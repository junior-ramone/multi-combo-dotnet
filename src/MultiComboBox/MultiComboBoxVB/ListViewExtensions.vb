Imports System.Runtime.InteropServices

''' <summary>
''' Módulo para adicionar funções úteis para ListViews como nos controles EListView e EMultiCombo
''' </summary>
Friend Module ListViewExtensions
#Region " Windows API "
    ''' <summary>
    ''' Interface para as chamadas API do windows
    ''' </summary>
    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=False)> _
    Private Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    End Function
    <DllImport("user32.dll", EntryPoint:="SendMessage")> _
    Private Function SendMessageItem(ByVal Handle As IntPtr, ByVal msg As Int32, ByVal wParam As IntPtr, ByRef lParam As HDITEM) As IntPtr
    End Function

    ''' <summary>
    ''' Estruturas utilizadas pelas chamadas das API menssionadas a cima.
    ''' </summary>
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
    Private Structure HDITEM
        Public mask As UInteger
        Public cxy As Integer
        Public pszText As IntPtr
        Public hbm As IntPtr
        Public cchTextMax As Integer
        Public fmt As Integer
        Public lParam As IntPtr
        Public iImage As Integer
        Public iOrdenarComo As Integer
        Public type As UInteger
        Public pvFilter As IntPtr
    End Structure

    ''' <summary>
    ''' Constantes utilizadas pelas chamadas das API menssionadas a cima.
    ''' </summary>
    Private Const HDI_FORMAT As Integer = &H4
    Private Const HDF_SORTUP As Integer = &H400
    Private Const HDF_SORTDOWN As Integer = &H200
    Private Const LVM_FIRST As Integer = &H1000
    Private Const LVM_GETHEADER As Integer = (LVM_FIRST + 31)
    Private Const HDM_FIRST As Integer = &H1200
    Private Const HDM_GETITEM As Integer = HDM_FIRST + 11
    Private Const HDM_SETITEM As Integer = HDM_FIRST + 12
    Private Const LVM_SETITEMSTATE As Integer = LVM_FIRST + 43
    Private Const LVM_SETSELECTEDCOLUMN As Integer = LVM_FIRST + 140
    Private Const LVM_GETCOLUMNORDERARRAY As Integer = (LVM_FIRST + 59)
    Private Const WM_PAINT As Integer = &HF
#End Region

    Private lastColumn As Integer = -1

    Public Sub ShowSortIcon(list As ListView, direction As SortOrder, column As Integer)
        Try

            Dim hHeader As IntPtr = SendMessage(list.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero)

            Dim newColumn As New IntPtr(column)
            Dim hdItem As HDITEM
            Dim rtn As IntPtr

            ' Remove icon from last column, if it applies

            hdItem = New HDITEM()
            hdItem.mask = HDI_FORMAT

            If lastColumn > -1 Then
                Dim prevColumn As New IntPtr(lastColumn)

                rtn = SendMessageItem(hHeader, HDM_GETITEM, prevColumn, hdItem)
                hdItem.fmt = hdItem.fmt And Not HDF_SORTDOWN And Not HDF_SORTUP

                rtn = SendMessageItem(hHeader, HDM_SETITEM, prevColumn, hdItem)
            End If

            ' Set icon on desired column

            hdItem = New HDITEM()
            hdItem.mask = HDI_FORMAT
            rtn = SendMessageItem(hHeader, HDM_GETITEM, newColumn, hdItem)

            If direction = SortOrder.Ascending Then
                hdItem.fmt = hdItem.fmt Or HDF_SORTUP
            Else
                hdItem.fmt = hdItem.fmt Or HDF_SORTDOWN
            End If

            rtn = SendMessageItem(hHeader, HDM_SETITEM, newColumn, hdItem)

            lastColumn = column
        Catch ex As Exception

        End Try
    End Sub
End Module