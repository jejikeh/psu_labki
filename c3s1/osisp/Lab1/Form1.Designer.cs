namespace Lab1
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            rColorSlider = new TrackBar();
            gColorSlider = new TrackBar();
            bColorSlider = new TrackBar();
            colorBox = new PictureBox();
            rValue = new Label();
            gValue = new Label();
            bValue = new Label();
            rHex = new Label();
            ((System.ComponentModel.ISupportInitialize)rColorSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gColorSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bColorSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)colorBox).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 61);
            label1.Name = "label1";
            label1.Size = new Size(28, 32);
            label1.TabIndex = 0;
            label1.Text = "R";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 132);
            label2.Name = "label2";
            label2.Size = new Size(30, 32);
            label2.TabIndex = 1;
            label2.Text = "G";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(37, 203);
            label3.Name = "label3";
            label3.Size = new Size(28, 32);
            label3.TabIndex = 2;
            label3.Text = "B";
            // 
            // rColorSlider
            // 
            rColorSlider.Location = new Point(83, 61);
            rColorSlider.Maximum = 255;
            rColorSlider.Name = "rColorSlider";
            rColorSlider.Size = new Size(157, 90);
            rColorSlider.TabIndex = 3;
            // 
            // gColorSlider
            // 
            gColorSlider.Location = new Point(83, 132);
            gColorSlider.Maximum = 255;
            gColorSlider.Name = "gColorSlider";
            gColorSlider.Size = new Size(157, 90);
            gColorSlider.TabIndex = 4;
            // 
            // bColorSlider
            // 
            bColorSlider.Location = new Point(83, 203);
            bColorSlider.Maximum = 255;
            bColorSlider.Name = "bColorSlider";
            bColorSlider.Size = new Size(157, 90);
            bColorSlider.TabIndex = 5;
            // 
            // colorBox
            // 
            colorBox.Location = new Point(322, 12);
            colorBox.Name = "colorBox";
            colorBox.Size = new Size(466, 426);
            colorBox.TabIndex = 6;
            colorBox.TabStop = false;
            // 
            // rValue
            // 
            rValue.AutoSize = true;
            rValue.Location = new Point(261, 70);
            rValue.Name = "rValue";
            rValue.Size = new Size(27, 32);
            rValue.TabIndex = 7;
            rValue.Text = "0";
            // 
            // gValue
            // 
            gValue.AutoSize = true;
            gValue.Location = new Point(261, 132);
            gValue.Name = "gValue";
            gValue.Size = new Size(27, 32);
            gValue.TabIndex = 8;
            gValue.Text = "0";
            // 
            // bValue
            // 
            bValue.AutoSize = true;
            bValue.Location = new Point(261, 203);
            bValue.Name = "bValue";
            bValue.Size = new Size(27, 32);
            bValue.TabIndex = 9;
            bValue.Text = "0";
            // 
            // rHex
            // 
            rHex.AutoSize = true;
            rHex.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            rHex.Location = new Point(52, 314);
            rHex.Name = "rHex";
            rHex.Size = new Size(188, 59);
            rHex.TabIndex = 10;
            rHex.Text = "#000000";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rHex);
            Controls.Add(bValue);
            Controls.Add(gValue);
            Controls.Add(rValue);
            Controls.Add(colorBox);
            Controls.Add(bColorSlider);
            Controls.Add(gColorSlider);
            Controls.Add(rColorSlider);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)rColorSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)gColorSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)bColorSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)colorBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TrackBar rColorSlider;
        private TrackBar gColorSlider;
        private TrackBar bColorSlider;
        private PictureBox colorBox;
        private Label rValue;
        private Label gValue;
        private Label bValue;
        private Label rHex;
    }
}