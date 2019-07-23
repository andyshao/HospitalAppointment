Imports LSW.Net
Imports HtmlAgilityPack
Imports System.Collections.Specialized
Imports System.Text
Imports LSW.Extension

Public Class OrderForm
    Dim gh As Guahao
    Dim url As String
    Dim VIEWSTATE As String
    Dim EVENTVALIDATION As String
    Dim flag As Boolean = False
    Dim NumOnly As String
    Dim IsAuto As Boolean = False

    Public Overloads Function ShowDialog(gh As Guahao) As DialogResult
        Me.gh = gh
        flag = False
        Button1.Enabled = False
        NumOnly = ""
        url = String.Format("http://www.xazyy.com/guahaoDetail.aspx?doc_id={0}&regtime={1}&regweek={2}", gh.Doc_id, gh.Regtime, gh.Regweek)
        Return MyBase.ShowDialog
    End Function

    Public Overloads Function ShowDialog(gh As Guahao, isauto As Boolean) As DialogResult
        Me.IsAuto = isauto
        Return ShowDialog(gh)
    End Function

    Private Sub OrderForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim xml = My.Computer.FileSystem.ReadAllText("user.xml")
        Dim u = xml.XmlDeserialize(Of User)()
        txtName.Text = u.Name
        txtshenfen.Text = u.ID
        txtSex.Text = u.Sex
        txtTel.Text = u.Phone

        WebBrowser1.Navigate(url)

        Dim html As New HtmlDocument
        html.LoadHtml(GetHtml(url))
        Dim sel = html.DocumentNode.SelectSingleNode("//select[@id='ddlperi']").InnerText
        VIEWSTATE = html.DocumentNode.SelectSingleNode("//input[@id='__VIEWSTATE']").GetAttributeValue("value", "")
        EVENTVALIDATION = html.DocumentNode.SelectSingleNode("//input[@id='__EVENTVALIDATION']").GetAttributeValue("value", "")
        Dim options = Trim(sel).Split(vbCrLf)
        ddlperi.Items.Clear()
        For Each opt In options
            If Trim(opt).Length > 3 Then ddlperi.Items.Add(Trim(opt))
        Next
        txtDate.Text = Now.AddDays(gh.Regweek + 2).ToShortDateString
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        WebBrowser1.Document.GetElementById("txtName").SetAttribute("value", txtName.Text)
        If txtSex.Text = "男" Then
            WebBrowser1.Document.GetElementById("rnan").InvokeMember("click")
        Else
            WebBrowser1.Document.GetElementById("rnv").InvokeMember("click")
        End If
        WebBrowser1.Document.GetElementById("txtshenfen").SetAttribute("value", txtshenfen.Text)
        WebBrowser1.Document.GetElementById("txtTel").SetAttribute("value", txtTel.Text)
        WebBrowser1.Document.GetElementById("ddlperi").SetAttribute("selectedindex", ddlperi.SelectedIndex)
        WebBrowser1.Document.GetElementById("txtjianjie").SetAttribute("value", TextBox1.Text)
        flag = True
        WebBrowser1.Document.GetElementById("ImageButton1").InvokeMember("click")
        'DialogResult = Windows.Forms.DialogResult.OK
        'Dim vars As New NameValueCollection
        'vars.Add("__EVENTTARGET", "")
        'vars.Add("__EVENTARGUMENT", "")
        'vars.Add("__VIEWSTATE", VIEWSTATE)
        'vars.Add("__EVENTVALIDATION", EVENTVALIDATION)
        'vars.Add("Search1$ddlNewsType", "-1")
        'vars.Add("Search1$txtSearch", "")
        'vars.Add("txtName", txtName.Text)
        'vars.Add("aa", IIf(txtSex.Text = "男", "rnan", "rnv"))
        'vars.Add("ddlType", ddlType.Text)
        'vars.Add("txtshenfen", txtshenfen.Text)
        'vars.Add("txtTel", txtTel.Text)
        'vars.Add("txtDate", txtDate.Text)
        'vars.Add("ddlperi", ddlperi.SelectedItem)
        'vars.Add("txtjianjie", TextBox1.Text)
        'vars.Add("ImageButton1.x", 19)
        'vars.Add("ImageButton1.y", 12)
        'Dim rehtml = Post(vars, url, Encoding.UTF8)
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        If flag Then
            flag = False
            NumOnly = WebBrowser1.Document.GetElementById("lblOnly").InnerText
            Dim m = "预约时间为：" & Now.AddDays(gh.Regweek + 2).ToShortDateString & " " & ddlperi.SelectedItem & vbCrLf & "您的预约号为：" & NumOnly
            My.Computer.Clipboard.SetText(m)
            'MsgBox("提交成功！" & vbCrLf & m & "(请记住此号)" & vbCrLf & "号码已经为您复制到剪切板，粘贴即可")
            MainForm.ShowMsg("提交成功！" & vbCrLf & m & "(请记住此号)" & vbCrLf & "号码已经为您复制到剪切板，粘贴即可")
            Close()
        Else
            Button1.Enabled = True
            If IsAuto Then
                ddlperi.SelectedIndex = 0
                TextBox1.Text = "您好"
                Button1.PerformClick()
            End If
        End If
    End Sub
End Class