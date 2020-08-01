Imports System.Data.SqlClient
Public Class Withdraw

    Dim connection As New SqlConnection()
    Dim sql As String
    Private Sub Withdraw_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connection.ConnectionString = GetConnection.Connection()
        lbShow.Text = ""
        txtAccount_id.Focus()
    End Sub
    Private Sub txtAccount_id_TextChanged(sender As Object, e As EventArgs) Handles txtAccount_id.TextChanged
        connection.Open()
        Try
            sql = "select Account.*,Member_firstname,Member_lastname from Account,Member where Account_id = '" & txtAccount_id.Text & "' and Account.Member_id = Member.Member_id "
            Dim da As New SqlDataAdapter(sql, connection)
            Dim dt As New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                txtAccount_name.Text = dt.Rows(0)("Member_firstname") + " " + dt.Rows(0)("Member_lastname")
                txtAccount_type.Text = dt.Rows(0)("Account_type")
                txtAccount_balance.Text = dt.Rows(0)("Account_balance")
            Else
                txtAccount_name.Text = ""
                txtAccount_type.Text = ""
                txtAccount_balance.Text = ""
                txtAmount.Text = ""
                lbShow.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        connection.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        txtDate.Text = Now()
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(txtAccount_id.Text) <> "" Then
            sql = "insert into Transcription values(@Account_id,@Tran_date,@Tran_type,@Tran_amount,@Tran_Text)"
            Dim cmd As New SqlCommand(sql, connection)
            cmd.Parameters.AddWithValue("@Account_id", txtAccount_id.Text)
            cmd.Parameters.AddWithValue("@Tran_date", Date.Now.ToString("MM/d/yyyy hh:mm:ss tt"))
            cmd.Parameters.AddWithValue("@Tran_type", "ถอน")
            cmd.Parameters.AddWithValue("@Tran_amount", txtAmount.Text)
            cmd.Parameters.AddWithValue("@Tran_Text", "Wtd")
            connection.Open()
            Try
                If Val(txtAmount.Text) <= Val(txtAccount_balance.Text) Then
                    cmd.ExecuteNonQuery()
                    sql = "update Account set Account_balance = Account_balance - '" & Val(txtAmount.Text) & "' where Account_id = '" & txtAccount_id.Text & "'"
                    cmd = New SqlCommand(sql, connection)
                    cmd.ExecuteNonQuery()
                    lbShow.Text = Val(txtAccount_balance.Text) - Val(txtAmount.Text)
                    MessageBox.Show("ทำรายการเสร็จสิ้นแล้ว", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("ยอดเงินคงเหลือไม่เพียงพอ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            connection.Close()
            clear()
        Else
            MessageBox.Show("กรุณาเลือกหมายเลขบัญชี ที่จะทำรายการ !")
            clear()
        End If
    End Sub
    Friend Sub clear()
        txtAccount_id.Text = ""
        txtAccount_name.Text = ""
        txtAccount_type.Text = ""
        txtAccount_balance.Text = ""
        txtAmount.Text = ""
        lbShow.Text = ""
        txtAccount_id.Focus()
    End Sub

    Private Sub Withdraw_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Timer1.Stop()
    End Sub
End Class