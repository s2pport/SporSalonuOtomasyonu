using System;
using System.Data;
using System.Data.SqlClient;

namespace SporSalonu.DAL
{
    /// <summary>
    /// Tüm DAL sınıflarının ortak kullandığı ADO.NET yardımcısı.
    /// Her metot bağlantıyı açar, işi yapar ve using ile kapatır.
    /// SQL her zaman PARAMETRELİ yazılmalıdır (SQL Injection koruması).
    /// </summary>
    public static class SqlYardimci
    {
        /// <summary>null değeri DBNull'a çevirerek parametre üretir.</summary>
        public static SqlParameter Parametre(string ad, object deger)
        {
            return new SqlParameter(ad, deger ?? DBNull.Value);
        }

        /// <summary>INSERT / UPDATE / DELETE. Etkilenen satır sayısını döndürür.</summary>
        public static int KomutCalistir(string sql, params SqlParameter[] parametreler)
        {
            using (SqlConnection con = Baglanti.Olustur())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                if (parametreler != null) cmd.Parameters.AddRange(parametreler);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>Tek değer döndüren sorgular (COUNT, SUM, SCOPE_IDENTITY ...).</summary>
        public static object TekDeger(string sql, params SqlParameter[] parametreler)
        {
            using (SqlConnection con = Baglanti.Olustur())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                if (parametreler != null) cmd.Parameters.AddRange(parametreler);
                con.Open();
                return cmd.ExecuteScalar();
            }
        }

        /// <summary>SELECT sonucunu DataTable olarak döndürür (DataGridView.DataSource için ideal).</summary>
        public static DataTable Tablo(string sql, params SqlParameter[] parametreler)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = Baglanti.Olustur())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                if (parametreler != null) cmd.Parameters.AddRange(parametreler);
                da.Fill(dt);      // Fill, bağlantıyı kendisi açıp kapatır
            }
            return dt;
        }
    }
}
