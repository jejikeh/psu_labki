namespace Flow
{
    partial class Flow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.gameCanvas = new System.Windows.Forms.PictureBox();
            this.txtScore = new System.Windows.Forms.Label();
            this.spawnBios = new System.Windows.Forms.Timer(this.components);
            this.garbageColliders = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gameCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 40;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // gameCanvas
            // 
            this.gameCanvas.Location = new System.Drawing.Point(9, 9);
            this.gameCanvas.Margin = new System.Windows.Forms.Padding(0);
            this.gameCanvas.Name = "gameCanvas";
            this.gameCanvas.Size = new System.Drawing.Size(988, 575);
            this.gameCanvas.TabIndex = 0;
            this.gameCanvas.TabStop = false;
            this.gameCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.UpdateCanvas);
            // 
            // txtScore
            // 
            this.txtScore.AutoSize = true;
            this.txtScore.Location = new System.Drawing.Point(9, 9);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(65, 20);
            this.txtScore.TabIndex = 1;
            this.txtScore.Text = "Score : 0";
            // 
            // spawnBios
            // 
            this.spawnBios.Enabled = true;
            this.spawnBios.Tick += new System.EventHandler(this.spawnBios_Tick);
            // 
            // garbageColliders
            // 
            this.garbageColliders.Enabled = true;
            this.garbageColliders.Interval = 1000;
            this.garbageColliders.Tick += new System.EventHandler(this.garbageColliders_Tick);
            // 
            // Flow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 593);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.gameCanvas);
            this.Name = "Flow";
            this.Text = "Flow";
            this.Load += new System.EventHandler(this.Flow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.gameCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private PictureBox gameCanvas;
        private Label txtScore;
        private System.Windows.Forms.Timer spawnBios;
        private System.Windows.Forms.Timer garbageColliders;
    }
}