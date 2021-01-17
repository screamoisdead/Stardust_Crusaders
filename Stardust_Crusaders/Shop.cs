using System;
using System.Collections.Generic;
using System.Text;

namespace Stardust_Crusaders
{
    class Shop
    {


        public static void OpenShop()
        {

            Console.WriteLine("Welcome to the shop. What would you like to buy");
            Console.WriteLine("1. Attack amulet - 50 Gold");
            Console.WriteLine("2. Toughness amulet - 50 Gold");
            int shopChoice = Convert.ToInt32(Console.ReadLine());

            if (shopChoice == 1 && Game.currentPlayer.Gold >= 50)
            {
                int currentDamage = Game.currentPlayer.Damage;
                int currentGold = Game.currentPlayer.Gold;
                Game.currentPlayer.Damage = currentDamage + 2;
                Game.currentPlayer.Gold = currentGold - 50;
                Console.WriteLine("You bought an attack amulet, you deal greater damage");
                Console.ReadKey();

            }
            else if (shopChoice == 2 && Game.currentPlayer.Gold >= 50)
            {
                int currentArmor = Game.currentPlayer.ArmorValue;
                int currentGold = Game.currentPlayer.Gold;
                Game.currentPlayer.ArmorValue = currentArmor + 2;
                Game.currentPlayer.Gold = currentGold - 50;
                Console.WriteLine("You bought an toughness amulet, you take less damage");
                Console.ReadKey();
            }
        }

    }
}
