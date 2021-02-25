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
        int cols; int rows;
        int sizex; int sizey;

        Boolean GameOver = false;

        int startPosX, startPosY;

        Random random;
        Timer timer;

        int Speed;

        List<Square> Snake = new List<Square>();
        Square food = new Square();

        enum Direction {up,down,left,right}

        Direction direction;


        public GameForm()
        {
            InitializeComponent();

            cols = 69;
            rows = 36;

            gamePoints = 0;

            Speed = 10;

            startPosX = 34;
            startPosY = 18;

            direction = Direction.up;

            random = new Random();


            //Timer (for game speed)
            timer = new Timer();
            timer.Interval = 1000/Speed;
            timer.Tick += new EventHandler(tick);
            timer.Start(); 

            sizex = Board.Width /cols;
            sizey = Board.Height/rows;


            InitializeGame();
        }

        private void InitializeGame()
        {
            Snake.Clear();
            //Create Snake
            Square square = new Square();
            square.x = startPosX;
            square.y = startPosY;
            Snake.Add(square);

            //Create Food
            food = new Square();
            food.x = random.Next(0, cols);
            food.y = random.Next(0, rows);
        }

        private void tick(object sender, EventArgs e)
        {
            Console.WriteLine("HEE");
            for (int i = 0; i < Snake.Count; i++)
            {

                if (i == 0)
                {
                    switch (direction)
                    {
                        case Direction.up:
                            if (Snake[i].y == 0) { Snake[i].y = rows; } else { Snake[i].y--; }
                            break;
                        case Direction.down:
                            if (Snake[i].y == rows) { Snake[i].y = 0; } else { Snake[i].y++; }
                            break;
                        case Direction.right:
                            if (Snake[i].x == cols) { Snake[i].x = 0; } else { Snake[i].x++; }
                            break;
                        case Direction.left:
                            if (Snake[i].x == 0) { Snake[i].x = cols; } else { Snake[i].x--; }
                            break;

                    }

                } else {
                    Snake[i].x = Snake[i - 1].x;
                    Snake[i].y = Snake[i - 1].y;
                }

            } Board.Invalidate();
        }

        private void Collisions()
        {
            //Collisions with food

            //Collisions with body

        }

        private void KeyHandler(object sender, KeyEventArgs e)
        {
            Keys key = e.KeyCode;
            
            switch (key) {
                case Keys.Up:
                    direction = Direction.up;
                    break;
                case Keys.Down:
                    direction = Direction.down;
                    break;
                case Keys.Right:
                    direction = Direction.right;
                    break;
                case Keys.Left:
                    direction = Direction.left;
                    break;
                case Keys.Escape:
                    if (MessageBox.Show("Are you sure you want to close?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                    break;
                case Keys.Enter:
                    if (GameOver)
                    {
                        gamePoints = 0;
                        updateScore();

                        InitializeGame();

                        timer.Start();
                    }
                    break;
                default:
                    break;
            }
        }


        private void Board_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            for (int i = 0; i<Snake.Count;i++)
            {
                Size size = new Size(sizex, sizey);
                Point point = new Point(Snake[i].x*10, Snake[i].y*10);
                Rectangle rectangle = new Rectangle(point,size);
                graphics.FillRectangle(Brushes.Black, rectangle);
            }

            Size s = new Size(sizex, sizey);
            Point p = new Point(food.x*10 , food.y*10);

            Rectangle r = new Rectangle(p, s);
            graphics.FillRectangle(Brushes.Red,r);
        }

        private void updateScore()
        {
            score.Text = "Score: " + gamePoints;
        }



    }
}
