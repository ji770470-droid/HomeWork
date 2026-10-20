using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork 
{
    internal static class MonsterFactory // 集中負責建立怪物。
    {
        public static Monster Create(MonsterID monsterId) // 根據怪物種類建立並回傳怪物。
        {
            switch (monsterId) // 檢查傳入的怪物種類。
            {
                case MonsterID.slime: // 要建立史萊姆時。
                    return new NormalMonster(); // 建立新的史萊姆物件。


                default: // 傳入尚未支援的怪物種類時。
                    throw new NotSupportedException( // 明確回報目前沒有建立方式。
                        $"尚未設定怪物種類：{monsterId}"); // 把缺少的種類放進錯誤訊息。
            }
        }
    }
}
