// Rasmus Appelqvist
// 09/01-15
// Project: Pacman

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    /// <summary>
    /// This class will represent an enemy
    /// </summary>
    class Enemy : Character
    {
        /// <summary>
        /// Initialize the neemy
        /// </summary>
        /// <param name="pGame">The parent game class</param>
        /// <param name="pImage">The image of the enemy</param>
        /// <param name="pPosition">The initial position</param>
        public Enemy(Game pGame, Image pImage, Point pPosition)
            : base(pGame, pImage, pPosition)
        {
            // Give the enemy a new speed
            Speed = 2.0f;

            // Instantly find a new direction and the move
            FindDirection();
            Move();
        }

        /// <summary>
        /// This method will find all possible directions of the enemy
        /// </summary>
        private void FindDirection()
        {
            List<Map.Direction> possibleDirections = new List<Map.Direction>();

            // Iterate all existing directions (up, down, left, right)
            foreach(KeyValuePair<Map.Direction, Point> item in Map.DirectionRelation)
            {
                // Find the relative position of the direciton and the character
                Point pos = new Point(item.Value.X + Position.X, item.Value.Y + Position.Y);

                // Check if the direciton is not the oppisite
                if (item.Key != Map.GetOppositeDirection(Direction) &&
                    // Check if the direciton is walkable
                    Map.IsWalkable(pos) &&
                    // Check if another enemy is not standing at the position
                    !Game.IsEnemyAtPosition(pos))
                {
                    // If all above succeeded, add the direction to the possible directions list
                    possibleDirections.Add(item.Key);
                }
            }

            // Make sure that there was atleast one possible directions
            if (possibleDirections.Count > 0)
            {
                // Select a random direction of the possible ones
                Direction = possibleDirections[new Random().Next(0, possibleDirections.Count)];
            }
            else 
            {
                // If no possible direction was found, turn around to the opposite direction
                Direction = Map.GetOppositeDirection(Direction);
            }
        }

        /// <summary>
        /// Override the set position to check for the player
        /// </summary>
        /// <param name="pPosition">The new possition</param>
        public override void SetPosition(Point pPosition)
        {
            base.SetPosition(pPosition);

            // CHeck if there is a player at the new position
            if (Game.IsPlayerAtPosition(pPosition))
            {
                // End the game if so
                Game.GameOver();
            }

            // Instantly move to a possible new direction
            FindDirection();
            Move();
        }
    }
}
