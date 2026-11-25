using System;

namespace SporSalonu.DAL
{
    /// <summary>
    /// Ana ekran özet kartları için sayım sorguları (Uyeler, Uyelikler, Odemeler tabloları gerekir).
    /// </summary>
    public class PanelDal
    {
        public int ToplamUye()
        {
            return Sayi("SELECT COUNT(*) FROM Uyeler WHERE AktifMi = 1");
        }

        public int AktifUyelik()
        {
            return Sayi(
                @"SELECT COUNT(*) FROM Uyelikler ul
                  INNER JOIN Uyeler u ON u.UyeID = ul.UyeID
                  WHERE u.AktifMi = 1
                    AND CAST(GETDATE() AS DATE) BETWEEN ul.BaslangicTarihi AND ul.BitisTarihi");
        }

        public int SuresiDolmusUyelik()
        {
            return Sayi(
                @"SELECT COUNT(*) FROM Uyelikler ul
                  INNER JOIN Uyeler u ON u.UyeID = ul.UyeID
                  WHERE u.AktifMi = 1
                    AND ul.BitisTarihi < CAST(GETDATE() AS DATE)");
        }

        public decimal GunlukOdemeToplami()
        {
            object sonuc = SqlYardimci.TekDeger(
                @"SELECT ISNULL(SUM(Tutar), 0) FROM Odemeler
                  WHERE CAST(OdemeTarihi AS DATE) = CAST(GETDATE() AS DATE)");
            return Convert.ToDecimal(sonuc);
        }

        private static int Sayi(string sql)
        {
            return Convert.ToInt32(SqlYardimci.TekDeger(sql));
        }
    }
}
