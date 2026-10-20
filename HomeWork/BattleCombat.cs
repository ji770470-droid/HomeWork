using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork 
{
    internal static class BattleCombat // 戰鬥流程只需要共用方法，因此使用 static 類別。
    {
        private static readonly Random random = new Random();

        public static void Start(Monster monster) 
        {
            bool playerFirst; // 記錄玩家是否先攻。

            if (Player.spd > monster.SPD) // 玩家速度較高時。
            {
                playerFirst = true; // 玩家先攻。
            }
            else if (Player.spd < monster.SPD) // 怪物速度較高時。
            {
                playerFirst = false; // 怪物先攻。
            }
            else // 雙方速度相同時。
            {
                playerFirst = random.Next(0, 2) == 0; // 隨機決定玩家或怪物先攻。
            }

            Console.WriteLine(); // 空一行，讓戰鬥訊息更容易閱讀。
            Console.WriteLine(playerFirst ? "你比怪物快，取得先攻！" : "怪物比你快，取得先攻！"); // 顯示先攻結果。

            while (Player.IsAlive && monster.IsAlive) // 只要雙方都還活著，就繼續戰鬥。
            {
                if (playerFirst) // 玩家是先攻方時。
                {
                    PlayerTurn(monster); // 執行玩家回合。

                    if (monster.IsAlive) // 怪物被擊敗時不再反擊。
                    {
                        MonsterTurn(monster); // 執行怪物回合。
                    }
                }
                else // 怪物是先攻方時。
                {
                    MonsterTurn(monster); // 執行怪物回合。

                    if (Player.IsAlive) // 玩家被擊敗時不再攻擊。
                    {
                        PlayerTurn(monster); // 執行玩家回合。
                    }
                }

                Console.WriteLine(); 
                Console.WriteLine("按任意鍵繼續..."); 
                Console.ReadKey(true); 

             
            }

            if (monster.IsAlive == false) // 怪物死亡代表玩家獲勝。
            {
                Player.exp += monster.ExpReward; // 把怪物的經驗獎勵加入玩家經驗。
                Player.money += monster.MoneyReward; // 把怪物的金錢獎勵加入玩家金錢。

                Console.WriteLine();
                Console.WriteLine($"戰鬥勝利！獲得 {monster.ExpReward} 經驗和 {monster.MoneyReward} 金幣。"); // 顯示勝利獎勵。
            }
            else // 玩家死亡代表玩家落敗。
            {
                Console.WriteLine(); 
                Console.WriteLine("戰鬥失敗，你倒下了。"); // 顯示失敗訊息。
            }

            Console.WriteLine("按任意鍵返回..."); // 提示玩家準備離開戰鬥畫面。
            Console.ReadKey(true); 
        }

        private static void PlayerTurn(Monster monster) // 執行玩家的普通攻擊回合。
        {
            Console.WriteLine(); 
            Console.WriteLine("你發動普通攻擊！"); 

            if (RollChance(Player.ar) == false) // 依照玩家命中率判斷是否命中。
            {
                Console.WriteLine("你的攻擊沒有命中！"); 
                return; 
            }

            bool critical = RollChance(Player.ctr); // 依照玩家暴擊率判斷是否暴擊。
            int damage = CalculateDamage(Player.atk, monster.Def, critical); // 根據攻擊、防禦和暴擊計算最終傷害。

            if (critical) // 本次攻擊暴擊時。
            {
                Console.WriteLine("暴擊！"); // 顯示暴擊訊息。
            }

            monster.TakeDamage(damage); // 將算好的最終傷害交給怪物扣血。
        }

        private static void MonsterTurn(Monster monster) // 執行怪物的普通攻擊回合。
        {
            Console.WriteLine(); 
            int attack = monster.Attack(); 
            
            if (RollChance(Player.er)) // 依照玩家閃避率判斷是否成功閃避。
            {
                Console.WriteLine("你成功閃避了攻擊！"); 
                return; 
            }

            bool critical = RollChance(monster.CTR); 
            int damage = CalculateDamage(attack, Player.def, critical); 

            if (critical) // 本次怪物攻擊暴擊時。
            {
                Console.WriteLine("怪物打出暴擊！"); 
            }

            Player.TakeDamage(damage); // 將算好的最終傷害交給玩家扣血。
        }

        private static int CalculateDamage(int attack, int defense, bool critical) // 計算一次攻擊的最終傷害。
        {
            int baseDamage = Math.Max(1, attack - defense); // 計算攻擊減防禦，並確保至少造成 1 點基礎傷害。
            double randomRate = 0.9 + random.NextDouble() * 0.2; // 產生 0.9 到小於 1.1 的浮動倍率。
            double finalDamage = baseDamage * randomRate; // 套用傷害浮動倍率。

            if (critical) // 如果本次攻擊暴擊。
            {
                finalDamage *= 2; // 將傷害加倍。
            }

            return Math.Max(1, (int)Math.Round(finalDamage)); // 四捨五入成整數，並確保至少造成 1 點傷害。
        }

        private static bool RollChance(float chance) // 依照傳入的機率回傳成功或失敗。
        {
            double safeChance = Math.Max(0, Math.Min(1, chance)); // 將機率限制在 0 到 1 之間。
            return random.NextDouble() < safeChance; // 亂數小於機率時視為成功。
        }
    }
}
