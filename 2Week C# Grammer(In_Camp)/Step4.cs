//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Step_4
//{
//    internal class Step4
//    {
//        static void Main()
//        {
//            BasicFor();
//            PrintLineFor();
//            MinusFor();
//            DoubleFor();
//            SumFor();
//            GreedRepeat(3);
//            IfFor();
//            BasicWhile();
//            MinusWhile();
//            SumWhile();
//            IfWhile();
//            Login();
//            EvenOdd();
//            BreakFor();
//            ContinueFor();
//            InfiniteWhile_Break();
//            ContinueApply();
//            BreakApply();
//            InfinityWhile_Login();
//            InfinityWhile_Menu();
//            InfinityWhile_Login2();
//            ContinueWhile_Sum();
//            SumFor_Apply();
//            NestingFor();
//            Square();
//            MultiplicationTable2();
//            MultiplicationTable();
//            SumApply_Break();
//            DoWhile();
//        }

//        static void BasicFor()
//        {
//            for (int i = 1; i <= 10; i++)
//            {
//                Console.WriteLine(i);
//            }
//        }

//        static void PrintLine()
//        {
//            Console.WriteLine("============");
//        }

//        static void PrintLineFor()
//        {
//            for (int i = 0; i < 5; i++)
//            {
//                PrintLine();
//            }
//        }

//        static void MinusFor()
//        {
//            for (int i = 10; i >= 1; i--)
//            {
//                Console.WriteLine(i);
//            }
//        }

//        static void DoubleFor()
//        {
//            for (int i = 0; i <= 10; i += 2)
//            {
//                Console.WriteLine(i);
//            }
//        }

//        static void SumFor()
//        {
//            int sum = 0;
//            for (int i = 1; i <= 10; i++)
//            {
//                sum += i;
//            }
//            Console.WriteLine(sum);
//        }

//        static void GreedRepeat(int count)
//        {
//            for (int i = 0; i < count; i++)
//            {
//                Console.WriteLine("안녕하세요");
//            }
//        }

//        static void IfFor()
//        {
//            for (int i = 1; i <= 20; i++)
//            {
//                if (i % 3 == 0)
//                {
//                    Console.WriteLine(i);
//                }
//            }
//        }

//        static void BasicWhile()
//        {
//            int i = 1;
//            while (i <= 10)
//            {
//                Console.WriteLine(i);
//                i++;
//            }
//        }

//        static void MinusWhile()
//        {
//            int i = 10;
//            while (i >= 1)
//            {
//                Console.WriteLine(i);
//                i--;
//            }
//        }

//        static void SumWhile()
//        {
//            int i = 1;
//            int sum = 0;
//            while (i <= 10)
//            {
//                sum += i;
//                i++;
//            }
//            Console.WriteLine(sum);
//        }

//        static void IfWhile()
//        {
//            int i = 1;
//            while (i <= 20)
//            {
//                if (i % 2 == 0)
//                {
//                    Console.WriteLine(i);
//                }
//                i++;
//            }
//        }

//        static void Login()
//        {
//            string password = "1234";
//            string input = "";

//            while (input != password)
//            {
//                Console.Write("비밀번호를 입력하세요: ");
//                input = Console.ReadLine();
//            }
//            Console.WriteLine("로그인 성공!");
//        }

//        static void EvenOdd()
//        {
//            while (true)
//            {
//                Console.Write("숫자를 입력하세요 (0=종료): ");
//                int number = int.Parse(Console.ReadLine());

//                if (number == 0)
//                {
//                    Console.WriteLine("종료합니다.");
//                    break;
//                }

//                if (number % 2 == 0)
//                {
//                    Console.WriteLine("짝수");
//                }
//                else
//                {
//                    Console.WriteLine("홀수");
//                }
//            }
//        }

//        static void BreakFor()
//        {
//            for (int i = 1; i <= 100; i++)
//            {
//                if (i == 5)
//                {
//                    break;
//                }
//                Console.WriteLine(i);
//            }
//        }

//        static void ContinueFor()
//        {
//            for (int i = 1; i <= 10; i++)
//            {
//                if (i % 2 != 0)
//                    continue; //다음 반복으로 넘어간다는 뜻 ->따라서 홀수일 경우 WriteLine출력 x
//                Console.WriteLine(i);
//            }
//        }

//        static void InfiniteWhile_Break()
//        {
//            int i = 1;
//            while (true)
//            {
//                Console.WriteLine(i);
//                i++;

//                if (i > 5)
//                    break;
//            }
//        }

//        static void ContinueApply()
//        {
//            int i = 0;
//            while (i < 20)
//            {
//                i++;
//                if (i % 3 != 0)
//                    continue;

//                Console.WriteLine(i);
//            }
//        }

//        static void BreakApply()
//        {
//            for (int i = 1; i <= 100; i++)
//            {
//                if (i % 7 == 0)
//                {
//                    Console.WriteLine(i);
//                    break;
//                }
//            }
//        }

//        static void InfinityWhile_Login()
//        {
//            while (true)
//            {
//                Console.WriteLine("비밀번호 (1234): ");
//                string input = Console.ReadLine();

//                if (input == "1234")
//                {
//                    Console.WriteLine("로그인 성공");
//                    break;
//                }
//                else
//                    Console.WriteLine("비밀번호 오류!");
//            }
//        }

//        static void InfinityWhile_Menu()
//        {
//            bool isGameRunning = true;

//            while (isGameRunning)
//            {
//                Console.WriteLine("1.공격 2.방어 0.종료");
//                Console.Write("입력: ");
//                string choice = Console.ReadLine();

//                switch (choice)
//                {
//                    case "0":
//                        isGameRunning = false;
//                        break;
//                    case "1":
//                        Console.WriteLine("공격!");
//                        break;
//                    case "2":
//                        Console.WriteLine("방어!");
//                        break;
//                    default:
//                        Console.WriteLine("잘못된 입력");
//                        break;
//                }
//            }
//        }

//        static void InfinityWhile_Login2()
//        {
//            string id = "myid";
//            string pw = "1234";

//            while (true)
//            {
//                Console.Write("아이디:  ");
//                string inputId = Console.ReadLine();

//                Console.Write("비밀번호: ");
//                string inputPw = Console.ReadLine();

//                if (inputId == "myid" && inputPw == "1234")
//                {
//                    Console.WriteLine("로그인 성공!");
//                    break;
//                }
//                else
//                {
//                    Console.WriteLine("아이디/비밀번호 오류. 재시도.");
//                }
//            }
//        }

//        static void ContinueWhile_Sum()
//        {
//            int sum = 0;

//            while (true)
//            {
//                Console.Write("더할 숫자 입력(0=종료): ");
//                int.TryParse(Console.ReadLine(), out int num); //TryParse는 문자열을 int 로 변환시도. 성공하면 True->num에 입력된 값 저장,실패하면 false num=0 out을 쓰는 이유는 TryParse가 bool,int형 두개의 값 반환해야 해서

//                if (num > 0)
//                {
//                    sum += num;
//                    Console.WriteLine(sum);
//                }
//                else if (num < 0)
//                {
//                    Console.WriteLine("음수는 계산하지 않습니다.");
//                    continue;
//                }
//                else
//                {
//                    break;
//                }
//            }
//        }

//        static void SumFor_Apply()
//        {
//            int sum = 0;
//            for (int i = 1; i <= 100; i++)
//            {
//                if (i % 3 == 0 || i % 5 == 0)
//                {
//                    sum += i;
//                }
//            }
//            Console.WriteLine(sum);
//        }

//        static void NestingFor()
//        {
//            for(int i = 1;i<=3;i++)
//            {
//                for(int j = 1;j<=2;j++)
//                {
//                    Console.WriteLine($"i: {i} j: {j}");//i는 1일때 j는 1,2반복 따라서 i: 1 j:1->i: 1  j:2
//                }
//            }
//        }

//        static void Square()
//        {
//            for(int i=0;i<5;i++)
//            {
//                for(int j = 0;j<5;j++)
//                {
//                    Console.Write("*");
//                }
//                Console.WriteLine();
//            }
//        }

//        static void MultiplicationTable2()
//        {
//            for(int i =1;i<=9;i++)
//            {
//                Console.Write($"{i}x2={i * 2}\n");
//            }
//        }

//        static void MultiplicationTable()
//        {
//            for(int i =1;i<=9;i++)
//            { 
//                for(int j = 1;j<=9;j++)
//                {
//                    Console.Write($"{i}x{j} = {i * j} ");
//                }
//                Console.WriteLine();
//            }
//        }

//        static void SumApply_Break()
//        {
//            int sum = 0;
//            for(int i =1; ;i++)
//            {
//                if (sum < 2000)
//                {
//                    sum += i;
//                }
//                else
//                    break;
//            }
//        }

//        static void DoWhile()
//        {
//            int i = 1;
//            do
//            {
//                Console.WriteLine(i);
//                i++;
//            } while (i<=5);
//        }
//    }
//}

