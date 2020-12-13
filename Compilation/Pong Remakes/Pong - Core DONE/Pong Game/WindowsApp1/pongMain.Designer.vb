Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class pongMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.paddlePlayer = New System.Windows.Forms.PictureBox()
        Me.paddleComputer = New System.Windows.Forms.PictureBox()
        Me.gameBall = New System.Windows.Forms.PictureBox()
        Me.plrScoreDraw = New System.Windows.Forms.Label()
        Me.compScoreDraw = New System.Windows.Forms.Label()
        Me.gameTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Restart = New System.Windows.Forms.Button()
        Me.Backto = New System.Windows.Forms.Button()
        Me.AITimer = New System.Windows.Forms.Timer(Me.components)
        Me.pbTopWall = New System.Windows.Forms.PictureBox()
        Me.pbBottomWall = New System.Windows.Forms.PictureBox()
        Me.pbLeftWall = New System.Windows.Forms.PictureBox()
        Me.pbRightWall = New System.Windows.Forms.PictureBox()
        Me.madmodeTimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.paddlePlayer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.paddleComputer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gameBall, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbTopWall, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbBottomWall, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbLeftWall, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbRightWall, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'paddlePlayer
        '
        Me.paddlePlayer.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.paddlePlayer.Location = New System.Drawing.Point(571, 158)
        Me.paddlePlayer.Name = "paddlePlayer"
        Me.paddlePlayer.Size = New System.Drawing.Size(16, 109)
        Me.paddlePlayer.TabIndex = 0
        Me.paddlePlayer.TabStop = False
        '
        'paddleComputer
        '
        Me.paddleComputer.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.paddleComputer.Location = New System.Drawing.Point(30, 158)
        Me.paddleComputer.Name = "paddleComputer"
        Me.paddleComputer.Size = New System.Drawing.Size(16, 109)
        Me.paddleComputer.TabIndex = 1
        Me.paddleComputer.TabStop = False
        '
        'gameBall
        '
        Me.gameBall.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.gameBall.Location = New System.Drawing.Point(289, 201)
        Me.gameBall.Name = "gameBall"
        Me.gameBall.Size = New System.Drawing.Size(20, 20)
        Me.gameBall.TabIndex = 2
        Me.gameBall.TabStop = False
        '
        'plrScoreDraw
        '
        Me.plrScoreDraw.AutoSize = True
        Me.plrScoreDraw.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.plrScoreDraw.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.plrScoreDraw.Location = New System.Drawing.Point(560, 38)
        Me.plrScoreDraw.Name = "plrScoreDraw"
        Me.plrScoreDraw.Size = New System.Drawing.Size(27, 29)
        Me.plrScoreDraw.TabIndex = 3
        Me.plrScoreDraw.Text = "0"
        '
        'compScoreDraw
        '
        Me.compScoreDraw.AutoSize = True
        Me.compScoreDraw.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.compScoreDraw.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.compScoreDraw.Location = New System.Drawing.Point(25, 38)
        Me.compScoreDraw.Name = "compScoreDraw"
        Me.compScoreDraw.Size = New System.Drawing.Size(27, 29)
        Me.compScoreDraw.TabIndex = 4
        Me.compScoreDraw.Text = "0"
        '
        'gameTimer
        '
        Me.gameTimer.Interval = 20
        '
        'Restart
        '
        Me.Restart.Location = New System.Drawing.Point(258, 12)
        Me.Restart.Name = "Restart"
        Me.Restart.Size = New System.Drawing.Size(75, 23)
        Me.Restart.TabIndex = 5
        Me.Restart.Text = "Restart"
        Me.Restart.UseVisualStyleBackColor = True
        Me.Restart.Visible = False
        '
        'Backto
        '
        Me.Backto.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Backto.Location = New System.Drawing.Point(258, 407)
        Me.Backto.Name = "Backto"
        Me.Backto.Size = New System.Drawing.Size(75, 23)
        Me.Backto.TabIndex = 6
        Me.Backto.Text = "Back to Menu"
        Me.Backto.UseVisualStyleBackColor = True
        Me.Backto.Visible = False
        '
        'AITimer
        '
        Me.AITimer.Interval = 4000
        '
        'pbTopWall
        '
        Me.pbTopWall.Location = New System.Drawing.Point(-1, -10)
        Me.pbTopWall.Name = "pbTopWall"
        Me.pbTopWall.Size = New System.Drawing.Size(624, 10)
        Me.pbTopWall.TabIndex = 7
        Me.pbTopWall.TabStop = False
        '
        'pbBottomWall
        '
        Me.pbBottomWall.Location = New System.Drawing.Point(0, 441)
        Me.pbBottomWall.Name = "pbBottomWall"
        Me.pbBottomWall.Size = New System.Drawing.Size(624, 10)
        Me.pbBottomWall.TabIndex = 8
        Me.pbBottomWall.TabStop = False
        '
        'pbLeftWall
        '
        Me.pbLeftWall.Location = New System.Drawing.Point(-10, -25)
        Me.pbLeftWall.Name = "pbLeftWall"
        Me.pbLeftWall.Size = New System.Drawing.Size(10, 475)
        Me.pbLeftWall.TabIndex = 9
        Me.pbLeftWall.TabStop = False
        '
        'pbRightWall
        '
        Me.pbRightWall.Location = New System.Drawing.Point(624, -19)
        Me.pbRightWall.Name = "pbRightWall"
        Me.pbRightWall.Size = New System.Drawing.Size(10, 465)
        Me.pbRightWall.TabIndex = 10
        Me.pbRightWall.TabStop = False
        '
        'madmodeTimer
        '
        Me.madmodeTimer.Interval = 20
        '
        'pongMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(624, 442)
        Me.Controls.Add(Me.pbRightWall)
        Me.Controls.Add(Me.pbLeftWall)
        Me.Controls.Add(Me.pbBottomWall)
        Me.Controls.Add(Me.pbTopWall)
        Me.Controls.Add(Me.Backto)
        Me.Controls.Add(Me.Restart)
        Me.Controls.Add(Me.compScoreDraw)
        Me.Controls.Add(Me.plrScoreDraw)
        Me.Controls.Add(Me.gameBall)
        Me.Controls.Add(Me.paddleComputer)
        Me.Controls.Add(Me.paddlePlayer)
        Me.Name = "pongMain"
        Me.Text = "Pong"
        CType(Me.paddlePlayer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.paddleComputer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gameBall, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbTopWall, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbBottomWall, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbLeftWall, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbRightWall, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents paddlePlayer As PictureBox
    Friend WithEvents paddleComputer As PictureBox
    Friend WithEvents gameBall As PictureBox
    Friend WithEvents plrScoreDraw As Label
    Friend WithEvents compScoreDraw As Label
    Friend WithEvents gameTimer As Timer
    Friend WithEvents Restart As Button
    Friend WithEvents Backto As Button
    Friend WithEvents AITimer As Timer
    Friend WithEvents pbTopWall As PictureBox
    Friend WithEvents pbBottomWall As PictureBox
    Friend WithEvents pbLeftWall As PictureBox
    Friend WithEvents pbRightWall As PictureBox
    Friend WithEvents madmodeTimer As Timer
End Class
