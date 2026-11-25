using System;

namespace SporSalonu.Entities
{
    public class Paket
    {
        public int PaketId { get; set; }
        public string PaketAdi { get; set; }
        public int SureGun { get; set; }
        public decimal Fiyat { get; set; }
        public string Aciklama { get; set; }
        public bool AktifMi { get; set; }
    }
}