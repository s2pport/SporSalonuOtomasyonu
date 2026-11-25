using System.Linq;

namespace SporSalonu.BLL
{
    /// <summary>
    /// Tüm ekip üyelerinin kullanabileceği ortak doğrulama yardımcıları.
    /// </summary>
    public static class Dogrulama
    {
        public static bool BosMu(string metin)
        {
            return string.IsNullOrWhiteSpace(metin);
        }

        /// <summary>"0 (532) 123 45 67" gibi girişlerden sadece rakamları bırakır.</summary>
        public static string TelefonTemizle(string telefon)
        {
            return new string((telefon ?? "").Where(char.IsDigit).ToArray());
        }

        /// <summary>Türkiye cep telefonu: 05XXXXXXXXX (11 hane).</summary>
        public static bool TelefonGecerliMi(string telefon)
        {
            string temiz = TelefonTemizle(telefon);
            return temiz.Length == 11 && temiz.StartsWith("05");
        }

        /// <summary>Ad / soyad: sadece harf, boşluk ve tire.</summary>
        public static bool AdSoyadGecerliMi(string metin)
        {
            return !BosMu(metin) && metin.Trim().All(c => char.IsLetter(c) || c == ' ' || c == '-');
        }
    }
}
