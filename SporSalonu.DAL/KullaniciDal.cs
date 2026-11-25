using System;
using System.Data;
using System.Data.SqlClient;
using SporSalonu.Entities;

namespace SporSalonu.DAL
{
    /// <summary>
    /// Kullanicilar tablosu için veri erişim işlemleri. İş kuralı BURADA YOK, sadece SQL var.
    /// </summary>
    public class KullaniciDal
    {
        public Kullanici KullaniciAdiylaGetir(string kullaniciAdi)
        {
            const string sql =
                @"SELECT k.KullaniciID, k.RolID, r.RolAdi, k.KullaniciAdi, k.ParolaHash, k.Salt, k.AktifMi
                  FROM Kullanicilar k
                  INNER JOIN Roller r ON r.RolID = k.RolID
                  WHERE k.KullaniciAdi = @ad";

            DataTable dt = SqlYardimci.Tablo(sql, new SqlParameter("@ad", kullaniciAdi));
            if (dt.Rows.Count == 0) return null;

            DataRow satir = dt.Rows[0];
            return new Kullanici
            {
                KullaniciID  = Convert.ToInt32(satir["KullaniciID"]),
                RolID        = Convert.ToInt32(satir["RolID"]),
                RolAdi       = Convert.ToString(satir["RolAdi"]),
                KullaniciAdi = Convert.ToString(satir["KullaniciAdi"]),
                ParolaHash   = Convert.ToString(satir["ParolaHash"]),
                Salt         = Convert.ToString(satir["Salt"]),
                AktifMi      = Convert.ToBoolean(satir["AktifMi"])
            };
        }

        public int KullaniciSayisi()
        {
            return Convert.ToInt32(SqlYardimci.TekDeger("SELECT COUNT(*) FROM Kullanicilar"));
        }

        public int Ekle(Kullanici k)
        {
            const string sql =
                @"INSERT INTO Kullanicilar (RolID, KullaniciAdi, ParolaHash, Salt, AktifMi)
                  VALUES (@rol, @ad, @hash, @salt, @aktif);
                  SELECT CAST(SCOPE_IDENTITY() AS INT);";

            object yeniId = SqlYardimci.TekDeger(sql,
                new SqlParameter("@rol", k.RolID),
                new SqlParameter("@ad", k.KullaniciAdi),
                new SqlParameter("@hash", k.ParolaHash),
                new SqlParameter("@salt", k.Salt),
                new SqlParameter("@aktif", k.AktifMi));
            return Convert.ToInt32(yeniId);
        }

        public int ParolaGuncelle(int kullaniciId, string yeniHash, string yeniSalt)
        {
            const string sql =
                "UPDATE Kullanicilar SET ParolaHash = @hash, Salt = @salt WHERE KullaniciID = @id";

            return SqlYardimci.KomutCalistir(sql,
                new SqlParameter("@hash", yeniHash),
                new SqlParameter("@salt", yeniSalt),
                new SqlParameter("@id", kullaniciId));
        }
    }
}
