using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork 
{
    // 建立一般怪物的class
    internal class NormalMonster : Monster
    {
        
        public NormalMonster()
            : base(                      // 呼叫 Monster 的建構子。
                name: "史萊姆",      // 將名稱參數設成史萊姆。
                level: 1,                // 將等級設成 1。
                hp: 20,                  // 將最大血量與初始血量設成 20。
                atk: 9,                  // 將攻擊力設成 6。
                def: 2,                  // 將防禦力設成 1。
                spd: 3,                  // 將速度設成 2。
                ctr: 0f,                 // 教學怪物暫時不暴擊。
                expReward: 5,           // 擊敗後提供 10 經驗。
                moneyReward: 3,
                attackScription:"使用了史萊姆衝撞!",
                exScription:"黏黏滑滑的史萊姆，速度很慢，隨便一個成年人用木棒都能打倒"
               )       // 擊敗後提供 5 金錢。
        {
            
        }

        // 完成父類別要求的 Attack 方法。
        public override int Attack()
        {
            // 顯示這種怪物的專屬攻擊訊息。
            Console.WriteLine($"{Name}{AttackScription}");

            // 回傳原始攻擊傷害，尚未扣除玩家防禦。
            return Atk;
        }

        // 改寫資訊顯示方法，在共通資訊後追加教學提示。
        public override void ShowStatus()
        {
            // 先執行 Monster 原本的 ShowStatus，顯示名稱與數值。
            base.ShowStatus();
        }
    }
}