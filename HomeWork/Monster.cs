using System; // 使用 Console 與 Math。

namespace HomeWork // 與其他作業檔案保持相同命名空間。
{
    // Monster 是所有怪物的共同基底。
    // abstract 表示不能直接 new Monster。
    // IDamageable 表示怪物具有「可以受傷」的能力。
    internal abstract class Monster : IDamageable
    {
        // 怪物名稱：外部可讀取，建立後不能直接修改。
        public string Name { get; }

        // 怪物等級：由建構子設定。
        public int Level { get; }

        // 當前血量：外部可讀取，只有 Monster 內部可設定。
        public int Hp { get; private set; }

        // 最大血量：建立怪物時決定。
        public int MaxHp { get; }

        // 攻擊力：供怪物的攻擊方法讀取。
        public int Atk { get; }

        // 防禦力：受到傷害時使用。
        public int Def { get; }

        // 速度：預留給 BattleCombat 判斷出手順序。
        public int SPD { get; }

        // 暴擊率：使用 float，0.05f 代表 5%。
        public float CTR { get; }

        // 擊敗這隻怪物可獲得的經驗。
        public int ExpReward { get; }

        // 擊敗這隻怪物可獲得的金錢。
        public int MoneyReward { get; }
        
        public string AttackScription { get; }

        public string ExScription { get; }

        // 提供外部判斷怪物是否還活著。
        public bool IsAlive
        {
            // 每次讀取 IsAlive，都依照目前血量重新判斷。
            get
            {
                return Hp > 0; // 血量大於 0 回傳 true，否則回傳 false。
            }
        }

        // 父類別建構子：供子類別透過 base(...) 呼叫。
        protected Monster(
            string name,     // 接收怪物名稱。
            int level,       // 接收怪物等級。
            int hp,          // 接收初始血量與最大血量。
            int atk,         // 接收攻擊力。
            int def,         // 接收防禦力。
            int spd,         // 接收速度。
            float ctr,       // 接收暴擊率。
            int expReward,   // 接收經驗獎勵。
            int moneyReward, // 接收金錢獎勵。
            string attackScription,
            string exScription) 
        {
            Name = name; // 保存名稱。

            Level = Math.Max(1, level); // 等級最低為 1。

            MaxHp = Math.Max(1, hp); // 最大血量最低為 1。

            Hp = MaxHp; // 新建立的怪物從滿血開始。

            Atk = Math.Max(0, atk); // 攻擊力最低為 0。

            Def = Math.Max(0, def); // 防禦力最低為 0。

            SPD = Math.Max(0, spd); // 速度最低為 0。

            CTR = Math.Max(0f, Math.Min(1f, ctr)); // 暴擊率限制在 0～1。

            ExpReward = Math.Max(0, expReward); // 經驗獎勵不能是負數。

            MoneyReward = Math.Max(0, moneyReward); // 金錢獎勵不能是負數。
            AttackScription = attackScription;
            ExScription = exScription;
        }

        // 每種具體怪物都必須提供自己的攻擊實作。
        
        public abstract int Attack();

        // 實作 IDamageable 規定的受傷方法。
        public void TakeDamage(int rawDamage)
        {
            // 如果怪物已死亡，就不再處理傷害。
            if (!IsAlive)
            {
                return; // 結束這次方法呼叫。
            }


            
            int damage = Math.Max(0, rawDamage);

            // 實際損失不能超過剩餘血量。
            int actualDamage = Math.Min(Hp, damage);

            // 更新當前血量。
            Hp -= actualDamage;

            // 顯示本次真正損失的血量與剩餘血量。
            Console.WriteLine(
                $"{Name} 受到 {actualDamage} 點傷害，HP：{Hp}/{MaxHp}");

            // 扣血後再次檢查是否死亡。
            if (!IsAlive)
            {
                // 只顯示死亡訊息，獎勵留給 BattleCombat 結算。
                Console.WriteLine($"{Name} 被擊敗了！");
            }
        }

        // 提供預設資訊顯示方式，子類別可以 override。
        public virtual void ShowStatus()
        {
            Console.WriteLine("===== 怪物資訊 ====="); // 顯示標題。
            Console.WriteLine($"名稱：{Name}"); // 顯示名稱。
            Console.WriteLine($"等級：{Level}"); // 顯示等級。
            Console.WriteLine($"HP：{Hp}/{MaxHp}"); // 顯示當前與最大血量。
            Console.WriteLine($"攻擊力：{Atk}"); // 顯示攻擊力。
            Console.WriteLine($"防禦力：{Def}"); // 顯示防禦力。
            Console.WriteLine($"速度：{SPD}"); // 顯示速度。
            Console.WriteLine($"暴擊率：{CTR:P0}"); // 將小數顯示為百分比。
        }
    }
}