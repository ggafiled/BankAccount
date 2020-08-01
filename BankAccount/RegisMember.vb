Imports System.Data.SqlClient
Public Class RegisMember

    Dim connection As New SqlConnection()
    Dim sql As String

    Private Sub RegisMember_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connection.ConnectionString = GetConnection.Connection()
        txtMember_id.Select()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Friend Sub clear()
        txtMember_id.Text = ""
        txtMember_card.Text = ""
        cbGender.SelectedIndex = 0
        txtEmail.Text = ""
        txtName.Text = ""
        txtSurname.Text = ""
        txtDate.Value = Now()
        txtPhone.Text = ""
        cbCareer.SelectedIndex = 0
        cbLavel.SelectedIndex = 0
        txtNo.Text = ""
        txtPro.Text = ""
        txtCity.Text = ""
        txtDes.Text = ""
        txtPost.Text = ""
        txtMember_id.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(txtMember_id.Text) <> "" And Trim(txtMember_card.Text) <> "" And Trim(cbGender.Text) <> "" And Trim(txtEmail.Text) <> "" And Trim(txtName.Text) <> "" And Trim(txtSurname.Text) <> "" And Trim(txtPhone.Text) <> "" And Trim(cbCareer.Text) <> "" And Trim(cbLavel.Text) <> "" And Trim(txtNo.Text) <> "" And Trim(txtPro.Text) <> "" And Trim(txtCity.Text) <> "" And Trim(txtDes.Text) <> "" And Trim(txtPost.Text) <> "" Then
            sql = "insert into Member values(@Member_id,@Member_cardid,@Member_email,@Member_firstname"
            sql &= ",@Member_lastname,@Member_sex,@Member_birthday,@Member_phone,@Member_addrno,@Member_addrpro"
            sql &= ",@Member_addrcity,@Member_addrdist,@Member_postcode,@Member_career,@Member_level,@Bank_id)"
            Dim cmd As New SqlCommand(sql, connection)
            cmd.Parameters.AddWithValue("@Member_id", txtMember_id.Text)
            cmd.Parameters.AddWithValue("@Member_cardid", txtMember_card.Text)
            cmd.Parameters.AddWithValue("@Member_email", txtEmail.Text)
            cmd.Parameters.AddWithValue("@Member_firstname", txtName.Text)
            cmd.Parameters.AddWithValue("@Member_lastname", txtSurname.Text)
            cmd.Parameters.AddWithValue("@Member_sex", cbGender.Text)
            cmd.Parameters.AddWithValue("@Member_birthday", txtDate.Value)
            cmd.Parameters.AddWithValue("@Member_phone", txtPhone.Text)
            cmd.Parameters.AddWithValue("@Member_addrno", txtNo.Text)
            cmd.Parameters.AddWithValue("@Member_addrpro", txtPro.Text)
            cmd.Parameters.AddWithValue("@Member_addrcity", txtCity.Text)
            cmd.Parameters.AddWithValue("@Member_addrdist", txtDes.Text)
            cmd.Parameters.AddWithValue("@Member_postcode", txtPost.Text)
            cmd.Parameters.AddWithValue("@Member_career", cbCareer.Text)
            cmd.Parameters.AddWithValue("@Member_level", cbLavel.Text)
            cmd.Parameters.AddWithValue("@Bank_id", "59086")
            connection.Open()
            Try
                cmd.ExecuteNonQuery()
                MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            connection.Close()
            clear()
        Else
            MessageBox.Show("กุณษกรอกข้อมูลให้ครบถูกช่อง !")
        End If
    End Sub
End Class