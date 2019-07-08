Friend Class Company
    Public Property Id As ULong
    Public Property Company As String
    Public Property Symbol As String
    Public Property Sector As String

    Sub New(company, symbol, sector)
        Me.Company = company
        Me.Symbol = symbol
        Me.Sector = sector
    End Sub

    Public Function Clone() As Company
        Return CType(MemberwiseClone(), Company)
    End Function
End Class
