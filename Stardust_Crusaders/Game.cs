using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Text;

namespace Stardust_Crusaders
{
    class Game
    {
        //Creates the player
        public static Player currentPlayer = new Player();

        public static Monsters kalle = new Monsters("Kalle", 10, 2);

        //Sets up a bool that keeps the game running until you win or die
        public static bool keepPlaying = true;

        public static void Start()
        {
            Console.WriteLine("Name: ");
            currentPlayer.Name = Console.ReadLine();
            Console.Clear();
            print(currentPlayer.Name + ", Be safe on your travels in the wild wild world where many different critters live",40);
        }

        public static void MainMenu()
        {
            while (keepPlaying)
            {

                Console.Clear();
                Console.WriteLine("1. Walk around");
                Console.WriteLine("2.Character info");
                Console.WriteLine("3. Shop");
                Console.WriteLine("4. Exit");
                int input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        // Theres a 10 % chance that you dont encounter any enemies
                        if (Encounters.rand.Next(1, 10) == 1)
                        {
                            Console.WriteLine("You see nothing");
                            Console.ReadKey();
                        }
                        else
                        {
                            Encounters.RandomEncounter();
                        }
                        break;
                    case 2:
                        //Open method character information to show the current stats of your character
                        Player.CharacterInfo();
                        break;
                    case 3:
                        Shop.OpenShop();
                        break;
                    case 4:
                        ;
                        keepPlaying = false;
                        break;
                    default:
                        Console.WriteLine("Wrong input");
                        Console.ReadKey();
                        break;
                }
            }
        }

        //Typewriter effect function
        //To make the game get that jrpg feeling
        public static void print(string text, int speed = 70)
        {

            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(speed);
            }

            Console.WriteLine();
            Console.ReadKey();
        }

    }
}
