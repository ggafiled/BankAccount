Imports System.IO

Public Class Advertising

    Dim imglist() As String
    Dim max As Integer
    Dim Random As Integer
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        laShow.Text = Now()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Randomize()
        Random = Int(Rnd() * max)
        pcShow.Image = Image.FromFile(imglist(Random))
    End Sub

    Private Sub Advertising_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        imglist = Directory.GetFiles("D:\dev\BankAccount\BankAccount\Resources\Advertising")
        max = imglist.Length
        Timer1.Start()
        Timer2.Start()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Timer1.Stop()
        Timer2.Stop()
        Dim mn As New MainManu()
        mn.Show()
    End Sub
End Class