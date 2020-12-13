namespace Menu
{
    partial class frmCMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCMenu));
            this.lblText = new System.Windows.Forms.Label();
            this.pbPong = new System.Windows.Forms.PictureBox();
            this.butPong = new System.Windows.Forms.Button();
            this.pbSpaceInvaders = new System.Windows.Forms.PictureBox();
            this.butSpaceInvaders = new System.Windows.Forms.Button();
            this.pbMyGame = new System.Windows.Forms.PictureBox();
            this.butMyGame = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.butFlappyBird = new System.Windows.Forms.Button();
            this.pbPacMan = new System.Windows.Forms.PictureBox();
            this.butPacMan = new System.Windows.Forms.Button();
            this.butHighScore = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbPong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpaceInvaders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMyGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPacMan)).BeginInit();
            this.SuspendLayout();
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("Rockwell", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.ForeColor = System.Drawing.Color.White;
            this.lblText.Location = new System.Drawing.Point(226, 32);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(320, 59);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "Game Menu";
            // 
            // pbPong
            // 
            this.pbPong.Image = ((System.Drawing.Image)(resources.GetObject("pbPong.Image")));
            this.pbPong.Location = new System.Drawing.Point(22, 389);
            this.pbPong.Name = "pbPong";
            this.pbPong.Size = new System.Drawing.Size(200, 120);
            this.pbPong.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPong.TabIndex = 1;
            this.pbPong.TabStop = false;
            // 
            // butPong
            // 
            this.butPong.Location = new System.Drawing.Point(84, 515);
            this.butPong.Name = "butPong";
            this.butPong.Size = new System.Drawing.Size(75, 23);
            this.butPong.TabIndex = 2;
            this.butPong.Text = "Start Pong";
            this.butPong.UseVisualStyleBackColor = true;
            this.butPong.Click += new System.EventHandler(this.butPong_Click);
            // 
            // pbSpaceInvaders
            // 
            this.pbSpaceInvaders.Image = ((System.Drawing.Image)(resources.GetObject("pbSpaceInvaders.Image")));
            this.pbSpaceInvaders.Location = new System.Drawing.Point(554, 389);
            this.pbSpaceInvaders.Name = "pbSpaceInvaders";
            this.pbSpaceInvaders.Size = new System.Drawing.Size(200, 120);
            this.pbSpaceInvaders.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSpaceInvaders.TabIndex = 3;
            this.pbSpaceInvaders.TabStop = false;
            // 
            // butSpaceInvaders
            // 
            this.butSpaceInvaders.Location = new System.Drawing.Point(591, 515);
            this.butSpaceInvaders.Name = "butSpaceInvaders";
            this.butSpaceInvaders.Size = new System.Drawing.Size(136, 23);
            this.butSpaceInvaders.TabIndex = 4;
            this.butSpaceInvaders.Text = "Start Space Invaders";
            this.butSpaceInvaders.UseVisualStyleBackColor = true;
            this.butSpaceInvaders.Click += new System.EventHandler(this.butSpaceInvaders_Click);
            // 
            // pbMyGame
            // 
            this.pbMyGame.Image = ((System.Drawing.Image)(resources.GetObject("pbMyGame.Image")));
            this.pbMyGame.Location = new System.Drawing.Point(288, 237);
            this.pbMyGame.Name = "pbMyGame";
            this.pbMyGame.Size = new System.Drawing.Size(200, 120);
            this.pbMyGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMyGame.TabIndex = 5;
            this.pbMyGame.TabStop = false;
            // 
            // butMyGame
            // 
            this.butMyGame.Location = new System.Drawing.Point(321, 363);
            this.butMyGame.Name = "butMyGame";
            this.butMyGame.Size = new System.Drawing.Size(136, 23);
            this.butMyGame.TabIndex = 6;
            this.butMyGame.Text = "Start My Game";
            this.butMyGame.UseVisualStyleBackColor = true;
            this.butMyGame.Click += new System.EventHandler(this.butMyGame_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(554, 111);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // butFlappyBird
            // 
            this.butFlappyBird.Location = new System.Drawing.Point(591, 237);
            this.butFlappyBird.Name = "butFlappyBird";
            this.butFlappyBird.Size = new System.Drawing.Size(136, 23);
            this.butFlappyBird.TabIndex = 8;
            this.butFlappyBird.Text = "Start Flappy Bird";
            this.butFlappyBird.UseVisualStyleBackColor = true;
            this.butFlappyBird.Click += new System.EventHandler(this.butFlappyBird_Click);
            // 
            // pbPacMan
            // 
            this.pbPacMan.Image = ((System.Drawing.Image)(resources.GetObject("pbPacMan.Image")));
            this.pbPacMan.Location = new System.Drawing.Point(22, 111);
            this.pbPacMan.Name = "pbPacMan";
            this.pbPacMan.Size = new System.Drawing.Size(200, 120);
            this.pbPacMan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPacMan.TabIndex = 9;
            this.pbPacMan.TabStop = false;
            // 
            // butPacMan
            // 
            this.butPacMan.Location = new System.Drawing.Point(52, 237);
            this.butPacMan.Name = "butPacMan";
            this.butPacMan.Size = new System.Drawing.Size(136, 23);
            this.butPacMan.TabIndex = 10;
            this.butPacMan.Text = "Start PacMan";
            this.butPacMan.UseVisualStyleBackColor = true;
            this.butPacMan.Click += new System.EventHandler(this.butPacMan_Click);
            // 
            // butHighScore
            // 
            this.butHighScore.Location = new System.Drawing.Point(321, 140);
            this.butHighScore.Name = "butHighScore";
            this.butHighScore.Size = new System.Drawing.Size(136, 23);
            this.butHighScore.TabIndex = 11;
            this.butHighScore.Text = "See Top Players";
            this.butHighScore.UseVisualStyleBackColor = true;
            this.butHighScore.Click += new System.EventHandler(this.butHighScore_Click);
            // 
            // frmCMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(779, 560);
            this.Controls.Add(this.butHighScore);
            this.Controls.Add(this.butPacMan);
            this.Controls.Add(this.pbPacMan);
            this.Controls.Add(this.butFlappyBird);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.butMyGame);
            this.Controls.Add(this.pbMyGame);
            this.Controls.Add(this.butSpaceInvaders);
            this.Controls.Add(this.pbSpaceInvaders);
            this.Controls.Add(this.butPong);
            this.Controls.Add(this.pbPong);
            this.Controls.Add(this.lblText);
            this.Name = "frmCMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.pbPong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpaceInvaders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMyGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPacMan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.PictureBox pbPong;
        private System.Windows.Forms.Button butPong;
        private System.Windows.Forms.PictureBox pbSpaceInvaders;
        private System.Windows.Forms.Button butSpaceInvaders;
        private System.Windows.Forms.PictureBox pbMyGame;
        private System.Windows.Forms.Button butMyGame;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button butFlappyBird;
        private System.Windows.Forms.PictureBox pbPacMan;
        private System.Windows.Forms.Button butPacMan;
        private System.Windows.Forms.Button butHighScore;
    }
}

