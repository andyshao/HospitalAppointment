Imports System.Windows.Forms
Imports System.Threading

Public Class LoginDialog
    Dim IsLogin As Boolean = False
    Public Cookie As String
    Dim TempUrl As String
    Dim IsClick As Boolean = False

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        My.Settings.Save()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub Login()
        WebBrowser1.Navigate("http://wn.jinyexx.com/otherlogin.aspx")
    End Sub

    Public Sub Logout()
        IsLogin = False
        If WebBrowser1.Document IsNot Nothing Then WebBrowser1.Document.Cookie = Nothing
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        If e.Url.ToString = "http://wn.jinyexx.com/otherlogin.aspx" Then
            If Not IsLogin Then
                Try
                    WebBrowser1.Document.GetElementById("txtUserName").SetAttribute("value", My.Settings.用户名)
                    WebBrowser1.Document.GetElementById("txtPWD").SetAttribute("value", My.Settings.密码)
                    WebBrowser1.Document.GetElementById("btnLogin").InvokeMember("click")
                Catch ex As Exception
                End Try
                IsLogin = True
            ElseIf IsLogin Then
                Cookie = WebBrowser1.Document.Cookie
            End If
        End If

        If e.Url.ToString.Contains("order.aspx") Then
            If IsClick Then
                TempUrl = ""
                MainForm.ShowMsg(WebBrowser1.Document.GetElementsByTagName("b")(0).InnerText)
                MainForm.ShowMsg(WebBrowser1.Document.GetElementById("news2").InnerText)
            Else
                WebBrowser1.Document.GetElementById("ContentPlaceHolder1_btnSubmit").InvokeMember("click")
                IsClick = True
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Login()
    End Sub

    Public Sub Order(url As String)
        TempUrl = url
        IsClick = False
        WebBrowser1.Navigate(url)
    End Sub
End Class
