using System;
using System.Windows.Forms;
using SporSalonu.BLL;
using SporSalonu.Entities;

namespace SporSalonu.UI
{
    /// <summary>
    /// UI-02 Ana Panel: MDI kapsayıcı + rol bazlı menü + özet kartları + durum çubuğu.
    /// Diğer ekranlar (UyeForm, UyelikForm...) bu formun içinde alt pencere olarak açılır.
    /// </summary>
    public partial class AnaForm : Form
    {
        /// <summary>true ise Program.cs giriş ekranını tekrar açar (Oturumu Kapat).</summary>
        public bool YenidenGirisYapilsin { get; private set; }

        private bool _kapanisOnaylandi;
        private readonly PanelBll _panelBll = new PanelBll();

        public AnaForm()
        {
            InitializeComponent();

            Load += AnaForm_Load;
            FormClosing += AnaForm_FormClosing;
            FormClosed += (s, e) => Oturum.Kapat();
            tmrSaat.Tick += (s, e) => SaatiGuncelle();

            // ---- Menü olayları ----
            // Ekip arkadaşları formlarını bitirince "Yakinda(...)" satırını FormAc<...>() ile değiştirecek.
            mnuUyeler.Click += (s, e) => FormAc<UyeYonetimiForm>();      // FormAc<UyeForm>();
            mnuPaketler.Click += (s, e) => FormAc<PaketForm>();            // FormAc<PaketForm>();
            mnuUyelik.Click += (s, e) => Yakinda("Üyelik");            // FormAc<UyelikForm>();
            mnuOdeme.Click += (s, e) => Yakinda("Ödeme");             // FormAc<OdemeForm>();
            mnuDondurma.Click += (s, e) => Yakinda("Dondurma");          // FormAc<DondurmaForm>();
            mnuGirisCikis.Click += (s, e) => Yakinda("Giriş-Çıkış");       // FormAc<GirisCikisForm>();

            mnuSifreDegistir.Click += mnuSifreDegistir_Click;
            mnuYenile.Click += (s, e) => OzetiYukle();
            mnuOturumKapat.Click += mnuOturumKapat_Click;
            mnuCikis.Click += (s, e) => Close();
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            Kullanici k = Oturum.AktifKullanici;

            Text = "Spor Salonu Yönetim Otomasyonu";
            tslKullanici.Text = "Kullanıcı: " + k.KullaniciAdi;
            tslRol.Text = "Rol: " + k.RolAdi;

            YetkileriUygula();
            OzetiYukle();
            SaatiGuncelle();
            tmrSaat.Start();
        }

        // ------------------------------------------------------------------
        //  ROL BAZLI ARAYÜZ  (asıl güvenlik BLL'de; burası sadece kullanıcıya kolaylık)
        // ------------------------------------------------------------------
        private void YetkileriUygula()
        {
            bool yonetici = Oturum.YoneticiMi;

            mnuPaketler.Visible = yonetici;        // UI-04: Paket Yönetimi yalnızca Yönetici
            lblGunlukOdeme.Visible = yonetici;     // Günlük gelir kartı yalnızca Yönetici
        }

        private void PaketEkraniniAc()
        {
            YetkiKontrol.YoneticiGerekli();        // Menü bir şekilde görünse bile Resepsiyon giremez
            Yakinda("Paket Yönetimi");             // FormAc<PaketForm>();
        }

        // ------------------------------------------------------------------
        //  EKRANLAR ARASI GEÇİŞ
        // ------------------------------------------------------------------
        /// <summary>
        /// T türündeki formu MDI alt penceresi olarak açar; zaten açıksa yenisini açmaz, öne getirir.
        /// Kullanım: FormAc&lt;UyeForm&gt;();   (Formun parametresiz yapıcısı olmalı)
        /// </summary>
        private void FormAc<T>() where T : Form, new()
        {
            foreach (Form acik in MdiChildren)
            {
                if (acik is T)
                {
                    if (acik.WindowState == FormWindowState.Minimized)
                        acik.WindowState = FormWindowState.Normal;
                    acik.Activate();
                    return;
                }
            }

            T yeni = new T();
            yeni.MdiParent = this;
            yeni.Show();
        }

        private void Yakinda(string ekranAdi)
        {
            MesajKutusu.Bilgi(ekranAdi + " ekranı henüz projeye eklenmedi.");
        }

        // ------------------------------------------------------------------
        //  ÖZET KARTLARI
        // ------------------------------------------------------------------
        private void OzetiYukle()
        {
            try
            {
                PanelOzeti o = _panelBll.OzetGetir();
                lblToplamUye.Text = "Toplam Üye" + Environment.NewLine + o.ToplamUye;
                lblAktifUyelik.Text = "Aktif Üyelik" + Environment.NewLine + o.AktifUyelik;
                lblSuresiDolmus.Text = "Süresi Dolmuş" + Environment.NewLine + o.SuresiDolmus;
                lblGunlukOdeme.Text = "Bugünkü Ödemeler" + Environment.NewLine + o.GunlukOdeme.ToString("C2");
            }
            catch (Exception)
            {
                // Üye/üyelik/ödeme tabloları henüz yoksa ya da bağlantı sorunluysa uygulama çökmez.
                lblToplamUye.Text = "Toplam Üye" + Environment.NewLine + "-";
                lblAktifUyelik.Text = "Aktif Üyelik" + Environment.NewLine + "-";
                lblSuresiDolmus.Text = "Süresi Dolmuş" + Environment.NewLine + "-";
                lblGunlukOdeme.Text = "Bugünkü Ödemeler" + Environment.NewLine + "-";
            }
        }

        private void SaatiGuncelle()
        {
            tslSaat.Text = DateTime.Now.ToString("dd.MM.yyyy  HH:mm:ss");
        }

        // ------------------------------------------------------------------
        //  HESAP MENÜSÜ
        // ------------------------------------------------------------------
        private void mnuSifreDegistir_Click(object sender, EventArgs e)
        {
            using (SifreDegistirForm f = new SifreDegistirForm())
            {
                f.ShowDialog(this);
            }
        }

        private void mnuOturumKapat_Click(object sender, EventArgs e)
        {
            if (!MesajKutusu.Soru("Oturumu kapatmak istiyor musunuz?")) return;

            _kapanisOnaylandi = true;           // FormClosing tekrar sormasın
            YenidenGirisYapilsin = true;        // Program.cs giriş ekranını yeniden açacak
            Close();
        }

        private void AnaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_kapanisOnaylandi || e.CloseReason != CloseReason.UserClosing) return;

            if (MesajKutusu.Soru("Uygulamadan çıkmak istiyor musunuz?"))
                _kapanisOnaylandi = true;
            else
                e.Cancel = true;
        }
    }
}
