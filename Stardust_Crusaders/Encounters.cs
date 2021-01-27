using System;
using System.Collections.Generic;
using System.Text;

namespace Stardust_Crusaders
{
    class Encounters
    {
        //New random call
        public static Random rand = new Random();

        //The method that is called to randomly select an enemy to battle
        public static void RandomEncounter()
        {
            //We use the rand(Random) function here to randomize which one of the monsters the player will face
            switch (rand.Next(1, 4))
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("A new enemy appears in front of you.");
                    Console.WriteLine("[Press enter...]");
                    Game.playSound(Sounds.soundEncounter);
                    Console.ReadKey();
                    //Opens the method that will make you fight the enemy called Polnaref
                    Combat(Game.Polnaref.Name, Game.Polnaref.Health, Game.Polnaref.Damage);
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("A new enemy appears in front of you.");
                    Console.WriteLine("[Press enter...]");
                    Game.playSound(Sounds.soundEncounter);
                    Console.ReadKey();
                    //Opens the method that will make you fight the enemy called Jotaro
                    Combat(Game.Jotaro.Name, Game.Jotaro.Health, Game.Jotaro.Damage);
                    Game.playSound(Sounds.soundEncounter);
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("A new enemy appears in front of you.");
                    Console.WriteLine("[Press enter...]");
                    Game.playSound(Sounds.soundEncounter);
                    Console.ReadKey();
                    //Opens the method that will make you fight the enemy called Avdol
                    Combat(Game.Avdol.Name, Game.Avdol.Health, Game.Avdol.Damage);
                    break;
            }
        }

        //The method that will engage the player in a fight, takes in argument from the instantiated monsters
        //And the arguments are the name, their health and their damage
        public static void Combat(string name, int health, int damage)
        {

            //Check if the user bought any armor and the monster will deal less damage
            if (Game.currentPlayer.ArmorValue > 0)
            {
                damage = damage - Game.currentPlayer.ArmorValue;
            }

            //If the user buys too much armor bonus, it would make the enemies to deal negative damage
            //That would heal the player. So we need this to just put the damage at 0 in this case
            if (damage < 0)
            {
                damage = 0;
            }

            //Once you gain levels the monsters will become stronger and deal more damage
            health = health * Monsters.mod;
            damage = damage * Monsters.mod;

            //We have to set the battle in a loop to make it turn based where you deal and recieve damage
            //Until either you or the enemy dies.
            while (health > 0)
            {
                //Battle log
                Console.Clear();
                Console.WriteLine("*******Battle*******");
                Console.WriteLine(Game.currentPlayer.Name);
                Console.WriteLine($"Health: {Game.currentPlayer.Health}");
                Console.WriteLine("********************");
                Console.WriteLine($"{name}");
                Console.WriteLine($"Health: {health}");
                Console.WriteLine("********************");
                Console.ReadKey();

                //Shows how much damage the player deals
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

                //The ammount of damage the player deals will be subtracted from the monster each round
                health -= Game.currentPlayer.Damage;
                //Shows how much damage the monster deals to the player
                Console.WriteLine($"The enemy attacks you and deals {damage} damage");

                //To vary a bit between the sounds of being hit by the enemy
                switch (rand.Next(1, 3))
                {
                    case 1:
                        Game.playSound(Sounds.soundOuch);
                        break;
                    case 2:
                        Game.playSound(Sounds.soundOuchTwo);
                        break;
                }       
                //The ammount of damage the monster deals will be subtracted from the player each round
                Game.currentPlayer.Health -= damage;

                //Press enter for a next round of fighting
                Console.WriteLine("[Press enter...]");
                Console.ReadKey();

                //If you run out of health. you will die
                //And the game will end
                if (Game.currentPlayer.Health <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("It seems like the enemy has defeated you");
                    Console.WriteLine("You have died. Please try the game again");
                    Game.playSound(Sounds.soundPlayerDie);
                    Console.WriteLine("[Press enter...]");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }
            }

            //This is where we go when we win the battle
            //Gold and Experience is randomly selected and added to the character
            Console.Clear();
            int c = rand.Next(10, 50);
            int d = rand.Next(25, 50);
            int currentGold = Game.currentPlayer.Gold;
            int currentExp = Game.currentPlayer.Experience;
            Console.WriteLine($"You won the battle and you get {c} gold and {d} experience from the enemy");
            Game.playSound(Sounds.soundMuda);
            Game.currentPlayer.Experience = currentExp + d;
            Game.currentPlayer.Gold = currentGold + c;

            Console.WriteLine("[Press enter...]");
            Console.ReadKey();

            //Before we exit the battle we need to check if the player has enough experience to level up
            //This function checks the current level of the player, how much exp they have
            //And what the cap is for the next level
            Player.CharacterLevelCheck();

        }
    }
}
