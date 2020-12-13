Public Class Form1

    Dim Yspeed As Integer = 0 'Vertical Speed of pbBird
    Dim Gravity As Integer = 2 'This Value Determines how quick pbBird Falls, the bigger it is the quicker it falls
    Dim Pipe(2) As PictureBox 'Acts like an Array with the number of Pipes inside the Parameter
    Dim TopPipe(2) As PictureBox 'Acts Like an Array with the Number of Pipes inside the Parameter
    Dim GapBetweenPipes As Integer = 475 'Allows the User to change the Gap between the Pipes if they think the game is either too easy or hard
    Dim PipeSpeed As Single = 3.5 'Variable controls how fast the Pipes Move
    Dim Lives As Integer = 0 'Stores the Players Lives 
    Dim InvincibilityTimer As Integer = 1000 'Times how long player can stay invincible
    Dim r As Random = New Random 'Used to generate Random Numbers
    Dim Score As Integer = 0 'Stores the Players Score
    Dim UserInput As String 'Used to hold the users input

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize() 'Calls the inbuilt Randomize Function here
        UserInput = InputBox("Do you want to play with Random Mode or Not?") 'Lets the User Choose if they want to play with Random Mode or Not
        Timer1.Start() 'Starts the named Timer
        RandomEvent.Start() 'Starts the named Timer
        CreatePipes(1) 'Calls the Private Sub with the Same Name
        CreateTopPipes(1) 'Calls the Private Sub with the Same Name
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        InvincibilityTimer = InvincibilityTimer - 10 'When InvincibiltyTimer is below or equal to 0 then collsion can occur

        Yspeed += Gravity 'Everytime Timer Ticks Yspeed increases by 2 so from 2 to 4 to 6 following a geometric progrssion
        pbBird.Top += Yspeed 'Increase speed varaible by gravity and Top position of pbBird increases by whatever the speed variable is, starting at 0

        For i = 0 To 1 'This For Loop allows the Pipes to move to the Left Hand side of the Screen
            Pipe(i).Left -= PipeSpeed
            TopPipe(i).Left -= PipeSpeed

            If Pipe(i).Location.X < pbBird.Location.X Then
                Score += 1
                TopPipe(i).Left += 400 'Allow the Pipes to Loop so Pipe keep going to Right Hand Side
                Pipe(i).Left += 400 'Allow the Pipes to Loop so Pipe keep going to Right Hand Side
                Pipe(i).Top = r.Next(125, 350) 'Makes sure a Random Size is given each time
                TopPipe(i).Top = Pipe(i).Top - GapBetweenPipes 'This makes sure their is a gap of a constant size between the top pipe and bottom pipe

                'The IF Statement checks to see if the players score is a multiple of 5 if it is then the player becomes invinsible for a short period of time
                If Score Mod 5 = 0 Then
                    lblIndicator.Visible = True
                    lblIndicator.Text = ("You are Currently Invinsible")
                    InvincibilityTimer = 1000
                End If
            End If

            'If Ready is below or equal to 0 then collision detection can occur else it doesn't
            If InvincibilityTimer <= 0 Then
                lblIndicator.Visible = False
                If (pbBird.Bounds.IntersectsWith(Pipe(i).Bounds)) Or (pbBird.Bounds.IntersectsWith(TopPipe(i).Bounds)) Then 'Code makes it so if pbBird touches any Pipe the Game Ends
                    If Lives = 0 Then
                        Timer1.Stop()
                        MessageBox.Show("Your Score is " & Score)
                        Application.Exit()
                    End If
                End If
            End If
        Next

        'The Code below checks to see if the bird has collided with the top or bottom wall and if the bird does the game endsf
        If (pbBird.Bounds.IntersectsWith(pbTopWall.Bounds)) Then
            Timer1.Stop()
            MessageBox.Show("Your Score is " & Score)
            Application.Exit()
        ElseIf (pbBird.Bounds.IntersectsWith(pbBottomWall.Bounds)) Then
            Timer1.Stop()
            MessageBox.Show("Your Score is " & Score)
            Application.Exit()
        End If

        'Displays the Score to the User
        lblScore.Text = (Score)

    End Sub

    Private Sub RandomEvent_Tick(sender As Object, e As EventArgs) Handles RandomEvent.Tick
        If UserInput = "Yes" Then 'If the user inputs any of the options given Random Mode will work
            RandomEventCaller() 'Calls Sub Routine by the same name here
        Else
            'Do Nothing
        End If
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Space Then 'When Space is pressed the following code takes place
            Yspeed = -15 'If pbBird is falling down speed will be positive, if pbBird is going up speed has to be negative for pbBird to go up
        End If
    End Sub

    Private Sub CreatePipes(ByVal Number As Integer)
        'The Code Below Generates Pipes that appear at the bottom of the screen

        Dim i As Integer = 0 'Used for Loops
        For i = 0 To Number
            Dim pbTemp As New PictureBox 'Variable allows me to Dynamically make new pictureboxes on Form without using pictureboxes so program is more efficient
            Me.Controls.Add(pbTemp) 'Adds pbTemp to the Form with the properties of the picturebox being given below
            pbTemp.Width = 50
            pbTemp.Height = 350
            pbTemp.BorderStyle = BorderStyle.FixedSingle
            pbTemp.BackColor = Color.Green
            pbTemp.Top = r.Next(70, 350)  'Generates a Number Between the Range 70-300
            pbTemp.Left = i * 200 + 300 'Uses to Calculate the Number of Pipes as well as their distance from pbBird similiar to a function f(x) on a graph
            Pipe(i) = pbTemp
            Pipe(i).Visible = True 'Makes the picturebox visible
        Next
    End Sub

    Private Sub CreateTopPipes(ByVal Number As Integer)
        'The Code Below Generates Pipes which appear at the top of the screen

        Dim i As Integer = 0 'Used for Loops
        For i = 0 To Number
            Dim pbTemp As New PictureBox 'Variable allows me to Dynamically make new pictureboxes on Form without using pictureboxes so program is more efficient
            Me.Controls.Add(pbTemp) 'Adds pbTemp to the Form with the properties of the picturebox being given below
            pbTemp.Width = 50
            pbTemp.Height = 350
            pbTemp.BorderStyle = BorderStyle.FixedSingle
            pbTemp.BackColor = Color.Green
            pbTemp.Top = r.Next(-350, -70) + 350 'Creates a consistent gap between each pipe
            pbTemp.Left = i * 200 + 300 'Uses to Calculate the Number of Pipes as well as their distance from pbBird similiar to a function f(x) on a graph
            TopPipe(i) = pbTemp
            TopPipe(i).Visible = True 'Makes the picturebox visible
        Next
    End Sub

    Private Sub RandomEventCaller() 'Random Events are Declared here with the use of the Random Number Generator
        Dim x As Integer 'Stores a Random Number
        x = r.Next(0, 20) 'Chooses a Random Number Betwen 20 and 0

        If x = 0 Then 'If the Number Generated is 0 then the following code runs
            InvincibilityTimer = 1000
            lblIndicator.Text = ("You are Invinsible")
            lblIndicator.Visible = True 'Player gets indicated that they are invinsible
        End If

        If x = 1 Then 'If the number generated is 1 then the following code is ran
            'The player gains 3 points for crossing each pipe
            For i = 0 To 1
                If Pipe(i).Left < 0 Then
                    Score += 3
                    lblIndicator.Text = ("You currently gain 3 Points for each Pipe") 'Informs player of this effect
                    lblIndicator.Visible = True
                    TopPipe(i).Left += 400 'Allow the Pipes to Loop so Pipe keep going to Right Hand Side
                    Pipe(i).Left += 400 'Allow the Pipes to Loop so Pipe keep going to Right Hand Side
                    Pipe(i).Top = r.Next(350, 125) 'Makes sure a Random Size is given each time
                    TopPipe(i).Top = Pipe(i).Top - GapBetweenPipes 'This makes sure their is a gap of a constant size between the top pipe and bottom pipe
                End If
            Next
        End If

        If x = 4 Then 'If the Number Generated is 4 then the follwing code is ran
            'The player doesn't gain any points for passing a pipe
            For i = 0 To 1
                If Pipe(i).Left < 0 Then
                    Score += 0
                    lblIndicator.Text = ("You currently gain 0 Points for each Pipe") 'Informs player of this effect
                    lblIndicator.Visible = True
                    TopPipe(i).Left += 400 'Allow the Pipes to Loop so Pipe keep going to Right Hand Side
                    Pipe(i).Left += 400 'Allow the Pipes to Loop so Pipe keep going to Right Hand Side
                    Pipe(i).Top = r.Next(350, 125) 'Makes sure a Random Size is given each time
                    TopPipe(i).Top = Pipe(i).Top - GapBetweenPipes 'This makes sure their is a gap of a constant size between the top pipe and bottom pipe
                End If
            Next
        End If

        If x = 5 Then 'If the number generated is 5 then the following code runs
            'The player gains one life
            Lives += 1
            lblIndicator.Text = ("You gained one Life") 'Informs player of this effect
            lblIndicator.Visible = True
        ElseIf r.Next(0, 20) = 7 Then 'If the Number generated is 7 then the following code runs
            'The player instantly dies
            lblIndicator.Text = ("You Have Died Instantly") 'Informs player of this effect
            lblIndicator.Visible = True
            Timer1.Stop() 'Stops the Timer
            MessageBox.Show("Your Score is " & Score) 'MessageBox appears telling the player their final score
            Application.Exit() 'Closes the Program
        End If

        If x = 2 Then 'If the number generated is 2 then

            'Players bird becomes invisible
            While InvincibilityTimer > 0
                lblIndicator.Text = ("You are now Invisible") 'Informs player of this effect
                lblIndicator.Visible = True
                pbBird.Visible = False
            End While

        End If

        If x = 3 Then 'If the RandomNumber generated is 3 then the following code is ran        z
            lblIndicator.Text = ("Pipes are Now Moving Slower") 'Informs player of this effect
            lblIndicator.Visible = True
            PipeSpeed = 1 'The speed at which the pipes come slows down
        ElseIf r.Next(0, 20) = 6 Then 'If the RandomNumber generated is 6 then the following code is ran
            lblIndicator.Text = ("Pipes are Now Moving Faster") 'Informs player of this effect
            lblIndicator.Visible = True
            PipeSpeed = 6.5 'The Pipes speed up
        End If

    End Sub

End Class