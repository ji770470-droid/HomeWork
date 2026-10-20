using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork 
{
    internal static class MonsterFactory // 集中負責建立怪物。
    {
        internal class MonsterData // 保存怪物的固定設定資料。
        {
            public string Name { get; } // 保存怪物名稱。
            public int Level { get; } // 保存怪物等級。
            public int Hp { get; } // 保存怪物最大血量。
            public int Atk { get; } // 保存怪物攻擊力。
            public int Def { get; } // 保存怪物防禦力。
            public int Spd { get; } // 保存怪物速度。
            public float Ctr { get; } // 保存怪物暴擊率。
            public int ExpReward { get; } // 保存經驗獎勵。
            public int MoneyReward { get; } // 保存金錢獎勵。
            public string AttackDescription { get; } // 保存怪物攻擊時的文字。
            public string Description { get; } // 保存怪物介紹文字。

            public MonsterData( // 建立一份怪物設定資料。
                string name, // 接收怪物名稱。
                int level, // 接收怪物等級。
                int hp, // 接收最大血量。
                int atk, // 接收攻擊力。
                int def, // 接收防禦力。
                int spd, // 接收速度。
                float ctr, // 接收暴擊率。
                int expReward, // 接收經驗獎勵。
                int moneyReward, // 接收金錢獎勵。
                string attackDescription, // 接收攻擊描述。
                string description) // 接收怪物介紹。
            {
                Name = name; // 保存怪物名稱。
                Level = level; // 保存怪物等級。
                Hp = hp; // 保存最大血量。
                Atk = atk; // 保存攻擊力。
                Def = def; // 保存防禦力。
                Spd = spd; // 保存速度。
                Ctr = ctr; // 保存暴擊率。
                ExpReward = expReward; // 保存經驗獎勵。
                MoneyReward = moneyReward; // 保存金錢獎勵。
                AttackDescription = attackDescription; // 保存攻擊描述。
                Description = description; // 保存怪物介紹。
            }
        }

        private static readonly MonsterData slimeData = new MonsterData( // 保存史萊姆的固定資料。
            name: "史萊姆", // 設定名稱。
            level: 1, // 設定等級。
            hp: 20, // 設定最大血量。
            atk: 9, // 設定攻擊力。
            def: 2, // 設定防禦力。
            spd: 3, // 設定速度。
            ctr: 0f, // 設定暴擊率。
            expReward: 5, // 設定經驗獎勵。
            moneyReward: 3, // 設定金錢獎勵。
            attackDescription: "使用了史萊姆衝撞！", // 設定攻擊描述。
            description: "黏黏滑滑的史萊姆，速度很慢。" // 設定怪物介紹。
        );

        public static Monster Create(MonsterID monsterId) // 根據怪物種類建立並回傳怪物。
        {
            switch (monsterId) // 檢查傳入的怪物種類。
            {
                case MonsterID.slime: // 要建立史萊姆時。
                    return new Monster(slimeData); // 建立新的史萊姆物件。


                default: // 傳入尚未支援的怪物種類時。
                    throw new NotSupportedException( // 明確回報目前沒有建立方式。
                        $"尚未設定怪物種類：{monsterId}"); // 把缺少的種類放進錯誤訊息。
            }
        }
    }
}
