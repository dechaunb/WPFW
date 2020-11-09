using System;

namespace WPFW_Voorbereiding
{
    public class Player
    {
        public int x;

        public Player()
        {
            x = Console.WindowWidth / 2;
        }

        public void left()
        {
            x = Math.Max(0, x - 1);
        }

        public void right()
        {
            x = Math.Min(Console.WindowWidth, x + 1);
        }
    }

    public class Enemy {
        private int x;
        private int y;

        public Enemy() 
        {
            x = Console.WindowWidth / 2;
            y = Console.WindowHeight / 2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Console.Clear();
            Console.CursorVisible = false;
            while (true)
            {
                Console.SetCursorPosition(player.x, Console.WindowHeight);
                Console.Write("O");
                System.Threading.Thread.Sleep(100);
                Console.SetCursorPosition(player.x, Console.WindowHeight);
                Console.Write(" ");
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    if (key.Equals(ConsoleKey.J))
                    {
                        player.left();
                    }
                    if (key.Equals(ConsoleKey.K))
                    {
                        player.right();
                    }
                }

            }
        }
    }
}
