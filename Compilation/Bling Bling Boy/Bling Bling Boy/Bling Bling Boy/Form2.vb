Public Class frmMenu
    Public PlayerName As String 'Stores the Best Players Name
    Public HighScore As Integer 'Stores the Best Players Score

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim temp As String

        Using Reader As IO.StreamReader = New IO.StreamReader("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Bling Bling Boy\Bling Bling Boy\Bling Bling Boy\bin\Debug\BestPlayer.txt")
            PlayerName = Reader.ReadLine
            temp = Reader.ReadLine
        End Using

        HighScore = Integer.Parse(temp)
        lblPlayer.Text = ("Best Score: " & PlayerName) 'Writes the best players name to a label
        lblHighScore.Text = ("High Score: " & HighScore) 'Writes the best players score to a label

    End Sub

    Private Sub butStartGame_Click(sender As Object, e As EventArgs) Handles butStartGame.Click 'This code is ran when the Button called butStartGame is clicked
        frmGame.Show() 'The form where the game is played is shown to the user
    End Sub

    Private Sub butDebug_Click(sender As Object, e As EventArgs) Handles butDebug.Click
        frmScoreMenu.Show() 'The form where the user can search for their scores and/or submit them is shown to the user
    End Sub

End Class