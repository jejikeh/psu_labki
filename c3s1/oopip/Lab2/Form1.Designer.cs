namespace Lab2
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
            components = new System.ComponentModel.Container();
            filmBindingSource = new BindingSource(components);
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            filmRepositoryBindingSource = new BindingSource(components);
            listView1 = new ListView();
            ID = new ColumnHeader();
            Title = new ColumnHeader();
            Rating = new ColumnHeader();
            Contry = new ColumnHeader();
            Release = new ColumnHeader();
            FilmType = new ColumnHeader();
            button5 = new Button();
            label5 = new Label();
            textBox4 = new TextBox();
            label4 = new Label();
            comboBox1 = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)filmBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)filmRepositoryBindingSource).BeginInit();
            SuspendLayout();
            // 
            // filmBindingSource
            // 
            filmBindingSource.DataSource = typeof(Models.Film);
            // 
            // button1
            // 
            button1.Location = new Point(1647, 97);
            button1.Name = "button1";
            button1.Size = new Size(150, 46);
            button1.TabIndex = 2;
            button1.Text = "Create";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1647, 149);
            button2.Name = "button2";
            button2.Size = new Size(150, 46);
            button2.TabIndex = 3;
            button2.Text = "Delete";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(1647, 201);
            button3.Name = "button3";
            button3.Size = new Size(150, 46);
            button3.TabIndex = 4;
            button3.Text = "Update";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // filmRepositoryBindingSource
            // 
            filmRepositoryBindingSource.DataSource = typeof(Persistence.FilmRepository);
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { ID, Title, Rating, Contry, Release, FilmType });
            listView1.LabelEdit = true;
            listView1.Location = new Point(39, 45);
            listView1.Name = "listView1";
            listView1.Size = new Size(1066, 701);
            listView1.TabIndex = 6;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // ID
            // 
            ID.Text = "ID";
            ID.Width = 120;
            // 
            // Title
            // 
            Title.Text = "Title";
            Title.Width = 240;
            // 
            // Rating
            // 
            Rating.Text = "Rating";
            Rating.Width = 100;
            // 
            // Contry
            // 
            Contry.Text = "Country";
            Contry.Width = 240;
            // 
            // Release
            // 
            Release.Text = "Release";
            Release.Width = 240;
            // 
            // FilmType
            // 
            FilmType.Text = "FilmType";
            FilmType.Width = 240;
            // 
            // button5
            // 
            button5.Location = new Point(1647, 45);
            button5.Name = "button5";
            button5.Size = new Size(150, 46);
            button5.TabIndex = 7;
            button5.Text = "Seed";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1472, 540);
            label5.Name = "label5";
            label5.Size = new Size(94, 32);
            label5.TabIndex = 19;
            label5.Text = "Release";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(1597, 540);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(200, 39);
            textBox4.TabIndex = 18;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1489, 467);
            label4.Name = "label4";
            label4.Size = new Size(65, 32);
            label4.TabIndex = 17;
            label4.Text = "Type";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Movie", "Serial" });
            comboBox1.Location = new Point(1597, 467);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(200, 40);
            comboBox1.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1472, 402);
            label3.Name = "label3";
            label3.Size = new Size(82, 32);
            label3.TabIndex = 15;
            label3.Text = "Rating";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1455, 343);
            label2.Name = "label2";
            label2.Size = new Size(99, 32);
            label2.TabIndex = 14;
            label2.Text = "Country";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1494, 289);
            label1.Name = "label1";
            label1.Size = new Size(60, 32);
            label1.TabIndex = 13;
            label1.Text = "Title";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(1597, 402);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(200, 39);
            textBox3.TabIndex = 12;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(1597, 343);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(200, 39);
            textBox2.TabIndex = 11;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1597, 286);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(200, 39);
            textBox1.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1833, 782);
            Controls.Add(label5);
            Controls.Add(textBox4);
            Controls.Add(label4);
            Controls.Add(comboBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button5);
            Controls.Add(listView1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Paint += Form1_Paint;
            ((System.ComponentModel.ISupportInitialize)filmBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)filmRepositoryBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private Button button2;
        private Button button3;
        private BindingSource filmBindingSource;
        private BindingSource filmRepositoryBindingSource;
        private ListView listView1;
        private ColumnHeader ID;
        private ColumnHeader Title;
        private ColumnHeader Rating;
        private ColumnHeader Contry;
        private ColumnHeader Release;
        private Button button5;
        private ColumnHeader FilmType;
        private Label label5;
        private TextBox textBox4;
        private Label label4;
        private ComboBox comboBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
    }
}