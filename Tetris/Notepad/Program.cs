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