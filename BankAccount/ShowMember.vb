Imports System.Data.SqlClient
Public Class ShowMember

    Dim connection As New SqlConnection()
    Dim sql As String
    Dim status As Boolean = True
    Private Sub ShowMember_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connection.ConnectionString = GetConnection.Connection()
        txtMember_id.Select()
        btnUpdate.Enabled = False
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
                cbGender.Text = dt.Rows(0)("Member_sex")
                txtEmail.Text = dt.Rows(0)("Member_email")
                txtName.Text = dt.Rows(0)("Member_firstname")
                txtSurname.Text = dt.Rows(0)("Member_lastname")
                txtDate.Value = dt.Rows(0)("Member_birthday")
                txtPhone.Text = dt.Rows(0)("Member_phone")
                cbCareer.Text = dt.Rows(0)("Member_career")
                cbLavel.Text = dt.Rows(0)("Member_level")
                txtNo.Text = dt.Rows(0)("Member_addrno")
                txtPro.Text = dt.Rows(0)("Member_addrpro")
                txtCity.Text = dt.Rows(0)("Member_addrcity")
                txtDes.Text = dt.Rows(0)("Member_addrdist")
                txtPost.Text = dt.Rows(0)("Member_postcode")
                btnUpdate.Enabled = True
            Else
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
                btnUpdate.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        connection.Close()
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
        txtMember_id.Enabled = True
        txtMember_card.Enabled = False
        cbGender.Enabled = False
        txtEmail.Enabled = False
        txtName.Enabled = False
        txtSurname.Enabled = False
        txtDate.Enabled = False
        txtPhone.Enabled = False
        cbCareer.Enabled = False
        cbLavel.Enabled = False
        txtNo.Enabled = False
        txtPro.Enabled = False
        txtCity.Enabled = False
        txtDes.Enabled = False
        txtPost.Enabled = False
        txtMember_id.Focus()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Private Sub btnUpdate_Click_1(sender As Object, e As EventArgs) Handles btnUpdate.Click
        txtMember_id.Enabled = False
        txtMember_card.Enabled = False
        cbGender.Enabled = True
        txtEmail.Enabled = True
        txtName.Enabled = True
        txtSurname.Enabled = True
        txtDate.Enabled = True
        txtPhone.Enabled = True
        cbCareer.Enabled = True
        cbLavel.Enabled = True
        txtNo.Enabled = True
        txtPro.Enabled = True
        txtCity.Enabled = True
        txtDes.Enabled = True
        txtPost.Enabled = True
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(txtMember_id.Text) <> "" And Trim(txtMember_card.Text) <> "" And Trim(cbGender.Text) <> "" And Trim(txtEmail.Text) <> "" And Trim(txtName.Text) <> "" And Trim(txtSurname.Text) <> "" And Trim(txtPhone.Text) <> "" And Trim(cbCareer.Text) <> "" And Trim(cbLavel.Text) <> "" And Trim(txtNo.Text) <> "" And Trim(txtPro.Text) <> "" And Trim(txtCity.Text) <> "" And Trim(txtDes.Text) <> "" And Trim(txtPost.Text) <> "" Then
            sql = "update Member set Member_cardid = @Member_cardid,Member_email = @Member_email,Member_firstname = @Member_firstname"
            sql &= ",Member_lastname = @Member_lastname,Member_sex = @Member_sex,Member_birthday = @Member_birthday,Member_phone = @Member_phone,Member_addrno = @Member_addrno,Member_addrpro = @Member_addrpro"
            sql &= ",Member_addrcity = @Member_addrcity,Member_addrdist = @Member_addrdist,Member_postcode = @Member_postcode,Member_career = @Member_career,Member_level = @Member_level,Bank_id = @Bank_id where  Member_id =  @Member_id"
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