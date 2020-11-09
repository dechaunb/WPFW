using System;

namespace WPFW_Voorbereiding
{
    public class Player
    {
        public int lives {get; set;}
        public int x;

        public Player(int lives)
        {
            x = Console.WindowWidth / 2;
            this.lives = lives;
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
        public int x {get; set;}
        public int y {get; set;}

        public Enemy(int x) 
        {
            this.x = x;
            this.y = Console.WindowTop;
        }

        public void Move() {
            if(this.y < Console.WindowHeight) {
                y +=1;
            } else {
                y = 0;
                Random rnd = new Random();
                x = rnd.Next(0, Console.WindowWidth);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(3);
            Enemy enemy = new Enemy(Console.WindowWidth / 2);
            Console.Clear();
            Console.CursorVisible = false;

            int countDown = 0;

            bool playerHasLives = true;
            while (playerHasLives == true)
            {
                // Boolean to determine if a life has been distracted this round
                bool subtractedLife = false;

                // Moves player/enemies to new position
                Console.SetCursorPosition(player.x, Console.WindowHeight);
                Console.Write("O");
                Console.SetCursorPosition(enemy.x, enemy.y);
                Console.Write("E");
                System.Threading.Thread.Sleep(100);

                // Erases player/enemies previous position
                Console.SetCursorPosition(player.x, Console.WindowHeight);
                Console.Write(" ");
                Console.SetCursorPosition(enemy.x, enemy.y);
                Console.Write(" ");

                // Increases an int by one, this makes the enemy move slower than the player
                countDown++;
                if(countDown % 3 == 0) {
                    enemy.Move();
                } 

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

                if(enemy.y == Console.WindowHeight) {
                    if(enemy.x == player.x) {
                        if(subtractedLife) {
                            Console.Write("DOOD");
                            break;
                        }
                        player.lives--;
                        subtractedLife = true;
                    }
                }

                if(player.lives <= 0) {
                    playerHasLives = false;
                    Console.Write("DOOD");
                }

            }
        }
    }
}
