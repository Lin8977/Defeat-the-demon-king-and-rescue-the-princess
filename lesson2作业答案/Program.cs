namespace lesson2作业答案
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            int monsterHealth = 20;
            int monsterDefense = 10;  
            Random rand = new Random();
            int attackDamage = 0;

            while (true) 
            {
                int damage = rand.Next(8, 13) - monsterDefense; // 生成8到12的随机数，包含12
                if (attackDamage > 0)
                {
                    monsterHealth -= damage;
                    Console.WriteLine($"Your attack has dealt {damage} points of damage, Monster Health: {monsterHealth}");
                    if (monsterHealth <= 0) 
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Your attack was too weak to penetrate the monster's defense!");
                }
                Console.WriteLine("请按任意键继续攻击...");
                Console.ReadKey(true); // 等待用户按任意键
                Console.Clear(); // 清屏，准备下一轮攻击

            }
            Console.WriteLine("The monster has been defeated!");


        }
    }
}
