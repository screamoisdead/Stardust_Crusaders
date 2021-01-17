using System;
using System.Collections.Generic;
using System.Text;

namespace Stardust_Crusaders
{
    class Monsters
    {

        private string name;
        private int health;
        private int damage;

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

        public Monsters(string name, int health, int damage)
        {
            this.name = name;
            this.health = health;
            this.damage = damage;
        }

    }
}
