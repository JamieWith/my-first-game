using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Rework
{
    class Program
    {

        static Player playerHp;

        static void Main(string[] args)
        {
            State currentScene = new State("");
            State moveCount = new State(0);
            Player potUse = new Player(1);
            playerHp = new Player(100);
            GameStart(currentScene, moveCount, potUse);
            
        }

        private static void GameStart(State currentScene, State moveCount, Player potUse)
        {
            var CanGameContinue = false;
            currentScene.CurerntScene = "Start menu";
            ConsoleKey SpaceCheck;
            Console.WriteLine("Space to start...");
            do
            {
                SpaceCheck = Console.ReadKey(true).Key;
                if (SpaceCheck == ConsoleKey.Spacebar)
                {
                    CanGameContinue = true;
                    FirstRoom(currentScene, moveCount, potUse);
                }
                else
                {
                    Console.WriteLine("Thats not the spacebar, try again...");
                } 
            } while (CanGameContinue != true);
        }

        private static void FirstRoom(State currentScene, State moveCount, Player potUse)
        {
            
            var rnd = new Random();
            currentScene.CurerntScene = "Room 1: Dungeon";
            moveCount.MoveCount = 0;
            Console.WriteLine("You awake in a dungeon cell with a rusty door. What do you do?");
            var UserInput = Convert.ToString(Console.ReadLine());
            UserInput = UserInput.ToLower();
            if (UserInput == "try door")
            {
                moveCount.MoveCount = moveCount.MoveCount + 1;
                Console.WriteLine("The door can be kicked down, but it might injure you.");
                Console.WriteLine("The door also has a lock, it looks like it could be picked..");
                UserInput = Convert.ToString(Console.ReadLine());
                UserInput = UserInput.ToLower();
                if (UserInput == "kick door")
                {
                    moveCount.MoveCount = moveCount.MoveCount + 1;
                    var RustDMG = rnd.Next(0, 7);
                    playerHp.PlayerHp = playerHp.PlayerHp - RustDMG;
                    Console.WriteLine("The door flies off its hinges!");
                    Console.WriteLine("But you take " + RustDMG + " damage from the rust!");
                    Console.WriteLine("HP: " + playerHp.PlayerHp);
                    SecondRoom(currentScene, moveCount, playerHp, potUse);

                }
                else if (UserInput == "pick lock")
                {
                    var DoorOpen = false;
                    moveCount.MoveCount = moveCount.MoveCount + 1;
                    Console.WriteLine("You go to pick the lock...");
                    var LockChance = rnd.Next(1, 5);
                    Console.WriteLine("Guess the number of cogs in the lock...(1 - 4)");
                    do
                    {
                        var LockChoice = Convert.ToInt16(Console.ReadLine());
                        moveCount.MoveCount = moveCount.MoveCount + 1;
                        if (LockChoice == LockChance)
                        {
                            Console.WriteLine("The door opens...");

                            DoorOpen = true;
                        }
                        else
                        {
                            playerHp.PlayerHp = playerHp.PlayerHp - 2;
                            Player.Check(playerHp.PlayerHp);
                            Console.WriteLine("The lockpick breaks and you cut youself!");
                            Console.WriteLine("HP: " + playerHp.PlayerHp);
                            
                        } 
                    } while (DoorOpen != true);
                    Console.WriteLine("Turn count: " + moveCount.MoveCount);
                    Console.WriteLine("HP: " + playerHp.PlayerHp);
                    SecondRoom(currentScene, moveCount, playerHp, potUse);

                }
            }

        }

        private static void SecondRoom(State currentScene, State moveCount, Player playerHp, Player potUse)
        {
            var rnd = new Random(); 
            var Wrongway = false;
            currentScene.CurerntScene = "Room 2: Hallway";
            Console.WriteLine("You're in a hallway. There are 2 ways you can go: left or right");
            Console.WriteLine("Where will you go?");
            do
            {
                var UserInput = Convert.ToString(Console.ReadLine());

                UserInput = UserInput.ToLower();
                if (UserInput == "left")
                {
                    moveCount.MoveCount = moveCount.MoveCount + 1;
                    Console.WriteLine("Its just a dead end...");

                }
                else if (UserInput == "right")
                {

                    Ladder(currentScene, moveCount, playerHp, potUse);

                }

                

            } while (Wrongway != true);



            Console.ReadKey();
        }

        private static void Ladder(State currentScene, State moveCount, Player playerHp, Player potUse)
        {
            currentScene.CurerntScene = "Ladder Room";
            moveCount.MoveCount = moveCount.MoveCount + 1;
            Console.WriteLine("There's a ladder going down...");
            var UserInput = Convert.ToString(Console.ReadLine());
            UserInput = UserInput.ToLower();
            if (UserInput == "go down ladder")
            {
                var rnd = new Random();
                moveCount.MoveCount = moveCount.MoveCount + 1;
                var LadderSlip = rnd.Next(0, 4);
                if (LadderSlip == 0)
                {
                    playerHp.PlayerHp = playerHp.PlayerHp - 10;
                    Player.Check(playerHp.PlayerHp);
                    Console.WriteLine("You slip on the ladder!");
                    Console.WriteLine("You take 10 damage");
                    Console.WriteLine("HP: " + playerHp.PlayerHp);
                    ThirdRoom(currentScene, moveCount, playerHp, potUse);

                }
                else
                {
                    moveCount.MoveCount = moveCount.MoveCount + 1;
                    ThirdRoom(currentScene, moveCount, playerHp, potUse);
                }
            }
        }

        private static void ThirdRoom(State currentScene, State moveCount, Player playerHp, Player potUse)
        {
            Hostile Spider = new Hostile(100);
            currentScene.CurerntScene = "Room 3: Sewer";
            playerHp.PlayerHp = playerHp.PlayerHp + playerHp.HpPot(potUse.HpPotUse, playerHp.PlayerHp);
            potUse.HpPotUse = potUse.HpPotUse - 1;
            Console.WriteLine("HP: " + playerHp.PlayerHp);
            Console.WriteLine("");
            Console.WriteLine("A large spider comes out of the black and attacks you!");
            Console.WriteLine("*Type battle to fight*");
            var UserInput = Convert.ToString(Console.ReadLine());
            UserInput = UserInput.ToLower();
            if (UserInput == "battle")
            {

                do
                {
                    Console.WriteLine("**Select an attack**");
                    Console.WriteLine("**Enter the corisponding number to do the attack**");
                    Console.WriteLine("1) Punch");
                    Console.WriteLine("2) Kick");
                    Console.WriteLine("3) Knee");
                    Console.WriteLine("4) Elbow");
                    var BattleInput = Convert.ToInt16(Console.ReadLine());
                    switch (BattleInput)
                    {
                        case 1:
                            Spider.HostileHp = Player.Punch(Spider.HostileHp);
                            Spider.SpiderAttackSelector(playerHp.PlayerHp);
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        default:
                            break;
                    } 
                } while (Spider.HostileHp > 0 || playerHp.PlayerHp > 0);
            }
            else
            {
                Console.WriteLine("You shoot back up the ladder!");
                Ladder(currentScene, moveCount, playerHp, potUse);
            }


            Console.ReadKey();
        }
    }
}
