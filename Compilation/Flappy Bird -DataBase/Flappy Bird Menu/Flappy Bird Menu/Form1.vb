Public Class Form1
    Private Sub butStartGame_Click(sender As Object, e As EventArgs) Handles butStartGame.Click 'The code inside is ran when the Start Game Button is pressed
        Me.Close() 'Closes the Form
        Process.Start("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Flappy Bird -DataBase\Flappy Bird - Core DONE\Flappy Bird\Flappy Bird\bin\Debug\Flappy Bird.exe") 'This path leads to the Original game which the player can access and play
    End Sub

    Private Sub butExit_Click(sender As Object, e As EventArgs) Handles butExit.Click 'When this Button is pressed the following code is ran
        Application.Exit() 'Closes the Program
    End Sub

End Class