using System;
using System.Collections.Generic;
using System.Text;

namespace Stardust_Crusaders
{
    class Encounters
    {

        public static Random rand = new Random();

        //The method that is called to randomly select an enemy to battle
        public static void RandomEncounter()
        {
            switch (rand.Next(1, 4))
            {
                case 1:
                    Combat(Game.Polnaref.Name, Game.Polnaref.Health, Game.Polnaref.Damage);
                    break;
                case 2:
                    Combat(Game.Jotaro.Name, Game.Jotaro.Health, Game.Jotaro.Damage);
                    break;
                case 3:
                    Combat(Game.Avdol.Name, Game.Avdol.Health, Game.Avdol.Damage);
                    break;
            }
        }

        public static void Combat(string name, int health, int damage)
        {
            //Here we set tht edifficulty modifier
            //Once you reach a higher level, the tougher the enemies will get
            health = health * Monsters.mod;
            damage = damage * Monsters.mod;

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

            //We have to set the battle in a loop to make it turn based where you deal and recieve damage
            //Until either you or the enemy dies.
            while (health > 0)
            {
                Console.Clear();
                Console.WriteLine("*******Battle*******");
                Console.WriteLine(Game.currentPlayer.Name);
                Console.WriteLine($"Health: {Game.currentPlayer.Health}");
                Console.WriteLine("********************");
                Console.WriteLine($"{name}");
                Console.WriteLine($"Health: {health}");
                Console.WriteLine("********************");
                Console.ReadKey();
                Console.WriteLine($"You attack the enemy and deals {Game.currentPlayer.Damage} damage");

                //To vary a bit between the sounds of attack
                switch (rand.Next(1,3))
                {
                    case 1:
                        Game.playSound(Sounds.soundAttackOne);
                        break;
                    case 2:
                        Game.playSound(Sounds.soundAttackTwo);
                        break;
                }

                health -= Game.currentPlayer.Damage;
                Console.WriteLine($"The enemy attacks you and deals {damage} damage");
                Game.playSound(Sounds.soundOuch);
                Game.currentPlayer.Health -= damage;
                Console.ReadKey();
            }

            //If you die. the game ends.
            //Good bye.
            if (Game.currentPlayer.Health <= 0)
            {
                Console.WriteLine("You died. Game over.");
                Game.playSound(Sounds.soundPlayerDie);
                Console.ReadKey();
                System.Environment.Exit(0);
            }

            //This is where we go when we win the battle
            //Gold and Experience is randomly selected and added to the character
            int c = rand.Next(10, 50);
            int d = rand.Next(25, 50);
            int currentGold = Game.currentPlayer.Gold;
            int currentExp = Game.currentPlayer.Experience;
            Console.WriteLine($"You won the battle and you get {c} gold and {d} experience from the enemy");
            Game.playSound(Sounds.soundMuda);
            Game.currentPlayer.Experience = currentExp + d;
            Game.currentPlayer.Gold = currentGold + c;

            Console.ReadKey();

            //We check if the character levels up with this method
            Player.CharacterLevelCheck();

        }

    }
}
