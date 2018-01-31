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
            string Text = "*The dark souls you died message apears*" + Environment.NewLine + "Hit space to restart...";
            TypeLine(Text);
            while (Console.ReadKey().Key != ConsoleKey.Spacebar) { };
            Console.Clear();
            Game();

        }

        private static void WinGame()
        {
            string Text = "Congrats, You won the game!" + Environment.NewLine + "Hit space to restart...";
            TypeLine(Text);
            while (Console.ReadKey().Key != ConsoleKey.Spacebar) { };
            Console.Clear();
            Game();

        }

        private static bool FoodRoom()
        {
            bool bRedPill = false;
            string sUserChoice = "";
            string Text = "You walk out into a eerie hall, with a small table facing you." + Environment.NewLine + "On the table are two pills, one red and one blue, with a note in front of each saying 'Eat me'. " + Environment.NewLine + "What do you do? ";
            TypeLine(Text);
            sUserChoice = Convert.ToString(Console.ReadLine());
            sUserChoice = sUserChoice.ToLower();
            if (sUserChoice == "eat red pill")
            {
                Text = "You eat the red pill, suddenly the world clapses around you and you wake up!" + Environment.NewLine;
                TypeLine(Text);

                bRedPill = true;
            }
            else
            {
                Text = "You try to " + sUserChoice + " , but suddenly the world folds in on itself and you become nothing..." + Environment.NewLine;
                TypeLine(Text);
            }
            return bRedPill;
        }

        private static bool Door()
        {
            int milliseconds = 100;
            string sUserChoice = "";
            string sUserName = "";
            bool bDoorOpens = false;
            sUserName = UserEnterName();
            string Text = "Welcome " + sUserName + " to your adventure! You wake in a cold dark room, and all you can see is a wooden door. " + Environment.NewLine + "What would you like to do? ";
            TypeLine(Text);
            sUserChoice = Convert.ToString(Console.ReadLine());
            sUserChoice = sUserChoice.ToLower();
            if (sUserChoice == "open door")
            {
                bDoorOpens = true;
                Text = "With a loud creak, the door opens!";
            }
            else
            {
                Text = "You try to " + sUserChoice + ", but nothing happens!" + Environment.NewLine;
                TypeLine(Text);
                Thread.Sleep(milliseconds);
                Text = "Your trapped forever!" + Environment.NewLine;
                TypeLine(Text);
                Thread.Sleep(milliseconds);
                Text = "Hit space to try again";
                TypeLine(Text);
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
           
            string Text = "Welcome!" + Environment.NewLine;
            TypeLine(Text);
            int milliseconds = 100;
            Thread.Sleep(milliseconds);
            Text = "Please adventurer, Enter Your name: ";
            TypeLine(Text);

            sUserName = Convert.ToString(Console.ReadLine());
           
            return sUserName;
        }

        private static void StartingStory()
        {
            
            string Text = "Hello," + Environment.NewLine;
            TypeLine(Text);
            int milliseconds = 100;
            Thread.Sleep(milliseconds);
            Text = "Enter space to start your story...";
            TypeLine(Text);
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
            string Text = "Are you sure you want to quit? ";
            TypeLine(Text);
            UserAnswer = Convert.ToString(Console.ReadLine());
            UserAnswer = UserAnswer.ToLower();
            if (UserAnswer == "yes")
            {
                Environment.Exit(1);
            }
        }
        static void TypeLine(string line)
        {
            for (int i = 0; i < line.Length; i++)
            {
                Console.Write(line[i]);
                System.Threading.Thread.Sleep(40); // Sleep for 150 milliseconds
            }
        }

    }
}
