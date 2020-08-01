<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptOpenAccount
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.QrDepositBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BankAccountDataSet = New BankAccount.BankAccountDataSet()
        Me.QrAccountBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.QrDepositTableAdapter = New BankAccount.BankAccountDataSetTableAdapters.QrDepositTableAdapter()
        Me.QrAccountTableAdapter = New BankAccount.BankAccountDataSetTableAdapters.QrAccountTableAdapter()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbSelect = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.QrDepositBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BankAccountDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QrAccountBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'QrDepositBindingSource
        '
        Me.QrDepositBindingSource.DataMember = "QrDeposit"
        Me.QrDepositBindingSource.DataSource = Me.BankAccountDataSet
        '
        'BankAccountDataSet
        '
        Me.BankAccountDataSet.DataSetName = "BankAccountDataSet"
        Me.BankAccountDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'QrAccountBindingSource
        '
        Me.QrAccountBindingSource.DataMember = "QrAccount"
        Me.QrAccountBindingSource.DataSource = Me.BankAccountDataSet
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.QrDepositBindingSource
        ReportDataSource2.Name = "DataSet2"
        ReportDataSource2.Value = Me.QrAccountBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "BankAccount.rptOpenAccount.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(-1, 50)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1219, 521)
        Me.ReportViewer1.TabIndex = 1
        '
        'QrDepositTableAdapter
        '
        Me.QrDepositTableAdapter.ClearBeforeFill = True
        '
        'QrAccountTableAdapter
        '
        Me.QrAccountTableAdapter.ClearBeforeFill = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "เลือกรูปแบบการค้นหา :"
        '
        'cbSelect
        '
        Me.cbSelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cbSelect.FormattingEnabled = True
        Me.cbSelect.Items.AddRange(New Object() {"ชื่อ", "เพศ", "อำเภอ", "ประเภทบัญชี", "อาชีพ", "สาขา"})
        Me.cbSelect.Location = New System.Drawing.Point(167, 10)
        Me.cbSelect.Name = "cbSelect"
        Me.cbSelect.Size = New System.Drawing.Size(214, 28)
        Me.cbSelect.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(670, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(121, 36)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Report"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(388, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "คำค้นหา :"
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(461, 10)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(202, 29)
        Me.txtSearch.TabIndex = 6
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(797, 6)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(121, 36)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Clear"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'rptOpenAccount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1218, 570)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cbSelect)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ReportViewer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximumSize = New System.Drawing.Size(1234, 609)
        Me.MinimumSize = New System.Drawing.Size(1234, 609)
        Me.Name = "rptOpenAccount"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "รายงานข้อมูลการเปิดบัญชี"
        CType(Me.QrDepositBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BankAccountDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QrAccountBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents QrDepositBindingSource As BindingSource
    Friend WithEvents BankAccountDataSet As BankAccountDataSet
    Friend WithEvents QrAccountBindingSource As BindingSource
    Friend WithEvents QrDepositTableAdapter As BankAccountDataSetTableAdapters.QrDepositTableAdapter
    Friend WithEvents QrAccountTableAdapter As BankAccountDataSetTableAdapters.QrAccountTableAdapter
    Friend WithEvents Label1 As Label
    Friend WithEvents cbSelect As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Button2 As Button
End Class
