Public Class pongMain

#Region "Globals"
    Dim Speed As Single = 5 'Ball's Speed
    Dim rndInst As New Random() 'Random Instance
    Dim BallShot As Boolean = False 'Checks to see if the Ball has been let loose by the player
    Dim AdvBallSpeed As Integer = 10 'Controls the Balls Speed for the Enhancements(Mad Mode Region)
    Dim xVel As Single = Math.Cos(rndInst.Next(5, 10)) * Speed 'Velcoity of the Ball Horizontally (on the x-axis)
    Dim yVel As Single = Math.Sin(rndInst.Next(5, 10)) * Speed 'Velocity of the Ball Vertically (on the y-axis)
    Dim AIActive As Boolean = True 'Checks to see if the AI is using its full Intelligence or not (so if the AI knows where the ball is going or not)
    Dim AIChecker As Integer = 400 'The Checker is used to check the time the AI is used 
    Dim Count As Integer = 0 'Count is used to look at the number of different possibilites for Mad Mode
    Dim AICoolDown As Integer = 100 'The Cool Down period for the AI when it is fully active but can also used to check the time the AI is used
    Dim OriginalLocation As New Point 'Stores the Location of the ball initially
    Dim CheatBoxCount As Boolean = False 'Used for Testing by allowing me to change the Count variable when needed
    Dim CheatBoxScore As Boolean = False 'Used to change the Score by allowing me to change the Score when needed
    Dim MadModeEnabled As Boolean = False 'Used to check if Mad Mode conditions are running
    Dim t As Integer = 0 'Counts up the number of times an event is allowed to run
    Dim r As Random = New Random
    'The Players Score
    Dim plrScore As Integer = 0 'Stores the players score
    Dim compScore As Integer = 0 'Stores the AI score
#End Region

#Region "Move the Paddle According to the Mouse"
    'Move the Paddle According to the Mouse Position
    Private Sub pongMain_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseMove 'The Following code is ran when the mouse moves

        If e.Y > 5 And e.Y < Me.Height - 40 - paddlePlayer.Height Then 'The Following IF statement is ran when the location of the mouse moves
            paddlePlayer.Location = New Point(paddlePlayer.Location.X, e.Y)  'The Players paddle is moves to the location of the mouse
        End If

    End Sub
#End Region

#Region "Main Timer"
    Private Sub gameTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gameTimer.Tick 'The following code is ran everytime the Timer called gameTimer ticks

        MadMode() 'Calls the Sub Routine by the same Name and causes my additon of Mad Mode to the game

        If BallShot = True AndAlso MadModeEnabled = False Then 'If the Boolean Variable BallShot and MadModeEnabled are True then the following code is ran
            gameBall.Location = New Point(gameBall.Location.X + xVel, gameBall.Location.Y + yVel) 'Moves the Ball
        End If


        If AIActive = True Then 'The following IF statement is ran when the Boolean Variable AIActive is True
            If gameBall.Location.Y > 5 And gameBall.Location.Y < Me.Height - 40 - paddlePlayer.Height Then 'Set the Computer Player to Move According to the Balls Position.
                paddleComputer.Location = New Point(paddleComputer.Location.X, gameBall.Location.Y) 'This code lets the AI directly take the postion of the ball and move according to it
            End If
        End If

        If gameBall.Bounds.IntersectsWith(pbTopWall.Bounds) Then 'Check for Top Wall (The top of the Form)
            gameBall.Location = New Point(gameBall.Location.X, 0) 'Makes it so the ball cannot move beyond Top of the Form
            yVel = -yVel 'Inverses the balls speed vertically so the ball moves down when it collides with the top wall, this is done as I am not dealing with advanced spinning Physics
        End If

        If gameBall.Bounds.IntersectsWith(pbBottomWall.Bounds) Then 'Check for Bottom Wall (The bottom of the Form)
            gameBall.Location = New Point(gameBall.Location.X, Me.Height - gameBall.Size.Height - 45) 'Makes it so the ball cannot move beyond the bottom of the Form
            yVel = -yVel 'Inverses the Balls Speed vertically so the ball moves up when it collides with the bottom wall, this is done as I am not dealing with any advanced spinning Physics
        End If

        If gameBall.Bounds.IntersectsWith(paddlePlayer.Bounds) Then 'Check for Player Paddle
            gameBall.Location = New Point(paddlePlayer.Location.X - gameBall.Size.Width, gameBall.Location.Y) 'The game Ball cannot move beyond the players paddle
            xVel = -xVel 'Inverses the Balls Speed horizontally so the ball moves in the opposite direction
        End If

        If gameBall.Bounds.IntersectsWith(paddleComputer.Bounds) Then 'Check for Computer Paddle
            gameBall.Location = New Point(paddleComputer.Location.X + paddleComputer.Size.Width + 1, gameBall.Location.Y) 'The game Ball cannot move beyond the Computer Paddle
            xVel = -xVel 'Inverses the Balls Speed Horizontally so the ball moves in the opposite direction
        End If

        If gameBall.Bounds.IntersectsWith(pbLeftWall.Bounds) Then 'Check for Left Wall
            plrScore += 1 'If the ball goes past the Computer (AI's) wall the player gains one point
            AIActive = True 'The AI start to track the ball again
            gameBall.Location = OriginalLocation 'The game ball is set to its inital location in the centre of the map
            BallShot = False 'Makes it so the ball doesn't move as soon as the player gains a point allowing the player to control the pace of the game
            plrScoreDraw.Text = Convert.ToString(plrScore) 'Makes it so the Label displays the Players score
        End If

        If gameBall.Bounds.IntersectsWith(pbRightWall.Bounds) Then 'Check for Right Wall
            compScore += 1 'If the ball goes past the Players wall the AI gains one point
            BallShot = False 'Makes it so the ball doesn't move as as the computer gains a point allowing the player to control the pace of the game
            gameBall.Location = OriginalLocation 'Resets the ball back to its original location which is at the centre of the form
            compScoreDraw.Text = Convert.ToString(compScore) 'Convers the players score to string type so it can be displayed in the label so the player can see how many points the AI has
        End If

        If plrScore = 10 And compScore < plrScore Then 'When the Player reaches the 10 point milestone before the computer then the following code is ran
            gameTimer.Stop() 'The Timer is stopped
            AITimer.Stop() 'The Timer controlling the AI functionality is stopped
            MsgBox("Well Done, You have Beat the AI. Do you want to Carry on Playing, if you do you Will Recieve a Extra Point.") 'A messagebox appears telling the player their current options which are to either carry on or quit
            plrScore = plrScore + 1 'If the player chooses to carry on they gain one more point
            plrScoreDraw.Text = Convert.ToString(plrScore) 'Converts the players score to String to it can be displayed to the player in the label
            gameTimer.Start() 'Start the game timer which controls all the games movements and functions
            AITimer.Start() 'Starts the AI timer which controls the AI's functionality
        End If

        If compScore = 10 And plrScore < compScore Then 'If the Computer reaches the 10 point milestone before the player then the following code is executed
            gameTimer.Stop() 'The game timer is stopped
            AITimer.Stop() 'The AI timer is stopped
            MsgBox("Sorry Game Over...") 'A Message Box appears which tells the player that they have lost
            Me.Close() 'Closes the Form (Program)
        End If

        If CheatBoxScore = True Then 'When a certain key is pressed the variable CheatBoxScore becomes true which allows the following code to run
            gameTimer.Stop() 'The game Timer is stopped
            AITimer.Stop() 'The AI Timer is stopped
            plrScore = (InputBox("What do You want your Score to be?")) 'A InputBox appears which allows me to change the score for testing reasons
            plrScoreDraw.Text = (plrScore) 'Shows the Players score in the label which displays the player score to the player
            gameTimer.Start() 'Starts the game Timer
            AITimer.Start() 'Starts the AI timer
            CheatBoxScore = False 'Resets the variable to False so I only get one Input Box not one every time the Timers are started again
        End If

    End Sub

#End Region

#Region "Enemy Timer"
    Private Sub AITimer_Tick(sender As Object, e As EventArgs) Handles AITimer.Tick 'The Following code is ran every time the AI timer ticks
        AIChecker = AIChecker - 100 'This piece of code is used to make sure the Computer doesn't always know where the balls exact location is at all times by making a countdown of sorts everytime the timer ticks

        If AIActive = False Then 'The following code is ran when the Condition in the IF statement is fuffiled

            AICoolDown = AICoolDown - 50 'This varaible is used to cool down the AI so it launches when this is set to 0

            If AICoolDown < 0 Then 'If the AICoolDown variable is less than 0 the following code is executed
                AICoolDown = 0 'The variable is set to 0 as their is no need for the variable to be below zero as it causes other statements not to function correctly
            End If

            If AIActive = False And AICoolDown = 0 Then 'If both the AI has cooled down and it still isn't activated the following code is executed
                AIActive = True 'The AI is executed
                AICoolDown = 100 'The cool down period is reset
            End If

        End If

        If AIChecker < 0 Then 'Makes it so the variable AIChecker cannot be below 0 by running the following code
            AIChecker = 0 'This sets the Variable back to 0 to reduce bugs and errors in the code and as there is no need for this variable to be negative
        End If


        If AIChecker = 0 Then 'If the AI checker value is 0 then the following code is executed
            AIActive = True 'This piece of code reactivates the AI's full potential where it can find out where the ball is exactly and move directly to that position
        End If

        If plrScore < 5 Then 'If the Players score is less than 5 the follwing code is executed

            If r.Next(0, 10) Mod 2 = 0 Then 'A random number between 0 and 10 is chosen to provide an even chance of their being an odd number or even number but with an increases range, if the number is even then the follwing code is executed, this is done by moduling the value given by the random nunmber generator to see if it gives a value of 0 or not because if it is 0 then the random number generated will be even
                AIActive = True 'Activates the AI if the value given by the random number generator is even
            Else 'If the conditon in the IF statement is not fufilled the following code is ran, in this instance if the number is odd then the following code is ran
                AIActive = False 'The AI isn't activated
            End If
        End If

        If plrScore > 5 And plrScore <= 10 Then 'If the players score is in the range specified then the following code is executed

            If r.Next(1, 10) Mod 2 = 0 Then 'If the randomly generated number is even then the following code is executed, this time there is a higher chance of their being an odd numerb due to their being more odd numbers in the range compared to even numbers
                AIActive = True 'If the number generated is even then the following code is executed
            Else 'If the condition isn't fuffiled then the following code is executed then the follwing code is execeuted
                AIActive = False 'The AI isn't activated
            End If

        End If

        If 10 < plrScore And plrScore <= 15 And r.Next(1, 7) Mod 2 = 0 Then 'If the Players score is in the range and the number generated is even then the following code is executed

            AIActive = True 'The AI is turned on to perform at its best capabilites
        Else 'If the IF statement condition isn't fufilled then the following code is executed
            AIActive = False 'The AI isn't activated
        End If

        If 15 < plrScore And plrScore >= 30 Then 'If the Players score is in the range of scores given then the following code is executed
            AIActive = True 'The AI just becomes Active making it very difficult for the player to gain more points
        End If

    End Sub
#End Region

#Region "End Game on Escape Press"
    'Close the Game when the Escape Button is Pressed
    Private Sub pongMain_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown 'The Following code is ran and used to check when a key is pressed down and to see if it has any functionalities associated with it
        If e.KeyValue = Keys.Escape Then 'If the Escape key is pressed than the following code is executed
            Me.Close() 'The Program closes
        End If

        If e.KeyValue = Keys.A Then 'If the A key is pressed then the following code is executed
            CheatBoxCount = True 'The Boolean Variable called CheatBoxCount is made True so the input boxpops up allowing the player/user to change the Count variable to a digit of their liking
        End If

        If e.KeyValue = Keys.Z Then 'If the Z key is pressed then the following code is executed
            CheatBoxScore = True 'The CheatBoxScore varaible is made True making it so the CheatBox Pops up allowing me to change and manipulate my score throughout the game
        End If

    End Sub
#End Region

#Region "Pause Menu and User Input"
    Private Sub pongMain_Restart(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown 'When the Q Key is Pressed the Pause Menu will Display hiding everything on the Screen, also shows the position of the Cursor

        If e.KeyValue = Keys.Q Then 'When the Q key is pressed down the following code is ran
            gameBall.Hide() 'The ball disappears
            paddlePlayer.Hide() 'The Player Paddle dissapears
            paddleComputer.Hide() 'The Computer Variable disappears
            Restart.Visible = True 'The restart button becomes visible to the player allowing them to interact with it
            Backto.Visible = True 'The backto buttomn becomes visible to the player allowing them to interact with it
            Cursor.Show() 'The Player can now see the cursor when the game is paused
        ElseIf e.KeyValue = Keys.Space Then 'Otherwise if the Space key is presssed down instead the following code is executed
            BallShot = True 'The BallShot Variable becomes True allowing the ball to move now and interact with the paddles and form boundarys (walls)
        End If
    End Sub

    Private Sub pongMain_Hide(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown 'When the W Key is Pressed the Pause Menu will Close starting the Game again, Hiding the Cursor

        If e.KeyValue = Keys.W Then 'When the W Key is pressed down the following code is ran
            gameBall.Show() 'The gameball becomes visible allowing the player to see it
            paddleComputer.Show() 'The Compter AI paddle is no longer hidden meaning the user can now see it
            paddlePlayer.Show() 'The Player Paddle becomes visible so it's no longer hidden from the user
            Restart.Visible = False 'The Restart button isn't visible to the player anymore when the game is unpaused
            Backto.Visible = False 'The BackTo button isn't visible to the player anymore when the game is unpaused
            Cursor.Hide()
        End If
    End Sub

    Private Sub Restart_Click(sender As Object, e As EventArgs) Handles Restart.Click
        Application.Restart() 'When the Restart Button is Pressed the Whole Program will Restart
    End Sub

    Private Sub pongMain_Back(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Backto.Click 'When this Button is Pressed the Game goes back to the Main Menu

        Process.Start("E:\College Subjects\Computer Science\Computer Science NEA\My Games\Pong\Pong Menu\Pong Menu\WindowsApp1\bin\Debug\WindowsApp1.exe") 'Launches the Main Menu from the location it's saved at
    End Sub

#End Region

#Region "Mad Mode"
    Private Sub MadMode()
        If Count = 0 And BallShot = True Then 'If the Variable count is directly = 0 and the ball is in play then the follwing code is executed

            If plrScore >= 5 Then 'If the players score is greater than or equal to 5 then the following code is rexecuted

                If plrScore Mod 2 = 0 Then 'As long as the Players Score is even the following code will ran
                    gameBall.Location = New Point(gameBall.Location.X + xVel * 2, gameBall.Location.Y + yVel) 'Moves the Ball, this piece of code speeds the ball up if the condition is fuffiled otherwise the balls is slowed down
                    MadModeEnabled = True 'Makes this true so the rest of code knows that mad mode is running
                Else
                    gameBall.Location = New Point(gameBall.Location.X + xVel * AdvBallSpeed / 5, gameBall.Location.Y + yVel) 'Moves the Ball, this piece of code halves the speed of the ball so slows it down if the condition isn't fufilled
                    MadModeEnabled = True 'Lets the rest of the program know that Mad Mode is enabled
                End If
                Count = Count + 1 'One is added to the count to allow the other Pieces of code to function properly
            End If
        End If

        If Count = 1 And BallShot = True And plrScore >= 10 Then 'If the Variable Count is 1 and the ball is in play and the player score is greater than or equal to 10 then the follwing code is executed
            If r.Next(0, 5) Mod 2 = 0 AndAlso t = 0 Then 'If the Generated number is even then the following code is ran

                MadModeEnabled = False 'Disables Mad Mode
                AIActive = True 'The AI becomes active and will now track the ball 
                t += 1 'Increments t by 1

            Else
                AIActive = False 'Disables the AI if the condition isn't fufilled
            End If
            Count = Count + 1 'One more is added to Count increasing its valueto 2
        End If

        If Count = 2 And BallShot = True Then 'If Count is 2 and the Ball is in play then the following code is executed
            If r.Next(0, 1) Mod 2 = 0 And plrScore >= 15 Then 'If the Random Number generated in the range is even and the players score is at least 15 then the following code is ran
                t = 0 't is reset
                If gameBall.Location.X = 450 Then 'If the ball is close to the player horizontally (on the x-axis)
                    If r.Next(0, 2) Mod 2 = 0 Then
                        gameBall.Location = New Point(gameBall.Location.X + xVel, gameBall.Location.Y + yVel * AdvBallSpeed) 'Moves the Ball, this piece of code makes the ball move faster vertically
                    End If
                End If
                Count = Count + 1 'One More is added to Count increasing its value to 3
            End If
        End If

        If Count = 3 And BallShot = True And plrScore >= 25 Then
            Dim temp As Integer 'Temporarly Stores a Value
            t = 0 'Resets t
            If r.Next(0, 3) Mod 2 = 0 Then
                temp = xVel 'Temp stores the current value of xVel
                xVel = -xVel 'xVel gets inverted
                gameBall.Location = New Point(gameBall.Location.X + xVel * 2, gameBall.Location.Y + yVel) 'Code allows ball to move
                xVel = temp 'xVel gets it old value back
            End If
        End If

        Count = r.Next(0, 4) 'A random number generated between the range 0 - 4 is given to represent Count so the AI acts randomly keeping the player on their toes at all times

        If CheatBoxCount = True Then 'If the CheatBoxCount Variable is True through the Key Down event than the following code is executed
            gameTimer.Stop() 'The game timer is stopped
            AITimer.Stop() 'The AI timer is stopped
            Count = (InputBox("What do You want the Count to be?")) 'An input Box appears which allows me to change the count variable for testing and debugging
            gameTimer.Start() 'The game timer is started again
            AITimer.Start() 'The AI timer is also started again
            CheatBoxCount = False 'The Variable used in the statement is set to False I can access it multiple times at different times when the game is running
        End If

    End Sub
#End Region

End Class