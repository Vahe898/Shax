namespace Shax
{
    internal class Program
    {
        public static void TakingNecessaryPointForRookAndKing(Point ForRook, Point ForKing,ref int[,] arrForRook, int[,] arrForKing,ref int shax)
        {
            shax = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (arrForKing[i, j] + arrForRook[i, j] > 10)/*ena vor gci vra yngav araji kingy*/
                    {
                        shax++;
                        if (ForRook.Number < ForKing.Number && Array.IndexOf(Enum.GetValues(ForRook.Letter.GetType()), ForRook.Letter)== Array.IndexOf(Enum.GetValues(ForKing.Letter.GetType()), ForKing.Letter))/*kingy verevna uxxahayac*/
                        {
                            for (int k = ForKing.Number; k < 8; k++)/*toxer*/
                            {
                                arrForRook[k, j] = 0;
                            }

                        }
                        else if (ForRook.Number > ForKing.Number && Array.IndexOf(Enum.GetValues(ForRook.Letter.GetType()), ForRook.Letter) == Array.IndexOf(Enum.GetValues(ForKing.Letter.GetType()), ForKing.Letter))/*kingy nerqevna uxxahayac*/
                        {
                            for (int k = 0; k <= ForKing.Number; k++)/*toxer*/
                            {
                                arrForRook[k, j] = 0;
                            }
                        }
                        else if (Array.IndexOf(Enum.GetValues(ForRook.Letter.GetType()), ForRook.Letter) > Array.IndexOf(Enum.GetValues(ForKing.Letter.GetType()), ForKing.Letter) && ForRook.Number==ForKing.Number)/*kingy horizonakan depi caxa yngnum*/
                        {
                            for (int k = Array.IndexOf(Enum.GetValues(ForKing.Letter.GetType()), ForKing.Letter); k >= 0; k--)/*toxer*/
                            {
                                arrForRook[i, k] = 0;
                            }
                        }
                        else if (Array.IndexOf(Enum.GetValues(ForRook.Letter.GetType()), ForRook.Letter) < Array.IndexOf(Enum.GetValues(ForKing.Letter.GetType()), ForKing.Letter) &&  ForRook.Number == ForKing.Number)/*kingy horizonakan depi aja yngnum*/
                        {
                            for (int k = Array.IndexOf(Enum.GetValues(ForKing.Letter.GetType()), ForKing.Letter); k < 8; k++)/*toxer*/
                            {
                                arrForRook[i, k] = 0;
                            }
                        }
                    }
                }
            }
        }
        public static void TakingNecessaryPointForQueenAndAther(Point ForQueen,Point ForAther,ref int[,] arrForQueen, int[,] arrForAther,ref int shax)
        {

            TakingNecessaryPointForRookAndKing(ForQueen, ForAther, ref arrForQueen, arrForAther,ref shax  );
            for (int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if (arrForQueen[i, j] + arrForAther[i, j] > 10)/*ena vor gci vra yngav bayc diaganali*/
                    {
                        shax++;
                        if (ForQueen.Number > ForAther.Number && Array.IndexOf(Enum.GetValues(ForQueen.Letter.GetType()), ForQueen.Letter) < Array.IndexOf(Enum.GetValues(ForAther.Letter.GetType()), ForAther.Letter))/*diaganalov verev aj queenic*/
                        {
                            for(int k = ForAther.Number; k >= 0; k--)
                            {
                                for(int t= Array.IndexOf(Enum.GetValues(ForAther.Letter.GetType()), ForAther.Letter); t < 8; t++)
                                {
                                    arrForQueen[k, t] = 0;
                                }
                            }
                        }
                        else if((ForQueen.Number > ForAther.Number && Array.IndexOf(Enum.GetValues(ForQueen.Letter.GetType()), ForQueen.Letter) > Array.IndexOf(Enum.GetValues(ForAther.Letter.GetType()), ForAther.Letter)))/*diaganalov depi verev caxa yngnum queenic*/
                        {
                            for (int k = ForAther.Number; k>=0; k--)
                            {
                                for (int t = Array.IndexOf(Enum.GetValues(ForAther.Letter.GetType()), ForAther.Letter); t >=0; t--)
                                {
                                    arrForQueen[k, t] = 0;
                                }
                            }
                        }
                        else if (ForQueen.Number < ForAther.Number && Array.IndexOf(Enum.GetValues(ForQueen.Letter.GetType()), ForQueen.Letter) < Array.IndexOf(Enum.GetValues(ForAther.Letter.GetType()), ForAther.Letter))/*queenic nerqev aj diaganalov*/
                        {
                            for (int k = ForAther.Number; k <8 ; k++)
                            {
                                for (int t = Array.IndexOf(Enum.GetValues(ForAther.Letter.GetType()), ForAther.Letter); t < 8; t++)
                                {
                                    arrForQueen[k, t] = 0;
                                }
                            }
                        }
                        else if (ForQueen.Number < ForAther.Number && Array.IndexOf(Enum.GetValues(ForQueen.Letter.GetType()), ForQueen.Letter) > Array.IndexOf(Enum.GetValues(ForAther.Letter.GetType()), ForAther.Letter))/*queenic diaganalov nerqev cax*/
                        {
                            for (int k = ForAther.Number; k < 8; k++)
                            {
                                for (int t = Array.IndexOf(Enum.GetValues(ForAther.Letter.GetType()), ForAther.Letter); t >=0; t--)
                                {
                                    arrForQueen[k, t] = 0;
                                }
                            }
                        }
                    }
                            
                }
            }
            //for (int i = 0; i < 8; i++)
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        Console.Write(arrForQueen[i, j]);
            //    }
            //    Console.WriteLine();
            //}
        }
        public static void MakeMatric(int inputNumForRedKing, Letters inputLetForRedKing, int inputNumForRedRook, Letters inputLetForRedRook, ref int[,] arrForRedRook,int inputNumForBlueKing,Letters inputLetForBlueKing,int inputNumForRedRook2,Letters inputLetForRedRook2,ref int[,] arrForRedRook2,int inputNumForRedQueen,Letters inputLetForRedQueen, ref int[,] arrForRedQueen)
        {
            King redKing = new King();
            Point PointOfRedKing = new Point(inputNumForRedKing, inputLetForRedKing);
            int[,] arrForRedKing = new int[8, 8];
            redKing.MatricOfKing(PointOfRedKing.Number, PointOfRedKing.Letter, ref arrForRedKing);

            Rook redRook = new Rook();
            Point PointOfRedRook = new Point(inputNumForRedRook, inputLetForRedRook);
            redRook.MatricOfRook(PointOfRedRook.Number, PointOfRedRook.Letter, ref arrForRedRook);
           

            King blueKing = new King();
            Point PointOfBlueKing = new Point(inputNumForBlueKing, inputLetForBlueKing);
            int[,] arrForBlueKing = new int[8, 8];
            blueKing.MatricOfKing(PointOfBlueKing.Number, PointOfBlueKing.Letter, ref arrForBlueKing);

            Rook redRook2 = new Rook();
            Point PointOfRedRook2 = new Point(inputNumForRedRook2, inputLetForRedRook2);
            redRook2.MatricOfRook(PointOfRedRook2.Number, PointOfRedRook2.Letter, ref arrForRedRook2);

            Queen redQueen = new Queen();
            Point PointOfRedQueen = new Point(inputNumForRedQueen, inputLetForRedQueen);
            redQueen.MatricOfQueen(PointOfRedQueen.Number, PointOfRedQueen.Letter, ref arrForRedQueen);

            int shax = 0;
            TakingNecessaryPointForQueenAndAther(PointOfRedQueen, PointOfRedKing, ref arrForRedQueen, arrForRedKing,ref shax);
            TakingNecessaryPointForQueenAndAther(PointOfRedQueen, PointOfRedRook, ref arrForRedQueen, arrForRedRook, ref shax);
            TakingNecessaryPointForQueenAndAther(PointOfRedQueen, PointOfRedRook2, ref arrForRedQueen, arrForRedRook2, ref shax);
            TakingNecessaryPointForQueenAndAther(PointOfRedQueen, PointOfBlueKing, ref arrForRedQueen, arrForBlueKing, ref shax);
            if (shax > 0)/*blue kingi hamar u taguhu*/
            {
                Console.WriteLine("shax");
            }

            TakingNecessaryPointForRookAndKing(PointOfRedRook, PointOfRedKing, ref arrForRedRook, arrForRedKing, ref shax);
            TakingNecessaryPointForRookAndKing(PointOfRedRook, PointOfBlueKing, ref arrForRedRook, arrForBlueKing, ref shax);
            if (shax > 0)/*blue kingi hamar u navi*/
            {
                Console.WriteLine("shax");
            }
            TakingNecessaryPointForRookAndKing(PointOfRedRook2, PointOfRedKing, ref arrForRedRook2, arrForRedKing, ref shax);          
            TakingNecessaryPointForRookAndKing(PointOfRedRook2, PointOfBlueKing, ref arrForRedRook2, arrForBlueKing, ref shax);
            if (shax > 0)/*blue kingi hamar u navi myus*/
            {
                Console.WriteLine("shax");
            }




            //for (int i = 0; i < 8; i++)
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        Console.Write(arrForRedRook2[i, j]);
            //    }
            //    Console.WriteLine();
            //}

        }

        public static void MakeChessWithMatric(Point PoinntOfRedRook,string inputFigurOfRedRook, Point PointOfRedKing, string inputFigurOfRedKing, Point PoinntOfRedRook2,string inputFigurOfRedRook2, Point PointOfBlueKing, string inputFigurOfBlueKing,Point PointOfRedQueen, string inputFigurOfRedQueen)
        {
            int[,] arrForRedRook = new int[8, 8];
            int[,] arrForRedRook2 = new int[8, 8];
            int[,] arrForRedQueen = new int[8, 8];

            MakeMatric(PointOfRedKing.Number , PointOfRedKing.Letter, PoinntOfRedRook.Number, PoinntOfRedRook.Letter,ref arrForRedRook, PointOfBlueKing.Number , PointOfBlueKing.Letter, PoinntOfRedRook2.Number , PoinntOfRedRook2.Letter,ref arrForRedRook2,PointOfRedQueen.Number,PointOfRedQueen.Letter,ref arrForRedQueen);
            King redKing = new King();
            int[,] arrForRedKing = new int[8, 8];
            redKing.MatricOfKing(PointOfRedKing.Number , PointOfRedKing.Letter, ref arrForRedKing);

            King blueKing = new King();
            int[,] arrForBlueKing = new int[8, 8];
            blueKing.MatricOfKing(PointOfBlueKing.Number , PointOfBlueKing.Letter, ref arrForBlueKing);
            
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (j == 0 && i < 8)/*tverna tpum*/
                    {
                        Console.Write(i + 1);
                    }
                    else if (i == 8 && j >= 0)/*tareri hamra*/
                    {
                        Console.Write($"  {(Letters)j}");
                    }

                    if ((i + j) % 2 == 0 && i < 8)/*guynenrna*/
                    {

                        Console.BackgroundColor = ConsoleColor.White;

                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    /*karmiri figury*/
                    if (i  == PointOfRedKing.Number && (Letters)j == PointOfRedKing.Letter) /*nayuma koordinatnery hamynknuma*/
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(inputFigurOfRedKing + "  ");
                    }

                    /*kaputi figury*/
                    else if (i  == PoinntOfRedRook.Number && (Letters)j == PoinntOfRedRook.Letter) /*nayuma koordinatnery hamynknuma*/
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(inputFigurOfRedRook + "  ");
                    }
                    else if (i  == PoinntOfRedRook2.Number && (Letters)j == PoinntOfRedRook2.Letter) /*nayuma koordinatnery hamynknuma*/
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(inputFigurOfRedRook2 + "  ");
                    }
                    else if (i  == PointOfBlueKing.Number && (Letters)j == PointOfBlueKing.Letter) /*nayuma koordinatnery hamynknuma*/
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(inputFigurOfBlueKing + "  ");
                    }
                    else if(i == PointOfRedQueen.Number && (Letters)j == PointOfRedQueen.Letter)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(inputFigurOfRedQueen + "  ");
                    }

                    /*karmiri vandakanishnery*/
                    else if (i < 8)
                    {


                        if (arrForBlueKing[i,j] + arrForRedKing[i,j] == 2 || arrForBlueKing[i,j] + arrForRedQueen[i,j] == 3 || arrForBlueKing[i,j] + arrForRedRook[i,j] == 3 || arrForBlueKing[i,j] + arrForRedRook2[i,j] == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(" # ");
                        }

                        else if (i < 8 && arrForRedRook[i, j] == 2 || arrForRedRook2[i, j] == 2 || arrForRedQueen[i,j] == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" # ");
                        }
                        else if (i < 8 && arrForRedKing[i, j] == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" # ");
                        }
                        else if (i < 8 && arrForBlueKing[i, j] == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(" # ");
                        }

                        else if (i != 8 && j >= 0)
                        {
                            Console.Write("   ");
                        }
                    }
                }
                Console.ResetColor();
                Console.WriteLine();
            }
            
        }
        static void Main(string[] args)
        {
            int[,] arr = new int[8, 8];
            int[,] arr2 = new int[8, 8];
            int[,] arr3 = new int[8, 8];
            Point PoinntOfRedRook2 = new Point(2, Letters.D);
            Point PointOfRedKing = new Point(2, Letters.B);
            Point PoinntOfRedRook = new Point(5, Letters.E);
            Point PointOfBlueKing = new Point(3, Letters.E);
            Point PoinntOfRedQueen = new Point(4, Letters.B);
            //MakeMatric(PointOfRedKing.Number, PointOfRedKing.Letter, PoinntOfRedRook.Number, PoinntOfRedRook.Letter, ref arr, PointOfBlueKing.Number, PointOfBlueKing.Letter, PoinntOfRedRook2.Number, PoinntOfRedRook2.Letter, ref arr2, PoinntOfRedQueen.Number, PoinntOfRedQueen.Letter, ref arr3);
             MakeChessWithMatric(PoinntOfRedRook, "r", PointOfRedKing, "k", PoinntOfRedRook2, "r", PointOfBlueKing, "k",PoinntOfRedQueen,"q");




            //for (int i = 0; i < 8; i++)
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        Console.Write(arr[i, j]);
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine(  );
            //Console.WriteLine(  );
            //for (int i = 0; i < 8; i++)
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        Console.Write(arr2[i, j]);
            //    }
            //    Console.WriteLine();
            //}


        }
    }
}
