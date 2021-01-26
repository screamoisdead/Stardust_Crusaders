using System;
using System.Collections.Generic;
using System.Text;

namespace Stardust_Crusaders
{
    class Player
    {

        private string name;
        private int health = 100;
        private int damage = 2;
        private int level = 1;
        private int experience = 0;
        private int gold = 0;
        private int armorValue = 0;

        //Level caps
        public static int levelTwoCap = 50;
        public static int levelThreeCap = 100;
        public static int levelFourCap = 150;
        public static int levelFiveCap = 200;
        public static int levelSixCap = 250;
        public static int levelSevenCap = 300;
        public static int levelEightCap = 350;
        public static int levelNineCap = 400;
        public static int levelTenCap = 450;

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

        public int Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
            }
        }

        public int Experience
        {
            get
            {
                return experience;
            }
            set
            {
                experience = value;
            }
        }

        public int Gold
        {
            get
            {
                return gold;
            }
            set
            {
                gold = value;
            }
        }

        public int ArmorValue
        {
            get
            {
                return armorValue;
            }
            set
            {
                armorValue = value;
            }
        }

        public Player()
        {

        }

        public Player(
            string name
        )

        {
            this.name = name;
        }

        //Method to display the current character information
        //Which can be acessed through the main menu
        public static void CharacterInfo()
        {
            Console.Clear();
            Console.WriteLine("Character status");
            Console.WriteLine($"Name: {Game.currentPlayer.name}");
            Console.WriteLine($"Health: {Game.currentPlayer.health}");
            Console.WriteLine($"Gold: {Game.currentPlayer.gold}");
            Console.WriteLine($"Level: {Game.currentPlayer.level}");
            Console.WriteLine($"Experience: {Game.currentPlayer.experience}");
            Console.WriteLine($"Armor: {Game.currentPlayer.ArmorValue}");
            Console.WriteLine($"Damage: {Game.currentPlayer.damage}");
            Console.ReadKey();
            Game.MainMenu();

        }

        //Method that checks if the character meets the requirement to level up
        //Also checks if you reached the maximum level which is the endgame event
        //Meaning you won the game!
        public static void CharacterLevelCheck()
        {
            Console.Clear();

            if (Game.currentPlayer.experience > levelTwoCap && Game.currentPlayer.level == 1)
            {
                Game.currentPlayer.level = 2;
                int currentHealth = Game.currentPlayer.health;
                Game.currentPlayer.health = currentHealth + 10;
                Console.WriteLine("You reached level 2! and you are healed for 10 points");
                Game.playSound(Sounds.soundLevelUp);
                Console.ReadKey();

            }
            else if (Game.currentPlayer.experience > levelThreeCap && Game.currentPlayer.level == 2)
            {
                Game.currentPlayer.level = 3;
                int currentHealth = Game.currentPlayer.health;
                Game.currentPlayer.health = currentHealth + 10;
                Console.WriteLine("You reached level 3! and you are healed for 10 points");
                Console.WriteLine("And your enemies grow stronger");
                Monsters.mod = 2;
                Game.playSound(Sounds.soundLevelUp);
                Console.ReadKey();
            }
            else if (Game.currentPlayer.experience > levelFourCap && Game.currentPlayer.level == 3)
            {
                Game.currentPlayer.level = 4;
                Console.WriteLine("You reached level 4! and you are healed for 10 points");
                Game.playSound(Sounds.soundLevelUp);
                Console.ReadKey();

            }
            else if (Game.currentPlayer.experience > levelFiveCap && Game.currentPlayer.level == 4)
            {
                Game.currentPlayer.level = 5;
                Console.WriteLine("You reached level 5! and you are healed for 10 points");
                Game.playSound(Sounds.soundLevelUp);
                Console.ReadKey();
            }

            /*
            Console.WriteLine("Congratulations, you reached the final level.");
            Console.WriteLine("It means you won the game");
            Game.playSound(Sounds.soundMudaMudaMuda);
            Console.ReadKey();
            System.Environment.Exit(0);
            */
        }

    }
}
