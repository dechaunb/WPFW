using System;
using System.Collections.Generic;  

namespace WPFW_Voorbereiding
{

    public abstract class Entity {
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
   public class Player
    {
        public int x;
        public int lives {get; set;}
        public bool living = true;

        public string message = " ";

        public Player(int lives )
        {
            this.lives = lives;
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

    public class Enemy : Entity {
        
        public int x;
        public int y;

        public List<Bullet> bullets = new List<Bullet>();
        public Enemy() 
        {
            x = Console.WindowWidth / 2;
            y = 0;
        }
        
        public static void moveEnemyHorizontal(Enemy enemy, Player player) {
            Random random = new Random();
                Action[] actions = {
                () => { enemy.x -= 1; },
                () => { enemy.x += 1; }
                };
            if(enemy.y <= Console.WindowHeight && enemy.x < Console.WindowWidth) {
                if(enemy.x == 0) {
                    enemy.x += 2;
                }
                if (enemy.x == Console.WindowWidth) {
                    enemy.x -= 2; 
                }
                moveEnemyDown(enemy, player);
                actions[random.Next(actions.Length)]();
            } else {
                resetPosition(enemy,player);
            }
        }
        public static void moveShooting(Enemy enemy,Player player){
            Random random = new Random();
            moveEnemyDown(enemy,player);
            if(random.Next(5)==1){
                Shoot(enemy);
            }
        }
        public static void Shoot(Enemy enemy){
            Bullet bullet = new Bullet();
            bullet.x = enemy.x;
            bullet.y = enemy.y;
            enemy.bullets.Add(bullet);
        }
        
    }
    public class Bullet{
        public int x;
        public int y;
    }

    class Program
    {
        public static int beurten = 0;
        static void Main(string[] args)
        {
            Player player = new Player(3);
            Enemy enemy = new Enemy();
            Enemy verticalEnemy = new Enemy();
            Enemy ShootingEnemy = new Enemy();
            
            Console.Clear();
            Console.CursorVisible = false;
            
            while (true)
            {
                Console.SetCursorPosition(0,15);
                Console.Write(player.message);
                printPlayer(player);
                printEnemy(enemy,'E');
                printEnemy(verticalEnemy,'V');
                printEnemy(ShootingEnemy,'S');
                printBullets(ShootingEnemy.bullets);
                System.Threading.Thread.Sleep(50);
                beurten++;
                Console.SetCursorPosition(player.x, Console.WindowHeight);
                Console.Write(" ");
                Console.SetCursorPosition(enemy.x, enemy.y);
                Console.Write(" ");
                Console.SetCursorPosition(verticalEnemy.x, verticalEnemy.y);
                Console.Write(" ");
                Console.SetCursorPosition(ShootingEnemy.x, ShootingEnemy.y);
                Console.Write(" ");
                clearBullets(ShootingEnemy.bullets);
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
                if(beurten%20==0){
                    beurten=1;
                    Enemy.moveShooting(ShootingEnemy,player);
                }
                if(beurten%10==0){
                        Enemy.moveEnemyDown(enemy,player);
                    }
                if(beurten%7==0){
                    Enemy.moveEnemyHorizontal(verticalEnemy,player);
                }
                printBullets(ShootingEnemy.bullets);
            }//end whileloop
        }
        public static void printPlayer(Player player){
            Console.SetCursorPosition(player.x, Console.WindowHeight);
            Console.Write("O");
        }
        public static void clearBullets(List<Bullet> bullets){
            for(int i = 0;i<bullets.Count;i++){
                Console.SetCursorPosition(bullets[i].x, bullets[i].y);
                Console.Write(" ");
            }
        }
        public static void printEnemy(Enemy enemy,char icon){
            Console.SetCursorPosition(enemy.x, enemy.y);
            Console.Write(icon);
        }
        public static void printBullets(List<Bullet> bullets){
            for(int i = 0;i<bullets.Count;i++){
                if(bullets[i].y!=Console.WindowHeight){
                Console.SetCursorPosition(bullets[i].x, bullets[i].y);
                Console.Write('|');
                bullets[i].y+=1;
                }else{
                    //bullets.Remove(i);
                }
            }
        }
    }
}
 
