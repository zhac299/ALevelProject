Public Class Form2

#Region "Variables"
    'Variabe is Used to transfer the Player Score from the game Form to this Form
    Public Score2 As Integer

    'The Array Below Stores the Usernames and the scores of all players
    Dim UsernameArray() As String = IO.File.ReadAllLines("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Flappy Bird -DataBase\Flappy Bird - Core DONE\Flappy Bird\Flappy Bird\bin\Debug\Username.txt")
    'Counter used to count and increase the size of the array
    Dim NumOfValues As Integer = 0
    'Variable below is used to store just the scores of the User
    Dim JustScore(NumOfValues) As Integer
    'Variable Below Just stores the Usernames of all the players
    Dim JustUserName() As String = IO.File.ReadAllLines("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Flappy Bird -DataBase\Flappy Bird - Core DONE\Flappy Bird\Flappy Bird\bin\Debug\JustUserName.txt")
#End Region

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblScore.Text = Score2 'Displays the current Player their score

        UpdateData() 'Calls Sub Routine by the same name here

    End Sub

    Private Sub butSubmit_Click(sender As Object, e As EventArgs) Handles butSubmit.Click

        'Write to Username File using StreamWriter
        Using Writer As New IO.StreamWriter("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Flappy Bird -DataBase\Flappy Bird - Core DONE\Flappy Bird\Flappy Bird\bin\Debug\Username.txt", True)
            Writer.WriteLine(txtUsername.Text & ", " & lblScore.Text)
        End Using

        'Write to Score File using StreamWriter
        Using Writer As New IO.StreamWriter("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Flappy Bird -DataBase\Flappy Bird - Core DONE\Flappy Bird\Flappy Bird\bin\Debug\Score.txt", True)
            Writer.WriteLine(lblScore.Text)
        End Using

        'Variables below make sure that duplicate values aren't added to the JustUserName file
        Dim CheckExists() As String = IO.File.ReadAllLines("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Flappy Bird -DataBase\Flappy Bird - Core DONE\Flappy Bird\Flappy Bird\bin\Debug\JustUserName.txt")
        Dim count As Integer = 0

        If CheckExists.Length < 1 Then 'If the File is empty data is written to it

            Using Writer As New IO.StreamWriter("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Flappy Bird -DataBase\Flappy Bird - Core DONE\Flappy Bird\Flappy Bird\bin\Debug\JustUserName.txt", True)
                Writer.WriteLine(txtUsername.Text)
            End Using

        Else 'If existing data is present then the following code is ran

            'Checks if the Score already exists in the database 
            For i = 0 To CheckExists.Length - 1

                If CheckExists(i) = txtUsername.Text Then 'If the data already exists count is set to 0
                    count = 0
                ElseIf CheckExists(i) <> txtUsername.Text Then 'If the data doesn't exist count increases by 1
                    count += 1
                End If

            Next

            'If Count is above base value (0) so the data being added is new then the data is written to the file
            If count > 0 Then
                'Write to File
                Using Writer As New IO.StreamWriter("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Flappy Bird -DataBase\Flappy Bird - Core DONE\Flappy Bird\Flappy Bird\bin\Debug\JustUserName.txt", True)
                    Writer.WriteLine(txtUsername.Text)
                End Using
                'Reads all the values from JustUserName.txt to JustUserName
                JustUserName = IO.File.ReadAllLines("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Flappy Bird -DataBase\Flappy Bird - Core DONE\Flappy Bird\Flappy Bird\bin\Debug\Username.txt")
            End If
        End If

        'Redeclares JustScore
        ReDim JustScore(NumOfValues)
        UpdateData() 'Calles Sub Routine by the same name here

        MessageBox.Show("Saved") 'When all the data is saved then a messagebox appears which tells the user their data is saved
        butSubmit.Visible = False 'Submit button becomes false so the user cannot spam the subit button
    End Sub

    Private Sub butSearch_Click(sender As Object, e As EventArgs) Handles butSearch.Click
        BinarySearch() 'Calls the Binary Search Routine when the search button is pressed
    End Sub

    Private Sub UpdateData()
        'Data from score file is read to Score Array
        Dim ScoreArray() As String = IO.File.ReadAllLines("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Flappy Bird -DataBase\Flappy Bird - Core DONE\Flappy Bird\Flappy Bird\bin\Debug\Score.txt")

        'The FOR loop below converts all data from score array to integer and stores it in JustScore
        For i = 0 To ScoreArray.Length - 1

            ScoreArray(i) = CInt(ScoreArray(i))

            JustScore(NumOfValues) = ScoreArray(i)

            NumOfValues += 1 'NumOfValues is incremented by 1
            ReDim Preserve JustScore(NumOfValues) 'JustScore is Redimmed to Increase its size and as Preserve is also used data in the array is also kept
        Next

    End Sub

    Private Sub butMergeSort_Click(sender As Object, e As EventArgs) Handles butMergeSort.Click

        MergeSort(JustScore) 'Calls the MergeSort Algorithm here with the values of the JustScore array

        MessageBox.Show("Data is Sorted, You can Now use the Searching Operation") 'MessageBox appears when data is sorted telling the user their data is sorted

        butSearch.Visible = True 'Button used to use Binary Search is made visible, it's originally hidden as binary search cannot be ran when the data isn't sorted

    End Sub


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
        'The Binary Search Algorithm can be seen below
        Dim Result As Integer = -1
        Dim Low As Integer = 0
        Dim High As Integer = JustScore.Length - 1
        Dim Middle As Integer
        Dim UserInput As Integer

        UserInput = InputBox("What is Your Score")

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
            Result = JustScore.Length - Result 'Makes it so that when the position is given the position is inversed as originally when data is sorted largest value would be last value so the position given would be a greater number then it should be for a high score so for instance it would be 10 instead of 1

            MessageBox.Show("Your Value is at the " & Result & " Place in the List")
        End If

    End Sub

End Class