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
    /// This class will represent the player
    /// </summary>
    class Player : Character
    {
        private Timer mBuffTimer;

        /// <summary>
        /// Initialize the player
        /// </summary>
        /// <param name="pGame">The parent game</param>
        /// <param name="pImage">The image of the character</param>
        /// <param name="pPosition">The initial position of the character</param>
        public Player(Game pGame, Image pImage, Point pPosition)
            : base(pGame, pImage, pPosition)
        {
            // Create a buff timer
            mBuffTimer = new Timer();
            mBuffTimer.Interval = 5000;
            mBuffTimer.Tick += EndBuff;
        }

        /// <summary>
        /// This event will check if a key is down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            // Make sure that the character is not moving
            if (IsAtWantedPosition())
            {
                // Face left and move
                if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                {
                    SetDirection(Map.Direction.Left);
                    Move();
                }
                // Face right and move
                else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
                {
                    SetDirection(Map.Direction.Right);
                    Move();
                }
                // Face up and move
                else if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                {
                    SetDirection(Map.Direction.Up);
                    Move();
                }
                // Face down and move
                else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                {
                    SetDirection(Map.Direction.Down);
                    Move();
                }
            }
        }

        /// <summary>
        /// Override the set position of this object
        /// </summary>
        /// <param name="pPosition">The new position</param>
        public override void SetPosition(Point pPosition)
        {
            base.SetPosition(pPosition);

            // Find any food at the new position
            Food food = Game.GetMap().GetFoodAtPos(pPosition);

            // If food has been found
            if(food != null)
            {
                // Eat it
                food.Eat();

                // If the food is a superfood
                if (food.Type == Food.FoodType.Super)
                {
                    // Add a speedbuff
                    SpeedMultiplier = 2.0f;

                    // Reset timer if a buff is already active
                    mBuffTimer.Stop();
                    mBuffTimer.Start();
                }
            }

            // End the game if all food has been taken
            if (Game.GetMap().GetFoodLeft() <= 0)
            {
                Game.GameOver();
            }
        }

        /// <summary>
        /// Event to end the buff
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndBuff(object sender, EventArgs e)
        {
            SpeedMultiplier = 1.0f;
            mBuffTimer.Stop();
        }
    }
}
