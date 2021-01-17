using System;
using System.IO;
using System.Media;
using System.Reflection;
using System.Threading;

namespace Stardust_Crusaders
{
    class Program
    {
        static void Main(string[] args)
        {

            //Start the game
            //Game.Start();

            playSound();

            //Enter the Main menu
            //Game.MainMenu();

        }

        public static void playSound()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = projectDirectory + "/Sounds/9098__ddohler__typewriter.wav";
            player.PlaySync();
            Console.ReadKey();
        }
    }
}
