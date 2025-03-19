using static System.Formats.Asn1.AsnWriter;

namespace Pong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool flag = false;
            int speedOfGame = 0;
            int lengthOfRackiets = 0;
            while (!flag)
            {
                Console.WriteLine("Введите скорость игры от 1 до 10");                
                flag = int.TryParse(Console.ReadLine(), out speedOfGame);
                if (speedOfGame>10 || speedOfGame<1)
                    flag = false;
                Console.Clear();
            }
            flag = false;
            while (!flag)
            {
                Console.WriteLine("Введите длину ракетки игры от 3 до 10");
                flag = int.TryParse(Console.ReadLine(), out lengthOfRackiets);
                if (lengthOfRackiets > 10 || lengthOfRackiets < 3)
                    flag = false;
                Console.Clear();
            }
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Pong";
            Game game = new Game(speedOfGame, lengthOfRackiets);                        
            game.OnKeyPress += game.HandleKeyPress; // Подписываемся на событие
            game.Start();           
        }
    }
}
