using System;
using System.Collections.Generic;
using System.Text;

namespace Stardust_Crusaders
{
    class Shop
    {
        //Bool for helping us stay in a loop while being in the shop
        public static bool keepBuying = true;

        public static void OpenShop()
        {
            //As long as capitalism is at stake you stay in the store;)
            while (keepBuying)
            {
            Console.Clear();

                Console.WriteLine("Welcome to the shop. What would you like to buy");
                Console.WriteLine("1. Attack amulet - 50 Gold");
                Console.WriteLine("2. Toughness amulet - 50 Gold");
                Console.WriteLine("3. Exit the shop");
                int shopChoice = Convert.ToInt32(Console.ReadLine());

                //Check if the player wants to buy this item they gotta have enough gold
                //If the player has enough gold the player attack will be boosted
                if (shopChoice == 1 && Game.currentPlayer.Gold >= 50)
                {
                    int currentDamage = Game.currentPlayer.Damage;
                    int currentGold = Game.currentPlayer.Gold;
                    Game.currentPlayer.Damage = currentDamage + 2;
                    Game.currentPlayer.Gold = currentGold - 50;
                    Console.WriteLine("You bought an attack amulet, you deal greater damage");
                    Console.WriteLine("[Press enter...]");
                    Game.playSound(Sounds.soundNewItem);
                    Console.ReadKey();

                }
                //Check if the player wants to buy this item they gotta have enough gold
                //If the player has enough gold the player armor will be boosted
                else if (shopChoice == 2 && Game.currentPlayer.Gold >= 50)
                {
                    int currentArmor = Game.currentPlayer.ArmorValue;
                    int currentGold = Game.currentPlayer.Gold;
                    Game.currentPlayer.ArmorValue = currentArmor + 2;
                    Game.currentPlayer.Gold = currentGold - 50;
                    Console.WriteLine("You bought an toughness amulet, you take less damage");
                    Console.WriteLine("[Press enter...]");
                    Game.playSound(Sounds.soundNewItem);
                    Console.ReadKey();
                }
                //And if you dont have enough gold... display this message
                else if (shopChoice == 1 || shopChoice == 2 && Game.currentPlayer.Gold < 50)
                {
                    Console.WriteLine("You don't have ennough gold to buy this item.");
                    Console.WriteLine("[Press enter...]");
                    Console.ReadKey();
                    Console.Clear();
                }
                //Exit the shop
                else if (shopChoice == 3)
                {
                    Console.WriteLine("You exit the shop");
                    Console.WriteLine("[Press enter...]");
                    Console.ReadKey();
                    keepBuying = false;
                }
                //Or if you just typed the wrong input you will be asked to try again
                else
                {
                    Console.WriteLine("Wrong input. Please try again");
                    Console.WriteLine("[Press enter...]");
                    Console.ReadKey();
                }
            }
        }

    }
}
