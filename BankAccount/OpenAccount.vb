Imports System.Data.SqlClient
Public Class OpenAccount

    Dim connection As New SqlConnection()
    Dim cmd As SqlCommand
    Dim sql As String
    Dim Profit As String
    Dim dateProfit As Date

    Private Sub OpenAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connection.ConnectionString = GetConnection.Connection()
        cbBank()
        cbType.SelectedIndex = 0
        txtMember_id.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(txtMember_id.Text) <> "" And Trim(cbType.Text) <> "" And Trim(cbSub.Text) <> "" And Val(txtBalance.Text) >= 100 Then
            Profit = cbType.Text
            If Profit = "ออมทรัพย์" Then
                dateProfit = Date.Now.AddYears(1)
            ElseIf Profit = "ออมทรัพย์พิเศษ" Then
                dateProfit = Date.Now.AddMonths(5)
            ElseIf Profit = "ฝากประจำ" Then
                dateProfit = Date.Now.AddMonths(3)
            End If
            sql = "insert into Account values(@Account_date,@Account_date_profit,@Account_type,@Account_note,@Bank_id,@Account_balance,@Member_id)"
                cmd = New SqlCommand(sql, connection)
                cmd.Parameters.AddWithValue("@Account_date", txtDate.Text)
            cmd.Parameters.AddWithValue("@Account_date_profit", dateProfit)
            cmd.Parameters.AddWithValue("@Account_type", cbType.Text)
                cmd.Parameters.AddWithValue("@Account_note", txtIssue.Text)
                cmd.Parameters.AddWithValue("@Bank_id", cbSub.SelectedValue)
                cmd.Parameters.AddWithValue("@Account_balance", txtBalance.Text)
                cmd.Parameters.AddWithValue("@Member_id", txtMember_id.Text)
                connection.Open()
                Try
                    cmd.ExecuteNonQuery()
                    ' sql = "select * from Account where Member_id = '" & txtMember_id.Text & "'"
                    'sql = "Select * from Account  where Member_id = '" & txtMember_id.Text & "' and Account_date in (Select top 1 Max(Account_date) From Account)"
                    sql = "Select * from Account  where Member_id = '" & txtMember_id.Text & "' order by[Account_date] desc"
                    Dim da As New SqlDataAdapter(sql, connection)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        MessageBox.Show("เปิดบัญชีเรียบร้อยแล้ว หมายเลขบัญชีคือ '" & dt.Rows(0)("Account_id") & "'")
                    Else
                        MessageBox.Show("มีข้อผิดพลาดบางอย่าง")
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
                connection.Close()
                clear()
            Else
                MessageBox.Show("กรุณาแก้ไขข้อมูลให้ถูกต้อง !")
        End If
    End Sub

    Friend Sub cbBank()
        connection.Open()
        sql = "select * from Bank"
        Dim da As New SqlDataAdapter(sql, connection)
        Dim ds As New DataSet()
        da.Fill(ds)
        cbSub.DataSource = ds.Tables(0)
        cbSub.DisplayMember = "Bank_name"
        cbSub.ValueMember = "Bank_id"
        cbSub.SelectedIndex = 0
        connection.Close()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Friend Sub clear()
        txtMember_id.Text = ""
        txtMember_name.Text = ""
        txtMember_card.Text = ""
        txtIssue.Text = ""
        cbSub.SelectedIndex = 0
        cbType.SelectedIndex = 0
        txtBalance.Text = ""
        txtMember_id.Focus()
    End Sub

    Private Sub txtMember_id_TextChanged(sender As Object, e As EventArgs) Handles txtMember_id.TextChanged
        connection.Open()
        Try
            sql = "select * from Member where Member_id = '" & txtMember_id.Text & "'"
            Dim da As New SqlDataAdapter(sql, connection)
            Dim dt As New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                txtMember_card.Text = dt.Rows(0)("Member_cardid")
                txtMember_name.Text = dt.Rows(0)("Member_firstname") + " " + dt.Rows(0)("Member_lastname")
            Else
                txtMember_name.Text = ""
                txtMember_card.Text = ""
                txtIssue.Text = ""
                cbSub.SelectedIndex = 0
                cbType.SelectedIndex = 0
                txtBalance.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        connection.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        txtDate.Text = Now.Date()
    End Sub

    Private Sub OpenAccount_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Timer1.Stop()
    End Sub
End Class
