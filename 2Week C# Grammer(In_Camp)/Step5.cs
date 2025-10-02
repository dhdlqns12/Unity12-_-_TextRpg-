//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Step_5
//{
//    internal class Step5
//    {
//        static void Main()
//        {
//            IntParse();
//            //IntParseError();
//            IntTryParse1();
//            IntTryParse2();
//            Contains1();
//            Replace1();
//        }

//        static void IntParse()
//        {
//            string input = "1";
//            int choice = int.Parse(input);

//            Console.WriteLine(choice + 1);
//        }

//        static void IntParseError()
//        {
//            string input = "abc"; 
//            int a = int.Parse(input);//숫자형이 아닌 문자형이기 때문에 올바르지 않은 포맷이라고 나옵니다.
//        }

//        static void IntTryParse1()
//        {
//            string input = "abc";
//            if(int.TryParse(input, out int choice))
//            {
//                Console.WriteLine(choice);
//            }
//            else
//            {
//                Console.WriteLine("숫자만 입력해야 합니다.");
//            }
//        }
        
//        static void IntTryParse2()
//        {
//            string input = "3";

//            if (int.TryParse(input, out int choice))
//            {
//                Console.WriteLine($"입력한 숫자: {choice}");
//            }
//            else
//            {
//                Console.WriteLine("숫자만 입력해야 합니다.");
//            }
//        }

//        static void Contains1()
//        {
//            string message = "You found a potion!";

//            if(message.Contains("potion"))
//            {
//                Console.WriteLine("포션을 발견했다!");
//            }
//        }

//        static void Replace1()
//        {
//            string description = "매우 [낡은] 검입니다.";
//            string newDescription = description.Replace("[낡은]", "강화된");
//            Console.WriteLine(newDescription);
//        }
//    }
//}
