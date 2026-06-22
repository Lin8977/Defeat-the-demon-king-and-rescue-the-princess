namespace lesson1控制台相关
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            #region 

            Console.WriteLine("请输入一个字符：");

            char k = Console.ReadKey().KeyChar;

            //补充知识
            //如果在ReadKey(true)则不会把输入的内容显示在控制台上，但是仍然可以获取输入的字符

            Console.WriteLine("请输入一个字符（不会显示在控制台上）：");
            char k2 = Console.ReadKey(true).KeyChar;



            #endregion


            #region 控制台其它方法
            //1.清空控制台

            Console.WriteLine("准备清空控制台...");
            Console.ReadKey();
            Console.Clear();

            //2.设置控制台大小
            //窗口大小 缓冲区大小(显示内容的部分大小)
            //注意：a)要先设置窗口大小，再设置缓冲区大小，否则会抛出异常 b)缓冲区大小不能小于窗口大小 c)设置窗口大小不能大于控制台的最大值
            Console.SetWindowSize(100, 50);
            Console.SetBufferSize(100, 1000);

            //3.设置光标的位置
            //光标位置以左上角为原点，向右为x轴正方向，向下为y轴正方向
            //注意：a)设置光标位置时，坐标必须在窗口范围内，否则会抛出异常 b)光标位置是以字符为单位的，而不是像素 c)横纵距离单位不同 1y=2x 视觉上的!!
            Console.SetCursorPosition(10, 10);
            Console.WriteLine("光标已移动到(10,10)");

            //4.设置颜色相关
            //文字颜色
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(".....");
            Console.ForegroundColor = ConsoleColor.Red;
            //背景颜色
            Console.BackgroundColor = ConsoleColor.White;//这样会只有部分的背景颜色改变，若想要全部改变需要调用Console.Clear()方法来清空控制台，这样就会把背景颜色应用到整个控制台上

            //5.光标的显示与隐藏
            Console.CursorVisible = true;//true 就是显示光标，false就是隐藏光标

            //6.关闭控制台
            Environment.Exit(0);//参数0表示正常退出，非0表示异常退出 //调试模式不会关闭控制台，发布模式会关闭控制台

            #endregion

        }
    }
}
