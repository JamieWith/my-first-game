using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Rework
{
    class State
    {
        private string currentScene;

        public State(string currentScene)
        {
            this.currentScene = currentScene;
        }

        public string CurerntScene
        {
            get { return currentScene; }
            set { currentScene = value; }
        }

        private int moveCount;

        public State(int moveCount)
        {
            this.moveCount = moveCount;
        }

        public int MoveCount
        {
            get { return moveCount; }
            set { moveCount = value; }
        }

    }
}
