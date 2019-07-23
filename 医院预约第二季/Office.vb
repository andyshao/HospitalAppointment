Public Class Office
    Public ReadOnly Property ID As Integer
        Get
            Return Url.Substring(Url.IndexOf("Offid=") + 6)
        End Get
    End Property
    Public Property Name As String
    Public Property Url As String

    Public Overrides Function ToString() As String
        Return Name
    End Function
End Class
