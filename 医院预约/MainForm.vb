Imports LSW.Extension

Public Class MainForm
    Dim hosp As New Hospital
    Dim AutoExp As Expert
    Dim i As Integer = 0

    Sub Init()
        Dim xml = My.Computer.FileSystem.ReadAllText("Hospital.xml")
        hosp = xml.XmlDeserialize(Of Hospital)()
        ComboBox1.Items.Add(hosp)
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Init()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MyInfoDialog.ShowDialog()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        DateTimePicker1.Enabled = CheckBox1.Checked
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim cb = DirectCast(sender, ComboBox)
        Dim h = DirectCast(cb.SelectedItem, Hospital)
        ComboBox2.Items.Clear()
        ComboBox2.Items.AddRange(h.Keshis.ToArray)
        ComboBox2.Enabled = True
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim cb = DirectCast(sender, ComboBox)
        Dim k = DirectCast(cb.SelectedItem, Keshi)
        ComboBox3.Items.Clear()
        ComboBox3.Items.AddRange(k.Experts.ToArray)
        ComboBox3.Enabled = True
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        Dim cb = DirectCast(sender, ComboBox)
        Dim exp = DirectCast(cb.SelectedItem, Expert)
        AutoExp = exp
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If AutoExp IsNot Nothing Then
            ShowMsg("自动扫描器启动")
            Timer1.Interval = NumericUpDown1.Value * 100
            Button1.Enabled = False
            Button2.Enabled = True
            Timer1.Start()
        Else
            ShowMsg("请先选择专家")
        End If
    End Sub

    Public Sub ShowMsg(msg As String)
        TextBox1.AppendText(Now & " " & msg & vbCrLf)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button1.Enabled = True
        Button2.Enabled = False
        Timer1.Stop()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
#If False Then
        i += 1
        If i > 50 Then
            Timer1.Stop()
            ShowMsg("试用版的次数已到，请联系作者拿正式版")
        End If
#End If
        ShowMsg("正在扫描。。。医生：" & AutoExp.Name)
        Dim g = ExpertForm.GetGuohaoTime(AutoExp)
        If g.Count > 0 Then
            Timer1.Stop()
            ShowMsg("找到可预约的号。。。正在预约。。。")
            OrderForm.ShowDialog(g(0), True)
            Button1.Enabled = True
        Else
            ShowMsg("扫描结果：目前没号")
        End If
    End Sub
End Class