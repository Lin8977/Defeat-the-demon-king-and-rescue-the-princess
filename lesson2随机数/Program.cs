namespace lesson2随机数
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            #region 知识点一 产生随机数对象

            //产生随机数对象
            //Random 随机数变量名 = new Random();
            Random r = new Random();

            //生成随机数

            //1    用的比较少，因为生成的数比较大
            int i = r.Next();//生成一个非负的随机整数，范围是0到int.MaxValue-1
            Console.WriteLine(i);
            //2
            i = r.Next(100);//生成一个0到99之间的随机整数 左边始终是0，右边是指定的数，左包含右不包含
            Console.WriteLine(i);
            
            //3
            i =r.Next(50, 100);//生成一个50到99之间的随机整数 左包含右不包含
            Console.WriteLine(i);


            //补充知识


            #endregion


        }
    }
}
