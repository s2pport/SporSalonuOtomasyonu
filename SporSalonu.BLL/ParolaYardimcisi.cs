using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SporSalonu.BLL
{
    /// <summary>
    /// Güvenli parola işlemleri (FOG-02): kullanıcıya özgü salt + PBKDF2-SHA256.
    /// Düz parola ASLA veritabanına yazılmaz. Gereksinim: .NET Framework 4.7.2 ve üzeri.
    /// </summary>
    public static class ParolaYardimcisi
    {
        private const int SaltBoyutu = 16;      // byte  -> Base64'te 24 karakter (Salt NVARCHAR(100) sütununa sığar)
        private const int HashBoyutu = 32;      // byte  -> Base64'te 44 karakter (ParolaHash NVARCHAR(255) sütununa sığar)
        private const int Iterasyon = 100000;   // Brute-force'u yavaşlatmak için tekrar sayısı

        /// <summary>Kriptografik olarak rastgele yeni bir salt üretir.</summary>
        public static string SaltUret()
        {
            byte[] salt = new byte[SaltBoyutu];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }

        /// <summary>Parola + salt'tan PBKDF2 özeti üretir.</summary>
        public static string HashUret(string parola, string saltBase64)
        {
            byte[] salt = Convert.FromBase64String(saltBase64);
            using (Rfc2898DeriveBytes pbkdf2 =
                   new Rfc2898DeriveBytes(parola, salt, Iterasyon, HashAlgorithmName.SHA256))
            {
                return Convert.ToBase64String(pbkdf2.GetBytes(HashBoyutu));
            }
        }

        /// <summary>Girilen parolayı kayıtlı hash ile karşılaştırır.</summary>
        public static bool Dogrula(string parola, string saltBase64, string kayitliHash)
        {
            string hesaplanan = HashUret(parola, saltBase64);
            return SabitZamanliKarsilastir(hesaplanan, kayitliHash);
        }

        // == yerine sabit sürede karşılaştırma: süre farkından bilgi sızmasını (timing attack) önler.
        private static bool SabitZamanliKarsilastir(string a, string b)
        {
            byte[] x = Encoding.UTF8.GetBytes(a ?? "");
            byte[] y = Encoding.UTF8.GetBytes(b ?? "");
            int fark = x.Length ^ y.Length;
            for (int i = 0; i < x.Length && i < y.Length; i++)
                fark |= x[i] ^ y[i];
            return fark == 0;
        }

        /// <summary>
        /// Parola güç politikası: en az 8 karakter, büyük harf, küçük harf, rakam ve özel karakter.
        /// </summary>
        public static bool GucluMu(string parola, out string mesaj)
        {
            if (string.IsNullOrEmpty(parola) || parola.Length < 8)
            { mesaj = "Parola en az 8 karakter olmalıdır."; return false; }
            if (!parola.Any(char.IsUpper))
            { mesaj = "Parola en az bir büyük harf içermelidir."; return false; }
            if (!parola.Any(char.IsLower))
            { mesaj = "Parola en az bir küçük harf içermelidir."; return false; }
            if (!parola.Any(char.IsDigit))
            { mesaj = "Parola en az bir rakam içermelidir."; return false; }
            if (parola.All(char.IsLetterOrDigit))
            { mesaj = "Parola en az bir özel karakter (örn. ! ? # $) içermelidir."; return false; }

            mesaj = "";
            return true;
        }
    }
}
