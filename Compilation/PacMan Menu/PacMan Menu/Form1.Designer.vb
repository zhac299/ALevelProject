<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.butStart = New System.Windows.Forms.Button()
        Me.butChooseMap = New System.Windows.Forms.Button()
        Me.butHighScore = New System.Windows.Forms.Button()
        Me.butQuit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.BackColor = System.Drawing.Color.Black
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(227, 28)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(207, 55)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "PacMan"
        '
        'butStart
        '
        Me.butStart.Location = New System.Drawing.Point(268, 149)
        Me.butStart.Name = "butStart"
        Me.butStart.Size = New System.Drawing.Size(110, 28)
        Me.butStart.TabIndex = 1
        Me.butStart.Text = "Start Game"
        Me.butStart.UseVisualStyleBackColor = True
        '
        'butChooseMap
        '
        Me.butChooseMap.Location = New System.Drawing.Point(268, 234)
        Me.butChooseMap.Name = "butChooseMap"
        Me.butChooseMap.Size = New System.Drawing.Size(110, 28)
        Me.butChooseMap.TabIndex = 2
        Me.butChooseMap.Text = "Choose Map"
        Me.butChooseMap.UseVisualStyleBackColor = True
        '
        'butHighScore
        '
        Me.butHighScore.Location = New System.Drawing.Point(268, 316)
        Me.butHighScore.Name = "butHighScore"
        Me.butHighScore.Size = New System.Drawing.Size(110, 28)
        Me.butHighScore.TabIndex = 3
        Me.butHighScore.Text = "High Score"
        Me.butHighScore.UseVisualStyleBackColor = True
        '
        'butQuit
        '
        Me.butQuit.Location = New System.Drawing.Point(268, 393)
        Me.butQuit.Name = "butQuit"
        Me.butQuit.Size = New System.Drawing.Size(110, 28)
        Me.butQuit.TabIndex = 4
        Me.butQuit.Text = "Quit"
        Me.butQuit.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(663, 501)
        Me.Controls.Add(Me.butQuit)
        Me.Controls.Add(Me.butHighScore)
        Me.Controls.Add(Me.butChooseMap)
        Me.Controls.Add(Me.butStart)
        Me.Controls.Add(Me.lblTitle)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents butStart As Button
    Friend WithEvents butChooseMap As Button
    Friend WithEvents butHighScore As Button
    Friend WithEvents butQuit As Button
End Class
