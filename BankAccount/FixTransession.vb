Imports System.Configuration
Imports System.Data.SqlClient
Public Class FixTransession

    Dim connection As New SqlConnection()
    Dim sql As String
    Dim TempId As Integer
    Dim TempAccount As Integer
    Dim TempAmount As Double


    Private Sub FixTransession_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connection.ConnectionString = GetConnection.Connection()
        Showdata("")
        txtSearch.Select()
    End Sub

    Friend Sub Showdata(value As String)
        connection.Open()
        Try
            sql = "select * from Transcription where Account_id like '%" & value & "%'"
            Dim cmd As New SqlCommand(sql, connection)
            Dim data = cmd.ExecuteReader()

            Me.listview.Clear()
            Me.listview.Columns.Clear()
            Me.listview.Columns.Add("หมายเลขใบเสร็จ", 100, HorizontalAlignment.Center)
            Me.listview.Columns.Add("หมายเลขบัญชี", 100, HorizontalAlignment.Center)
            Me.listview.Columns.Add("วันที่ทำรายการ", 120, HorizontalAlignment.Left)
            Me.listview.Columns.Add("ประเภท", 50, HorizontalAlignment.Right)
            Me.listview.Columns.Add("ยอดทำรายการ", 150, HorizontalAlignment.Right)
            listview.View = View.Details

            While data.Read()
                Dim temp As New ListViewItem(data("Tran_id").ToString())
                temp.SubItems.Add(data("Account_id").ToString())
                temp.SubItems.Add(data("Tran_date").ToString())
                temp.SubItems.Add(data("Tran_type").ToString())
                temp.SubItems.Add(data("Tran_amount").ToString())
                Me.listview.Items.Add(temp)
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        connection.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TempId <> 0 And TempAccount <> 0 Then
            If Trim(TextBox1.Text) = "//" Then
                If MessageBox.Show("ยกเลิกรายการนี้ใช่ไหม !", "แจ้งเตือน", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    Dim cmd0 As SqlCommand
                    connection.Open()
                    Try
                        If listview.SelectedItems(0).SubItems(3).Text = "ถอน" Then
                            sql = "insert into Transcription values(@Account_id,@Tran_date,@Tran_type,@Tran_amount,@Tran_Text)"
                            Dim cmd1 As SqlCommand
                            cmd1 = New SqlCommand(sql, connection)
                            cmd1.Parameters.AddWithValue("@Account_id", TempAccount)
                            cmd1.Parameters.AddWithValue("@Tran_date", Date.Now.ToString("MM/d/yyyy hh:mm:ss tt"))
                            cmd1.Parameters.AddWithValue("@Tran_type", "ฝาก")
                            cmd1.Parameters.AddWithValue("@Tran_amount", TempAmount)
                            cmd1.Parameters.AddWithValue("@Tran_Text", "ยกเลิก")
                            cmd1.ExecuteNonQuery()
                            sql = "update Account set Account_balance = Account_balance  + '" & TempAmount & "' where Account_id = '" & TempAccount & "'"

                        ElseIf listview.SelectedItems(0).SubItems(3).Text = "ฝาก" Then
                            sql = "insert into Transcription values(@Account_id,@Tran_date,@Tran_type,@Tran_amount,@Tran_Text)"
                            Dim cmd2 As SqlCommand
                            cmd2 = New SqlCommand(sql, connection)
                            cmd2.Parameters.AddWithValue("@Account_id", TempAccount)
                            cmd2.Parameters.AddWithValue("@Tran_date", Date.Now.ToString("MM/d/yyyy hh:mm:ss tt"))
                            cmd2.Parameters.AddWithValue("@Tran_type", "ถอน")
                            cmd2.Parameters.AddWithValue("@Tran_amount", TempAmount)
                            cmd2.Parameters.AddWithValue("@Tran_Text", "ยกเลิก")
                            cmd2.ExecuteNonQuery()
                            sql = "update Account set Account_balance = Account_balance - '" & TempAmount & "' where Account_id = '" & TempAccount & "'"
                        End If
                        cmd0 = New SqlCommand(sql, connection)
                        cmd0.ExecuteNonQuery()
                        MessageBox.Show("ยกเลิกรายการแล้ว !")
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                    connection.Close()
                    Showdata("")
                    TextBox1.Clear()
                    txtSearch.Clear()
                    TextBox1.Focus()
                    Exit Sub
                End If
            End If
        Else
            MessageBox.Show("กรุณาเลือกรายการที่ต้องการแก้ไข !")
        End If
    End Sub

    Private Sub listview_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listview.SelectedIndexChanged
        If listview.SelectedItems.Count > 0 Then
            TempId = CInt(listview.SelectedItems(0).Text)
            TempAccount = CInt(listview.SelectedItems(0).SubItems(1).Text)
            TempAmount = Val(listview.SelectedItems(0).SubItems(4).Text)
        Else
            TempId = 0
            TempAccount = 0
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Showdata(txtSearch.Text)
    End Sub
End Class