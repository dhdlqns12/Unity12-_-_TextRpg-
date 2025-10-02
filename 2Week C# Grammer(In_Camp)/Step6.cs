//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Step_6
//{
//    internal class Step6
//    {
//        static void Main()
//        {
//            Step6_1();
//            Step6_2();
//            Step6_3();
//            Step6_4();
//            Step6_5();
//        }

//        static void Step6_1()
//        {
//            int[] scores = new int[5];
//            scores[0] = 100;
//            scores[2] = 80;
//            int sum = scores[0] + scores[2];

//            Console.WriteLine(sum);

//            if (scores[0]==100)
//            {
//                Console.WriteLine("만접입니다!");
//            }
//        }

//        static void Step6_2()
//        {
//            string[] items = { "철검", "가죽갑옷", "HP포션" };
//            string item = items[2];

//            Console.WriteLine(item);

//            int count = items.Length;

//            Console.WriteLine(count);

//            for(int i =0;i<items.Length;i++)
//            {
//                Console.WriteLine(items[i]);
//            }
//        }

//        static void Step6_3()
//        {
//            string[] monsterNames = new string[3] { "고블린","오크","예티"};

//            for(int i=0;i<monsterNames.Length;i++)
//            {
//                Console.WriteLine($"{i+1}번 몬스터: {monsterNames[i]}");
//                Console.WriteLine($"{monsterNames[i].Length}");
//            }

//            foreach(string name in monsterNames)
//            {
//                Console.WriteLine(name);
//            }
//        }

//        static void Step6_4()
//        {
//            int[] data = { 5, 12, 3, 8, 10 };
//            int sum = 0;

//            for(int i=0;i<data.Length;i++)
//            {
//                if (data[i]>10)
//                {
//                    Console.WriteLine(data[i]);
//                }

//                if (data[i]%2==0)
//                {
//                    Console.WriteLine(data[i]);
//                }

//                sum += data[i];
//            }

//            foreach(int num in data)
//            {
//                if(num>5)
//                {
//                    Console.WriteLine(num);
//                }
//            }
//            Console.WriteLine(sum+"\n");
//        }

//        static void Step6_5()
//        {
//            List<string> inventory = new List<string>() { "검", "방패", "포션" };

//            bool hasShield = false;
//            bool hasSword = false;

//            int count = inventory.Count;

//            Console.WriteLine($"\n{count}");

//            string item = inventory[0];

//            Console.WriteLine(item);

//            inventory[1] = "강철방패";

//            inventory.Remove("포션");

//            inventory.RemoveAt(0);

//            Console.WriteLine(inventory.Count);

//            hasShield=inventory.Contains("강철방패");
//            hasSword = inventory.Contains("검");

//            Console.WriteLine(hasShield);
//            Console.WriteLine(hasSword);

//            inventory.Clear();
//            Console.WriteLine(inventory.Count);

//            PrintInventory(inventory);

//            inventory.Add("검");
//            inventory.Add("방패");
//            inventory.Add("포션");

//            PrintInventory(inventory);
//        }

//        static void PrintInventory(List<string>inv)
//        {
//            foreach(string item in inv )
//            {
//                Console.WriteLine(item);
//            }
//        }
//    }
//}
