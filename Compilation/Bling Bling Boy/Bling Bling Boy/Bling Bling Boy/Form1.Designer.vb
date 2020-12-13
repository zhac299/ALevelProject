<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGame
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
        Me.pbBoy = New System.Windows.Forms.PictureBox()
        Me.gameTimer = New System.Windows.Forms.Timer(Me.components)
        Me.pbGem = New System.Windows.Forms.PictureBox()
        Me.lblScore = New System.Windows.Forms.Label()
        Me.enemyTimer = New System.Windows.Forms.Timer(Me.components)
        Me.lblLives = New System.Windows.Forms.Label()
        Me.pbEnemy1 = New System.Windows.Forms.PictureBox()
        Me.pbEnemy2 = New System.Windows.Forms.PictureBox()
        Me.pbEnemy3 = New System.Windows.Forms.PictureBox()
        Me.pbEnemy4 = New System.Windows.Forms.PictureBox()
        Me.pbEnemy5 = New System.Windows.Forms.PictureBox()
        CType(Me.pbBoy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbGem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEnemy1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEnemy2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEnemy3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEnemy4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEnemy5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbBoy
        '
        Me.pbBoy.Image = Global.Bling_Bling_Boy.My.Resources.Resources.Untitled
        Me.pbBoy.Location = New System.Drawing.Point(446, 91)
        Me.pbBoy.Name = "pbBoy"
        Me.pbBoy.Size = New System.Drawing.Size(60, 68)
        Me.pbBoy.TabIndex = 0
        Me.pbBoy.TabStop = False
        '
        'gameTimer
        '
        Me.gameTimer.Enabled = True
        Me.gameTimer.Interval = 20
        '
        'pbGem
        '
        Me.pbGem.Image = Global.Bling_Bling_Boy.My.Resources.Resources.Gem
        Me.pbGem.Location = New System.Drawing.Point(257, 189)
        Me.pbGem.Name = "pbGem"
        Me.pbGem.Size = New System.Drawing.Size(32, 32)
        Me.pbGem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbGem.TabIndex = 1
        Me.pbGem.TabStop = False
        Me.pbGem.Visible = False
        '
        'lblScore
        '
        Me.lblScore.AutoSize = True
        Me.lblScore.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScore.Location = New System.Drawing.Point(12, 9)
        Me.lblScore.Name = "lblScore"
        Me.lblScore.Size = New System.Drawing.Size(71, 24)
        Me.lblScore.TabIndex = 2
        Me.lblScore.Text = "Score:"
        '
        'enemyTimer
        '
        Me.enemyTimer.Enabled = True
        Me.enemyTimer.Interval = 20
        '
        'lblLives
        '
        Me.lblLives.AutoSize = True
        Me.lblLives.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLives.Location = New System.Drawing.Point(12, 33)
        Me.lblLives.Name = "lblLives"
        Me.lblLives.Size = New System.Drawing.Size(64, 24)
        Me.lblLives.TabIndex = 3
        Me.lblLives.Text = "Lives:"
        '
        'pbEnemy1
        '
        Me.pbEnemy1.Image = Global.Bling_Bling_Boy.My.Resources.Resources.Enemy_Sprite
        Me.pbEnemy1.Location = New System.Drawing.Point(343, 323)
        Me.pbEnemy1.Name = "pbEnemy1"
        Me.pbEnemy1.Size = New System.Drawing.Size(30, 34)
        Me.pbEnemy1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbEnemy1.TabIndex = 4
        Me.pbEnemy1.TabStop = False
        '
        'pbEnemy2
        '
        Me.pbEnemy2.Image = Global.Bling_Bling_Boy.My.Resources.Resources.Enemy_Sprite
        Me.pbEnemy2.Location = New System.Drawing.Point(290, 323)
        Me.pbEnemy2.Name = "pbEnemy2"
        Me.pbEnemy2.Size = New System.Drawing.Size(30, 34)
        Me.pbEnemy2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbEnemy2.TabIndex = 5
        Me.pbEnemy2.TabStop = False
        Me.pbEnemy2.Visible = False
        '
        'pbEnemy3
        '
        Me.pbEnemy3.Image = Global.Bling_Bling_Boy.My.Resources.Resources.Enemy_Sprite
        Me.pbEnemy3.Location = New System.Drawing.Point(239, 323)
        Me.pbEnemy3.Name = "pbEnemy3"
        Me.pbEnemy3.Size = New System.Drawing.Size(30, 34)
        Me.pbEnemy3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbEnemy3.TabIndex = 6
        Me.pbEnemy3.TabStop = False
        Me.pbEnemy3.Visible = False
        '
        'pbEnemy4
        '
        Me.pbEnemy4.Image = Global.Bling_Bling_Boy.My.Resources.Resources.Enemy_Sprite
        Me.pbEnemy4.Location = New System.Drawing.Point(189, 323)
        Me.pbEnemy4.Name = "pbEnemy4"
        Me.pbEnemy4.Size = New System.Drawing.Size(30, 34)
        Me.pbEnemy4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbEnemy4.TabIndex = 7
        Me.pbEnemy4.TabStop = False
        Me.pbEnemy4.Visible = False
        '
        'pbEnemy5
        '
        Me.pbEnemy5.Image = Global.Bling_Bling_Boy.My.Resources.Resources.Enemy_Sprite
        Me.pbEnemy5.Location = New System.Drawing.Point(142, 323)
        Me.pbEnemy5.Name = "pbEnemy5"
        Me.pbEnemy5.Size = New System.Drawing.Size(30, 34)
        Me.pbEnemy5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbEnemy5.TabIndex = 8
        Me.pbEnemy5.TabStop = False
        Me.pbEnemy5.Visible = False
        '
        'frmGame
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(584, 440)
        Me.Controls.Add(Me.pbEnemy5)
        Me.Controls.Add(Me.pbEnemy4)
        Me.Controls.Add(Me.pbEnemy3)
        Me.Controls.Add(Me.pbEnemy2)
        Me.Controls.Add(Me.pbEnemy1)
        Me.Controls.Add(Me.lblLives)
        Me.Controls.Add(Me.pbGem)
        Me.Controls.Add(Me.pbBoy)
        Me.Controls.Add(Me.lblScore)
        Me.Name = "frmGame"
        Me.Text = "Bling Bling Boy"
        CType(Me.pbBoy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbGem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEnemy1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEnemy2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEnemy3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEnemy4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEnemy5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pbBoy As PictureBox
    Friend WithEvents gameTimer As Timer
    Private WithEvents pbGem As PictureBox
    Friend WithEvents lblScore As Label
    Friend WithEvents enemyTimer As Timer
    Friend WithEvents lblLives As Label
    Friend WithEvents pbEnemy1 As PictureBox
    Friend WithEvents pbEnemy2 As PictureBox
    Friend WithEvents pbEnemy3 As PictureBox
    Friend WithEvents pbEnemy4 As PictureBox
    Friend WithEvents pbEnemy5 As PictureBox
End Class
