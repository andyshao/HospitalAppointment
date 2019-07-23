Imports LSW.Net
Imports HtmlAgilityPack

Public Class ExpertForm
    Dim exp As Expert

    Public Overloads Function ShowDialog(exp As Expert) As DialogResult
        Me.exp = exp
        PictureBox1.ImageLocation = ""
        Return MyBase.ShowDialog
    End Function

    Private Sub ExpertForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = "专家挂号 - " & exp.Name
        PictureBox1.ImageLocation = "http://www.xazyy.com/" & exp.ImgUrl
        TextBox1.Text = exp.Name
        TextBox2.Text = exp.Level
        TextBox3.Text = exp.Keshi
        TextBox4.Text = exp.GoodAt
        TextBox5.Text = exp.ExpIntro
        GuahaoBindingSource.DataSource = GetGuohaoTime("http://www.xazyy.com/ExpGuaHao.aspx?expert_id=" & exp.ID)
    End Sub

    Public Function GetGuohaoTime(exp As Expert) As List(Of Guahao)
        Me.exp = exp
        Return GetGuohaoTime("http://www.xazyy.com/ExpGuaHao.aspx?expert_id=" & exp.ID)
    End Function

    Public Function GetGuohaoTime(url As String) As List(Of Guahao)
        Dim result As New List(Of Guahao)
        Dim html As New HtmlDocument
        html.LoadHtml(GetHtml(url))
        Try
            'For Each a In html.DocumentNode.SelectNodes("//a[@style='color:#996600']")
            For Each f In html.DocumentNode.SelectNodes("//font[@class='tableTr']")
                Dim g As New Guahao With {.Doc_id = exp.ID}
                Dim a = f.NextSibling.NextSibling.NextSibling
                Dim href = a.GetAttributeValue("href", "")
                g.Regtime = href.Substring(href.IndexOf("e=") + 2, 1)
                g.Regweek = href.Substring(href.IndexOf("k=") + 2, 1)
                Dim state = Trim(f.ParentNode.InnerText.Replace(vbCrLf, ""))
                g.State = state.Substring(0, state.Length - 3)
                result.Add(g)
            Next
        Catch ex As Exception
        End Try
        Return result
    End Function

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = 2 Then
            Dim dv = DirectCast(sender, DataGridView)
            Dim g = DirectCast(dv.Rows(e.RowIndex).DataBoundItem, Guahao)
            OrderForm.ShowDialog(g)
        End If
    End Sub
End Class