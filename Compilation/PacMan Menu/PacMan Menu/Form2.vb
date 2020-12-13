Imports System.IO

Public Class Form2

#Region "Variables"
    Dim NumOfValues As Integer = 0 'Used to Count the Size of JustScore Array
    'Variable Below Stores the Usernames and Scores from the PacMan Game
    Dim PacManTextFile() As String = IO.File.ReadAllLines("E:\College Subjects\Computer Science\Computer Science NEA\My Games\PacMan Unity\Help\PacMan Clone\PacMan Clone\Assets\Text File\Username.txt")
    Dim Username() As String 'Stores all the Usernames in this array
    Dim temporaryCheck() As String 'Array is used to check for duplicate data
    Dim JustScore(NumOfValues) As Integer 'Array will only store the Scores
    Dim JustUserName() As String = IO.File.ReadAllLines("E:\College Subjects\Computer Science\Computer Science NEA\My Games\PacMan Menu\PacMan Menu\bin\Debug\JustUserName.txt") 'Array Will only store the Usernames
    Dim JustUserNameVal As String 'Holds the Value of the Username when it is seperated from the score
    Dim CheckExists() As String 'Used alongside temporaryCheck to check for duplicate data
    Dim UserInput As String 'Will hold all UserInput
    Dim ScoreOfUser As Integer 'Will Hold the score of a single User
    Dim temp As String 'Temp variable used to store data which needs holding on to for a while
    Dim GlobalNum As Integer 'Used to turn a local value into a Global Value
    Dim count As Integer = 0 'Used with CheckExists and TemporaryCheck to find Duplicated Dataw
#End Region

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Stores the Username and Score from the PacMan file into temp when the Form Loads
        For i = 0 To PacManTextFile.Length - 1
            temp = PacManTextFile(i)
        Next
    End Sub

    Private Sub butQuit_Click(sender As Object, e As EventArgs) Handles butQuit.Click
        Application.Exit() 'Closes the Application
    End Sub

    Private Sub butStart_Click(sender As Object, e As EventArgs) Handles butStart.Click

        'Code Below Checks if temp is empty, if it is then we write to username for the first time otherwise data already exists and we make temp empty and write the new value to temp
        If File.ReadAllText("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\PacMan Menu\PacMan Menu\bin\Debug\temp.txt").Length = 0 Then
            MsgBox("Storing First Data")
            'Writes temp to Username File
            Using Writer As New IO.StreamWriter("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\PacMan Menu\PacMan Menu\bin\Debug\Username.txt", True)
                Writer.WriteLine(temp)
            End Using
            GettingJustScore() 'Calls Sub Routine by the same name here
        Else 'If data is present in the temp file then
            MsgBox("Existing Data...")
            System.IO.File.WriteAllText("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\PacMan Menu\PacMan Menu\bin\Debug\temp.txt", "") 'Makes temp empty
            Using Writer As New IO.StreamWriter("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\PacMan Menu\PacMan Menu\bin\Debug\temp.txt", True) 'Writes temp value to temp
                Writer.WriteLine(temp)
            End Using
        End If

        temporaryCheck = IO.File.ReadAllLines("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\PacMan Menu\PacMan Menu\bin\Debug\temp.txt") 'Reads temp

        CheckExists = IO.File.ReadAllLines("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\PacMan Menu\PacMan Menu\bin\Debug\Username.txt") 'Reads username

        'Checks if the Score already exists in the database 
        For i = 0 To temporaryCheck.Length - 1
            For j = 0 To CheckExists.Length - 1

                If CheckExists(j) = temporaryCheck(i) Then 'If the Data already exists count is set to 0
                    count = 0
                ElseIf CheckExists(j) <> temporaryCheck(i) Then 'If the Data doesn't exist count is incremented by one
                    count += 1
                End If

            Next

            If count > 0 Then 'If the Value of Count is greater then its base value then data is writen
                'Writes temp to Username
                Using Writer As New IO.StreamWriter("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\PacMan Menu\PacMan Menu\bin\Debug\Username.txt", True)
                    Writer.WriteLine(temp)
                End Using
                'Reads the Username Text File to Username
                Username = IO.File.ReadAllLines("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\PacMan Menu\PacMan Menu\bin\Debug\Username.txt")
            End If

            GettingJustScore() 'Calls Sub Routine by the same name here
        Next


        Dim CheckJustUserName() As String = IO.File.ReadAllLines("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\PacMan Menu\PacMan Menu\bin\Debug\JustUserName.txt") 'Reads username
        Dim count2 As Integer = 0 'Used to remove duplicate data
        Dim Score() As String = File.ReadAllLines("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\PacMan Menu\PacMan Menu\bin\Debug\score.txt") 'Reads score to Score array
        Username = IO.File.ReadAllLines("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\PacMan Menu\PacMan Menu\bin\Debug\Username.txt") 'Reads all the Usernames with scores to Username

        If CheckJustUserName.Length < 1 Then 'If the JustUsername array is empty so checks if file is empty if it is then the following code is ran
            'Nested FOR Loops Used to go through Username and Score Array 
            For i = 0 To Username.Length - 1
                For j = 0 To Score.Length - 1
                    'Code Below Seperates the Username and Score by using the comma as a delimiter
                    For Each Data As String In Username
                        If Data.EndsWith(", " & Score(j)) Then
                            If Not Integer.Parse(Data.Split(","c)(1)) Then 'If the value cannot be turned into a integer then the following code is ran
                                JustUserNameVal = Data.Split(","c)(0) 'Stores the just the UserName in JustUserNameVal

                                'Writes just the Username to the JustUserName text file
                                Using Writer As New IO.StreamWriter("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\PacMan Menu\PacMan Menu\bin\Debug\JustUserName.txt", True)
                                    Writer.WriteLine(JustUserNameVal)
                                End Using
                            End If
                        End If
                    Next
                Next

            Next

        Else 'If there already is data in JustUserName Text File then the following code is ran

            'Loops through JustUserName array and Score Array
            'The Nested FOR Loops Seperates the Username from score using Split 
            For i = 0 To JustUserName.Length - 1
                For j = 0 To Score.Length - 1
                    For Each Data As String In Username
                        If Data.EndsWith(", " & Score(j)) Then
                            If Not Integer.Parse(Data.Split(","c)(1)) Then

                                JustUserNameVal = Data.Split(","c)(0)

                                'If the Username already is in file then count is set to base value of 0
                                If CheckJustUserName(i) = JustUserNameVal Then
                                    count2 = 0
                                    'If the Username doesn't exist in file then count is incremented by 1
                                ElseIf CheckJustUserName(i) <> JustUserNameVal Then
                                    count2 += 1
                                End If

                            End If
                        End If
                    Next
                Next
            Next
            'If Count2 is greater then base value (0) then data did not exist before so writes data to file
            If count2 > 0 Then
                'Writes just the Username to JustUserName text file
                Using Writer As New IO.StreamWriter("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\PacMan Menu\PacMan Menu\bin\Debug\JustUserName.txt", True)
                    Writer.WriteLine(JustUserNameVal)
                End Using

                JustUserName = IO.File.ReadAllLines("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\PacMan Menu\PacMan Menu\bin\Debug\Username.txt") 'Stores all the Usernames into JustUserName Array
            End If
        End If


        UserInput = InputBox("What is Your Username?") 'Asks the User for their username
        Username = IO.File.ReadAllLines("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\PacMan Menu\PacMan Menu\bin\Debug\Username.txt") 'Reads alls the scores and usernames to username array
        GetValue() 'Calls Sub Routine by the same name here
        MessageBox.Show("Your Score is " & ScoreOfUser) 'MessageBox appears which tells the user their score
        butMergeSort.Visible = True 'Makes the Merge Sort Button Visible to the User
    End Sub

    Private Sub butMergeSort_Click(sender As Object, e As EventArgs) Handles butMergeSort.Click

        MergeSort(JustScore) 'Calls the Merge Sort Algorithm passing the Just Score Array in the parameters

        MessageBox.Show("Data is Sorted, You can Now use the Searching Operation") 'When data is sorted a Message box appears which tells the User that the data is sorted

        butSearch.Visible = True 'Makes the Search Button Visible allowing the user to search for their position

    End Sub

    Private Sub butSearch_Click(sender As Object, e As EventArgs) Handles butSearch.Click
        BinarySearch() 'Calls Binary Search Algorithm here
    End Sub

    Private Sub GettingJustScore()
        'Variables below are used to just get the score of the user from the username file
        Dim data = System.IO.File.ReadAllText("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\PacMan Menu\PacMan Menu\bin\Debug\Username.txt")
        Dim arrays = New List(Of Single())()
        Dim lines = data.Split({vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)
        Dim Number As Integer

        For Each line In lines
            Dim lineArray = New List(Of Single)()

            For Each s In line.Split({","c}, StringSplitOptions.RemoveEmptyEntries) 'Seperates the data at the comma
                Integer.TryParse(s, Number) 'Trys to convert s to integer if the data can be parsed it is added to linearray
                lineArray.Add(Convert.ToInt32(Number))
            Next

            arrays.Add(lineArray.ToArray()) 'Turns LineArray data to lineArray
            Dim i As Integer = 0, result As Integer = 0 'Declare two more integer variables called i and integer

            'Increments result
            While i < lineArray.Count
                result += Convert.ToInt32(lineArray(Math.Min(System.Threading.Interlocked.Increment(i), i - 1)))
            End While

            temporaryCheck = IO.File.ReadAllLines("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\PacMan Menu\PacMan Menu\bin\Debug\score.txt") 'Used to remove duplicate data, stores all scores
            If temporaryCheck.Length < 1 Then 'If the Score file is empty data is written to it

                Using Writer As New IO.StreamWriter("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\PacMan Menu\PacMan Menu\bin\Debug\score.txt", True)
                    Writer.WriteLine(result)
                End Using

            Else 'If the file isn't empty then the following code is ran

                If temporaryCheck.Contains(result) Then 'If the array already holds that value then nothing happens
                    'Do Nothing
                Else 'If the value isn't already in the array then the following code is ran

                    'Writes the data to Score
                    Using Writer As New IO.StreamWriter("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\PacMan Menu\PacMan Menu\bin\Debug\score.txt", True)
                        Writer.WriteLine(result)
                    End Using
                    GlobalNum = result 'Gives GlobalNum the same value as result
                End If
            End If
        Next
        UpdateData() 'Calls Sub Routine by the same name here
    End Sub

    Private Sub UpdateData()
        Dim ScoreArray() As String = IO.File.ReadAllLines("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\PacMan Menu\PacMan Menu\bin\Debug\score.txt") 'Reads and Stores all the Values from Score

        'Loops through ScoreArray
        For i = 0 To ScoreArray.Length - 1
            If JustScore.Contains(ScoreArray(i)) Then 'If JustScore already contains the value then nothing happens
                'Do Nothing
            Else 'If JustScore doesn't already contain the data then the following code is ran

                ScoreArray(i) = CInt(ScoreArray(i)) 'Converts the value at i to integer

                JustScore(NumOfValues) = ScoreArray(i) 'Gives JustScore the same value

                NumOfValues += 1 'Increments i by 1
                ReDim Preserve JustScore(NumOfValues) 'Increases the Size of JustScore by ReDim and keeps the old values through Preserve
            End If
        Next

    End Sub

    Private Function GetValue()
        'Goes through the Username Array and looks for Data that starts with the username the user stated
        For Each Data As String In Username
            If Data.StartsWith(UserInput & ",") Then
                ScoreOfUser = Integer.Parse(Data.Split(","c)(1)) 'Seperates the score from the username and stores it in ScoreOfUser
            End If
        Next

        Return ScoreOfUser 'Outputs ScoreOfUser
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
        'Binary Search Algorithm can be seen Below

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
            Result = JustScore.Length - Result 'Inverses the Positon so greatest value is at the top of the array instead of being the last value

            MessageBox.Show("Your Value is at the " & Result & " Place in the List")
        End If

    End Sub

End Class