Public Class Form1
    Private Sub butStart_Click(sender As Object, e As EventArgs) Handles butStart.Click
        Me.Close() 'Closes the Form
        Process.Start("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Unity PacMan Done\PacMan Clone.exe") 'This path leads to the Original game which the player can access and play
    End Sub

    Private Sub butQuit_Click(sender As Object, e As EventArgs) Handles butQuit.Click
        Application.Exit() 'Closes the whole program
    End Sub

    Private Sub butChooseMap_Click(sender As Object, e As EventArgs) Handles butChooseMap.Click
        Me.Hide() 'Closes this Form 
        Form3.Show() 'Shows Form3 to the User
    End Sub

    Private Sub butHighScore_Click(sender As Object, e As EventArgs) Handles butHighScore.Click
        Me.Hide() 'Closes the current Form
        Form2.Show() 'Displays the Form2
    End Sub

End Class
