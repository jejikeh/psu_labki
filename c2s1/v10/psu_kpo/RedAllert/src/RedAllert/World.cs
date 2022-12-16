using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedAllert
{
    public class World : GameObject
    {
        private SolidBrush _gameObjectSolidBrush;
        private List<Tile> _tiles = new List<Tile>();
        private List<Tuple<GameObject, int>> _gameObjectInWorld = new();
        private Random _random = new Random();

        public World(int x, int y, int width, int height, Game form) : base(x, y, width, height, form)
        {
            _gameObjectSolidBrush = new SolidBrush(Color.Gray);
            InitMap();
        }

        public void SetToTile(GameObject gameObject) {
            var index = _random.Next(_tiles.Count);
            _gameObjectInWorld.Add(new Tuple<GameObject, int>(gameObject, index));

            _gameObjectInWorld.Last().Item1.X = _tiles[index].X;
            _gameObjectInWorld.Last().Item1.Y = _tiles[index].Y;
        }


        public void MoveToNextTile(GameObject gameObject)
        {
            var findedObject = _gameObjectInWorld.FindIndex(x => x.Item1 == gameObject);

            if (_gameObjectInWorld[findedObject].Item2 == _tiles.Count - 1)
            {
                _gameObjectInWorld[findedObject].Item1.X = _tiles[0].X;
                _gameObjectInWorld[findedObject].Item1.Y = _tiles[0].Y;
                _gameObjectInWorld[findedObject] = new Tuple<GameObject, int>(_gameObjectInWorld[findedObject].Item1, 0);
                return;
            }

            _gameObjectInWorld[findedObject].Item1.X = _tiles[_gameObjectInWorld[findedObject].Item2 + 1].X;
            _gameObjectInWorld[findedObject].Item1.Y = _tiles[_gameObjectInWorld[findedObject].Item2 + 1].Y;
            _gameObjectInWorld[findedObject] = new Tuple<GameObject, int>(_gameObjectInWorld[findedObject].Item1, _gameObjectInWorld[findedObject].Item2 + 1);
        }

        public override void Draw(Graphics graphics) { }

        public override void Update() { }

        private void InitMap()
        {
            var xCount = 10;
            var yCount = 6;

            for (int x = X; x <= xCount + X; x++)
                _tiles.Add(new Tile(x, Y, 32, 32, Form,0));

            for (int y = Y + 1; y <= yCount + Y; y++)
                _tiles.Add(new Tile(X + xCount, y, 32, 32, Form, 90));

            for (int x = X + xCount; x >= X; x--)
                _tiles.Add(new Tile(x, Y + yCount + 1, 32, 32, Form, 0));

            for (int y = Y + yCount; y >= Y; y--)
                _tiles.Add(new Tile(X, y, 32, 32, Form, 90));
        }
    }
}
