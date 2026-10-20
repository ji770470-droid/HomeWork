using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal class Player
    {
        public enum Job
        {
            warrior,
            mage,
            archer,
            thief
        }

        public static bool IsAlive
        {
            // 每次讀取時，根據當前血量重新判斷。
            get
            {
                return hp > 0; // 血量大於 0 代表存活。
            }
        }

        // 接收怪物造成的原始傷害，在這裡扣除玩家防禦。
        public static void TakeDamage(int rawDamage)
        {
            // 玩家已死亡時，不再處理傷害。
            if (!IsAlive)
            {
                return; // 結束本次方法呼叫。
            }

            int damage=Math.Max(0,rawDamage);

            // 真正扣掉的血量，不超過玩家目前的血量。
            int actualDamage = Math.Min(hp, damage);

            // 更新玩家血量。
            hp -= actualDamage;

            // 顯示實際扣血與剩餘血量。
            Console.WriteLine($"你受到 {actualDamage} 點傷害，剩餘 HP：{hp}/{MaxHp}");

            // 檢查這次受傷是否導致玩家死亡。
            if (!IsAlive)
            {
                Console.WriteLine("你倒下了！"); // 顯示死亡訊息。
            }
        }

        public static int _level = 1;
        public static Job job;
        public static int level 
        {
            get
            {
                return _level;
            } 
            set
            {
                if(value > 20)
                {
                    _level = 20;
                }
                else
                {
                    _level = value;
                }
            }
        }
        public static int exp;
        public static int money;
        public static int str;
        public static int _int;
        public static int luk;
        public static int dex;
        public static int hp;
        public static int MaxHp;
        public static int mp;
        public static int def;
        public static int atk;
        public static int spd;
        public static float ctr;
        public static float ar;
        public static float er;

      

        public static void SetJob(Job newjob)
        {
            job = newjob;
            SetJobStats();
        }
        public static void SetJobStats()
        {
            switch (job)
            {
                case Job.warrior:
                    str=level * 3;
                    _int=level * 1;
                    luk=level * 1;
                    dex=level * 1;
                    MaxHp=108+level * 12;
                    hp=MaxHp;
                    mp = level * 4;
                    def=level * 6;
                    atk = level * 7;
                    spd=level * 4;
                    ctr=0.04f;
                    ar=0.90f;
                    er=0.03f;
                    break;
                case Job.mage:
                    str = level * 1;
                    _int = level * 3;
                    luk = level * 1;
                    dex = level * 1;
                    MaxHp = 60+level * 5;
                    hp = MaxHp;
                    mp = level * 12;
                    def = level * 2;
                    atk = level * 8;
                    spd = level * 4;
                    ctr = 0.05f;
                    ar = 0.85f;
                    er = 0.02f;
                    break;
                case Job.archer:
                    str = level * 1;
                    _int = level * 1;
                    luk = level * 1;
                    dex = level * 3;
                    MaxHp = 80+level * 8;
                    hp = MaxHp;
                    mp = level * 6;
                    def = level * 3;
                    atk = level * 9;
                    spd = level * 8;
                    ctr = 0.08f;
                    ar = 0.98f;
                    er = 0.16f;
                    break;
                case Job.thief:
                    str = level * 1;
                    _int = level * 1;
                    luk = level * 3;
                    dex = level * 2;
                    MaxHp = 78+level * 8;
                    hp = MaxHp;
                    mp = level * 7;
                    def = level * 3;
                    atk = level * 9;
                    spd = level *8;
                    ctr = 0.18f;
                    ar = 0.94f;
                    er = 0.13f;
                    break;
            }
        }
        public static void ShowStatus()
        {
            Console.WriteLine();
            Console.WriteLine("===== 玩家資訊 =====");
            Console.WriteLine($"職業：{job}");
            Console.WriteLine($"等級：{level}");
            Console.WriteLine($"金錢：{money}");
            Console.WriteLine($"生命值：{hp}/{MaxHp}");
            Console.WriteLine($"魔力：{mp}");
            Console.WriteLine($"力量：{str}");
            Console.WriteLine($"智力：{_int}");
            Console.WriteLine($"運氣：{luk}");
            Console.WriteLine($"敏捷：{dex}");
            Console.WriteLine($"攻擊力：{atk}");
            Console.WriteLine($"防禦力：{def}");
            Console.WriteLine($"速度：{spd}");
            Console.WriteLine($"暴擊率：{ctr:P0}");
            Console.WriteLine($"命中率：{ar:P0}");
            Console.WriteLine($"閃避率：{er:P0}");
            Console.WriteLine("====================");
            Console.WriteLine("按下任意鍵繼續...");
            Console.ReadKey(true);
        }
    }
}
