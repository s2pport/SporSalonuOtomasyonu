namespace SporSalonu.Entities
{
    /// <summary>
    /// Ana ekrandaki özet kartlarında gösterilen bilgiler (FG-11).
    /// </summary>
    public class PanelOzeti
    {
        public int ToplamUye { get; set; }
        public int AktifUyelik { get; set; }
        public int SuresiDolmus { get; set; }
        public decimal GunlukOdeme { get; set; }   // Sadece Yönetici için doldurulur
    }
}
