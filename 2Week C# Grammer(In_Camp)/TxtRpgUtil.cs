using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    static class Utility
    {
        public static string PaddingKorean_Center(string str, int width)
        {
            int curWidth = 0;

            foreach (char c in str)
            {
                curWidth += c <= 127 ? 1 : 2;
            }

            int padding = width - curWidth;
            int leftPadding = padding / 2;
            int rightPadding = padding - leftPadding;

            return new string(' ', Math.Max(0, leftPadding)) + str + new string(' ', Math.Max(0, rightPadding));
        }

        public static string PaddingKorean_Right(string str, int width)
        {
            int curWidth = 0;

            foreach (char c in str)
            {
                curWidth += c <= 127 ? 1 : 2;
            }

            int padding = width - curWidth;

            return str + new string(' ', Math.Max(0, padding));
        }

        public  static int  IntInput()
        {
            while(true)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    return result;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("숫자만 입력해주세요!");
                    Console.ResetColor();
                    Console.Write(">>");
                }
            }
        }
    }
}
