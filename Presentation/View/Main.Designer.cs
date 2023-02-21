namespace Presentation
{
    partial class Main
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
            this.WindowHeaderTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonMinimize = new System.Windows.Forms.Button();
            this.ButtonMaximize = new System.Windows.Forms.Button();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SideMenuTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonHomePage = new System.Windows.Forms.Button();
            this.ButtonSimulation = new System.Windows.Forms.Button();
            this.ButtonCalibration = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.ButtonMode = new System.Windows.Forms.Button();
            this.PanelContent = new System.Windows.Forms.Panel();
            this.WindowHeaderTableLayoutPanel.SuspendLayout();
            this.SideMenuTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // WindowHeaderTableLayoutPanel
            // 
            this.WindowHeaderTableLayoutPanel.BackColor = System.Drawing.Color.White;
            this.WindowHeaderTableLayoutPanel.ColumnCount = 4;
            this.WindowHeaderTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.WindowHeaderTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.WindowHeaderTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.WindowHeaderTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.WindowHeaderTableLayoutPanel.Controls.Add(this.ButtonMinimize, 1, 0);
            this.WindowHeaderTableLayoutPanel.Controls.Add(this.ButtonMaximize, 2, 0);
            this.WindowHeaderTableLayoutPanel.Controls.Add(this.ButtonClose, 3, 0);
            this.WindowHeaderTableLayoutPanel.Controls.Add(this.label1, 0, 0);
            this.WindowHeaderTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.WindowHeaderTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.WindowHeaderTableLayoutPanel.Name = "WindowHeaderTableLayoutPanel";
            this.WindowHeaderTableLayoutPanel.RowCount = 1;
            this.WindowHeaderTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.WindowHeaderTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.WindowHeaderTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.WindowHeaderTableLayoutPanel.Size = new System.Drawing.Size(1280, 32);
            this.WindowHeaderTableLayoutPanel.TabIndex = 0;
            this.WindowHeaderTableLayoutPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WindowHeaderTableLayoutPanel_MouseDown);
            // 
            // ButtonMinimize
            // 
            this.ButtonMinimize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonMinimize.FlatAppearance.BorderSize = 0;
            this.ButtonMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ScrollBar;
            this.ButtonMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonMinimize.Image = global::Presentation.Properties.Resources.minimize_button_24px;
            this.ButtonMinimize.Location = new System.Drawing.Point(1184, 0);
            this.ButtonMinimize.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonMinimize.Name = "ButtonMinimize";
            this.ButtonMinimize.Size = new System.Drawing.Size(32, 32);
            this.ButtonMinimize.TabIndex = 3;
            this.ButtonMinimize.UseVisualStyleBackColor = true;
            this.ButtonMinimize.Click += new System.EventHandler(this.ButtonMinimize_Click);
            // 
            // ButtonMaximize
            // 
            this.ButtonMaximize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonMaximize.FlatAppearance.BorderSize = 0;
            this.ButtonMaximize.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ScrollBar;
            this.ButtonMaximize.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonMaximize.Image = global::Presentation.Properties.Resources.maximize_button_24px;
            this.ButtonMaximize.Location = new System.Drawing.Point(1216, 0);
            this.ButtonMaximize.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonMaximize.Name = "ButtonMaximize";
            this.ButtonMaximize.Size = new System.Drawing.Size(32, 32);
            this.ButtonMaximize.TabIndex = 2;
            this.ButtonMaximize.UseVisualStyleBackColor = true;
            this.ButtonMaximize.Click += new System.EventHandler(this.ButtonMaximize_Click);
            // 
            // ButtonClose
            // 
            this.ButtonClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonClose.FlatAppearance.BorderSize = 0;
            this.ButtonClose.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ScrollBar;
            this.ButtonClose.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonClose.Image = global::Presentation.Properties.Resources.close_button_24px;
            this.ButtonClose.Location = new System.Drawing.Point(1248, 0);
            this.ButtonClose.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(32, 32);
            this.ButtonClose.TabIndex = 1;
            this.ButtonClose.UseVisualStyleBackColor = true;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gilroy ExtraBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(200)))));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "İBKS - İSKİ BAKANLIK KABİNİ SİSTEMİ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SideMenuTableLayoutPanel
            // 
            this.SideMenuTableLayoutPanel.BackColor = System.Drawing.Color.White;
            this.SideMenuTableLayoutPanel.ColumnCount = 1;
            this.SideMenuTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SideMenuTableLayoutPanel.Controls.Add(this.ButtonHomePage, 0, 0);
            this.SideMenuTableLayoutPanel.Controls.Add(this.ButtonSimulation, 0, 1);
            this.SideMenuTableLayoutPanel.Controls.Add(this.ButtonCalibration, 0, 2);
            this.SideMenuTableLayoutPanel.Controls.Add(this.button3, 0, 3);
            this.SideMenuTableLayoutPanel.Controls.Add(this.button4, 0, 4);
            this.SideMenuTableLayoutPanel.Controls.Add(this.button5, 0, 5);
            this.SideMenuTableLayoutPanel.Controls.Add(this.ButtonMode, 0, 7);
            this.SideMenuTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.SideMenuTableLayoutPanel.ForeColor = System.Drawing.Color.DimGray;
            this.SideMenuTableLayoutPanel.Location = new System.Drawing.Point(0, 32);
            this.SideMenuTableLayoutPanel.MaximumSize = new System.Drawing.Size(90, 0);
            this.SideMenuTableLayoutPanel.MinimumSize = new System.Drawing.Size(90, 0);
            this.SideMenuTableLayoutPanel.Name = "SideMenuTableLayoutPanel";
            this.SideMenuTableLayoutPanel.RowCount = 8;
            this.SideMenuTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.SideMenuTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.SideMenuTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.SideMenuTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.SideMenuTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.SideMenuTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.SideMenuTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SideMenuTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.SideMenuTableLayoutPanel.Size = new System.Drawing.Size(90, 688);
            this.SideMenuTableLayoutPanel.TabIndex = 1;
            // 
            // ButtonHomePage
            // 
            this.ButtonHomePage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ButtonHomePage.FlatAppearance.BorderSize = 0;
            this.ButtonHomePage.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ScrollBar;
            this.ButtonHomePage.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonHomePage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonHomePage.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ButtonHomePage.ForeColor = System.Drawing.Color.DimGray;
            this.ButtonHomePage.Image = global::Presentation.Properties.Resources.filled_home_24px;
            this.ButtonHomePage.Location = new System.Drawing.Point(7, 3);
            this.ButtonHomePage.Name = "ButtonHomePage";
            this.ButtonHomePage.Size = new System.Drawing.Size(75, 65);
            this.ButtonHomePage.TabIndex = 2;
            this.ButtonHomePage.Text = "Anasayfa";
            this.ButtonHomePage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ButtonHomePage.UseVisualStyleBackColor = true;
            this.ButtonHomePage.Click += new System.EventHandler(this.ButtonHomePage_Click);
            // 
            // ButtonSimulation
            // 
            this.ButtonSimulation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ButtonSimulation.FlatAppearance.BorderSize = 0;
            this.ButtonSimulation.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ScrollBar;
            this.ButtonSimulation.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonSimulation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonSimulation.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ButtonSimulation.ForeColor = System.Drawing.Color.DimGray;
            this.ButtonSimulation.Image = global::Presentation.Properties.Resources.monitor_24px;
            this.ButtonSimulation.Location = new System.Drawing.Point(7, 74);
            this.ButtonSimulation.Name = "ButtonSimulation";
            this.ButtonSimulation.Size = new System.Drawing.Size(75, 65);
            this.ButtonSimulation.TabIndex = 2;
            this.ButtonSimulation.Text = "Simülasyon";
            this.ButtonSimulation.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ButtonSimulation.UseVisualStyleBackColor = true;
            // 
            // ButtonCalibration
            // 
            this.ButtonCalibration.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ButtonCalibration.FlatAppearance.BorderSize = 0;
            this.ButtonCalibration.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ScrollBar;
            this.ButtonCalibration.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonCalibration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonCalibration.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ButtonCalibration.ForeColor = System.Drawing.Color.DimGray;
            this.ButtonCalibration.Image = global::Presentation.Properties.Resources.azimuth_24px;
            this.ButtonCalibration.Location = new System.Drawing.Point(7, 145);
            this.ButtonCalibration.Name = "ButtonCalibration";
            this.ButtonCalibration.Size = new System.Drawing.Size(75, 65);
            this.ButtonCalibration.TabIndex = 2;
            this.ButtonCalibration.Text = "Kalibrasyon";
            this.ButtonCalibration.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ButtonCalibration.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ScrollBar;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.ForeColor = System.Drawing.Color.DimGray;
            this.button3.Image = global::Presentation.Properties.Resources.alarm_24px;
            this.button3.Location = new System.Drawing.Point(7, 216);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 65);
            this.button3.TabIndex = 2;
            this.button3.Text = "Mail";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ScrollBar;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button4.ForeColor = System.Drawing.Color.DimGray;
            this.button4.Image = global::Presentation.Properties.Resources.save_24px;
            this.button4.Location = new System.Drawing.Point(7, 287);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 65);
            this.button4.TabIndex = 2;
            this.button4.Text = "Raporlama";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ScrollBar;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button5.ForeColor = System.Drawing.Color.DimGray;
            this.button5.Image = global::Presentation.Properties.Resources.settings_24px;
            this.button5.Location = new System.Drawing.Point(7, 358);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 65);
            this.button5.TabIndex = 2;
            this.button5.Text = "Ayarlar";
            this.button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // ButtonMode
            // 
            this.ButtonMode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ButtonMode.FlatAppearance.BorderSize = 0;
            this.ButtonMode.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ScrollBar;
            this.ButtonMode.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonMode.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ButtonMode.ForeColor = System.Drawing.Color.DimGray;
            this.ButtonMode.Image = global::Presentation.Properties.Resources.black_and_white_24px;
            this.ButtonMode.Location = new System.Drawing.Point(7, 616);
            this.ButtonMode.Name = "ButtonMode";
            this.ButtonMode.Size = new System.Drawing.Size(75, 65);
            this.ButtonMode.TabIndex = 2;
            this.ButtonMode.Text = "Gece Modu";
            this.ButtonMode.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ButtonMode.UseVisualStyleBackColor = true;
            this.ButtonMode.Click += new System.EventHandler(this.ButtonMode_Click);
            // 
            // PanelContent
            // 
            this.PanelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContent.Location = new System.Drawing.Point(90, 32);
            this.PanelContent.Name = "PanelContent";
            this.PanelContent.Size = new System.Drawing.Size(1190, 688);
            this.PanelContent.TabIndex = 2;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.ControlBox = false;
            this.Controls.Add(this.PanelContent);
            this.Controls.Add(this.SideMenuTableLayoutPanel);
            this.Controls.Add(this.WindowHeaderTableLayoutPanel);
            this.MinimumSize = new System.Drawing.Size(1296, 736);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Main_Load);
            this.WindowHeaderTableLayoutPanel.ResumeLayout(false);
            this.WindowHeaderTableLayoutPanel.PerformLayout();
            this.SideMenuTableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel WindowHeaderTableLayoutPanel;
        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.Button ButtonMinimize;
        private System.Windows.Forms.Button ButtonMaximize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel SideMenuTableLayoutPanel;
        private System.Windows.Forms.Button ButtonHomePage;
        private System.Windows.Forms.Button ButtonSimulation;
        private System.Windows.Forms.Button ButtonCalibration;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel PanelContent;
        internal System.Windows.Forms.Button ButtonMode;
    }
}

