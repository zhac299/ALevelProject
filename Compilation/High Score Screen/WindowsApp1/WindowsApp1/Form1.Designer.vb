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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblBest = New System.Windows.Forms.Label()
        Me.lblSecond = New System.Windows.Forms.Label()
        Me.lblThird = New System.Windows.Forms.Label()
        Me.butSearch = New System.Windows.Forms.Button()
        Me.butFind = New System.Windows.Forms.Button()
        Me.lblFourth = New System.Windows.Forms.Label()
        Me.lblFifth = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(94, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(385, 73)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Top Players"
        '
        'lblBest
        '
        Me.lblBest.AutoSize = True
        Me.lblBest.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBest.Location = New System.Drawing.Point(145, 134)
        Me.lblBest.Name = "lblBest"
        Me.lblBest.Size = New System.Drawing.Size(0, 39)
        Me.lblBest.TabIndex = 1
        '
        'lblSecond
        '
        Me.lblSecond.AutoSize = True
        Me.lblSecond.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSecond.Location = New System.Drawing.Point(145, 215)
        Me.lblSecond.Name = "lblSecond"
        Me.lblSecond.Size = New System.Drawing.Size(0, 39)
        Me.lblSecond.TabIndex = 2
        '
        'lblThird
        '
        Me.lblThird.AutoSize = True
        Me.lblThird.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblThird.Location = New System.Drawing.Point(145, 288)
        Me.lblThird.Name = "lblThird"
        Me.lblThird.Size = New System.Drawing.Size(0, 39)
        Me.lblThird.TabIndex = 3
        '
        'butSearch
        '
        Me.butSearch.Location = New System.Drawing.Point(12, 23)
        Me.butSearch.Name = "butSearch"
        Me.butSearch.Size = New System.Drawing.Size(75, 23)
        Me.butSearch.TabIndex = 5
        Me.butSearch.Text = "Search"
        Me.butSearch.UseVisualStyleBackColor = True
        '
        'butFind
        '
        Me.butFind.Location = New System.Drawing.Point(485, 23)
        Me.butFind.Name = "butFind"
        Me.butFind.Size = New System.Drawing.Size(75, 23)
        Me.butFind.TabIndex = 6
        Me.butFind.Text = "Find Score"
        Me.butFind.UseVisualStyleBackColor = True
        '
        'lblFourth
        '
        Me.lblFourth.AutoSize = True
        Me.lblFourth.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFourth.Location = New System.Drawing.Point(145, 362)
        Me.lblFourth.Name = "lblFourth"
        Me.lblFourth.Size = New System.Drawing.Size(0, 39)
        Me.lblFourth.TabIndex = 7
        '
        'lblFifth
        '
        Me.lblFifth.AutoSize = True
        Me.lblFifth.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFifth.Location = New System.Drawing.Point(145, 431)
        Me.lblFifth.Name = "lblFifth"
        Me.lblFifth.Size = New System.Drawing.Size(0, 39)
        Me.lblFifth.TabIndex = 8
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(572, 494)
        Me.Controls.Add(Me.lblFifth)
        Me.Controls.Add(Me.lblFourth)
        Me.Controls.Add(Me.butFind)
        Me.Controls.Add(Me.butSearch)
        Me.Controls.Add(Me.lblThird)
        Me.Controls.Add(Me.lblSecond)
        Me.Controls.Add(Me.lblBest)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lblBest As Label
    Friend WithEvents lblSecond As Label
    Friend WithEvents lblThird As Label
    Friend WithEvents butSearch As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents butFind As Button
    Friend WithEvents lblFourth As Label
    Friend WithEvents lblFifth As Label
End Class
