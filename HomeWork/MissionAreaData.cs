using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HomeWork
{
    internal class MissionAreaData
    {
        // 區域基本資料
        public string Name { get; set; }
        public int RequiredLevel { get; set; }

        // 區域劇情
        public string Introduction { get; set; }

        public MonsterID monsterid { get; set; }

        // 建構子
        public MissionAreaData(
            string name,
            int requiredLevel,
            string introduction,
            MonsterID monsterId
        )
        {
            Name = name;
            RequiredLevel = requiredLevel;
            Introduction = introduction;
        }
    }
}
