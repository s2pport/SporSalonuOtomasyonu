using System;
using System.Drawing;
using System.Windows.Forms;
using SporSalonu.BLL;
using SporSalonu.Entities;

namespace SporSalonu.UI
{
    /// <summary>UI-01 Giriş Ekranı. Designer'daki kontrol adları rehberdeki tabloyla BİREBİR aynı olmalı.</summary>
    public partial class GirisForm : Form
    {
        private readonly KullaniciBll _bll = new KullaniciBll();

        public GirisForm()
        {
            InitializeComponent();

            // Olaylar kodla bağlanıyor: Designer'da kontrollere ÇİFT TIKLAMAYIN (çift tetiklenir).
            Load += GirisForm_Load;
            btnGiris.Click += btnGiris_Click;
            btnIptal.Click += btnIptal_Click;
            chkParolaGoster.CheckedChanged += chkParolaGoster_CheckedChanged;
        }

        private void GirisForm_Load(object sender, EventArgs e)
        {
            AcceptButton = btnGiris;      // Enter tuşu = Giriş Yap
            CancelButton = btnIptal;      // Esc tuşu  = İptal
            txtParola.UseSystemPasswordChar = true;
            lblDurum.Text = "";
            lblDurum.ForeColor = Color.Firebrick;
            txtKullaniciAdi.Focus();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            btnGiris.Enabled = false;     // Çift tıklamayı engelle (hash hesabı ~0.1 sn sürer)
            Cursor = Cursors.WaitCursor;
            try
            {
                IslemSonucu sonuc = _bll.GirisYap(txtKullaniciAdi.Text, txtParola.Text);

                if (sonuc.Basarili)
                {
                    DialogResult = DialogResult.OK;   // ShowDialog() OK döner, form kapanır -> Program.cs AnaForm'u açar
                }
                else
                {
                    lblDurum.Text = sonuc.Mesaj;
                    txtParola.Clear();
                    txtParola.Focus();
                }
            }
            finally
            {
                Cursor = Cursors.Default;
                btnGiris.Enabled = true;
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void chkParolaGoster_CheckedChanged(object sender, EventArgs e)
        {
            txtParola.UseSystemPasswordChar = !chkParolaGoster.Checked;
        }
    }
}
