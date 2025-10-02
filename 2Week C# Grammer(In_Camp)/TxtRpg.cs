using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Util;
using GameManager;

namespace SpartaDungeon
{
    public enum Item
    {
        Iron_Armor,
        Old_Sword,
        Traning_Spear,
        Sparta_Armor,
        Sparta_Spear,
        Iron_Axe,
        Hp_Potion
    }

    struct ItemInfo
    {
        public string name;
        public string type;
        public int value;
        public string description;
        public int price;

        public ItemInfo(string _name, string _type, int _value, string _description, int _price)
        {
            name = _name;
            type = _type;
            value = _value;
            description = _description;
            price = _price;
        }
    }

    public class Character
    {
        public string Name { get; protected set; }
        public int Level { get; set; }
        public int Hp { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }

        public Character(string _name, int _level, int _hp, int _atk, int _def)
        {
            Name = _name;
            Level = _level;
            Hp = _hp;
            Atk = _atk;
            Def = _def;
        }
    }

    public class Player : Character
    {
        public string Job { get; protected set; }
        public int Gold { get; set; }
        public int Stamina { get; set; }
        public int Exp { get; set; }

        public Player(string _name, int _level, int _hp, int _atk, int _def, string _job, int _gold, int _stamina, int _exp) : base(_name, _level, _hp, _atk, _def)
        {
            Job = _job;
            Gold = _gold;
            Stamina = _stamina;
            Exp = _exp;
        }
    }

    public class Monster
    {

    }

    public class Skill
    {

    }

    class InGame
    {
        static Dictionary<Item, ItemInfo> itemData;
        static List<Item> playerInventory = new List<Item>();
        static List<Item> equipItem = new List<Item>();
        static List<Item> shopItem = new List<Item>();

        private const int STAMINA_ADVENTURE = 10;
        private const int STAMINA_PATROL = 5;
        private const int STAMINA_TRAINING = 15;
        private const int POTION_HEAL = 5;
        private const int MAX_HP = 100;
        private const int MAX_STAMINA = 30;

        static int[] req_Def = { 5, 11, 17 };
        static int[] arr_reqExp = { 50, 80, 150, 500 };

        static void Main()
        {
            Console.Title = "스파르탄 던전";
            Player player = new Player("플레이어", 1, MAX_HP, 1, 1, "무직", 0, MAX_STAMINA, 0);
            Console.CursorVisible = false;
            Init();
            Start(player);
        }

        static void Init()
        {
            itemData = ItemInit();

            foreach (Item item in Enum.GetValues(typeof(Item)))
            {
                shopItem.Add(item);
            }
        }

        static void Turn()
        {

        }

        static void Battle()
        {

        }

        static void Start(Player player)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.\n이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n");
            Console.ResetColor();
            Console.WriteLine("1. 상태보기\n2. 인벤토리\n3. 랜덤 모험\n4. 마을 순찰하기\n5. 훈련하기\n6. 상점\n7. 던전입장\n8. 휴식\n9. 저장/불러오기\n\n0. 게임종료");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            Console.ResetColor();

            while (true)
            {
                int input = Utility.IntInput();

                if (input == 1)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("상태보기를 선택했습니다.\n");
                    Console.ResetColor();
                    Status(player);
                    break;
                }
                else if (input == 2)
                {
                    Console.Clear();
                    Console.WriteLine("인벤토리를 선택했습니다.\n");
                    Inven(player);
                    break;
                }
                else if (input == 3)
                {
                    if (player.Stamina < STAMINA_ADVENTURE)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("스태미나가 부족합니다.");
                        Console.ResetColor();
                        Console.Write(">>");
                    }
                    else
                    {
                        RandomAdventure(player);
                        player.Stamina -= STAMINA_ADVENTURE;
                        Console.Write(">>");
                    }
                }
                else if (input == 4)
                {
                    if (player.Stamina < STAMINA_PATROL)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("스태미나가 부족합니다.");
                        Console.ResetColor();
                        Console.Write(">>");
                    }
                    else
                    {
                        TownPatrol(player);
                        player.Stamina -= STAMINA_PATROL;
                        Console.Write(">>");
                    }
                }
                else if (input == 5)
                {
                    if (player.Stamina < STAMINA_TRAINING)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("스태미나가 부족합니다.");
                        Console.ResetColor();
                        Console.Write(">>");
                    }
                    else
                    {
                        Training(player);
                        player.Stamina -= STAMINA_TRAINING;
                        Console.Write(">>");
                    }
                }
                else if (input == 6)
                {
                    Shop(player);
                    break;
                }
                else if (input == 7)
                {
                    Dungeon(player);
                    break;
                }
                else if (input == 8)
                {
                    Rest(player);
                    break;
                }
                else if (input == 9)
                {
                    SaveLoad(player);
                    break;
                }
                else if (input == 0)
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }

        static void Status(Player player)
        {
            ShowInfo_Player(player);
            Console.WriteLine($"\n0. 나가기\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            Console.ResetColor();

            while (true)
            {
                int input = Utility.IntInput();

                if (input == 0)
                {
                    Start(player);
                    break;
                }
                else
                {
                    Console.WriteLine("0번을 입력해 나가주세요");
                    Console.Write(">>");
                }
            }
        }

        static Dictionary<Item, ItemInfo> ItemInit()
        {
            Dictionary<Item, ItemInfo> itemData = new Dictionary<Item, ItemInfo>()
            {
                {Item.Iron_Armor,new ItemInfo("무쇠갑옷","방어력",5,"무쇠로 무쇠로 만들어져 튼튼한 갑옷입니다.",1000)},
                {Item.Old_Sword,new ItemInfo("낡은 검","공격력",2,"쉽게 볼 수 있는 낡은 검 입니다.",600)},
                {Item.Traning_Spear,new ItemInfo("연습용 창","공격력",3,"검보다는 그래도 창이 다루기 쉽죠.",900)},
                {Item.Sparta_Armor,new ItemInfo("스파르타의 갑옷","방어력",15,"스파르타의 전사들이 사용했다는 전설의 갑옷입니다.",3500)},
                {Item.Sparta_Spear,new ItemInfo("스파르타의 창","공격력",9,"스파르타의 전사들이 사용했다는 전설의 창입니다.",3500)},
                {Item.Iron_Axe,new ItemInfo("철도끼","공격력",5,"어디선가 사용됐던거 같은 도끼입니다.",1500)},
                {Item.Hp_Potion,new ItemInfo("HP포션","회복",5,"체력은 채워야지.",500)}
            };

            return itemData;
        }

        static void Inven(Player player)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("=인벤토리=\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("보유 중인 아이템이 표시됩니다.\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("[아이템 목록]");
            Console.ResetColor();
            playerInventory = playerInventory.OrderByDescending(item => itemData[item].name).ToList();

            for (int i = 0; i < playerInventory.Count; i++)
            {
                Item item = playerInventory[i];
                ItemInfo itemInfo = itemData[item];
                Console.WriteLine($"- {Utility.PaddingKorean_Right(itemInfo.name, 20)}|{Utility.PaddingKorean_Center(itemInfo.type + " " + itemInfo.value, 14)}| {Utility.PaddingKorean_Right(itemInfo.description, 30)}");
            }

            Console.WriteLine($"\n1. 장착관리");
            Console.WriteLine($"0. 나가기");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            Console.ResetColor();

            while (true)
            {
                Console.Write(">>");

                int input = Utility.IntInput();

                if (input == 1)
                {
                    EquipManager(player);
                    break;
                }
                else if (input == 0)
                {
                    Start(player);
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }

        static void EquipManager(Player player)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("=인벤토리=\n");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("[아이템 목록]");
                Console.ResetColor();

                for (int i = 0; i < playerInventory.Count; i++)
                {
                    Item item = playerInventory[i];
                    ItemInfo itemInfo = itemData[item];

                    bool isEquip = IsEquipIndex(i);

                    if (isEquip)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("[E]");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("- ");
                    }

                    Console.WriteLine($"{Utility.PaddingKorean_Right(itemInfo.name, 20)}|{Utility.PaddingKorean_Center(itemInfo.type + " " + itemInfo.value, 14)}| {Utility.PaddingKorean_Right(itemInfo.description, 30)}");
                }

                Console.WriteLine("\n0. 나가기");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n원하시는 행동을 입력해주세요.");
                Console.Write(">>");
                Console.ResetColor();

                int input = Utility.IntInput();

                if (input == 0)
                {
                    Inven(player);
                    break;
                }
                else if (input >= 1 && input <= playerInventory.Count)
                {
                    int selectIndex = input - 1;
                    EquipToggle(selectIndex, player);
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }

        static bool IsEquipIndex(int invIndex)
        {
            return equipItem.Contains(playerInventory[invIndex]);
        }

        static void EquipToggle(int invIdex, Player player)
        {
            Item selectedItem = playerInventory[invIdex];

            if (equipItem.Contains(selectedItem))
            {
                equipItem.Remove(selectedItem);
            }
            else if (playerInventory.Contains(selectedItem) && selectedItem == Item.Hp_Potion)
            {
                UsePotion(player);
                equipItem.Remove(selectedItem);
                playerInventory.Remove(selectedItem);
            }
            else
            {
                ItemInfo selectItemInfo = itemData[selectedItem];

                for (int i = equipItem.Count - 1; i >= 0; i--)//처음에 foreach사용해서 변경할려 했으나 foreach문에선 순회 중 수정 불가능하단게 기억이 안났어서 시간 좀 걸렸었음
                {
                    Item equippedItem = equipItem[i];
                    if (itemData.TryGetValue(equippedItem, out ItemInfo equippedInfo))
                    {
                        if (equippedInfo.type == selectItemInfo.type)
                        {
                            equipItem.RemoveAt(i);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"아이템 없음: {equippedItem}");
                        equipItem.RemoveAt(i);
                    }
                }
                equipItem.Add(selectedItem);
            }
        }

        static void Shop(Player player)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("==상점==");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.ResetColor();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.Gold} G\n");
            shopItem = shopItem.OrderBy(item => itemData[item].price).ToList();

            for (int i = 0; i < itemData.Count; i++)
            {
                Item item = shopItem[i];
                ItemInfo itemInfo = itemData[item];
                Console.WriteLine($"- {Utility.PaddingKorean_Right(itemInfo.name, 20)}|{Utility.PaddingKorean_Center(itemInfo.type + " " + itemInfo.value, 14)}| " +
                    $"{Utility.PaddingKorean_Right(itemInfo.description, 50)}|{Utility.PaddingKorean_Right(itemInfo.price.ToString() + " G", 10)}");
            }

            Console.WriteLine("\n1. 아이템 구매\n2. 아이템 판매\n0. 나가기\n");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n원하시는 행동을 입력해주세요.");
                Console.Write(">>");
                Console.ResetColor();

                int input = Utility.IntInput();

                if (input == 1)
                {
                    ShopBuy(player);
                    break;
                }
                else if (input == 2)
                {
                    ShopSell(player);
                    break;
                }
                else if (input == 0)
                {
                    Start(player);
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }

        static void ShopBuy(Player player)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("==상점==");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.ResetColor();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.Gold} G\n");

            for (int i = 0; i < shopItem.Count; i++)
            {
                Item item = shopItem[i];
                ItemInfo itemInfo = itemData[item];

                bool isPurchase = playerInventory.Contains(item);

                if (isPurchase && itemInfo.type != "회복")
                {
                    Console.WriteLine($"- {i + 1} {Utility.PaddingKorean_Right(itemInfo.name, 20)}|{Utility.PaddingKorean_Center(itemInfo.type + " " + itemInfo.value, 14)}| " +
                                             $"{Utility.PaddingKorean_Right(itemInfo.description, 50)}|{Utility.PaddingKorean_Right("구매완료", 10)}");
                }
                else
                {
                    Console.WriteLine($"- {i + 1} {Utility.PaddingKorean_Right(itemInfo.name, 20)}|{Utility.PaddingKorean_Center(itemInfo.type + " " + itemInfo.value, 14)}| " +
                                              $"{Utility.PaddingKorean_Right(itemInfo.description, 50)}|{Utility.PaddingKorean_Right(itemInfo.price.ToString() + " G", 10)}");
                }
            }

            Console.WriteLine("\n0. 나가기\n");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n원하시는 행동을 입력해주세요.");
                Console.Write(">>");
                Console.ResetColor();

                int input = Utility.IntInput();

                if (input == 0)
                {
                    Shop(player);
                    break;
                }
                else if (input <= shopItem.Count)
                {
                    Item selectItem = shopItem[input - 1];
                    ItemInfo selectItemInfo = itemData[selectItem];

                    if (playerInventory.Contains(selectItem) && selectItemInfo.name != "HP포션")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("이미 구매한 아이템입니다.");
                        Console.ResetColor();
                    }
                    else
                    {
                        if (player.Gold >= selectItemInfo.price)
                        {
                            player.Gold -= selectItemInfo.price;
                            playerInventory.Add(selectItem);
                            Console.WriteLine($"{selectItemInfo.name}을 구매했습니다.");
                            ShopBuy(player);
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("골드가 부족합니다.");
                            Console.ResetColor();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }

        static void ShopSell(Player player)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("==상점==");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.ResetColor();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.Gold} G\n");

            for (int i = 0; i < playerInventory.Count; i++)
            {
                Item item = playerInventory[i];
                ItemInfo itemInfo = itemData[item];

                Console.WriteLine($"- {i + 1} {Utility.PaddingKorean_Right(itemInfo.name, 20)}|{Utility.PaddingKorean_Center(itemInfo.type + " " + itemInfo.value, 14)}| " +
                                          $"{Utility.PaddingKorean_Right(itemInfo.description, 50)}|{Utility.PaddingKorean_Right((itemInfo.price * 0.85f).ToString() + " G", 10)}");

            }

            Console.WriteLine("\n0. 나가기\n");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n원하시는 행동을 입력해주세요.");
                Console.Write(">>");
                Console.ResetColor();

                int input = Utility.IntInput();

                if (input == 0)
                {
                    Shop(player);
                    break;
                }
                else if (input <= playerInventory.Count)
                {
                    Item selectItem = playerInventory[input - 1];
                    ItemInfo selectItemInfo = itemData[selectItem];

                    player.Gold += (int)(selectItemInfo.price * 0.85f);
                    playerInventory.Remove(selectItem);
                    equipItem.Remove(selectItem);
                    Console.WriteLine($"{selectItemInfo.name}을 판매했습니다.");
                    ShopSell(player);
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }

        static void ShowInfo_Player(Player player)
        {
            int bonusAtk = GetBonusAtk();
            int bonusDef = GetBonusDef();

            Console.WriteLine($"이름: {player.Name}\n");
            Console.WriteLine($"Lv.{player.Level}  EXP:{player.Exp}\n");
            Console.WriteLine($"직업: {player.Job}");
            Console.WriteLine($"체력: {player.Hp}");

            if (bonusAtk > 0)
            {
                Console.WriteLine($"공격력: {player.Atk} (+{bonusAtk})");
            }
            else
            {
                Console.WriteLine($"공격력: {player.Atk}");
            }

            if (bonusDef > 0)
            {
                Console.WriteLine($"방어력: {player.Def} (+{bonusDef})");
            }
            else
            {
                Console.WriteLine($"방어력: {player.Def}");
            }
            Console.WriteLine($"Gold: {player.Gold}");
            Console.WriteLine($"스태미나: {player.Stamina}");
        }

        static void UsePotion(Player player)
        {
            player.Hp += POTION_HEAL;
        }

        static void RandomAdventure(Player player)
        {
            Random ran = new Random();
            int ranNum = ran.Next(1, 3);

            switch (ranNum)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("몬스터 조우! 골드 500 획득");
                    Console.ResetColor();
                    player.Gold += 500;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("아무 일도 일어나지 않았다.");
                    Console.ResetColor();
                    break;
            }
        }

        static void TownPatrol(Player player)
        {
            Random ran = new Random();

            var events = new[]
            {
                (10, "마을 아이들이 모여있다. 간식을 사줘볼까?",-500),
                (20,"촌장님을 만나서 심부름을 했다.",2000),
                (40, "길 읽은 사람을 안내해주었다.",1000),
                (70, "마을 주민과 인사를 나눴다. 선물을 받았다.",500),
                (100, "아무 일도 일어나지 않았다",0)
            };

            int ranNum = ran.Next(1, 101);

            foreach (var (percent, message, gold) in events)//튜플 사용,break를 활용한 누적값 계산, 나중에 Json으로 받아올 수 있게 도전해볼까?
            {
                if (ranNum <= percent)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(message);
                    Console.ResetColor();
                    player.Gold += gold;
                    break;
                }
            }
        }

        static void Training(Player player)
        {
            Random ran = new Random();

            var events = new[]
            {
                (15, "훈련이 잘 되었습니다!",60),
                (75,"오늘하루 열심히 훈련했습니다.",40),
                (100, "하기 싫다... 훈련이...",30)
            };

            int ranNum = ran.Next(1, 101);

            foreach (var (percent, message, exp) in events)
            {
                if (ranNum <= percent)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(message);
                    Console.ResetColor();
                    player.Exp += exp;
                    CheckLevelUp(player);
                    break;
                }
            }
        }

        static void Dungeon(Player player)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("==던전입장==");
            Console.ResetColor();
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");

            string[] dungeonName = { "쉬운 던전", "일반 던전", "어려운 던전" };
            int[] rewardGold = { 1000, 1700, 2500 };
            int[] rewardExp = { 50, 100, 200 };

            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"{i}. {Utility.PaddingKorean_Right(dungeonName[i - 1], 14)}| 방어력 {req_Def[i - 1]}이상 권장");
            }

            Console.WriteLine("\n0. 나가기");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n원하시는 행동을 입력해주세요.");
                Console.Write(">>");
                Console.ResetColor();

                int input = Utility.IntInput();

                if (input >= 1 && input <= 3)
                {
                    Random ran = new Random();
                    int ranNum = ran.Next(1, 101);
                    int totalDef = player.Def + GetBonusDef();
                    int damage = 0;
                    bool isFail = (totalDef < req_Def[input - 1]) && (ranNum <= 40);

                    if (isFail)
                    {
                        damage = (int)Math.Round(CalcDamage(player, input - 1) / 2f);
                        DungeonResult(player, dungeonName[input - 1], false, damage, input - 1, rewardGold, rewardExp);
                    }
                    else
                    {
                        damage = CalcDamage(player, input - 1);
                        DungeonResult(player, dungeonName[input - 1], true, damage, input - 1, rewardGold, rewardExp);
                    }
                }
                else if (input == 0)
                {
                    Start(player);
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }

        static int CalcDamage(Player player, int index)
        {
            Random ran = new Random();
            int ranNum = ran.Next(20, 36);

            int totalDef = player.Def + GetBonusDef();
            int def_Dif = totalDef - req_Def[index];
            int damage = ranNum - def_Dif;

            if (damage <= 0)
            {
                damage = 0;
            }

            return damage;
        }

        static int[] CalcReward(Player player, int index, int[] rewardGold, int[] rewardExp)
        {
            Random ran = new Random();
            int totalAtk = player.Atk + GetBonusAtk();
            int bonus = ran.Next(totalAtk, (totalAtk * 2) + 1);

            int gold = (int)Math.Round(rewardGold[index] * (100 + bonus) / 100.0);
            int exp = (int)Math.Round(rewardExp[index] * (100 + bonus) / 100.0);

            return new int[] { gold, exp };
        }

        static void DungeonResult(Player player, string name, bool isSuccess, int damage, int dungeonIndex, int[] rewardGold, int[] rewardExp)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            int curHp = player.Hp;
            int curGold = player.Gold;

            player.Hp -= damage;

            if (isSuccess)
            {
                int[] rewards = CalcReward(player, dungeonIndex, rewardGold, rewardExp);
                player.Gold += rewards[0];
                player.Exp += rewards[1];
                CheckLevelUp(player);
            }

            if (isSuccess)
            {
                Console.Clear();
                Console.WriteLine("==던전 클리어==");
                Console.ResetColor();
                Console.WriteLine($"축하합니다!\n{name}을 클리어 하였습니다.");
                Console.WriteLine("\n[탐험 결과]");
                Console.WriteLine($"체력 {curHp} -> {curHp - damage}");
                Console.WriteLine($"Gold {curGold} -> {player.Gold}");
                Console.WriteLine("\n0. 나가기");
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n원하시는 행동을 입력해주세요.");
                    Console.Write(">>");
                    Console.ResetColor();

                    int input = Utility.IntInput();

                    if (input == 0)
                    {
                        Dungeon(player);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("==던전 실패==");
                Console.ResetColor();
                Console.WriteLine($"{name}을 실패 하셨습니다.");
                Console.WriteLine("\n[탐험 결과]");
                Console.WriteLine($"체력 {curHp} -> {curHp - damage}");
                Console.WriteLine("\n0. 나가기");

                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n원하시는 행동을 입력해주세요.");
                    Console.Write(">>");
                    Console.ResetColor();

                    int input = Utility.IntInput();

                    if (input == 0)
                    {
                        Dungeon(player);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }
                }
            }
        }

        static void Rest(Player player)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("==휴식하기==");
            Console.ResetColor();
            Console.WriteLine($"500G를 내면 체력을 회복할 수 있습니다. (보유 골드: {player.Gold}G)");

            Console.WriteLine("\n1. 휴식하기\n0. 나가기");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            Console.ResetColor();

            while (true)
            {
                Console.Write(">>");

                int input = Utility.IntInput();

                if (input == 1)
                {
                    if (player.Gold >= 500)
                    {
                        int curHp = player.Hp;
                        int curStamina = player.Stamina;
                        player.Gold -= 500;

                        if (player.Hp + 100 > 100)
                        {
                            player.Hp = 100;
                        }
                        else
                        {
                            player.Hp += 100;
                        }

                        if (player.Stamina + 20 > 30)
                        {
                            player.Stamina = 30;
                        }
                        else
                        {
                            player.Stamina += 20;
                        }

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("휴식을 완료했습니다.");
                        Console.WriteLine($"\n체력 {curHp} -> {player.Hp}");
                        Console.WriteLine($"\n스태미나 {curStamina} ->{player.Stamina}");
                    }
                    else
                    {
                        Console.WriteLine("\n골드가 부족합니다.");
                    }
                }
                else if (input == 0)
                {
                    Start(player);
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }

        static void CheckLevelUp(Player player)
        {
            if (player.Level >= 5)
            {
                return;
            }

            int reqExp = arr_reqExp[player.Level - 1];

            while (player.Exp >= reqExp && player.Level < 5)
            {
                player.Exp -= reqExp;

                player.Level++;

                player.Atk += 1;
                player.Def += 2;

                if (player.Level < 5)
                {
                    reqExp = arr_reqExp[player.Level - 1];
                }
            }
        }

        static int GetBonusAtk()
        {
            int bonus = 0;
            foreach (Item item in equipItem)
            {
                ItemInfo itemInfo = itemData[item];
                if (itemInfo.type == "공격력")
                {
                    bonus += itemInfo.value;
                }
            }
            return bonus;
        }

        static int GetBonusDef()
        {
            int bonus = 0;
            foreach (Item item in equipItem)
            {
                ItemInfo itemInfo = itemData[item];
                if (itemInfo.type == "방어력")
                {
                    bonus += itemInfo.value;
                }
            }
            return bonus;
        }

        static void SaveLoad(Player player, string message = "")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("==게임 저장 및 로드==\n");
            Console.ResetColor();

            if (!string.IsNullOrEmpty(message))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(message);
                Console.ResetColor();
                Console.WriteLine();
            }

            for (int i = 1; i <= 3; i++)
            {
                if (GameSaveManager.HasSaveData(i))
                {
                    Console.WriteLine($"{i}. 슬롯{i} 저장 데이터 있음");
                }
                else
                {
                    Console.WriteLine($"{i}. 슬롯{i} 비어있음");
                }
            }

            Console.WriteLine("\n0. 나가기");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            Console.ResetColor();

            while (true)
            {
                int input = Utility.IntInput();

                if (input >= 1 && input <= 3)
                {
                    if (GameSaveManager.HasSaveData(input))
                    {
                        Console.WriteLine("\n1. 저장\n2. 불러오기\n0. 취소");
                        int saveLoadInput = Utility.IntInput();

                        if (saveLoadInput == 1)
                        {
                            GameSaveManager.GameSave(player, playerInventory, equipItem, input);
                            SaveLoad(player, $"슬롯 {input}에 저장되었습니다.");
                            break;
                        }
                        else if (saveLoadInput == 2)
                        {
                            SaveData data = GameSaveManager.GameLoad(input);

                            if (data != null)
                            {
                                Player newPlayer = new Player(
                                    data.Name,
                                    data.Level,
                                    data.Hp,
                                    data.Atk,
                                    data.Def,
                                    data.Job,
                                    data.Gold,
                                    data.Stamina,
                                    data.Exp
                                );

                                playerInventory = data.playerInventory;
                                equipItem = data.equipItem;

                                Start(newPlayer);
                                break;
                            }
                        }
                        else if (saveLoadInput == 0)
                        {
                            SaveLoad(player);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                        }
                    }
                    else
                    {
                        GameSaveManager.GameSave(player, playerInventory, equipItem, input);
                        SaveLoad(player, $"슬롯 {input}에 저장되었습니다.");
                    }
                }
                else if (input == 0)
                {
                    Start(player);
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }
    }
}


//추가 작업
//-->협업 중요시...
//-->분배? 기능 추가? 분배 가능하게끔 스크립트 나누는거 고민 해 보기

