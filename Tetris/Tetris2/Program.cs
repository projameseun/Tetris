using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Tetris
{


    class GameTitle
    {
        GameTitle[,] Title = null;

        GameTitle[] Cover = null; //숨기는곳

        public int num;

        public int zero;

        public int idx1, idx2, idx3, idx4;



        public void Start()
        {
            Random ran = new Random();


            Title = new GameTitle[5, 11];
            Cover = new GameTitle[5];

            for (int i = 0; i < Title.GetLength(0); i++)
            {
                for (int j = 0; j < Title.GetLength(1); j++)
                {
                    Title[i, j] = new GameTitle();
                }
            }

            for (int i = 0; i < Cover.Length; i++)
            {

                Cover[i] = new GameTitle();

            }

            for (int i = 0; i < Title.GetLength(0); i++)
            {
                for (int j = 0; j < Title.GetLength(1); j++)
                {
                    zero = ran.Next(0, 2);

                    Title[i, j].num = zero;
                }
            }

            Title[0, 0].num = 3;
            Title[1, 0].num = 3;
            Title[2, 0].num = 3;
            Title[3, 0].num = 3;
            Title[4, 0].num = 3;


            int start = 1;

            while (start == 1)
            {

                Console.SetCursorPosition(0, 0);


                //숨기는곳 
                for (int i = 0; i < Cover.Length; i++)
                {
                    Console.WriteLine();
                }
                Console.WriteLine("                      T E T R I S");
                Console.WriteLine();

                for (int i = 0; i < Title.GetLength(0); i++)
                {


                    for (int j = 0; j < Title.GetLength(1); j++)
                    {
                        idx1 = ran.Next(0, Title.GetLength(1));
                        idx2 = ran.Next(0, Title.GetLength(1));

                        idx3 = ran.Next(0, Title.GetLength(1));
                        idx4 = ran.Next(0, Title.GetLength(1));


                        if (i == idx1 && j == idx2 && Title[i, j].num != 3)
                        {
                            Console.Write("★");
                        }

                        else if (i == idx3 && j == idx4 && Title[i, j].num != 3)
                        {
                            Console.Write("☆");
                        }



                        else if (Title[i, j].num == 0)
                        {
                            Console.Write("■");
                        }
                        else if (Title[i, j].num == 1)
                        {
                            Console.Write("□");
                        }

                        else if (Title[i, j].num == 3)
                        {
                            Console.Write("\t\t");
                        }


                    }
                    //Console.WriteLine(String.Format("{0}", "1").PadLeft(42 - (21 - ("1".Length / 2))))
                    Console.WriteLine();

                }

                Console.WriteLine();
                Console.Write("           ENTER : START");
                Console.WriteLine("           ESC : EXIT ");
                Console.WriteLine("           Pause : P");
                Console.WriteLine("           DROP DOWN : SPACE");
                Console.WriteLine();
                Console.WriteLine("             ▲          up");
                Console.Write("           ◀");
                Console.WriteLine("  ▶    left/right");
                Console.WriteLine("             ▼         down");



                System.Threading.Thread.Sleep(1000);
                if (Console.KeyAvailable != false)
                {

                    ConsoleKeyInfo cki;


                    cki = Console.ReadKey(true);
                    switch (cki.Key)
                    {

                        case ConsoleKey.Enter:
                            start = 2;
                            break;
                        case ConsoleKey.Escape:
                            System.Environment.Exit(-1);
                            break; ;

                    }

                }
                // Console.ReadLine();


            }



        }


    }

    class GameManager
    {
        public int ch_count = 0;
        //public int idx1, idx2, idx3, idx4, idx5, idx6;

        //블락 위를 눌렀을때종류들
        public int upcnt1, upcnt2, upcnt3, upcnt4, upcnt5, upcnt6, upcnt7;


        /// <summary>
        public int[,] block1 = null; //한줄
        public int[,] block2 = null; // 오른쪽기억
        public int[,] block3 = null; //왼쪽기억
        public int[,] block4 = null; //뻐큐
        public int[,] block5 = null; //네모
        public int[,] block6 = null; //니은
        public int[,] block7 = null; // 니은반대









        /// </summary>


        Random ran = new Random();

        Block[,] block_test = null;


        GameManager[,] MainGame = null;
        GameManager[,] blockxy = null;
        GameManager[,] temp = null;
        public int Map;
        public int num;

        public void Start()
        {

            upcnt1 = 0; upcnt2 = 0; upcnt3 = 0; upcnt4 = 0; upcnt5 = 0; upcnt6 = 0; upcnt7 = 0;
            int Next_Block = ran.Next(1, 8);
            int Level = 10;
            int score = 0;
            int cnt = 1;

            Console.CursorVisible = false;

            int[,] block1 = { { 1, 1, 1, 1 },
                              { 0, 0, 0, 0 },
                              { 0, 0, 0, 0 },
                              { 0, 0, 0, 0 }
                                            };
            int[,] block2 = { { 0, 0, 1, 1 },
                              { 0, 1, 1, 0 },
                              { 0, 0, 0, 0 },
                              { 0, 0, 0, 0 }
                                            };
            int[,] block3 = { { 1, 1, 0, 0 },
                              { 0, 1, 1, 0 },
                              { 0, 0, 0, 0 },
                              { 0, 0, 0, 0 }
                                            };
            int[,] block4 = { { 0, 0, 1, 0 },
                              { 0, 1, 1, 1 },
                              { 0, 0, 0, 0 },
                              { 0, 0, 0, 0 }
                                            };
            int[,] block5 = { { 1, 1, 0, 0 },
                              { 1, 1, 0, 0 },
                              { 0, 0, 0, 0 },
                              { 0, 0, 0, 0 }
                                            };
            int[,] block6 = { { 1, 0, 0, 0 },
                              { 1, 1, 1, 0 },
                              { 0, 0, 0, 0 },
                              { 0, 0, 0, 0 }
                                            };
            int[,] block7 = { { 0, 0, 0, 1 },
                              { 0, 1, 1, 1 },
                              { 0, 0, 0, 0 },
                              { 0, 0, 0, 0 }
                                            };


            //array5 = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };

            MainGame = new GameManager[22, 12];

            GameManager[,] temp = MainGame;

            blockxy = new GameManager[4, 4];

            for (int i = 0; i < MainGame.GetLength(0); i++)
            {
                for (int j = 0; j < MainGame.GetLength(1); j++)
                {
                    MainGame[i, j] = new GameManager();
                }
            }

            for (int i = 0; i < blockxy.GetLength(0); i++)
            {
                for (int j = 0; j < blockxy.GetLength(1); j++)
                {
                    blockxy[i, j] = new GameManager();
                }
            }

            for (int i = 0; i < MainGame.GetLength(0); i++)
            {
                for (int j = 0; j < MainGame.GetLength(1); j++)
                {
                    MainGame[i, j].Map = 0;
                }
            }

            //가로 맨위 블럭
            //for(int i =0; i<1; i++)
            //{
            //    for(int j =0; j<MainGame.GetLength(1); j++)
            //    MainGame[i, j].Map = 1;

            //}
            //가로 맨아래 블럭
            for (int i = 21; i < 22; i++)
            {
                for (int j = 0; j < MainGame.GetLength(1); j++)
                    MainGame[i, j].Map = 1;

            }
            //세로 왼쪽 블럭


            for (int i = 0; i < MainGame.GetLength(0); i++)
                MainGame[i, 0].Map = 1;



            //세로 오른쪽블럭


            for (int i = 0; i < MainGame.GetLength(0); i++)
            {
                int j = 11;
                MainGame[i, j].Map = 1;

            }
            for (int i = 0; i < MainGame.GetLength(0); i++)
            {
                for (int j = 0; j < MainGame.GetLength(1); j++)
                {
                    if (j != 0 || j != 11)
                        continue;
                    if (i != 0 || i != 21)
                        continue;

                    MainGame[i, j].Map = 2;

                }
            }

            while (true)
            {
                //  Exit:

                //내가현재 움직일 블락
                ch_count = Next_Block;
                Next_Block = ran.Next(1, 8);
               // Next_Block = 1;
                //  ch_count++;

                //ch_count = 0;


                // ch_count = 2;
                int X = 0;
                if (ch_count == 1)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (block1[i, j] == 1)
                            {
                                blockxy[X, 0].num = i + 2;
                                blockxy[X, 1].num = j + 3;
                                X++;
                            }


                        }
                    }
                }

                else if (ch_count == 2)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (block2[i, j] == 1)
                            {
                                blockxy[X, 0].num = i + 1;
                                blockxy[X, 1].num = j + 3;
                                X++;
                            }


                        }
                    }
                }
                else if (ch_count == 3)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (block3[i, j] == 1)
                            {
                                blockxy[X, 0].num = i + 1;
                                blockxy[X, 1].num = j + 3;
                                X++;
                            }


                        }
                    }
                }
                else if (ch_count == 4)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (block4[i, j] == 1)
                            {
                                blockxy[X, 0].num = i + 1;
                                blockxy[X, 1].num = j + 3;
                                X++;
                            }


                        }
                    }
                }
                else if (ch_count == 5)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (block5[i, j] == 1)
                            {
                                blockxy[X, 0].num = i + 1;
                                blockxy[X, 1].num = j + 3;
                                X++;
                            }


                        }
                    }
                }
                else if (ch_count == 6)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (block6[i, j] == 1)
                            {
                                blockxy[X, 0].num = i + 1;
                                blockxy[X, 1].num = j + 3;
                                X++;
                            }


                        }
                    }
                }
                else if (ch_count == 7)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (block7[i, j] == 1)
                            {
                                blockxy[X, 0].num = i + 1;
                                blockxy[X, 1].num = j + 3;
                                X++;
                            }


                        }
                    }
                }


                //Console.ReadLine();

                if (score / 300 == cnt && score != 0)
                {
                    Level++;
                    cnt++;
                }

                //게임업데이트
                while (true)
                {

              

                    Console.SetCursorPosition(0, 0);





                    for (int i = 0; i < MainGame.GetLength(0); i++)
                    {

                        for (int j = 0; j < MainGame.GetLength(1); j++)
                        {
                            int ch = 0;
                            for (X = 0; X < 4; X++)
                            {
                                if (blockxy[X, 0].num == i && blockxy[X, 1].num == j)
                                {
                                    Console.Write("■");
                                    ch++;
                                }
                            }

                            if (ch != 0)
                                continue;


                            if (MainGame[i, j].Map == 1)
                            {
                                Console.Write("■");
                            }



                            else if (temp[i, j].Map == 3) //블락채워지는곧
                            {
                                Console.Write("□");
                            }
                            else if (MainGame[i, j].Map == 0)
                            {
                                Console.Write("  ");
                            }



                        }

                        Console.WriteLine();



                    }


                    Console.SetCursorPosition(MainGame.GetLength(1) * 2, 2);

                    Console.Write("\t    NEXT");
                    Console.SetCursorPosition(MainGame.GetLength(1) * 2, 4);
                    Console.Write("      ▲▲▲▲▲▲▲▲");
                    Console.SetCursorPosition(MainGame.GetLength(1) * 2, 5);
                    Console.Write("    ◀                ▶");
                    Console.SetCursorPosition(MainGame.GetLength(1) * 2, 6);
                    Console.Write("    ◀                ▶");
                    Console.SetCursorPosition(MainGame.GetLength(1) * 2, 7);
                    Console.Write("    ◀                ▶");
                    Console.SetCursorPosition(MainGame.GetLength(1) * 2, 8);
                    Console.Write("    ◀                ▶");
                    Console.SetCursorPosition(MainGame.GetLength(1) * 2, 9);
                    Console.Write("    ◀                ▶");
                    Console.SetCursorPosition(MainGame.GetLength(1) * 2, 10);
                    Console.Write("      ▼▼▼▼▼▼▼▼");


                    Console.SetCursorPosition(MainGame.GetLength(1) * 2, 12);
                    Console.Write("    SCORE : " + score + "  LEVEL : " + Level );
                    Console.SetCursorPosition(MainGame.GetLength(1) * 2, 16);
                    Console.Write("    ESC : EXIT ");
                    Console.SetCursorPosition(MainGame.GetLength(1) * 2, 17);
                    Console.Write("    Pause : P");
                    Console.SetCursorPosition(MainGame.GetLength(1) * 2, 18);
                    Console.Write("    DROP DOWN : SPACE");
                    Console.SetCursorPosition(MainGame.GetLength(1) * 2, 20);
                    Console.Write("       ▲          up");
                    Console.SetCursorPosition(MainGame.GetLength(1) * 2, 21);
                    Console.Write("     ◀  ▶    left/right");
                    Console.SetCursorPosition(MainGame.GetLength(1) * 2, 22);
                    Console.Write("       ▼         down");




                    if (Next_Block == 1)
                    {
                        for (int i = 0; i < 4; i++)
                            for (int j = 0; j < 4; j++)
                                if (block1[i, j] == 1)
                                {
                                    Console.SetCursorPosition(MainGame.GetLength(1) * 2 + 10 + j * 2, 7 + i);
                                    Console.Write("■");
                                }
                    }

                    else if (Next_Block == 2)
                    {
                        for (int i = 0; i < 4; i++)
                            for (int j = 0; j < 4; j++)
                                if (block2[i, j] == 1)
                                {
                                    Console.SetCursorPosition(MainGame.GetLength(1) * 2 + 10 + j * 2, 7 + i);
                                    Console.Write("■");
                                }
                    }
                    else if (Next_Block == 3)
                    {
                        for (int i = 0; i < 4; i++)
                            for (int j = 0; j < 4; j++)
                                if (block3[i, j] == 1)
                                {
                                    Console.SetCursorPosition(MainGame.GetLength(1) * 2 + 10 + j * 2, 7 + i);
                                    Console.Write("■");
                                }
                    }
                    else if (Next_Block == 4)
                    {
                        for (int i = 0; i < 4; i++)
                            for (int j = 0; j < 4; j++)
                                if (block4[i, j] == 1)
                                {
                                    Console.SetCursorPosition(MainGame.GetLength(1) * 2 + 10 + j * 2, 7 + i);
                                    Console.Write("■");
                                }
                    }
                    else if (Next_Block == 5)
                    {
                        for (int i = 0; i < 4; i++)
                            for (int j = 0; j < 4; j++)
                                if (block5[i, j] == 1)
                                {
                                    Console.SetCursorPosition(MainGame.GetLength(1) * 2 + 10 + j * 2, 7 + i);
                                    Console.Write("■");
                                }
                    }
                    else if (Next_Block == 6)
                    {
                        for (int i = 0; i < 4; i++)
                            for (int j = 0; j < 4; j++)
                                if (block6[i, j] == 1)
                                {
                                    Console.SetCursorPosition(MainGame.GetLength(1) * 2 + 10 + j * 2, 7 + i);
                                    Console.Write("■");
                                }
                    }
                    else if (Next_Block == 7)
                    {
                        for (int i = 0; i < 4; i++)
                            for (int j = 0; j < 4; j++)
                                if (block7[i, j] == 1)
                                {
                                    Console.SetCursorPosition(MainGame.GetLength(1) * 2 + 10 + j * 2, 7 + i);
                                    Console.Write("■");
                                }
                    }

                    if (Console.KeyAvailable != false)
                    {


                        ConsoleKeyInfo cki;

                        int Xcheck = 0;
                        int xupcnt = 3;
                        int yupcnt = 3;

                        cki = Console.ReadKey(true);
                        switch (cki.Key)
                        {

                            case ConsoleKey.RightArrow:
                                Console.SetCursorPosition(MainGame.GetLength(1) * 2, 21);
                                Console.Write("     ◀  ▷    left/right");
                                Thread.Sleep(33);

                                for (X = 0; X < 4; X++)
                                {
                                    int i = blockxy[X, 0].num;
                                    int j = blockxy[X, 1].num;
                                    if (MainGame[i, j + 1].Map == 1 || temp[i, j + 1].Map == 3)
                                        Xcheck = 1;
                                }

                                if (Xcheck == 0)
                                    for (X = 0; X < 4; X++)
                                        blockxy[X, 1].num++;
                                break;
                            case ConsoleKey.LeftArrow:
                                Console.SetCursorPosition(MainGame.GetLength(1) * 2, 21);
                                Console.Write("     ◁  ▶    left/right");
                                Thread.Sleep(33);

                                for (X = 0; X < 4; X++)
                                {
                                    int i = blockxy[X, 0].num;
                                    int j = blockxy[X, 1].num;
                                    if (MainGame[i, j - 1].Map == 1 || temp[i, j - 1].Map == 3)
                                        Xcheck = 1;
                                }

                                if (Xcheck == 0)
                                    for (X = 0; X < 4; X++)
                                        blockxy[X, 1].num--;
                                break;
                            case ConsoleKey.UpArrow:

                                Console.SetCursorPosition(MainGame.GetLength(1) * 2, 20);
                                Console.Write("       △          up");
                                Thread.Sleep(33);




                                if (ch_count == 1)
                                {

                                    if (upcnt1 == 0)
                                    {

                                        for (X = 0; X < 4; X++)
                                        {
                                            if (X == 0)
                                            {
                                                xupcnt = 3;
                                                yupcnt = 3;

                                                blockxy[X, 0].num -= xupcnt;
                                                blockxy[X, 1].num += yupcnt;
                                            }
                                            else if (X == 1)
                                            {
                                                xupcnt = 2;
                                                yupcnt = 2;

                                                blockxy[X, 0].num -= xupcnt;
                                                blockxy[X, 1].num += yupcnt;
                                            }
                                            else if (X == 2)
                                            {
                                                xupcnt = 1;
                                                yupcnt = 1;

                                                blockxy[X, 0].num -= xupcnt;
                                                blockxy[X, 1].num += yupcnt;
                                            }



                                        }
                                        upcnt1 = 1; //다음단게로

                                    }
                                    else if (upcnt1 == 1)
                                    {

                                        for (X = 0; X < 4; X++)
                                        {
                                            if (X == 0)
                                            {
                                                xupcnt = 3;
                                                yupcnt = 3;

                                                blockxy[X, 0].num += xupcnt;
                                                blockxy[X, 1].num -= yupcnt;

                                            }

                                            else if (X == 1)
                                            {
                                                xupcnt = 2;
                                                yupcnt = 2;

                                                blockxy[X, 0].num += xupcnt;
                                                blockxy[X, 1].num -= yupcnt;

                                            }

                                            else if (X == 2)
                                            {
                                                xupcnt = 1;
                                                yupcnt = 1;

                                                blockxy[X, 0].num += xupcnt;
                                                blockxy[X, 1].num -= yupcnt;
                                            }

                                        }
                                        upcnt1 = 0;


                                    }


                                }

                                else if (ch_count == 2)//start 2
                                {

                                    if (upcnt2 == 0)
                                    {
                                        for (X = 0; X < 4; X++)
                                        {
                                            if (X == 0)
                                            {
                                                xupcnt = 1;
                                                yupcnt = 1;
                                                blockxy[X, 0].num += xupcnt;
                                                blockxy[X, 1].num -= yupcnt;


                                            }
                                            else if (X == 1)
                                            {

                                                yupcnt = 2;
                                                blockxy[X, 1].num -= yupcnt;
                                            }
                                            else if (X == 2)
                                            {
                                                xupcnt = 1;
                                                yupcnt = 1;
                                                blockxy[X, 0].num += xupcnt;
                                                blockxy[X, 1].num += yupcnt;
                                            }



                                        }
                                        upcnt2 = 1; //다음단게로

                                    }
                                    else if (upcnt2 == 1)
                                    {


                                        for (X = 0; X < 4; X++)
                                        {
                                            if (X == 0)
                                            {

                                                xupcnt = 1;
                                                yupcnt = 1;

                                                blockxy[X, 0].num -= xupcnt;
                                                blockxy[X, 1].num += yupcnt;


                                            }
                                            else if (X == 1)
                                            {

                                                yupcnt = 2;

                                                blockxy[X, 1].num += yupcnt;
                                            }
                                            else if (X == 2)
                                            {
                                                xupcnt = 1;
                                                yupcnt = 1;
                                                blockxy[X, 0].num -= xupcnt;
                                                blockxy[X, 1].num -= yupcnt;
                                            }


                                        }

                                        upcnt2 = 0;


                                    }
                                }
                                else if (ch_count == 3)  //3 start
                                {


                                    if (upcnt3 == 0)
                                    {
                                        for (X = 0; X < 4; X++)
                                        {
                                            if (X == 0)
                                            {

                                                yupcnt = 2;
                                                blockxy[X, 1].num += yupcnt;


                                            }
                                            else if (X == 1)
                                            {
                                                xupcnt = 1;
                                                yupcnt = 1;
                                                blockxy[X, 0].num += xupcnt;
                                                blockxy[X, 1].num += yupcnt;
                                            }
                                            else if (X == 3)
                                            {
                                                xupcnt = 1;
                                                yupcnt = 1;
                                                blockxy[X, 0].num += xupcnt;
                                                blockxy[X, 1].num -= yupcnt;
                                            }



                                        }
                                        upcnt3 = 1; //다음단게로
                                    }


                                    else if (upcnt3 == 1)
                                    {
                                        for (X = 0; X < 4; X++)
                                        {
                                            if (X == 0)
                                            {
                                                yupcnt = 2;
                                                blockxy[X, 1].num -= yupcnt;


                                            }
                                            else if (X == 1)
                                            {
                                                xupcnt = 1;
                                                yupcnt = 1;
                                                blockxy[X, 0].num -= xupcnt;
                                                blockxy[X, 1].num -= yupcnt;
                                            }
                                            else if (X == 3)
                                            {
                                                xupcnt = 1;
                                                yupcnt = 1;
                                                blockxy[X, 0].num -= xupcnt;
                                                blockxy[X, 1].num += yupcnt;
                                            }



                                        }
                                        upcnt3 = 0; //다음단게로
                                    }


                                } //3 last
                                else if (ch_count == 4)  //start 4
                                {

                                    if (upcnt4 == 0)
                                    {
                                        for (X = 0; X < 4; X++)
                                        {
                                            if (X == 0)
                                            {

                                                xupcnt = 1;
                                                yupcnt = 1;
                                                blockxy[X, 0].num += xupcnt;
                                                blockxy[X, 1].num += yupcnt;


                                            }
                                            else if (X == 1)
                                            {
                                                xupcnt = 1;
                                                yupcnt = 1;
                                                blockxy[X, 0].num -= xupcnt;
                                                blockxy[X, 1].num += yupcnt;
                                            }
                                            else if (X == 3)
                                            {
                                                xupcnt = 1;
                                                yupcnt = 1;
                                                blockxy[X, 0].num += xupcnt;
                                                blockxy[X, 1].num -= yupcnt;
                                            }



                                        }
                                        upcnt4 = 1; //다음단게로
                                    }


                                    else if (upcnt4 == 1)
                                    {

                                        for (X = 0; X < 4; X++)
                                        {
                                            if (X == 0)
                                            {
                                                xupcnt = 1;
                                                yupcnt = 1;

                                                blockxy[X, 0].num += xupcnt;
                                                blockxy[X, 1].num -= yupcnt;


                                            }
                                            else if (X == 1)
                                            {
                                                xupcnt = 1;
                                                yupcnt = 1;
                                                blockxy[X, 0].num += xupcnt;
                                                blockxy[X, 1].num += yupcnt;
                                            }
                                            else if (X == 3)
                                            {
                                                xupcnt = 1;
                                                yupcnt = 1;
                                                blockxy[X, 0].num -= xupcnt;
                                                blockxy[X, 1].num -= yupcnt;
                                            }



                                        }
                                        upcnt4 = 2; //다음단게로


                                    }

                                    else if (upcnt4 == 2)
                                    {

                                        for (X = 0; X < 4; X++)
                                        {
                                            if (X == 0)
                                            {
                                                xupcnt = 1;
                                                yupcnt = 1;

                                                blockxy[X, 0].num -= xupcnt;
                                                blockxy[X, 1].num -= yupcnt;


                                            }
                                            else if (X == 1)
                                            {
                                                xupcnt = 1;
                                                yupcnt = 1;
                                                blockxy[X, 0].num += xupcnt;
                                                blockxy[X, 1].num -= yupcnt;
                                            }
                                            else if (X == 3)
                                            {
                                                xupcnt = 1;
                                                yupcnt = 1;
                                                blockxy[X, 0].num -= xupcnt;
                                                blockxy[X, 1].num += yupcnt;
                                            }



                                        }
                                        upcnt4 = 3; //다음단게로
                                    }

                                    else if (upcnt4 == 3)
                                    {

                                        for (X = 0; X < 4; X++)
                                        {
                                            if (X == 0)
                                            {
                                                xupcnt = 1;
                                                yupcnt = 1;

                                                blockxy[X, 0].num -= xupcnt;
                                                blockxy[X, 1].num += yupcnt;


                                            }
                                            else if (X == 1)
                                            {
                                                xupcnt = 1;
                                                yupcnt = 1;
                                                blockxy[X, 0].num -= xupcnt;
                                                blockxy[X, 1].num -= yupcnt;
                                            }
                                            else if (X == 3)
                                            {
                                                xupcnt = 1;
                                                yupcnt = 1;
                                                blockxy[X, 0].num += xupcnt;
                                                blockxy[X, 1].num += yupcnt;
                                            }



                                        }
                                        upcnt4 = 0; //다음단게로
                                    }





                                } //last 4

                                else if (ch_count == 6)  //start
                                {

                                    if (upcnt6 == 0)
                                    {
                                        for (X = 0; X < 4; X++)
                                        {
                                            if (X == 0)
                                            {

                                                xupcnt = 1;
                                                yupcnt = 1;
                                                blockxy[X, 0].num += xupcnt;
                                                blockxy[X, 1].num += yupcnt;


                                            }
                                            else if (X == 2)
                                            {
                                                xupcnt = 1;
                                                yupcnt = 1;
                                                blockxy[X, 0].num += xupcnt;
                                                blockxy[X, 1].num -= yupcnt;
                                            }
                                            else if (X == 3)
                                            {
                                                xupcnt = 2;
                                                yupcnt = 2;
                                                blockxy[X, 0].num += xupcnt;
                                                blockxy[X, 1].num -= yupcnt;
                                            }



                                        }
                                        upcnt6 = 1; //다음단게로
                                    }


                                    else if (upcnt6 == 1)
                                    {


                                        for (X = 0; X < 4; X++)
                                        {
                                            if (X == 0)
                                            {
                                                xupcnt = 1;
                                                yupcnt = 1;

                                                blockxy[X, 0].num += xupcnt;
                                                blockxy[X, 1].num -= yupcnt;


                                            }
                                            else if (X == 2)
                                            {
                                                xupcnt = 1;
                                                yupcnt = 1;
                                                blockxy[X, 0].num -= xupcnt;
                                                blockxy[X, 1].num -= yupcnt;
                                            }
                                            else if (X == 3)
                                            {
                                                xupcnt = 2;
                                                yupcnt = 2;
                                                blockxy[X, 0].num -= xupcnt;
                                                blockxy[X, 1].num -= yupcnt;
                                            }



                                        }
                                        upcnt6 = 2; //다음단게로


                                    }

                                    else if (upcnt6 == 2)
                                    {

                                        for (X = 0; X < 4; X++)
                                        {
                                            if (X == 0)
                                            {
                                                xupcnt = 1;
                                                yupcnt = 1;

                                                blockxy[X, 0].num -= xupcnt;
                                                blockxy[X, 1].num -= yupcnt;


                                            }
                                            else if (X == 2)
                                            {
                                                xupcnt = 1;
                                                yupcnt = 1;
                                                blockxy[X, 0].num -= xupcnt;
                                                blockxy[X, 1].num += yupcnt;
                                            }
                                            else if (X == 3)
                                            {
                                                xupcnt = 2;
                                                yupcnt = 2;
                                                blockxy[X, 0].num -= xupcnt;
                                                blockxy[X, 1].num += yupcnt;
                                            }



                                        }
                                        upcnt6 = 3; //다음단게로
                                    }

                                    else if (upcnt6 == 3)
                                    {

                                        for (X = 0; X < 4; X++)
                                        {
                                            if (X == 0)
                                            {
                                                xupcnt = 1;
                                                yupcnt = 1;

                                                blockxy[X, 0].num -= xupcnt;
                                                blockxy[X, 1].num += yupcnt;


                                            }
                                            else if (X == 2)
                                            {
                                                xupcnt = 1;
                                                yupcnt = 1;
                                                blockxy[X, 0].num += xupcnt;
                                                blockxy[X, 1].num += yupcnt;
                                            }
                                            else if (X == 3)
                                            {
                                                xupcnt = 2;
                                                yupcnt = 2;
                                                blockxy[X, 0].num += xupcnt;
                                                blockxy[X, 1].num += yupcnt;
                                            }



                                        }
                                        upcnt6 = 0; //다음단게로
                                    }

                                } // last 6 
                                else if (ch_count == 7) //start 7
                                {


                                    if (upcnt7 == 0)
                                    {
                                        for (X = 0; X < 4; X++)
                                        {
                                            if (X == 0)
                                            {

                                                xupcnt = 1;
                                                yupcnt = 1;

                                                blockxy[X, 0].num += xupcnt;
                                                blockxy[X, 1].num += yupcnt;


                                            }
                                            else if (X == 1)
                                            {
                                                xupcnt = 2;
                                                yupcnt = 2;
                                                blockxy[X, 0].num -= xupcnt;
                                                blockxy[X, 1].num += yupcnt;
                                            }
                                            else if (X == 2)
                                            {
                                                xupcnt = 1;
                                                yupcnt = 1;
                                                blockxy[X, 0].num -= xupcnt;
                                                blockxy[X, 1].num += yupcnt;
                                            }



                                        }
                                        upcnt7 = 1; //다음단게로
                                    }


                                    else if (upcnt7 == 1)
                                    {

                                        for (X = 0; X < 4; X++)
                                        {
                                            if (X == 0)
                                            {
                                                xupcnt = 1;
                                                yupcnt = 1;

                                                blockxy[X, 0].num += xupcnt;
                                                blockxy[X, 1].num -= yupcnt;


                                            }
                                            else if (X == 1)
                                            {
                                                xupcnt = 2;
                                                yupcnt = 2;
                                                blockxy[X, 0].num += xupcnt;
                                                blockxy[X, 1].num += yupcnt;
                                            }
                                            else if (X == 2)
                                            {
                                                xupcnt = 1;
                                                yupcnt = 1;
                                                blockxy[X, 0].num += xupcnt;
                                                blockxy[X, 1].num += yupcnt;
                                            }



                                        }
                                        upcnt7 = 2; //다음단게로
                                    }

                                    else if (upcnt7 == 2)
                                    {

                                        for (X = 0; X < 4; X++)
                                        {
                                            if (X == 0)
                                            {
                                                xupcnt = 1;
                                                yupcnt = 1;

                                                blockxy[X, 0].num -= xupcnt;
                                                blockxy[X, 1].num -= yupcnt;


                                            }
                                            else if (X == 1)
                                            {
                                                xupcnt = 2;
                                                yupcnt = 2;
                                                blockxy[X, 0].num += xupcnt;
                                                blockxy[X, 1].num -= yupcnt;
                                            }
                                            else if (X == 2)
                                            {
                                                xupcnt = 1;
                                                yupcnt = 1;
                                                blockxy[X, 0].num += xupcnt;
                                                blockxy[X, 1].num -= yupcnt;
                                            }



                                        }
                                        upcnt7 = 3; //다음단게로
                                    }

                                    else if (upcnt7 == 3)
                                    {

                                        for (X = 0; X < 4; X++)
                                        {
                                            if (X == 0)
                                            {
                                                xupcnt = 1;
                                                yupcnt = 1;

                                                blockxy[X, 0].num -= xupcnt;
                                                blockxy[X, 1].num += yupcnt;


                                            }
                                            else if (X == 1)
                                            {
                                                xupcnt = 2;
                                                yupcnt = 2;
                                                blockxy[X, 0].num -= xupcnt;
                                                blockxy[X, 1].num -= yupcnt;
                                            }
                                            else if (X == 2)
                                            {
                                                xupcnt = 1;
                                                yupcnt = 1;
                                                blockxy[X, 0].num -= xupcnt;
                                                blockxy[X, 1].num -= yupcnt;
                                            }



                                        }
                                        upcnt7 = 0; //다음단게로
                                    }

                                }

                            XUnder:
                                for (int i = 0; i < 4; i++)
                                {
                                    if (blockxy[i, 1].num <= 0)
                                    {
                                        for (int j = 0; j < 4; j++)
                                        {
                                            blockxy[j, 1].num++;

                                        }
                                        goto XUnder;
                                    }

                                }

                            X2Under:
                                for (int i = 0; i < 4; i++)
                                {
                                    if (blockxy[i, 1].num >= 11)
                                    {
                                        for (int j = 0; j < 4; j++)
                                        {
                                            blockxy[j, 1].num--;

                                        }
                                        goto X2Under;
                                    }

                                }






                                break;

                            case ConsoleKey.DownArrow:
                                Console.SetCursorPosition(MainGame.GetLength(1) * 2, 22);
                                Console.Write("       ▽         down");
                                Thread.Sleep(33);

                                for (X = 0; X < 4; X++)
                                {
                                    int i = blockxy[X, 0].num;
                                    int j = blockxy[X, 1].num;
                                    if (MainGame[i + 1, j].Map == 1 || temp[i + 1, j].Map == 3)
                                        Xcheck = 1;
                                }

                                if (Xcheck == 0)
                                    for (X = 0; X < 4; X++)
                                        blockxy[X, 0].num++;

                                break;
                            case ConsoleKey.Spacebar:
                                while (true)
                                {
                                    Xcheck = 0;
                                    for (X = 0; X < 4; X++)
                                    {
                                        int i = blockxy[X, 0].num;
                                        int j = blockxy[X, 1].num;
                                        if (MainGame[i + 1, j].Map == 1 || temp[i + 1, j].Map == 3)
                                            Xcheck = 1;
                                    }

                                    if (Xcheck == 0)
                                        for (X = 0; X < 4; X++)
                                            blockxy[X, 0].num++;

                                    else
                                    {
                                        for (X = 0; X < 4; X++)
                                        {
                                            int i = blockxy[X, 0].num;
                                            int j = blockxy[X, 1].num;
                                            MainGame[i, j].Map = 3;
                                            // ch_count = 0;
                                            upcnt1 = 0; upcnt2 = 0; upcnt3 = 0; upcnt4 = 0; upcnt5 = 0; upcnt6 = 0; upcnt7 = 0; //초기화

                                        }
                                        goto Exit;
                                    }
                                }
                            Exit:
                                break;
                            case ConsoleKey.Escape:
                                System.Environment.Exit(-1);
                                break; ;
                            case ConsoleKey.P:
                                Console.SetCursorPosition(3 * 2, 9);
                                Console.Write("┌────┐");
                                Console.SetCursorPosition(3*2,10);
                                Console.Write("│  PAUSE │");
                                Console.SetCursorPosition(3 * 2, 11);
                                Console.Write("└────┘");


                                Console.ReadKey();
                                break;

                        }
                    }



                    else
                    {


                        int Xcheck = 0;
                        for (X = 0; X < 4; X++)
                        {
                            int i = blockxy[X, 0].num;
                            int j = blockxy[X, 1].num;
                            if (MainGame[i + 1, j].Map == 1 || temp[i + 1, j].Map == 3)
                                Xcheck = 1;
                        }

                        if (Xcheck == 0)
                            for (X = 0; X < 4; X++)
                                blockxy[X, 0].num++;

                        else
                        {




                            for (X = 0; X < 4; X++)
                            {
                                int i = blockxy[X, 0].num;
                                int j = blockxy[X, 1].num;
                                temp[i, j].Map = 3;
                                //  ch_count = 0;
                                upcnt1 = 0; upcnt2 = 0; upcnt3 = 0; upcnt4 = 0; upcnt5 = 0; upcnt6 = 0; upcnt7 = 0; //reset


                            }

                            int scount = 0;
                            int exitcount = 0;

                            int idx = 0;

                            for (int i = 0; i < MainGame.GetLength(0); i++)
                            {
                                scount = 0;
                                for (int j = 0; j < MainGame.GetLength(1); j++)
                                {
                                    if (MainGame[i, j].Map == 3)
                                    {
                                        scount++;
                                    }
                                }


                                if (scount == 10)
                                {
                                    for (int j = 1; j < MainGame.GetLength(1) - 1; j++)
                                    {
                                        MainGame[i, j].Map = 0;
                                        idx = i;
                                        
                                    }



                                    for (int k = idx - 1; k > 1; k--)
                                    {

                                        for (int l = 1; l < MainGame.GetLength(1) - 1; l++)
                                        {




                                            MainGame[k + 1, l].Map = temp[k, l].Map;


                                        }


                                    }
                                    score += 100;
                                }




                            }

                            break;
                        }



                        //blockxy[0,0] = 0 -> 1
                        //blockxy[1,0] = 0 -> 1
                        //blockxy[2,0] = 1 -> 2
                        //blockxy[3,0] = 1 -> 2
                        

                        if(Level == 30)
                        {
                            Console.WriteLine("WIn !!!");
                            Console.ReadKey();
                            System.Environment.Exit(-1);
                        }

                        System.Threading.Thread.Sleep(300 - Level * 10);
                    }


                }//while last

            }


        }
    }

    class Block
    {
        //7개블락 

        public int[,] block1 = null; //한줄
        public int[,] block2 = null; // 오른쪽기억
        public int[,] block3 = null; //왼쪽기억
        public int[,] block4 = null; //뻐큐
        public int[,] block5 = null; //네모
        public int[,] block6 = null; //니은
        public int[,] block7 = null; // 니은반대

        public int num;





    }


    class Program
    {
        static void Main(string[] args)
        {
            GameTitle title = new GameTitle();
            GameManager manager = new GameManager();
            Block block = new Block();

            //  block.Start();
            title.Start();

            Console.Clear(); //enter 누르면 들어옴

            manager.Start();

            Console.ReadLine();


        }
    }
}