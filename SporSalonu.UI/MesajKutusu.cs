using System.Windows.Forms;

namespace SporSalonu.UI
{
    /// <summary>
    /// Ortak mesaj kutusu yardımcısı: tüm ekranlarda aynı başlık ve simgeler kullanılır.
    /// Kullanım:  MesajKutusu.Uyari("Ad alanı boş olamaz.");
    ///            if (MesajKutusu.Soru("Üye pasife alınsın mı?")) { ... }
    /// </summary>
    internal static class MesajKutusu
    {
        private const string Baslik = "Spor Salonu Otomasyonu";

        public static void Bilgi(string mesaj)
        {
            MessageBox.Show(mesaj, Baslik, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Uyari(string mesaj)
        {
            MessageBox.Show(mesaj, Baslik, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void Hata(string mesaj)
        {
            MessageBox.Show(mesaj, Baslik, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool Soru(string mesaj)
        {
            return MessageBox.Show(mesaj, Baslik, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                   == DialogResult.Yes;
        }
    }
}
