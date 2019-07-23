Imports System.Windows.Forms
Imports LSW.Extension

Public Class MyInfoDialog

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        'My.Settings.扫描时间间隔 = CInt(TextBox1.Text) * 1000
        Dim u As New User With {
            .Name = txtName.Text,
            .ID = txtshenfen.Text,
            .Sex = txtSex.Text,
            .Phone = txtTel.Text
            }
        My.Computer.FileSystem.WriteAllText("user.xml", u.XmlSerialize, False)
        My.Settings.Save()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub MyInfoDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim xml = My.Computer.FileSystem.ReadAllText("user.xml")
            Dim u = xml.XmlDeserialize(Of User)()
            txtName.Text = u.Name
            txtshenfen.Text = u.ID
            txtSex.Text = u.Sex
            txtTel.Text = u.Phone
        Catch ex As Exception
            Dim u As New User With {
              .Name = "贺玉山",
              .ID = "230602196404055610",
              .Sex = "男",
              .Phone = "15522887506"
              }
            My.Computer.FileSystem.WriteAllText("user.xml", u.XmlSerialize, False)
        End Try
        'TextBox1.Text = My.Settings.扫描时间间隔 / 1000
    End Sub
End Class
