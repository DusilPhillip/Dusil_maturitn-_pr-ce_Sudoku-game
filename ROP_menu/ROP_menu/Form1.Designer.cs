namespace ROP_menu
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menu = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.HighScore_Button = new System.Windows.Forms.PictureBox();
            this.exit_button = new System.Windows.Forms.PictureBox();
            this.option_button = new System.Windows.Forms.PictureBox();
            this.start_button = new System.Windows.Forms.PictureBox();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HighScore_Button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exit_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.option_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.start_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.menu.BackgroundImage = global::ROP_menu.Properties.Resources.menu;
            this.menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menu.Controls.Add(this.textBox1);
            this.menu.Controls.Add(this.label1);
            this.menu.Controls.Add(this.HighScore_Button);
            this.menu.Controls.Add(this.exit_button);
            this.menu.Controls.Add(this.option_button);
            this.menu.Controls.Add(this.start_button);
            this.menu.Location = new System.Drawing.Point(88, 77);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(311, 351);
            this.menu.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(105, 80);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "petr";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(131, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name:";
            // 
            // HighScore_Button
            // 
            this.HighScore_Button.Image = global::ROP_menu.Properties.Resources.score;
            this.HighScore_Button.Location = new System.Drawing.Point(105, 275);
            this.HighScore_Button.Name = "HighScore_Button";
            this.HighScore_Button.Size = new System.Drawing.Size(100, 43);
            this.HighScore_Button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HighScore_Button.TabIndex = 4;
            this.HighScore_Button.TabStop = false;
            this.HighScore_Button.Click += new System.EventHandler(this.HighScore_Button_Click);
            this.HighScore_Button.MouseHover += new System.EventHandler(this.HighScore_Button_MouseHover);
            // 
            // exit_button
            // 
            this.exit_button.Image = global::ROP_menu.Properties.Resources.exit_normal;
            this.exit_button.Location = new System.Drawing.Point(105, 226);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(100, 43);
            this.exit_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.exit_button.TabIndex = 3;
            this.exit_button.TabStop = false;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            this.exit_button.MouseLeave += new System.EventHandler(this.exit_button_MouseLeave);
            this.exit_button.MouseHover += new System.EventHandler(this.exit_button_MouseHover);
            // 
            // option_button
            // 
            this.option_button.Image = global::ROP_menu.Properties.Resources.option_normal;
            this.option_button.Location = new System.Drawing.Point(105, 177);
            this.option_button.Name = "option_button";
            this.option_button.Size = new System.Drawing.Size(100, 43);
            this.option_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.option_button.TabIndex = 1;
            this.option_button.TabStop = false;
            this.option_button.Click += new System.EventHandler(this.option_button_Click);
            this.option_button.MouseLeave += new System.EventHandler(this.option_button_MouseLeave);
            this.option_button.MouseHover += new System.EventHandler(this.option_button_MouseHover);
            // 
            // start_button
            // 
            this.start_button.Image = global::ROP_menu.Properties.Resources.start_normal;
            this.start_button.Location = new System.Drawing.Point(105, 128);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(100, 43);
            this.start_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.start_button.TabIndex = 0;
            this.start_button.TabStop = false;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            this.start_button.MouseLeave += new System.EventHandler(this.start_button_MouseLeave);
            this.start_button.MouseHover += new System.EventHandler(this.start_button_MouseHover);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(32, 32);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(75, 23);
            this.axWindowsMediaPlayer1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ROP_menu.Properties.Resources.background3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(484, 511);
            this.ControlBox = false;
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Form1";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HighScore_Button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exit_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.option_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.start_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel menu;
        private System.Windows.Forms.PictureBox exit_button;
        private System.Windows.Forms.PictureBox option_button;
        private System.Windows.Forms.PictureBox start_button;
        private System.Windows.Forms.PictureBox HighScore_Button;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}

