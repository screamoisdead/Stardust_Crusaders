using System;
using System.Collections.Generic;
using System.Text;

namespace Stardust_Crusaders.Enemies
{
    interface IMonster
    {
        string Name { get; set; }
        int Health { get; set; }
        int Damage { get; set; }

    }
}
