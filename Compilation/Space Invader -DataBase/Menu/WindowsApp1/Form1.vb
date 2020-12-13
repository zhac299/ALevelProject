Public Class gameForm
    Private Sub startButton_Click(sender As Object, e As System.EventArgs) Handles startButton.Click 'The Following Code is ran when the start game Button is pressed
        Process.Start("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Space Invader -DataBase\Space Invader Main Game - Database\Space Invader Main Game\bin\Debug\Space Invader Main Game.exe") 'This path leads to the original game which the player can access and play
        Environment.Exit(0) 'Terminates (Ends/Closes) this Form
    End Sub

    Private Sub startcustomButton_Click(sender As Object, e As System.EventArgs) Handles startcustomButton.Click 'The Following code is ran when the start custom game button is pressed
        Process.Start("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Space Invader -DataBase\Shoot em Up - Core DONE\Shoot em Up\bin\Debug\Shoot em Up.exe") 'This path leads to the custom game which the player can access and play
        Environment.Exit(0) 'Terminates (Ends/Closes) this Form
    End Sub

    Private Sub exitButton_Click(sender As Object, e As System.EventArgs) Handles exitButton.Click 'The Following Code is ran when the exit button is pressed
        Environment.Exit(0) 'Terminates (Ends/Closes) this form
    End Sub

End Class