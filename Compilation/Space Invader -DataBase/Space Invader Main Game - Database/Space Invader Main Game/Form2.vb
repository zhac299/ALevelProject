Public Class Form2

#Region "Variables"
    Public Score2 As Integer 'Gets the Score of the User from the game form and tranfers it to this form
    'Variables below Read Files and Store the Username with the Score and Just the Username in arrays respectivly
    Dim UsernameArray() As String = IO.File.ReadAllLines("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Space Invader -DataBase\Space Invader Main Game - Database\Space Invader Main Game\bin\Debug\Username.txt")
    Dim JustUserName() As String = IO.File.ReadAllLines("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Space Invader -DataBase\Space Invader Main Game - Database\Space Invader Main Game\bin\Debug\JustUserName.txt")

    Dim NumOfValues As Integer = 0 'Used to increase the size of the JustScore Array
    Dim JustScore(NumOfValues) As Integer
#End Region

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblScore.Text = Score2 'Writes the current Users score to the label

        UpdateData() 'Calls Sub Routine by the same name here

    End Sub

    Private Sub butSubmit_Click(sender As Object, e As EventArgs) Handles butSubmit.Click

        'Writes Username and score to the username text file
        Using Writer As New IO.StreamWriter("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Space Invader -DataBase\Space Invader Main Game - Database\Space Invader Main Game\bin\Debug\Username.txt", True)
            Writer.WriteLine(txtUsername.Text & ", " & lblScore.Text)
        End Using

        'Writes Users Score to Score Text File
        Using Writer As New IO.StreamWriter("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Space Invader -DataBase\Space Invader Main Game - Database\Space Invader Main Game\bin\Debug\Score.txt", True)
            Writer.WriteLine(lblScore.Text)
        End Using

        'Variables below are used to spot duplicated data and prevent it from being saved to the text file
        Dim CheckExists() As String = IO.File.ReadAllLines("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Space Invader -DataBase\Space Invader Main Game - Database\Space Invader Main Game\bin\Debug\JustUserName.txt") 'Reads username
        Dim count As Integer = 0

        If CheckExists.Length < 1 Then 'If the File is empty then Data is written to it

            'Writes the Users Username to JustUsername text file
            Using Writer As New IO.StreamWriter("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Space Invader -DataBase\Space Invader Main Game - Database\Space Invader Main Game\bin\Debug\JustUserName.txt", True)
                Writer.WriteLine(txtUsername.Text)
            End Using

        Else 'If the Text File isn't empty then the following code is ran

            'Checks if the Score already exists in the database 
            For i = 0 To CheckExists.Length - 1

                If CheckExists(i) = txtUsername.Text Then 'If the score already exists count is set to 0
                    count = 0
                ElseIf CheckExists(i) <> txtUsername.Text Then 'If Score doesn't already exist then count is incremented by 1
                    count += 1
                End If

            Next

            If count > 0 Then 'If count is greater then its base value then data is written to file
                'Write Just the Username to JustUsername File
                Using Writer As New IO.StreamWriter("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Space Invader -DataBase\Space Invader Main Game - Database\Space Invader Main Game\bin\Debug\JustUserName.txt", True)
                    Writer.WriteLine(txtUsername.Text)
                End Using
                'Reads Just Usernames to JustUserName Array
                JustUserName = IO.File.ReadAllLines("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Space Invader -DataBase\Space Invader Main Game - Database\Space Invader Main Game\bin\Debug\Username.txt")
            End If
        End If

        ReDim JustScore(NumOfValues) 'Redeclares the JustScore array
        UpdateData() 'Calls Sub Routine by the same name here

        MessageBox.Show("Saved") 'MessageBox Appears which tells the user that their data is saved
        butSubmit.Visible = False 'Makes the Submit Button Invisible
    End Sub

    Private Sub butSearch_Click(sender As Object, e As EventArgs) Handles butSearch.Click
        BinarySearch() 'Calls the BinarySearch Algorithm here
    End Sub

    Private Sub UpdateData()
        'Reads the Score text file to array
        Dim ScoreArray() As String = IO.File.ReadAllLines("E:\College Subjects\Computer Science\Computer Science NEA\FINAL\Space Invader -DataBase\Space Invader Main Game - Database\Space Invader Main Game\bin\Debug\Score.txt")

        'Code belwo converts all of the Value in ScoreArray to Integer and into the JustScore Array
        For i = 0 To ScoreArray.Length - 1

            ScoreArray(i) = CInt(ScoreArray(i))

            JustScore(NumOfValues) = ScoreArray(i)

            NumOfValues += 1 'Value of NumOfValues is incremented
            ReDim Preserve JustScore(NumOfValues) 'JustScore is Redeclared and has its size increased due to NumOfValues and as Preserve is used all previous data is also kept intact
        Next

    End Sub

    Private Sub butMergeSort_Click(sender As Object, e As EventArgs) Handles butMergeSort.Click

        MergeSort(JustScore) 'Calls the Merge Sort Algorithm here and passes the JustScore Array through in the parameters

        MessageBox.Show("Data is Sorted, You can Now use the Searching Operation") 'When the data is sorted, a message box appears which informs the user that the data is sorted

        butSearch.Visible = True 'Makes search button visible, so the user can now use binary search to search for their score

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
        'Binary Search Algorithm can be Seen Below

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
            Result = JustScore.Length - Result 'Inverses the Positon so greatest value is at the top of the array instead of being the last value

            MessageBox.Show("Your Value is at the " & Result & " Place in the List")
        End If

    End Sub

End Class