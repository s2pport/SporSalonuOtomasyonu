using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using SporSalonu.Entities;

namespace SporSalonu.DAL
{
    public class UyeDal
    {
        private readonly string _baglantiCumlesi =
            ConfigurationManager.ConnectionStrings["SporSalonuDb"].ConnectionString;

        public List<Uye> Listele(string arama = "")
        {
            var liste = new List<Uye>();
            using (var conn = new SqlConnection(_baglantiCumlesi))
            {
                string sql = @"SELECT UyeId, AdSoyad, TcNo, Telefon, Eposta, DogumTarihi, Cinsiyet, AktifMi, KayitTarihi
                               FROM Uyeler
                               WHERE (@ara = '' OR AdSoyad LIKE '%' + @ara + '%' OR TcNo LIKE '%' + @ara + '%' OR Telefon LIKE '%' + @ara + '%')
                               ORDER BY UyeId DESC";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ara", arama ?? "");
                    conn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            liste.Add(new Uye
                            {
                                UyeId = Convert.ToInt32(dr["UyeId"]),
                                AdSoyad = dr["AdSoyad"].ToString(),
                                TcNo = dr["TcNo"].ToString(),
                                Telefon = dr["Telefon"].ToString(),
                                Eposta = dr["Eposta"] == DBNull.Value ? "" : dr["Eposta"].ToString(),
                                DogumTarihi = dr["DogumTarihi"] == DBNull.Value ? DateTime.Today : Convert.ToDateTime(dr["DogumTarihi"]),
                                Cinsiyet = dr["Cinsiyet"].ToString(),
                                AktifMi = Convert.ToBoolean(dr["AktifMi"]),
                                KayitTarihi = Convert.ToDateTime(dr["KayitTarihi"])
                            });
                        }
                    }
                }
            }
            return liste;
        }

        public void Ekle(Uye uye)
        {
            using (var conn = new SqlConnection(_baglantiCumlesi))
            {
                string sql = @"INSERT INTO Uyeler (AdSoyad, TcNo, Telefon, Eposta, DogumTarihi, Cinsiyet, AktifMi, KayitTarihi)
                               VALUES (@AdSoyad, @TcNo, @Telefon, @Eposta, @DogumTarihi, @Cinsiyet, @AktifMi, GETDATE())";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@AdSoyad", uye.AdSoyad);
                    cmd.Parameters.AddWithValue("@TcNo", uye.TcNo);
                    cmd.Parameters.AddWithValue("@Telefon", uye.Telefon);
                    cmd.Parameters.AddWithValue("@Eposta", (object)uye.Eposta ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DogumTarihi", uye.DogumTarihi);
                    cmd.Parameters.AddWithValue("@Cinsiyet", uye.Cinsiyet);
                    cmd.Parameters.AddWithValue("@AktifMi", uye.AktifMi);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Guncelle(Uye uye)
        {
            using (var conn = new SqlConnection(_baglantiCumlesi))
            {
                string sql = @"UPDATE Uyeler
                               SET AdSoyad=@AdSoyad, TcNo=@TcNo, Telefon=@Telefon, Eposta=@Eposta,
                                   DogumTarihi=@DogumTarihi, Cinsiyet=@Cinsiyet, AktifMi=@AktifMi
                               WHERE UyeId=@UyeId";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UyeId", uye.UyeId);
                    cmd.Parameters.AddWithValue("@AdSoyad", uye.AdSoyad);
                    cmd.Parameters.AddWithValue("@TcNo", uye.TcNo);
                    cmd.Parameters.AddWithValue("@Telefon", uye.Telefon);
                    cmd.Parameters.AddWithValue("@Eposta", (object)uye.Eposta ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DogumTarihi", uye.DogumTarihi);
                    cmd.Parameters.AddWithValue("@Cinsiyet", uye.Cinsiyet);
                    cmd.Parameters.AddWithValue("@AktifMi", uye.AktifMi);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Sil(int uyeId)
        {
            using (var conn = new SqlConnection(_baglantiCumlesi))
            {
                string sql = "DELETE FROM Uyeler WHERE UyeId=@UyeId";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UyeId", uyeId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}