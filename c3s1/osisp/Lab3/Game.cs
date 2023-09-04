using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Game : Form
    {
        public List<Button> Field = new List<Button>();
        private GameManager? _gameManager;
        private bool _computerGame = true;

        public Game()
        {
            InitializeComponent();
            _computerGame = true;
        }

        public Game(bool computer)
        {
            InitializeComponent();
            _computerGame = computer;
        }

        private void Game_Load(object sender, EventArgs e)
        {
            Field = new List<Button>
            {
                button1,
                button2, button3, button4, button5, button6,
                button7, button8, button9
            };

            _gameManager = new GameManager(this, _computerGame);
        }
    }
}
