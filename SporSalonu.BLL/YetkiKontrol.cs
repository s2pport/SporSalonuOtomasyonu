using System;
using SporSalonu.Entities;

namespace SporSalonu.BLL
{
    /// <summary>Yetkisiz işlem denendiğinde fırlatılır.</summary>
    public class YetkiHatasi : Exception
    {
        public YetkiHatasi(string mesaj) : base(mesaj) { }
    }

    /// <summary>
    /// Rapor 9.2: "Yetkiler yalnızca butonları gizlemekle kalmayacak, BLL'de de kesin kontrol edilecek."
    /// Rol gerektiren her BLL metodunun İLK satırında bu sınıf çağrılır.
    /// Örnek:  public IslemSonucu PaketEkle(...) { YetkiKontrol.YoneticiGerekli(); ... }
    /// </summary>
    public static class YetkiKontrol
    {
        public static void GirisGerekli()
        {
            if (!Oturum.GirisYapildiMi)
                throw new YetkiHatasi("Bu işlem için önce giriş yapmalısınız.");
        }

        public static void YoneticiGerekli()
        {
            GirisGerekli();
            if (!Oturum.YoneticiMi)
                throw new YetkiHatasi("Bu işlem yalnızca Yönetici yetkisiyle yapılabilir.");
        }

        public static void RolGerekli(params RolTipi[] izinliRoller)
        {
            GirisGerekli();
            foreach (RolTipi rol in izinliRoller)
                if (Oturum.AktifKullanici.RolID == (int)rol) return;

            throw new YetkiHatasi("Bu işlem için yetkiniz bulunmamaktadır.");
        }
    }
}
