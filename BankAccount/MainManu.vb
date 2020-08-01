Imports System.Data.SqlClient
Imports System.Globalization

Public Class MainManu
    Dim connection As New SqlConnection()
    Dim sql As String
    Private Sub ออกโปรแกรมToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ออกโปรแกรมToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ฝากเงนToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ฝากเงนToolStripMenuItem.Click
        Dim dp As New Deposit()
        dp.MdiParent = Me
        dp.Show()
    End Sub

    Private Sub ถอนเงนToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ถอนเงนToolStripMenuItem.Click
        Dim wd As New Withdraw()
        wd.MdiParent = Me
        wd.Show()
    End Sub

    Private Sub เปดบญชToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles เปดบญชToolStripMenuItem.Click
        Dim op As New OpenAccount()
        op.MdiParent = Me
        op.Show()
    End Sub

    Private Sub สมครสมาชกToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles สมครสมาชกToolStripMenuItem.Click
        Dim rg As New RegisMember()
        rg.MdiParent = Me
        rg.Show()
    End Sub

    Private Sub ขอมลสามชกToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ขอมลสามชกToolStripMenuItem.Click
        Dim sm As New ShowMember()
        sm.MdiParent = Me
        sm.Show()
    End Sub
    Private Sub ชอธนาคารToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ชอธนาคารToolStripMenuItem.Click
        Dim st As New Setting()
        st.MdiParent = Me
        st.Show()
    End Sub

    Private Sub MainManu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Timer1.Stop()
        Application.Exit()
    End Sub

    Private Sub MainManu_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F3 Then
            Dim dp As New Deposit()
            dp.MdiParent = Me
            dp.Show()
        End If
        If e.KeyCode = Keys.F4 Then
            Dim wd As New Withdraw()
            wd.MdiParent = Me
            wd.Show()
        End If
        If e.KeyCode = Keys.F5 Then
            Dim op As New OpenAccount()
            op.MdiParent = Me
            op.Show()
        End If
        If e.KeyCode = Keys.F6 Then
            Dim rg As New RegisMember()
            rg.MdiParent = Me
            rg.Show()
        End If
        If e.KeyCode = Keys.F7 Then
            Dim st As New Setting()
            st.MdiParent = Me
            st.Show()
        End If
        If e.KeyCode = Keys.F8 Then
            Dim Fs As New FixTransession()
            Fs.MdiParent = Me
            Fs.Show()
        End If
        If e.KeyCode = Keys.F9 Then
            Dim sm As New ShowMember()
            sm.MdiParent = Me
            sm.Show()
        End If
    End Sub

    Private Sub รายงานการทำรายการฝากเงนToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles รายงานการทำรายการฝากเงนToolStripMenuItem.Click
        Dim rptDp As New rptDeposit()
        rptDp.MdiParent = Me
        rptDp.Show()
    End Sub

    Private Sub รายงานการทำรายการถอนเงนToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles รายงานการทำรายการถอนเงนToolStripMenuItem.Click
        Dim rptWd As New rptWithdraw()
        rptWd.MdiParent = Me
        rptWd.Show()
    End Sub

    Private Sub รายงานการเปดบญชToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles รายงานการเปดบญชToolStripMenuItem.Click
        Dim rptOa As New rptOpenAccount()
        rptOa.MdiParent = Me
        rptOa.Show()
    End Sub

    Private Sub รายงานขอมลสมาชกทงหมดToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles รายงานขอมลสมาชกทงหมดToolStripMenuItem.Click
        Dim rptSm As New rptShowMember()
        rptSm.MdiParent = Me
        rptSm.Show()
    End Sub

    Private Sub รายการธรกรรมผดพลาดToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles รายการธรกรรมผดพลาดToolStripMenuItem.Click
        Dim Fs As New FixTransession()
        Fs.MdiParent = Me
        Fs.Show()
    End Sub

    Private Sub MainManu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connection.ConnectionString = GetConnection.Connection

        Timer1.Start()
    End Sub

    Dim Account_balance As Double
    Dim dt As New DataTable()


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'ตัวแปรใช้งาน
        Dim i As Integer
        'เลือกวันที่จากตารางเปิดบัญชีมาดูว่าควร เพิ่มกำไรให้ไหม
        sql = "select * from Account"
        connection.Open()
        Try
            Dim da_All As New SqlDataAdapter(sql, connection)
            da_All.Fill(dt)
            If dt.Rows.Count > 0 Then
                Account_balance = Double.Parse(dt.Rows(0)("Account_balance"))
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
        connection.Close()


        For i = 0 To dt.Rows.Count - 1

            'เช็คประเภทบัญชี เพื่ออัพเดพให้ตรง
            'ออมทรัพย์
            If dt.Rows(i)("Account_type").ToString = "ออมทรัพย์" Then
                If dt.Rows(i)("Account_date_profit") = Date.Now.ToString("yyyy-MM-dd") Then
                    Account_balance = (Double.Parse(dt.Rows(i)("Account_balance")) * 0.5) / 100 + Double.Parse(dt.Rows(i)("Account_balance"))
                    sql = "update Account set Account_balance = '" & Account_balance & "', Account_date_profit = '" & DateAdd("yyyy", 1, Now.Date) & "' where Account_id = '" & Integer.Parse(dt.Rows(i)("Account_id")) & "'"
                    Dim cmd As New SqlCommand(sql, connection)
                    connection.Open()
                    Try
                        cmd.ExecuteNonQuery()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message + vbNewLine + "ออมทรัพย์อัพเดต")
                    End Try
                    connection.Close()
                    'เพิ่มลงรายการ Tran
                    Account_balance = (Double.Parse(dt.Rows(i)("Account_balance")) * 0.5) / 100
                    sql = "insert into Transcription values(@Account_id,@Tran_date,@Tran_type,@Tran_amount,@Tran_Text)"
                    Dim cmd_update As New SqlCommand(sql, connection)
                    cmd_update.Parameters.AddWithValue("@Account_id", Integer.Parse(dt.Rows(i)("Account_id")))
                    cmd_update.Parameters.AddWithValue("@Tran_date", Now())
                    cmd_update.Parameters.AddWithValue("@Tran_type", "ฝาก")
                    cmd_update.Parameters.AddWithValue("@Tran_amount", Account_balance)
                    cmd_update.Parameters.AddWithValue("@Tran_Text", "ดอกเบี้ย")
                    connection.Open()
                    Try
                        cmd_update.ExecuteNonQuery()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message + vbNewLine + "ออมทรัพย์เพิ่ม")
                    End Try
                    connection.Close()
                    Account_balance = 0

                End If
                Continue For
            End If
            'ออมทรัพย์พิเศษ
            If dt.Rows(i)("Account_type").ToString = "ออมทรัพย์พิเศษ" Then
                If dt.Rows(i)("Account_date_profit") = Date.Now.ToString("yyyy-MM-dd") Then
                    Account_balance = (Double.Parse(dt.Rows(i)("Account_balance")) * 1.5) / 100 + Double.Parse(dt.Rows(i)("Account_balance"))
                    sql = "update Account set Account_balance = '" & Account_balance & "', Account_date_profit = '" & DateAdd("M", 5, Now.Date) & "' where Account_id = '" & Integer.Parse(dt.Rows(i)("Account_id")) & "'"
                    Dim cmd As New SqlCommand(sql, connection)
                    connection.Open()
                    Try
                        cmd.ExecuteNonQuery()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message + vbNewLine + "ออมทรัพย์พิเศษอัพเดต")
                    End Try
                    connection.Close()
                    'เพิ่มลงรายการ Tran
                    Account_balance = (Double.Parse(dt.Rows(i)("Account_balance")) * 1.5) / 100
                    sql = "insert into Transcription values(@Account_id,@Tran_date,@Tran_type,@Tran_amount,@Tran_Text)"
                    Dim cmd_update As New SqlCommand(sql, connection)
                    cmd_update.Parameters.AddWithValue("@Account_id", Integer.Parse(dt.Rows(i)("Account_id")))
                    cmd_update.Parameters.AddWithValue("@Tran_date", Now())
                    cmd_update.Parameters.AddWithValue("@Tran_type", "ฝาก")
                    cmd_update.Parameters.AddWithValue("@Tran_amount", Account_balance)
                    cmd_update.Parameters.AddWithValue("@Tran_Text", "ดอกเบี้ย")
                    connection.Open()
                    Try
                        cmd_update.ExecuteNonQuery()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message + vbNewLine + "ออมทรัพย์พิเศษเพิ่ม")
                    End Try
                    connection.Close()
                    Account_balance = 0
                End If
                Continue For
            End If
            'ฝากประจำ
            If dt.Rows(i)("Account_type").ToString = "ฝากประจำ" Then
                If dt.Rows(i)("Account_date_profit") = Date.Now.ToString("yyyy-MM-dd") Then
                    Account_balance = (Double.Parse(dt.Rows(i)("Account_balance")) * 3.5) / 100 + Double.Parse(dt.Rows(i)("Account_balance"))
                    sql = "update Account set Account_balance = '" & Account_balance & "', Account_date_profit = '" & DateAdd("M", 3, Now.Date) & "' where Account_id = '" & Integer.Parse(dt.Rows(i)("Account_id")) & "'"
                    Dim cmd As New SqlCommand(sql, connection)
                    connection.Open()
                    Try
                        cmd.ExecuteNonQuery()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message + vbNewLine + "ฝากประจำอัพเดต")
                    End Try
                    connection.Close()
                    'เพิ่มลงรายการ Tran
                    Account_balance = (Double.Parse(dt.Rows(i)("Account_balance")) * 3.5) / 100
                    sql = "insert into Transcription values(@Account_id,@Tran_date,@Tran_type,@Tran_amount,@Tran_Text)"
                    Dim cmd_update As New SqlCommand(sql, connection)
                    cmd_update.Parameters.AddWithValue("@Account_id", Integer.Parse(dt.Rows(i)("Account_id")))
                    cmd_update.Parameters.AddWithValue("@Tran_date", Now())
                    cmd_update.Parameters.AddWithValue("@Tran_type", "ฝาก")
                    cmd_update.Parameters.AddWithValue("@Tran_amount", Account_balance)
                    cmd_update.Parameters.AddWithValue("@Tran_Text", "ดอกเบี้ย")
                    connection.Open()
                    Try
                        cmd_update.ExecuteNonQuery()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message + vbNewLine + "ฝากประจำเพิ่ม")
                    End Try
                    connection.Close()
                    Account_balance = 0
                End If
                Continue For
            End If
        Next
        dt.Clear()
    End Sub
End Class