Public Class Hospital
    Public Property Name As String
    Public Property Url As String
    Public Property Keshis As List(Of Keshi)

    Public Sub Add(exp As Expert)
        Dim ke = Keshis.FirstOrDefault(Function(k) k.Name = exp.Keshi)
        If ke IsNot Nothing Then
            ke.Experts.Add(exp)
        Else
            ke = New Keshi
            ke.Name = exp.Keshi
            ke.Experts = New List(Of Expert)
            ke.Experts.Add(exp)
            Keshis.Add(ke)
        End If
    End Sub

    Public Overrides Function ToString() As String
        Return Name
    End Function
End Class
