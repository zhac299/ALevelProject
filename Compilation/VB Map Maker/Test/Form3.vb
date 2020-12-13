Public Class Form3

    'View Port
    Dim ResWidth As Integer = 1099 'This Value Decides Where the Red Selector Can Go on the X-Axis
    Dim ResHeight As Integer = 769.5 'This Value Decides Where the Red Selector Can Go on the Y-Axis
    Dim TileSize As Integer = 32

    ' Graphics Variable
    Dim G As Graphics
    Dim BBG As Graphics 'BBG = Back Buffer Graphics
    Dim BB As Bitmap 'BB = Back Buffer
    Dim BMPTile As Bitmap
    Dim sRect As Rectangle 'sRect = Source Rectangle
    Dim dRect As Rectangle 'dRect = Distance Rectangle

    'Map Variable
    Dim Map(100, 100, 10) As Integer
    Dim MapX As Integer = 20
    Dim MapY As Integer = 20

    'Game Running
    Dim IsRunning As Boolean = True

    'Mouse Location
    Dim MouseX As Integer
    Dim MouseY As Integer
    Dim mMapX As Integer
    Dim mMapY As Integer


    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadMap("Map1")
    End Sub










    Private Sub LoadMap(ByVal MapFile As String)

        Try
            Dim sr As New IO.StreamReader(MapFile & ".map")
            Dim strLine As String = ""
            Dim X As Integer = 0
            Dim Y As Integer = 0

            Do Until sr.EndOfStream
                strLine = sr.ReadLine
                strLine = strLine.Replace(strLine.LastIndexOf(","), "")

                For Each item As String In Split(strLine, ",", -1)
                    If item = "" Then
                        item = 0
                    End If

                    If X <= 100 Then
                        Map(X, Y, 0) = Int(item)
                    End If

                    X = X + 1
                Next
                X = 0
                Y = Y + 1
            Loop
            sr.Close()
            sr.Dispose()
        Catch ex As Exception
            MsgBox("Map '" & MapFile & "' Could not be Loaded." & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical, "ERROR")
            IsRunning = False
        End Try

    End Sub


End Class