namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Console.BackgroundColor = ConsoleColor.Red;
            //Console.Clear();
            //Console.SetCursorPosition(5,10 );
            //Console.BackgroundColor = ConsoleColor.Green;
            //Console.SetCursorPosition(10, 20);
            //Console.BackgroundColor = ConsoleColor.Red;

            int bufferWidth = 50;
            int bufferHeight = 20;
            Console.SetWindowSize(bufferWidth, bufferHeight); // 设置窗口大小
            Console.SetBufferSize(bufferWidth, bufferHeight); // 设置缓冲区大小


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(50, 0);//会报错
            Console.WriteLine("1");


        }
    }
}
