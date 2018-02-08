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
        static State moveCount;
        static State currentScene;
        static Player potUse;

        static void Main(string[] args)
        {
            currentScene = new State("");
            potUse = new Player(1);
            playerHp = new Player(100);
            moveCount = new State(0);
            GameStart();

        }

        private static void GameStart()
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
                    FirstRoom();
                }
                else
                {
                    Console.WriteLine("Thats not the spacebar, try again...");
                }
            } while (CanGameContinue != true);
        }

        private static void FirstRoom()
        {
            int LockChoice = 0;
            int LockChance = 0;
            int attemptcount = 0;
            int attemptcount2 = 0;
            bool complete;
            bool complete2 = false;
            bool complete3 = false;
            var rnd = new Random();
            currentScene.CurerntScene = "Room 1: Dungeon";
            moveCount.MoveCount = 0;
            do
            {
                Console.WriteLine("You awake in a dungeon cell with a rusty door. What do you do?");
                var UserInput = Convert.ToString(Console.ReadLine());
                UserInput = UserInput.ToLower();
                if (UserInput == "try door")
                {
                    complete = true;
                    moveCount.MoveCount = moveCount.MoveCount + 1;
                    do
                    {
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
                            SecondRoom();

                        }
                        else if (UserInput == "pick lock")
                        {

                            complete2 = true;
                            var DoorOpen = false;
                            moveCount.MoveCount = moveCount.MoveCount + 1;
                            Console.WriteLine("You go to pick the lock...");
                            LockChance = rnd.Next(1, 5);
                            
                            do
                            {
                                do
                                {
                                    try
                                    {
                                        Console.WriteLine("Guess the number of cogs in the lock...(1 - 4)");
                                        LockChoice = Convert.ToInt16(Console.ReadLine());
                                        complete3 = true;
                                    }
                                    catch (Exception)
                                    {

                                        Console.WriteLine("Enter either 1, 2, 3, 4");
                                        complete3 = false;
                                    }
                                } while (complete3 != true);
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
                            SecondRoom();

                        }
                        else
                        {
                            attemptcount2 = attemptcount2 + 1;
                            moveCount.MoveCount = moveCount.MoveCount + 1;
                            Console.WriteLine("That isnt an option here!");
                            if (attemptcount2 == 3)
                            {
                                Console.WriteLine("*Hint: Try either 'kick door' or 'pick lock'");
                                attemptcount2 = 0;
                            }
                            complete2 = false;
                        } 
                    } while (complete2 != true);
                }
                else
                {
                    attemptcount = attemptcount + 1;
                    moveCount.MoveCount = moveCount.MoveCount + 1;
                    Console.WriteLine("That isnt an option here!");
                    if (attemptcount == 3)
                    {
                        Console.WriteLine("*Hint: Try 'try door'");
                        attemptcount = 0;
                    }
                    complete = false;
                } 
            } while (complete != true);

        }

        private static void SecondRoom()
        {
            int attemptcount = 0;
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

                    Ladder();

                }
                else
                {
                    attemptcount = attemptcount + 1;
                    moveCount.MoveCount = moveCount.MoveCount + 1;
                    Console.WriteLine("That isnt an option here!");
                    Console.WriteLine("You're in a hallway. There are 2 ways you can go: left or right");
                    Console.WriteLine("Where will you go?");
                    if (attemptcount == 3)
                    {
                        Console.WriteLine("*Hint: Try either 'left' or 'right'");
                        attemptcount = 0;
                    }
                    Wrongway = false;
                }



            } while (Wrongway != true);



            Console.ReadKey();
        }

        private static void Ladder()
        {
            int attemptcount = 0;
            var correctinput = false;
            currentScene.CurerntScene = "Ladder Room";
            do
            {
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
                        ThirdRoom();

                    }
                    else
                    {
                        ThirdRoom();
                    }
                }
                else
                {
                    attemptcount = attemptcount + 1;
                    moveCount.MoveCount = moveCount.MoveCount + 1;
                    Console.WriteLine("That isnt an option here!");
                    if (attemptcount == 3)
                    {
                        Console.WriteLine("*Hint: Try 'go down ladder'");
                    }


                }
            } while (correctinput != true);
        }

        private static void ThirdRoom()
        {
            bool Continue = false;
            int BattleInput = 0;
            Console.WriteLine("You go down the ladder...");
            bool test = false;
            Hostile Spider = new Hostile(100);
            currentScene.CurerntScene = "Room 3: Sewer";
            playerHp.PlayerHp = playerHp.PlayerHp + playerHp.HpPot(potUse.HpPotUse, playerHp.PlayerHp);
            potUse.HpPotUse = potUse.HpPotUse - 1;
            Console.WriteLine("HP: " + playerHp.PlayerHp);
            Console.WriteLine("A large spider comes out of the black and attacks you!");
            Console.WriteLine("*Type battle to fight*");
            var UserInput = Convert.ToString(Console.ReadLine());
            UserInput = UserInput.ToLower();
            if (UserInput == "battle")
            {
                moveCount.MoveCount = moveCount.MoveCount + 1;



                do
                {
                    moveCount.MoveCount = moveCount.MoveCount + 1;

                    do
                    {
                        Console.WriteLine("**Select an attack**");
                        Console.WriteLine("**Enter the corisponding number to do the attack**");
                        Console.WriteLine("1) Punch");
                        Console.WriteLine("2) Kick");
                        Console.WriteLine("3) Knee");
                        Console.WriteLine("4) Elbow");
                        try
                        {
                            BattleInput = Convert.ToInt16(Console.ReadLine());
                            Continue = true;
                        }
                        catch (Exception)
                        {

                            Console.WriteLine("Enter one of the options!");
                            Continue = false;
                        }
                    } while (Continue != true);
                    switch (BattleInput)
                    {
                        case 1:
                            Spider.HostileHp = Player.Punch(Spider.HostileHp);
                            playerHp.PlayerHp = Spider.SpiderAttackSelector(playerHp.PlayerHp);
                            Player.Check(playerHp.PlayerHp);
                            break;
                        case 2:
                            Spider.HostileHp = Player.Kick(Spider.HostileHp);
                            playerHp.PlayerHp = Spider.SpiderAttackSelector(playerHp.PlayerHp);
                            Player.Check(playerHp.PlayerHp);
                            break;
                        case 3:
                            Spider.HostileHp = Player.Knee(Spider.HostileHp);
                            playerHp.PlayerHp = Spider.SpiderAttackSelector(playerHp.PlayerHp);
                            Player.Check(playerHp.PlayerHp);
                            break;
                        case 4:
                            Spider.HostileHp = Player.Elbow(Spider.HostileHp);
                            playerHp.PlayerHp = Spider.SpiderAttackSelector(playerHp.PlayerHp);
                            Player.Check(playerHp.PlayerHp);
                            break;
                        default:
                            Console.WriteLine("Thats not an option!");
                            break;
                    }
                    if (playerHp.PlayerHp <= 0 || Spider.HostileHp <= 0)
                    {
                        test = true;
                    }
                    
                }while (test != true) ;
                if (Spider.HostileHp <= 0)
                {
                    Console.WriteLine("You killed the spider!");
                    FinalRoom();
                }
                else
                {
                    Console.WriteLine("You died!");
                    ConsoleKey SpaceCheck;
                    Console.WriteLine("Space to try again...");
                    Console.WriteLine("Press any other key to exit...");
                    SpaceCheck = Console.ReadKey(true).Key;
                    if (SpaceCheck == ConsoleKey.Spacebar)
                    {
                        Console.Clear();
                        FirstRoom();
                    }
                    else
                    {
                        Environment.Exit(1);
                    }

                }
            }
            else
            {
                moveCount.MoveCount = moveCount.MoveCount + 1;
                Console.WriteLine("You shoot back up the ladder!");
                Ladder();
            }
            
        }

        private static void FinalRoom()
        {
            Console.WriteLine("You see a light at the end of the tunnel");
            Console.WriteLine("A way out!");
            Console.WriteLine("Congrats, you win!");
            Console.WriteLine("You beat the game with " + playerHp.PlayerHp + " HP");
            Console.WriteLine("You did it in " + moveCount.MoveCount + " moves");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}