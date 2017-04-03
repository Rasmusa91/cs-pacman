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
    /// This class will handle the map
    /// </summary>
    class Map
    {
        // Create a virtual direction
        public enum Direction { Down, Left, Right, Up };
        public static Dictionary<Direction, Point> DirectionRelation = new Dictionary<Direction, Point> { 
            { Direction.Down, new Point(0, 1)},
            { Direction.Left, new Point(-1, 0)},
            { Direction.Right, new Point(1, 0)},
            { Direction.Up, new Point(0, -1)}
        };

        // Instantiate some constant sizes 
        public const int TILESIZE = 32;
        public const int MAPWIDTH = 31;
        public const int MAPHEIGHT = 30;

        // Manually create the location of every object
        // 0 = walkable ground + food
        // 1 = wall
        // 2 = superfood + enemy spawn
        // 3 = playerspawn + no food
        static int[][] data = new int[MAPHEIGHT][]
        {
			new int[MAPWIDTH] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
			new int[MAPWIDTH] { 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1 },
			new int[MAPWIDTH] { 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1 },
			new int[MAPWIDTH] { 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1 },
			new int[MAPWIDTH] { 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1 },
			new int[MAPWIDTH] { 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1 },
			new int[MAPWIDTH] { 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1 },
			new int[MAPWIDTH] { 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1 },
			new int[MAPWIDTH] { 1, 0, 1, 1, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 1, 1, 0, 1 },
			new int[MAPWIDTH] { 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1 },
			new int[MAPWIDTH] { 1, 0, 1, 1, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 1, 1, 0, 1 },
			new int[MAPWIDTH] { 1, 0, 1, 1, 0, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 0, 1, 1, 0, 1 },
			new int[MAPWIDTH] { 1, 0, 1, 1, 0, 0, 0, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 0, 0, 0, 1, 1, 0, 1 },
			new int[MAPWIDTH] { 1, 0, 1, 1, 0, 1, 1, 0, 1, 0, 1, 1, 3, 3, 3, 3, 3, 3, 3, 1, 1, 0, 1, 0, 1, 1, 0, 1, 1, 0, 1 },
			new int[MAPWIDTH] { 1, 0, 1, 1, 0, 1, 1, 0, 1, 0, 1, 1, 3, 1, 1, 1, 1, 1, 3, 1, 1, 0, 1, 0, 1, 1, 0, 1, 1, 0, 1 },
			new int[MAPWIDTH] { 1, 0, 1, 1, 0, 1, 1, 0, 1, 0, 1, 1, 3, 1, 1, 1, 1, 1, 3, 1, 1, 0, 1, 0, 1, 1, 0, 1, 1, 0, 1 },
			new int[MAPWIDTH] { 1, 0, 1, 1, 0, 1, 1, 0, 1, 0, 1, 1, 3, 3, 3, 3, 3, 3, 3, 1, 1, 0, 1, 0, 1, 1, 0, 1, 1, 0, 1 },
			new int[MAPWIDTH] { 1, 0, 1, 1, 0, 0, 0, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 0, 0, 0, 1, 1, 0, 1 },
			new int[MAPWIDTH] { 1, 0, 1, 1, 0, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 0, 1, 1, 0, 1 },
			new int[MAPWIDTH] { 1, 0, 1, 1, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 1, 1, 0, 1 },
			new int[MAPWIDTH] { 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1 },
			new int[MAPWIDTH] { 1, 0, 1, 1, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 1, 1, 0, 1 },
			new int[MAPWIDTH] { 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1 },
			new int[MAPWIDTH] { 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1 },
			new int[MAPWIDTH] { 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1 },
			new int[MAPWIDTH] { 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1 },
			new int[MAPWIDTH] { 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1 },
			new int[MAPWIDTH] { 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1 },
			new int[MAPWIDTH] { 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1 },
			new int[MAPWIDTH] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 } 
        };

        private List<Sprite> mEnvironment;
        private List<Food> mFood;
        private List<Point> mPlayerSpawns;
        private List<Point> mEnemySpawns;

        /// <summary>
        /// Initialize the map
        /// </summary>
        public Map()
        {
            mEnvironment = new List<Sprite>();
            mFood = new List<Food>();
            mPlayerSpawns = new List<Point>();
            mEnemySpawns = new List<Point>();

            Generate();
        }

        /// <summary>
        /// Draw all environment and food
        /// </summary>
        /// <param name="e"></param>
        public void Draw(PaintEventArgs e)
        {
            // Draw all environment
            for (int i = 0; i < mEnvironment.Count; i++)
            {
                mEnvironment[i].Draw(e);
            }

            // Draw all food
            for (int i = 0; i < mFood.Count; i++)
            {
                mFood[i].Draw(e);
            }
        }

        /// <summary>
        /// This method will analyze the data array and create objects based on the number and position of the number
        /// </summary>
        private void Generate()
        {
            Random r = new Random();

            // Iterate the whole jagged array
            for (int i = 0; i < MAPHEIGHT; i++)
            {
                for (int j = 0; j < MAPWIDTH; j++)
                {
                    // Put grass on every tile
                    mEnvironment.Add(new Sprite(Pacman.Properties.Resources.grass, new Point(j, i)));

                    // If the tile is a 1
                    if (data[i][j] == 1) 
                    {
                        // Find a random bush image
                        int randomBush = r.Next(0, 3);
                        Image bushImage = null;

                        switch (randomBush)
                        {        
                            case 0:
                                bushImage = Pacman.Properties.Resources.bush1;
                                break;
                            case 1:
                                bushImage = Pacman.Properties.Resources.bush2;
                                break;
                            case 2:
                                bushImage = Pacman.Properties.Resources.bush3;
                                break;
                        }

                        // Add the bush at the given location
                        mEnvironment.Add(new Sprite(bushImage, new Point(j, i)));
                    }
                    // If the tile is a 0
                    else if (data[i][j] == 0)
                    {
                        // Find a random normal food image
                        int randomFood = r.Next(0, 4);
                        Image foodImage = null;

                        switch (randomFood)
                        {
                            case 0:
                                foodImage = Pacman.Properties.Resources.food1;
                                break;
                            case 1:
                                foodImage = Pacman.Properties.Resources.food2;
                                break;
                            case 2:
                                foodImage = Pacman.Properties.Resources.food3;
                                break;
                            case 3:
                                foodImage = Pacman.Properties.Resources.food4;
                                break;
                        }

                        // Add the normal food
                        mFood.Add(new Food(foodImage, new Point(j, i), Food.FoodType.Normal));
                    }
                    // If the tile is a 2
                    else if (data[i][j] == 2)
                    {
                        // Find a random super food image
                        int randomSuperFood = r.Next(0, 3);
                        Image superFoodImage = null;

                        switch (randomSuperFood)
                        {
                            case 0:
                                superFoodImage = Pacman.Properties.Resources.superfood1;
                                break;
                            case 1:
                                superFoodImage = Pacman.Properties.Resources.superfood2;
                                break;
                            case 2:
                                superFoodImage = Pacman.Properties.Resources.superfood3;
                                break;
                        }

                        // Add the superfood to the food list
                        mFood.Add(new Food(superFoodImage, new Point(j, i), Food.FoodType.Super));
                        // Add a position to the enemyspawn list
                        mEnemySpawns.Add(new Point(j, i));
                    }
                    // If the tile is a 3
                    else if (data[i][j] == 3)
                    {
                        // Add a position to the playerspawn list
                        mPlayerSpawns.Add(new Point(j, i));
                    }
                }          
            }
        }

        /// <summary>
        /// Check if there is an active food at an given position
        /// </summary>
        /// <param name="pPosition">The position to check</param>
        /// <returns>The food object that was found (null if not)</returns>
        public Food GetFoodAtPos(Point pPosition)
        {
            Food food = null;

            for (int i = 0; i < mFood.Count && food == null; i++)
            { 
                if(mFood[i].Position.Equals(pPosition)) {
                    food = mFood[i];
                }
            }

            return food;
        }

        /// <summary>
        /// Get a random player spawn from the list of playerspawns
        /// </summary>
        /// <returns>The position of the selected playerspawn</returns>
        public Point GetRandomPlayerSpawn()
        {
            Random rnd = new Random();
            return mPlayerSpawns[rnd.Next(0, mPlayerSpawns.Count)];
        }

        /// <summary>
        /// Get all enemyspawns
        /// </summary>
        /// <returns>All enemy spawns</returns>
        public List<Point> GetEnemySpawns()
        {
            return mEnemySpawns;
        }

        /// <summary>
        /// Make all food active again
        /// </summary>
        public void ResetFood()
        {
            for (int i = 0; i < mFood.Count; i++)
            {
                mFood[i].IsActive = true;
            }           
        }

        /// <summary>
        /// Check the amount of food that has not been taken 
        /// </summary>
        /// <returns>The amount of not eaten food</returns>
        public int GetFoodLeft()
        {
            int foodLeft = 0;

            for (int i = 0; i < mFood.Count; i++)
            {
                if (mFood[i].IsActive)
                {
                    foodLeft++;
                }
            }

            return foodLeft;
        }

        /// <summary>
        /// Get the total amount of food
        /// </summary>
        /// <returns>The total amount of food</returns>
        public int GetMaxFood()
        {
            return mFood.Count;
        }

        /// <summary>
        /// Get the position of where to draw on the canvas (tilePosition * tileSize)
        /// </summary>
        /// <param name="pPosition">Tile position</param>
        /// <returns>The position where to draw on the canvas (tilePosition * tileSize)</returns>
        public static PointF GetTruePosition(PointF pPosition)
        {
            return new PointF(pPosition.X * TILESIZE, pPosition.Y * TILESIZE);
        }

        /// <summary>
        /// Check if a given position is walkable (not a wall)
        /// </summary>
        /// <param name="pPosition">The position to be checked</param>
        /// <returns>If the tile is a walkable</returns>
        public static bool IsWalkable(Point pPosition)
        {
            return (data[pPosition.Y][pPosition.X] != 1);
        }

        /// <summary>
        /// Find the opposite direction of a direction
        /// </summary>
        /// <param name="pDirection">The direction to be found the opposite off</param>
        /// <returns>The opposit position</returns>
        public static Direction GetOppositeDirection(Direction pDirection)
        {
            Direction oppositDir = Direction.Down;

            if (pDirection == Direction.Down)
            {
                oppositDir = Direction.Up;
            }
            else if (pDirection == Direction.Left)
            {
                oppositDir = Direction.Right;
            }
            else if (pDirection == Direction.Right)
            {
                oppositDir = Direction.Left;
            }

            return oppositDir;
        }
    }
}
