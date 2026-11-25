using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SporSalonu.DAL;
using SporSalonu.Entities;

namespace SporSalonu.BLL
{
    /// <summary>
    /// Giriş, çıkış, parola değiştirme ve varsayılan hesap oluşturma iş kuralları (FG-01).
    /// </summary>
    public class KullaniciBll
    {
        private readonly KullaniciDal _dal = new KullaniciDal();

        // ---- Kaba kuvvet (brute-force) koruması: 5 hatalı denemede 1 dakika kilit ----
        private const int MaksHataliDeneme = 5;
        private static readonly TimeSpan KilitSuresi = TimeSpan.FromMinutes(1);
        private static readonly Dictionary<string, DenemeKaydi> _denemeler =
            new Dictionary<string, DenemeKaydi>();

        private class DenemeKaydi
        {
            public int HataliSayisi;
            public DateTime KilitBitis = DateTime.MinValue;
        }

        // Kullanıcı bulunamadığında da hash hesaplanır; böylece yanıt süresine bakarak
        // "bu kullanıcı adı var mı" sorusunun cevabı sızmaz.
        private static readonly string SahteSalt = Convert.ToBase64String(new byte[16]);

        public IslemSonucu GirisYap(string kullaniciAdi, string parola)
        {
            kullaniciAdi = (kullaniciAdi ?? "").Trim();

            if (kullaniciAdi.Length == 0 || string.IsNullOrEmpty(parola))
                return IslemSonucu.Hata("Kullanıcı adı ve parola boş bırakılamaz.");

            DenemeKaydi kayit = DenemeKaydiGetir(kullaniciAdi.ToLowerInvariant());
            if (kayit.KilitBitis > DateTime.Now)
            {
                int kalanSn = (int)Math.Ceiling((kayit.KilitBitis - DateTime.Now).TotalSeconds);
                return IslemSonucu.Hata("Çok fazla hatalı deneme yapıldı. " + kalanSn + " saniye sonra tekrar deneyin.");
            }

            Kullanici kullanici;
            bool parolaDogru;
            try
            {
                kullanici = _dal.KullaniciAdiylaGetir(kullaniciAdi);
                if (kullanici == null)
                {
                    ParolaYardimcisi.HashUret(parola, SahteSalt);
                    parolaDogru = false;
                }
                else
                {
                    parolaDogru = ParolaYardimcisi.Dogrula(parola, kullanici.Salt, kullanici.ParolaHash);
                }
            }
            catch (SqlException)
            {
                return IslemSonucu.Hata("Veritabanına bağlanılamadı. SQL Server'ın çalıştığından emin olun.");
            }

            if (!parolaDogru)
            {
                kayit.HataliSayisi++;
                if (kayit.HataliSayisi >= MaksHataliDeneme)
                {
                    kayit.KilitBitis = DateTime.Now.Add(KilitSuresi);
                    kayit.HataliSayisi = 0;
                }
                // Mesaj bilerek genel tutulur: kullanıcı adı mı parola mı yanlış, söylenmez.
                return IslemSonucu.Hata("Kullanıcı adı veya parola hatalı.");
            }

            if (!kullanici.AktifMi)
                return IslemSonucu.Hata("Bu hesap pasif durumdadır. Lütfen yöneticinize başvurun.");

            kayit.HataliSayisi = 0;
            kayit.KilitBitis = DateTime.MinValue;

            // Oturumda hash ve salt tutulmaz.
            kullanici.ParolaHash = null;
            kullanici.Salt = null;
            Oturum.Baslat(kullanici);

            return IslemSonucu.Basari("Hoş geldiniz, " + kullanici.KullaniciAdi + ".");
        }

        public void CikisYap()
        {
            Oturum.Kapat();
        }

        public IslemSonucu ParolaDegistir(string eskiParola, string yeniParola, string yeniParolaTekrar)
        {
            YetkiKontrol.GirisGerekli();

            if (string.IsNullOrEmpty(eskiParola) || string.IsNullOrEmpty(yeniParola) || string.IsNullOrEmpty(yeniParolaTekrar))
                return IslemSonucu.Hata("Tüm alanları doldurunuz.");

            if (yeniParola != yeniParolaTekrar)
                return IslemSonucu.Hata("Yeni parola ve tekrarı aynı değil.");

            string guclulukMesaji;
            if (!ParolaYardimcisi.GucluMu(yeniParola, out guclulukMesaji))
                return IslemSonucu.Hata(guclulukMesaji);

            if (eskiParola == yeniParola)
                return IslemSonucu.Hata("Yeni parola eski parolayla aynı olamaz.");

            try
            {
                Kullanici k = _dal.KullaniciAdiylaGetir(Oturum.AktifKullanici.KullaniciAdi);
                if (k == null || !ParolaYardimcisi.Dogrula(eskiParola, k.Salt, k.ParolaHash))
                    return IslemSonucu.Hata("Mevcut parola hatalı.");

                string yeniSalt = ParolaYardimcisi.SaltUret();          // her değişimde yeni salt
                string yeniHash = ParolaYardimcisi.HashUret(yeniParola, yeniSalt);
                _dal.ParolaGuncelle(k.KullaniciID, yeniHash, yeniSalt);
                return IslemSonucu.Basari("Parolanız başarıyla güncellendi.");
            }
            catch (SqlException)
            {
                return IslemSonucu.Hata("Veritabanı hatası nedeniyle parola değiştirilemedi.");
            }
        }

        /// <summary>
        /// Rapor 3.2: hesaplar doğrudan veritabanına eklenir (hesap oluşturma ekranı yok).
        /// Hash'i SQL'de üretemediğimiz için, tablo boşsa ilk açılışta iki hesap otomatik oluşturulur.
        /// </summary>
        public void VarsayilanKullanicilariOlustur()
        {
            if (_dal.KullaniciSayisi() > 0) return;

            HesapEkle("admin", "Admin123!", RolTipi.Yonetici);
            HesapEkle("resepsiyon", "Resepsiyon123!", RolTipi.Resepsiyon);
        }

        private void HesapEkle(string kullaniciAdi, string parola, RolTipi rol)
        {
            string salt = ParolaYardimcisi.SaltUret();
            _dal.Ekle(new Kullanici
            {
                RolID = (int)rol,
                KullaniciAdi = kullaniciAdi,
                Salt = salt,
                ParolaHash = ParolaYardimcisi.HashUret(parola, salt),
                AktifMi = true
            });
        }

        private static DenemeKaydi DenemeKaydiGetir(string anahtar)
        {
            lock (_denemeler)
            {
                DenemeKaydi kayit;
                if (!_denemeler.TryGetValue(anahtar, out kayit))
                {
                    kayit = new DenemeKaydi();
                    _denemeler[anahtar] = kayit;
                }
                return kayit;
            }
        }
    }
}
