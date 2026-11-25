namespace SporSalonu.Entities
{
    /// <summary>
    /// Kullanicilar tablosundaki bir satırı temsil eder (RolAdi, Roller tablosundan JOIN ile gelir).
    /// </summary>
    public class Kullanici
    {
        public int KullaniciID { get; set; }
        public int RolID { get; set; }
        public string RolAdi { get; set; }
        public string KullaniciAdi { get; set; }
        public string ParolaHash { get; set; }
        public string Salt { get; set; }
        public bool AktifMi { get; set; }
    }
}
