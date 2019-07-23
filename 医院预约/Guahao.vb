Public Class Guahao
    Public Property Doc_id As Integer
    Public Property Regtime As Integer
    Public Property Regweek As Integer
    Public Property State As String
    Public ReadOnly Property DateTime As String
        Get
            Return Now.AddDays(Regweek + 2).ToShortDateString & IIf(Regtime = 1, "上午", "下午")
        End Get
    End Property
End Class
