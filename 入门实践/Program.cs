using System.ComponentModel.Design;
using System.Runtime.InteropServices;

namespace 入门实践
{

    internal class Program
    {
        static void MoveCursorP(int x, int w)
        {
            switch (x)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(w / 2 - 6, 6);
                    Console.WriteLine("营救公主游戏");
                    Console.SetCursorPosition(w / 2 - 4, 10);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("开始游戏");
                    Console.SetCursorPosition(w / 2 - 4, 12);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("退出游戏");

                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(w / 2 - 6, 6);
                    Console.WriteLine("营救公主游戏");
                    Console.SetCursorPosition(w / 2 - 4, 10);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("开始游戏");
                    Console.SetCursorPosition(w / 2 - 4, 12);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("退出游戏");
                    break;
            }
        }
        static void IfBossPlayer(int[] arr, int bossX, int bossY, ref bool canFight)
        {
            if (arr[0] == bossX - 2 && arr[1] == bossY || arr[0] == bossX + 2 && arr[1] == bossY || arr[0] == bossX && arr[1] == bossY - 1 || arr[0] == bossX && arr[1] == bossY+1)
            {
                canFight = true;
            }
        }
        static void CleanRowWord(int row, int line, int number)
        {
            Console.SetCursorPosition(row,line);
            Console.WriteLine(new string(' ', number));// 伪代码：string 的其中一个构造函数
                               //public string (char c, int count)第一个参数 c（' '）：指定你要用哪个字符来当原料。这里传入的是一个空格字符 ' '。
                               //第二个参数 count：指定你要把这个字符连续重复复制多少次。
        }
        static void HpCheck(ref int Hp) 
        {
            if (Hp<=0)
            {
                Hp = 0;
            }
            return;
        }
        static void Main(string[] args)
        {

            #region 控制台基础设置

            //隐藏光标
            int bufferWidth = 50;
            int bufferHeight = 20;
            int RedWallHeight = bufferHeight - 8;   
            Console.CursorVisible = false;
            Console.SetWindowSize(bufferWidth, bufferHeight); // 设置窗口大小
            Console.SetBufferSize(bufferWidth, bufferHeight); // 设置缓冲区大小

            Console.SetWindowPosition(0, 0);
            int State = 0;
            int CursorP = 0;
            #endregion

            #region boss基础信息
            int bossX = bufferWidth / 2-1;
            int bossY = bufferHeight / 2;
            Random random = new Random();
            int bossMoveStep = random.Next(0,2);
            int bossMovedirection = random.Next(0, 4);
            int bossAtkMin = 7;
            int bossAtkMax = 11;
            int bossAtk = random.Next(bossAtkMin, bossAtkMax + 1);
            int bossHp = 30;
            int bossDef = 5;
            bool canFight = false;
            bool isFight = false;
            ConsoleColor bossColor = ConsoleColor.Green;
            string bossIcon = "▲";
            string bossAlive = "Boss still alive,please fight";

            #endregion

            bool playerLiveFlag = true;
            bool bossLiveFlag = true;
            bool princessSaved = false;

            #region player
            char playerInput;
            int playerX = 2;
            int playerY = 1;
            int playerAtkMin = 8;
            int playerAtkMax = 12;
            int playerAtk = random.Next(playerAtkMin, playerAtkMax + 1);
            int playerHp = 35;
            int playerDef = 5;
            int []arrPlayerPosition = new int[2] {playerX, playerY};


            ConsoleColor playerColor = ConsoleColor.Yellow;
            string playerIcon = "▲";
            #endregion
            #region 公主信息
            int princessX = 20;
            int princessY = 5;
            ConsoleColor princessColor = ConsoleColor.Blue;

            #endregion

            while (true)
            {

                    playerHp = 35;
                    bossHp = 30;

                    switch (State)
                    {
                        case 0:
                            #region 开始界面逻辑
                            Console.Clear();
                            MoveCursorP(CursorP, bufferWidth);
                            char charKey = Console.ReadKey(true).KeyChar;
                            switch (charKey)
                            {
                                case 'W':
                                case 'w':
                                    CursorP = 0;
                                    break;

                                case 's':
                                case 'S':
                                    CursorP = 1;
                                    break;
                                case 'J':
                                case 'j':
                                    if (CursorP == 0)
                                    {
                                        State = 1;
                                    }
                                    else if (CursorP == 1)
                                    {
                                        Environment.Exit(0);
                                    }
                                    break;
                            }
                            #endregion
                            break;

                        case 1:
                            Console.Clear();
                            playerLiveFlag = true;
                            bossLiveFlag = true;
                            princessSaved = false;
                            arrPlayerPosition = new int[] { playerX, playerY };
                            #region 不变的红墙
                            for (int i = 0; i < bufferWidth; i += 2)
                            {
                                Console.SetCursorPosition(i, 0);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("■");
                            }
                            for (int i = 0; i < bufferHeight; i++)
                            {
                                Console.SetCursorPosition(0, i);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("■");
                            }
                            for (int i = 0; i < bufferWidth; i += 2)
                            {
                                Console.SetCursorPosition(i, bufferHeight - 1);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("■");
                            }
                            for (int i = 0; i < bufferHeight; i++)
                            {
                                Console.SetCursorPosition(bufferWidth - 2, i);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("■");
                            }
                            for (int i = 0; i < bufferWidth; i += 2)
                            {
                                Console.SetCursorPosition(i, RedWallHeight);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("■");
                            }
                            #endregion
                            while (true)
                            {
                                //判断怪物、玩家死亡了吗
                                if (playerLiveFlag == false || princessSaved == true)
                                {
                                    State = 2;
                                    break;
                                }

                                #region boss
                                //boss生成
                                if (bossHp > 0)
                                {
                                    Console.SetCursorPosition(bossX, bossY);
                                    Console.ForegroundColor = bossColor;
                                    Console.Write(bossIcon);
                                    //boxx信息
                                    Console.ForegroundColor = ConsoleColor.White;

                                    if (isFight == false)
                                    {
                                        Console.SetCursorPosition(2, RedWallHeight + 1);
                                        Console.Write(bossAlive);
                                        Console.SetCursorPosition(2, RedWallHeight + 2);
                                        Console.Write("Boss Hp is {0}", bossHp);
                                        Console.SetCursorPosition(2, RedWallHeight + 3);
                                        Console.Write("Player Hp is {0}", playerHp);

                                    }

                                }
                                else
                                {
                                    Console.SetCursorPosition(bossX, bossY);
                                    Console.Write("  ");
                                }
                                #endregion
                                #region 公主
                                if (bossLiveFlag == false)
                                {
                                    //公主的显示
                                    Console.SetCursorPosition(princessX, princessY);
                                    Console.ForegroundColor = princessColor;
                                    Console.Write("●");
                                }

                                #endregion
                                #region 玩家移动
                                //玩家生成
                                Console.SetCursorPosition(arrPlayerPosition[0], arrPlayerPosition[1]);
                                Console.ForegroundColor = playerColor;
                                Console.Write(playerIcon);
                                //玩家移动
                                playerInput = Console.ReadKey(true).KeyChar;
                                //擦除玩家当前位置
                                Console.SetCursorPosition(arrPlayerPosition[0], arrPlayerPosition[1]);
                                Console.Write("  ");
                                switch (playerInput)
                                {
                                    case 'a':
                                    case 'A':
                                        canFight = false;
                                        isFight = false;
                                        arrPlayerPosition[0] = arrPlayerPosition[0] - 2;
                                        if (arrPlayerPosition[0] < 2)
                                        {
                                            arrPlayerPosition[0] = 2;
                                        }
                                        if (arrPlayerPosition[0] == bossX && arrPlayerPosition[1] == bossY && bossHp > 0)
                                        {
                                            arrPlayerPosition[0] = arrPlayerPosition[0] + 2;
                                        }
                                        if (arrPlayerPosition[0] == princessX && arrPlayerPosition[1] == princessY && bossHp <= 0)
                                        {
                                            arrPlayerPosition[0] = arrPlayerPosition[0] + 2;
                                        }
                                        break;
                                    case 'd':
                                    case 'D':
                                        canFight = false;
                                        isFight = false;
                                        arrPlayerPosition[0] = arrPlayerPosition[0] + 2;
                                        if (arrPlayerPosition[0] > bufferWidth - 4)
                                        {
                                            arrPlayerPosition[0] = bufferWidth - 4;
                                        }
                                        if (arrPlayerPosition[0] == bossX && arrPlayerPosition[1] == bossY && bossHp > 0)
                                        {
                                            arrPlayerPosition[0] = arrPlayerPosition[0] - 2;
                                        }
                                        if (arrPlayerPosition[0] == princessX && arrPlayerPosition[1] == princessY && bossHp <= 0)
                                        {
                                            arrPlayerPosition[0] = arrPlayerPosition[0] - 2;
                                        }
                                        break;
                                    case 'w':
                                    case 'W':
                                        canFight = false;
                                        isFight = false;
                                        arrPlayerPosition[1] = arrPlayerPosition[1] - 1;
                                        if (arrPlayerPosition[1] < 1)
                                        {
                                            arrPlayerPosition[1] = 1;
                                        }
                                        if (arrPlayerPosition[0] == bossX && arrPlayerPosition[1] == bossY && bossHp > 0)
                                        {
                                            arrPlayerPosition[1] = arrPlayerPosition[1] + 1;
                                        }
                                        if (arrPlayerPosition[0] == princessX && arrPlayerPosition[1] == princessY && bossHp <= 0)
                                        {
                                            arrPlayerPosition[1] = arrPlayerPosition[1] + 1;
                                        }
                                        break;
                                    case 's':
                                    case 'S':
                                        canFight = false;
                                        isFight = false;
                                        arrPlayerPosition[1] = arrPlayerPosition[1] + 1;
                                        if (arrPlayerPosition[1] > RedWallHeight - 1)
                                        {
                                            arrPlayerPosition[1] = RedWallHeight - 1;
                                        }
                                        if (arrPlayerPosition[0] == bossX && arrPlayerPosition[1] == bossY && bossHp > 0)
                                        {
                                            arrPlayerPosition[1] = arrPlayerPosition[1] - 1;
                                        }
                                        if (arrPlayerPosition[0] == princessX && arrPlayerPosition[1] == princessY && bossHp <= 0)
                                        {
                                            arrPlayerPosition[1] = arrPlayerPosition[1] - 1;
                                        }
                                        break;
                                    case 'q':
                                    case 'Q':
                                        IfBossPlayer(arrPlayerPosition, bossX, bossY, ref canFight);
                                        if (canFight == true && bossHp > 0)
                                        {
                                            isFight = true;
                                            //进入战斗
                                            if (isFight == true)
                                            {
                                                CleanRowWord(2, RedWallHeight + 1, bossAlive.Length);
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.SetCursorPosition(2, RedWallHeight + 1);
                                                Console.Write("Fighting!!!!");
                                                #region 战斗
                                                bossAtk = random.Next(bossAtkMin, bossAtkMax + 1);
                                                playerAtk = random.Next(playerAtkMin, playerAtkMax + 1);
                                                if (playerAtk > bossDef)
                                                {
                                                    bossHp = bossHp - (playerAtk - bossDef);
                                                    HpCheck(ref bossHp);//检查血量是否见底
                                                    if (bossHp <= 0)
                                                    {
                                                        bossLiveFlag = false;
                                                        break;
                                                    }
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.SetCursorPosition(2, RedWallHeight + 2);
                                                    CleanRowWord(2, RedWallHeight + 2, 45);
                                                    Console.SetCursorPosition(2, RedWallHeight + 2);
                                                    Console.Write("You dealt {0} damage,boss Hp is {1}", (playerAtk - bossDef), bossHp);
                                                }
                                                else
                                                {
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.SetCursorPosition(2, RedWallHeight + 3);
                                                    CleanRowWord(2, RedWallHeight + 3, 45);
                                                    Console.SetCursorPosition(2, RedWallHeight + 3);
                                                    Console.Write("player dealt 0 damage");
                                                }

                                                if (bossAtk > playerDef)
                                                {
                                                    playerHp = playerHp - (bossAtk - playerDef);
                                                    HpCheck(ref playerHp);//检查血量是否见底
                                                    if (playerHp <= 0)
                                                    {
                                                        playerLiveFlag = false;
                                                        State = 2;
                                                        break;
                                                    }
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.SetCursorPosition(2, RedWallHeight + 3);
                                                    CleanRowWord(2, RedWallHeight + 3, 45);
                                                    Console.SetCursorPosition(2, RedWallHeight + 3);
                                                    Console.Write("boss dealt {0} damage,player Hp is {1}", (bossAtk - playerDef), playerHp);
                                                }
                                                else
                                                {
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.SetCursorPosition(2, RedWallHeight + 3);
                                                    CleanRowWord(2, RedWallHeight + 3, 45);
                                                    Console.SetCursorPosition(2, RedWallHeight + 3);
                                                    Console.Write("boss dealt 0 damage");
                                                }
                                                #endregion
                                            }

                                        }
                                        //判断在公主身边是否按q键
                                        if (bossHp <= 0 && (arrPlayerPosition[0] == princessX && arrPlayerPosition[1] == princessY - 1 || arrPlayerPosition[0] == princessX && arrPlayerPosition[1] == princessY + 1 || arrPlayerPosition[0] == princessX - 2 && arrPlayerPosition[1] == princessY || arrPlayerPosition[0] == princessX + 2 && arrPlayerPosition[1] == princessY))
                                        {
                                            princessSaved = true;
                                            break;
                                        }
                                        break;
                                }
                                #endregion

                            }
                            break;
                        case 2:
                            #region 结束界面
                            Console.Clear();
                            //标题显示
                            Console.SetCursorPosition(10, 6);
                            Console.ForegroundColor = ConsoleColor.White;
                            if (princessSaved == true)
                            {
                                Console.Write("You successfully rescued the princess!!");

                            }
                            else if (playerLiveFlag == false)
                            {
                                Console.Write("You lose!");
                            }
                            int nowEndID = 0;
                            while (true)
                            {
                                bool isQuiteEndWhile = false;
                                Console.SetCursorPosition(10, 7);
                                Console.ForegroundColor = nowEndID == 0 ? ConsoleColor.Red : ConsoleColor.White;
                                Console.Write("回到开始界面");
                                Console.SetCursorPosition(10, 8);
                                Console.ForegroundColor = nowEndID == 1 ? ConsoleColor.Red : ConsoleColor.White;
                                Console.Write("退出游戏");
                                char input = Console.ReadKey(true).KeyChar;
                                switch (input)
                                {
                                    case 'w':
                                    case 'W':
                                        nowEndID = 0;
                                        break;
                                    case 's':
                                    case 'S':
                                        nowEndID = 1;
                                        break;

                                    case 'j':
                                    case 'J':
                                    {
                                        if(nowEndID == 0)
                                        {
                                            State = 0;
                                            isQuiteEndWhile = true;
                                        }
                                        else if (nowEndID == 1)
                                        {
                                            Environment.Exit(0);
                                        }
                                    }
                                        break;
                                }
                                if (isQuiteEndWhile == true)
                                {
                                    break;
                                }
                            }
                            #endregion
                        break;
                    }
            }



        }
    }
}
