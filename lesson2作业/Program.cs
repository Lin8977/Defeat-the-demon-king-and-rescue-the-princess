using System.Security.Cryptography;

namespace lesson2作业
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Random r = new Random();
            int monsterHealth = 20;
            int monsterDefense = 10;
            Console.WriteLine($"Monster Health: {monsterHealth}, Monster Defense: {monsterDefense}");
            bool living = true;
            while (living)
            {
                Console.WriteLine("The monster is still alive!,Please attack!,His Health:{0}",monsterHealth);
                char charKey = Console.ReadKey(true).KeyChar;
                if (charKey == 'a' || charKey == 'A')//这里最好不要是按a键，也不要用if
                {
                    int damage = r.Next(8, 12) - monsterDefense;//这里有错误，得不到伤害12，应该是r.Next(8, 13)才对
                    if (damage > 0)
                    {
                        monsterHealth -= damage;
                        Console.WriteLine("Your attack has dealt {0} points of damage, Monster Health: {1}",damage,monsterHealth);
                    }
                    else
                    {
                        Console.WriteLine("Your attack was too weak to penetrate the monster's defense!");
                    }

                }
                else 
                {
                    Console.WriteLine("Error: Invalid input!");
                }
                if(monsterHealth <= 0)
                {
                    living = false;
                    Console.WriteLine("The monster has been defeated!");
                }

            }
        }
    }
}
