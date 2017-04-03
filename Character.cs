// Rasmus Appelqvist
// 09/01-15
// Project: Pacman

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    /// <summary>
    /// This class will represent a character (enemy / player)
    /// </summary>
    class Character : SpriteSheet
    {
        private Game mGame;
        private Point mWantedPosition;
        private float mSpeed;
        private float mSpeedMultiplier;
        private Map.Direction mDirection;
        private Stopwatch mIdleTimer;
        private bool mIsIdle;
        
        /// <summary>
        /// Get the parent game class
        /// </summary>
        protected Game Game
        {
            get { return mGame; }
        }

        /// <summary>
        /// Get the wanted position
        /// </summary>
        public Point WantedPosition
        {
            get { return mWantedPosition; }
        }

        /// <summary>
        /// Get the speed
        /// </summary>
        protected float Speed
        {
            set { mSpeed = value; }
        }

        /// <summary>
        /// Get or set the speedmultiplier
        /// </summary>
        protected float SpeedMultiplier
        {
            get { return mSpeedMultiplier; }
            set { mSpeedMultiplier = value; }
        }

        /// <summary>
        /// Get or set the facing direction
        /// </summary>
        internal Map.Direction Direction
        {
            get { return mDirection; }
            set { SetDirection(value); }
        }

        /// <summary>
        /// Initialzie the character
        /// </summary>
        /// <param name="pGame">The parent game class</param>
        /// <param name="pImage">The image to represent the cahracter</param>
        /// <param name="pPosition">The initial position of the character</param>
        public Character(Game pGame, Image pImage, Point pPosition)
            : base(pImage, pPosition)
        {
            mGame = pGame;
            mIdleTimer = new Stopwatch();    
            mWantedPosition = pPosition;
            mSpeed = 1.0f;
            mSpeedMultiplier = 1.0f;

            SetDirection(Map.Direction.Down);
            SetIdle(true);
        }

        /// <summary>
        /// Update the logic of the character
        /// </summary>
        /// <param name="pDeltaTime">Time between frames</param>
        public override void Update(float pDeltaTime)
        {
            base.Update(pDeltaTime);

            // If the character has been standing still for too long, make it idle
            if (IsAtWantedPosition() && mIdleTimer.ElapsedMilliseconds > 100) {
                SetIdle(true);
            }

            // If the character IS NOT at its wanted position
            if (!IsAtWantedPosition())
            {
                // Calculate the direction and speed of the movement
                PointF addPos = new PointF((mWantedPosition.X - Position.X) * mSpeed * mSpeedMultiplier * pDeltaTime, (mWantedPosition.Y - Position.Y) * mSpeed * mSpeedMultiplier * pDeltaTime);
                // Calculate on where the character would be after the movement
                PointF currPos = new PointF(Position.X + OffsetPosition.X + addPos.X, Position.Y + OffsetPosition.Y + addPos.Y);

                // If the character has reached its position
                if (PointDistance(currPos, Position) >= 1.0f)
                {
                    // Reset the offset
                    OffsetPosition = new PointF(0, 0);
                    // Update the actual position
                    Position = mWantedPosition;

                    // Start checking if the character is idle
                    mIdleTimer.Start();
                }
                else
                {
                    // As the character is moving, reset the idle timer
                    mIdleTimer.Reset();
                    // Make the character NOT idle
                    SetIdle(false);
                    // Move the characters
                    OffsetPosition = new PointF(OffsetPosition.X + addPos.X, OffsetPosition.Y + addPos.Y);
                }
            }
        }

        /// <summary>
        /// Calculate the distance between points
        /// </summary>
        /// <param name="pPoint">First point</param>
        /// <param name="pPoint2">Second point</param>
        /// <returns>The distance between two points</returns>
        public double PointDistance(PointF pPoint, PointF pPoint2)
        {
            return Math.Sqrt(Math.Pow(pPoint2.X - pPoint.X, 2) + Math.Pow(pPoint2.Y - pPoint.Y, 2));
        }

        /// <summary>
        /// Check if the character is at its wanted position
        /// </summary>
        /// <returns>If the character is at its wanted position</returns>
        public bool IsAtWantedPosition()
        {
            return mWantedPosition == Position;
        }

        /// <summary>
        /// Move in the facing direction
        /// </summary>
        /// <returns>If the character could move there</returns>
        public bool Move()
        {
            // Find the related direction
            Point pos = Map.DirectionRelation[mDirection];
            // Add it to the current position
            pos = new Point(pos.X + Position.X, pos.Y + Position.Y);
            // Make sure that it's possible to walk there and that the character is not already moving somewhere
            bool walkable = IsAtWantedPosition() && Map.IsWalkable(pos);

            if (walkable)
            {
                mWantedPosition = pos;
            }

            return walkable;
        }

        /// <summary>
        /// Update the direction of the cahracter
        /// </summary>
        /// <param name="pDirection">The new direction</param>
        public void SetDirection(Map.Direction pDirection)
        {
            // Make sure it's not the same direction as it's already facing
            if (mDirection != pDirection)
            {
                mDirection = pDirection;

                // Update the animation
                UpdateAnimation(mIsIdle);
            }
        }

        /// <summary>
        /// Make the character idle
        /// </summary>
        /// <param name="pState"></param>
        public void SetIdle(bool pState)
        {
            if (mIsIdle != pState)
            {
                // Update the animation
                UpdateAnimation(pState);
                mIsIdle = pState;
            }
        }

        /// <summary>
        /// Update the animation of the character
        /// </summary>
        /// <param name="pIdle"></param>
        public void UpdateAnimation(bool pIdle)
        {
            Point[] spriteSheet;

            if (pIdle)
            {
                // The only frame of this spritesheet is the idle one in the current direciton
                spriteSheet = new Point[] { new Point(1, (int)mDirection) };
            }
            else
            {
                // If the character is moving, the spritesheet will contain the first and the third frame
                spriteSheet = new Point[] { new Point(0, (int)mDirection), new Point(2, (int)mDirection) };
            }

            SetSpriteSheet(spriteSheet);
        }
    }
}
