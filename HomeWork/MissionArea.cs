using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal class MissionArea
    {
        private MissionAreaData data { get; set; }
        public MissionArea(MissionAreaData areaData)
        {
            data = areaData;
        }

        public void Enter()
        {
            if (Player.level < data.RequiredLevel)
            {
                Console.WriteLine();
                Console.WriteLine($"{data.Name} 的進入等級不足！");
                Console.WriteLine($"需求等級：{data.RequiredLevel}");
                Console.WriteLine($"目前等級：{Player.level}");
                Console.WriteLine("按下任意鍵後返回");
                Console.ReadKey();
                ShowMenu();
                return;
            }
            Console.Clear();
            Console.WriteLine($"你進入了 {data.Name}！");
            Console.WriteLine($"需求等級：{data.RequiredLevel}");
            Monster monster = MonsterFactory.Create(data.monsterid);
            StartMission(monster);
            Player.ShowStatus();
            BattleCombat.Start(monster);
        }

        public void StartMission(Monster monster) // 接收目前任務要使用的怪物。
        {
            Console.WriteLine(); 
            Console.WriteLine(data.Introduction); // 顯示區域的劇情介紹。
            Console.WriteLine($"你遇見了 LV.{monster.Level} 的 {monster.Name}！"); // 顯示怪物名稱和等級。
            Console.WriteLine(monster.ExScription); // 顯示怪物描述。
            Console.WriteLine(); 
            monster.ShowStatus(); 
            Console.WriteLine("怪物展示完成，按任意鍵繼續。");
            Console.ReadKey(true); 
        }

        


        public static void ShowMenu()
        {
            MissionAreaData forestData = new MissionAreaData(
                "初心者森林",
                1,
                "陽光透過樹葉灑落，你聽見草叢傳來奇怪的聲音...",
                MonsterID.slime

            );

            MissionAreaData desertData = new MissionAreaData(
                "挑戰者沙丘",
                5,
                "你踏入炎熱的沙漠，遠處有怪物正在移動...",
                MonsterID.goblin
            );

            MissionAreaData swampData = new MissionAreaData(
                "熔岩沼澤",
                10,
                "灼熱的空氣迎面而來，四周流動著岩漿...",
                MonsterID.orc
            );

            MissionAreaData palaceData = new MissionAreaData(
                "海底宮殿",
                15,
                "你來到神秘的海底宮殿，古老的建築散發微光...",
                MonsterID.skeleton
            );

            MissionAreaData castleData = new MissionAreaData(
                "魔王城",
                20,
                "你站在魔王城的大門前，感受到強大的黑暗力量...",
                MonsterID.MAO
            );

            MissionArea forest = new MissionArea(forestData);
            MissionArea desert = new MissionArea(desertData);
            MissionArea swamp = new MissionArea(swampData);
            MissionArea palace = new MissionArea(palaceData);
            MissionArea castle = new MissionArea(castleData);

            Menu missionMenu = new Menu("請選擇任務區域");

            missionMenu.AddOption("初心者森林", ConsoleKey.A, () =>
            {
                forest.Enter();
            });

            missionMenu.AddOption("挑戰者沙丘", ConsoleKey.B, () =>
            {
                desert.Enter();
            });

            missionMenu.AddOption("熔岩沼澤", ConsoleKey.C, () =>
            {
                swamp.Enter();
            });

            missionMenu.AddOption("海底宮殿", ConsoleKey.D, () =>
            {
                palace.Enter();
            });

            missionMenu.AddOption("魔王城", ConsoleKey.E, () =>
            {
                castle.Enter();
            });

            missionMenu.Show();

            ConsoleKey key = Console.ReadKey(true).Key;

            Option opt = missionMenu.FindOption(key);

            if (opt != null)
            {
                opt.Run();
            }
        }
    }

}
