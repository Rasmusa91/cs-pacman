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
    /// This class will represent food
    /// </summary>
    class Food : Sprite
    {
        // Create some virtual foodtypes
        public enum FoodType { Normal, Super };
        private FoodType mType;

        /// <summary>
        /// Get or set the foodtype
        /// </summary>
        public FoodType Type
        {
            get { return mType; }
            set { mType = value; }
        }

        /// <summary>
        /// Initialize the food
        /// </summary>
        /// <param name="pImage">Image of the food</param>
        /// <param name="pPosition">Position of the food</param>
        /// <param name="pFoodType">The type of the food</param>
        public Food(Image pImage, Point pPosition, FoodType pFoodType)
            : base(pImage, pPosition)
        {
            mType = pFoodType;
        }

        /// <summary>
        /// Override the draw method from sprite to make sure it's only drawn when active
        /// </summary>
        /// <param name="e"></param>
        public override void Draw(PaintEventArgs e)
        {
            // Only draw if active
            if (IsActive)
            {
                base.Draw(e);
            }
        }

        /// <summary>
        /// Eat the food (make it inactive)
        /// </summary>
        public void Eat()
        {
            if (IsActive)
            {
                IsActive = false;
            }
        }
    }
}
