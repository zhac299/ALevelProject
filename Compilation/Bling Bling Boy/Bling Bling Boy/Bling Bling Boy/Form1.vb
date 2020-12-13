Public Class frmGame

#Region "Variables"
    Dim MoveUp As Boolean = False 'This Variable is used to allow the player to move their character up
    Dim MoveDown As Boolean = False 'This Variable is used to allow the player to move their character down
    Dim MoveLeft As Boolean = False 'This Variable is used to allow the player to move their character left
    Dim MoveRight As Boolean = False 'This Variable is used to allow the player to move their character right
    Dim PlayerSpeed As Integer = 10 'This Variable holds the speed the player can move at
    Dim Lives As Integer = 3 'This Variable stores the number of Lives the player has
    Dim Count As Integer = 0 'This Variable is used to count the number of times a event takes place
    Dim Score As Integer = 0 'This Variable holds the players actual Score
    Dim RandomX As New Random 'This Variable stores a Random number and is used to allow the Gem to appear at a Random Location on the Form
    Dim RandomY As New Random 'This Variable stores a Random number and is used to allow the Gem to appear at a Random Location on the Form
    Dim CurrentNumberOfEnemies As Integer = 1 'This Variable holds the number of enemies on the form when the game is running
    Dim EnemyArray(5) As PictureBox 'Stores all the Enemys in a Array
    Dim InvincibilityTimer As Integer = 1000 'This Variable is used to give the player temorary invincibility
    Dim EnemySpeed As Single = 1.5 'This Variable stores the Speed of the enemies
    Dim HighScore As Integer 'Used to check if player has beaten current high score or not
    Dim temp As String 'Used to convert string to integer
#End Region

    Private Sub frmGame_Load(sender As Object, e As EventArgs) Handles Me.Load 'This code is ran when the Form is loaded
        Dim null As String 'Used to store irrelevent data
        'The code below stores all of the enemies into the array
        EnemyArray(1) = pbEnemy1
        EnemyArray(2) = pbEnemy2
        EnemyArray(3) = pbEnemy3
        EnemyArray(4) = pbEnemy4
        EnemyArray(5) = pbEnemy5

        Randomize() 'Loads up the .NET Randomize Function

        Using Reader As IO.StreamReader = New IO.StreamReader("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Bling Bling Boy\Bling Bling Boy\Bling Bling Boy\bin\Debug\BestPlayer.txt") 'Reads the stated file
            null = Reader.ReadLine 'Stores the irrelvent data in null
            temp = Reader.ReadLine 'Stores the required data in temp
        End Using

        HighScore = Integer.Parse(temp) 'HighScore is recieved by converting temp to integer

        pbGem.Location = New Point(RandomX.Next(1, 550), RandomY.Next(-3, 413)) 'Used to Assign the Gem a Random Location on the Form
        pbGem.Visible = True 'As initially the Gem isn't Visible this code makes it Visible so the user can see where it is
    End Sub

    Private Sub frmGame_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown 'This code is ran when a Key is pressed
        Select Case e.KeyCode
            Case Keys.Up 'If the Up Key is pressed then the following code is ran
                MoveUp = True 'MoveUp becomes True
            Case Keys.Down 'If the Down Key is pressed then the following code is ran
                MoveDown = True 'MoveDown becomes True
            Case Keys.Left 'If the Left Key is pressed then the following code is ran
                MoveLeft = True 'MoveLeft becomes True
            Case Keys.Right 'If the Right Key is pressed than the following code is ran
                MoveRight = True 'MoveRight becomes True
        End Select
    End Sub

    Private Sub frmGame_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp 'This code is ran when a Key is not being pressed / released
        Select Case e.KeyCode
            Case Keys.Up 'If the Up Key is not being pressed then the following code is ran
                MoveUp = False 'MoveUp becomes False
            Case Keys.Down 'If the Down Key is not being pressed then the following code is ran
                MoveDown = False 'MoveDown becomes False
            Case Keys.Left 'If the Left Key is not being pressed then the following code is ran
                MoveLeft = False 'MoveLeft becomes False
            Case Keys.Right 'If the Right Key is not being pressed then the following code is ran
                MoveRight = False 'MoveRight becomes False
        End Select

    End Sub

    Private Sub gameTimer_Tick(sender As Object, e As EventArgs) Handles gameTimer.Tick 'This code is ran when the gameTimer ticks
        InvincibilityTimer -= 10 'Decrements from the Invincibility timer to count it down

        If MoveUp = True Then 'If MoveUp is True then the following code is ran
            pbBoy.Top -= PlayerSpeed 'The player moves up
        ElseIf MoveDown = True Then 'If MoveDown is True then the following code is ran
            pbBoy.Top += PlayerSpeed 'The player moves down
        ElseIf MoveLeft = True Then 'If MoveLeft is True then the following code is ran
            pbBoy.Left -= PlayerSpeed 'The player moves left
        ElseIf MoveRight = True Then 'If MoveRight is True then the following code is ran
            pbBoy.Left += PlayerSpeed 'The player moves right
        End If

        If pbBoy.Location.Y > 380 Then 'If the player goes beyond the boundary of the form then the following code is ran
            pbBoy.Location = New Point(pbBoy.Location.X, 380) 'The player gets placed at the boundary
        ElseIf pbBoy.Location.Y < -6 Then 'If the player goes beyond the boundary of the form then the following code is ran
            pbBoy.Location = New Point(pbBoy.Location.X, -5) 'The player gets placed at the boundary
        End If

        If pbBoy.Location.X > 530 Then 'If the player goes beyond the boundary of the form then the following code is ran
            pbBoy.Location = New Point(530, pbBoy.Location.Y) 'The player gets placed at the boundary
        ElseIf pbBoy.Location.X < -10 Then 'If the player goes beyond the boundary of the form then the following code is ran
            pbBoy.Location = New Point(-10, pbBoy.Location.Y) 'The player gets placed at the boundary
        End If

        If pbBoy.Bounds.IntersectsWith(pbGem.Bounds) Then 'If the player collects a Gem then the following code is ran
            Score += 1 'The player gains 1 point to their Score
            pbGem.Visible = False 'The Gem temporarly becomes invisible
            pbGem.Location = AssignRandomLocation(pbGem.Location) 'The Gem gets a new Random Location
            pbGem.Visible = True 'The Gem becomes Visible again
        End If

        lblScore.Text = ("Score: " & Score) 'Displays Score to user
        lblLives.Text = ("Lives: " & Lives) 'Displays the number of Lives to user

        For i = 1 To CurrentNumberOfEnemies 'FOR loop goes through all of the enemies on the screen
            If InvincibilityTimer > 0 Then 'If the InvincibilityTimer Variable is greater than 0 then the following code is ran
                pbBoy.Image = My.Resources.Invincible_Main_Sprite 'The player character changes his sprite
            Else 'If the intial requirement isn't fulfilled then the following code is ran
                pbBoy.Image = My.Resources.Untitled 'The player character gets his original sprite

                If pbBoy.Bounds.IntersectsWith(EnemyArray(i).Bounds) Then 'If enemy and player are in contact then the following code is ran
                    EnemyArray(i).Location = AssignRandomLocation(EnemyArray(i).Location) 'The enemies are moved to a random location on the Form
                    InvincibilityTimer = 1000 'The InvincibilityTimer is reset
                    Lives -= 1 'The player loses a life
                    Score -= 1 'The player loses a point from their score
                    pbBoy.Location = New Point(446, 91) 'Puts the player back to their original location
                    EnemyArray(i).Location = AssignRandomLocation(EnemyArray(i).Location) 'Puts the enemies in random location
                End If
            End If
        Next

        If Score = 5 And Count = 0 Then
            CurrentNumberOfEnemies = 2 'When this Score milestone is reacher number of enemies increases
            EnemyArray(CurrentNumberOfEnemies).Visible = True 'Makes the CurrentNumberOfEnemies Visible
            InvincibilityTimer = 1000 'Resets InvincibilityTimer allowing the player to go temporarily invincible
            EnemySpeed = 2 'Increases EnemySpeed by 0.5
            Count = 1 'Makes it so program knows this event has occured already
        ElseIf Score = 10 And Count = 1 Then
            CurrentNumberOfEnemies = 3 'When this Score milestone is reacher number of enemies increases
            EnemyArray(CurrentNumberOfEnemies).Visible = True 'Makes the CurrentNumberOfEnemies Visible
            InvincibilityTimer = 1000 'Resets InvincibilityTimer allowing the player to go temporarily invincible
            EnemySpeed = 2.5 'Increases EnemySpeed by 0.5
            Count = 0 'Makes it so computer knows this is the most recent event allowing the other events to take place which require count = 0
        ElseIf Score = 15 And Count = 0 Then
            CurrentNumberOfEnemies = 4 'When this Score milestone is reacher number of enemies increases
            EnemyArray(CurrentNumberOfEnemies).Visible = True 'Makes the CurrentNumberOfEnemies Visible
            InvincibilityTimer = 1000 'Resets InvincibilityTimer allowing the player to go temporarily invincible
            EnemySpeed = 3 'Increases EnemySpeed by 0.5
            Count = 1 'Makes it so computer knows this is the most recent event allowing the other events to take place which require count = 1
        ElseIf Score = 20 And Count = 1 Then
            CurrentNumberOfEnemies = 5 'When this Score milestone is reacher number of enemies increases
            EnemyArray(CurrentNumberOfEnemies).Visible = True 'Makes the CurrentNumberOfEnemies Visible
            InvincibilityTimer = 1000 'Resets InvincibilityTimer allowing the player to go temporarily invincible
            EnemySpeed = 3.5 'Increases EnemySpeed by 0.5
            Count = 0 'Makes it so computer knows this is the most recent event allowing the other events to take place which require count = 0
        End If

        If Lives = 0 Then 'When the player runs out of Lives then the following code is ran
            gameTimer.Stop() 'The gameTimer is stopped so the events in this timer no longer take place
            enemyTimer.Stop() 'The enemyTimer is stopped so the events in this timer no longer take place
            lblScore.Text = ("Score: " & Score) 'Stores the Score in the Score Label
            If Score > HighScore Then
                Dim UserInput As String = InputBox("What is Your UserName?") 'Holds the users username

                Using Writer As IO.StreamWriter = New IO.StreamWriter("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Bling Bling Boy\Bling Bling Boy\Bling Bling Boy\bin\Debug\BestPlayer.txt") 'Used to write to stated file
                    Writer.WriteLine(UserInput) 'Writes the users username
                    Writer.WriteLine(Score) 'Writes the users score
                End Using

                MessageBox.Show("Well Done You Have the Current High Score") 'Informs user that they have beaten the current high score
            End If

            MessageBox.Show("Game Over Your Score is " & Score) 'A MessageBox appears which tells the user their final score
            frmScoreMenu.CurrentUserScore = Score 'The users Score is transferred from this form to the score menu
            Me.Hide() 'This form is closed
            frmScoreMenu.Show() 'The score menu form is shown to the user
        End If

    End Sub

    Private Sub enemyTimer_Tick(sender As Object, e As EventArgs) Handles enemyTimer.Tick 'This code is ran when the enemyTimer Ticks

        For i = 1 To CurrentNumberOfEnemies 'This FOR loop is used to loop through all the numbers up to the integer stored inside CurrentNumberOfEnemies
            If pbBoy.Location.X > EnemyArray(i).Location.X Then 'If the player is to the right of the enemy then the following code is ran
                EnemyArray(i).Left += EnemySpeed 'The enemy moves to the right
            Else 'If the intial requirement isn't fulfilled then the following code is ran
                EnemyArray(i).Left -= EnemySpeed 'The enemy moves to the left
            End If

            If pbBoy.Location.Y > EnemyArray(i).Location.Y Then 'If the player is below the player then the following code is ran
                EnemyArray(i).Top += EnemySpeed 'The enemy moves down
            Else 'If the inital requirement isn't fulfilled then the following code is ran
                EnemyArray(i).Top -= EnemySpeed 'The enemy moves up
            End If
        Next

        For j = 2 To 5 'FOR loop goes through values from 2 to 5
            If pbEnemy1.Bounds.IntersectsWith(EnemyArray(j).Bounds) Then 'Checks if enemy 1 has collided with any of the other enemies
                pbEnemy1.Left += 5 'If a collision has occured enemy 1 moves away
            End If
        Next

        For k = 3 To 5 'FOR loop goes through values from 3 to 5 
            If pbEnemy2.Bounds.IntersectsWith(EnemyArray(k).Bounds) Then 'Checks if enemy 2 has collided with any of the other enemies
                pbEnemy2.Left -= 5 'If a collision has occured enemy 2 moves away
            End If
        Next

        For l = 4 To 5 'FOR loop goes through values from 4 to 5
            If pbEnemy3.Bounds.IntersectsWith(EnemyArray(l).Bounds) Then 'Checks if enemy 3 has collided with any of the other enemies
                pbEnemy3.Left += 5 'If a collision has occured  enemy 3 moves away
            End If
        Next

        If pbEnemy4.Bounds.IntersectsWith(pbEnemy5.Bounds) Then 'Checks to see if enemy 4 and enemy 5 have collided
            pbEnemy4.Left -= 5 'If a collison has occured then enemy 4 moves away
        End If

    End Sub

    Private Function AssignRandomLocation(ByRef pbLocation As Point) 'This code is used to give a pb a random location
        pbLocation = New Point(RandomX.Next(1, 550), RandomY.Next(-3, 413)) 'Used to Assign a pb a Random Location on the Form
        Return pbLocation 'Outputs this new Location
    End Function

End Class
