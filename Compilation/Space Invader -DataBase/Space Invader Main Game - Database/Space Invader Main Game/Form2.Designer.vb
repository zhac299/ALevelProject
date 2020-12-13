<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.butMergeSort = New System.Windows.Forms.Button()
        Me.butSearch = New System.Windows.Forms.Button()
        Me.butSubmit = New System.Windows.Forms.Button()
        Me.lblScore = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'butMergeSort
        '
        Me.butMergeSort.Location = New System.Drawing.Point(536, 23)
        Me.butMergeSort.Name = "butMergeSort"
        Me.butMergeSort.Size = New System.Drawing.Size(75, 23)
        Me.butMergeSort.TabIndex = 19
        Me.butMergeSort.Text = "Sort Data"
        Me.butMergeSort.UseVisualStyleBackColor = True
        '
        'butSearch
        '
        Me.butSearch.Location = New System.Drawing.Point(15, 23)
        Me.butSearch.Name = "butSearch"
        Me.butSearch.Size = New System.Drawing.Size(75, 23)
        Me.butSearch.TabIndex = 18
        Me.butSearch.Text = "Search Data"
        Me.butSearch.UseVisualStyleBackColor = True
        Me.butSearch.Visible = False
        '
        'butSubmit
        '
        Me.butSubmit.Location = New System.Drawing.Point(248, 401)
        Me.butSubmit.Name = "butSubmit"
        Me.butSubmit.Size = New System.Drawing.Size(108, 23)
        Me.butSubmit.TabIndex = 17
        Me.butSubmit.Text = "Submit"
        Me.butSubmit.UseVisualStyleBackColor = True
        '
        'lblScore
        '
        Me.lblScore.AutoSize = True
        Me.lblScore.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScore.Location = New System.Drawing.Point(322, 249)
        Me.lblScore.Name = "lblScore"
        Me.lblScore.Size = New System.Drawing.Size(0, 37)
        Me.lblScore.TabIndex = 16
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(38, 249)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(265, 55)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Your Score"
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(304, 129)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(234, 20)
        Me.txtUsername.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(38, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(247, 55)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Username"
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(627, 450)
        Me.Controls.Add(Me.butMergeSort)
        Me.Controls.Add(Me.butSearch)
        Me.Controls.Add(Me.butSubmit)
        Me.Controls.Add(Me.lblScore)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form2"
        Me.Text = "Form2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents butMergeSort As Button
    Friend WithEvents butSearch As Button
    Friend WithEvents butSubmit As Button
    Friend WithEvents lblScore As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents Label1 As Label
End Class
