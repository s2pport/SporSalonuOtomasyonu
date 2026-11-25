using System;
using System.Configuration;          // Referans: System.Configuration
using System.Data.SqlClient;

namespace SporSalonu.DAL
{
    /// <summary>
    /// SQL Server bağlantı altyapısı. Bağlantı cümlesi UI projesindeki App.config'ten okunur.
    /// </summary>
    public static class Baglanti
    {
        private const string AyarAdi = "SporSalonuDB";

        private static string BaglantiCumlesi
        {
            get
            {
                ConnectionStringSettings ayar = ConfigurationManager.ConnectionStrings[AyarAdi];
                if (ayar == null || string.IsNullOrWhiteSpace(ayar.ConnectionString))
                    throw new InvalidOperationException(
                        "App.config içinde '" + AyarAdi + "' adlı bağlantı cümlesi bulunamadı.");
                return ayar.ConnectionString;
            }
        }

        /// <summary>
        /// Yeni (kapalı) bir bağlantı üretir. Çağıran taraf using ile kullanmalıdır.
        /// </summary>
        public static SqlConnection Olustur()
        {
            return new SqlConnection(BaglantiCumlesi);
        }

        /// <summary>
        /// Veritabanına ulaşılıp ulaşılamadığını sınar (risk tablosundaki "bağlantı kopması" önlemi).
        /// </summary>
        public static bool TestEt(out string hata)
        {
            try
            {
                using (SqlConnection con = Olustur())
                {
                    con.Open();
                }
                hata = null;
                return true;
            }
            catch (Exception ex)
            {
                hata = ex.Message;
                return false;
            }
        }
    }
}
