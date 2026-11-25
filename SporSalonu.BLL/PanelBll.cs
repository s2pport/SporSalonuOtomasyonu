using SporSalonu.DAL;
using SporSalonu.Entities;

namespace SporSalonu.BLL
{
    /// <summary>
    /// Ana ekran özet kartları (FG-11). Günlük ödeme toplamı yalnızca Yönetici içindir;
    /// bu kural butonu gizlemekle değil BURADA, BLL'de uygulanır.
    /// </summary>
    public class PanelBll
    {
        private readonly PanelDal _dal = new PanelDal();

        public PanelOzeti OzetGetir()
        {
            YetkiKontrol.GirisGerekli();

            PanelOzeti ozet = new PanelOzeti
            {
                ToplamUye = _dal.ToplamUye(),
                AktifUyelik = _dal.AktifUyelik(),
                SuresiDolmus = _dal.SuresiDolmusUyelik()
            };

            if (Oturum.YoneticiMi)
                ozet.GunlukOdeme = _dal.GunlukOdemeToplami();

            return ozet;
        }
    }
}
