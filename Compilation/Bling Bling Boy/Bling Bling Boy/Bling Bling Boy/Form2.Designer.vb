<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenu
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
        Me.lblPlayer = New System.Windows.Forms.Label()
        Me.butDebug = New System.Windows.Forms.Button()
        Me.InvinsibleDescription = New System.Windows.Forms.Label()
        Me.butStartGame = New System.Windows.Forms.Button()
        Me.BugDisciption = New System.Windows.Forms.Label()
        Me.GemDiscription = New System.Windows.Forms.Label()
        Me.PlayerDiscription = New System.Windows.Forms.Label()
        Me.GameTitle = New System.Windows.Forms.Label()
        Me.pbInvinsHero = New System.Windows.Forms.PictureBox()
        Me.pbEnemy = New System.Windows.Forms.PictureBox()
        Me.pbGem = New System.Windows.Forms.PictureBox()
        Me.pbHero = New System.Windows.Forms.PictureBox()
        Me.lblHighScore = New System.Windows.Forms.Label()
        CType(Me.pbInvinsHero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEnemy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbGem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbHero, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblPlayer
        '
        Me.lblPlayer.AutoSize = True
        Me.lblPlayer.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlayer.Location = New System.Drawing.Point(14, 24)
        Me.lblPlayer.Name = "lblPlayer"
        Me.lblPlayer.Size = New System.Drawing.Size(140, 25)
        Me.lblPlayer.TabIndex = 25
        Me.lblPlayer.Text = "Best Player:"
        '
        'butDebug
        '
        Me.butDebug.Location = New System.Drawing.Point(482, 24)
        Me.butDebug.Name = "butDebug"
        Me.butDebug.Size = New System.Drawing.Size(79, 46)
        Me.butDebug.TabIndex = 24
        Me.butDebug.Text = "Score Save Form"
        Me.butDebug.UseVisualStyleBackColor = True
        '
        'InvinsibleDescription
        '
        Me.InvinsibleDescription.AutoSize = True
        Me.InvinsibleDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InvinsibleDescription.Location = New System.Drawing.Point(17, 391)
        Me.InvinsibleDescription.Name = "InvinsibleDescription"
        Me.InvinsibleDescription.Size = New System.Drawing.Size(451, 16)
        Me.InvinsibleDescription.TabIndex = 22
        Me.InvinsibleDescription.Text = "When Your Character Look Like the Adjacent Image then You are Invinsible"
        '
        'butStartGame
        '
        Me.butStartGame.Location = New System.Drawing.Point(215, 447)
        Me.butStartGame.Name = "butStartGame"
        Me.butStartGame.Size = New System.Drawing.Size(146, 46)
        Me.butStartGame.TabIndex = 21
        Me.butStartGame.Text = "Start Game"
        Me.butStartGame.UseVisualStyleBackColor = True
        '
        'BugDisciption
        '
        Me.BugDisciption.AutoSize = True
        Me.BugDisciption.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BugDisciption.Location = New System.Drawing.Point(16, 312)
        Me.BugDisciption.Name = "BugDisciption"
        Me.BugDisciption.Size = New System.Drawing.Size(390, 24)
        Me.BugDisciption.TabIndex = 20
        Me.BugDisciption.Text = "Avoid the Nasty Bugs, as they Will Chase You"
        '
        'GemDiscription
        '
        Me.GemDiscription.AutoSize = True
        Me.GemDiscription.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GemDiscription.Location = New System.Drawing.Point(16, 222)
        Me.GemDiscription.Name = "GemDiscription"
        Me.GemDiscription.Size = New System.Drawing.Size(313, 24)
        Me.GemDiscription.TabIndex = 19
        Me.GemDiscription.Text = "Collect the Red Gems to Gain Points"
        '
        'PlayerDiscription
        '
        Me.PlayerDiscription.AutoSize = True
        Me.PlayerDiscription.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PlayerDiscription.Location = New System.Drawing.Point(16, 132)
        Me.PlayerDiscription.Name = "PlayerDiscription"
        Me.PlayerDiscription.Size = New System.Drawing.Size(378, 24)
        Me.PlayerDiscription.TabIndex = 18
        Me.PlayerDiscription.Text = "Use the Arrow Keys to Move Bling Bling Boy"
        '
        'GameTitle
        '
        Me.GameTitle.AutoSize = True
        Me.GameTitle.Font = New System.Drawing.Font("Comic Sans MS", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GameTitle.Location = New System.Drawing.Point(171, 67)
        Me.GameTitle.Name = "GameTitle"
        Me.GameTitle.Size = New System.Drawing.Size(220, 40)
        Me.GameTitle.TabIndex = 17
        Me.GameTitle.Text = "Bling Bling Boy"
        '
        'pbInvinsHero
        '
        Me.pbInvinsHero.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.pbInvinsHero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pbInvinsHero.Image = Global.Bling_Bling_Boy.My.Resources.Resources.Invincible_Main_Sprite
        Me.pbInvinsHero.Location = New System.Drawing.Point(483, 360)
        Me.pbInvinsHero.Name = "pbInvinsHero"
        Me.pbInvinsHero.Size = New System.Drawing.Size(60, 68)
        Me.pbInvinsHero.TabIndex = 23
        Me.pbInvinsHero.TabStop = False
        '
        'pbEnemy
        '
        Me.pbEnemy.Image = Global.Bling_Bling_Boy.My.Resources.Resources.Enemy_Sprite
        Me.pbEnemy.Location = New System.Drawing.Point(427, 302)
        Me.pbEnemy.Name = "pbEnemy"
        Me.pbEnemy.Size = New System.Drawing.Size(30, 34)
        Me.pbEnemy.TabIndex = 16
        Me.pbEnemy.TabStop = False
        Me.pbEnemy.Tag = "Enemy"
        '
        'pbGem
        '
        Me.pbGem.Image = Global.Bling_Bling_Boy.My.Resources.Resources.Gem
        Me.pbGem.Location = New System.Drawing.Point(427, 214)
        Me.pbGem.Name = "pbGem"
        Me.pbGem.Size = New System.Drawing.Size(32, 32)
        Me.pbGem.TabIndex = 15
        Me.pbGem.TabStop = False
        '
        'pbHero
        '
        Me.pbHero.Image = Global.Bling_Bling_Boy.My.Resources.Resources.Untitled
        Me.pbHero.Location = New System.Drawing.Point(427, 101)
        Me.pbHero.Name = "pbHero"
        Me.pbHero.Size = New System.Drawing.Size(60, 68)
        Me.pbHero.TabIndex = 14
        Me.pbHero.TabStop = False
        '
        'lblHighScore
        '
        Me.lblHighScore.AutoSize = True
        Me.lblHighScore.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHighScore.Location = New System.Drawing.Point(14, 49)
        Me.lblHighScore.Name = "lblHighScore"
        Me.lblHighScore.Size = New System.Drawing.Size(135, 25)
        Me.lblHighScore.TabIndex = 26
        Me.lblHighScore.Text = "High Score:"
        '
        'frmMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(575, 505)
        Me.Controls.Add(Me.lblHighScore)
        Me.Controls.Add(Me.lblPlayer)
        Me.Controls.Add(Me.butDebug)
        Me.Controls.Add(Me.pbInvinsHero)
        Me.Controls.Add(Me.InvinsibleDescription)
        Me.Controls.Add(Me.butStartGame)
        Me.Controls.Add(Me.BugDisciption)
        Me.Controls.Add(Me.GemDiscription)
        Me.Controls.Add(Me.PlayerDiscription)
        Me.Controls.Add(Me.GameTitle)
        Me.Controls.Add(Me.pbEnemy)
        Me.Controls.Add(Me.pbGem)
        Me.Controls.Add(Me.pbHero)
        Me.Name = "frmMenu"
        Me.Text = "Menu"
        CType(Me.pbInvinsHero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEnemy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbGem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbHero, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblPlayer As Label
    Friend WithEvents butDebug As Button
    Friend WithEvents pbInvinsHero As PictureBox
    Friend WithEvents InvinsibleDescription As Label
    Friend WithEvents butStartGame As Button
    Friend WithEvents BugDisciption As Label
    Friend WithEvents GemDiscription As Label
    Friend WithEvents PlayerDiscription As Label
    Friend WithEvents GameTitle As Label
    Friend WithEvents pbEnemy As PictureBox
    Friend WithEvents pbGem As PictureBox
    Friend WithEvents pbHero As PictureBox
    Friend WithEvents lblHighScore As Label
End Class
