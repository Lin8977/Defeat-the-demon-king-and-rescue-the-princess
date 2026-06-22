namespace lesson1作业答案
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //设置控制台大小

            int maxWidth = 100;
            int maxHeight = 50;

            Console.SetWindowSize(maxWidth, maxHeight);
            Console.SetBufferSize(maxWidth, maxHeight);

            //改背景颜色

            Console.BackgroundColor = ConsoleColor.Red;
            Console.Clear();

            //初始化位置
            int x = 5;
            int y = 5;

            //改变字体颜色
            Console.ForegroundColor = ConsoleColor.Yellow;

            //隐藏光标
            Console.CursorVisible = false;

            while (true)
            {

                //第一种方式清空之间的黄色方块
                //Console.Clear();//但这样不好，因为它会导致屏幕闪烁，而且如果有其他内容也会被清空

                Console.SetCursorPosition(x, y);
                Console.Write("■");//需要注意输出后，光标会自动移动到下一个位置（下一个字符）   但这个方块字符的宽度是2个单位

                char charKey = Console.ReadKey(true).KeyChar;//这里使用ReadKey(true)是为了让输入的字符不显示在控制台上，这样就不会干扰到我们绘制的方块了

                Console.SetCursorPosition(x, y);
                Console.Write("  ");//第二种方式清空之前的黄色方块，这样就不会导致屏幕闪烁，而且其他内容也不会被清空
                                    //这里需要注意的是1.绘制的方块是一个宽度为2的字符，所以清空的时候也需要使用两个空格来清空
                                    //2.在清空之前需要先把光标移动到之前方块的位置，否则会清空错误的位置
                                    //3.这段代码应该注意写的位置，这里是在输入之后，然后改变光标位置回到方块位置，进行清楚

                //贯穿整个程序的输入
                switch (charKey)
                {
                    case 'w':
                    case 'W':
                        y = y - 1;
                        if (y < 0)//这里需要加上边界判断，防止方块移动出控制台范围
                        {   
                            y = maxHeight-1;//方块移动出控制台的上边界了，让方块从下边界重新出现
                        }
                        break;
                    case 's':
                    case 'S':
                        y = y + 1;
                        if(y > Console.BufferHeight-1)//BufferHeight是缓冲区的高度，控制台的坐标是从0开始的，所以最大坐标是缓冲区大小-1
                        {
                            y = 0;
                        }
                        break;
                    case 'a':
                    case 'A':
                        x = x - 2;
                        if (x < 0)
                        {
                            x = maxWidth-2;
                        }
                        break;
                    case 'd':
                    case 'D':
                        x = x + 2; //这里x坐标每次移动2个单位，是因为控制台中的字符宽度是1个单位，而我们使用的方块字符宽度是2个单位，所以需要每次移动2个单位才能让方块看起来像是移动了一个位置
                        if (x > Console.BufferWidth-2)//方块是两个字符宽，所以需要减去2，防止方块移动出控制台的右边界
                        {
                            x = 0;
                        }
                        break;
                }



            }


        }
    }
}
