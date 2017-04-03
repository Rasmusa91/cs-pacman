// Rasmus Appelqvist
// 09/01-15
// Project: Pacman

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    [Serializable]
    class HighscoreEntry
    {
        private string mName;
        private int mScore;

        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }

        public int Score
        {
            get { return mScore; }
            set { mScore = value; }
        }

        public HighscoreEntry(string pName, int pScore)
        {
            mName = pName;
            mScore = pScore;
        }
    }
}
