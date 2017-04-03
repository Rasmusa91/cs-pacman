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
    /// This class will represent a sprite (image and position)
    /// </summary>
    class Sprite
    {
        private Image mImage;
        private Point mPosition;
        private PointF mOffsetPosition;
        private bool mIsActive;

        /// <summary>
        /// Return the image
        /// </summary>
        protected Image Image
        {
            get { return mImage; }
        }

        /// <summary>
        /// Return or set the position
        /// </summary>
        public Point Position
        {
            get { return mPosition; }
            set { SetPosition(value); }
        }

        /// <summary>
        /// Return or set the offsetposition
        /// </summary>
        protected PointF OffsetPosition
        {
            get { return mOffsetPosition; }
            set { mOffsetPosition = value; }
        }

        /// <summary>
        /// Get or set if the sprite is active
        /// </summary>
        public bool IsActive
        {
            get { return mIsActive; }
            set { mIsActive = value; }
        }

        /// <summary>
        /// Initialize the sprite
        /// </summary>
        /// <param name="pImage">The image to be drawn</param>
        /// <param name="pPosition">The position where to be drawn</param>
        public Sprite(Image pImage, Point pPosition)
        {
            mImage = pImage;
            mPosition = pPosition;
            mIsActive = true;
        }

        /// <summary>
        /// Empty, overridable update (not abstract because there is no need to force usage)
        /// </summary>
        /// <param name="pDeltaTime">Time between frames</param>
        public virtual void Update(float pDeltaTime)
        {
            // Overridable
        }

        /// <summary>
        /// Draw the sprite image at the given position
        /// </summary>
        /// <param name="e"></param>
        public virtual void Draw(PaintEventArgs e)
        {
            PointF truePosition = GetTruePosition();
            e.Graphics.DrawImage(mImage, new Rectangle((int) truePosition.X, (int) truePosition.Y, Map.TILESIZE, Map.TILESIZE));
        }

        /// <summary>
        /// Get the true position ((tilePosition + offsetPosition) * tileSize 
        /// </summary>
        /// <returns></returns>
        public PointF GetTruePosition()
        {
            PointF truePosition = Map.GetTruePosition(new PointF(mPosition.X + mOffsetPosition.X, mPosition.Y + mOffsetPosition.Y));

            return truePosition;
        }

        /// <summary>
        /// Overridable SetPosition for classes that want to do more when the position is updated
        /// </summary>
        /// <param name="pPosition">The new position</param>
        public virtual void SetPosition(Point pPosition)
        {
            mPosition = pPosition;
        }
    }
}
