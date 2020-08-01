Public Class rptOpenAccount
    Private Sub rptOpenAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbSelect.SelectedIndex = 0
        txtSearch.Select()
        Try
            'TODO: This line of code loads data into the 'BankAccountDataSet.QrDeposit' table. You can move, or remove it, as needed.
            'TODO: This line of code loads data into the 'BankAccountDataSet.QrAccount' table. You can move, or remove it, as needed.
            Me.QrAccountTableAdapter.Fill(Me.BankAccountDataSet.QrAccount)
            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            MessageBox.Show("ติดต่อฐานข้อมูลไม่ได้ !")
        End Try


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If cbSelect.Text = "ชื่อ" Then
            Me.QrAccountBindingSource.Filter = "Member_firstname like '%" & txtSearch.Text & "%'"
            Me.ReportViewer1.RefreshReport()
        ElseIf cbSelect.Text = "เพศ" Then
            Me.QrAccountBindingSource.Filter = "Member_sex like '%" & txtSearch.Text & "%'"
            Me.ReportViewer1.RefreshReport()
        ElseIf cbSelect.Text = "จังหวัด" Then
            Me.QrAccountBindingSource.Filter = "Member_addrcity like '%" & txtSearch.Text & "%'"
            Me.ReportViewer1.RefreshReport()
        ElseIf cbSelect.Text = "ประเภทบัญชี" Then
            Me.QrAccountBindingSource.Filter = "Account_type like '%" & txtSearch.Text & "%'"
            Me.ReportViewer1.RefreshReport()
        ElseIf cbSelect.Text = "อาชีพ" Then
            Me.QrAccountBindingSource.Filter = "Member_career like '%" & txtSearch.Text & "%'"
            Me.ReportViewer1.RefreshReport()
        ElseIf cbSelect.Text = "สาขา" Then
            Me.QrAccountBindingSource.Filter = "Bank_name like '%" & txtSearch.Text & "%'"
            Me.ReportViewer1.RefreshReport()
        Else
            MessageBox.Show("กรุณาเลือกการค้นหา !")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtSearch.Clear()
        txtSearch.Select()
        cbSelect.SelectedIndex = 0
        Me.QrAccountBindingSource.Filter = "Member_firstname like '%" & txtSearch.Text & "%'"
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class