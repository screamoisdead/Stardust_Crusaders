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

        //Creates the enemies that are possible to face in this game
        public static Enemies.Polnaref polnaref = new Enemies.Polnaref();
        public static Enemies.Jotaro jotaro = new Enemies.Jotaro();
        public static Enemies.Avdol avdol = new Enemies.Avdol();

        //Sets up a bool that keeps the game running until you win or die
        public static bool keepPlaying = true;

        //Public strings that helps getting a working directory path right to the project folder when wanting to acess files
        //In this case its used to create a relative path to the audio files im using in the game
        //Rather than the default is that its stuck in /bin/debug/netcoreapp3.1/
        public static string workingDirectory = Environment.CurrentDirectory;
        public static string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

        //This is the start screen where you get to select your name
        public static void Start()
        {
            //Welcome text to the game
            Console.WriteLine(" ,---.   ,--.                    ,--.                ,--.          ");
            Console.WriteLine("'   .-',-'  '-. ,--,--.,--.--. ,-|  |,--.,--. ,---.,-'  '-.  ");
            Console.WriteLine("`.  `-.'-.  .-'' ,-.  ||  .--'' .-. ||  ||  |(  .-''-.  .-'");
            Console.WriteLine(".-'    | |  |  \\ '-'  ||  |   \\ `-' |'  ''  '.-'  `) |  |  ");
            Console.WriteLine("`-----'  `--'   `--`--'`--'    `---'  `----' `----'  `--'  ");
            Console.WriteLine(" ,-----.                                 ,--.                      ");
            Console.WriteLine("'  .--./,--.--.,--.,--. ,---.  ,--,--. ,-|  | ,---. ,--.--. ,---.");
            Console.WriteLine("|  |    |  .--'|  ||  |(  .-' ' ,-.  |' .-. || .-. :|  .--'(  .-' ");
            Console.WriteLine("'  '--'\\|  |   '  ''  '.-'  `)\\ '-'  |\\ `-' |\\   --.|  |   .-'  `) ");
            Console.WriteLine(" `-----'`--'    `----' `----'  `--`--' `---'  `----'`--'   `----'  ");
            Console.WriteLine("                      -Press enter to start-");
            Console.ReadKey();
            Console.Clear();

            //Ask the player for their player name
            //But you can only use one name to start the game
            //Which of course is Dio.
            //Or if your name is robin...
            //Then you activate the god mode
            bool wrongName = true;
            while(wrongName)
            { 
                string tempName;
                Console.WriteLine("Traveler, what is your name?");
                tempName = Console.ReadLine().ToLower();
                if(tempName != "dio" && tempName != "robin")
                {
                    Console.WriteLine($"{tempName}, sounds like an awful name... maybe try the name dio instead.");
                    Console.WriteLine("[Press enter...]");
                    Console.ReadKey();
                    Console.Clear();
                } 
                else if(tempName == "dio")
                {
                    Console.WriteLine($"Ah yes, {tempName}, of course that is your name. Anything else would be profound");
                    currentPlayer.Name = tempName;
                    playSound(Sounds.soundZaWarudo);
                    wrongName = false;
                    Console.WriteLine("[Press enter...]");
                    Console.ReadKey();
                }
                //God mode
                else if (tempName == "robin")
                {
                    Console.WriteLine($"Ah yes, {tempName}-senpai. God mode has been activated at your leisure");
                    Console.WriteLine("[Press enter...]");
                    Console.ReadKey();
                    currentPlayer.Name = tempName;
                    currentPlayer.Damage = 999;
                    currentPlayer.Health = 999;
                    wrongName = false;
                }
            }
        }

        //This is the main menu where most of the game is happening
        public static void MainMenu()
        {
            while (keepPlaying)
            {
               
                Console.Clear();

                //A smaller character overview with name, level and current health
                Console.WriteLine("********************");
                Console.WriteLine($"* {currentPlayer.Name} - Level {currentPlayer.Level}");
                Console.WriteLine($"* Health - {currentPlayer.Health}");
                Console.WriteLine("********************");
                Console.WriteLine("1. Walk around");
                Console.WriteLine("2. Character info");
                Console.WriteLine("3. Shop");
                Console.WriteLine("4. Exit");
                int input = Convert.ToInt32(Console.ReadLine());

                //Here you decide what choice you will make
                switch (input)
                {
                    case 1:
                        //Opens the method where we are able to fight monsters
                        //But there is also a 10% chance that we dont see any monster
                        if (Encounters.rand.Next(1, 10) == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("You are looking for trouble, but nobody seems to be up for the challenge");
                            playSound(Sounds.soundNothing);
                            Console.WriteLine("[Press enter...]");
                            Console.ReadKey();
                        }
                        else
                        {
                            //Opens the method where a enemy is randomly selected
                            Encounters.RandomEncounter();
                        }
                        break;
                    case 2:
                        //Open method character information to show the current stats of your character
                        Player.CharacterInfo();
                        break;
                    case 3:
                        //Resets the bool statement loop for the shop so we can go in and out of it.
                        Shop.keepBuying = true;
                        //Opens the method shop where you are able to boost your character
                        //With the help from attack or defence amulets
                        Shop.OpenShop();
                        break;
                    case 4:
                        //This helps us exit the game by exiting the loop by changing keepPlaying to false
                        keepPlaying = false;
                        break;
                    default:
                        //If you didnt put in any of the right choices you will be asked to try again
                        Console.WriteLine("Wrong input");
                        Console.WriteLine("[Press enter...]");
                        Console.ReadKey();
                        break;
                }
            }
        }

        //Method that helps playing soundeffects
        //You just define the pathway to the sounds folder
        //And this is where we get help from the projectDirectory string to get a relative path
        //Rather than using a absolute which wouldnt make it so dynamic
        public static void playSound(string audioPath)
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = projectDirectory + audioPath;
            player.PlaySync();
        }

    }
}
