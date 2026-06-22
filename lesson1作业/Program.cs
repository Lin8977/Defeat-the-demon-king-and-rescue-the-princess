namespace lesson1作业
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //通过wasd控制

            //初始化黄色方块位置
            Console.SetWindowSize(100, 50);
            Console.SetBufferSize(100, 50);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            int x = 5;
            int y = 10;
            Console.SetCursorPosition(x, y);

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write("a");
            Console.CursorVisible = false;

            while (true) 
            {



                char charKey = Console.ReadKey().KeyChar;

                switch (charKey) 
                {
                    case 'a':
                        x--;
                        break;
                    case 'd':
                        x++;
                        break;
                    case 'w':
                        y--;
                        break;
                    case 's':
                        y++;
                        break;
                }
                if (x < 0) x = 0;
                if (y < 0) y = 0;
                if (x >100) x = 100;
                if (y >100) y = 100;
                if (x >= 0 && y >= 0)
                {
                    Console.BackgroundColor = ConsoleColor.Red; 
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.Yellow;
                }



            }


        }
    }
}
