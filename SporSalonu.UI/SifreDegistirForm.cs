using System;
using System.Drawing;
using System.Windows.Forms;
using SporSalonu.BLL;
using SporSalonu.Entities;

namespace SporSalonu.UI
{
   
    public partial class SifreDegistirForm : Form
    {
        private readonly KullaniciBll _bll = new KullaniciBll();

        public SifreDegistirForm()
        {
            InitializeComponent();

            Load += (s, e) =>
            {
                AcceptButton = btnKaydet;
                CancelButton = btnVazgec;
                lblGucMesaji.Text = "";
                txtEskiParola.UseSystemPasswordChar = true;
                txtYeniParola.UseSystemPasswordChar = true;
                txtYeniParolaTekrar.UseSystemPasswordChar = true;
            };
            txtYeniParola.TextChanged += txtYeniParola_TextChanged;
            btnKaydet.Click += btnKaydet_Click;
            btnVazgec.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }

        
        private void txtYeniParola_TextChanged(object sender, EventArgs e)
        {
            if (txtYeniParola.Text.Length == 0) { lblGucMesaji.Text = ""; return; }

            string mesaj;
            if (ParolaYardimcisi.GucluMu(txtYeniParola.Text, out mesaj))
            {
                lblGucMesaji.ForeColor = Color.SeaGreen;
                lblGucMesaji.Text = "✔ Parola yeterince güçlü.";
            }
            else
            {
                lblGucMesaji.ForeColor = Color.Firebrick;
                lblGucMesaji.Text = mesaj;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            IslemSonucu sonuc = _bll.ParolaDegistir(
                txtEskiParola.Text, txtYeniParola.Text, txtYeniParolaTekrar.Text);

            if (sonuc.Basarili)
            {
                MesajKutusu.Bilgi(sonuc.Mesaj);
                DialogResult = DialogResult.OK;
            }
            else
            {
                MesajKutusu.Uyari(sonuc.Mesaj);
            }
        }
    }
}

