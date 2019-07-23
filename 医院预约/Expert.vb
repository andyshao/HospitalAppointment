Public Class Expert
    Public Property ID As Integer
    Public Property ImgUrl As String
    Public Property Name As String
    Public Property Level As String
    Public Property Keshi As String
    Public Property GoodAt As String
    Public Property ExpIntro As String

    Public Overrides Function ToString() As String
        Return Name
    End Function
End Class
