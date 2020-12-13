Public Class Form1

    'When the Start Button is Pressed the Game Program is launched and the Game starts
    Private Sub Start_Click(sender As Object, e As EventArgs) Handles Start.Click
        Process.Start("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Pong Remakes\Pong - Core DONE\Pong Game\WindowsApp1\bin\Debug\WindowsApp1.exe")
        Environment.Exit(0)
    End Sub

    'When the Exit Button is pressed the Game Exits the Program
    Private Sub Close_Click(sender As Object, e As EventArgs) Handles Close.Click
        Environment.Exit(0)
    End Sub

End Class
