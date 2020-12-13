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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.butStart = New System.Windows.Forms.Button()
        Me.butQuit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'butMergeSort
        '
        Me.butMergeSort.Location = New System.Drawing.Point(525, 34)
        Me.butMergeSort.Name = "butMergeSort"
        Me.butMergeSort.Size = New System.Drawing.Size(75, 23)
        Me.butMergeSort.TabIndex = 0
        Me.butMergeSort.Text = "Sort Data"
        Me.butMergeSort.UseVisualStyleBackColor = True
        Me.butMergeSort.Visible = False
        '
        'butSearch
        '
        Me.butSearch.Location = New System.Drawing.Point(21, 34)
        Me.butSearch.Name = "butSearch"
        Me.butSearch.Size = New System.Drawing.Size(75, 23)
        Me.butSearch.TabIndex = 1
        Me.butSearch.Text = "Search Data"
        Me.butSearch.UseVisualStyleBackColor = True
        Me.butSearch.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(201, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(222, 42)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "High Scores"
        '
        'butStart
        '
        Me.butStart.Location = New System.Drawing.Point(269, 236)
        Me.butStart.Name = "butStart"
        Me.butStart.Size = New System.Drawing.Size(75, 23)
        Me.butStart.TabIndex = 3
        Me.butStart.Text = "Start"
        Me.butStart.UseVisualStyleBackColor = True
        '
        'butQuit
        '
        Me.butQuit.Location = New System.Drawing.Point(525, 395)
        Me.butQuit.Name = "butQuit"
        Me.butQuit.Size = New System.Drawing.Size(75, 23)
        Me.butQuit.TabIndex = 4
        Me.butQuit.Text = "Quit"
        Me.butQuit.UseVisualStyleBackColor = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(662, 442)
        Me.Controls.Add(Me.butQuit)
        Me.Controls.Add(Me.butStart)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.butSearch)
        Me.Controls.Add(Me.butMergeSort)
        Me.Name = "Form2"
        Me.Text = "Form2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents butMergeSort As Button
    Friend WithEvents butSearch As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents butStart As Button
    Friend WithEvents butQuit As Button
End Class
