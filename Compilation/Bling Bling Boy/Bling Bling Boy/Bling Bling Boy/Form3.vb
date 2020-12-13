Public Class frmScoreMenu
    Public CurrentUserScore As Integer 'Used to transfer the current users score between game form to score form

    'Variable Below Stores the Usernames with the Scores of the Players
    Dim UsernameArray() As String = IO.File.ReadAllLines("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Bling Bling Boy\Bling Bling Boy\Bling Bling Boy\bin\Debug\Username.txt")
    'Used as a Counter for the Array
    Dim NumOfValues As Integer = 0
    'Just Stores the Scores
    Dim JustScore(NumOfValues) As Integer
    'Just Stores the Usernames
    Dim JustUserName() As String = IO.File.ReadAllLines("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Bling Bling Boy\Bling Bling Boy\Bling Bling Boy\bin\Debug\JustUserName.txt")

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'As soon as Form Loads the Scores are read in to a new variable
        Dim ScoreArray() As String = IO.File.ReadAllLines("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Bling Bling Boy\Bling Bling Boy\Bling Bling Boy\bin\Debug\score.txt")

        lblScore.Text = CurrentUserScore 'Gets the Score from the game form and displays it to the user

        UpdateData() 'Calls Sub Routine by the same name here

    End Sub

    Private Sub butSubmit_Click(sender As Object, e As EventArgs) Handles butSubmit.Click

        'Write to Username file
        Using Writer As New IO.StreamWriter("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Bling Bling Boy\Bling Bling Boy\Bling Bling Boy\bin\Debug\Username.txt", True)
            Writer.WriteLine(txtUsername.Text & ", " & lblScore.Text)
        End Using

        'Write to the Score file
        Using Writer As New IO.StreamWriter("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Bling Bling Boy\Bling Bling Boy\Bling Bling Boy\bin\Debug\score.txt", True)
            Writer.WriteLine(lblScore.Text)
        End Using

        'Varaibles below are used to check and makes sure data isn't repeated
        Dim CheckExists() As String = IO.File.ReadAllLines("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Bling Bling Boy\Bling Bling Boy\Bling Bling Boy\bin\Debug\JustUserName.txt") 'Reads username
        Dim count As Integer = 0

        If CheckExists.Length < 1 Then 'If the File has no values the following code is ran

            'The File has the data written to as there is no data to compare against
            Using Writer As New IO.StreamWriter("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Bling Bling Boy\Bling Bling Boy\Bling Bling Boy\bin\Debug\JustUserName.txt", True)
                Writer.WriteLine(txtUsername.Text)
            End Using

        Else 'If there is data in the file then the following code is ran

            'Checks if the Score already exists in the database 
            For i = 0 To CheckExists.Length - 1

                If CheckExists(i) = txtUsername.Text Then
                    count = 0
                ElseIf CheckExists(i) <> txtUsername.Text Then
                    count += 1
                End If

            Next

            'If the value of count is greater then the value used to check if the data is there or not then the data is written to the file
            If count > 0 Then
                'Write to File
                Using Writer As New IO.StreamWriter("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Bling Bling Boy\Bling Bling Boy\Bling Bling Boy\bin\Debug\JustUserName.txt", True)
                    Writer.WriteLine(txtUsername.Text)
                End Using

                JustUserName = IO.File.ReadAllLines("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Bling Bling Boy\Bling Bling Boy\Bling Bling Boy\bin\Debug\Username.txt")
            End If
        End If

        'Increases the size of JustScore by NumOfValues
        ReDim JustScore(NumOfValues)
        UpdateData() 'Calls Sub Routine by the same name here

        'Message Box tells user their data is saved and makes the submit button false so it cannot be spammed and potentially crash the program
        MessageBox.Show("Saved")
        butSubmit.Visible = False
    End Sub

    Private Sub butMergeSort_Click(sender As Object, e As EventArgs) Handles butMergeSort.Click
        MergeSort(JustScore) 'Calls the Merge Sort Routine and used it on the array called JustScore

        MessageBox.Show("Data is Sorted, You can Now use the Searching Operation") 'Message Box appears when data is sorted

        butSearch.Visible = True 'Makes Search Button visible

    End Sub

    Private Sub butSearch_Click(sender As Object, e As EventArgs) Handles butSearch.Click
        BinarySearch() 'Calls the Binary Search Routine here
    End Sub

    Private Sub UpdateData()
        'Data is read to Score Array
        Dim ScoreArray() As String = IO.File.ReadAllLines("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Bling Bling Boy\Bling Bling Boy\Bling Bling Boy\bin\Debug\score.txt")

        For i = 0 To ScoreArray.Length - 1 'For the number of data there is

            ScoreArray(i) = CInt(ScoreArray(i)) 'Data is converted to integer

            JustScore(NumOfValues) = ScoreArray(i) 'Stores Data in JustScore

            NumOfValues += 1 'Increases the value of NumOfValues by 1
            ReDim Preserve JustScore(NumOfValues) 'Redeclares JustScore and inreases its size as NumOfValues has increased, also preserves data that is already in array
        Next

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
        'Binary Search Algorithm can be seen below

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
            Result = JustScore.Length - Result 'Changes Position of the Data from the order in array to output the correct position on the leaderboard
            MessageBox.Show("Your Value is at the " & Result & " Place in the List")
        End If

    End Sub

End Class