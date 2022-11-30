namespace Flow
{
    internal class Snake : Square
    {
        private List<Tail> _snake = new List<Tail>();
        private Color _tailColor;

        protected void AddToTail()
        {
            var tail = new Tail(X, Y, Width, Height, BelongForm, _tailColor, this);
            _snake.Add((Tail)BelongForm.CreateGameObject(tail));
        }

        public Snake(int x, int y, int width, int height, Flow form) : base(x, y, width, height, form)
        {
            _tailColor = RandomColor.Next();
        }

        public Snake(int x, int y, int width, int height, Flow form, Snake parentSnake, List<Tail>? tail) : base(x, y, width, height, form)
        {
            _tailColor = parentSnake._tailColor;
            if(tail is not null)
                _snake = tail;
        }

        private void MoveAllTails()
        {
            if(_snake.Count > 0)
            {
                _snake[0].X = X;
                _snake[0].Y = Y;
            }

            for(var i = _snake.Count - 1; i >= 1; i--)
            {
                _snake[i].X = _snake[i - 1].X;
                _snake[i].Y = _snake[i - 1].Y;
            }
        }

        public override void Update()
        {
            base.Update();
            MoveAllTails();
        }

        public override void OnHit(GameObject gameObject)
        {
            if(gameObject is Bio)
            {
                var tail = new Tail(X, Y, Width, Height, BelongForm,_tailColor, this);
                _snake.Add((Tail)BelongForm.CreateGameObject(tail));
                ToDoOnEatBio();

                if(BelongForm.FlowRandom.Next(0,5) == 2)
                    BelongForm.AddNewBios(1,2);
            }

            if(gameObject is Tail)
            {
                var tail = gameObject as Tail;
                if(tail.ParentSnake != this)
                {
                    var hittedSnake = tail.ParentSnake;
                    if(hittedSnake._snake.Count > 4)
                    {
                        var tempLength = hittedSnake._snake.Count / 2;
                        for (var i = hittedSnake._snake.Count - 1; i > tempLength; i--)
                        {
                            var snakeTail = hittedSnake._snake[i];
                            hittedSnake._snake.Remove(snakeTail);
                            snakeTail.GoingToDie = true;
                        }
                    }else
                    {
                        var snake = tail.ParentSnake;
                        if (snake._snake.Count > _snake.Count)
                        {
                            foreach (var tailr in _snake)
                                tailr.GoingToDie = true;

                            GoingToDie = true;
                        }

                        if (snake._snake.Count < _snake.Count)
                        {
                            foreach (var tailr in snake._snake)
                                tailr.GoingToDie = true;

                            snake.GoingToDie = true;
                        }
                    }
                }
            }

            if(gameObject is Snake)
            {
                var snake = gameObject as Snake;
                if(snake._snake.Count > _snake.Count)
                {
                    foreach(var tail in _snake)
                        tail.GoingToDie = true;

                    GoingToDie = true;
                }

                if (snake._snake.Count < _snake.Count)
                {
                    foreach (var tail in snake._snake)
                        tail.GoingToDie = true;

                    snake.GoingToDie = true;
                }
            }
        }

        public virtual void ToDoOnEatBio() { }

        public GameObject GetRandomTailTile()
        {
            if(_snake.Count > 0)
            {
                var randomIndex = BelongForm.FlowRandom.Next(0, _snake.Count - 1);
                return _snake[randomIndex];
            }

            return this;
        }

        public int DeleteTails(Tail tail)
        {
            var index = _snake.IndexOf(tail);
            if(index > -1)
                _snake = _snake.GetRange(0, index);

            return index;
        }
    }
}
