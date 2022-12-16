using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba9
{
    public partial class Form2 : Form
    {
        private Form1 _parentForm;
        public Form2(Form1 form)
        {
            InitializeComponent();
            _parentForm = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _parentForm.AddOrder    (textBox1.Text, textBox2.Text, textBox3.Text);
            this.Close();
        }
    }
}
