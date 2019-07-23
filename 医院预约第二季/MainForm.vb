Imports HtmlAgilityPack
Imports LSW.Net

Public Class MainForm
    Dim BaseUrl As String = "http://wn.jinyexx.com/"
    Dim AutoExp As Expert

    Public Sub ShowMsg(msg As String)
        TextBox1.AppendText(Now & " " & msg & vbCrLf)
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        DateTimePicker1.Enabled = CheckBox1.Checked
    End Sub

    Sub Init()
        Dim hosp As New Hospital With {.Name = "西安市中医医院", .Url = "HosIntro.aspx?Hosid=331"}
        ComboBox1.Items.Add(hosp)
        LoginDialog.Logout()
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Init()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim cb = DirectCast(sender, ComboBox)
        Dim h = DirectCast(cb.SelectedItem, Hospital)
        ComboBox2.Items.Clear()
        ComboBox2.Items.AddRange(GetOffices(h).ToArray)
        ComboBox2.Enabled = True
    End Sub

    Function GetOffices(h As Hospital) As List(Of Office)
        Dim os As New List(Of Office)
        Dim html As New HtmlDocument
        html.LoadHtml(GetHtml(BaseUrl & h.Url))
        Dim links = html.DocumentNode.SelectNodes("//div[@id='ys_qt_nr']/ul/li/a")
        For Each link In links
            Dim o As New Office With {
                .Name = link.InnerText,
                .Url = link.GetAttributeValue("href", "")
                }
            os.Add(o)
        Next
        Return os
    End Function

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim cb = DirectCast(sender, ComboBox)
        Dim o = DirectCast(cb.SelectedItem, Office)
        ComboBox3.Items.Clear()
        ComboBox3.Items.AddRange(GetExperts(o).ToArray)
        ComboBox3.Enabled = True
    End Sub

    Function GetExperts(o As Office) As List(Of Expert)
        Dim es As New List(Of Expert)
        Dim html As New HtmlDocument
        html.LoadHtml(GetHtml(BaseUrl & o.Url))
        Dim links = html.DocumentNode.SelectNodes("//div[@id='ys_qt_nr']/ul/li/a")
        For Each link In links
            Dim e As New Expert With {
                .Name = link.InnerText,
                .Url = link.GetAttributeValue("href", "")
                }
            es.Add(e)
        Next
        Return es
    End Function

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        Dim cb = DirectCast(sender, ComboBox)
        Dim exp = DirectCast(cb.SelectedItem, Expert)
        AutoExp = exp
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If AutoExp IsNot Nothing Then
            ShowMsg("自动扫描器启动")
            Timer1.Interval = NumericUpDown1.Value * 1000
            Button1.Enabled = False
            Button2.Enabled = True
            Timer1.Start()
        Else
            ShowMsg("请先选择专家")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button1.Enabled = True
        Button2.Enabled = False
        Timer1.Stop()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        LoginDialog.ShowDialog()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ShowMsg("正在扫描。。。医生：" & AutoExp.Name)
        Dim orders = GetOrders(AutoExp)
        If orders.Count > 0 Then
            'ShowMsg(orders(0))
            If String.IsNullOrEmpty(LoginDialog.Cookie) Then LoginDialog.Login()
            Timer1.Stop()
            ShowMsg("找到可预约的号。。。正在预约。。。")
            LoginDialog.Order(BaseUrl & orders(0))
        Else
            ShowMsg("扫描结果：目前没号")
        End If
    End Sub

    Function GetOrders(exp As Expert) As List(Of String)
        Dim orders As New List(Of String)
        Dim html As New HtmlDocument
        html.LoadHtml(GetHtml(BaseUrl & exp.Url))
        Dim links = html.DocumentNode.SelectNodes("//tr[@class='ys-cz_td2']/td/a")
        If links Is Nothing Then Return orders
        For Each link In links
            orders.Add(link.GetAttributeValue("href", ""))
        Next
        Return orders
    End Function
End Class
