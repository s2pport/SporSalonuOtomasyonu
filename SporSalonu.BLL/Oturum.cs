using SporSalonu.Entities;

namespace SporSalonu.BLL
{
    /// <summary>
    /// Uygulama boyunca "şu an kim giriş yapmış?" bilgisini tutar.
    /// Baslat() internal'dır: UI katmanı kendi kendine oturum açamaz, yalnızca
    /// KullaniciBll.GirisYap() doğrulama sonrası oturum başlatabilir.
    /// </summary>
    public static class Oturum
    {
        public static Kullanici AktifKullanici { get; private set; }

        public static bool GirisYapildiMi
        {
            get { return AktifKullanici != null; }
        }

        public static bool YoneticiMi
        {
            get { return GirisYapildiMi && AktifKullanici.RolID == (int)RolTipi.Yonetici; }
        }

        public static bool ResepsiyonMu
        {
            get { return GirisYapildiMi && AktifKullanici.RolID == (int)RolTipi.Resepsiyon; }
        }

        internal static void Baslat(Kullanici kullanici)
        {
            AktifKullanici = kullanici;
        }

        public static void Kapat()
        {
            AktifKullanici = null;
        }
    }
}
