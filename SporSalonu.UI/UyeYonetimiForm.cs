using System;
using System.Windows.Forms;
using SporSalonu.BLL;
using SporSalonu.Entities;

namespace SporSalonu.UI
{
    public partial class UyeYonetimiForm : Form
    {
        private readonly UyeBll _uyeBll = new UyeBll();
        private int _seciliUyeId = 0;

        public UyeYonetimiForm()
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
            txtAra.TextChanged += (s, e) => ListeyiYukle(txtAra.Text.Trim());
            dgvUyeler.CellClick += DgvUyeler_CellClick;
        }

        private void ListeyiYukle(string arama = "")
        {
            dgvUyeler.DataSource = _uyeBll.Listele(arama);
            if (dgvUyeler.Columns["UyeId"] != null)
                dgvUyeler.Columns["UyeId"].Visible = false;
        }

        private Uye FormdanUyeOlustur()
        {
            return new Uye
            {
                UyeId = _seciliUyeId,
                AdSoyad = txtAdSoyad.Text.Trim(),
                TcNo = txtTcNo.Text.Trim(),
                Telefon = txtTelefon.Text.Trim(),
                Eposta = txtEposta.Text.Trim(),
                DogumTarihi = dtpDogumTarihi.Value.Date,
                Cinsiyet = cmbCinsiyet.SelectedItem?.ToString() ?? "",
                AktifMi = chkAktif.Checked
            };
        }

        private void Ekle()
        {
            try
            {
                string hata = _uyeBll.Ekle(FormdanUyeOlustur());
                if (hata != null)
                {
                    MessageBox.Show(hata, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                MessageBox.Show("Üye başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string hata = _uyeBll.Guncelle(FormdanUyeOlustur());
                if (hata != null)
                {
                    MessageBox.Show(hata, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                MessageBox.Show("Üye bilgileri güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (_seciliUyeId <= 0)
            {
                MessageBox.Show("Silmek için tablodan bir üye seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Seçili üyeyi silmek istediğinize emin misiniz?", "Onay",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                _uyeBll.Sil(_seciliUyeId);
                MessageBox.Show("Üye silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
                ListeyiYukle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvUyeler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var uye = dgvUyeler.Rows[e.RowIndex].DataBoundItem as Uye;
            if (uye == null) return;

            _seciliUyeId = uye.UyeId;
            txtAdSoyad.Text = uye.AdSoyad;
            txtTcNo.Text = uye.TcNo;
            txtTelefon.Text = uye.Telefon;
            txtEposta.Text = uye.Eposta;
            dtpDogumTarihi.Value = uye.DogumTarihi;
            cmbCinsiyet.SelectedItem = uye.Cinsiyet;
            chkAktif.Checked = uye.AktifMi;
        }

        private void Temizle()
        {
            _seciliUyeId = 0;
            txtAdSoyad.Clear();
            txtTcNo.Clear();
            txtTelefon.Clear();
            txtEposta.Clear();
            dtpDogumTarihi.Value = DateTime.Today;
            cmbCinsiyet.SelectedIndex = -1;
            chkAktif.Checked = true;
        }
    }
}