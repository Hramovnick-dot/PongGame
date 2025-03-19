using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    internal class Game
    {
        const int FIELD_ROW = 45;
        const int FIELD_COLUMN = 150;
        const int FIELD_START_POSITION_ROW = 10;
        const int FIELD_START_POSITION_COLUMN = 30;

        public event Action<ConsoleKey> OnKeyPress;

        private bool isRunning = true;
        private bool stopGame = true;
        private Random random;
        private int speedOfGame;
        private int lengthOfRackiets;

        Field field;
        Rackiet rackiet;
        Rackiet rackiet2;
        public Game(int speedOfGame, int length)
        {
            this.speedOfGame = speedOfGame;
            this.lengthOfRackiets = length;
            this.random = new Random();
            this.field = new Field(FIELD_START_POSITION_ROW, FIELD_START_POSITION_COLUMN, FIELD_ROW, FIELD_COLUMN);
            this.rackiet = new Rackiet(1, lengthOfRackiets, FIELD_START_POSITION_ROW, FIELD_START_POSITION_COLUMN, FIELD_ROW, FIELD_COLUMN);
            this.rackiet2 = new Rackiet(2, lengthOfRackiets, FIELD_START_POSITION_ROW, FIELD_START_POSITION_COLUMN, FIELD_ROW, FIELD_COLUMN);
        }
        // Импорт функции WinAPI для проверки состояния клавиши
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        public void Start()
        {
            Console.CursorVisible = false;
            bool ballMovementDirection = true;
            Score score = new Score();
            while (score.ScoreLeftGamer < 15 && score.ScoreRightGamer < 15 && stopGame)
            {
                Console.Clear();
                Grafics.PrintField(field);
                Grafics.PrintScore(score);
                Task.Run(() => HandleInput());
                var newBallPosition = random.Next(50, 100);
                Ball ball = new Ball(30, FIELD_START_POSITION_COLUMN + newBallPosition, FIELD_START_POSITION_ROW, FIELD_START_POSITION_COLUMN, FIELD_ROW, FIELD_COLUMN, ballMovementDirection);
                while (isRunning && stopGame)
                {
                    ball.Upgraid(rackiet, rackiet2);
                    Grafics.PrintBall(ball);
                    Grafics.ClearOldPosition(rackiet);
                    Grafics.ClearOldPosition(rackiet2);
                    Grafics.PrintRackiet(rackiet);
                    Grafics.PrintRackiet(rackiet2);
                    isRunning = !ball.EndOfRound().IsRoundEnd;
                    if (!isRunning)
                    {
                        Grafics.ClearBall(ball);
                        if (ball.EndOfRound().IsRightPlayerLose == true)
                        {
                            score.ScoreLeftGamer++;
                            ballMovementDirection = true;
                        }
                        else
                        {
                            score.ScoreRightGamer++;
                            ballMovementDirection = false;
                        }
                    }
                    Thread.Sleep(100 - speedOfGame * 10 + 1);
                }
               // Grafics.PrintScore(score);
                isRunning = true;
            }
            Console.Clear();
            if (score.ScoreLeftGamer == 15)
                Console.WriteLine("Победил игрок слева");
            else if (score.ScoreRightGamer == 15)
                Console.WriteLine("Победил игрок справа");
            else Console.WriteLine("Вы же не доиграли!");
            Console.ReadLine();
        }
        private void HandleInput()
        {
            while (isRunning)
            {
                CheckKey(ConsoleKey.UpArrow);
                CheckKey(ConsoleKey.DownArrow);
                CheckKey(ConsoleKey.W);
                CheckKey(ConsoleKey.S);
                CheckKey(ConsoleKey.Escape);
                Thread.Sleep(70); // Небольшая задержка для снижения нагрузки на CPU
            }
        }
        private void CheckKey(ConsoleKey key)
        {
            if (IsKeyPressed(key))
            {
                OnKeyPress?.Invoke(key);
                if (key == ConsoleKey.Escape)
                {
                    stopGame = false;
                    isRunning = false;
                }
            }
        }
        private bool IsKeyPressed(ConsoleKey key)
        {
            // Проверяем состояние клавиши с помощью WinAPI
            return (GetAsyncKeyState((int)key) & 0x8000) != 0;
        }
        public void HandleKeyPress(ConsoleKey key)
        {
            if (key == ConsoleKey.UpArrow)
                rackiet2.RackietUp();
            if (key == ConsoleKey.DownArrow)
                rackiet2.RackietDown();
            if (key == ConsoleKey.W)
                rackiet.RackietUp();
            if (key == ConsoleKey.S)
                rackiet.RackietDown();
        }
    }
}

