namespace Lab3
{
    partial class Form1
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
            lPlay = new Label();
            label2 = new Label();
            lExit = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // lPlay
            // 
            lPlay.AutoSize = true;
            lPlay.Font = new Font("Segoe UI", 25.875F, FontStyle.Regular, GraphicsUnit.Point);
            lPlay.Location = new Point(101, 287);
            lPlay.Name = "lPlay";
            lPlay.Size = new Size(628, 92);
            lPlay.TabIndex = 0;
            lPlay.Text = "Player vs Computer";
            lPlay.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(101, 66);
            label2.Name = "label2";
            label2.Size = new Size(406, 170);
            label2.TabIndex = 1;
            label2.Text = "TicTac";
            // 
            // lExit
            // 
            lExit.AutoSize = true;
            lExit.Font = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point);
            lExit.Location = new Point(101, 457);
            lExit.Name = "lExit";
            lExit.Size = new Size(270, 170);
            lExit.TabIndex = 2;
            lExit.Text = "Exit";
            lExit.Click += label3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25.875F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(101, 379);
            label1.Name = "label1";
            label1.Size = new Size(507, 92);
            label1.TabIndex = 3;
            label1.Text = "Player vs Player";
            label1.Click += label1_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1283, 817);
            Controls.Add(label1);
            Controls.Add(lExit);
            Controls.Add(label2);
            Controls.Add(lPlay);
            Name = "Form1";
            Text = "Menu";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lPlay;
        private Label label2;
        private Label lExit;
        private Label label1;
    }
}