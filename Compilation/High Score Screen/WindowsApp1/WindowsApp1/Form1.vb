Imports System.IO
Public Class Form1

#Region "Variables"
    'The Path of the Files are stored here, the variable name states which file it is referring to
    Dim PacManUserNamePath As String = ("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\PacMan Menu\PacMan Menu\bin\Debug\Username.txt")
    Dim MyGameUsernamePath As String = ("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Bling Bling Boy\Bling Bling Boy\Bling Bling Boy\bin\Debug\Username.txt")
    Dim SpaceInvadersUsernamePath As String = ("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Space Invader -DataBase\Space Invader Main Game - Database\Space Invader Main Game\bin\Debug\Username.txt")
    Dim FlappyBirdUsernamePath As String = ("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Flappy Bird -DataBase\Flappy Bird - Core DONE\Flappy Bird\Flappy Bird\bin\Debug\Username.txt")

    'The Values below store all the usernames and scores from the username file into a array
    Dim PacManUserNameArray() As String = File.ReadAllLines("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\PacMan Menu\PacMan Menu\bin\Debug\JustUserName.txt")
    Dim MyGameUserNameArray() As String = File.ReadAllLines("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Bling Bling Boy\Bling Bling Boy\Bling Bling Boy\bin\Debug\JustUserName.txt")
    Dim SpaceInvadersUserNameArray() As String = File.ReadAllLines("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Space Invader -DataBase\Space Invader Main Game - Database\Space Invader Main Game\bin\Debug\JustUserName.txt")
    Dim FlappyBirdUserNameArray() As String = File.ReadAllLines("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Flappy Bird -DataBase\Flappy Bird - Core DONE\Flappy Bird\Flappy Bird\bin\Debug\JustUserName.txt")

    'Below all the Lists are declared which are used to pass values through
    Dim PacManList As New List(Of String)
    Dim MyGameList As New List(Of String)
    Dim SpaceInvadersList As New List(Of String)
    Dim FlappyBirdList As New List(Of String)

    Dim UserNamesList As New List(Of String)() 'List is used to store all the Usernames of the users
    Dim UserNamesWithSumList As New List(Of String)() 'List is used to store all the Username of the users alongisde the sum of their scores from each game
    Dim DistinctUserNamesWithSum As New List(Of String) 'Used to remove repeated data from the List Above
    Dim UserNames() As String 'Stores all the Usernames in a array
    Dim UserNamesWthSum() As String 'Stores all the the Username with their sum in a array
    Dim PlainUserName As String 'Used to pass the UserName of the Username where it's required
    Dim JustScoreList As New List(Of Integer)() 'List stores just the Scores of the Users
    Dim JustScore() As Integer 'Array will store just the scores of the users

    Dim UserInput As String 'Used to Pass User Inputs into the program
    Dim ScoreOfUser As Integer 'Stores the Score of a single User
#End Region

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        File.WriteAllText("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\High Score Screen\WindowsApp1\WindowsApp1\bin\Debug\Username.txt", "") 'Clears the Username Text File when the Program is Launched
        File.WriteAllText("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\High Score Screen\WindowsApp1\WindowsApp1\bin\Debug\Score.txt", "") 'Clears the Score Text File When the Program is Launched

        'Code below calls sub routine by the same name and passes the UserName array through it
        StoreUserName(PacManUserNameArray)
        StoreUserName(MyGameUserNameArray)
        StoreUserName(SpaceInvadersUserNameArray)
        StoreUserName(FlappyBirdUserNameArray)

        'Gets the Program to get the UserName of each player and get the Sum of each user with the GetSumOfSinglePlayer Sub Routine
        For i = 0 To UserNames.Length - 1
            PlainUserName = UserNames(i)

            GetSumofSingleUser(PlainUserName)
        Next

        UserNamesWthSum = DistinctUserNamesWithSum.ToArray() 'Makes a New Array with the Distinct Values in only

        WriteToTextFileUserNames() 'Calls Sub Routine by the same name here

        GetValue() 'Calls Sub Routine by the same name here

        'FOR Loop Below goes through each value in just score and writes it to the Score text file
        For i = 0 To JustScore.Length - 1

            Using Writer As New StreamWriter("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\High Score Screen\WindowsApp1\WindowsApp1\bin\Debug\Score.txt", True)
                Writer.WriteLine(JustScore(i))
            End Using

        Next

        MergeSort(JustScore) 'Sorts the Data with the Merge Sort Algorithm by passing through the JustScore array

        WriteToLabels() 'Calls the SUb Routine by the same name here

    End Sub

    Private Sub butSearch_Click(sender As Object, e As EventArgs) Handles butSearch.Click
        BinarySearch() 'Launches the Binary Search Algorithm
    End Sub

    Private Sub butFind_Click(sender As Object, e As EventArgs) Handles butFind.Click
        UserInput = InputBox("What is Your UserName?") 'Asks the Player who wants to know their score, stores their username in UserInput

        GetValueDependentonUser() 'Calls SUb Routine by the same name here

        MessageBox.Show("Your Score is " & ScoreOfUser) 'Tells the player their score through a message box
    End Sub

    Private Sub GetSumofSingleUser(ByVal WrittenUserNames As String)

        'Adds the data from each games Username text file to the correct list
        PacManList.AddRange(IO.File.ReadAllLines(PacManUserNamePath))
        MyGameList.AddRange(IO.File.ReadAllLines(MyGameUsernamePath))
        SpaceInvadersList.AddRange(IO.File.ReadAllLines(SpaceInvadersUsernamePath))
        FlappyBirdList.AddRange(IO.File.ReadLines(FlappyBirdUsernamePath))

        'Provides Indexs to use when going through lists
        Dim pacIndex As Integer = 0
        Dim myGameIndex As Integer = 0
        Dim spaceinvadersIndex As Integer = 0
        Dim flappybirdIndex As Integer = 0

        'Each FOR Loop for each game finds all the Username and Score from their Lists
        For i As Integer = 0 To PacManList.Count - 1
            If PacManList(i).StartsWith(WrittenUserNames) Then
                pacIndex = i
            End If
        Next

        For i As Integer = 0 To MyGameList.Count - 1
            If MyGameList(i).StartsWith(WrittenUserNames) Then
                myGameIndex = i
            End If
        Next

        For i As Integer = 0 To SpaceInvadersList.Count - 1
            If SpaceInvadersList(i).StartsWith((WrittenUserNames)) Then
                spaceinvadersIndex = i
            End If
        Next

        For i As Integer = 0 To FlappyBirdList.Count - 1
            If FlappyBirdList(i).StartsWith((WrittenUserNames)) Then
                flappybirdIndex = i
            End If
        Next

        'Seperated the data into two parts when a comma is present
        Dim pacSplit() As String = Split(PacManList(pacIndex), ",")
        Dim mygameSplit() As String = Split(MyGameList(myGameIndex), ",")
        Dim spaceinvadersSplit() As String = Split(SpaceInvadersList(spaceinvadersIndex), ",")
        Dim flappybirdSplit() As String = Split(FlappyBirdList(flappybirdIndex), ",")

        'Finds the Sum of all of the Scores from each game
        Dim sum As Integer = Integer.Parse(Trim(pacSplit(1))) + Integer.Parse(Trim(mygameSplit(1))) + Integer.Parse(Trim(spaceinvadersSplit(1))) + Integer.Parse(Trim(flappybirdSplit(1)))

        'Used to reduce bugs by removing any empty usernames
        If WrittenUserNames <> "" Then 'If the Username field isn't empty then we write it otherwise we don't
            Dim finaltext As String = (WrittenUserNames & ", " & sum.ToString) 'Stores the Username of the user alongside the sum of their scores

            UserNamesWithSumList.Add(finaltext) 'Adds the Username and the sum of each user to the List
            DistinctUserNamesWithSum = UserNamesWithSumList.Distinct().ToList 'Removes Repeated Entrys
        End If

    End Sub

    Private Sub StoreUserName(ByVal arr() As String)
        'Adds all the Username to the List below
        For i = 0 To arr.Length - 1
            UserNamesList.Add(arr(i))
        Next

        'Removes Duplicated values when moving data to array
        UserNames = UserNamesList.Distinct().ToArray
    End Sub

    Private Sub WriteToTextFileUserNames()
        'Writes all data to the UserName Text File from the DistinctUserNameWithSum List
        For i = 0 To DistinctUserNamesWithSum.Count - 1
            Using Writer As New StreamWriter("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\High Score Screen\WindowsApp1\WindowsApp1\bin\Debug\Username.txt", True)
                Writer.WriteLine(DistinctUserNamesWithSum(i))
            End Using
        Next
    End Sub

    Private Sub GetValue()
        'Goes through each UserName and adds the sum of their scores to JustScore
        For Each Data As String In UserNamesWthSum
            For i = 0 To UserNames.Length - 1
                PlainUserName = UserNames(i)

                If Data.StartsWith(PlainUserName & ",") Then
                    JustScoreList.Add(Integer.Parse(Data.Split(","c)(1)))
                End If
            Next
        Next

        JustScore = JustScoreList.ToArray() 'Converts List to Array

    End Sub

    Private Function GetValueDependentonUser()
        'If a User is looking for their score and they aren't on the top 5 they can look their score up here
        For Each Data As String In UserNamesWthSum
            If Data.StartsWith(UserInput & ",") Then 'Checks to see if data has the users provided username
                ScoreOfUser = Integer.Parse(Data.Split(","c)(1)) 'Splits the Data so ScoreOfUser only contains the Score of the User
            End If
        Next

        Return ScoreOfUser
    End Function

    Private Sub MergeSort(ByVal Array() As Integer)
        'Calls the Merge Sort Algorithm with the correct values inside the parameters using the array that it MergeSort was called with

        MergeSortAlgorithm(Array, 0, Array.Length - 1)

    End Sub

    Private Sub MergeSortAlgorithm(ByVal Array() As Integer, ByVal Low As Integer, ByVal High As Integer)
        'Merge Sort Algorithm can be seen below

        If Low >= High Then Return
        Dim Length As Integer = High - Low + 1
        Dim Middle As Integer = Math.Floor((Low + High) / 2)
        MergeSortAlgorithm(Array, Low, Middle)
        MergeSortAlgorithm(Array, Middle + 1, High)
        Dim Temporary(Array.Length - 1) As Integer
        For i As Integer = 0 To Length - 1
            Temporary(i) = Array(Low + i)
        Next
        Dim Point1 As Integer = 0
        Dim Point2 As Integer = Middle - Low + 1
        For i As Integer = 0 To Length - 1
            If Point2 <= High - Low Then
                If Point1 <= Middle - Low Then
                    If Temporary(Point1) > Temporary(Point2) Then
                        Array(i + Low) = Temporary(Point2)
                        Point2 += 1
                    Else
                        Array(i + Low) = Temporary(Point1)
                        Point1 += 1
                    End If
                Else
                    Array(i + Low) = Temporary(Point2)
                    Point2 += 1
                End If
            Else
                Array(i + Low) = Temporary(Point1)
                Point1 += 1
            End If
        Next

    End Sub

    Sub BinarySearch()
        'Binary Search Algorithm can be Seen Below

        Dim Result As Integer = -1
        Dim Low As Integer = 0
        Dim High As Integer = JustScore.Length - 1
        Dim Middle As Integer
        Dim UserInput As Integer

        UserInput = InputBox("What is Your Score?")

        While Low <= High And Result = -1
            Middle = (Low + High) / 2
            If UserInput = JustScore(Middle) Then
                Result = Middle
            ElseIf UserInput < JustScore(Middle) Then
                High = Middle - 1
            ElseIf UserInput > JustScore(Middle) Then
                Low = Middle + 1
            End If
        End While

        If Result < 0 Then
            MessageBox.Show("Your Value Isn't in the List")
        Else
            Result = JustScore.Length - Result
            MessageBox.Show("Your Value is at the " & Result & " Place in the List")
        End If


    End Sub

    Private Sub WriteToLabels()
        'Variables below are used to write the correct data to the labels on Form
        Dim Position As Integer
        Dim temp As String

        'Finds the Username of the User with the highest score and stores it in temp then writes data to label
        For Each Data As String In UserNamesWthSum

            If Data.EndsWith(", " & JustScore.Last) Then
                temp = Data.Split(","c)(0)
                lblBest.Text = ("1:" & temp & "-" & JustScore.Last)
            End If

            'Finds the Username of the User with the second highest score and stores it in temp then writes data to label
            Position = JustScore.Length - 2
            If Data.EndsWith(", " & JustScore(Position)) Then
                temp = Data.Split(","c)(0)
                lblSecond.Text = ("2:" & temp & "-" & JustScore(Position))
            End If

            'Finds the Username of the User with the third highest score and stores it in temp then writes data to label
            Position = JustScore.Length - 3
            If Data.EndsWith(", " & JustScore(Position)) Then
                temp = Data.Split(","c)(0)
                lblThird.Text = ("3:" & temp & "-" & JustScore(Position))
            End If

            'Finds the Username of the User with the fourth highest score and stores it in temp then writes data to label
            Position = JustScore.Length - 4
            If Data.EndsWith(", " & JustScore(Position)) Then
                temp = Data.Split(","c)(0)
                lblFourth.Text = ("4:" & temp & "-" & JustScore(Position))
            End If

            'Finds the Username of the User with the fifth highest score and stores it in temp then writes data to label
            Position = JustScore.Length - 5
            If Data.EndsWith(", " & JustScore(Position)) Then
                temp = Data.Split(","c)(0)
                lblFifth.Text = ("5:" & temp & "-" & JustScore(Position))
            End If

        Next

    End Sub

End Class
