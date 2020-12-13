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
        Me.lblGameName = New System.Windows.Forms.Label()
        Me.butStartGame = New System.Windows.Forms.Button()
        Me.butExit = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblGameName
        '
        Me.lblGameName.AutoSize = True
        Me.lblGameName.Font = New System.Drawing.Font("Cooper Black", 36.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGameName.Location = New System.Drawing.Point(117, 24)
        Me.lblGameName.Name = "lblGameName"
        Me.lblGameName.Size = New System.Drawing.Size(315, 55)
        Me.lblGameName.TabIndex = 0
        Me.lblGameName.Text = "Flappy Bird"
        '
        'butStartGame
        '
        Me.butStartGame.Location = New System.Drawing.Point(230, 155)
        Me.butStartGame.Name = "butStartGame"
        Me.butStartGame.Size = New System.Drawing.Size(99, 34)
        Me.butStartGame.TabIndex = 1
        Me.butStartGame.Text = "Start Game"
        Me.butStartGame.UseVisualStyleBackColor = True
        '
        'butExit
        '
        Me.butExit.Location = New System.Drawing.Point(230, 351)
        Me.butExit.Name = "butExit"
        Me.butExit.Size = New System.Drawing.Size(99, 34)
        Me.butExit.TabIndex = 3
        Me.butExit.Text = "Exit"
        Me.butExit.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Flappy_Bird_Menu.My.Resources.Resources.Untitled
        Me.PictureBox1.Location = New System.Drawing.Point(25, 134)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(102, 69)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(558, 537)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.butExit)
        Me.Controls.Add(Me.butStartGame)
        Me.Controls.Add(Me.lblGameName)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblGameName As Label
    Friend WithEvents butStartGame As Button
    Friend WithEvents butExit As Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
