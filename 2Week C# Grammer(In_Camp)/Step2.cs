//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Step_2
//{
//    internal class Step2
//    {
//        static int a = 12;
//        static int b = 10;
//        static int c = 11;
//        static int d = 12;

//        static void Main()
//        {
//            AndCalc();
//            BitCalc();
//            LeftShiftCalc();
//            RightShiftCalc();
//            CheckBit();
//            AddFlag();
//            ToggleFlag();
//            CheckFlag();
//            RemoveFlag();
//        }

//        static void AndCalc()
//        {
//            int result = a & b;

//            Console.WriteLine($"{result}");
//        }

//        static void BitCalc()
//        {
//            int result = a | b;
//            Console.WriteLine($"{result}");
//        }

//        static void LeftShiftCalc()
//        {
//            int result = c << 2;
//            Console.WriteLine($"{result}");
//        }

//        static void RightShiftCalc()
//        {
//            int result = c >> 1;
//            Console.WriteLine($"{result}");
//        }

//        static void CheckBit()
//        {
//            bool isThirdBitOn;

//            if (((d >> 2) & 1) == 1)
//            {
//                isThirdBitOn = true;
//            }
//            else
//                isThirdBitOn = false;

//            Console.WriteLine($"{isThirdBitOn}");
//        }

//        static void AddFlag()
//        {
//            int playerStatus = 0;
//            playerStatus = playerStatus | 0b0100;

//            Console.WriteLine($"{playerStatus}");
//        }

//        static void ToggleFlag()
//        {
//            int playerStatus = 5;
//            playerStatus = playerStatus ^ 0b0001; //xor연산은 서로 다른 비트만 1출력 따라서 0b0101인 상태에서 0b0001을 xor연산하면 0b0100이 값이  됨;

//            Console.WriteLine($"{playerStatus}");
//        }

//        static void CheckFlag()
//        {
//            int playerStatus = 5;
//            if((playerStatus&0b0100)!=0)//and연산으로 playerStatus와 0b0100의 각 자리의 비트가 일치하면 1이 출력됨
//            {
//                Console.WriteLine($"플레이어가 독 상태입니다.");
//            }
//        }

//        static void RemoveFlag()
//        {
//            int playerStatus = 7;
//            playerStatus &= ~0b0100; //~은 not연산 ~0b0100은 0b1011과 같다. , 0111&1011은 0011

//            Console.WriteLine($"{playerStatus}");
//        }
//    }
//}
