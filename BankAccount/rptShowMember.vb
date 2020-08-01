Public Class rptShowMember
    Private Sub rptShowMember_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'BankAccountDataSet.Member' table. You can move, or remove it, as needed.
        Me.MemberTableAdapter.Fill(Me.BankAccountDataSet.Member)
        'TODO: This line of code loads data into the 'BankAccountDataSet.QrMember' table. You can move, or remove it, as needed.
        Me.ReportViewer1.RefreshReport()
        cbSelect.SelectedIndex = 0
        txtSearch.Select()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If cbSelect.Text = "รหัสสมาชิก" Then
            Me.MemberBindingSource.Filter = "Member_id like '%" & txtSearch.Text & "%'"
            Me.ReportViewer1.RefreshReport()
        ElseIf cbSelect.Text = "เลขที่บัตรประจำตัวประชาชน" Then
            Me.MemberBindingSource.Filter = "Member_cardid like '%" & txtSearch.Text & "%'"
            Me.ReportViewer1.RefreshReport()
        ElseIf cbSelect.Text = "ชื่อ" Then
            Me.MemberBindingSource.Filter = "Member_firstname like '%" & txtSearch.Text & "%'"
            Me.ReportViewer1.RefreshReport()
        ElseIf cbSelect.Text = "เพศ" Then
            Me.MemberBindingSource.Filter = "Member_sex like '%" & txtSearch.Text & "%'"
            Me.ReportViewer1.RefreshReport()
        ElseIf cbSelect.Text = "จังหวัด" Then
            Me.MemberBindingSource.Filter = "Member_addrpro like '%" & txtSearch.Text & "%'"
            Me.ReportViewer1.RefreshReport()
        ElseIf cbSelect.Text = "อำเภอ" Then
            Me.MemberBindingSource.Filter = "Member_addrcity like '%" & txtSearch.Text & "%'"
            Me.ReportViewer1.RefreshReport()
        ElseIf cbSelect.Text = "ตำบล" Then
            Me.MemberBindingSource.Filter = "Member_addrdist like '%" & txtSearch.Text & "%'"
            Me.ReportViewer1.RefreshReport()
        ElseIf cbSelect.Text = "รหัสไปรษณีย์" Then
            Me.MemberBindingSource.Filter = "Member_postcode like '%" & txtSearch.Text & "%'"
            Me.ReportViewer1.RefreshReport()
        ElseIf cbSelect.Text = "อาชีพ" Then
            Me.MemberBindingSource.Filter = "Member_career like '%" & txtSearch.Text & "%'"
            Me.ReportViewer1.RefreshReport()
        Else
            MessageBox.Show("กรุณาเลือกการค้นหา !")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtSearch.Clear()
        txtSearch.Select()
        cbSelect.SelectedIndex = 0
        Me.MemberBindingSource.Filter = "Member_firstname like '%" & txtSearch.Text & "%'"
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class