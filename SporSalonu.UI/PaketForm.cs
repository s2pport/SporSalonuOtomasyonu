using System;
using System.Windows.Forms;
using SporSalonu.BLL;
using SporSalonu.Entities;

namespace SporSalonu.UI
{
    public partial class PaketForm : Form
    {
        private readonly PaketBll _paketBll = new PaketBll();
        private int _seciliPaketId = 0;

        public PaketForm()
        {
            InitializeComponent();
            OlaylariBagla();
        }

        private void OlaylariBagla()
        {
            Load += (s, e) => ListeyiYukle();
            btnEkle.Click += (s, e) => Ekle();
            btnGuncelle.Click += (s, e) => Guncelle();
            btnSil.Click += (s, e) => Sil();
            btnTemizle.Click += (s, e) => Temizle();
            dgvPaketler.CellClick += DgvPaketler_CellClick;
        }

        private void ListeyiYukle()
        {
            dgvPaketler.DataSource = _paketBll.Listele();
            if (dgvPaketler.Columns["PaketId"] != null)
                dgvPaketler.Columns["PaketId"].Visible = false;
        }

        private Paket FormdanPaketOlustur()
        {
            return new Paket
            {
                PaketId = _seciliPaketId,
                PaketAdi = txtPaketAdi.Text.Trim(),
                SureGun = (int)nudSureGun.Value,
                Fiyat = nudFiyat.Value,
                Aciklama = txtAciklama.Text.Trim(),
                AktifMi = chkAktif.Checked
            };
        }

        private void Ekle()
        {
            try
            {
                string hata = _paketBll.Ekle(FormdanPaketOlustur());
                if (hata != null)
                {
                    MessageBox.Show(hata, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                MessageBox.Show("Paket başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
                ListeyiYukle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Guncelle()
        {
            try
            {
                string hata = _paketBll.Guncelle(FormdanPaketOlustur());
                if (hata != null)
                {
                    MessageBox.Show(hata, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                MessageBox.Show("Paket güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
                ListeyiYukle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Sil()
        {
            if (_seciliPaketId <= 0)
            {
                MessageBox.Show("Silmek için tablodan bir paket seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Seçili paketi silmek istediğinize emin misiniz?", "Onay",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                _paketBll.Sil(_seciliPaketId);
                MessageBox.Show("Paket silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
                ListeyiYukle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvPaketler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var paket = dgvPaketler.Rows[e.RowIndex].DataBoundItem as Paket;
            if (paket == null) return;

            _seciliPaketId = paket.PaketId;
            txtPaketAdi.Text = paket.PaketAdi;
            nudSureGun.Value = paket.SureGun;
            nudFiyat.Value = paket.Fiyat;
            txtAciklama.Text = paket.Aciklama;
            chkAktif.Checked = paket.AktifMi;
        }

        private void Temizle()
        {
            _seciliPaketId = 0;
            txtPaketAdi.Clear();
            nudSureGun.Value = 30;
            nudFiyat.Value = 0;
            txtAciklama.Clear();
            chkAktif.Checked = true;
        }
    }
}