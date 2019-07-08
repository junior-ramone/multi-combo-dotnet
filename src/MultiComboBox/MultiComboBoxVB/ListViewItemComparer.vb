Public Class ListViewItemComparer
    Implements IComparer
    Private col As Integer
    Private order As SortOrder

    Public Sub New(column As Integer, order As SortOrder)
        Me.col = column
        Me.order = order
    End Sub

    Public Function Compare(x As Object, y As Object) As Integer Implements System.Collections.IComparer.Compare
        Dim return_val As Integer = 0

        Try
            Dim item_a As ListViewItem = CType(x, ListViewItem)
            Dim item_b As ListViewItem = CType(y, ListViewItem)

            If item_a.SubItems.Count > col And item_b.SubItems.Count > col Then

                Dim value_a As String = item_a.SubItems(col).Text
                Dim value_b As String = item_b.SubItems(col).Text

                If IsDate(value_a) AndAlso IsDate(value_b) Then

                    return_val = Date.Compare(value_a, value_b)

                ElseIf IsNumeric(value_a) AndAlso IsNumeric(value_b) Then

                    return_val = Decimal.Compare(value_a, value_b)

                Else

                    return_val = String.Compare(value_a, value_b)

                End If

                If order = SortOrder.Descending Then
                    return_val *= -1
                End If

            End If

            Return return_val

        Catch ex As Exception
            Return return_val
        End Try
    End Function
End Class