using System.Media;

namespace Flow
{
    public partial class Flow : Form
    {
        private List<GameObject> gameObjects = new List<GameObject>();
        private int _score = 0;
        private MainMenu _parentWindow;
        private List<GameObject> _collidedDetectedQuene = new List<GameObject>();
        public MainMenu Menu => _parentWindow;

        public int WidthF = 60;
        public int HeightF = 36;

        private bool _isPlaying = true;

        public Flow(MainMenu form)
        {
            WidthF = ClientSize.Width; HeightF = ClientSize.Height;

            InitializeComponent();
            Show();
            _parentWindow= form;

            label1.Enabled= false;
            label1.Visible = false;
            button1.Enabled=false;
            button1.Visible = false;
            button2.Enabled=false;
            button2.Visible = false;
            gameCanvas.BackColor = RandomColor.NextAlpha(20);
        }

        public Random FlowRandom = new Random();
        private void Flow_Load(object sender, EventArgs e)
        {
            spawnBios.Interval = FlowRandom.Next(1000, 10000);
            AddNewBios();

            CreateGameObject(new PlayerSnake(3, 3, 16, 16, this));
            // CreateGameObject(new ComputerSnake(4, 40, 16, 16, this));
            // CreateGameObject(new ComputerSnake(32, 40, 16, 16, this));
            // CreateGameObject(new ComputerSnake(24, 40, 16, 16, this));

            gameTimer.Start();
        }
        
        public void AddNewBios(int min = 0, int max = 20)
        {
            for (int i = 0; i < FlowRandom.Next(min, max); i++)
                CreateGameObject(new Bio(FlowRandom.Next(0, WidthF / 16), FlowRandom.Next(0, HeightF / 16), 16, 16, this));
        }

        public void AddNewComp(int min = 0, int max = 5)
        {
            for (int i = 0; i < FlowRandom.Next(min, max); i++)
                CreateGameObject(new ComputerSnake(FlowRandom.Next(0, WidthF / 16), FlowRandom.Next(0, HeightF / 16), 16, 16, this));
        }

        public GameObject CreateGameObject(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
            return gameObject;
        }

        private void StartPlay()
        {
            _isPlaying = true;
            label1.Enabled = false;
            label1.Visible = false;
            button1.Enabled = false;
            button1.Visible = false;
            button2.Enabled = false;
            button2.Visible = false;
        }

        private void StopPlay()
        {
            _isPlaying = false;
            label1.Enabled = true;
            label1.Visible = true;
            button1.Enabled = true;
            button1.Visible = true;
            button2.Enabled = true;
            button2.Visible = true;
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

            if(e.KeyCode == Keys.Escape)
            {
                if (_isPlaying)
                {
                    StopPlay();
                }
                else
                {
                    StopPlay();
                }
            }

        }

        private void UpdateCanvas(object sender, PaintEventArgs e)
        {

            var graphics = e.Graphics;
            foreach(var obj in gameObjects)
                obj.Draw(graphics);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            WidthF = ClientSize.Width - 20;
            HeightF = ClientSize.Height - 20;
            gameCanvas.Size = new Size(WidthF, HeightF);

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


            if (_isPlaying)
            {
                for (int i = 0; i < gameObjects.Count; i++)
                    gameObjects[i].Update();

                CheckForCollisions();
                DeleteDiedObjects();
                gameCanvas.Invalidate();
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            StartPlay();
            _parentWindow.PressSound.Play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _parentWindow.Show();
            _parentWindow.PressSound.Play();
            Close();
            return;
        }

        public void DeleteDiedObjects()
        {
            foreach(var obj in gameObjects)
            {
                if (obj is PlayerSnake && obj.GoingToDie)
                {
                    new GameOver(_parentWindow);
                    _parentWindow.AddToScoreList(_score);
                    Close();
                    gameObjects.Remove(obj);
                    return;
                }

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