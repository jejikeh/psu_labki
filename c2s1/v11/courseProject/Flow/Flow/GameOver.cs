using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flow
{
    public partial class GameOver : Form
    {
        private Form _parentWindow;
        public SoundPlayer PressSound = new SoundPlayer("1.wav");
        public SoundPlayer WinSound = new SoundPlayer("2.wav");
        public SoundPlayer DeadSound = new SoundPlayer("3.wav");
        public GameOver(Form form)
        {
            InitializeComponent();
            Show();
            _parentWindow= form;
            DeadSound.Play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _parentWindow.Show();
            PressSound.Play();
            Close();
        }
    }
}
