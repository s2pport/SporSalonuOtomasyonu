using System;

namespace SporSalonu.Entities
{
    public class Uye
    {
        public int UyeId { get; set; }
        public string AdSoyad { get; set; }
        public string TcNo { get; set; }
        public string Telefon { get; set; }
        public string Eposta { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Cinsiyet { get; set; }
        public bool AktifMi { get; set; }
        public DateTime KayitTarihi { get; set; }
    }
}