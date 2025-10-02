//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Security;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Linq;

//namespace Step_1
//{
//    internal class Step1
//    {
//        static byte level = 50;
//        static int levelInt = level;

//        static int gold = 200000;
//        static long goldLong = gold;

//        static int hp = 10;
//        static float hpFloat = hp;

//        static float speed = 5.25f;
//        static double speedDouble=speed;

//        static float averageDamage = 20.7f;
//        static int damageInt = (int)averageDamage;

//        static double preciseExp = 123.456;
//        static int expInt = (int)preciseExp;

//        static int itemCount = 150;
//        static byte countByte = (byte)itemCount;

//        static int overflowValue = 300;
//        static byte byteValue = (byte)overflowValue; //44출력됨  그 이유은 byte는 0~255까지 표현 가능한데 255가 넘어가면 오브플로우가 발생되 0부터 세기 시작 반대 개념으로는 언더플로우가 있음

//        static long hueGold = 3000000000L; //int->byte와 똑같은 이유  int 형은 -2,147,483,648부터 2,147,483,647까지의 범위를 가지므로 넘치는 값은 음수부터 다시 세기 시작
//        static int goldInt = (int)hueGold;

//        static double preciseLocation = 123.456789123; //float은 부동소수점 표현방식,근사값으로 표현됨 보통 float같은 경우엔 7~8자리를 넘어가면  정밀도가 떨어짐
//        static float simpleLocation = (float)preciseLocation;



//        static void Main()
//        {
//            Console.WriteLine($"{levelInt}\n");
//            Console.WriteLine($"{goldLong}\n");
//            Console.WriteLine($"{hpFloat}\n");
//            Console.WriteLine($"{speedDouble}\n");
//            Console.WriteLine($"{damageInt}\n");
//            Console.WriteLine($"{expInt}\n");
//            Console.WriteLine($"{countByte}\n");
//            Console.WriteLine($"{byteValue}\n");
//            Console.WriteLine($"{goldInt}\n");
//            Console.WriteLine($"{simpleLocation}\n");

//            var myLevel = 10;
//            var myJob = "전사";
//            var isPlayerTurn = true;

//            int 1stPlayerLevel; //맨 앞에 숫자가 오면 안됨
//            string player Name; //띄어쓰기 하면 안됨
//            bool IsMonsterDead;  //맨앞에 변수명은 소문자
//            int long; //long은 이미 c#에서 정의된 기능을 가지고 있음 따라서 변수명 사용 불가
//        }
//    }
//}
