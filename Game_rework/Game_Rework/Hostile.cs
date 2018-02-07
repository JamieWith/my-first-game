using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Rework
{
    class Hostile
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
            Random rnd = new Random();
            int AttackSelect = 1;
            switch (AttackSelect)
            {
                case 1:
                    SpiderBite(playerHp);
                    break;
                case 2:
                    SpiderWebAttack(playerHp);
                    break;
                case 3:
                    SpiderSpit(playerHp);
                    break;
                case 4:
                    SpiderSwingSlam(playerHp);
                    break;
                default:
                    break;
            }
            return playerHp;

        }

        private void SpiderSwingSlam(int playerHp)
        {
            Console.WriteLine("The spider swung in and slammed you!");
            playerHp = playerHp -40;
            Console.WriteLine("You have " + playerHp + " left!");
        }

        private void SpiderSpit(int playerHp)
        {
            Console.WriteLine("The spider spat at you!");
            playerHp = playerHp - 5;
            Console.WriteLine("You have " + playerHp + " left!");
        }

        private void SpiderWebAttack(int playerHp)
        {
            Console.WriteLine("The spider shot you with its webs!");
            playerHp = playerHp - 15;
            Console.WriteLine("You have " + playerHp + " left!");
        }

        private void SpiderBite(int playerHp)
        {
            Console.WriteLine("The spider bit you!");
            playerHp = playerHp - 10;
            Console.WriteLine("You have " + playerHp + " left!");
        }
    }
}
