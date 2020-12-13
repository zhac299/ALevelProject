Imports System.Timers

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.enemyTimer = New System.Windows.Forms.Timer(Me.components)
        Me.lblScore = New System.Windows.Forms.Label()
        Me.scoreTimer = New System.Windows.Forms.Timer(Me.components)
        Me.pbRightWall = New System.Windows.Forms.PictureBox()
        Me.pbLeftWall = New System.Windows.Forms.PictureBox()
        Me.pbShip = New System.Windows.Forms.PictureBox()
        Me.pbTopBoundary = New System.Windows.Forms.PictureBox()
        Me.pbBottomBoundary = New System.Windows.Forms.PictureBox()
        CType(Me.pbRightWall, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbLeftWall, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbShip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbTopBoundary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbBottomBoundary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 20
        '
        'enemyTimer
        '
        Me.enemyTimer.Interval = 200
        '
        'lblScore
        '
        Me.lblScore.AutoSize = True
        Me.lblScore.BackColor = System.Drawing.Color.Black
        Me.lblScore.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScore.ForeColor = System.Drawing.Color.White
        Me.lblScore.Location = New System.Drawing.Point(407, 18)
        Me.lblScore.Name = "lblScore"
        Me.lblScore.Size = New System.Drawing.Size(56, 20)
        Me.lblScore.TabIndex = 0
        Me.lblScore.Text = "Score"
        '
        'scoreTimer
        '
        Me.scoreTimer.Interval = 1000
        '
        'pbRightWall
        '
        Me.pbRightWall.Location = New System.Drawing.Point(496, -1)
        Me.pbRightWall.Name = "pbRightWall"
        Me.pbRightWall.Size = New System.Drawing.Size(14, 492)
        Me.pbRightWall.TabIndex = 1
        Me.pbRightWall.TabStop = False
        '
        'pbLeftWall
        '
        Me.pbLeftWall.Location = New System.Drawing.Point(-14, -2)
        Me.pbLeftWall.Name = "pbLeftWall"
        Me.pbLeftWall.Size = New System.Drawing.Size(14, 492)
        Me.pbLeftWall.TabIndex = 2
        Me.pbLeftWall.TabStop = False
        '
        'pbShip
        '
        Me.pbShip.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pbShip.Location = New System.Drawing.Point(213, 438)
        Me.pbShip.Name = "pbShip"
        Me.pbShip.Size = New System.Drawing.Size(40, 40)
        Me.pbShip.TabIndex = 3
        Me.pbShip.TabStop = False
        '
        'pbTopBoundary
        '
        Me.pbTopBoundary.Location = New System.Drawing.Point(2, -10)
        Me.pbTopBoundary.Name = "pbTopBoundary"
        Me.pbTopBoundary.Size = New System.Drawing.Size(495, 10)
        Me.pbTopBoundary.TabIndex = 4
        Me.pbTopBoundary.TabStop = False
        '
        'pbBottomBoundary
        '
        Me.pbBottomBoundary.Location = New System.Drawing.Point(1, 490)
        Me.pbBottomBoundary.Name = "pbBottomBoundary"
        Me.pbBottomBoundary.Size = New System.Drawing.Size(495, 10)
        Me.pbBottomBoundary.TabIndex = 5
        Me.pbBottomBoundary.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(496, 490)
        Me.Controls.Add(Me.pbBottomBoundary)
        Me.Controls.Add(Me.pbTopBoundary)
        Me.Controls.Add(Me.pbShip)
        Me.Controls.Add(Me.pbLeftWall)
        Me.Controls.Add(Me.pbRightWall)
        Me.Controls.Add(Me.lblScore)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        CType(Me.pbRightWall, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbLeftWall, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbShip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbTopBoundary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbBottomBoundary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents enemyTimer As System.Windows.Forms.Timer
    Friend WithEvents lblScore As System.Windows.Forms.Label
    Friend WithEvents scoreTimer As System.Windows.Forms.Timer
    Friend WithEvents pbRightWall As PictureBox
    Friend WithEvents pbLeftWall As PictureBox
    Friend WithEvents pbShip As PictureBox
    Friend WithEvents pbTopBoundary As PictureBox
    Friend WithEvents pbBottomBoundary As PictureBox
End Class
