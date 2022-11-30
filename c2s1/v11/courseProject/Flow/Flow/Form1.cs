namespace Flow
{
    public partial class Flow : Form
    {
        private List<GameObject> gameObjects = new List<GameObject>();
        private int _score = 0;

        private List<GameObject> _collidedDetectedQuene = new List<GameObject>();


        public Flow()
        {
            InitializeComponent();
        }

        public Random FlowRandom = new Random();
        private void Flow_Load(object sender, EventArgs e)
        {
            spawnBios.Interval = FlowRandom.Next(1000, 10000);
            AddNewBios();

            CreateGameObject(new PlayerSnake(3, 3, 16, 16, this));
            CreateGameObject(new ComputerSnake(4, 40, 16, 16, this));
            CreateGameObject(new ComputerSnake(32, 40, 16, 16, this));
            CreateGameObject(new ComputerSnake(24, 40, 16, 16, this));

            gameTimer.Start();
        }
        
        public void AddNewBios(int min = 0, int max = 20)
        {
            for (int i = 0; i < FlowRandom.Next(min, max); i++)
                CreateGameObject(new Bio(FlowRandom.Next(0, 60), FlowRandom.Next(0, 36), 16, 16, this));
        }

        public void AddNewComp(int min = 0, int max = 5)
        {
            for (int i = 0; i < FlowRandom.Next(min, max); i++)
                CreateGameObject(new ComputerSnake(FlowRandom.Next(0, 60), FlowRandom.Next(0, 36), 16, 16, this));
        }

        public GameObject CreateGameObject(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
            return gameObject;
        }

        public bool goLeft, goRight, goDown, goUp, goCreate;
        public string directions;
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && directions != "right")
                goLeft = true;
            if (e.KeyCode == Keys.Right && directions != "left")
                goRight = true;
            if (e.KeyCode == Keys.Up && directions != "down")
                goUp = true;
            if (e.KeyCode == Keys.Down && directions != "up")
                goDown = true;
            if (e.KeyCode == Keys.K)
                goCreate = true;
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                goLeft = false;
            if (e.KeyCode == Keys.Right)
                goRight = false;
            if (e.KeyCode == Keys.Up)
                goUp = false;
            if (e.KeyCode == Keys.Down)
                goDown = false;
            
            if (e.KeyCode == Keys.K)
                goCreate = false;
        }

        private void UpdateCanvas(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            foreach(var obj in gameObjects)
                obj.Draw(graphics);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (goLeft)
                directions = "left";
            if (goRight)
                directions = "right";
            if (goDown)
                directions = "down";
            if (goUp)
                directions = "up";
            if (goCreate)
                directions = "create";


            for(int i = 0; i < gameObjects.Count; i++)
                gameObjects[i].Update();

            CheckForCollisions();
            DeleteDiedObjects();
            gameCanvas.Invalidate(); 
        }

        private void spawnBios_Tick(object sender, EventArgs e)
        {
            AddNewBios();
            AddNewComp();
        }

        private void CheckForCollisions()
        {
            for(var i = 0; i < gameObjects.Count; i++)
            {
                for(var k = 0; k < gameObjects.Count; k++)
                {
                    if (i == k) continue;

                    if (gameObjects[i].X == gameObjects[k].X && gameObjects[i].Y == gameObjects[k].Y)
                    {
                        if (!_collidedDetectedQuene.Contains(gameObjects[k]) || !_collidedDetectedQuene.Contains(gameObjects[i]))
                        {
                            gameObjects[i].OnHit(gameObjects[k]);
                            gameObjects[k].OnHit(gameObjects[i]);
                            _collidedDetectedQuene.Add(gameObjects[i]);
                            _collidedDetectedQuene.Add(gameObjects[k]);
                        }
                    }
                }
            }
        }

        private void garbageColliders_Tick(object sender, EventArgs e)
        {
            _collidedDetectedQuene.Clear();
        }

        public void DeleteDiedObjects()
        {
            foreach(var obj in gameObjects)
            {
                if (obj.GoingToDie)
                {
                    gameObjects.Remove(obj);
                    return;
                }
            }
        }

        public void AddScore()
        {
            _score += 1;
            txtScore.Text = $"Score: {_score}";
        }

        public T GetRandomTarget<T>() where T : GameObject
        {

            var filter = gameObjects.Select(x => { return new { succses = x is T, val = x }; }).Where(a => a.succses).Select(v => (T)v.val).ToList();
            if (filter.Count == 0)
            {
                AddNewBios();
                return GetRandomTarget<T>();
            }

            var randomIndex = FlowRandom.Next(0, filter.Count - 1);
            var randomGameObject = filter[randomIndex];
            if (randomGameObject is Snake)
            {
                var snake = randomGameObject as Snake;
                randomGameObject = snake.GetRandomTailTile() as T;
            }

            return randomGameObject;
        }

        public List<T> GetGameObjects<T>() where T : GameObject
        {
            var filter = gameObjects.Select(x => { return new { succses = x is T, val = x }; }).Where(a => a.succses).Select(v => (T)v.val).ToList();

            return filter;
        }
    }
}