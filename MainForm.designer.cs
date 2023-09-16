namespace Plot3D
{
    partial class MainForm
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
            this.trackRho = new System.Windows.Forms.TrackBar();
            this.trackTheta = new System.Windows.Forms.TrackBar();
            this.trackPhi = new System.Windows.Forms.TrackBar();
            this.comboColors = new System.Windows.Forms.ComboBox();
            this.comboDataSrc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboRaster = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnScreenshot = new System.Windows.Forms.Button();
            this.graph3D = new Plot3D.Graph3D();
            this.btnReset = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackRho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackTheta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackPhi)).BeginInit();
            this.SuspendLayout();
            // 
            // trackRho
            // 
            this.trackRho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.trackRho.Location = new System.Drawing.Point(10, 243);
            this.trackRho.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.trackRho.Name = "trackRho";
            this.trackRho.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackRho.Size = new System.Drawing.Size(45, 309);
            this.trackRho.TabIndex = 10;
            this.trackRho.TickFrequency = 20;
            this.trackRho.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // trackTheta
            // 
            this.trackTheta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.trackTheta.Location = new System.Drawing.Point(62, 243);
            this.trackTheta.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.trackTheta.Name = "trackTheta";
            this.trackTheta.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackTheta.Size = new System.Drawing.Size(45, 309);
            this.trackTheta.TabIndex = 11;
            this.trackTheta.TickFrequency = 20;
            this.trackTheta.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // trackPhi
            // 
            this.trackPhi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.trackPhi.Location = new System.Drawing.Point(114, 243);
            this.trackPhi.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.trackPhi.Name = "trackPhi";
            this.trackPhi.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackPhi.Size = new System.Drawing.Size(45, 309);
            this.trackPhi.TabIndex = 12;
            this.trackPhi.TickFrequency = 20;
            this.trackPhi.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // comboColors
            // 
            this.comboColors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboColors.FormattingEnabled = true;
            this.comboColors.Location = new System.Drawing.Point(10, 31);
            this.comboColors.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboColors.MaxDropDownItems = 30;
            this.comboColors.Name = "comboColors";
            this.comboColors.Size = new System.Drawing.Size(140, 23);
            this.comboColors.TabIndex = 2;
            this.comboColors.SelectedIndexChanged += new System.EventHandler(this.comboColors_SelectedIndexChanged);
            // 
            // comboDataSrc
            // 
            this.comboDataSrc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataSrc.FormattingEnabled = true;
            this.comboDataSrc.Items.AddRange(new object[] {
            "0 - 1 кГц",
            "0 - 2 кГц",
            "0 - 5 кГц",
            "0 - 12.5 кГц",
            "1 - 12.5 кГц"});
            this.comboDataSrc.Location = new System.Drawing.Point(10, 119);
            this.comboDataSrc.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboDataSrc.MaxDropDownItems = 30;
            this.comboDataSrc.Name = "comboDataSrc";
            this.comboDataSrc.Size = new System.Drawing.Size(140, 23);
            this.comboDataSrc.TabIndex = 1;
            this.comboDataSrc.SelectedIndexChanged += new System.EventHandler(this.comboDataSrc_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(160, 557);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(535, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "Лкм: Поднять, Пкм: Повернуть, Лкм + SHIFT: Переместить, Лкм + CTRL или колесико: " +
    "Масштаб";
            // 
            // comboRaster
            // 
            this.comboRaster.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRaster.FormattingEnabled = true;
            this.comboRaster.Location = new System.Drawing.Point(9, 75);
            this.comboRaster.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboRaster.MaxDropDownItems = 30;
            this.comboRaster.Name = "comboRaster";
            this.comboRaster.Size = new System.Drawing.Size(140, 23);
            this.comboRaster.TabIndex = 3;
            this.comboRaster.SelectedIndexChanged += new System.EventHandler(this.comboRaster_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 13);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "Цветовая схема:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 57);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "Координатная система:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 557);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "Мас";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 557);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 15);
            this.label6.TabIndex = 19;
            this.label6.Text = "Выс";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(115, 557);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 15);
            this.label7.TabIndex = 20;
            this.label7.Text = "Пов";
            // 
            // btnScreenshot
            // 
            this.btnScreenshot.Location = new System.Drawing.Point(10, 208);
            this.btnScreenshot.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnScreenshot.Name = "btnScreenshot";
            this.btnScreenshot.Size = new System.Drawing.Size(141, 27);
            this.btnScreenshot.TabIndex = 5;
            this.btnScreenshot.Text = "Сохранить скриншот";
            this.btnScreenshot.UseVisualStyleBackColor = true;
            this.btnScreenshot.Click += new System.EventHandler(this.btnScreenshot_Click);
            // 
            // graph3D
            // 
            this.graph3D.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graph3D.AxisX_Color = System.Drawing.Color.DarkBlue;
            this.graph3D.AxisX_Legend = null;
            this.graph3D.AxisY_Color = System.Drawing.Color.DarkGreen;
            this.graph3D.AxisY_Legend = null;
            this.graph3D.AxisZ_Color = System.Drawing.Color.DarkRed;
            this.graph3D.AxisZ_Legend = null;
            this.graph3D.BackColor = System.Drawing.Color.White;
            this.graph3D.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.graph3D.Cursor = System.Windows.Forms.Cursors.Default;
            this.graph3D.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.graph3D.Location = new System.Drawing.Point(162, 13);
            this.graph3D.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.graph3D.Name = "graph3D";
            this.graph3D.PolygonLineColor = System.Drawing.Color.Black;
            this.graph3D.Raster = Plot3D.Graph3D.eRaster.Off;
            this.graph3D.Size = new System.Drawing.Size(765, 541);
            this.graph3D.TabIndex = 6;
            this.graph3D.TopLegendColor = System.Drawing.Color.WhiteSmoke;
            this.graph3D.Load += new System.EventHandler(this.graph3D_Load_1);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(10, 174);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(141, 27);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Сбросить положение";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 101);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 15);
            this.label2.TabIndex = 21;
            this.label2.Text = "Диапазон частот:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(9, 153);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(96, 15);
            this.lblInfo.TabIndex = 9;
            this.lblInfo.Text = "Главная частота";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(941, 579);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnScreenshot);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboRaster);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboDataSrc);
            this.Controls.Add(this.comboColors);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.graph3D);
            this.Controls.Add(this.trackPhi);
            this.Controls.Add(this.trackTheta);
            this.Controls.Add(this.trackRho);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(464, 456);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UwU";
            ((System.ComponentModel.ISupportInitialize)(this.trackRho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackTheta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackPhi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackRho;
        private System.Windows.Forms.TrackBar trackTheta;
        private System.Windows.Forms.TrackBar trackPhi;
        private Plot3D.Graph3D graph3D;
        private System.Windows.Forms.ComboBox comboColors;
        private System.Windows.Forms.ComboBox comboDataSrc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboRaster;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnScreenshot;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Timer timer1;
        private Label label2;
        private Label lblInfo;
    }
}
