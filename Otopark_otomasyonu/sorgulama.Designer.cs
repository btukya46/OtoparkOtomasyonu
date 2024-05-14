
namespace Otopark_otomasyonu
{
    partial class sorgulama
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
            this.plakaTxtBox = new System.Windows.Forms.TextBox();
            this.sorgulaBTN = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.geriBTN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(44, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "Plaka:";
            // 
            // plakaTxtBox
            // 
            this.plakaTxtBox.Location = new System.Drawing.Point(130, 36);
            this.plakaTxtBox.Multiline = true;
            this.plakaTxtBox.Name = "plakaTxtBox";
            this.plakaTxtBox.Size = new System.Drawing.Size(278, 42);
            this.plakaTxtBox.TabIndex = 7;
            // 
            // sorgulaBTN
            // 
            this.sorgulaBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sorgulaBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sorgulaBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sorgulaBTN.ForeColor = System.Drawing.Color.White;
            this.sorgulaBTN.Location = new System.Drawing.Point(64, 111);
            this.sorgulaBTN.Name = "sorgulaBTN";
            this.sorgulaBTN.Size = new System.Drawing.Size(251, 49);
            this.sorgulaBTN.TabIndex = 10;
            this.sorgulaBTN.Text = "Sorgula";
            this.sorgulaBTN.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(19, 201);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(360, 192);
            this.dataGridView1.TabIndex = 11;
            // 
            // geriBTN
            // 
            this.geriBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.geriBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.geriBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.geriBTN.ForeColor = System.Drawing.Color.White;
            this.geriBTN.Location = new System.Drawing.Point(19, 418);
            this.geriBTN.Name = "geriBTN";
            this.geriBTN.Size = new System.Drawing.Size(147, 52);
            this.geriBTN.TabIndex = 15;
            this.geriBTN.Text = "←";
            this.geriBTN.UseVisualStyleBackColor = false;
            this.geriBTN.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(227, 438);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Designed By MOzbek - BKaya";
            // 
            // sorgulama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 493);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.geriBTN);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.sorgulaBTN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.plakaTxtBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "sorgulama";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Araç Sorgulama";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox plakaTxtBox;
        private System.Windows.Forms.Button sorgulaBTN;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button geriBTN;
        private System.Windows.Forms.Label label2;
    }
}