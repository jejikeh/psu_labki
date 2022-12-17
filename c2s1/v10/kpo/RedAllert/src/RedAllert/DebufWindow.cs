using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedAllert
{
    public partial class DebufWindow : Form
    {
        public DebufWindow(string message)
        {
            InitializeComponent();
            label1.Text = message;
            ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
