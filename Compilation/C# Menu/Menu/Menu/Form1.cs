using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Menu
{
    public partial class frmCMenu : Form
    {
        public frmCMenu()
        {
            InitializeComponent();
        }

        private void butMyGame_Click(object sender, EventArgs e) //When the MyGame Button is pressed the following code is ran
        {
            Process.Start("E:/College Subjects/Computer Science/Computer Science NEA/FINAL/Bling Bling Boy/Bling Bling Boy/Bling Bling Boy/bin/Debug/Bling Bling Boy.exe"); //Launches Bling Bling Boy (MyGame)
            this.Close(); //Closes the Menu
        }

        private void butFlappyBird_Click(object sender, EventArgs e) //When the FlappyBird Button is pressed the following code is ran
        {
            Process.Start("E:/College Subjects/Computer Science/Computer Science NEA/FINAL/Flappy Bird -DataBase/Flappy Bird Menu/Flappy Bird Menu/bin/Debug/Flappy Bird Menu.exe"); //Launches the Flappy Bird Menu
            this.Close(); //Closes the Menu
        }

        private void butSpaceInvaders_Click(object sender, EventArgs e) //When the SpaceInvaders Button is pressed the following code is ran
        {
            Process.Start("E:/College Subjects/Computer Science/Computer Science NEA/FINAL/Space Invader -DataBase/Menu/WindowsApp1/bin/Debug/WindowsApp1.exe"); //Launches the Space Invaders Menu
            this.Close(); //Closes the Menu
        }

        private void butPong_Click(object sender, EventArgs e) //When the Pong button is pressed the following code is ran
        {
            Process.Start("E:/College Subjects/Computer Science/Computer Science NEA/FINAL/Pong Remakes/Pong - Core DONE/Pong Menu/Pong Menu/WindowsApp1/bin/Debug/WindowsApp1.exe"); //Launches the Pong Menu
            this.Close(); //Closes the Menu
        }

        private void butPacMan_Click(object sender, EventArgs e) //When the PacMan button is pressed the following code is ran
        {
            Process.Start("E:/College Subjects/Computer Science/Computer Science NEA/FINAL/PacMan Menu/PacMan Menu/bin/Debug/PacMan Menu.exe"); //Launches the PaMan Menu
            this.Close(); //Closes the Menu
        }

        private void butHighScore_Click(object sender, EventArgs e) //When the HighScore Button is pressed the following code is ran
        {
            Process.Start("E:/College Subjects/Computer Science/Computer Science NEA/FINAL/High Score Screen/WindowsApp1/WindowsApp1/bin/Debug/WindowsApp1.exe"); //Launches the High Score Screen
            this.Close(); //Closes the Menu
        }
    }
}
