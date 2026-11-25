using System.Collections.Generic;
using SporSalonu.DAL;
using SporSalonu.Entities;

namespace SporSalonu.BLL
{
    public class PaketBll
    {
        private readonly PaketDal _paketDal = new PaketDal();

        public List<Paket> Listele()
        {
            return _paketDal.Listele();
        }

        public string Ekle(Paket paket)
        {
            string hata = Dogrula(paket);
            if (hata != null) return hata;

            _paketDal.Ekle(paket);
            return null;
        }

        public string Guncelle(Paket paket)
        {
            if (paket.PaketId <= 0) return "Güncellenecek paketi tablodan seçiniz.";
            string hata = Dogrula(paket);
            if (hata != null) return hata;

            _paketDal.Guncelle(paket);
            return null;
        }

        public string Sil(int paketId)
        {
            if (paketId <= 0) return "Silinecek paketi tablodan seçiniz.";
            _paketDal.Sil(paketId);
            return null;
        }

        private string Dogrula(Paket paket)
        {
            if (string.IsNullOrWhiteSpace(paket.PaketAdi))
                return "Paket adı boş bırakılamaz.";
            if (paket.SureGun <= 0)
                return "Süre en az 1 gün olmalıdır.";
            if (paket.Fiyat < 0)
                return "Fiyat 0'dan küçük olamaz.";
            return null;
        }
    }
}