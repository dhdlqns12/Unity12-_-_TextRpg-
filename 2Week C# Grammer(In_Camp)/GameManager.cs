using SpartaDungeon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameManager
{
    public class SaveData
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Hp { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public string Job { get; set; }
        public int Gold { get; set; }
        public int Stamina { get; set; }
        public int Exp { get; set; }

        public List<Item> playerInventory { get; set; }
        public List<Item> equipItem { get; set; }

        public SaveData() { }
        public SaveData(Player player, List<Item> _playerInventory, List<Item> _equipItem)
        {
            Name = player.Name;
            Level = player.Level;
            Hp = player.Hp;
            Atk = player.Atk;
            Def = player.Def;
            Job = player.Job;
            Gold = player.Gold;
            Stamina = player.Stamina;
            Exp = player.Exp;

            playerInventory = new List<Item>(_playerInventory);
            equipItem = new List<Item>(_equipItem);
        }
    }

    static class GameSaveManager
    {
        static string SavePath(int slot)
        {
            return $"SaveGame{slot}.json";
        }

        public static void GameSave(Player player, List<Item> _playerInventory, List<Item> _equipItem, int _slot)
        {
            SaveData data = new SaveData(player, _playerInventory, _equipItem);
            string json_Serialize = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true }); //WriteIndented(false)는 한줄로 압축,파일 크기 작음,사람이 읽기 어려움,네트워크 전송 또는 대용량 데이터에 유효
                                                            //Serialize는 data를 Json으로 변환                                          //WriteIndented(true)는  줄바꿈과 들여쓰기,파일크기 큼,사람이 읽기 쉬움,디버깅 편함,세이브파일,개발,디버깅중에는 유효
            File.WriteAllText(SavePath(_slot), json_Serialize);
        }

        public static SaveData GameLoad(int _slot)
        {
            string path = SavePath(_slot);

            string json_Deserialize = File.ReadAllText(path);
            SaveData data = JsonSerializer.Deserialize<SaveData>(json_Deserialize);

            return data;
        }

        public static bool HasSaveData(int _slot)
        {
            return File.Exists(SavePath(_slot));
        }
    }
}
