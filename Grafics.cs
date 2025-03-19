using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    internal class Grafics
    {
        const char SYMBOL_OF_FIELD = '█';
        const char SYMBOL_OF_RACKIET = '█';
        const char SYMBOL_OF_BALL = '●';
        public static void PrintField(Field field)
        {
            for (int i = 0; i < field.startRow; i++)
                Console.WriteLine();
            Console.Write(new string(' ', field.startColumn));
            Console.WriteLine(new string(SYMBOL_OF_FIELD, field.sizeColumn + 1));
            for (int i = field.startRow; i < field.sizeRow; i++)
            {
                Console.Write(new string(' ', field.startColumn));
                Console.Write(SYMBOL_OF_FIELD);
                Console.Write(new string(' ', field.sizeColumn - 1));
                Console.Write(SYMBOL_OF_FIELD);
                Console.WriteLine();
            }
            Console.Write(new string(' ', field.startColumn));
            Console.WriteLine(new string(SYMBOL_OF_FIELD, field.sizeColumn + 1));
        }
        public static void PrintRackiet(Rackiet rackiet)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = rackiet.CoordinateStart; i <= rackiet.CoordinateEnd; i++)
            {
                Console.SetCursorPosition(rackiet.CoordinateX, i);
                Console.Write(SYMBOL_OF_RACKIET);
            }
            Console.ResetColor();
            rackiet.OldCoordinateStart = rackiet.CoordinateStart;
            rackiet.OldCoordinateEnd = rackiet.CoordinateEnd;
        }
        public static void ClearOldPosition(Rackiet rackiet)
        {
            for (int i = rackiet.OldCoordinateStart; i <= rackiet.OldCoordinateEnd; i++)
            {
                Console.SetCursorPosition(rackiet.CoordinateX, i);
                Console.Write(' '); // Очищаем старую позицию ракетки
            }
        }
        public static void PrintBall(Ball ball)
        {
            Console.SetCursorPosition(ball.PositionY,ball.PositionX);
            Console.Write(SYMBOL_OF_BALL);
            Console.SetCursorPosition(ball.OldPositionY, ball.OldPositionX);
            Console.Write(' '); 
        }
        public static void ClearBall(Ball ball)
        {
            Console.SetCursorPosition(ball.OldPositionY, ball.OldPositionX);
            Console.Write(' ');
        }

        public static void PrintScore(Score score)
        {
            Console.SetCursorPosition(100,3);
            Console.Write($"{score.ScoreLeftGamer}\t{score.ScoreRightGamer}");        
        }
    }
}
