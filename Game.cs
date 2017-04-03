// Rasmus Appelqvist
// 09/01-15
// Project: Pacman

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    /// <summary>
    /// This class will be the parent to all game-logic
    /// </summary>
    class Game
    {
        private MainForm mMainForm;
        private Map mMap;
        private List<Character> mCharacters;

        /// <summary>
        /// Initialize the game class
        /// </summary>
        /// <param name="pMainForm">The parent of the game class</param>
        public Game(MainForm pMainForm)
        {
            mMainForm = pMainForm;

            mMap = new Map();
            mCharacters = new List<Character>();

            Reset();
        }

        /// <summary>
        /// Resets the game
        /// </summary>
        public void Reset()
        {
            // Clear and reset food and characters
            mMap.ResetFood();
            mCharacters.Clear();

            // Create the player and assign the keyDown event to it
            Player player = new Player(this, Pacman.Properties.Resources.player, mMap.GetRandomPlayerSpawn());
            mCharacters.Add(player);
            mMainForm.KeyDownEvent += player.OnKeyDown;

            // Create enemies
            List<Point> enemySpawns = mMap.GetEnemySpawns();
            for (int i = 0; i < enemySpawns.Count; i++)
            {
                mCharacters.Add(new Enemy(this, Pacman.Properties.Resources.monster, enemySpawns[i]));
            } 
        }

        /// <summary>
        /// This method will update everything that needs to be updated inside the game class
        /// </summary>
        /// <param name="pDeltaTime">Time between frames</param>
        public void Update(float pDeltaTime)
        {
            // Update all characters (enemies and player)
            for (int i = 0; i < mCharacters.Count; i++)
            {
                mCharacters[i].Update(pDeltaTime);
            }
        }

        /// <summary>
        /// Draw everything associated with the game class
        /// </summary>
        /// <param name="e"></param>
        public void Draw(PaintEventArgs e)
        {
            // Draw the map
            mMap.Draw(e);

            // Draw all characters
            for (int i = 0; i < mCharacters.Count; i++)
            {
                mCharacters[i].Draw(e);
            }

            // Draw the score text
            e.Graphics.DrawString(
                "Score: " + (mMap.GetMaxFood() - mMap.GetFoodLeft()).ToString() + "/" + mMap.GetMaxFood().ToString(), 
                new Font("Arial", 16), 
                new SolidBrush(Color.White), 
                new Point(10, 10));
        }

        /// <summary>
        /// Get the map objet of the game
        /// </summary>
        /// <returns>The map object</returns>
        public Map GetMap()
        {
            return mMap;
        }

        /// <summary>
        /// Check if an enemy is at a given position
        /// </summary>
        /// <param name="pPosition">Position to check</param>
        /// <returns>If an enemy could be found</returns>
        public bool IsEnemyAtPosition(Point pPosition)
        {
            bool enemyAtPos = false;

            // Iterate all characters, then check if the character is an enemy
            // Check if its current position and its wanted position
            for (int i = 0; i < mCharacters.Count && !enemyAtPos; i++)
            {
                if( mCharacters[i] is Enemy &&
                    (mCharacters[i].Position.Equals(pPosition) ||
                    mCharacters[i].WantedPosition.Equals(pPosition)))
                {
                    enemyAtPos = true;
                }
            }

            return enemyAtPos;
        }

        /// <summary>
        /// Check if an player is at a given position
        /// </summary>
        /// <param name="pPosition">Position to check</param>
        /// <returns>If an player could be found</returns>
        public bool IsPlayerAtPosition(Point pPosition)
        {
            bool playerAtPos = false;

            // Iterate all characters, then check if the character is an player
            // Check if its current position and its wanted position
            for (int i = 0; i < mCharacters.Count && !playerAtPos; i++)
            {
                if (mCharacters[i] is Player &&
                    (mCharacters[i].Position.Equals(pPosition) ||
                    mCharacters[i].WantedPosition.Equals(pPosition)))
                {
                    playerAtPos = true;
                }
            }

            return playerAtPos;            
        }

        /// <summary>
        /// Tell the parent main form that the game is over
        /// </summary>
        public void GameOver()
        {
            mMainForm.GameOver();
        }
    }
}
