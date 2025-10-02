//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection.PortableExecutable;
//using System.Text;
//using System.Threading.Tasks;

//namespace Step_7
//{
//    public interface IAttackable
//    {
//        void Attack(Character target);
//    }

//    public abstract class Character
//    {
//        public string Name { get; protected set; }
//        public int Hp { get; protected set; }
//        public int Atk { get; protected set; }

//        public Character(string name,int _atk)
//        {
//            Name = name;
//            Atk = _atk;
//        }

//        public void Move()
//        {
//            Console.WriteLine($"{Name}이 이동합니다.");
//        }

//        public abstract void Die();

//        public virtual void ShowInfo()
//        {
//            Console.Write($"이름: {Name},  HP: {Hp}");
//        }
//    }

//    class Player: Character, IAttackable
//    {
//        int level=1;

//        public Player(string name, int _atk) : base(name, _atk)  
//        {

//        }

//        public void Attack(Character target)
//        {
//            Console.WriteLine($"{target.Name}에게 {Atk}데미지!");
//        }

//        public override void Die()
//        {
//            Console.WriteLine("플레이어가 사망했습니다.");
//        }

//        public override void ShowInfo()
//        {
//            base.ShowInfo();
//            Console.WriteLine($", 레벨: {level}");
//        }
//    }

//    class Monster:Character,IAttackable
//    {
//        public Monster(string name, int _atk) : base(name, _atk) 
//        {
//        }

//        public void Attack(Character target)
//        {
//            Console.WriteLine($"{target.Name}에게 {Atk}데미지!");
//        }

//        public override void Die()
//        {
//            Console.WriteLine($"{Name}몬스터가 사망했습니다.");
//        }
//    }

//    class Skill:Character,IAttackable
//    {
//        string skillName = "스킬이름";
//        public Skill(string name, int _atk) : base(name, _atk)
//        {
//            skillName = name;
//        }

//        public void Attack(Character target)
//        {
//            Console.WriteLine($"스킬 {skillName}발동! {target.Name}에게 {Atk}데미지!");
//        }

//        public override void Die()
//        {
//        }
//    }

//    class InGame
//    {
//        static void Main()
//        {
//            IAttackable playerAttack = new Player("플레이어",10);

//            Monster slime = new Monster("슬라임",1);
//            playerAttack.Attack(slime);
//            Skill fireBall = new Skill("파이어볼", 5);

//            List<IAttackable> attackers = new List<IAttackable>(); //서로 다른 클래스지만 IAttackable을 상속하므로 하나의 타입으로 취급 가능.
//            attackers.Add(playerAttack);
//            attackers.Add(slime);
//            attackers.Add(fireBall);

//            Character player = new Player("Player", 10);
//            player.ShowInfo();
//            slime.ShowInfo();
//        }
//    }
//}
