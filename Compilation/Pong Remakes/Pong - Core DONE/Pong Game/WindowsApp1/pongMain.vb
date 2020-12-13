Public Class pongMain

#Region "Globals"
    Dim Speed As Single = 15 'Ball's Speed
    Dim rndInst As New Random() 'Random Instance
    Dim BallShot As Boolean = False 'Determines if Ball has been shot or not
    Dim xVel As Single = Math.Cos(rndInst.Next(5, 10)) * Speed 'Velcoity of the Ball Horizontally (on the x-axis)
    Dim yVel As Single = Math.Sin(rndInst.Next(5, 10)) * Speed 'Velocity of the Ball Vertically (on the y-axis)
    Dim AIActive As Boolean = True 'Holds if the AI is on or not
    Dim AIChecker As Integer = 400 'Counts down the time until the AI becomes active
    Dim AICoolDown As Integer = 100 'AI Cooldown period
    Dim OriginalLocation As New Point 'Stores the Balls Location
    Dim r As Random = New Random 'Used to generate and use Random Numbers
    Dim CheatBox As Boolean = False 'Used to Debug by allowing me to change the score
    Dim UserInput As String 'Holds UserInput
    'The Players Score
    Dim plrScore As Integer = 0
    Dim compScore As Integer = 0
    'Variables used for Mad Mode
    Dim Count As Integer = 0 'Count is used to look at the number of different possibilites for Mad Mode
    Dim MadModeEnabled As Boolean = False 'Used to check if Mad Mode conditions are running
    Dim AdvBallSpeed As Integer = 10 'Controls the Balls Speed for the Enhancements(Mad Mode Region)
    Dim CheatBoxCount As Boolean = False 'Used for Testing by allowing me to change the Count variable when needed
    Dim t As Integer 'Counts up the number of times an event is allowed to run
#End Region

#Region "Form Load Event"
    Private Sub pongMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        Randomize() 'Enables the Randomize Function
        UserInput = InputBox("Do you Want to Play in Mad Mode") 'Asks the User if they want to play with my implementation of Mad Mode in the game

        If UserInput = "Yes" Then 'If the User wants to play in the noted mode then the following code is ran
            madmodeTimer.Start() 'The Corresponding Timer is started
            gameTimer.Start() 'The named timer starts ticking
            AITimer.Start() 'The named timer starts ticking
        Else 'If the inital condition isn't met then the following code is ran
            madmodeTimer.Stop() 'The Timer is Stopped
            gameTimer.Start() 'The named timer starts ticking
            AITimer.Start() 'The named timer starts ticking
        End If

        OriginalLocation = gameBall.Location 'When the Form Loads the Balls Original Location is stored
    End Sub
#End Region

#Region "Move the Paddle According to the Mouse"
    'Move the Paddle According to the Mouse Position Vertically
    Private Sub pongMain_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseMove
        If e.Y > 5 And e.Y < Me.Height - 40 - paddlePlayer.Height Then
            paddlePlayer.Location = New Point(paddlePlayer.Location.X, e.Y)
        End If

    End Sub
#End Region

#Region "Main Timer"
    Private Sub gameTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gameTimer.Tick

        If BallShot = True Then
            'Move the Ball
            gameBall.Location = New Point(gameBall.Location.X + xVel, gameBall.Location.Y + yVel)
        End If

        'Set the Computer Player to Move According to the Balls Position.
        If AIActive = True Then
            If gameBall.Location.Y > pbTopWall.Location.Y And gameBall.Location.Y < 333 Then 'Put boundaries on Paddle Movement for Computer so it Doesn't go off the screen
                paddleComputer.Location = New Point(paddleComputer.Location.X, gameBall.Location.Y)
            End If
        End If

        'Check for Top Wall
        If gameBall.Bounds.IntersectsWith(pbTopWall.Bounds) Then
            gameBall.Location = New Point(gameBall.Location.X, 0)
            yVel = -yVel 'Inverses Vertical Speed
        End If

        'Check for Bottom Wall
        If gameBall.Bounds.IntersectsWith(pbBottomWall.Bounds) Then
            gameBall.Location = New Point(gameBall.Location.X, Me.Height - gameBall.Size.Height - 45)
            yVel = -yVel 'Inverses Vertical Speed
        End If

        'Check for Player Paddle
        If gameBall.Bounds.IntersectsWith(paddlePlayer.Bounds) Then
            gameBall.Location = New Point(paddlePlayer.Location.X - gameBall.Size.Width, gameBall.Location.Y)
            xVel = -xVel 'Inverses Horizontal Speed
        End If

        'Check for Computer Paddle
        If gameBall.Bounds.IntersectsWith(paddleComputer.Bounds) Then
            gameBall.Location = New Point(paddleComputer.Location.X + paddleComputer.Size.Width + 1, gameBall.Location.Y)
            xVel = -xVel 'Inverses Horizontal Speed
        End If

        'Check for Left Wall
        If gameBall.Bounds.IntersectsWith(pbLeftWall.Bounds) Then 'If Ball hits wall behind comp paddle then the following code is ran
            plrScore += 1 'Increases Players Score
            AIActive = True 'Turns AI On
            gameBall.Location = OriginalLocation 'Moves Ball Back to Original Location
            BallShot = False 'Makes it so the ball isn't moving anymore
            plrScoreDraw.Text = Convert.ToString(plrScore) 'Writes Score
        End If

        'Check for Right Wall
        If gameBall.Bounds.IntersectsWith(pbRightWall.Bounds) Then 'If the ball hits wall behind the player then the following code is ran
            compScore += 1 'compScore increases
            AIActive = True 'Turns AI On
            BallShot = False 'Makes it so the ball doesn't move anymore
            gameBall.Location = OriginalLocation 'Moves Ball Back to original Location
            compScoreDraw.Text = Convert.ToString(compScore) 'Writes Score
        End If

        'Once the Player reaches 10 points they have beat the AI
        If plrScore = 10 Then
            'Timers are Stopped
            gameTimer.Stop()
            AITimer.Stop()
            'MessageBox Appears which tells the player they have beat the AI
            MsgBox("Well Done, You have Beat the AI. Do you want to Carry on Playing, if you do you Will Recieve a Extra Point.")
            plrScore = plrScore + 1 'Player gains one Point
            plrScoreDraw.Text = Convert.ToString(plrScore) 'Displays the Player Score
            'Starts the Timers
            gameTimer.Start()
            AITimer.Start()
        End If

        'If the Computer has 10 Points then the player has lost
        If compScore = 10 Then
            'The Timers are stopped
            gameTimer.Stop()
            AITimer.Stop()
            'MessageBox Appears Telling the Player that they have lost
            MsgBox("You Lose")
            Application.Exit() 'Closes the Program
        End If

        'If the CheatBox is enabled then the timers stop and I am given an Input Box where I can change the Score to what I want it to be
        If CheatBox = True Then
            gameTimer.Stop()
            AITimer.Stop()
            plrScore = (InputBox("What do You want your Score to be?"))
            plrScoreDraw.Text = (plrScore)
            gameTimer.Start()
            AITimer.Start()
            CheatBox = False
        End If

        'The IF statement checks to see if the ball has passed the boundary or not if it has then the ball is moved back to the centre. This is just for error handling just in case the ball goes past but the game does not respond accordingly
        If gameBall.Location.X < pbLeftWall.Location.X Then
            BallShot = False
            gameBall.Location = OriginalLocation
        ElseIf gameBall.Location.X > pbRightWall.Location.X Then
            BallShot = False
            gameBall.Location = OriginalLocation
        End If

    End Sub

#End Region

#Region "Enemy Timer"
    Private Sub AITimer_Tick(sender As Object, e As EventArgs) Handles AITimer.Tick
        AIChecker = AIChecker - 100

        If AIActive = False Then 'If the AI isn't active the following code runs

            AICoolDown = AICoolDown - 50 'The Cooldown period starts to count down

            'If AI CoolDown goes below 0 it's set to 0
            If AICoolDown < 0 Then
                AICoolDown = 0
            End If

            'Once AI Cool Down period is 0 and the AI is still not active then the AI is turned on to be active and the cool down period is reset
            If AIActive = False And AICoolDown = 0 Then
                AIActive = True
                AICoolDown = 100
            End If

        End If

        'If the AIChecker goes below 0 it's set to 0
        If AIChecker < 0 Then
            AIChecker = 0
        End If


        'Once the AI checker is 0, the AI is turned on
        If AIChecker = 0 Then
            AIActive = True
        End If

        'If the players score is less than 5 then they have an even chance of getting the AI to turn off
        If plrScore < 5 Then

            If r.Next(0, 10) Mod 2 = 0 Then
                AIActive = True
            Else
                AIActive = False
            End If
        End If

        'If the Players Score is greater than 5 but less than 10 the player has more chance for the AI to stay active
        If plrScore > 5 And plrScore < 10 Then

            If r.Next(1, 10) Mod 2 = 0 Then
                AIActive = True
            Else
                AIActive = False
            End If

        End If

        'If the players score is greater then 10 and less than 15 then the player has an increased chance of the AI staying active
        If 10 < plrScore And plrScore < 15 Then

            If r.Next(1, 7) Mod 2 = 0 Then
                AIActive = True
            Else
                AIActive = False
            End If

        End If

        'If the Players Score is greater than 15 the player has high chance of the AI turning on
        If 15 > plrScore Then
            If r.Next(1, 3) Mod 2 = 0 Then
                AIActive = False
            Else
                AIActive = True
            End If
        End If

    End Sub
#End Region

#Region "Mad Mode"
    Private Sub madmodeTimer_Tick(sender As Object, e As EventArgs) Handles madmodeTimer.Tick
        MadMode()
    End Sub

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
            madmodeTimer.Stop() 'The named timer stops ticking
            Count = (InputBox("What do You want the Count to be?")) 'An input Box appears which allows me to change the count variable for testing and debugging
            gameTimer.Start() 'The game timer is started again
            AITimer.Start() 'The AI timer is also started again
            madmodeTimer.Start() 'Starts the named tiemr
            CheatBoxCount = False 'The Variable used in the statement is set to False I can access it multiple times at different times when the game is running
        End If

    End Sub

#End Region

#Region "Pause Menu and User Input"

    'When the Restart Button is Pressed the Whole Program will Restart
    Private Sub Restart_Click(sender As Object, e As EventArgs) Handles Restart.Click
        Application.Restart()
    End Sub

    'When this Button is Pressed the Game goes back to the Main Menu
    Private Sub Backto_Click(sender As Object, e As EventArgs) Handles Backto.Click
        Process.Start("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Pong Remakes\Pong - Core DONE\Pong Menu\Pong Menu\WindowsApp1\bin\Debug\WindowsApp1.exe")
        Environment.Exit(0)
    End Sub

    Private Sub pongMain_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        'When the Q Key is Pressed the Pause Menu will Display hiding everything on the Screen, also shows the position of the Cursor
        If e.KeyValue = Keys.Q Then
            gameBall.Hide()
            paddlePlayer.Hide()
            paddleComputer.Hide()
            Restart.Visible = True
            Backto.Visible = True
            Cursor.Show()
        ElseIf e.KeyValue = Keys.W Then
            gameBall.Show()
            paddleComputer.Show()
            paddlePlayer.Show()
            Restart.Visible = False
            Backto.Visible = False
            Cursor.Hide()
        ElseIf e.KeyValue = Keys.Space Then 'Allows the Ball to be Fired
            BallShot = True
        ElseIf e.KeyValue = Keys.A Then 'Used to Access the CheatBox
            CheatBox = True
        ElseIf e.KeyValue = Keys.Z Then 'Used to change Count for Mad Mode
            CheatBoxCount = True
        End If
    End Sub


#End Region

End Class