using System;
using System.Collections.Generic;
using System.Text;

namespace Stardust_Crusaders.Enemies
{
    class Monster : IMonster
    {
        public string Name { get ; set ; }
        public int Health { get ; set; }
        public int Damage { get; set ; }

        public static int mod = 1;
    }
}
