<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Advertising
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
        Me.pcShow = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.laShow = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.pcShow, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pcShow
        '
        Me.pcShow.Image = Global.BankAccount.My.Resources.Resources._0
        Me.pcShow.Location = New System.Drawing.Point(-1, -1)
        Me.pcShow.Name = "pcShow"
        Me.pcShow.Size = New System.Drawing.Size(555, 314)
        Me.pcShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcShow.TabIndex = 0
        Me.pcShow.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'laShow
        '
        Me.laShow.AutoSize = True
        Me.laShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.laShow.Location = New System.Drawing.Point(12, 318)
        Me.laShow.Name = "laShow"
        Me.laShow.Size = New System.Drawing.Size(57, 20)
        Me.laShow.TabIndex = 1
        Me.laShow.Text = "Label1"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Button1.Location = New System.Drawing.Point(400, 313)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(154, 30)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "เข้าใช้งาน"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 5000
        '
        'Advertising
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(553, 343)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.laShow)
        Me.Controls.Add(Me.pcShow)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximumSize = New System.Drawing.Size(553, 343)
        Me.MinimumSize = New System.Drawing.Size(553, 343)
        Me.Name = "Advertising"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Advertising"
        CType(Me.pcShow, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pcShow As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents laShow As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Timer2 As Timer
End Class
