using System;

namespace WPFW_Voorbereiding
{
   public class Player
    {
        public int x;
        public int lives = 3;
        public bool living = true;

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
            lives=lives-1;
            if(lives==0){
                death();
            }else{
                x = Console.WindowWidth / 2;
                message = "Lives "+ lives;
            }
        }
        public void death(){
            message = "game Over";
            living = false;
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
        public static void moveVerticalEnemyDown(Enemy enemy,Player player){
            Random random = new Random();
            if(enemy.y<=Console.WindowHeight){
                enemy.y+=1; 
                if(enemy.x<=Console.WindowWidth){
                    enemy.x+=1;
                }else{
                    enemy.x=-1;
                }
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
            Enemy verticalEnemy = new Enemy();
            
            Console.Clear();
            Console.CursorVisible = false;
            
            while (true)
            {
                Console.SetCursorPosition(0,15);
                Console.Write(player.message);
                printPlayer(player);
                printEnemy(enemy,'E');
                printEnemy(verticalEnemy,'v');
                System.Threading.Thread.Sleep(75);
                beurten++;
                Console.SetCursorPosition(player.x, Console.WindowHeight);
                Console.Write(" ");
                Console.SetCursorPosition(enemy.x, enemy.y);
                Console.Write(" ");
                Console.SetCursorPosition(verticalEnemy.x, verticalEnemy.y);
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
                        Enemy.moveVerticalEnemyDown(verticalEnemy,player);
                    }
            }//end whileloop
        }
        public static void printPlayer(Player player){
            Console.SetCursorPosition(player.x, Console.WindowHeight);
            Console.Write("O");
        }
        public static void printEnemy(Enemy enemy,char icon){
            Console.SetCursorPosition(enemy.x, enemy.y);
            Console.Write(icon);
        }
    }
}
 
