Public Class gameForm

#Region "Variables"
    Dim MissleShoot As Boolean = False 'Tells the Computer if the Missile is allowed to shoot or not
    Dim EnemyArray(32) As PictureBox 'Holds the enemys in an array
    Dim EnemyLocation(32) As Point 'Keeps track of the location of each enemy in an array
    Dim EnemyShot(32) As PictureBox 'Keeps track of the bullet of each enemy
    Dim EnemyShot2(32) As Boolean 'Used to tell if an enemy has shot or not
    Dim BarricadeLife(2) As Single 'Used to Hold the Barricade Lives    
    Dim EnemySpeed As Integer = 3 'Holds how fast the enemys move
    Dim MoveRight As Boolean = False 'Used to tell if the player can move right or not
    Dim MoveLeft As Boolean = False 'Used to tell if the player can move left or not
    Dim PlayerSpeed As Integer = 4 'Holds the Players Speed
    Dim Score As Integer = 0 'Holds the Score of the Player
    Dim Lives As Integer = 3 'Holds the Lives of the User
    Dim Complete As Integer = 0 'Holds the number of enemys killed
    Dim Level As Integer = 1 'Holds the level of the player 
#End Region

    Private Sub GameForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim i As Integer = 0 'Used for Loops

        Select Case e.KeyValue
            Case Keys.Right 'When the Right Key is Pressed MoveRight becomes True
                MoveRight = True
            Case Keys.Left 'When the Left Key is Pressed MoveLeft becomes True
                MoveLeft = True
            Case Keys.Space 'When the Space Key is pressed the following code is ran
                pbMissile.Location = New Point(pbPlayer.Location.X + 26, pbPlayer.Location.Y)
                MissleShoot = True
                pbMissile.Enabled = True
                pbMissile.Visible = True
        End Select

    End Sub

    Private Sub GameForm_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp

        Select Case e.KeyValue
            Case Keys.Right
                MoveRight = False 'When the Right Key is Released MoveRight becomes False
            Case Keys.Left
                MoveLeft = False 'When the Left Key is Released MoveLeft Becomes False
        End Select

    End Sub

    Private Sub GameForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize() 'Calls Randomize through FrameWork
        InitaliseEnemys() 'Calls Sub Routine by the same name here
        EnemyShoot(32) 'Calls Sub Routine by the same name here

        'When the Form Loads each Barricade is given three lives, thus each barricade can endure three hits
        For i = 0 To 2
            BarricadeLife(i) = 3
        Next

    End Sub

    Private Sub TimerGame_Tick(sender As Object, e As EventArgs) Handles timerGame.Tick 'The Following events occur everytime TimerGame Ticks

        If MissleShoot = False Then
            pbMissile.Visible = False
        End If

        'If MoveRight is True and the Player then the player moves right the same number of pixels as the value of playerspeed
        If MoveRight = True Then
            pbPlayer.Left += PlayerSpeed
        End If

        'If MoveLeft is True then the player moves left the same number of pixels as the value of playerspeed
        If MoveLeft = True Then
            pbPlayer.Left -= PlayerSpeed
        End If

        If pbPlayer.Bounds.IntersectsWith(pbLeftWall.Bounds) Then 'If the player reaches the boundary of the form the following code is ran
            pbPlayer.Location = New Point(0, 431) 'The player is placed at the boundary of the form
        End If

        If pbPlayer.Bounds.IntersectsWith(pbRightWall.Bounds) Then 'If the player reaches the boundary of the form then the following code is ran
            pbPlayer.Location = New Point(794, 431) 'The player is placed at the boundary
        End If

        If MissleShoot = True Then
            pbMissile.Top -= 5 'The Missile Moves up
        End If

        If pbMissile.Location.Y < 1 Then 'If the Missile are off the screen then then the following code is executed
            pbMissile.Visible = False 'The Missile Dissappears
            MissleShoot = False
            pbMissile.Location = New Point(pbPlayer.Location.X + 26, pbPlayer.Location.Y)
        End If

        For j = 0 To 32 'This Loop checks to see if the Missile Hits the Enemy or Not
            If EnemyArray(j).Visible = True Then
                If (pbMissile.Bounds.IntersectsWith(EnemyArray(j).Bounds)) Then 'If the missile and enemy at the j respectivily collide the following code is executed

                    pbMissile.Visible = False 'The missile dissapears
                    MissleShoot = False
                    EnemyArray(j).Visible = False 'The Enemy Dies (Dissapears)
                    pbMissile.Location = New Point(pbPlayer.Location.X + 26, pbPlayer.Location.Y)

                    Complete += 1 'Increments Complete by 1 as an enemy was killed

                    'Checks to see which typeof enemy was killed and adds the correct amount of points to the score
                    If EnemyArray(j).Tag = ("Enemy2") Then
                        Score += 20
                    End If

                    If EnemyArray(j).Tag = ("Enemy3") Then
                        Score += 40
                    End If

                    If EnemyArray(j).Tag = ("Enemy1") Then
                        Score += 10
                    End If

                    lblScore.Text = ("Score: " & Score) 'Displays the Score in the Label to show the User what their score is
                End If
            End If

        Next

        LevelControl() 'Calls Sub Routine by the same name here

    End Sub

    Private Sub TimerEnemy_Tick(sender As Object, e As EventArgs) Handles timerEnemy.Tick

        EnemyMoveMent() 'Calls Sub Routine by the same name here
        EnemyShotMovement() 'Calls Sub Routine by the same name here
        Barricade() 'Calls Sub Routine by the same name here

        For i = 0 To 32 'Loops through all the enemys
            If (pbPlayer.Bounds.IntersectsWith(lblBoundary.Bounds)) Then 'If the enemy reaches the label boundary the follwoing code is ran
                Dim j As Integer 'Used for Loops
                'Resets the Positions of all the enemy
                For j = 0 To 32
                    EnemyArray(j).Location = EnemyLocation(j)
                Next

                'Makes all the Life indicators invisible
                pbLife.Visible = False
                pbLife2.Visible = False
                pbLife3.Visible = False

                Form2.Score2 = Score 'transfers teh Player score to Form2
                Form2.Show() 'Opens Form2
                timerGame.Stop() 'The Main Timer Stops
                timerEnemy.Stop() 'The Enemy Timer Stops
                MsgBox("Game Over Your Score is " & Score) 'MessageBox appears which states game over with the players score
                Me.Hide()
            End If
        Next

    End Sub

    Private Sub InitaliseEnemys()
        Dim i As Integer

        For Each Picturebox In Me.Controls 'For every object in the Form the following code is ran
            If Picturebox.Tag = ("Enemy1") Then 'If the object is a picturebox and is also a enemy then the IF statement is executed. The AndAlso will make sure the code is only ran when both statements (considered as Boolean) are True
                EnemyArray(i) = Picturebox 'Every object which satisfied the given conditions is added to the Array
                i += 1 'The value for i is incremented by 1 until all the objects in the Form are checked over
                ReDim Preserve EnemyArray(i) 'Each time the loop is ran through it's redim (redeclared) with Preserve to stop any previous data which was added from being deleted
            ElseIf Picturebox.Tag = ("Enemy2") Then
                EnemyArray(i) = Picturebox 'Every object which satisfied the given conditions is added to the Array
                i += 1 'The value for i is incremented by 1 until all the objects in the Form are checked over
                ReDim Preserve EnemyArray(i) 'Each time the loop is ran through it's redim (redeclared) with Preserve to stop any previous data which was added from being deleted
            ElseIf Picturebox.Tag = ("Enemy3") Then
                EnemyArray(i) = Picturebox 'Every object which satisfied the given conditions is added to the Array
                i += 1 'The value for i is incremented by 1 until all the objects in the Form are checked over
                ReDim Preserve EnemyArray(i) 'Each time the loop is ran through it's redim (redeclared) with Preserve to stop any previous data which was added from being deleted
            End If

        Next

        'Loop gives each Enemy their right location
        For i = 0 To 32
            EnemyLocation(i) = EnemyArray(i).Location
        Next

    End Sub

    Private Sub EnemyMoveMent()

        'Each Enemy Moves left or right until they reach the boundary then they move down

        For i = 0 To 32
            EnemyArray(i).Left = EnemyArray(i).Left + EnemySpeed
        Next

        If PictureBox13.Bounds.IntersectsWith(pbRightWall.Bounds) Then
            EnemySpeed = EnemySpeed * -1

            For i = 0 To 32
                EnemyArray(i).Top += 10
            Next
        End If

        If PictureBox2.Bounds.IntersectsWith(pbLeftWall.Bounds) Then
            EnemySpeed = EnemySpeed * -1

            For i = 0 To 32
                EnemyArray(i).Top += 10
            Next
        End If

    End Sub
    Private Sub EnemyShoot(ByVal Number As Integer)

        'Code Below dynamically creates each missile when one is shot by the enemy
        For i = 0 To Number

            Dim EnemyMissile As New PictureBox
            Me.Controls.Add(EnemyMissile)
            EnemyMissile.Height = 10
            EnemyMissile.Width = 5
            EnemyMissile.BorderStyle = BorderStyle.FixedSingle
            EnemyMissile.BackColor = Color.GhostWhite
            EnemyMissile.Top = EnemyArray(i).Top + EnemyArray(i).Height / 2 - EnemyMissile.Height / 2
            EnemyMissile.Left = EnemyArray(i).Left + EnemyArray(i).Width / 2 - EnemyMissile.Width / 2
            EnemyMissile.BringToFront()
            EnemyShot(i) = EnemyMissile
            EnemyShot(i).Visible = False
        Next

    End Sub

    Private Sub EnemyShotMovement()
        'Variables below are used for Loops
        Dim j As Integer

        'Loops through to check if the enemy has shot if it hasn't it has the chance to become true through the random
        For i = 0 To 32
            If EnemyShot2(i) = False Then
                j = CInt(Int((1000 * Rnd()) + 1))
                If j = 1000 Then
                    EnemyShot2(i) = True
                End If
            End If
        Next

        'Checks to see if the Enemy has shot if it has then the bullet becomes visible and the missile moves down
        For i = 0 To 32
            If EnemyShot2(i) = True Then
                EnemyShot(i).Visible = True
                EnemyShot(i).Top += 20
            End If

            If (EnemyShot(i).Bounds.IntersectsWith(pbPlayer.Bounds)) Then 'If a bullet hits the player then following code is ran

                Me.Controls.Remove(EnemyShot(i)) 'Enemy Shot is removed from the form
                EnemyShot(i).Location = EnemyArray(i).Location 'Moves the bullet back to the position of the enemy

                Lives = Lives - 1 'Player loses one life

                'Code below checks the life the player is on and changes the UI accordingly
                If Lives = 2 Then
                    pbLife.Visible = False
                ElseIf Lives = 1 Then
                    pbLife2.Visible = False
                End If

            End If

            'If the Shot goes out of the Form then the Shot is removed and is moved back to its original location
            If EnemyShot(i).Top > Me.Height Then
                EnemyShot2(i) = False
                EnemyShot(i).Visible = False
                EnemyShot(i).Location = EnemyLocation(i)
                EnemyShot(i).Top = EnemyShot(i).Top + 30
                EnemyShot(i).Left = EnemyShot(i).Left + 15
            End If
        Next

        If Lives = 0 Then 'If Player has 0 lives then the follwing code is ran
            pbLife3.Visible = False 'Life Indicator is made invisible
            Form2.Score2 = Score 'Player Score is transferred from this form to form2
            timerGame.Stop() 'The Main Timer Stops
            timerEnemy.Stop() 'The Enemy Timer Stops
            MsgBox("Game Over Your Score is " & Score) 'MessageBox appears which states game over with the players score
            Form2.Show() 'Open Form2
            Me.Hide() 'Closes this Form
        End If

    End Sub
    Private Sub Barricade()
        Dim j As Integer 'Used for Loops

        Dim BarricadeArray(2) As PictureBox 'Stores all the Barricades in an Array

        'The Code below loops through each picturebox in the form and adds it to the array if it has the barricade tag
        For i = 0 To 2

            For Each Picturebox In Me.Controls
                If Picturebox.Tag = ("Barricade") Then
                    BarricadeArray(i) = Picturebox
                    i += 1
                    ReDim Preserve BarricadeArray(i)
                End If
            Next

        Next

        'Nested FOR Loop checks to see if the player shot the barricade, if they did then the barricade loses a life and the image of the barricade changes accordingly
        For j = 0 To 2
            For i = 0 To 1
                If BarricadeLife(j) > 0 AndAlso BarricadeArray(j).Visible = True Then

                    If (pbMissile.Bounds.IntersectsWith(BarricadeArray(j).Bounds)) Then

                        pbMissile.Visible = False
                        MissleShoot = False
                        pbMissile.Location = New Point(pbPlayer.Location.X + 26, pbPlayer.Location.Y)

                        BarricadeLife(j) = BarricadeLife(j) - 1
                    End If

                    If BarricadeLife(j) >= 2 And BarricadeLife(j) < 3 Then
                        BarricadeArray(j).Image = My.Resources.DamagedBarricade1
                    ElseIf BarricadeLife(j) >= 1 And BarricadeLife(j) < 2 Then
                        BarricadeArray(j).Image = My.Resources.DamagedBarricade2
                    ElseIf BarricadeLife(j) >= 0 And BarricadeLife(j) < 1 Then
                        BarricadeArray(j).Visible = False
                    End If
                End If

                If BarricadeLife(j) < 0 Then
                    BarricadeLife(j) = 0
                End If

            Next
        Next

        'Nested FOR Loops checks to see if a Enemy Missile has hit the barricade, this causes the barricade to lose one life and the barricade image changes accordingly
        For j = 0 To 2
            For i = 0 To 32
                If (EnemyShot(i).Bounds.IntersectsWith(BarricadeArray(j).Bounds)) Then

                    Me.Controls.Remove(EnemyShot(i))
                    EnemyShot(i).Location = EnemyArray(i).Location

                    BarricadeLife(j) = BarricadeLife(j) - 0.25

                    If BarricadeLife(j) >= 2 And BarricadeLife(j) < 3 Then
                        BarricadeArray(j).Image = My.Resources.DamagedBarricade1
                    ElseIf BarricadeLife(j) >= 1 And BarricadeLife(j) < 2 Then
                        BarricadeArray(j).Image = My.Resources.DamagedBarricade2
                    ElseIf BarricadeLife(j) >= 0 And BarricadeLife(j) < 1 Then
                        BarricadeArray(j).Visible = False
                    End If

                    If BarricadeLife(j) < 0 Then
                        BarricadeLife(j) = 0
                    End If

                End If
            Next
        Next

    End Sub

    Private Sub LevelControl()

        'If all the enemys have been killed then the level is incremented and shown to the user and the value for complete is reset
        If Complete = 33 Then
            Level += 1
            lblLevel.Text = ("Level: " & Level)
            Complete = 0
            'Code below resets all enemy locations and makes them all visible again
            For i = 0 To 32
                EnemyArray(i).Location = EnemyLocation(i)
                EnemyArray(i).Visible = True
            Next

        End If

    End Sub

End Class