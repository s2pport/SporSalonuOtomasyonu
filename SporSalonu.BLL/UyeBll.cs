using System;
using System.Collections.Generic;
using SporSalonu.DAL;
using SporSalonu.Entities;

namespace SporSalonu.BLL
{
    public class UyeBll
    {
        private readonly UyeDal _uyeDal = new UyeDal();

        public List<Uye> Listele(string arama = "")
        {
            return _uyeDal.Listele(arama);
        }

        public string Ekle(Uye uye)
        {
            string hata = Dogrula(uye);
            if (hata != null) return hata;

            _uyeDal.Ekle(uye);
            return null;
        }

        public string Guncelle(Uye uye)
        {
            if (uye.UyeId <= 0) return "Güncellenecek üyeyi tablodan seçiniz.";
            string hata = Dogrula(uye);
            if (hata != null) return hata;

            _uyeDal.Guncelle(uye);
            return null;
        }

        public string Sil(int uyeId)
        {
            if (uyeId <= 0) return "Silinecek üyeyi tablodan seçiniz.";
            _uyeDal.Sil(uyeId);
            return null;
        }

        private string Dogrula(Uye uye)
        {
            if (string.IsNullOrWhiteSpace(uye.AdSoyad))
                return "Ad Soyad boş bırakılamaz.";
            if (string.IsNullOrWhiteSpace(uye.TcNo) || uye.TcNo.Length != 11)
                return "TC Kimlik No 11 haneli olmalıdır.";
            if (string.IsNullOrWhiteSpace(uye.Telefon))
                return "Telefon numarası boş bırakılamaz.";
            if (string.IsNullOrWhiteSpace(uye.Cinsiyet))
                return "Lütfen cinsiyet seçiniz.";
            return null;
        }
    }
}