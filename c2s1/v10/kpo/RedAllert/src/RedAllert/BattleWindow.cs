using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedAllert
{
    public partial class BattleWindow : Form
    {
        private Image _ratSprite = Image.FromFile("../../../resources/rat.png");
        private Image _playerSprite = Image.FromFile("../../../resources/knight.png");



        private ALifeUnit _player;
        private ALifeUnit _enemy;

        private Random _random = new Random();
        

        public BattleWindow()
        {
            InitializeComponent();
            //_player = player
            
            button1.Hide();
            button2.Hide();
            button3.Hide();

            
            Show();
        }

        public void AddUnits(ALifeUnit player, ALifeUnit enemy)
        {
            _player = player;
            _enemy = enemy;
            button1.Show();
            button2.Show();
            button3.Show();
            label1.Text = $"Здоровье: {_player.Health}";
            label2.Text = $"Здоровье: {_enemy.Health}";
        }
        

        

        private void Draw(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            float playerSize = 256;
            float enemySize = 256;
            graphics.DrawImage(_ratSprite, 256,0, (int)playerSize, (int)playerSize);
            graphics.DrawImage(_playerSprite, 24, 24, enemySize, enemySize);
            Console.WriteLine("FF");
            // _player.Draw(graphics);
            // _enemy.Draw(graphics);
        }

        /// <summary>
        /// stone
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
       
            var ratChoose = _random.Next(0,3);
            switch (ratChoose) {
                case 0:
                    new DebufWindow("Ничья!");
                    break;
                case 1:
                    new DebufWindow($"Победа! Вы наносите {_enemy.Name} {_player.Attack} ед. урона");
                    _enemy.Health -= _player.Attack;
                    label1.Text = $"Здоровье: {_player.Health}";
                    label2.Text = $"Здоровье: {_enemy.Health}";
                    break;
                case 2:
                    new DebufWindow($"Поражение! {_enemy.Name} наносит вам {_enemy.Attack} ед. урона");
                    _player.Health -= _enemy.Attack;
                    label1.Text = $"Здоровье: {_player.Health}";
                    label2.Text = $"Здоровье: {_enemy.Health}";
                    break;
            }
            if (_enemy.Health <= 0)
            {
                new DebufWindow("You Win");
                Close();
            }
            else if(_player.Health <=0)
            {
                new DebufWindow("You Lose((:(");

                Close();
            }

            pictureBox1.Invalidate();
        }

        /// <summary>
        /// n
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
           

            var ratChoose = _random.Next(0, 3);
            switch (ratChoose)
            {
                case 0:
                    new DebufWindow($"Поражение! {_enemy.Name} наносит вам {_enemy.Attack} ед. урона");
                    _player.Health -= _enemy.Attack;
                    label1.Text = $"Здоровье: {_player.Health}";
                    label2.Text = $"Здоровье: {_enemy.Health}";
                    break;
                case 1:
                    new DebufWindow("Ничья!");
                    break;
                case 2:
                    new DebufWindow($"Победа! Вы наносите {_enemy.Name} {_player.Attack} ед. урона");

                    _enemy.Health -= _player.Attack;
                    label1.Text = $"Здоровье: {_player.Health}";
                    

                    label2.Text = $"Здоровье: {_enemy.Health}";
                    break;
            }
            if (_enemy.Health <= 0)
            {
                new DebufWindow("You Win");
               

                Close();
            }
            else if(_player.Health <=0)
            {
                new DebufWindow("You Lose((:(");
                

                Close();
            }

            pictureBox1.Invalidate();

        }

        /// <summary>
        /// paper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
           
            var ratChoose = _random.Next(0, 3);
            switch (ratChoose)
            {
                case 0:
                    new DebufWindow($"Победа! Вы наносите {_enemy.Name} {_player.Attack} ед. урона");
                    _enemy.Health -= _player.Attack;
                    label1.Text = $"Здоровье: {_player.Health}";
                    label2.Text = $"Здоровье: {_enemy.Health}";
                    break;
                case 1:
                    new DebufWindow($"Поражение! {_enemy.Name} наносит вам {_enemy.Attack} ед. урона");
                    _player.Health -= _enemy.Attack;
                    label1.Text = $"Здоровье: {_player.Health}";
                    label2.Text = $"Здоровье: {_enemy.Health}";
                    break;
                case 2:
                    new DebufWindow("Ничья!");
               

                    break;
            }
            if (_enemy.Health <= 0)
            {
                new DebufWindow("You Win");
              

                Close();
            }
            else if(_player.Health <=0)
            {
                new DebufWindow("You Lose((:(");

                Close();
            }

            pictureBox1.Invalidate();

        }

     
    }
}
