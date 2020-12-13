Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.pbBird = New System.Windows.Forms.PictureBox()
        Me.pbTopWall = New System.Windows.Forms.PictureBox()
        Me.pbBottomWall = New System.Windows.Forms.PictureBox()
        Me.lblScore = New System.Windows.Forms.Label()
        Me.RandomEvent = New System.Windows.Forms.Timer(Me.components)
        Me.lblIndicator = New System.Windows.Forms.Label()
        CType(Me.pbBird, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbTopWall, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbBottomWall, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 40
        '
        'pbBird
        '
        Me.pbBird.BackColor = System.Drawing.SystemColors.Control
        Me.pbBird.Image = Global.Flappy_Bird.My.Resources.Resources.Untitled
        Me.pbBird.Location = New System.Drawing.Point(51, 61)
        Me.pbBird.Name = "pbBird"
        Me.pbBird.Size = New System.Drawing.Size(45, 37)
        Me.pbBird.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbBird.TabIndex = 0
        Me.pbBird.TabStop = False
        '
        'pbTopWall
        '
        Me.pbTopWall.Location = New System.Drawing.Point(13, -12)
        Me.pbTopWall.Name = "pbTopWall"
        Me.pbTopWall.Size = New System.Drawing.Size(344, 10)
        Me.pbTopWall.TabIndex = 1
        Me.pbTopWall.TabStop = False
        '
        'pbBottomWall
        '
        Me.pbBottomWall.Location = New System.Drawing.Point(9, 369)
        Me.pbBottomWall.Name = "pbBottomWall"
        Me.pbBottomWall.Size = New System.Drawing.Size(344, 10)
        Me.pbBottomWall.TabIndex = 2
        Me.pbBottomWall.TabStop = False
        '
        'lblScore
        '
        Me.lblScore.AutoSize = True
        Me.lblScore.Location = New System.Drawing.Point(153, 13)
        Me.lblScore.Name = "lblScore"
        Me.lblScore.Size = New System.Drawing.Size(39, 13)
        Me.lblScore.TabIndex = 3
        Me.lblScore.Text = "Label1"
        '
        'RandomEvent
        '
        Me.RandomEvent.Interval = 1000
        '
        'lblIndicator
        '
        Me.lblIndicator.AutoSize = True
        Me.lblIndicator.Location = New System.Drawing.Point(12, 13)
        Me.lblIndicator.Name = "lblIndicator"
        Me.lblIndicator.Size = New System.Drawing.Size(0, 13)
        Me.lblIndicator.TabIndex = 4
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(365, 367)
        Me.Controls.Add(Me.lblIndicator)
        Me.Controls.Add(Me.lblScore)
        Me.Controls.Add(Me.pbBottomWall)
        Me.Controls.Add(Me.pbTopWall)
        Me.Controls.Add(Me.pbBird)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        CType(Me.pbBird, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbTopWall, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbBottomWall, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pbBird As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents pbTopWall As PictureBox
    Friend WithEvents pbBottomWall As PictureBox
    Friend WithEvents lblScore As Label
    Friend WithEvents RandomEvent As Timer
    Friend WithEvents lblIndicator As Label
End Class
