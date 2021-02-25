using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snakegame
{
    public partial class GameForm : System.Windows.Forms.Form
    {
        int gamePoints;
        int boardWidth; int boardHeight;
        int sizex; int sizey;

        Boolean gameOver = false;

        int startPosX, startPosY;

        Random random;
        Timer timer;

        int gameSpeed;

        List<Square> snake = new List<Square>();
        Square food = new Square();

        enum Direction {up,down,left,right}

        Direction direction;


        public GameForm()
        {
            InitializeComponent();

            labelGame.Visible = false;

            boardWidth = 40;
            boardHeight = 30;

            gamePoints = 0;

            gameSpeed = 10;

            startPosX = 22;
            startPosY = 15;

            direction = Direction.up;

            random = new Random();

            timer = new Timer();
            timer.Interval = 1000/gameSpeed;
            timer.Tick += new EventHandler(Movement);
            timer.Start(); 

            sizex = Board.Width /boardWidth;
            sizey = Board.Height/boardHeight;


            InitializeGame();
        }

        private void InitializeGame()
        {
            snake.Clear();

            //Create Snake
            Square square0 = new Square();
            square0.x = startPosX;
            square0.y = startPosY;

            Square square1 = new Square();
            square1.x = startPosX;
            square1.y = startPosY+1;

            Square square2 = new Square();
            square2.x = startPosX;
            square2.y = startPosY+2;

            snake.Add(square0);
            snake.Add(square1);
            snake.Add(square2);

            CreateFood();
        }

        public void CreateFood()
        {
            food = new Square();
            food.x = random.Next(0, boardWidth);
            food.y = random.Next(0, boardHeight);
        }

        private void Movement(object sender, EventArgs e)
        {
            if (!gameOver) { 
            for (int i = snake.Count-1; i >= 0; i--)
            {

                if (i == 0)
                {
                    switch (direction)
                    {
                        case Direction.up:
                            if (snake[i].y == 0) { snake[i].y = boardHeight; } else { snake[i].y--; }
                            break;
                        case Direction.down:
                            if (snake[i].y == boardHeight) { snake[i].y = 0; } else { snake[i].y++; }
                            break;
                        case Direction.right:
                            if (snake[i].x == boardWidth) { snake[i].x = 0; } else { snake[i].x++; }
                            break;
                        case Direction.left:
                            if (snake[i].x == 0) { snake[i].x = boardWidth; } else { snake[i].x--; }
                            break;

                    }

                } else {
                    snake[i].x = snake[i - 1].x;
                    snake[i].y = snake[i - 1].y;
                }

            }
            Collisions();
            Board.Invalidate();
            }
        }

        private void Collisions()
        {
            //Collisions with food
            if (snake[0].x==food.x && snake[0].y==food.y)
            {
                food = new Square();
                food.x = snake[snake.Count - 1].x;
                food.y = snake[snake.Count - 1].y;
                snake.Add(food);

                updateScore();

                if (gamePoints % 3 == 0) { gameSpeed++; timer.Interval = 1000 / gameSpeed;};

                CreateFood();


            }

            //Collisions with body
            for (int i = 2; i < snake.Count; i++)
            {
                if (snake[0].x == snake[i].x && snake[0].y == snake[i].y)
                {
                    gameOver = true;
                    labelGame.Visible = true;
                }
            }


        }

        private void KeyHandler(object sender, KeyEventArgs e)
        {
            Keys key = e.KeyCode;
            
            switch (key) {
                case Keys.Up:
                    if (direction != Direction.down) {direction = Direction.up;}
                    break;
                case Keys.Down:
                    if (direction != Direction.up)   {direction = Direction.down;}
                    break;
                case Keys.Right:
                    if (direction != Direction.left) {direction = Direction.right;}
                    break;
                case Keys.Left:
                    if (direction != Direction.right) {direction = Direction.left;}
                        
                    break;
                case Keys.Escape:
                    if (MessageBox.Show("Are you sure you want to close?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                    break;
                case Keys.Enter:
                    if (gameOver)
                    {
                        updateScore();

                        gameOver = false;

                        labelGame.Visible = false;

                        InitializeGame();


                        
                    }
                    break;
                default:
                    break;
            }
        }


        private void Board_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            for (int i = 0; i<snake.Count;i++)
            {
                Rectangle rectangle = new Rectangle(new Point(snake[i].x * 10, snake[i].y * 10), new Size(sizex, sizey));
                graphics.FillRectangle(Brushes.Black, rectangle);
            }

            Rectangle r = new Rectangle(new Point(food.x * 10, food.y * 10), new Size(sizex, sizey));
            graphics.FillRectangle(Brushes.Red,r);
        }

        private void updateScore()
        {
            if (gameOver) { gamePoints = 0; }
            else { gamePoints++; }

            score.Text = "Score: " + gamePoints;
        }



    }
}
