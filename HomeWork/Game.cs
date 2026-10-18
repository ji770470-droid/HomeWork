using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal class Game
    {
        public void Start()
        {
            StoryBackground();
            GameStart();
        }
        public void StoryBackground()
        {
            Console.Clear();
            Console.WriteLine("很久以前……");
            Console.WriteLine("這片大陸曾經是一個和平的世界。");
            Console.WriteLine("直到某一天，黑暗力量突然甦醒……");
            Console.WriteLine();
            Console.WriteLine("按任意鍵繼續...");
            Console.ReadKey();
            Console.Clear();
        }
        public void GameStart()
        {

            Console.WriteLine("================================");
            Console.WriteLine("          遊戲開始");
            Console.WriteLine("================================");
            Console.WriteLine();
            Console.WriteLine("你站在一座陌生的城鎮前。");
            Console.WriteLine("前方的道路通往未知的世界。");
            Console.WriteLine("你的冒險正式開始了。");
            Console.WriteLine();
            Console.WriteLine("按任意鍵繼續...");
            Console.ReadKey();
        }

        public void StartMenu()
        {
            Menu mainmenu = new Menu("歡迎來到魔獸世界");

            mainmenu.AddOption("創建角色", ConsoleKey.C, () =>
            {
                CreateCharacter();
            });

            mainmenu.AddOption("離開遊戲", ConsoleKey.Q, () =>
            {
                Console.WriteLine("離開遊戲");
            });

            mainmenu.Show();

            ConsoleKey key = Console.ReadKey().Key;

            Option opt = mainmenu.FindOption(key);

            if (opt != null)
            {
                opt.Run();
            }
        }
        
        public void CreateCharacter()
        {
            Console.WriteLine();

            Menu jobMenu = new Menu("請選擇職業");
            jobMenu.AddOption("Warrior", ConsoleKey.A, () => {
                Player.SetJob(Player.Job.warrior);
                Player.ShowStatus();
            });
            jobMenu.AddOption("Mage", ConsoleKey.B, () => {
                Player.SetJob(Player.Job.mage);
                Player.ShowStatus();
            });
            jobMenu.AddOption("archer", ConsoleKey.C, () => {
                Player.SetJob(Player.Job.archer);
                Player.ShowStatus();
            });
            jobMenu.AddOption("thief", ConsoleKey.D, () => {
                Player.SetJob(Player.Job.thief);
                Player.ShowStatus();
            });

            jobMenu.Show();
            ConsoleKey key = Console.ReadKey().Key;

            Option opt = jobMenu.FindOption(key);

            if (opt != null)
            {
                opt.Run();
            }
        }

        public void GameMenu()
        {
            Menu gameMenu = new Menu("請選擇您的行動");

            gameMenu.AddOption("開始任務", ConsoleKey.A, () =>
            {
                MissionArea.ShowMenu();
            });
            //gameMenu.AddOption("背包", ConsoleKey.B);
            //gameMenu.AddOption("玩家資訊", ConsoleKey.C);
            //gameMenu.AddOption("離開遊戲", ConsoleKey.D);

            gameMenu.Show();
            ConsoleKey key = Console.ReadKey().Key;
            Option opt = gameMenu.FindOption(key);

            if (opt != null)
            {
                opt.Run();
            }
        }
       
    }
}
