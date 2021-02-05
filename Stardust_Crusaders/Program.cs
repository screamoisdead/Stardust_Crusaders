using Stardust_Crusaders.Enemies;
using System;
using System.IO;
using System.Media;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Stardust_Crusaders
{

    class Program
    {
        static void Main(string[] args)
        {

            //Start the game
            Game.Start();

            //Enter the Main menu
            Game.MainMenu();

        }
    }
}
