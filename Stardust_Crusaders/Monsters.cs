using System;
using System.Collections.Generic;
using System.Text;

namespace Stardust_Crusaders
{
    class Monsters
    {
        //Fields
        private string name;
        private int health;
        private int damage;
        public static int mod = 1;

        //Properties
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }

        public int Damage
        {
            get
            {
                return damage;
            }
            set
            {
                damage = value;
            }
        }

        //Constructor
        public Monsters(string name, int health, int damage)
        {
            this.name = name;
            this.health = health;
            this.damage = damage;
        }

    }
}
