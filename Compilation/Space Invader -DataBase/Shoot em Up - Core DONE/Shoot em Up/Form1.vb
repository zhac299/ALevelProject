Public Class Form1

#Region "Variables"
    Dim MoveRight As Boolean = False 'This Variable controls wheather the Ship moves Right or Not
    Dim MoveLeft As Boolean = False 'This Variable controls wheather the Ship moves Left or Not    
    Dim MaxMissileNumber As Integer = 5 'This Variable holds the max number of Missiles, this value can be changed for user accessbility or if the game seems to difficult
    Dim MissileArray() As PictureBox 'This Variable allows me to have multiple Missiles on the screen at one given time, currently I have hardcoded the value to 5
    Dim MissileNumber As Integer = 0 'This Varaible is used to allocate each Missile released a Number
    Dim MissileOnScreen() As Boolean 'This Variable is used to count the number of Missiles on the Screen and will be used to limit the number that can be on the screen. In this case it has been given the value from the MaxMissileNumber Variable so if the value needs changing it can be if needed
    Dim MissileSpeed As Integer 'This Variable controls how fast a missile move
    Dim MaxEnemyNumber As Integer = 5 'This value will hold the Maximum number of Enemy on the Screen
    Dim EnemyArray() As PictureBox 'This Variable allows me to have the number of enemys on the screen to come and go, for instance if one enemy is defeated it will be removed from the array if an enemy is created the it will be added to the array as long as the MaxEnemyNumber Variable isn't exceeded
    Dim EnemyOnScreen() As Boolean 'This Variable is used to count the number of enemys on the screen and will be used to linit the number that can be on the screen at one instant. In this case it has been given the same value as MaxEnemyNumber so the amount can be changed if needed
    Dim Score As Integer = 0 'This Variable is Used to save the Score of the User
    Dim EnemySpeed As Single = 3 'This Variable is Used to alter the Enemys speed as they move. This is represented as a Single which is a decimal with one Decimal number after the decimal point
    Dim Sound As New Media.SoundPlayer 'This Variable is declared as a Sound Object used to run sound Files
    Dim UserInput As String 'This Variable will hold the Users Response to Input Boxes
#End Region

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load 'This Piece of Code runs as soon as the Form is loaded up

        UserInput = InputBox("Do you Want to Change some Settings?") 'If the correct response is given the user can edit their settings
        If UserInput = ("Yes") Then
            MaxMissileNumber = InputBox("What's the Max Missile Number you Want?") 'Asks the User How Many Missiles they want
            ReDim MissileArray(MaxMissileNumber) 'This Variable allows me to have multiple Missiles on the screen at one given time, currently I have hardcoded the value to 5
            ReDim MissileOnScreen(MaxMissileNumber) 'This Variable is used to count the number of Missiles on the Screen and will be used to limit the number that can be on the screen. In this case it has been given the value from the MaxMissileNumber Variable so if the value needs changing it can be if needed

            MaxEnemyNumber = InputBox("How many Enemy's Do you Want?") 'Asks the User how many Enemys they want
            MaxEnemyNumber = MaxEnemyNumber - 1
            ReDim EnemyArray(MaxEnemyNumber) 'This Variable allows me to have the number of enemys on the screen to come and go, for instance if one enemy is defeated it will be removed from the array if an enemy is created the it will be added to the array as long as the MaxEnemyNumber Variable isn't exceeded
            ReDim EnemyOnScreen(MaxEnemyNumber) 'This Variable is used to count the number of enemys on the screen and will be used to linit the number that can be on the screen at one instant. In this case it has been given the same value as MaxEnemyNumber so the amount can be changed if needed

            MissileSpeed = InputBox("How fast do you want your Missiles to Move?") 'Will allow the User to Chane how fast the Missiles Move

            EnemySpeed = InputBox("How Fast Do You Want the Enemys to Move?") 'Will affect how fast the enemy move

            Timer1.Start()
            scoreTimer.Start()
            enemyTimer.Start()

        Else
            ReDim MissileArray(MaxMissileNumber) 'This Variable allows me to have multiple Missiles on the screen at one given time, currently I have hardcoded the value to 5
            ReDim MissileOnScreen(MaxMissileNumber) 'This Variable is used to count the number of Missiles on the Screen and will be used to limit the number that can be on the screen. In this case it has been given the value from the MaxMissileNumber Variable so if the value needs changing it can be if needed
            ReDim EnemyArray(MaxEnemyNumber) 'This Variable allows me to have the number of enemys on the screen to come and go, for instance if one enemy is defeated it will be removed from the array if an enemy is created the it will be added to the array as long as the MaxEnemyNumber Variable isn't exceeded
            ReDim EnemyOnScreen(MaxEnemyNumber) 'This Variable is used to count the number of enemys on the screen and will be used to linit the number that can be on the screen at one instant. In this case it has been given the same value as MaxEnemyNumber so the amount can be changed if needed
            MissileSpeed = 5
            EnemySpeed = 5

            Timer1.Start()
            scoreTimer.Start()
            enemyTimer.Start()

        End If

        CreateMissiles(MaxMissileNumber) 'This calls the subroutine with the same name and makes it so only the Max Number of Missiles are made
        CreateEnemys(MaxEnemyNumber) 'This calls the subroutine with the same name and makes it so only the Max Number of Enemy are made 
        Sound.SoundLocation = ("E:\College Subjects\Computer Science\Computer Science NEA\My Games\Space Invader -DataBase\Shoot em Up - Core DONE\Shoot em Up\bin\Debug\Resources\Explosion.wav") 'This Piece of Code loads up the Sound from its location via its name

        Randomize() 'Makes it so a different Random Number is generated every single time a random number is made
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown 'This Code is ran when a Key is Pressed Down
        Dim Count As Integer = 1

        Select Case e.KeyValue
            Case Keys.Right  'When the Right Key is Pressed Down, the Variable MoveRight becomes True
                MoveRight = True
            Case Keys.Left 'When the Left Key is Pressed Down, the Variable MoveLeft becomes True
                MoveLeft = True
            Case Keys.Space 'When the Space Key is Pressed Down, a Missile is released vertically upwards

                Sound.SoundLocation = ("E:\College Subjects\Computer Science\Computer Science NEA\My Games\Space Invader -DataBase\Shoot em Up - Core DONE\Shoot em Up\bin\Debug\Resources\Shoot.wav") 'This Piece of Code loads up the Sound from its location via its name
                Sound.Play() 'This code plays the sound from the code above

                For i = 0 To MaxMissileNumber 'This Loop will count the Number of Missiles on Screen
                    If MissileOnScreen(i) = True Then 'If there are Missiles on screen then the following code in the IF Statement will be executed
                        Count = Count + 1 'Everytime the statement is true and space is pressed the Count Variable has 1 added to it. In essence this counts the number of Missiles on the Screen. This value can be used later to limit the amount of missiles on the screen
                    End If
                Next 'The Whole Loop will always count the number of Missiles there are on the screen and limit them to the number assigned

                If Count <= MaxMissileNumber Then ' This IF statement does the following: If the Number of Missiles is less than or equal to 5 then can you fire more missiles, if not you cannot fire anymore missiles.
                    MissileOnScreen(MissileNumber) = True 'This makes the MissileOnScreen Variable True only when count follows is requirement, then the number on missiles which can be on the screen becomes 5 
                    MissileArray(MissileNumber).Visible = True 'This Array stores all the Misiles on the Screen in the Array and makes them Visible so the player can see them
                    MissileArray(MissileNumber).Location = New Point(pbShip.Location.X + 16, pbShip.Location.Y) 'Makes the Missile Vertically Centered
                    MissileNumber += 1 'This code increments the MissileNumber by 1

                    If MissileNumber = MaxMissileNumber Then 'Once the Missile Number reaches 5 from the increments (above) the following code is ran
                        MissileNumber = 0 'This resets the MissileNumber back to 0, so the player can send out 5 missiles everytime there aren't atleast 5 missiles on the screen, if the MissileNumber wasn't reset then the player would only be able to shoot 5 missiles a game
                    End If

                End If

        End Select
    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp 'This Code is ran when a Key which was Down is released so it is now Up

        Select Case e.KeyValue
            Case Keys.Right 'When the Right Key is released, the Variable MoveRight becomes False, so the Ship stops moving Right
                MoveRight = False
            Case Keys.Left 'When the Left Key is release, the Variable MoveLeft Becomes False, so the Ship stops moving Left
                MoveLeft = False
        End Select

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick 'The Following Code is Excecuted every time the Timer Ticks

        If MoveRight = True Then 'If the Boolean Variable MoveRight is True then code inside the IF statement is executed
            pbShip.Left += 4 'Everytime the Timer Ticks the Ship moves one to the Right as the distance of the ship from the left increases by one each time
        End If

        If MoveLeft = True Then 'If the Boolean Variable MoveLeft is True then the code inside the IF statement is executed
            pbShip.Left -= 4  'Everytime the Timer Ticks the Ship moves one to the Left as the Distance from the Left decreases by one each time
        End If

        If pbShip.Bounds.IntersectsWith(pbLeftWall.Bounds) Then 'If the Ship gets to the boundary of the Form the following code is ran
            pbShip.Location = New Point(0, pbShip.Location.Y) 'Ship gets moved back to the boundary
        End If

        If pbShip.Bounds.IntersectsWith(pbRightWall.Bounds) Then 'If the Ship gets to the boundary of the Form then the following code is ran
            pbShip.Location = New Point(455, pbShip.Location.Y) 'Ship gets moved back to the boundary
        End If

        For i = 0 To MaxMissileNumber 'This FOR Loop allows the Missiles made (determined from MissileNumber which is found in Shooting) to move up
            If MissileOnScreen(i) = True Then 'If the Missiles on the Screen Then the following code is executed
                MissileArray(i).Top -= MissileSpeed 'The Missiles move up
            End If

            If MissileArray(i).Bounds.IntersectsWith(pbTopBoundary.Bounds) Then 'If the Missiles reach top of the screen then then the following code is executed
                MissileOnScreen(i) = False 'The ith missile (object at the ith position)  will be False when the Missile reaches the end of the screen as they won't be on the screen anymore
                MissileArray(i).Visible = False 'The missile dissapears
            End If

            For j = 0 To MaxEnemyNumber 'This Loop checks to see if the Missile Hits the Enemy or Not
                If MissileArray(i).Bounds.IntersectsWith(EnemyArray(j).Bounds) Then 'If the missile and enemy at the postion i and j respectivily collide the following code is executed

                    Sound.Play() 'This Piece of Code plays the sound assigned to Sound

                    MissileArray(i).Visible = False 'The missile dissapears
                    EnemyArray(j).Top = 0 'This Moves the Enemy back to the Top of the Form if a Missile and Enemy collide
                    EnemyArray(j).Left = CInt(Rnd() * Width) 'This moves the enemy to a random location on the X-Axis once it collides with a missile. This makes the Game more replayable so the game doesn't just end when there are no more enemys. The CInt() converts Value inside parenthesis to an integer for instance a Double Value to Integer
                End If
            Next

        Next

    End Sub

    Private Sub enemyTimer_Tick(sender As Object, e As EventArgs) Handles enemyTimer.Tick 'This Timer Controls the Enemy's movements
        Dim r As Double

        For i = 0 To MaxEnemyNumber 'This Loop makes sure all the enemys from 1 to 5 are affected

            EnemyArray(i).Top += EnemySpeed 'The enemy moves down at the speed assigned by variable EnemySpeed

            EnemyArray(i).Top += EnemySpeed 'This makes the Enemys move Down

            If EnemyArray(i).Bounds.IntersectsWith(pbBottomBoundary.Bounds) Then 'The Following IF statement does the following if the Enemy moves past the bottom of the screen
                Timer1.Stop() 'The Main Timer Stops
                enemyTimer.Stop() 'The Enemy Timer Stops
                scoreTimer.Stop() 'The Score Timer Stops so the Player stops gaining any more points to their score
                MsgBox("Game Over Your Score is " & Score) 'MessageBox appears which states game over with the players score
                Application.Exit()
            End If

            r = Rnd() 'Makes it so Random is equal to a random number between 0 and 1, as Random is Double it can also be decimals

            If r > 0.5 Then 'If r > 0.5 then the following code is executed
                EnemyArray(i).Left += 5 'The Enemy Moves Right 5 Pixels each time a random number is generated which is > 0.5
            Else 'Otherwise if the r Variable < 0.5 then the following code is executed
                EnemyArray(i).Left -= 5 'The Enemy Moves Left 5 Pixels each time a random number is generated which is < 0.5
            End If

            If EnemyArray(i).Bounds.IntersectsWith(pbLeftWall.Bounds) Then 'If the Enemy moves hits the left wall then the following code moves them back in
                EnemyArray(i).Location = New Point(0, EnemyArray(i).Location.Y) 'Enemy is Moved to the Boundary
            End If

            If EnemyArray(i).Bounds.IntersectsWith(pbRightWall.Bounds) Then 'If the Enemy hiys the right wall then the Following Code moves them back in
                EnemyArray(i).Location = New Point(455, EnemyArray(i).Location.Y) 'Enemy is Moved to the Boundary
            End If
        Next

    End Sub

    Private Sub scoreTimer_Tick(sender As Object, e As EventArgs) Handles scoreTimer.Tick 'This Timer is used to keep track of the players score every 1000ms
        Score += 1 'The Score Increments by 1 every timer the Timer Ticks
        lblScore.Text = ("Score: " & Score) 'The label which displays the Score will show the score using this Code
        If Score Mod 5 = 0 Then 'When Score is Divided by 5 and the Remainder is 0 the following code is executed and as only multiples of 5 will have a mod of 0 this occurs everytime the score is a multiple of 5
            EnemySpeed += 1.5 'If the IF statement requirement is fufilled the enemy speed increased by 1.5
        End If
    End Sub

    Private Sub CreateMissiles(ByVal Number As Integer) 'This Sub Routine makes the Missiles
        For i = 0 To Number
            Dim Missile As New PictureBox 'This Variable makes the Picturebox for me so I don't have to make it on the form itself
            Me.Controls.Add(Missile) 'The Me refers to the Form (in this case is Form1), so this piece of code adds the PictureBox to Form1 and allows me to control it in the sense that I can manipulate its properties
            Missile.Height = 10 'The Missiles Width
            Missile.Width = 5 'The Missiles Height
            Missile.BorderStyle = BorderStyle.FixedSingle 'The Border of the PictureBox is a single Line which does not move away from the picturebox making sure the whole picturebox is one entity
            Missile.BackColor = Color.White 'The Missiles Colour is white
            Missile.Top = pbShip.Top + pbShip.Height / 2 - Missile.Height / 2 'Makes the Missile Vertically Centered
            Missile.Left = pbShip.Left + pbShip.Width / 2 - Missile.Width / 2 'Makes the Missile Horizontally Centered
            Missile.BringToFront() 'Brings the Missile infront of the Ship when the Space Key is Pressed
            MissileArray(i) = Missile 'The Number of Missiles in the Array is i, this is done to limit the number of missiles and so the program runs more efficiently rather than having the value increment by using ReDim and Preserve and using MissileArray(MissileNumber) = Missile, in essence this Variable will hold the missiles in the Array, that will be fired off and when they are they are removed from the array
            MissileArray(i).Visible = False 'Makes the Missile invisible            
            MissileOnScreen(i) = False 'This piece of code makes it so the missiles being made aren't considered on the screen until the Form1_KeyDown event checks to see if there are 5 missiles on the screen or not
        Next
    End Sub

    Private Sub CreateEnemys(ByVal Number As Integer)
        For i = 0 To Number
            Dim Enemy As New PictureBox 'This Variable makes the Picturebox for me so I don't have to make it on the form itself
            Me.Controls.Add(Enemy) 'The Me refers to the Form (in this case is Form1), so this piece of code adds the PictureBox to Form1 and allows me to control it in the sense that I can manipulate its properties
            Enemy.Height = 20 'The Enemys Width
            Enemy.Width = 20 'The Enemys Height
            Enemy.BorderStyle = BorderStyle.FixedSingle 'The Border of the PictureBox is a single Line which does not move away from the picturebox making sure the whole picturebox is one entity
            Enemy.BackColor = Color.Red 'The Enemy Colour is Red
            Enemy.Top = 50 'Makes it so the enemys are 50 pixels from the Top
            Enemy.Left = i * 80 'Spreads out the Enemys 80 pixels apart
            Enemy.BringToFront() 'Brings the Enemy infront of anything that was in front
            EnemyArray(i) = Enemy 'The Number of Enemys in the Array is i, this is done to limit the number of enemys and so the program runs more efficiently, in essence this Variable will hold the Enemys in the Array
            EnemyOnScreen(i) = True 'This piece of code makes it so the enemys being made aren't considered on the screen until the Form1_KeyDown event checks to see if there are 5 enemys on the screen or not
            Enemy.Visible = True 'Makes the Enemy invisible until called to be visible
        Next
    End Sub

End Class