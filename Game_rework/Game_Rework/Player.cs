using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Rework
{
    class Player
    {
        private int playerHp;
        private int potUse = 1;
        private int abilityChoice;

        public Player(int playerHp)
        {
            this.playerHp = playerHp;

        }

        public int PlayerHp
        {
            get { return playerHp; }
            set { playerHp = value; }
            
        }
        public int HpPotUse
        {
            get { return potUse; }
            set { potUse = value; }
        }
        public static void Check(int playerHp)
        {
            if (playerHp <= 10)
            {
                Console.BackgroundColor = ConsoleColor.Red;
            }
        }
        public int HpPot(int potUse, int playerHp)
        {
            var heal = 0;
            if (potUse == 1)
            {
                heal = 5;
                Console.WriteLine("You find a healing pot! This increased your Hp by 5!");
                
            }
            else
            {
                Console.WriteLine("You've already used the health pot here!");
            }
            return heal;
        }
        public int AbilityChoice
        {
            get { return abilityChoice; }
            set { abilityChoice = value; }
        }
        public static int Punch(int hostileHp)
        {
            Console.WriteLine("You punched!");
            hostileHp = hostileHp - 10;
            Console.WriteLine("The hostile has " + hostileHp + " left!");
            return hostileHp;
            
        }


    }
}
