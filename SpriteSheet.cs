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
    /// This class will handle the animation of a spritesheet
    /// </summary>
    class SpriteSheet : Sprite
    {
        private Timer mTimer;
        private Point[] mSpriteSheet;
        private int mSpriteSheetPosition;

        public SpriteSheet(Image pImage, Point pPosition)
            : base(pImage, pPosition)
        {
            // Timer on when to update the animation frame
            mTimer = new Timer();
            mTimer.Interval = 1000;
            mTimer.Tick += UpdateAnimation;
            mTimer.Enabled = true;

            mSpriteSheetPosition = 0;
        }

        /// <summary>
        /// Draw the current frame of the spritesheet
        /// </summary>
        /// <param name="e"></param>
        public override void Draw(PaintEventArgs e)
        {
            if (mSpriteSheet != null) 
            {
                PointF truePosition = GetTruePosition();
                e.Graphics.DrawImage(
                    // The spritesheet image
                    Image, 
                    // The position and size of the final image
                    new Rectangle((int) truePosition.X, (int) truePosition.Y, Map.TILESIZE, Map.TILESIZE),
                    // The position on the spritesheet and the image size
                    new Rectangle(mSpriteSheet[mSpriteSheetPosition].X * Map.TILESIZE, mSpriteSheet[mSpriteSheetPosition].Y * Map.TILESIZE, Map.TILESIZE, Map.TILESIZE),
                    // Measure in pixels
                    GraphicsUnit.Pixel);
            }
        }

        /// <summary>
        /// Event that will update the animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateAnimation(object sender, EventArgs e)
        {
            // Make sure a spritesheet has been set
            if (mSpriteSheet != null)
            {
                // Jump to next frame
                mSpriteSheetPosition++;

                // If it's exceeding the size, reset
                if (mSpriteSheetPosition >= mSpriteSheet.Length)
                {
                    mSpriteSheetPosition = 0;
                }
            }
        }

        /// <summary>
        /// Update the spritesheet frames
        /// </summary>
        /// <param name="pSpriteSheet">The spritesheet frames</param>
        public void SetSpriteSheet(Point[] pSpriteSheet)
        {
            mSpriteSheet = pSpriteSheet;
            mSpriteSheetPosition = 0;
        }
    }
}
