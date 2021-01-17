using System;
using System.Collections.Generic;
using System.Text;

namespace Stardust_Crusaders
{
    class Encounters
    {

        public static Random rand = new Random();

        //Encounters generic

        //Encounters
        /*
        public static void basicFight()
        {
            Combat();
        }
        */
        public static void RandomEncounter()
        {
            switch (rand.Next(1, 4))
            {
                case 1:
                    Combat("Jens", 10, 2);
                    break;
                case 2:
                    Combat(Game.kalle.Name, Game.kalle.Health, Game.kalle.Damage);
                    break;
                case 3:
                    Combat("Jonna", 6, 8);
                    break;
            }

        }


        //Encounters tools

        public static void Combat(string name, int health, int damage)
        //public static void Combat()
        {
            //Check if the user bought any armor and the monster will deal less damage
            if (Game.currentPlayer.ArmorValue > 0)
            {
                damage = damage - Game.currentPlayer.ArmorValue;
            }

            //If the damage is negative, it would heal the player. so we need to put it to zero.
            if (damage < 0)
            {
                damage = 0;
            }

            while (health > 0)
            {
                Console.Clear();
                Console.WriteLine("Battle");
                Console.WriteLine(Game.currentPlayer.Name);
                Console.WriteLine(Game.currentPlayer.Health);
                Console.WriteLine($"{name}");
                Console.WriteLine($"{health}");
                Console.ReadKey();
                Console.WriteLine($"You attack the enemy and deals {Game.currentPlayer.Damage} damage");
                health -= Game.currentPlayer.Damage;
                Console.WriteLine($"The enemy attacks you and deals {damage} damage");
                Game.currentPlayer.Health -= damage;
                Console.ReadKey();
            }

            if (Game.currentPlayer.Health <= 0)
            {
                Console.WriteLine("You died. Game over.");
                System.Environment.Exit(0);
            }

            int c = rand.Next(10, 50);
            int d = rand.Next(25, 50);
            int currentGold = Game.currentPlayer.Gold;
            int currentExp = Game.currentPlayer.Experience;
            Console.WriteLine($"You won the battle and you get {c} gold and {d} experience from the enemy");
            Game.currentPlayer.Experience = currentExp + d;
            Game.currentPlayer.Gold = currentGold + c;

            //Check if level up
            Player.CharacterLevelCheck();

            Console.ReadKey();

        }

    }
}
