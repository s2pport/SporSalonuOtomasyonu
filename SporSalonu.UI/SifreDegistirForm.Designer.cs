namespace SporSalonu.UI
{
    partial class SifreDegistirForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEskiParola = new System.Windows.Forms.TextBox();
            this.txtYeniParola = new System.Windows.Forms.TextBox();
            this.txtYeniParolaTekrar = new System.Windows.Forms.TextBox();
            this.lblGucMesaji = new System.Windows.Forms.Label();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnVazgec = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mevcut Parola";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(53, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Yeni Parola";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Yeni Parola Tekrar";
         
            // 
            // txtEskiParola
            // 
            this.txtEskiParola.Location = new System.Drawing.Point(202, 81);
            this.txtEskiParola.Name = "txtEskiParola";
            this.txtEskiParola.Size = new System.Drawing.Size(176, 20);
            this.txtEskiParola.TabIndex = 4;
            this.txtEskiParola.UseSystemPasswordChar = true;
            // 
            // txtYeniParola
            // 
            this.txtYeniParola.Location = new System.Drawing.Point(202, 156);
            this.txtYeniParola.Name = "txtYeniParola";
            this.txtYeniParola.Size = new System.Drawing.Size(176, 20);
            this.txtYeniParola.TabIndex = 5;
            this.txtYeniParola.UseSystemPasswordChar = true;
            // 
            // txtYeniParolaTekrar
            // 
            this.txtYeniParolaTekrar.Location = new System.Drawing.Point(210, 224);
            this.txtYeniParolaTekrar.Name = "txtYeniParolaTekrar";
            this.txtYeniParolaTekrar.Size = new System.Drawing.Size(168, 20);
            this.txtYeniParolaTekrar.TabIndex = 6;
            this.txtYeniParolaTekrar.UseSystemPasswordChar = true;
          
            // 
            // lblGucMesaji
            // 
            this.lblGucMesaji.Location = new System.Drawing.Point(94, 272);
            this.lblGucMesaji.Name = "lblGucMesaji";
            this.lblGucMesaji.Size = new System.Drawing.Size(461, 87);
            this.lblGucMesaji.TabIndex = 7;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKaydet.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnKaydet.Location = new System.Drawing.Point(502, 362);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(104, 45);
            this.btnKaydet.TabIndex = 8;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            // 
            // btnVazgec
            // 
            this.btnVazgec.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVazgec.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnVazgec.Location = new System.Drawing.Point(645, 362);
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.Size = new System.Drawing.Size(104, 45);
            this.btnVazgec.TabIndex = 9;
            this.btnVazgec.Text = "Vazgeç";
            this.btnVazgec.UseVisualStyleBackColor = true;
            // 
            // SifreDegistirForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVazgec);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.lblGucMesaji);
            this.Controls.Add(this.txtYeniParolaTekrar);
            this.Controls.Add(this.txtYeniParola);
            this.Controls.Add(this.txtEskiParola);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SifreDegistirForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sifre Degistir";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEskiParola;
        private System.Windows.Forms.TextBox txtYeniParola;
        private System.Windows.Forms.TextBox txtYeniParolaTekrar;
        private System.Windows.Forms.Label lblGucMesaji;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnVazgec;
    }
}