using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class GameManager
    {
        public enum Team
        {
            O,
            X
        }

        private Game _game;
        private Team _playerTeam;
        private Team _enemyTeam;
        private int _fieldSize;
        private bool _computer;

        public GameManager(Game game, bool computer = false)
        {
            _game = game;
            _playerTeam = (Team)Random.Shared.Next(1);
            _enemyTeam = _playerTeam == Team.O ? Team.X : Team.O;
            _fieldSize = (int)Math.Sqrt(_game.Field.Count);
            _computer = computer;

            _game.Field.ForEach(x =>
            {
                x.Click += Y_Click;
            });
        }

        private void Y_Click(object? sender, EventArgs e)
        {
            var button = sender as Button;
            if (button is null)
            {
                return;
            }

            var empty = _game.Field.Where(x => x.Text == string.Empty);
            if (empty.Any())
            {

                if (button.Text != string.Empty) return;

                button.Text = _playerTeam.ToString();

                if (_computer) {
                    EnemyMove();
                } else
                {
                    (_enemyTeam, _playerTeam) = (_playerTeam, _enemyTeam);
                }

                var s = IsWinState();

                if (s is not null)
                {
                    if (s == _playerTeam) MessageBox.Show($"You win! {s}");
                    else MessageBox.Show($"You lose, WIN {s}");
                    ResetGame();
                }
            } else
            {
                ResetGame();
            }
        }

        private void EnemyMove()
        {
            var empty = _game.Field.Where(x => x.Text == string.Empty);
            if (empty.Any())
            {
                empty.ToList()[Random.Shared.Next(0, empty.Count())].Text = _enemyTeam.ToString();
            }
        }

        private void ResetGame()
        {
            foreach(var b in _game.Field)
            {
                b.Text = "";
            }
        }

        private Team? IsWinState()
        {
            var field = _game.Field;
            if (field[0].Text == field[1].Text && field[0].Text == field[2].Text)
            {
                if (field[0].Text != string.Empty)
                    return field[0].Text == Team.O.ToString() ? Team.O : Team.X;
            }

            if (field[3].Text == field[4].Text && field[3].Text == field[5].Text)
            {
                if (field[3].Text != string.Empty)
                    return field[3].Text == Team.O.ToString() ? Team.O : Team.X;
            }

            if (field[6].Text == field[7].Text && field[6].Text == field[8].Text)
            {
                if (field[6].Text != string.Empty)
                    return field[6].Text == Team.O.ToString() ? Team.O : Team.X;
            }

            if (field[0].Text == field[4].Text && field[0].Text == field[8].Text)
            {
                if (field[0].Text != string.Empty) 
                    return field[0].Text == Team.O.ToString() ? Team.O : Team.X;
            }

            if (field[2].Text == field[4].Text && field[2].Text == field[6].Text)
            {
                if (field[2].Text != string.Empty) 
                    return field[2].Text == Team.O.ToString() ? Team.O : Team.X;
            }

            if (field[0].Text == field[3].Text && field[0].Text == field[6].Text)
            {
                if (field[0].Text != string.Empty) 
                    return field[0].Text == Team.O.ToString() ? Team.O : Team.X;
            }

            if (field[1].Text == field[4].Text && field[1].Text == field[7].Text)
            {
                if (field[1].Text != string.Empty) 
                    return field[1].Text == Team.O.ToString() ? Team.O : Team.X;
            }

            if (field[2].Text == field[5].Text && field[2].Text == field[8].Text)
            {
                if (field[2].Text != string.Empty) 
                    return field[2].Text == Team.O.ToString() ? Team.O : Team.X;
            }

            return null;
        }
    }
}
