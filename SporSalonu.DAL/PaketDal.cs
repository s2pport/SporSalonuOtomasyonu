using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using SporSalonu.Entities;

namespace SporSalonu.DAL
{
    public class PaketDal
    {
        private readonly string _baglantiCumlesi =
            ConfigurationManager.ConnectionStrings["SporSalonuDb"].ConnectionString;

        public List<Paket> Listele()
        {
            var liste = new List<Paket>();
            using (var conn = new SqlConnection(_baglantiCumlesi))
            {
                string sql = @"SELECT PaketId, PaketAdi, SureGun, Fiyat, Aciklama, AktifMi
                               FROM Paketler
                               ORDER BY PaketId DESC";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            liste.Add(new Paket
                            {
                                PaketId = Convert.ToInt32(dr["PaketId"]),
                                PaketAdi = dr["PaketAdi"].ToString(),
                                SureGun = Convert.ToInt32(dr["SureGun"]),
                                Fiyat = Convert.ToDecimal(dr["Fiyat"]),
                                Aciklama = dr["Aciklama"] == DBNull.Value ? "" : dr["Aciklama"].ToString(),
                                AktifMi = Convert.ToBoolean(dr["AktifMi"])
                            });
                        }
                    }
                }
            }
            return liste;
        }

        public void Ekle(Paket paket)
        {
            using (var conn = new SqlConnection(_baglantiCumlesi))
            {
                string sql = @"INSERT INTO Paketler (PaketAdi, SureGun, Fiyat, Aciklama, AktifMi)
                               VALUES (@PaketAdi, @SureGun, @Fiyat, @Aciklama, @AktifMi)";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@PaketAdi", paket.PaketAdi);
                    cmd.Parameters.AddWithValue("@SureGun", paket.SureGun);
                    cmd.Parameters.AddWithValue("@Fiyat", paket.Fiyat);
                    cmd.Parameters.AddWithValue("@Aciklama", (object)paket.Aciklama ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@AktifMi", paket.AktifMi);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Guncelle(Paket paket)
        {
            using (var conn = new SqlConnection(_baglantiCumlesi))
            {
                string sql = @"UPDATE Paketler
                               SET PaketAdi=@PaketAdi, SureGun=@SureGun, Fiyat=@Fiyat,
                                   Aciklama=@Aciklama, AktifMi=@AktifMi
                               WHERE PaketId=@PaketId";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@PaketId", paket.PaketId);
                    cmd.Parameters.AddWithValue("@PaketAdi", paket.PaketAdi);
                    cmd.Parameters.AddWithValue("@SureGun", paket.SureGun);
                    cmd.Parameters.AddWithValue("@Fiyat", paket.Fiyat);
                    cmd.Parameters.AddWithValue("@Aciklama", (object)paket.Aciklama ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@AktifMi", paket.AktifMi);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Sil(int paketId)
        {
            using (var conn = new SqlConnection(_baglantiCumlesi))
            {
                string sql = "DELETE FROM Paketler WHERE PaketId=@PaketId";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@PaketId", paketId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}