using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flow
{
    public partial class GameOver : Form
    {
        private Form _parentWindow;
        public GameOver(Form form)
        {
            InitializeComponent();
            Show();
            _parentWindow= form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _parentWindow.Show();
            Close();
        }
    }
}
