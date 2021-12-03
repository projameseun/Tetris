using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

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

            for(int i=0; i<Title.GetLength(0); i++)
            {
                for(int j=0; j<Title.GetLength(1); j++)
                {
                    Title[i, j] = new GameTitle();
                }
            }

            for (int i = 0; i < Cover.Length; i++)
            {
                
                    Cover[i] = new GameTitle();
                
            }

            for (int i =0; i<Title.GetLength(0); i++)
            {
                for(int j=0; j<Title.GetLength(1); j++)
                {
                   zero = ran.Next(0,2);

                    Title[i, j].num = zero;
                }
            }

            Title[0,0].num = 3;
            Title[1,0].num = 3;
            Title[2,0].num = 3;
            Title[3,0].num = 3;
            Title[4,0].num = 3;


            int start = 1;

            while (start ==1)
            {

                Console.SetCursorPosition(0, 0);


                //숨기는곳 
                for (int i =0; i<Cover.Length; i++)
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


                        if (i == idx1 && j == idx2 && Title[i,j].num != 3)
                        {
                            Console.Write("★");
                        }

                        else if (i == idx3 && j == idx4 && Title[i, j].num != 3)
                        {
                            Console.Write("☆");
                        }

                      

                        else if (Title[i,j].num == 0)
                        {
                            Console.Write("■");
                        }
                        else if(Title[i,j].num == 1)
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
                Console.WriteLine("           ESC : EXIT " );
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
        public int idx1, idx2, idx3, idx4, idx5, idx6;




        /// <summary>
        public int[,] block1 = null; //한줄
        public int[,] block2 = null; // 오른쪽기억
        public int[,] block3 = null; //왼쪽기억
        public int[,] block4 = null; //뻐큐
        public int[,] block5 = null; //네모
        public int[,] block6 = null; //니은
        public int[,] block7 = null; // 니은반대

        public int num;

       
        
           

        

        /// </summary>


        Random ran = new Random();

        Block[,] block_test = null;


        GameManager[,] MainGame = null;
        GameManager[,] temp = null;
        public int Map;

        public void Start()
        {
            //array5 = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };

            MainGame = new GameManager[22, 12];

            GameManager[,] temp = MainGame;

     

            for (int i =0; i<MainGame.GetLength(0); i++)
            {
                for(int j =0; j<MainGame.GetLength(1); j++)
                {
                    MainGame[i, j] = new GameManager();

                    temp[i, j] = new GameManager();
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
            for (int i = 21; i <22 ; i++)
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
    while(true)
            {

                idx1 = 0; //초기화
                idx2 = 0;
                idx3 = 0;
                idx4 = 0;
                idx5 = 0;
                idx6 = 0;


                ch_count = ran.Next(1, 8);

            ch_count = 1;
            
           // ch_count = 2;
            
            if(ch_count == 1)
            {
                MainGame[0, 4].Map = 2;
                MainGame[0, 5].Map = 2;
                MainGame[0, 6].Map = 2;
                MainGame[0, 7].Map = 2;

                idx1 = 0;

                idx2 = 4;
                idx3 = 5;
                idx4 = 6;
                idx5 = 7;

            }

                else if (ch_count == 2)
                {
                    MainGame[0, 4].Map = 2;
                    MainGame[0, 5].Map = 2;
                    MainGame[1, 4].Map = 2;
                    MainGame[1, 5].Map = 2;

                    idx1 = 0;

                    idx2 = 1;
                    idx3 = 4;
                    idx4 = 5;
                    //idx5 = 7;

                }
            else if(ch_count == 3)
                {
                    MainGame[0, 4].Map = 2;
                    MainGame[0, 5].Map = 2;
                    MainGame[1, 4].Map = 2;
                    MainGame[1, 3].Map = 2;

                    idx1 = 0;
                    idx2 = 1;
                    idx3 = 4;
                    idx4 = 5;
                    idx5 = 3;

                }
                else if (ch_count == 4)
                {
                    MainGame[0, 3].Map = 2;
                    MainGame[0, 4].Map = 2;
                    MainGame[1, 4].Map = 2;
                    MainGame[1, 5].Map = 2;

                    idx1 = 0;
                    idx2 = 1;
                    idx3 = 3;
                    idx4 = 4;
                    idx5 = 5;

                }

                else if (ch_count == 5)
                {
                    MainGame[0, 4].Map = 2;
                    MainGame[1, 3].Map = 2;
                    MainGame[1, 4].Map = 2;
                    MainGame[1, 5].Map = 2;

                    idx1 = 0;
                    idx2 = 1;
                    idx3 = 4;
                    idx4 = 3;
                    idx5 = 5;

                }


                else if (ch_count == 6)
                {
                    MainGame[0, 2].Map = 2;
                    MainGame[1, 2].Map = 2;
                    MainGame[1, 3].Map = 2;
                    MainGame[1, 4].Map = 2;

                    idx1 = 0;
                    idx2 = 1;
                    idx3 = 2;
                    idx4 = 3;
                    idx5 = 4;

                }
                else if (ch_count == 7)
                {
                    MainGame[0, 6].Map = 2;
                    MainGame[1, 6].Map = 2;
                    MainGame[1, 5].Map = 2;
                    MainGame[1, 4].Map = 2;

                    idx1 = 0;
                    idx2 = 1;
                    idx3 = 6;
                    idx4 = 5;
                    idx5 = 4;

                }

                //Console.ReadLine();



                while (true)
            {
                Console.SetCursorPosition(0, 0);





                    for (int i = 0; i < MainGame.GetLength(0); i++)
                    {


                        for (int j = 0; j < MainGame.GetLength(1); j++)
                        {




                            if (MainGame[i, j].Map == 1)
                            {
                                Console.Write("■");
                            }
                            else if (MainGame[i, j].Map == 0)
                            {
                                Console.Write("  ");
                            }


                            else if (idx1 == i && ch_count == 1)
                            {
                                Console.Write("■");
                            }
                            else if (idx1 == i && ch_count == 2)
                            {
                                Console.Write("■");
                            }
                            else if (idx2 == i && ch_count == 2)
                            {
                                Console.Write("■");

                            }
                            else if (idx1 == i && ch_count == 3)
                            {
                                Console.Write("■");
                            }
                            else if (idx2 == i && ch_count == 3)
                            {
                                Console.Write("■");
                            }
                            else if (idx1 == i && ch_count == 4)
                            {
                                Console.Write("■");
                            }
                            else if (idx2 == i && ch_count == 4)
                            {
                                Console.Write("■");
                            }

                            else if (idx1 == i && ch_count == 5)
                            {
                                Console.Write("■");
                            }
                            else if (idx2 == i && ch_count == 5)
                            {
                                Console.Write("■");
                            }
                            else if (idx1 == i && ch_count == 6)
                            {
                                Console.Write("■");
                            }
                            else if (idx2 == i && ch_count == 6)
                            {
                                Console.Write("■");
                            }
                            else if (idx1 == i && ch_count == 7)
                            {
                                Console.Write("■");
                            }
                            else if (idx2 == i && ch_count == 7)
                            {
                                Console.Write("■");
                            }

                            else if (temp[i, j].Map == 3) //블락채워지는곧
                            {
                                Console.Write("■");
                            }






                        }
                        //Console.WriteLine(String.Format("{0}", "1").PadLeft(42 - (21 - ("1".Length / 2))))
                        Console.WriteLine();

                        //key input

                        if (Console.KeyAvailable != false)
                        {
                            ConsoleKeyInfo cki;


                            cki = Console.ReadKey(true);
                            switch (cki.Key)
                            {

                                case ConsoleKey.RightArrow:

                                    if (idx5 < MainGame.GetLength(1) - 2)
                                    {
                                        if (ch_count == 1)
                                        {
                                            idx2++;
                                            idx3++;
                                            idx4++;
                                            idx5++;
                                        }
                                    }
                                    break;
                                case ConsoleKey.LeftArrow:
                                    if (idx2 > 1)
                                    {
                                        if (ch_count == 1)
                                        {
                                            idx2--;
                                            idx3--;
                                            idx4--;
                                            idx5--;
                                        }
                                    }
                                    break;
                                case ConsoleKey.UpArrow:

                                    break;
                                case ConsoleKey.DownArrow:

                                    break;
                                case ConsoleKey.Spacebar:

                                    break;
                                case ConsoleKey.Escape:
                                    System.Environment.Exit(-1);
                                    break; ;
                                case ConsoleKey.Q:

                                    Console.ReadKey();
                                    break;

                            }

                        }
                    }
                    

                    if (ch_count == 1)
                    {



                        idx1++;
                        MainGame[idx1 - 1, idx2].Map = 0;
                        MainGame[idx1 - 1, idx3].Map = 0;
                        MainGame[idx1 - 1, idx4].Map = 0;
                        MainGame[idx1 - 1, idx5].Map = 0;

                        MainGame[idx1, idx2].Map = 2;
                        MainGame[idx1, idx3].Map = 2;
                        MainGame[idx1, idx4].Map = 2;
                        MainGame[idx1, idx5].Map = 2;





                        if (idx1 < MainGame.GetLength(0) - 1)
                        {
                            if (temp[idx1 + 1, idx3].Map == 3 || temp[idx1 + 1, idx4].Map == 3
                                || temp[idx1 + 1, idx2].Map == 3 || temp[idx1 + 1, idx5].Map == 3)
                            {
                                temp[idx1, idx2].Map = 3;
                                temp[idx1, idx3].Map = 3;
                                temp[idx1, idx4].Map = 3;
                                temp[idx1, idx5].Map = 3;

                                ch_count = 0;


                                
                                break;
                            }


                            else if (idx1 == MainGame.GetLength(0) - 2)
                            {
                                temp[idx1, idx2].Map = 3;
                                temp[idx1, idx3].Map = 3;
                                temp[idx1, idx4].Map = 3;
                                temp[idx1, idx5].Map = 3;

                                ch_count = 0;



                                break;

                            }

                        }
                    }

                    if (ch_count == 2)
                    {



                        idx1++;
                        idx2++;
                        MainGame[idx1 - 1, idx3].Map = 0;
                        MainGame[idx1 - 1, idx4].Map = 0;
                        MainGame[idx2 - 1, idx3].Map = 0;
                        MainGame[idx2 - 1, idx4].Map = 0;

                        MainGame[idx1, idx3].Map = 2;
                        MainGame[idx1, idx4].Map = 2;
                        MainGame[idx2, idx3].Map = 2;
                        MainGame[idx2, idx4].Map = 2;


                        if (idx2 < MainGame.GetLength(0) - 1)
                        {
                            if (temp[idx1 + 1, idx3].Map == 3 || temp[idx2 + 1, idx4].Map == 3
                             || temp[idx1 + 1, idx4].Map == 3 || temp[idx2 + 1, idx3].Map == 3   )
                            {
                                temp[idx1, idx3].Map = 3;
                                temp[idx1, idx4].Map = 3;
                                temp[idx2, idx3].Map = 3;
                                temp[idx2, idx4].Map = 3;

                                ch_count = 0;


                                idx1 = 0; //초기화
                                idx2 = 0;
                                break;
                            }


                            else if (idx2 == MainGame.GetLength(0) - 2)
                            {
                                temp[idx1, idx3].Map = 3;
                                temp[idx1, idx4].Map = 3;
                                temp[idx2, idx3].Map = 3;
                                temp[idx2, idx4].Map = 3;

                                ch_count = 0;


                                idx1 = 0; //초기화
                                idx2 = 0;
                                break;

                            }
                        }
                    }

                    //count 3

                    if (ch_count == 3)
                    {



                        idx1++;
                        idx2++;
                        

                        MainGame[idx1 - 1, idx3].Map = 0;
                        MainGame[idx1 - 1, idx4].Map = 0;
                        MainGame[idx2 - 1, idx3].Map = 0;
                        MainGame[idx2 - 1, idx5].Map = 0;

                        MainGame[idx1, idx3].Map = 2;
                        MainGame[idx1, idx4].Map = 2;
                        MainGame[idx2, idx3].Map = 2;
                        MainGame[idx2, idx5].Map = 2;





                        if (idx2 < MainGame.GetLength(0) - 1)
                        {
                            if (temp[idx1 + 1, idx3].Map == 3 || temp[idx1 + 1, idx4].Map == 3
                                || temp[idx2 + 1, idx3].Map == 3 || temp[idx2 + 1, idx5].Map == 3)
                            {
                                temp[idx1, idx3].Map = 3;
                                temp[idx1, idx4].Map = 3;
                                temp[idx2, idx3].Map = 3;
                                temp[idx2, idx5].Map = 3;

                                ch_count = 0;


                                
                                break;
                            }


                            else if (idx2 == MainGame.GetLength(0) - 2)
                            {
                                temp[idx1, idx3].Map = 3;
                                temp[idx1, idx4].Map = 3;
                                temp[idx2, idx3].Map = 3;
                                temp[idx2, idx5].Map = 3;

                                ch_count = 0;



                                break;

                            }

                        }
                    }

                    //coutn 4

                    if (ch_count == 4)
                    {



                        idx1++;
                        idx2++;


                        MainGame[idx1 - 1, idx3].Map = 0;
                        MainGame[idx1 - 1, idx4].Map = 0;
                        MainGame[idx2 - 1, idx4].Map = 0;
                        MainGame[idx2 - 1, idx5].Map = 0;

                        MainGame[idx1, idx3].Map = 2;
                        MainGame[idx1, idx4].Map = 2;
                        MainGame[idx2, idx4].Map = 2;
                        MainGame[idx2, idx5].Map = 2;





                        if (idx2 < MainGame.GetLength(0) - 1)
                        {
                            if (temp[idx1 + 1, idx3].Map == 3 || temp[idx1 + 1, idx4].Map == 3
                                || temp[idx2 + 1, idx4].Map == 3 || temp[idx2 + 1, idx5].Map == 3)
                            {
                                temp[idx1, idx3].Map = 3;
                                temp[idx1, idx4].Map = 3;
                                temp[idx2, idx4].Map = 3;
                                temp[idx2, idx5].Map = 3;

                                ch_count = 0;



                                break;
                            }


                            else if (idx2 == MainGame.GetLength(0) - 2)
                            {
                                temp[idx1, idx3].Map = 3;
                                temp[idx1, idx4].Map = 3;
                                temp[idx2, idx4].Map = 3;
                                temp[idx2, idx5].Map = 3;

                                ch_count = 0;



                                break;

                            }

                        }
                    }


                    //count 5


                    if (ch_count == 5)
                    {



                        idx1++;
                        idx2++;


                        MainGame[idx1 - 1, idx3].Map = 0;
                        MainGame[idx2 - 1, idx4].Map = 0;
                        MainGame[idx2 - 1, idx3].Map = 0;
                        MainGame[idx2 - 1, idx5].Map = 0;

                        MainGame[idx1, idx3].Map = 2;
                        MainGame[idx2, idx4].Map = 2;
                        MainGame[idx2, idx3].Map = 2;
                        MainGame[idx2, idx5].Map = 2;





                        if (idx2 < MainGame.GetLength(0) - 1)
                        {
                            if (temp[idx1 + 1, idx3].Map == 3 || temp[idx2 + 1, idx4].Map == 3
                                || temp[idx2 + 1, idx3].Map == 3 || temp[idx2 + 1, idx5].Map == 3)
                            {
                                temp[idx1, idx3].Map = 3;
                                temp[idx2, idx4].Map = 3;
                                temp[idx2, idx3].Map = 3;
                                temp[idx2, idx5].Map = 3;

                                ch_count = 0;



                                break;
                            }


                            else if (idx2 == MainGame.GetLength(0) - 2)
                            {
                                temp[idx1, idx3].Map = 3;
                                temp[idx2, idx4].Map = 3;
                                temp[idx2, idx3].Map = 3;
                                temp[idx2, idx5].Map = 3;

                                ch_count = 0;



                                break;

                            }

                        }
                    }

                    //count 6

                    if (ch_count == 6)
                    {



                        idx1++;
                        idx2++;


                        MainGame[idx1 - 1, idx3].Map = 0;
                        MainGame[idx2 - 1, idx3].Map = 0;
                        MainGame[idx2 - 1, idx4].Map = 0;
                        MainGame[idx2 - 1, idx5].Map = 0;

                        MainGame[idx1, idx3].Map = 2;
                        MainGame[idx2, idx3].Map = 2;
                        MainGame[idx2, idx4].Map = 2;
                        MainGame[idx2, idx5].Map = 2;





                        if (idx2 < MainGame.GetLength(0) - 1)
                        {
                            if (temp[idx1 + 1, idx3].Map == 3 || temp[idx2 + 1, idx3].Map == 3
                                || temp[idx2 + 1, idx4].Map == 3 || temp[idx2 + 1, idx5].Map == 3)
                            {
                                temp[idx1, idx3].Map = 3;
                                temp[idx2, idx3].Map = 3;
                                temp[idx2, idx4].Map = 3;
                                temp[idx2, idx5].Map = 3;

                                ch_count = 0;



                                break;
                            }


                            else if (idx2 == MainGame.GetLength(0) - 2)
                            {
                                temp[idx1, idx3].Map = 3;
                                temp[idx2, idx3].Map = 3;
                                temp[idx2, idx4].Map = 3;
                                temp[idx2, idx5].Map = 3;

                                ch_count = 0;



                                break;

                            }

                        }
                    }

                    //count 7 

                    if (ch_count == 7)
                    {



                        idx1++;
                        idx2++;


                        MainGame[idx1 - 1, idx3].Map = 0;
                        MainGame[idx2 - 1, idx3].Map = 0;
                        MainGame[idx2 - 1, idx4].Map = 0;
                        MainGame[idx2 - 1, idx5].Map = 0;

                        MainGame[idx1, idx3].Map = 2;
                        MainGame[idx2, idx3].Map = 2;
                        MainGame[idx2, idx4].Map = 2;
                        MainGame[idx2, idx5].Map = 2;





                        if (idx2 < MainGame.GetLength(0) - 1)
                        {
                            if (temp[idx1 + 1, idx3].Map == 3 || temp[idx2 + 1, idx3].Map == 3
                                || temp[idx2 + 1, idx4].Map == 3 || temp[idx2 + 1, idx5].Map == 3)
                            {
                                temp[idx1, idx3].Map = 3;
                                temp[idx2, idx3].Map = 3;
                                temp[idx2, idx4].Map = 3;
                                temp[idx2, idx5].Map = 3;

                                ch_count = 0;



                                break;
                            }


                            else if (idx2 == MainGame.GetLength(0) - 2)
                            {
                                temp[idx1, idx3].Map = 3;
                                temp[idx2, idx3].Map = 3;
                                temp[idx2, idx4].Map = 3;
                                temp[idx2, idx5].Map = 3;

                                ch_count = 0;



                                break;

                            }

                        }
                    }
                    

                        System.Threading.Thread.Sleep(1000);
                    
                    Console.WriteLine("idx1 " + idx1);

                //bloc 시작점 

                //System.Threading.Thread.Sleep(1000);

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

        public void Start()
        {


            int[,] block1 = {
                            { 1, 1, 1, 1 },
                            { 0, 0, 0, 0 },
                            { 0, 0, 0, 0 },
                            { 0, 0, 0, 0 }
                                            };

            int[,] block2 = {
                            { 0, 0, 1, 1 },
                            { 0, 1, 1, 0 },
                            { 0, 0, 0, 0 },
                            { 0, 0, 0, 0 }
                                            };

            int[,] block3 = {
                            { 1, 1, 0, 0 },
                            { 0, 1, 1, 0 },
                            { 0, 0, 0, 0 },
                            { 0, 0, 0, 0 }
                                            };

            int[,] block4 = {
                            { 0, 1, 0, 0 },
                            { 1, 1, 1, 0 },
                            { 0, 0, 0, 0 },
                            { 0, 0, 0, 0 }
                                            };

            int[,] block5 = {
                            { 1, 1, 0, 0 },
                            { 1, 1, 0, 0 },
                            { 0, 0, 0, 0 },
                            { 0, 0, 0, 0 }
                                            };

            int[,] block6 = {
                            { 1, 0, 0, 0 },
                            { 1, 1, 1, 0 },
                            { 0, 0, 0, 0 },
                            { 0, 0, 0, 0 }
                                            };

            int[,] block7 = {
                            { 0, 0, 0, 1 },
                            { 0, 1, 1, 1 },
                            { 0, 0, 0, 0 },
                            { 0, 0, 0, 0 }
                                            };



        }




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
