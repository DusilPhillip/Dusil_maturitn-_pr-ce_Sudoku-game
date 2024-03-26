namespace ROP_menu
{
    partial class option_page
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
            this.Option_menu = new System.Windows.Forms.Panel();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.exit_button2 = new System.Windows.Forms.PictureBox();
            this.Sound_on = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.Option_menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exit_button2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sound_on)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // Option_menu
            // 
            this.Option_menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Option_menu.BackgroundImage = global::ROP_menu.Properties.Resources.option_menu;
            this.Option_menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Option_menu.Controls.Add(this.radioButton3);
            this.Option_menu.Controls.Add(this.radioButton2);
            this.Option_menu.Controls.Add(this.radioButton1);
            this.Option_menu.Controls.Add(this.label1);
            this.Option_menu.Controls.Add(this.exit_button2);
            this.Option_menu.Controls.Add(this.Sound_on);
            this.Option_menu.Controls.Add(this.trackBar1);
            this.Option_menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Option_menu.Location = new System.Drawing.Point(115, 52);
            this.Option_menu.Name = "Option_menu";
            this.Option_menu.Size = new System.Drawing.Size(268, 384);
            this.Option_menu.TabIndex = 0;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButton3.Location = new System.Drawing.Point(113, 292);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(52, 17);
            this.radioButton3.TabIndex = 6;
            this.radioButton3.Text = "Hard";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButton2.Location = new System.Drawing.Point(113, 269);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(64, 17);
            this.radioButton2.TabIndex = 5;
            this.radioButton2.Text = "Normal";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButton1.Location = new System.Drawing.Point(113, 246);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(52, 17);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Easy";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(52, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "choose your level of difficulty:";
            // 
            // exit_button2
            // 
            this.exit_button2.Cursor = System.Windows.Forms.Cursors.Default;
            this.exit_button2.Image = global::ROP_menu.Properties.Resources.exit_normal;
            this.exit_button2.Location = new System.Drawing.Point(87, 324);
            this.exit_button2.Name = "exit_button2";
            this.exit_button2.Size = new System.Drawing.Size(100, 43);
            this.exit_button2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.exit_button2.TabIndex = 2;
            this.exit_button2.TabStop = false;
            this.exit_button2.Click += new System.EventHandler(this.exit_button2_Click);
            this.exit_button2.MouseLeave += new System.EventHandler(this.exit_button2_MouseLeave);
            this.exit_button2.MouseHover += new System.EventHandler(this.exit_button2_MouseHover);
            // 
            // Sound_on
            // 
            this.Sound_on.Image = global::ROP_menu.Properties.Resources.sound_on;
            this.Sound_on.Location = new System.Drawing.Point(113, 169);
            this.Sound_on.Name = "Sound_on";
            this.Sound_on.Size = new System.Drawing.Size(50, 50);
            this.Sound_on.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Sound_on.TabIndex = 1;
            this.Sound_on.TabStop = false;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(55, 132);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(175, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.Value = 50;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // option_page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ROP_menu.Properties.Resources.background4;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(484, 511);
            this.ControlBox = false;
            this.Controls.Add(this.Option_menu);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "option_page";
            this.Text = "option_page";
            this.Option_menu.ResumeLayout(false);
            this.Option_menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exit_button2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sound_on)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Option_menu;
        private System.Windows.Forms.PictureBox Sound_on;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.PictureBox exit_button2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.RadioButton radioButton1;
        public System.Windows.Forms.RadioButton radioButton3;
        public System.Windows.Forms.RadioButton radioButton2;
    }
}