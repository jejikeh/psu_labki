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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
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
            this.gameCanvas.Size = new System.Drawing.Size(ClientSize.Width, ClientSize.Height);
            this.gameCanvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(377, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 81);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pause";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(422, 239);
            this.button1.MaximumSize = new System.Drawing.Size(94, 30);
            this.button1.MinimumSize = new System.Drawing.Size(94, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "Resume";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(422, 285);
            this.button2.MaximumSize = new System.Drawing.Size(94, 30);
            this.button2.MinimumSize = new System.Drawing.Size(94, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 30);
            this.button2.TabIndex = 4;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Flow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 593);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
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
        private Label label1;
        private Button button1;
        private Button button2;
    }
}