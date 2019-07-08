Friend Class ComboBoxItem
    Public Property Text As String
    Public Property Value As Object

    Sub New(text As String, value As Object)
        Me.Text = text
        Me.Value = value
    End Sub
End Class