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
        public static Monsters Jotaro = new Monsters("Jotaro Kujo", 10, 4);
        public static Monsters Polnaref = new Monsters("Jean Pierre Polnaref", 12, 3);
        public static Monsters Avdol = new Monsters("Mohammed Avdol", 8, 6);

        //Sets up a bool that keeps the game running until you win or die
        public static bool keepPlaying = true;

        //Public strings that helps getting a working directory path right to the project folder when wanting to acess files
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
                    Console.ReadKey();
                    Console.Clear();
                } 
                else if(tempName == "dio")
                {
                    Console.WriteLine($"Ah yes, {tempName}, of course that is your name. Anything else would be profound");
                    currentPlayer.Name = tempName;
                    playSound(Sounds.soundZaWarudo);
                    wrongName = false;
                    Console.ReadKey();
                }
                //God mode
                else if (tempName == "robin")
                {
                    Console.WriteLine($"Ah yes, {tempName}-senpai. God mode has been activated at your leisure");
                    Console.ReadKey();
                    currentPlayer.Name = tempName;
                    currentPlayer.Damage = 999;
                    currentPlayer.Health = 999;
                    Console.Clear();
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

                Console.WriteLine("********************");
                Console.WriteLine($"*{currentPlayer.Name} - Level {currentPlayer.Level}");
                Console.WriteLine("********************");
                Console.WriteLine("1. Walk around");
                Console.WriteLine("2.Character info");
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
                            Console.WriteLine("You see nothing");
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
                        //Opens method shop where you are able to buy amulets to increase
                        //Your strenght or Defense
                    case 3:
                        //Resets the bool statement loop for the shop so we can go in and out of it.
                        Shop.keepBuying = true;
                        Shop.OpenShop();
                        break;
                    case 4:
                        //This helps us exit the game by exiting the loop by changing keepPlaying to false
                        keepPlaying = false;
                        break;
                    default:
                        Console.WriteLine("Wrong input");
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
