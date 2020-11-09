using System;

namespace WPFW_Voorbereiding
{
   public class Player
    {
        public int x;
        public int lives = 3;

        public string message = " ";

        public Player()
        {
            x = Console.WindowWidth / 2;
            message = "Lives "+ lives;
        }

        public void left()
        {
            x = Math.Max(0, x - 1);
        }

        public void right()
        {
            x = Math.Min(Console.WindowWidth, x + 1);
        }
        public void kill(){
            lives=-1;
            if(lives==0){
                death();
            }else{
                x = Console.WindowWidth / 2;
                message = "Lives "+ lives;
            }
        }
        public void death(){
            message = "game Over";
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
        public static void moveEnemyDown(Enemy enemy,Player player){
            if(enemy.y<=Console.WindowHeight){
               enemy.y+=1; 
            }else{
                resetPosition(enemy,player);
            }
        }
        public static void resetPosition(Enemy enemy,Player player){
                Random random = new Random();
                if(enemy.x==player.x){
                    player.kill();
                }
                enemy.y=0;
                enemy.x=random.Next(Console.WindowWidth);
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
                Console.SetCursorPosition(0,15);
                Console.Write(player.message);
                Console.SetCursorPosition(player.x, Console.WindowHeight);
                Console.Write("O");
                Console.SetCursorPosition(enemy.x, enemy.y);
                Console.Write("E");
                System.Threading.Thread.Sleep(75);
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
                if(beurten%5==0){
                        beurten=1;
                        Enemy.moveEnemyDown(enemy,player);
                    }
            }//end whileloop
        }
    }
}
 
