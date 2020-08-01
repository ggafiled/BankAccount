Public Class rptDeposit
    Private Sub rptDeposit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.QrDepositTableAdapter.Fill(Me.BankAccountDataSet.QrDeposit)
            Me.ReportViewer1.RefreshReport()
            txtCode.Select()
            DateTimePicker1.CustomFormat = "MM/d/yyyy hh:mm:ss tt"
        Catch ex As Exception
            MessageBox.Show("ติดต่อฐานข้อมูลไม่ได้ !")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Me.QrDepositBindingSource.Filter = "Account_id  = '" & Integer.Parse(txtCode.Text) & "' And Tran_date = '#" & DateTime.Parse(DateTimePicker1.Text) & "#'"
            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtCode.Clear()
        Me.QrDepositBindingSource.Filter = "Tran_type  like '%" & txtCode.Text & "%'"
        Me.ReportViewer1.RefreshReport()
        txtCode.Select()
        DateTimePicker1.CustomFormat = "MM/d/yyyy hh:mm:ss tt"
    End Sub
End Class
