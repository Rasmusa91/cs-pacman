namespace Pacman
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.GameLoop = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.endButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.endScreenGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.endScreenRestartButton = new System.Windows.Forms.Button();
            this.endScreenScoreLabel = new System.Windows.Forms.Label();
            this.endScreenSubmitButton = new System.Windows.Forms.Button();
            this.endScreenNameInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.highscoresListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mainGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.endScreenGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.mainGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GameLoop
            // 
            this.GameLoop.Enabled = true;
            this.GameLoop.Interval = 32;
            this.GameLoop.Tick += new System.EventHandler(this.GameLoop_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 42);
            this.label2.TabIndex = 0;
            this.label2.Text = "Pacman";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // endButton
            // 
            this.endButton.Location = new System.Drawing.Point(13, 236);
            this.endButton.Name = "endButton";
            this.endButton.Size = new System.Drawing.Size(148, 23);
            this.endButton.TabIndex = 2;
            this.endButton.Text = "Exit";
            this.endButton.UseVisualStyleBackColor = true;
            this.endButton.Click += new System.EventHandler(this.endButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(13, 207);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(148, 23);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // endScreenGroupBox
            // 
            this.endScreenGroupBox.BackColor = System.Drawing.SystemColors.Control;
            this.endScreenGroupBox.Controls.Add(this.label1);
            this.endScreenGroupBox.Controls.Add(this.endScreenRestartButton);
            this.endScreenGroupBox.Controls.Add(this.endScreenScoreLabel);
            this.endScreenGroupBox.Controls.Add(this.endScreenSubmitButton);
            this.endScreenGroupBox.Controls.Add(this.endScreenNameInput);
            this.endScreenGroupBox.Controls.Add(this.label3);
            this.endScreenGroupBox.Location = new System.Drawing.Point(342, 269);
            this.endScreenGroupBox.Name = "endScreenGroupBox";
            this.endScreenGroupBox.Size = new System.Drawing.Size(290, 265);
            this.endScreenGroupBox.TabIndex = 6;
            this.endScreenGroupBox.TabStop = false;
            this.endScreenGroupBox.Text = "Game Over";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(36, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Game Over";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // endScreenRestartButton
            // 
            this.endScreenRestartButton.Location = new System.Drawing.Point(147, 213);
            this.endScreenRestartButton.Name = "endScreenRestartButton";
            this.endScreenRestartButton.Size = new System.Drawing.Size(99, 23);
            this.endScreenRestartButton.TabIndex = 5;
            this.endScreenRestartButton.Text = "Restart";
            this.endScreenRestartButton.UseVisualStyleBackColor = true;
            this.endScreenRestartButton.Click += new System.EventHandler(this.endScreenRestartButton_Click);
            // 
            // endScreenScoreLabel
            // 
            this.endScreenScoreLabel.BackColor = System.Drawing.SystemColors.Control;
            this.endScreenScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endScreenScoreLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.endScreenScoreLabel.Location = new System.Drawing.Point(38, 93);
            this.endScreenScoreLabel.Name = "endScreenScoreLabel";
            this.endScreenScoreLabel.Size = new System.Drawing.Size(203, 42);
            this.endScreenScoreLabel.TabIndex = 1;
            this.endScreenScoreLabel.Text = "Score : 100/100";
            this.endScreenScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // endScreenSubmitButton
            // 
            this.endScreenSubmitButton.Location = new System.Drawing.Point(43, 213);
            this.endScreenSubmitButton.Name = "endScreenSubmitButton";
            this.endScreenSubmitButton.Size = new System.Drawing.Size(98, 23);
            this.endScreenSubmitButton.TabIndex = 4;
            this.endScreenSubmitButton.Text = "Submit";
            this.endScreenSubmitButton.UseVisualStyleBackColor = true;
            this.endScreenSubmitButton.Click += new System.EventHandler(this.endScreenSubmitButton_Click);
            // 
            // endScreenNameInput
            // 
            this.endScreenNameInput.Location = new System.Drawing.Point(43, 187);
            this.endScreenNameInput.Name = "endScreenNameInput";
            this.endScreenNameInput.Size = new System.Drawing.Size(203, 20);
            this.endScreenNameInput.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(0, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(290, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Enter your name for the highscore";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.highscoresListView);
            this.groupBox2.Location = new System.Drawing.Point(167, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(264, 240);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Highscores";
            // 
            // highscoresListView
            // 
            this.highscoresListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.highscoresListView.Location = new System.Drawing.Point(6, 19);
            this.highscoresListView.Name = "highscoresListView";
            this.highscoresListView.Size = new System.Drawing.Size(252, 215);
            this.highscoresListView.TabIndex = 1;
            this.highscoresListView.UseCompatibleStateImageBehavior = false;
            this.highscoresListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Score";
            // 
            // mainGroupBox
            // 
            this.mainGroupBox.BackColor = System.Drawing.SystemColors.Control;
            this.mainGroupBox.Controls.Add(this.groupBox1);
            this.mainGroupBox.Controls.Add(this.groupBox2);
            this.mainGroupBox.Controls.Add(this.startButton);
            this.mainGroupBox.Controls.Add(this.endButton);
            this.mainGroupBox.Controls.Add(this.label2);
            this.mainGroupBox.Location = new System.Drawing.Point(277, 268);
            this.mainGroupBox.Name = "mainGroupBox";
            this.mainGroupBox.Size = new System.Drawing.Size(437, 415);
            this.mainGroupBox.TabIndex = 7;
            this.mainGroupBox.TabStop = false;
            this.mainGroupBox.Text = "Pacman";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(13, 272);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 128);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Help";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Controls: ";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(73, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(339, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Use the arrows on the keyboard or W, A, S, D to move the character";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(76, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(336, 67);
            this.label6.TabIndex = 3;
            this.label6.Text = resources.GetString("label6.Text");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Objectives:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(321, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = "Good Luck!";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(991, 960);
            this.Controls.Add(this.mainGroupBox);
            this.Controls.Add(this.endScreenGroupBox);
            this.Name = "MainForm";
            this.Text = "Pacman";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.endScreenGroupBox.ResumeLayout(false);
            this.endScreenGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.mainGroupBox.ResumeLayout(false);
            this.mainGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer GameLoop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button endButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.GroupBox endScreenGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button endScreenRestartButton;
        private System.Windows.Forms.Label endScreenScoreLabel;
        private System.Windows.Forms.Button endScreenSubmitButton;
        private System.Windows.Forms.TextBox endScreenNameInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView highscoresListView;
        private System.Windows.Forms.GroupBox mainGroupBox;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}

