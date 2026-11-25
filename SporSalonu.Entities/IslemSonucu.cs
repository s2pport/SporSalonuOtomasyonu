namespace SporSalonu.Entities
{
    /// <summary>
    /// BLL metotlarının UI'a döndürdüğü ortak sonuç nesnesi.
    /// Ekip arkadaşları da kendi BLL sınıflarında aynısını kullanabilir.
    /// </summary>
    public class IslemSonucu
    {
        public bool Basarili { get; set; }
        public string Mesaj { get; set; }

        public static IslemSonucu Basari(string mesaj = "")
        {
            return new IslemSonucu { Basarili = true, Mesaj = mesaj };
        }

        public static IslemSonucu Hata(string mesaj)
        {
            return new IslemSonucu { Basarili = false, Mesaj = mesaj };
        }
    }
}
