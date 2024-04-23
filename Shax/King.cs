using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shax
{
    internal class King
    {
        private int _numberForKing;
        private Letters _letterForKing;


        public int NumberForKing
        {
            get
            {
                return _numberForKing;
            }
            set
            {
                if (value > 0 && value < 9)
                {
                    _numberForKing = value;
                }
                else
                {
                    throw new ArgumentException($"{value} is not correct");
                }
            }
        }
        public Letters LetterForKing
        {
            get
            {
                return _letterForKing;

            }
            set
            {
                if (Enum.IsDefined(typeof(Letters), value))/*senc nayum em tenam tvacs enumis meja te che*/
                {
                    _letterForKing = (Letters)Enum.Parse(typeof(Letters), value.ToString().ToUpper());/*tvacs tary vory stringa darcnuma enum*/
                }
                else
                {
                    throw new ArgumentException($"{value} is not correct");
                }
            }
        }
        public void MatricOfKing(int inputNum, Letters inputLet, ref int[,] arr)
        {

            Point PointOfKing = new Point(inputNum, inputLet);
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Array.IndexOf(Enum.GetValues(PointOfKing.Letter.GetType()), PointOfKing.Letter) == Array.IndexOf(Enum.GetValues(((Letters)j).GetType()), (Letters)j) || Array.IndexOf(Enum.GetValues(PointOfKing.Letter.GetType()), PointOfKing.Letter) + 1 == Array.IndexOf(Enum.GetValues(((Letters)j).GetType()), ((Letters)j)) || (Array.IndexOf(Enum.GetValues(PointOfKing.Letter.GetType()), PointOfKing.Letter) - 1 == Array.IndexOf(Enum.GetValues(((Letters)j).GetType()), ((Letters)j))))
                    {
                        if (PointOfKing.Number == i || PointOfKing.Number + 1 == i || PointOfKing.Number - 1 == i)
                        {
                            if (!(inputNum == i && inputLet == (Letters)j))
                            {
                                arr[i, j] = 1;
                            }
                            else
                            {
                                arr[i, j] = 9;
                            }


                        }
                    }
                }

            }

        }
    }
}
