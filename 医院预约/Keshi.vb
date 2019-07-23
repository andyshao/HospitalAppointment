Public Class Keshi
    Public Property Name As String
    Public Property Experts As List(Of Expert)

    Public Overrides Function ToString() As String
        Return Name
    End Function
End Class
