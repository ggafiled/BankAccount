Imports System.Data.SqlClient
Public Class Setting

    Dim connection As New SqlConnection()
    Dim sql As String
    Dim name As String
    Dim address As String
    Private Sub Setting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connection.ConnectionString = GetConnection.Connection()
        showdata()
        btnSave.Select()
    End Sub

    Friend Sub showdata()
        connection.Open()
        sql = "select * from Bank"
        Dim da As New SqlDataAdapter(sql, connection)
        Dim dt As New DataTable()
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            txtBank_name.Text = dt.Rows(0)("Bank_name")
            name = txtBank_address.Text
            txtBank_address.Text = dt.Rows(0)("Bank_address")
            address = txtBank_address.Text
        End If
        connection.Close()
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtBank_name.Text = name
        txtBank_address.Text = address
        txtBank_name.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(txtBank_address.Text) <> "" And Trim(txtBank_address.Text) <> "" Then
            sql = "update Bank set Bank_name = '" & txtBank_name.Text & "',Bank_address = '" & txtBank_address.Text & "' where Bank_id = 59086"
            Dim cmd As New SqlCommand(sql, connection)
            connection.Open()
            Try
                cmd.ExecuteNonQuery()
                MessageBox.Show("แก้ไขข้อมูลเรียบร้อยแล้ว")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            connection.Close()
        Else
            MessageBox.Show("กรุณาป้อนชื่อธนาคาร และที่ตั้งให้สมบูรณ์ !")
        End If
    End Sub
End Class