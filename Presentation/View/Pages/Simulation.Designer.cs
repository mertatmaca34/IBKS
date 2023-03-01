namespace Presentation.View.Pages
{
    partial class Simulation
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.PanelBG = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 750;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PanelBG
            // 
            this.PanelBG.BackColor = System.Drawing.Color.Transparent;
            this.PanelBG.BackgroundImage = global::Presentation.Properties.Resources.IBKS_bg;
            this.PanelBG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelBG.Location = new System.Drawing.Point(0, 0);
            this.PanelBG.Name = "PanelBG";
            this.PanelBG.Size = new System.Drawing.Size(1190, 688);
            this.PanelBG.TabIndex = 0;
            this.PanelBG.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelBG_MouseClick);
            // 
            // Simulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1190, 688);
            this.Controls.Add(this.PanelBG);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Simulation";
            this.Text = "Simulation";
            this.Load += new System.EventHandler(this.Simulation_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel PanelBG;
    }
}