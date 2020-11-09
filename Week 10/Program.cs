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
        public int x;
        public int y;

        public Enemy() 
        {
            x = Console.WindowWidth / 2;
            y = 0;
        }
            public static void moveEnemyDown(Enemy enemy){
            if(enemy.y<=Console.WindowHeight){
               enemy.y+=1; 
            }else{
                Random random = new Random();
                enemy.y=0;
                enemy.x=random.Next(Console.WindowWidth);
            }
        }
    }

    class Program
    {
        public static int beurten = 0;
        static void Main(string[] args)
        {
            Player player = new Player();
            Enemy enemy = new Enemy();
            
            Console.Clear();
            Console.CursorVisible = false;
            while (true)
            {
                Console.SetCursorPosition(player.x, Console.WindowHeight);
                Console.Write("O");
                Console.SetCursorPosition(enemy.x, enemy.y);
                Console.Write("E");
                System.Threading.Thread.Sleep(100);
                beurten++;
                Console.SetCursorPosition(player.x, Console.WindowHeight);
                Console.Write(" ");
                Console.SetCursorPosition(enemy.x, enemy.y);
                Console.Write(" ");
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    if (key.Equals(ConsoleKey.A))
                    {
                        player.left();
                        
                        
                    }
                    if (key.Equals(ConsoleKey.D))
                    {
                        player.right();
                        
                    }
                    
                }
                if(beurten%4==0){
                        Enemy.moveEnemyDown(enemy);
                    }
            }//end whileloop
        }
    }
}
 
