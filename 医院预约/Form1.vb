Imports LSW.Net
Imports HtmlAgilityPack
Imports LSW.Extension

Public Class Form1
    Dim hosp As New Hospital
    Dim AutoExp As New Expert
    Dim i As Integer = 0

    Private Sub 刷新医院信息ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 刷新医院信息ToolStripMenuItem.Click
        Dim hosp As New Hospital With {.Name = "西安市中医医院", .Url = "http://www.xazyy.com/", .Keshis = New List(Of Keshi)}
        Dim xazyyurl = "http://www.xazyy.com/GuahaoNext.aspx"
        Dim html As New HtmlDocument
        html.LoadHtml(GetHtml(xazyyurl))
        For Each a In html.DocumentNode.SelectNodes("//a[@class='line']")
            Dim href = a.GetAttributeValue("href", "")
            hosp.Add(GetExpert(hosp.Url & href))
        Next
        My.Computer.FileSystem.WriteAllText("Hospital.xml", hosp.XmlSerialize, False)
        MsgBox("刷新成功！")
    End Sub

    Function GetExpert(url As String) As Expert
        Dim html As New HtmlDocument
        html.LoadHtml(GetHtml(url))
        Return New Expert With {
            .ID = url.Substring(url.IndexOf("=") + 1),
            .ImgUrl = html.DocumentNode.SelectSingleNode("//img[@id='imgurl']").GetAttributeValue("src", ""),
            .Name = html.DocumentNode.SelectSingleNode("//span[@id='lblName']").InnerText,
            .Level = html.DocumentNode.SelectSingleNode("//span[@id='lblLevel']").InnerText,
            .Keshi = html.DocumentNode.SelectSingleNode("//span[@id='lblKeshi']").InnerText,
            .GoodAt = html.DocumentNode.SelectSingleNode("//span[@id='lblGoodAt']").InnerText,
            .ExpIntro = html.DocumentNode.SelectSingleNode("//span[@id='lblExpIntro']").InnerText
            }
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Init()
    End Sub

    Sub Init()
        Dim xml = My.Computer.FileSystem.ReadAllText("Hospital.xml")
        hosp = xml.XmlDeserialize(Of Hospital)()
        ToolStripComboBox1.Items.Add(hosp)
    End Sub

    Private Sub ToolStripComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ToolStripComboBox1.SelectedIndexChanged
        Dim cb = DirectCast(sender, ToolStripComboBox)
        Dim h = DirectCast(cb.SelectedItem, Hospital)
        ToolStripComboBox2.Items.AddRange(h.Keshis.ToArray)
        ToolStripComboBox2.Enabled = True
    End Sub

    Private Sub ToolStripComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ToolStripComboBox2.SelectedIndexChanged
        Dim cb = DirectCast(sender, ToolStripComboBox)
        Dim k = DirectCast(cb.SelectedItem, Keshi)
        ExpertBindingSource.DataSource = k.Experts
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = 0 Then
            Dim dv = DirectCast(sender, DataGridView)
            Dim exp = DirectCast(dv.Rows(e.RowIndex).DataBoundItem, Expert)
            ExpertForm.ShowDialog(exp)
        ElseIf e.ColumnIndex = 4 Then
            Dim dv = DirectCast(sender, DataGridView)
            Dim exp = DirectCast(dv.Rows(e.RowIndex).DataBoundItem, Expert)
            AutoExp = exp
            Timer1.Enabled = True
            ToolStripStatusLabel1.Text = "自动扫描器启动"
        End If
    End Sub

    Private Sub 我的资料ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 我的资料ToolStripMenuItem.Click
        MyInfoDialog.ShowDialog()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Timer1.Enabled = False
#If DEBUG Then
        i += 1
        If i > 50 Then
            Timer1.Enabled = False
            MsgBox("试用版的次数已到，请联系作者拿正式版")
            End
        End If
#End If
        ToolStripStatusLabel1.Text = "正在扫描。。。医生：" & AutoExp.Name
        Dim g = ExpertForm.GetGuohaoTime(AutoExp)
        If g.Count > 0 Then
            ToolStripStatusLabel1.Text = "找到可预约的号。。。正在预约。。。"
            OrderForm.ShowDialog(g(0), True)
            Timer1.Enabled = False
        Else
            ToolStripStatusLabel1.Text &= "。。。结果：目前没号"
        End If
    End Sub
End Class
