namespace SporSalonu.UI
{
    partial class AnaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuUyeler = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPaketler = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUyelik = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOdeme = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDondurma = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGirisCikis = new System.Windows.Forms.ToolStripMenuItem();
            this.hesapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSifreDegistir = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuYenile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOturumKapat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCikis = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.tslKullanici = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslRol = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslBoşluk = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslSaat = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrSaat = new System.Windows.Forms.Timer(this.components);
            this.tblOzet = new System.Windows.Forms.TableLayoutPanel();
            this.lblGunlukOdeme = new System.Windows.Forms.Label();
            this.lblSuresiDolmus = new System.Windows.Forms.Label();
            this.lblToplamUye = new System.Windows.Forms.Label();
            this.lblAktifUyelik = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.tblOzet.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUyeler,
            this.mnuPaketler,
            this.mnuUyelik,
            this.mnuOdeme,
            this.mnuDondurma,
            this.mnuGirisCikis,
            this.hesapToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuUyeler
            // 
            this.mnuUyeler.Name = "mnuUyeler";
            this.mnuUyeler.Size = new System.Drawing.Size(89, 20);
            this.mnuUyeler.Text = "Üye Yönetimi";
            // 
            // mnuPaketler
            // 
            this.mnuPaketler.Name = "mnuPaketler";
            this.mnuPaketler.Size = new System.Drawing.Size(98, 20);
            this.mnuPaketler.Text = "Paket Yönetimi";
            // 
            // mnuUyelik
            // 
            this.mnuUyelik.Name = "mnuUyelik";
            this.mnuUyelik.Size = new System.Drawing.Size(54, 20);
            this.mnuUyelik.Text = "Üyelik ";
            // 
            // mnuOdeme
            // 
            this.mnuOdeme.Name = "mnuOdeme";
            this.mnuOdeme.Size = new System.Drawing.Size(58, 20);
            this.mnuOdeme.Text = "Ödeme";
            // 
            // mnuDondurma
            // 
            this.mnuDondurma.Name = "mnuDondurma";
            this.mnuDondurma.Size = new System.Drawing.Size(76, 20);
            this.mnuDondurma.Text = "Dondurma";
            // 
            // mnuGirisCikis
            // 
            this.mnuGirisCikis.Name = "mnuGirisCikis";
            this.mnuGirisCikis.Size = new System.Drawing.Size(72, 20);
            this.mnuGirisCikis.Text = "Giriş-Çıkış";
            // 
            // hesapToolStripMenuItem
            // 
            this.hesapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSifreDegistir,
            this.mnuYenile,
            this.mnuOturumKapat,
            this.mnuCikis});
            this.hesapToolStripMenuItem.Name = "hesapToolStripMenuItem";
            this.hesapToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.hesapToolStripMenuItem.Text = "Hesap";
            // 
            // mnuSifreDegistir
            // 
            this.mnuSifreDegistir.Name = "mnuSifreDegistir";
            this.mnuSifreDegistir.Size = new System.Drawing.Size(180, 22);
            this.mnuSifreDegistir.Text = "Şifre Değiştir";
            // 
            // mnuYenile
            // 
            this.mnuYenile.Name = "mnuYenile";
            this.mnuYenile.Size = new System.Drawing.Size(180, 22);
            this.mnuYenile.Text = "Paneli Yenile";
            // 
            // mnuOturumKapat
            // 
            this.mnuOturumKapat.Name = "mnuOturumKapat";
            this.mnuOturumKapat.Size = new System.Drawing.Size(180, 22);
            this.mnuOturumKapat.Text = "Oturumu Kapat";
            // 
            // mnuCikis
            // 
            this.mnuCikis.Name = "mnuCikis";
            this.mnuCikis.Size = new System.Drawing.Size(180, 22);
            this.mnuCikis.Text = "Çıkış";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslKullanici,
            this.tslRol,
            this.tslBoşluk,
            this.tslSaat});
            this.statusStrip2.Location = new System.Drawing.Point(0, 406);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(800, 22);
            this.statusStrip2.TabIndex = 3;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // tslKullanici
            // 
            this.tslKullanici.Name = "tslKullanici";
            this.tslKullanici.Size = new System.Drawing.Size(64, 17);
            this.tslKullanici.Text = "tslKullanici";
            // 
            // tslRol
            // 
            this.tslRol.Name = "tslRol";
            this.tslRol.Size = new System.Drawing.Size(36, 17);
            this.tslRol.Text = "tslRol";
            // 
            // tslBoşluk
            // 
            this.tslBoşluk.Name = "tslBoşluk";
            this.tslBoşluk.Size = new System.Drawing.Size(0, 17);
            // 
            // tslSaat
            // 
            this.tslSaat.Name = "tslSaat";
            this.tslSaat.Size = new System.Drawing.Size(41, 17);
            this.tslSaat.Text = "tslSaat";
            // 
            // tmrSaat
            // 
            this.tmrSaat.Interval = 1000;
            // 
            // tblOzet
            // 
            this.tblOzet.ColumnCount = 4;
            this.tblOzet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblOzet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblOzet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblOzet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblOzet.Controls.Add(this.lblGunlukOdeme, 3, 0);
            this.tblOzet.Controls.Add(this.lblSuresiDolmus, 2, 0);
            this.tblOzet.Controls.Add(this.lblToplamUye, 0, 0);
            this.tblOzet.Controls.Add(this.lblAktifUyelik, 1, 0);
            this.tblOzet.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblOzet.Location = new System.Drawing.Point(0, 24);
            this.tblOzet.Name = "tblOzet";
            this.tblOzet.RowCount = 1;
            this.tblOzet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblOzet.Size = new System.Drawing.Size(800, 90);
            this.tblOzet.TabIndex = 4;
            // 
            // lblGunlukOdeme
            // 
            this.lblGunlukOdeme.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGunlukOdeme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGunlukOdeme.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGunlukOdeme.Location = new System.Drawing.Point(603, 0);
            this.lblGunlukOdeme.Name = "lblGunlukOdeme";
            this.lblGunlukOdeme.Size = new System.Drawing.Size(194, 90);
            this.lblGunlukOdeme.TabIndex = 3;
            this.lblGunlukOdeme.Text = "Gunluk Ödeme";
            this.lblGunlukOdeme.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSuresiDolmus
            // 
            this.lblSuresiDolmus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSuresiDolmus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSuresiDolmus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuresiDolmus.Location = new System.Drawing.Point(403, 0);
            this.lblSuresiDolmus.Name = "lblSuresiDolmus";
            this.lblSuresiDolmus.Size = new System.Drawing.Size(194, 90);
            this.lblSuresiDolmus.TabIndex = 2;
            this.lblSuresiDolmus.Text = "Süresi Dolmuş";
            this.lblSuresiDolmus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblToplamUye
            // 
            this.lblToplamUye.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblToplamUye.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToplamUye.Location = new System.Drawing.Point(3, 0);
            this.lblToplamUye.Name = "lblToplamUye";
            this.lblToplamUye.Size = new System.Drawing.Size(194, 90);
            this.lblToplamUye.TabIndex = 0;
            this.lblToplamUye.Text = "Aktif Üyelik";
            this.lblToplamUye.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAktifUyelik
            // 
            this.lblAktifUyelik.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAktifUyelik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAktifUyelik.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAktifUyelik.Location = new System.Drawing.Point(203, 0);
            this.lblAktifUyelik.Name = "lblAktifUyelik";
            this.lblAktifUyelik.Size = new System.Drawing.Size(194, 90);
            this.lblAktifUyelik.TabIndex = 1;
            this.lblAktifUyelik.Text = "Aktif Üyelik";
            this.lblAktifUyelik.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tblOzet);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AnaForm";
            this.Text = "Spor Salonu Yönetim Sistemi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.tblOzet.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuUyeler;
        private System.Windows.Forms.ToolStripMenuItem mnuPaketler;
        private System.Windows.Forms.ToolStripMenuItem mnuUyelik;
        private System.Windows.Forms.ToolStripMenuItem mnuOdeme;
        private System.Windows.Forms.ToolStripMenuItem mnuDondurma;
        private System.Windows.Forms.ToolStripMenuItem mnuGirisCikis;
        private System.Windows.Forms.ToolStripMenuItem hesapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSifreDegistir;
        private System.Windows.Forms.ToolStripMenuItem mnuYenile;
        private System.Windows.Forms.ToolStripMenuItem mnuOturumKapat;
        private System.Windows.Forms.ToolStripMenuItem mnuCikis;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel tslKullanici;
        private System.Windows.Forms.ToolStripStatusLabel tslRol;
        private System.Windows.Forms.ToolStripStatusLabel tslBoşluk;
        private System.Windows.Forms.ToolStripStatusLabel tslSaat;
        private System.Windows.Forms.Timer tmrSaat;
        private System.Windows.Forms.TableLayoutPanel tblOzet;
        private System.Windows.Forms.Label lblToplamUye;
        private System.Windows.Forms.Label lblAktifUyelik;
        private System.Windows.Forms.Label lblGunlukOdeme;
        private System.Windows.Forms.Label lblSuresiDolmus;
    }
}