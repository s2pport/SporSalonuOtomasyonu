using System.Data.SqlClient;
using SporSalonu.DAL;
using SporSalonu.Entities;

namespace SporSalonu.BLL
{
    /// <summary>
    /// Uygulama açılışında çalışan hazırlık adımları. UI, DAL'a doğrudan dokunmasın diye
    /// bağlantı testi ve varsayılan hesap oluşturma burada toplanır.
    /// </summary>
    public class BaslangicBll
    {
        public IslemSonucu Hazirla()
        {
            string hata;
            if (!Baglanti.TestEt(out hata))
                return IslemSonucu.Hata(
                    "Veritabanına bağlanılamadı." + System.Environment.NewLine + System.Environment.NewLine +
                    hata + System.Environment.NewLine + System.Environment.NewLine +
                    "SQL Server'ın çalıştığını ve App.config içindeki bağlantı cümlesini kontrol edin.");

            try
            {
                new KullaniciBll().VarsayilanKullanicilariOlustur();
                return IslemSonucu.Basari();
            }
            catch (SqlException ex)
            {
                return IslemSonucu.Hata(
                    "Veritabanı tabloları bulunamadı veya hatalı." + System.Environment.NewLine +
                    "Önce Veritabani\\01_Kurulum.sql dosyasını çalıştırın." + System.Environment.NewLine + System.Environment.NewLine +
                    ex.Message);
            }
        }
    }
}
