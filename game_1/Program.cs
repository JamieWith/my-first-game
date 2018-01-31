using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Complete
            Game();

        }

        private static void Game()
        {
            bool bDoesDoorOpen = false;
            bool bEatRed = false;
            StartingStory();
            bDoesDoorOpen = Door();
            if (bDoesDoorOpen == true)
            {
                bEatRed = FoodRoom();
                if (bEatRed == true)
                {
                    WinGame();
                }
                else
                {
                    LoseGame();
                }
            }
        }

        private static void LoseGame()
        {
            Console.WriteLine("*The dark souls you died message apears*" + Environment.NewLine + "Hit space to restart...");
            while (Console.ReadKey().Key != ConsoleKey.Spacebar) { };
            Console.Clear();
            Game();

        }

        private static void WinGame()
        {
            Console.WriteLine("Congrats, You won the game!" + Environment.NewLine + "Hit space to restart...");
            while (Console.ReadKey().Key != ConsoleKey.Spacebar) { };
            Console.Clear();
            Game();

        }

        private static bool FoodRoom()
        {
            bool bRedPill = false;
            string sUserChoice = "";
            Console.Write("You walk out into a eerie hall, with a small table facing you." + Environment.NewLine + "On the table are two pills, one red and one blue, with a note in front of each saying 'Eat me'. " + Environment.NewLine + "What do you do? ");
            sUserChoice = Convert.ToString(Console.ReadLine());
            sUserChoice = sUserChoice.ToLower();
            if (sUserChoice == "eat red pill")
            {
                Console.WriteLine("You eat the red pill, suddenly the world clapses around you and you wake up!");
                bRedPill = true;
            }
            else
            {
                Console.WriteLine("You try to {0}, but suddenly the world folds in on itself and you become nothing...", sUserChoice);
            }
            return bRedPill;
        }

        private static bool Door()
        {
            int milliseconds = 900;
            string sUserChoie = "";
            string sUserName = "";
            bool bDoorOpens = false;
            sUserName = UserEnterName();
            Console.Write("Welcome {0} to your adventure! You wake in a cold dark room, and all you can see is a wooden door. " + Environment.NewLine + "What would you like to do? ", sUserName);
            sUserChoie = Convert.ToString(Console.ReadLine());
            sUserChoie = sUserChoie.ToLower();
            if (sUserChoie == "open door")
            {
                bDoorOpens = true;
                Console.WriteLine("With a loud creak, the door opens!");
            }
            else
            {
                Console.WriteLine("You try to {0}, but nothing happens!", sUserChoie);
                Thread.Sleep(milliseconds);
                Console.WriteLine("Your trapped forever!");
                Thread.Sleep(milliseconds);
                Console.WriteLine("Hit space to try again");
                while (Console.ReadKey().Key != ConsoleKey.Spacebar) { };
                Console.Clear();
                Game();

            }
            return bDoorOpens;
        }

        private static string UserEnterName()
        {

            Console.Clear();
            string sUserName = "";
           
            Console.WriteLine("Welcome!");
            int milliseconds = 900;
            Thread.Sleep(milliseconds);
            Console.Write("Please adventurer, Enter Your name: ");            
            sUserName = Convert.ToString(Console.ReadLine());
           
            return sUserName;
        }

        private static void StartingStory()
        {
            
            Console.WriteLine("Hello,");
            int milliseconds = 900;
            Thread.Sleep(milliseconds);
            Console.WriteLine("Enter space to start your story...");
            ConsoleKey test = Console.ReadKey().Key;
            if (test == ConsoleKey.Spacebar)
            {
               
            }
            else if (test == ConsoleKey.Escape)
            {
                Terminate();
            }
            else
            {
                StartingStory();
            }

            



        }
        private static void Terminate()
        {
            string UserAnswer = "";
            Console.Write("Are you sure you want to quit? ");
            UserAnswer = Convert.ToString(Console.ReadLine());
            UserAnswer = UserAnswer.ToLower();
            if (UserAnswer == "yes")
            {
                Environment.Exit(1);
            }
        }

    }
}
