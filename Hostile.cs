using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Rework
{
    public class Hostile
    {
        private int hostileHp;

        public Hostile(int hostileHp)
        {
            this.hostileHp = hostileHp;

        }

        public int HostileHp
        {
            get { return hostileHp; }
            set { hostileHp = value; }

        }
        public int SpiderAttackSelector(int playerHp)
        {
            int dmg;
            Random rnd = new Random();
            int AttackSelect = rnd.Next(1, 5);
            switch (AttackSelect)
            {
                case 1:
                    dmg = SpiderBite(playerHp);
                    playerHp = playerHp - dmg;
                    break;
                case 2:
                    dmg = SpiderWebAttack(playerHp);
                    playerHp = playerHp - dmg;
                    break;
                case 3:
                    dmg = SpiderSpit(playerHp);
                    dmg = playerHp = playerHp - dmg;
                    break;
                case 4:
                    dmg = SpiderSwingSlam(playerHp);
                    playerHp = playerHp - dmg;
                    break;
                default:
                    break;
            }
            return playerHp;

        }

        public int SpiderSwingSlam(int playerHp)
        {
            int dmg = 40;
            playerHp = playerHp - dmg;
            Console.WriteLine("The spider swung in and slammed you!");
            Console.WriteLine("You have " + playerHp + " HP");
            return dmg;
        }

        public int SpiderSpit(int playerHp)
        {
            int dmg = 5;
            playerHp = playerHp - dmg;
            Console.WriteLine("The spider spat at you!");
            Console.WriteLine("You have " + playerHp + " HP");

            return dmg;
        }

        public int SpiderWebAttack(int playerHp)
        {
            int dmg = 15;
            playerHp = playerHp - dmg;
            Console.WriteLine("The spider shot you with its webs!");
            Console.WriteLine("You have " + playerHp + " HP");


            return dmg;
        }

        public int SpiderBite(int playerHp)
        {
            int dmg = 10;
            playerHp = playerHp - dmg;
            Console.WriteLine("The spider bit you!");
            Console.WriteLine("You have " + playerHp + " HP");


            return dmg;
        }
    }
}
