Option Strict Off
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class Form1
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

    'PaintBrush
    Dim PaintBrush As Integer = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Show()
        Me.Focus()

        'Initialise Graphics Objects
        G = Me.CreateGraphics
        BB = New Bitmap(ResWidth, ResHeight)
        BMPTile = New Bitmap(GFX.pbGFX.Image)


        StartGameLoop()

    End Sub

    Private Sub StartGameLoop()
        Do While IsRunning = True
            'Keep App Responsive
            Application.DoEvents()

            '1) Check User Input
            '2) Run AI
            '3) Update Object Data (Object Positions, Status, Collision Detection, etc)
            '4) Check Triggers and Condition (Death of Pacman Animation, Ghosts Being Eaten, etc)
            '5) Draw Graphics
            DrawGraphics()
            '6) Playing Sound Effects and Music (Not as Important as Everything Else)



        Loop
    End Sub


    Private Sub DrawGraphics()
        'Fill Back Buffer
        'Draw Tile, String, Characters ETC
        For X = 0 To 21 '(22 Tiles Across Screen)
            For Y = 0 To 25 '(26 Tiles Down)
                GetSourceRectangle(MapX + X, MapY + Y, TileSize, TileSize)

                dRect = New Rectangle(X * TileSize, Y * TileSize, TileSize, TileSize)
                G.DrawImage(BMPTile, dRect, sRect, GraphicsUnit.Pixel)
            Next
        Next

        'Characters, Menus ETC
        'G.FillRectangle(Brushes.Red, 22 * TileSize, 2 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(0, 0, TileSize, TileSize)
        G.DrawImage(BMPTile, 22 * TileSize, 2 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Blue, 22 * TileSize, 4 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(32, 0, TileSize, TileSize)
        G.DrawImage(BMPTile, 22 * TileSize, 4 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Black, 22 * TileSize, 6 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(64, 0, TileSize, TileSize)
        G.DrawImage(BMPTile, 22 * TileSize, 6 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Orange, 22 * TileSize, 8 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(96, 0, TileSize, TileSize)
        G.DrawImage(BMPTile, 22 * TileSize, 8 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Pink, 22 * TileSize, 10 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(128, 0, TileSize, TileSize)
        G.DrawImage(BMPTile, 22 * TileSize, 10 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.SandyBrown, 22 * TileSize, 12 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(0, 32, TileSize, TileSize)
        G.DrawImage(BMPTile, 22 * TileSize, 12 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.DarkGreen, 22 * TileSize, 14 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(32, 32, TileSize, TileSize)
        G.DrawImage(BMPTile, 22 * TileSize, 14 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Indigo, 22 * TileSize, 0 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(64, 32, TileSize, TileSize)
        G.DrawImage(BMPTile, 22 * TileSize, 0 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Navy, 23 * TileSize, 1 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(96, 32, TileSize, TileSize)
        G.DrawImage(BMPTile, 23 * TileSize, 1 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Chocolate, 23 * TileSize, 3 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(128, 32, TileSize, TileSize)
        G.DrawImage(BMPTile, 23 * TileSize, 3 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.DarkSalmon, 23 * TileSize, 5 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(160, 32, TileSize, TileSize)
        G.DrawImage(BMPTile, 23 * TileSize, 5 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Gray, 23 * TileSize, 7 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(0, 64, TileSize, TileSize)
        G.DrawImage(BMPTile, 23 * TileSize, 7 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.OliveDrab, 23 * TileSize, 9 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(32, 64, TileSize, TileSize)
        G.DrawImage(BMPTile, 23 * TileSize, 9 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Plum, 23 * TileSize, 11 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(64, 64, TileSize, TileSize)
        G.DrawImage(BMPTile, 23 * TileSize, 11 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Turquoise, 24 * TileSize, 4 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(96, 64, TileSize, TileSize)
        G.DrawImage(BMPTile, 24 * TileSize, 4 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.DarkGray, 24 * TileSize, 6 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(128, 64, TileSize, TileSize)
        G.DrawImage(BMPTile, 24 * TileSize, 6 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Gold, 24 * TileSize, 8 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(96, 128, TileSize, TileSize)
        G.DrawImage(BMPTile, 24 * TileSize, 8 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.LemonChiffon, 24 * TileSize, 10 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(96, 96, TileSize, TileSize)
        G.DrawImage(BMPTile, 24 * TileSize, 10 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Purple, 24 * TileSize, 12 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(128, 96, TileSize, TileSize)
        G.DrawImage(BMPTile, 24 * TileSize, 12 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Tan, 24 * TileSize, 14 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(87, 0, TileSize, TileSize)
        G.DrawImage(BMPTile, 24 * TileSize, 14 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Yellow, 24 * TileSize, 2 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(128, 128, TileSize, TileSize)
        G.DrawImage(BMPTile, 24 * TileSize, 2 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 25 * TileSize, 1 * TileSize, TileSize, TileSize) 
        sRect = New Rectangle(0, 96, TileSize, TileSize)
        G.DrawImage(BMPTile, 25 * TileSize, 1 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 25 * TileSize, 3 * TileSize, TileSize, TileSize) 
        sRect = New Rectangle(0, 128, TileSize, TileSize)
        G.DrawImage(BMPTile, 25 * TileSize, 3 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 25 * TileSize, 5 * TileSize, TileSize, TileSize) 
        sRect = New Rectangle(32, 96, TileSize, TileSize)
        G.DrawImage(BMPTile, 25 * TileSize, 5 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 25 * TileSize, 7 * TileSize, TileSize, TileSize) 
        sRect = New Rectangle(32, 128, TileSize, TileSize)
        G.DrawImage(BMPTile, 25 * TileSize, 7 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 25 * TileSize, 9 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(64, 96, TileSize, TileSize)
        G.DrawImage(BMPTile, 25 * TileSize, 9 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 25 * TileSize, 11 * TileSize, TileSize, TileSize) 
        sRect = New Rectangle(64, 128, TileSize, TileSize)
        G.DrawImage(BMPTile, 25 * TileSize, 11 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 25 * TileSize, 13 * TileSize, TileSize, TileSize) 
        sRect = New Rectangle(256, 0, TileSize, TileSize)
        G.DrawImage(BMPTile, 25 * TileSize, 13 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 26 * TileSize, 2 * TileSize, TileSize, TileSize) 
        sRect = New Rectangle(224, 0, TileSize, TileSize)
        G.DrawImage(BMPTile, 26 * TileSize, 2 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 26 * TileSize, 4 * TileSize, TileSize, TileSize) 
        sRect = New Rectangle(190, 0, TileSize, TileSize)
        G.DrawImage(BMPTile, 26 * TileSize, 4 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 26 * TileSize, 6 * TileSize, TileSize, TileSize) 
        sRect = New Rectangle(192, 160, TileSize, TileSize)
        G.DrawImage(BMPTile, 26 * TileSize, 6 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 26 * TileSize, 8 * TileSize, TileSize, TileSize) 
        sRect = New Rectangle(160, 160, TileSize, TileSize)
        G.DrawImage(BMPTile, 26 * TileSize, 8 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 26 * TileSize, 10 * TileSize, TileSize, TileSize) 
        sRect = New Rectangle(128, 160, TileSize, TileSize)
        G.DrawImage(BMPTile, 26 * TileSize, 10 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 24 * TileSize, 0 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(96, 160, TileSize, TileSize)
        G.DrawImage(BMPTile, 24 * TileSize, 0 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 26 * TileSize, 12 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(64, 160, TileSize, TileSize)
        G.DrawImage(BMPTile, 26 * TileSize, 12 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 26 * TileSize, 0 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(32, 160, TileSize, TileSize)
        G.DrawImage(BMPTile, 26 * TileSize, 0 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 26 * TileSize, 14 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(0, 160, TileSize, TileSize)
        G.DrawImage(BMPTile, 26 * TileSize, 14 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 27 * TileSize, 1 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(288, 0, TileSize, TileSize)
        G.DrawImage(BMPTile, 27 * TileSize, 1 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 27 * TileSize, 3 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(288, 32, TileSize, TileSize)
        G.DrawImage(BMPTile, 27 * TileSize, 3 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 27 * TileSize, 5 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(320, 0, TileSize, TileSize)
        G.DrawImage(BMPTile, 27 * TileSize, 5 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 27 * TileSize, 7 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(320, 32, TileSize, TileSize)
        G.DrawImage(BMPTile, 27 * TileSize, 7 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 27 * TileSize, 9 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(320, 64, TileSize, TileSize)
        G.DrawImage(BMPTile, 27 * TileSize, 9 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 27 * TileSize, 11 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(320, 96, TileSize, TileSize)
        G.DrawImage(BMPTile, 27 * TileSize, 11 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 27 * TileSize, 13 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(288, 64, TileSize, TileSize)
        G.DrawImage(BMPTile, 27 * TileSize, 13 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 27 * TileSize, 15 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(288, 96, TileSize, TileSize)
        G.DrawImage(BMPTile, 27 * TileSize, 15 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 28 * TileSize, 0 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(320, 128, TileSize, TileSize)
        G.DrawImage(BMPTile, 28 * TileSize, 0 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 28 * TileSize, 2 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(288, 128, TileSize, TileSize)
        G.DrawImage(BMPTile, 28 * TileSize, 2 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 28 * TileSize, 4 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(320, 160, TileSize, TileSize)
        G.DrawImage(BMPTile, 28 * TileSize, 4 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 28 * TileSize, 6 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(288, 160, TileSize, TileSize)
        G.DrawImage(BMPTile, 28 * TileSize, 6 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 28 * TileSize, 8 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(288, 192, TileSize, TileSize)
        G.DrawImage(BMPTile, 28 * TileSize, 8 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 28 * TileSize, 10 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(320, 192, TileSize, TileSize)
        G.DrawImage(BMPTile, 28 * TileSize, 10 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 28 * TileSize, 12 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(256, 192, TileSize, TileSize)
        G.DrawImage(BMPTile, 28 * TileSize, 12 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 28 * TileSize, 14 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(224, 192, TileSize, TileSize)
        G.DrawImage(BMPTile, 28 * TileSize, 14 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 29 * TileSize, 1 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(224, 224, TileSize, TileSize)
        G.DrawImage(BMPTile, 29 * TileSize, 1 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 29 * TileSize, 3 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(224, 256, TileSize, TileSize)
        G.DrawImage(BMPTile, 29 * TileSize, 3 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 29 * TileSize, 5 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(256, 256, TileSize, TileSize)
        G.DrawImage(BMPTile, 29 * TileSize, 5 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 29 * TileSize, 7 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(320, 256, TileSize, TileSize)
        G.DrawImage(BMPTile, 29 * TileSize, 7 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 29 * TileSize, 9 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(352, 0, TileSize, TileSize)
        G.DrawImage(BMPTile, 29 * TileSize, 9 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 29 * TileSize, 11 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(384, 0, TileSize, TileSize)
        G.DrawImage(BMPTile, 29 * TileSize, 11 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 29 * TileSize, 13 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(416, 0, TileSize, TileSize)
        G.DrawImage(BMPTile, 29 * TileSize, 13 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 29 * TileSize, 15 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(448, 0, TileSize, TileSize)
        G.DrawImage(BMPTile, 29 * TileSize, 15 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 30 * TileSize, 0 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(384, 32, TileSize, TileSize)
        G.DrawImage(BMPTile, 30 * TileSize, 0 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 30 * TileSize, 2 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(384, 64, TileSize, TileSize)
        G.DrawImage(BMPTile, 30 * TileSize, 2 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 30 * TileSize, 4 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(416, 32, TileSize, TileSize)
        G.DrawImage(BMPTile, 30 * TileSize, 4 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 30 * TileSize, 6 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(416, 64, TileSize, TileSize)
        G.DrawImage(BMPTile, 30 * TileSize, 6 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 30 * TileSize, 8 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(352, 160, TileSize, TileSize)
        G.DrawImage(BMPTile, 30 * TileSize, 8 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 30 * TileSize, 10 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(384, 160, TileSize, TileSize)
        G.DrawImage(BMPTile, 30 * TileSize, 10 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 30 * TileSize, 12 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(416, 160, TileSize, TileSize)
        G.DrawImage(BMPTile, 30 * TileSize, 12 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 30 * TileSize, 14 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(448, 160, TileSize, TileSize)
        G.DrawImage(BMPTile, 30 * TileSize, 14 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 30 * TileSize, 16 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(474, 160, TileSize, TileSize)
        G.DrawImage(BMPTile, 30 * TileSize, 16 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 31 * TileSize, 1 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(384, 96, TileSize, TileSize)
        G.DrawImage(BMPTile, 31 * TileSize, 1 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 31 * TileSize, 3 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(416, 96, TileSize, TileSize)
        G.DrawImage(BMPTile, 31 * TileSize, 3 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 31 * TileSize, 5 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(480, 0, TileSize, TileSize)
        G.DrawImage(BMPTile, 31 * TileSize, 5 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 31 * TileSize, 7 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(512, 0, TileSize, TileSize)
        G.DrawImage(BMPTile, 31 * TileSize, 7 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 31 * TileSize, 9 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(480, 32, TileSize, TileSize)
        G.DrawImage(BMPTile, 31 * TileSize, 9 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 31 * TileSize, 11 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(448, 32, TileSize, TileSize)
        G.DrawImage(BMPTile, 31 * TileSize, 11 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 31 * TileSize, 13 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(448, 64, TileSize, TileSize)
        G.DrawImage(BMPTile, 31 * TileSize, 13 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 31 * TileSize, 15 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(480, 64, TileSize, TileSize)
        G.DrawImage(BMPTile, 31 * TileSize, 15 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 32 * TileSize, 0 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(512, 64, TileSize, TileSize)
        G.DrawImage(BMPTile, 32 * TileSize, 0 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 32 * TileSize, 2 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(448, 96, TileSize, TileSize)
        G.DrawImage(BMPTile, 32 * TileSize, 2 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 32 * TileSize, 4 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(480, 96, TileSize, TileSize)
        G.DrawImage(BMPTile, 32 * TileSize, 4 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 32 * TileSize, 6 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(512, 96, TileSize, TileSize)
        G.DrawImage(BMPTile, 32 * TileSize, 6 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 32 * TileSize, 8 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(448, 128, TileSize, TileSize)
        G.DrawImage(BMPTile, 32 * TileSize, 8 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 32 * TileSize, 10 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(608, 64, TileSize, TileSize)
        G.DrawImage(BMPTile, 32 * TileSize, 10 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 32 * TileSize, 12 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(544, 64, TileSize, TileSize)
        G.DrawImage(BMPTile, 32 * TileSize, 12 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 32 * TileSize, 14 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(544, 96, TileSize, TileSize)
        G.DrawImage(BMPTile, 32 * TileSize, 14 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 32 * TileSize, 16 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(608, 96, TileSize, TileSize)
        G.DrawImage(BMPTile, 32 * TileSize, 16 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 33 * TileSize, 1 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(544, 128, TileSize, TileSize)
        G.DrawImage(BMPTile, 33 * TileSize, 1 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 33 * TileSize, 3 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(576, 128, TileSize, TileSize)
        G.DrawImage(BMPTile, 33 * TileSize, 3 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 33 * TileSize, 5 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(576, 160, TileSize, TileSize)
        G.DrawImage(BMPTile, 33 * TileSize, 5 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 33 * TileSize, 7 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(352, 192, TileSize, TileSize)
        G.DrawImage(BMPTile, 33 * TileSize, 7 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 33 * TileSize, 9 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(352, 224, TileSize, TileSize)
        G.DrawImage(BMPTile, 33 * TileSize, 9 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 33 * TileSize, 11 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(352, 256, TileSize, TileSize)
        G.DrawImage(BMPTile, 33 * TileSize, 11 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 33 * TileSize, 13 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(384, 192, TileSize, TileSize)
        G.DrawImage(BMPTile, 33 * TileSize, 13 * TileSize, sRect, GraphicsUnit.Pixel)
        'G.FillRectangle(Brushes.Colour, 33 * TileSize, 15 * TileSize, TileSize, TileSize)
        sRect = New Rectangle(384, 224, TileSize, TileSize)
        G.DrawImage(BMPTile, 33 * TileSize, 15 * TileSize, sRect, GraphicsUnit.Pixel)



        'G.FillRectangle(Brushes.Colour, 22 * TileSize, 13 * TileSize, TileSize, TileSize)



        G.DrawRectangle(Pens.Red, MouseX * TileSize, MouseY * TileSize, TileSize, TileSize)


        'Copy BackBuffer to Graphics Object
        G = Graphics.FromImage(BB)
        'Draw BackBuffer to Screen
        BBG = Me.CreateGraphics
        BBG.DrawImage(BB, 0, 0, ResWidth, ResHeight)
    End Sub

    Private Sub Form1_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        If MouseX = 22 And MouseY = 2 Then
            PaintBrush = 1
        ElseIf MouseX = 22 And MouseY = 4 Then
            PaintBrush = 2
        ElseIf MouseX = 22 And MouseY = 6 Then
            PaintBrush = 3
        ElseIf MouseX = 22 And MouseY = 8 Then
            PaintBrush = 4
        ElseIf MouseX = 22 And MouseY = 10 Then
            PaintBrush = 5
        ElseIf MouseX = 22 And MouseY = 12 Then
            PaintBrush = 6
        ElseIf MouseX = 22 And MouseY = 14 Then
            PaintBrush = 7
        ElseIf MouseX = 22 And MouseY = 0 Then
            PaintBrush = 8
        ElseIf MouseX = 23 And MouseY = 1 Then
            PaintBrush = 9
        ElseIf MouseX = 23 And MouseY = 3 Then
            PaintBrush = 10
        ElseIf MouseX = 23 And MouseY = 5 Then
            PaintBrush = 11
        ElseIf MouseX = 23 And MouseY = 7 Then
            PaintBrush = 12
        ElseIf MouseX = 23 And MouseY = 9 Then
            PaintBrush = 13
        ElseIf MouseX = 23 And MouseY = 11 Then
            PaintBrush = 14
        ElseIf MouseX = 24 And MouseY = 4 Then
            PaintBrush = 15
        ElseIf MouseX = 24 And MouseY = 6 Then
            PaintBrush = 16
        ElseIf MouseX = 24 And MouseY = 8 Then
            PaintBrush = 17
        ElseIf MouseX = 24 And MouseY = 10 Then
            PaintBrush = 18
        ElseIf MouseX = 24 And MouseY = 12 Then
            PaintBrush = 19
        ElseIf MouseX = 24 And MouseY = 14 Then
            PaintBrush = 20
        ElseIf MouseX = 24 And MouseY = 2 Then
            PaintBrush = 21
        ElseIf MouseX = 25 And MouseY = 1 Then
            PaintBrush = 22
        ElseIf MouseX = 25 And MouseY = 3 Then
            PaintBrush = 23
        ElseIf MouseX = 25 And MouseY = 5 Then
            PaintBrush = 25
        ElseIf MouseX = 25 And MouseY = 7 Then
            PaintBrush = 25
        ElseIf MouseX = 25 And MouseY = 9 Then
            PaintBrush = 26
        ElseIf MouseX = 25 And MouseY = 11 Then
            PaintBrush = 27
        ElseIf MouseX = 25 And MouseY = 13 Then
            PaintBrush = 28
        ElseIf MouseX = 26 And MouseY = 2 Then
            PaintBrush = 29
        ElseIf MouseX = 26 And MouseY = 4 Then
            PaintBrush = 30
        ElseIf MouseX = 26 And MouseY = 6 Then
            PaintBrush = 31
        ElseIf MouseX = 26 And MouseY = 8 Then
            PaintBrush = 32
        ElseIf MouseX = 26 And MouseY = 10 Then
            PaintBrush = 33
        ElseIf MouseX = 24 And MouseY = 0 Then
            PaintBrush = 34
        ElseIf MouseX = 26 And MouseY = 12 Then
            PaintBrush = 35
        ElseIf MouseX = 26 And MouseY = 0 Then
            PaintBrush = 36
        ElseIf MouseX = 26 And MouseY = 14 Then
            PaintBrush = 37
        ElseIf MouseX = 27 And MouseY = 1 Then
            PaintBrush = 38
        ElseIf MouseX = 27 And MouseY = 3 Then
            PaintBrush = 39
        ElseIf MouseX = 27 And MouseY = 5 Then
            PaintBrush = 40
        ElseIf MouseX = 27 And MouseY = 7 Then
            PaintBrush = 41
        ElseIf MouseX = 27 And MouseY = 9 Then
            PaintBrush = 42
        ElseIf MouseX = 27 And MouseY = 11 Then
            PaintBrush = 43
        ElseIf MouseX = 27 And MouseY = 13 Then
            PaintBrush = 44
        ElseIf MouseX = 27 And MouseY = 15 Then
            PaintBrush = 45
        ElseIf MouseX = 28 And MouseY = 0 Then
            PaintBrush = 46
        ElseIf MouseX = 28 And MouseY = 2 Then
            PaintBrush = 47
        ElseIf MouseX = 28 And MouseY = 4 Then
            PaintBrush = 48
        ElseIf MouseX = 28 And MouseY = 6 Then
            PaintBrush = 49
        ElseIf MouseX = 28 And MouseY = 8 Then
            PaintBrush = 50
        ElseIf MouseX = 28 And MouseY = 10 Then
            PaintBrush = 51
        ElseIf MouseX = 28 And MouseY = 12 Then
            PaintBrush = 52
        ElseIf MouseX = 28 And MouseY = 14 Then
            PaintBrush = 53
        ElseIf MouseX = 29 And MouseY = 1 Then
            PaintBrush = 54
        ElseIf MouseX = 29 And MouseY = 3 Then
            PaintBrush = 56
        ElseIf MouseX = 29 And MouseY = 5 Then
            PaintBrush = 55
        ElseIf MouseX = 29 And MouseY = 7 Then
            PaintBrush = 57
        ElseIf MouseX = 29 And MouseY = 9 Then
            PaintBrush = 58
        ElseIf MouseX = 29 And MouseY = 11 Then
            PaintBrush = 59
        ElseIf MouseX = 29 And MouseY = 13 Then
            PaintBrush = 60
        ElseIf MouseX = 29 And MouseY = 15 Then
            PaintBrush = 61
        ElseIf MouseX = 30 And MouseY = 0 Then
            PaintBrush = 62
        ElseIf MouseX = 30 And MouseY = 2 Then
            PaintBrush = 63
        ElseIf MouseX = 30 And MouseY = 4 Then
            PaintBrush = 64
        ElseIf MouseX = 30 And MouseY = 6 Then
            PaintBrush = 65
        ElseIf MouseX = 30 And MouseY = 8 Then
            PaintBrush = 66
        ElseIf MouseX = 30 And MouseY = 10 Then
            PaintBrush = 67
        ElseIf MouseX = 30 And MouseY = 12 Then
            PaintBrush = 68
        ElseIf MouseX = 30 And MouseY = 14 Then
            PaintBrush = 69
        ElseIf MouseX = 30 And MouseY = 16 Then
            PaintBrush = 70
        ElseIf MouseX = 31 And MouseY = 1 Then
            PaintBrush = 71
        ElseIf MouseX = 31 And MouseY = 3 Then
            PaintBrush = 72
        ElseIf MouseX = 31 And MouseY = 5 Then
            PaintBrush = 73
        ElseIf MouseX = 31 And MouseY = 7 Then
            PaintBrush = 74
        ElseIf MouseX = 31 And MouseY = 9 Then
            PaintBrush = 75
        ElseIf MouseX = 31 And MouseY = 11 Then
            PaintBrush = 76
        ElseIf MouseX = 31 And MouseY = 13 Then
            PaintBrush = 77
        ElseIf MouseX = 31 And MouseY = 15 Then
            PaintBrush = 78
        ElseIf MouseX = 32 And MouseY = 0 Then
            PaintBrush = 79
        ElseIf MouseX = 32 And MouseY = 2 Then
            PaintBrush = 80
        ElseIf MouseX = 32 And MouseY = 4 Then
            PaintBrush = 81
        ElseIf MouseX = 32 And MouseY = 6 Then
            PaintBrush = 82
        ElseIf MouseX = 32 And MouseY = 8 Then
            PaintBrush = 83
        ElseIf MouseX = 32 And MouseY = 10 Then
            PaintBrush = 84
        ElseIf MouseX = 32 And MouseY = 12 Then
            PaintBrush = 85
        ElseIf MouseX = 32 And MouseY = 14 Then
            PaintBrush = 86
        ElseIf MouseX = 32 And MouseY = 16 Then
            PaintBrush = 87
        ElseIf MouseX = 33 And MouseY = 1 Then
            PaintBrush = 88
        ElseIf MouseX = 33 And MouseY = 3 Then
            PaintBrush = 89
        ElseIf MouseX = 33 And MouseY = 5 Then
            PaintBrush = 90
        ElseIf MouseX = 33 And MouseY = 7 Then
            PaintBrush = 91
        ElseIf MouseX = 33 And MouseY = 9 Then
            PaintBrush = 92
        ElseIf MouseX = 33 And MouseY = 11 Then
            PaintBrush = 93
        ElseIf MouseX = 33 And MouseY = 13 Then
            PaintBrush = 94
        ElseIf MouseX = 33 And MouseY = 15 Then
            PaintBrush = 95
        End If

        Select Case PaintBrush
            Case 0

            Case 1 'Red
                Map(mMapX, mMapY, 0) = 1
            Case 2 'Blue
                Map(mMapX, mMapY, 0) = 2
            Case 3 'Black
                Map(mMapX, mMapY, 0) = 3
            Case 4 'Orange
                Map(mMapX, mMapY, 0) = 4
            Case 5 'Pink
                Map(mMapX, mMapY, 0) = 5
            Case 6 'Sandy Brown
                Map(mMapX, mMapY, 0) = 6
            Case 7 'Dark Green
                Map(mMapX, mMapY, 0) = 7
            Case 8 'Indigo
                Map(mMapX, mMapY, 0) = 8
            Case 9 'Navy
                Map(mMapX, mMapY, 0) = 9
            Case 10 'Chocolate
                Map(mMapX, mMapY, 0) = 10
            Case 11 'Dark Salmon
                Map(mMapX, mMapY, 0) = 11
            Case 12 'Gray
                Map(mMapX, mMapY, 0) = 12
            Case 13 'OliveDrab
                Map(mMapX, mMapY, 0) = 13
            Case 14 'Silver
                Map(mMapX, mMapY, 0) = 14
            Case 15 'Turquoise
                Map(mMapX, mMapY, 0) = 15
            Case 16 'Dark Gray
                Map(mMapX, mMapY, 0) = 16
            Case 17 'Gold
                Map(mMapX, mMapY, 0) = 17
            Case 18 'Lemon Chiffon
                Map(mMapX, mMapY, 0) = 18
            Case 19 'Purple
                Map(mMapX, mMapY, 0) = 19
            Case 20 'Tan
                Map(mMapX, mMapY, 0) = 20
            Case 21 'Yellow
                Map(mMapX, mMapY, 0) = 21
            Case 22 'Colour
                Map(mMapX, mMapY, 0) = 22
            Case 23 'Colour
                Map(mMapX, mMapY, 0) = 23
            Case 24 'Colour
                Map(mMapX, mMapY, 0) = 24
            Case 25 'Colour
                Map(mMapX, mMapY, 0) = 25
            Case 26 ' Colour
                Map(mMapX, mMapY, 0) = 26
            Case 27 'Colour
                Map(mMapX, mMapY, 0) = 27
            Case 28 'Colour
                Map(mMapX, mMapY, 0) = 28
            Case 29 'Colour
                Map(mMapX, mMapY, 0) = 29
            Case 30 'Colour
                Map(mMapX, mMapY, 0) = 30
            Case 31 'Colour
                Map(mMapX, mMapY, 0) = 31
            Case 32 'Colour
                Map(mMapX, mMapY, 0) = 32
            Case 33 'Colour
                Map(mMapX, mMapY, 0) = 33
            Case 34 'Colour
                Map(mMapX, mMapY, 0) = 34
            Case 35 'Colour
                Map(mMapX, mMapY, 0) = 35
            Case 36 'Colour
                Map(mMapX, mMapY, 0) = 36
            Case 37 'Colour
                Map(mMapX, mMapY, 0) = 37
            Case 38 'Colour
                Map(mMapX, mMapY, 0) = 38
            Case 39 'Colour
                Map(mMapX, mMapY, 0) = 39
            Case 40 'Colour
                Map(mMapX, mMapY, 0) = 40
            Case 41 'Colour
                Map(mMapX, mMapY, 0) = 41
            Case 42 'Colour
                Map(mMapX, mMapY, 0) = 42
            Case 43 'Colour
                Map(mMapX, mMapY, 0) = 43
            Case 44 'Colour
                Map(mMapX, mMapY, 0) = 44
            Case 45 'Colour
                Map(mMapX, mMapY, 0) = 45
            Case 46 'Colour
                Map(mMapX, mMapY, 0) = 46
            Case 47 'Colour
                Map(mMapX, mMapY, 0) = 47
            Case 48 'Colour
                Map(mMapX, mMapY, 0) = 48
            Case 49 ' Colour
                Map(mMapX, mMapY, 0) = 49
            Case 50 ' Colour
                Map(mMapX, mMapY, 0) = 50
            Case 51 ' Colour
                Map(mMapX, mMapY, 0) = 51
            Case 52 ' Colour
                Map(mMapX, mMapY, 0) = 52
            Case 53 ' Colour
                Map(mMapX, mMapY, 0) = 53
            Case 54 'Colour
                Map(mMapX, mMapY, 0) = 54
            Case 55 'Colour
                Map(mMapX, mMapY, 0) = 55
            Case 56 'Colour
                Map(mMapX, mMapY, 0) = 56
            Case 57 'Colour
                Map(mMapX, mMapY, 0) = 57
            Case 58 'Colour
                Map(mMapX, mMapY, 0) = 58
            Case 59 'Colour
                Map(mMapX, mMapY, 0) = 59
            Case 60 'Colour
                Map(mMapX, mMapY, 0) = 60
            Case 61 'Colour
                Map(mMapX, mMapY, 0) = 61
            Case 62 'Colour
                Map(mMapX, mMapY, 0) = 62
            Case 63 'Colour
                Map(mMapX, mMapY, 0) = 63
            Case 64 'Colour
                Map(mMapX, mMapY, 0) = 64
            Case 65 'Colour
                Map(mMapX, mMapY, 0) = 65
            Case 66 'Colour
                Map(mMapX, mMapY, 0) = 66
            Case 67 'Colour
                Map(mMapX, mMapY, 0) = 67
            Case 68 'Colour
                Map(mMapX, mMapY, 0) = 68
            Case 69 'Colour
                Map(mMapX, mMapY, 0) = 69
            Case 70 'Colour
                Map(mMapX, mMapY, 0) = 70
            Case 71 'Colour
                Map(mMapX, mMapY, 0) = 71
            Case 72 'Colour
                Map(mMapX, mMapY, 0) = 72
            Case 73 'Colour
                Map(mMapX, mMapY, 0) = 73
            Case 74 'Colour
                Map(mMapX, mMapY, 0) = 74
            Case 75 'Colour
                Map(mMapX, mMapY, 0) = 75
            Case 76 'Colour
                Map(mMapX, mMapY, 0) = 76
            Case 77 'Colour
                Map(mMapX, mMapY, 0) = 77
            Case 78 'Colour
                Map(mMapX, mMapY, 0) = 78
            Case 79 'Colour
                Map(mMapX, mMapY, 0) = 79
            Case 80 'Colour
                Map(mMapX, mMapY, 0) = 80
            Case 81 'Colour
                Map(mMapX, mMapY, 0) = 81
            Case 82 'Colour
                Map(mMapX, mMapY, 0) = 82
            Case 83 'Colour
                Map(mMapX, mMapY, 0) = 83
            Case 84 'Colour
                Map(mMapX, mMapY, 0) = 84
            Case 85 'Colour
                Map(mMapX, mMapY, 0) = 85
            Case 86 'Colour
                Map(mMapX, mMapY, 0) = 86
            Case 87 'Colour
                Map(mMapX, mMapY, 0) = 87
            Case 88 'Colour
                Map(mMapX, mMapY, 0) = 88
            Case 89 'Colour
                Map(mMapX, mMapY, 0) = 89
            Case 90 'Colour
                Map(mMapX, mMapY, 0) = 90
            Case 91 'Colour
                Map(mMapX, mMapY, 0) = 91
            Case 92 'Colour
                Map(mMapX, mMapY, 0) = 92
            Case 93 'Colour
                Map(mMapX, mMapY, 0) = 93
            Case 94 'Colour
                Map(mMapX, mMapY, 0) = 94
            Case 95 'Colour
                Map(mMapX, mMapY, 0) = 95
        End Select
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        MouseX = Math.Floor(e.X / TileSize)
        MouseY = Math.Floor(e.Y / TileSize)

        mMapX = MapX + MouseX
        mMapY = MapY + MouseY

    End Sub

    Private Sub GetSourceRectangle(ByVal X As Integer, ByVal Y As Integer, ByVal w As Integer, ByVal h As Integer)
        Select Case Map(X, Y, 0)
            Case 0 'Black Tile' changes all of them
                sRect = New Rectangle(87, 0, TileSize, TileSize)
            Case 1 'Box Bottom Straight 'Red
                sRect = New Rectangle(0, 0, TileSize, TileSize)
            Case 2 'Box Top Right Curve 'Blue
                sRect = New Rectangle(32, 0, TileSize, TileSize)
            Case 3 'Box Bottom Right Curve 'Black
                sRect = New Rectangle(64, 0, TileSize, TileSize)
            Case 4 'Right Straight 'Orange
                sRect = New Rectangle(96, 0, TileSize, TileSize)
            Case 5 'Bottom Straight 'Pink
                sRect = New Rectangle(128, 0, TileSize, TileSize)
            Case 6 'Box Left Curve 'Sandy Brown
                sRect = New Rectangle(0, 32, TileSize, TileSize)
            Case 7 'Box Bottom Straight 'Dark Green
                sRect = New Rectangle(32, 32, TileSize, TileSize)
            Case 8 'Box Bottom Left Curve 'Indigo
                sRect = New Rectangle(64, 32, TileSize, TileSize)
            Case 9 'Right Curve 'Navy
                sRect = New Rectangle(96, 32, TileSize, TileSize)
            Case 10 'Left Curve 'Chocolate
                sRect = New Rectangle(128, 32, TileSize, TileSize)
            Case 11 'Left Straight 'Dark Salmon
                sRect = New Rectangle(160, 32, TileSize, TileSize)
            Case 12 'Top Right Curve 'Gray
                sRect = New Rectangle(0, 64, TileSize, TileSize)
            Case 13 'Top Straight 'OliverDrab
                sRect = New Rectangle(32, 64, TileSize, TileSize)
            Case 14 'Top Left Curve 'Silver
                sRect = New Rectangle(64, 64, TileSize, TileSize)
            Case 15 'Mid Left Curve 'Turquoise
                sRect = New Rectangle(96, 64, TileSize, TileSize)
            Case 16 'Mid Joint 'Dark Grey
                sRect = New Rectangle(128, 64, TileSize, TileSize)
            Case 17 'Mid Right Curve 'Gold
                sRect = New Rectangle(96, 128, TileSize, TileSize)
            Case 18 'Mid Left Straight 'Lemon Chiffon
                sRect = New Rectangle(96, 96, TileSize, TileSize)
            Case 19 'Mid Right Straight 'Purple
                sRect = New Rectangle(128, 96, TileSize, TileSize)
            Case 20 'Black Tile 'Tan
                sRect = New Rectangle(87, 0, TileSize, TileSize)
            Case 21 ' Mid Bottom Right Curve 'Yellow
                sRect = New Rectangle(128, 128, TileSize, TileSize)
            Case 22 ' Left Curve Right Curve Joint 'Colour
                sRect = New Rectangle(0, 96, TileSize, TileSize)
            Case 23 'Left Curve Bottom Straight 'Colour
                sRect = New Rectangle(0, 128, TileSize, TileSize)
            Case 24 'Left Curve Top Straight 'Colour
                sRect = New Rectangle(32, 96, TileSize, TileSize)
            Case 25 'Left Curve Bottom Right Curve 'Colour
                sRect = New Rectangle(32, 128, TileSize, TileSize)
            Case 26 'Left Curve Top Right Curve 'Colour
                sRect = New Rectangle(64, 96, TileSize, TileSize)
            Case 27 'Left Curve Right Straight 'Colour
                sRect = New Rectangle(64, 128, TileSize, TileSize)
            Case 28 'Right Curve Joint 'Colour
                sRect = New Rectangle(256, 0, TileSize, TileSize)
            Case 29 'Right Curve Straight 'Colour
                sRect = New Rectangle(224, 0, TileSize, TileSize)
            Case 30 'Right Curve Left Joint 'Colour
                sRect = New Rectangle(193, 0, TileSize, TileSize)
            Case 31 'Right Curve Left Straight 'Colour
                sRect = New Rectangle(192, 160, TileSize, TileSize)
            Case 32 'Right Curve Left Right Joint 'Colour
                sRect = New Rectangle(160, 160, TileSize, TileSize)
            Case 33 'Right Bottom Straight 'Colour
                sRect = New Rectangle(128, 160, TileSize, TileSize)
            Case 34 'Left Curve Straight Joint 'Colour
                sRect = New Rectangle(96, 160, TileSize, TileSize)
            Case 35 'Right Curve Top Bottom 'Colour
                sRect = New Rectangle(64, 160, TileSize, TileSize)
            Case 36 'Right Curve Botton Straight 'Colour
                sRect = New Rectangle(32, 160, TileSize, TileSize)
            Case 37 'Right Curve Bottom Right Joint 'Colour
                sRect = New Rectangle(0, 160, TileSize, TileSize)
            Case 38 'Left Bump Top 'Colour
                sRect = New Rectangle(288, 0, TileSize, TileSize)
            Case 39 'Left Bump Bottom 'Colour
                sRect = New Rectangle(288, 32, TileSize, TileSize)
            Case 40 'Left Bump Top Edge 'Colour
                sRect = New Rectangle(320, 0, TileSize, TileSize)
            Case 41 'Left Bump Bottom Edge 'Colour
                sRect = New Rectangle(320, 32, TileSize, TileSize)
            Case 42 'Right Bump Top 'Colour
                sRect = New Rectangle(320, 64, TileSize, TileSize)
            Case 43 'Right Bump Bottom 'Colour
                sRect = New Rectangle(320, 96, TileSize, TileSize)
            Case 44 'Right Bump Top Edge 'Colour
                sRect = New Rectangle(288, 64, TileSize, TileSize)
            Case 45 'Right Bump Bottom Edge 'Colour
                sRect = New Rectangle(288, 96, TileSize, TileSize)
            Case 46 'Straight Curve Right Box 'Colour
                sRect = New Rectangle(320, 128, TileSize, TileSize)
            Case 47 'Straight Curve Left Box 'Colour
                sRect = New Rectangle(288, 128, TileSize, TileSize)
            Case 48 'Small Straight Curve Right Box 'Colour
                sRect = New Rectangle(320, 160, TileSize, TileSize)
            Case 49 'Small Straight Curve Left Box 'Colour
                sRect = New Rectangle(288, 160, TileSize, TileSize)
            Case 50 'Centre Box Right 'Colour
                sRect = New Rectangle(288, 192, TileSize, TileSize)
            Case 51 'Right Box Curve 'Colour
                sRect = New Rectangle(320, 192, TileSize, TileSize)
            Case 52 'Centre Box Left 'Colour
                sRect = New Rectangle(256, 192, TileSize, TileSize)
            Case 53 'Left Box Curve 'Colour
                sRect = New Rectangle(224, 192, TileSize, TileSize)
            Case 54 'Left Box Centre Straight 'Colour
                sRect = New Rectangle(224, 224, TileSize, TileSize)
            Case 55 'Centre Bottom Straight Centre 'Colour
                sRect = New Rectangle(256, 256, TileSize, TileSize)
            Case 56 'Centre Bottom Left Curve 'Colour
                sRect = New Rectangle(224, 256, TileSize, TileSize)
            Case 57 'Centre Bottom Right Curve 'Colour
                sRect = New Rectangle(320, 256, TileSize, TileSize)
            Case 58 'T-Shape Top Left Curve 'Colour
                sRect = New Rectangle(352, 0, TileSize, TileSize)
            Case 59 'T-Shape Top Centre Left Curve 'Colour
                sRect = New Rectangle(384, 0, TileSize, TileSize)
            Case 60 'T-Shape Top Centre Right Curve 'Colour
                sRect = New Rectangle(416, 0, TileSize, TileSize)
            Case 61 'T-Shape Top Right Curve 'Colour
                sRect = New Rectangle(448, 0, TileSize, TileSize)
            Case 62 'T-Shape Left Centre Straight Curve 'Colour
                sRect = New Rectangle(384, 32, TileSize, TileSize)
            Case 63 'T-Shape Left Centre End Curve 'Colour
                sRect = New Rectangle(384, 64, TileSize, TileSize)
            Case 64 'T-Shape Right Centre Straight Curve 'Colour
                sRect = New Rectangle(416, 32, TileSize, TileSize)
            Case 65 'T-Shape Right Centre End Curve 'Colour
                sRect = New Rectangle(416, 64, TileSize, TileSize)
            Case 66 'Upside Down T-Shape Left Curve 'Colour
                sRect = New Rectangle(352, 160, TileSize, TileSize)
            Case 67 'Upside Down T-Shape Centre Left Curve 'Colour
                sRect = New Rectangle(384, 160, TileSize, TileSize)
            Case 68 'Upside Down T-Shape Centre Right Curve 'Colour
                sRect = New Rectangle(416, 160, TileSize, TileSize)
            Case 69 'Upside Down T-Shape Centre Right Straight 'Colour
                sRect = New Rectangle(448, 160, TileSize, TileSize)
            Case 70 'Upside Down T-Shape Centre Right Curve 'Colour
                sRect = New Rectangle(474, 160, TileSize, TileSize)
            Case 71 'Upside Down T-Shape Top Left Curve 'Colour
                sRect = New Rectangle(384, 96, TileSize, TileSize)
            Case 72 'Upside Down T-Shape Top Right Curve 'Colour
                sRect = New Rectangle(416, 96, TileSize, TileSize)
            Case 73 'Upside Down L Left Curve 'Colour
                sRect = New Rectangle(480, 0, TileSize, TileSize)
            Case 74 'Upside Down L Right Curve 'Colour
                sRect = New Rectangle(512, 0, TileSize, TileSize)
            Case 75 'Upside Down L Bottom Curve 'Colour
                sRect = New Rectangle(480, 32, TileSize, TileSize)
            Case 76 'Left T-Shape Top Curve 'Colour
                sRect = New Rectangle(448, 32, TileSize, TileSize)
            Case 77 'Left T-Shape Top Centre Curve 'Colour
                sRect = New Rectangle(448, 64, TileSize, TileSize)
            Case 78 'Left T-Shape Top Centre Straight 'Colour
                sRect = New Rectangle(480, 64, TileSize, TileSize)
            Case 79 'Left T-Shape Top Centre Curve 'Colour
                sRect = New Rectangle(512, 64, TileSize, TileSize)
            Case 80 'Left T-Shape Bottom Curve 'Colour
                sRect = New Rectangle(448, 96, TileSize, TileSize)
            Case 81 'Left T-Shape Bottom Centre Straight 'Colour
                sRect = New Rectangle(480, 96, TileSize, TileSize)
            Case 82 'Left T-Shape Bottom Centre Curve 'Colour
                sRect = New Rectangle(512, 96, TileSize, TileSize)
            Case 83 'Left T-Shape Bottom Centre 'Colour
                sRect = New Rectangle(448, 128, TileSize, TileSize)
            Case 84 'Right T-Shape Top Centre 'Colour
                sRect = New Rectangle(608, 64, TileSize, TileSize)
            Case 85 'Right T-Shape Top Centre Curve 'Colour
                sRect = New Rectangle(544, 64, TileSize, TileSize)
            Case 86 'Right T-Shape Bottom Centre 'Colour
                sRect = New Rectangle(544, 96, TileSize, TileSize)
            Case 87 'Right T-Shape Bottom Centre  'Colour
                sRect = New Rectangle(608, 96, TileSize, TileSize)
            Case 88 'Left Upside Down L Curve  'Colour
                sRect = New Rectangle(544, 128, TileSize, TileSize)
            Case 89 'Left Upside Down L Edge  'Colour
                sRect = New Rectangle(576, 128, TileSize, TileSize)
            Case 90 'Left Upside Down L Bottom  'Colour
                sRect = New Rectangle(576, 160, TileSize, TileSize)
            Case 91 'Top Curve  'Colour
                sRect = New Rectangle(352, 192, TileSize, TileSize)
            Case 92 'Bottom Curve 'Colour
                sRect = New Rectangle(352, 224, TileSize, TileSize)
            Case 93 'Bottom Curve 'Colour
                sRect = New Rectangle(352, 256, TileSize, TileSize)
            Case 94 'Pill 'Colour
                sRect = New Rectangle(384, 192, TileSize, TileSize)
            Case 95 'Power Pill 'Colour
                sRect = New Rectangle(384, 224, TileSize, TileSize)
        End Select
    End Sub

    Private Sub SaveMap(ByVal MapFile As String)

        Try
            Dim sw As New IO.StreamWriter(MapFile & ".map")
            Dim strLine As String = ""
            Dim X As Integer = 0
            Dim Y As Integer = 0

            For Y = 0 To 100
                For X = 0 To 100
                    strLine = strLine & Map(X, Y, 0) & ","
                Next
                sw.WriteLine(strLine)
                strLine = ""
            Next
            sw.Close()
            sw.Dispose()

            MsgBox("Map '" & MapFile & "' Successfully Saved.", MsgBoxStyle.OkOnly, "Success")

        Catch ex As Exception
            MsgBox("Map '" & MapFile & "' Could not be Written to." & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical, "ERROR")
            IsRunning = False
        End Try

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SaveMap("Map1")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        LoadMap("Map1")
    End Sub
End Class