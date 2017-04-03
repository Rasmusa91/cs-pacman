// Rasmus Appelqvist
// 09/01-15
// Project: Pacman

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    /// <summary>
    /// Class that will handle everything that has to do with the form
    /// </summary>
    public partial class MainForm : Form
    {
        private const string mHighscoreFile = @".\highscores.dat";

        public event KeyEventHandler KeyDownEvent;

        private Game mGame;
        private Stopwatch mGameTimer;
        private bool mIsRunning;
        private List<HighscoreEntry> mHighscoreEntries;

        /// <summary>
        /// Get or set if the game is running
        /// </summary>
        public bool IsRunning
        {
            get { return mIsRunning; }
            set { mIsRunning = value; }
        }
        
        /// <summary>
        /// Initialize the form
        /// </summary>
        public MainForm()
        {
            // Create default values the variables
            mGame = new Game(this);
            mHighscoreEntries = new List<HighscoreEntry>();
            mIsRunning = false;

            // Try to read the highscore file (don't want an error if the file don't exists as it will if so be created when a entry is saved)
            try
            {
                if (File.Exists(mHighscoreFile))
                {
                    mHighscoreEntries = BinSerializerUtility.DeSerialize<List<HighscoreEntry>>(mHighscoreFile);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
         
            // Create a game timer to measure amount time between frames (delta time)
            mGameTimer = new Stopwatch();
            mGameTimer.Start();

            InitializeComponent();
            InitializeGUI();
        }

        /// <summary>
        /// Initialize all GUI components
        /// </summary>
        private void InitializeGUI()
        {
            UpdateHighscores();
            endScreenGroupBox.Visible = false;

            // Set some flags to make the game smoother
            SetStyle(
              ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.DoubleBuffer, true);            
        }

        /// <summary>
        /// Update the highscore list
        /// </summary>
        public void UpdateHighscores()
        {
            // Sort list with bubble-sort
            for (int i = 0; i < mHighscoreEntries.Count; i++)
            {
                for (int j = 0; j < mHighscoreEntries.Count; j++)
                {
                    if(mHighscoreEntries[i].Score > mHighscoreEntries[j].Score)
                    {
                        HighscoreEntry temp = mHighscoreEntries[i];
                        mHighscoreEntries[i] = mHighscoreEntries[j];
                        mHighscoreEntries[j] = temp;
                    }
                }                
            }

            // Put all items in the list view
            highscoresListView.Items.Clear();
            for (int i = 0; i < mHighscoreEntries.Count; i++)
            {
                highscoresListView.Items.Add(new ListViewItem(new string[] { mHighscoreEntries[i].Name, mHighscoreEntries[i].Score.ToString() }));
            }            
        }

        /// <summary>
        /// Tell the form that the game is over
        /// Update the score label, stop the update and view the end screen form
        /// </summary>
        public void GameOver()
        {
            endScreenScoreLabel.Text = "Score: " + (mGame.GetMap().GetMaxFood() - mGame.GetMap().GetFoodLeft()).ToString() + "/" + mGame.GetMap().GetMaxFood().ToString();
            endScreenGroupBox.Visible = true;
            mIsRunning = false;
        }

        /// <summary>
        /// This event will let us draw on the canvas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            mGame.Draw(e);

            // If the game is not running, create a opaqe black overlay
            if (!mIsRunning)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(200, Color.Black)), new Rectangle(0, 0, Map.MAPWIDTH * Map.TILESIZE, Map.MAPHEIGHT * Map.TILESIZE));
            }
        }

        /// <summary>
        /// Every tick the timer ticks we'll update the game (30 fps in this case (see the timer property in the Designer))
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameLoop_Tick(object sender, EventArgs e)
        {
            // Only update the game if the game is active
            if (mIsRunning)
            {
                // Calculate the delta second and update the game
                mGame.Update((float)(mGameTimer.ElapsedMilliseconds * 0.001f));
                mGameTimer.Restart();

                // Tell the canvas to redraw
                Refresh();
            }
        }

        /// <summary>
        /// Fire the event that handles the key-down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDownEvent(this, e);
        }

        /// <summary>
        /// Event that checks if the Exit button has been pressed on the main form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void endButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Event that will check if the start button has been pressed in the main form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startButton_Click(object sender, EventArgs e)
        {
            mainGroupBox.Visible = false;

            mGame.Reset();
            mIsRunning = true;
            this.Focus();
        }

        /// <summary>
        /// Event that will check if the Submit button is pressed at the endscreen form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void endScreenSubmitButton_Click(object sender, EventArgs e)
        {
            // If the name is not empty
            if (endScreenNameInput.Text != String.Empty)
            {
                // Create a highscore entry
                mHighscoreEntries.Add(new HighscoreEntry(endScreenNameInput.Text, (mGame.GetMap().GetMaxFood() - mGame.GetMap().GetFoodLeft())));
                UpdateHighscores();

                // Try to save the highscores
                try
                {
                    BinSerializerUtility.Serialize(mHighscoreEntries, mHighscoreFile);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                }

                //Hide the end screen form and show the main form
                endScreenGroupBox.Visible = false;
                mainGroupBox.Visible = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid name!");
            }
        }

        /// <summary>
        /// Event that checks if the restart button at the end screen has been pressed, then instantly restart the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void endScreenRestartButton_Click(object sender, EventArgs e)
        {
            endScreenGroupBox.Visible = false;

            mGame.Reset();
            IsRunning = true;
            this.Focus();
        }
    }
}
