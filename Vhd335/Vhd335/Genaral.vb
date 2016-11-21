Imports ClsLookup
Imports System.ComponentModel

Module Genaral
    Public Voucherid As String = "HD3"
    Public Voucher As ClsSV31.Voucher20
    Public conn As Clsql.SQL
    Public f_tien As String
    Public f_tien_nt As String
    Public f_so_luong As String

    Public ma_nt_ht As String
    Public layhd As GetDataByStoreMD
    Public querytt As String = ""

    Private oPrint As ClsSV31.Print20
    Private fPrintDialog As frmPrint
    Public frmin As New frminput
    Public Sub vprint()
        getPrint().Print()
    End Sub
    Function getPrint() As ClsSV31.Print20
        If oPrint IsNot Nothing Then
            Return oPrint
        End If
        fPrintDialog = New frmPrint
        ClsControl2.PropertyOfForm.SetLable(Voucher.oLan, fPrintDialog)
        fPrintDialog.Icon = frmin.Icon

        'print
        oPrint = New ClsSV31.Print20(Voucher, fPrintDialog.cbbmau, fPrintDialog.txttieu_de, fPrintDialog.Txtso_lien)
        fPrintDialog.StartPosition = FormStartPosition.CenterParent
        fPrintDialog.Txtso_lien.Value = Voucher.Voucherinfo("d_so_lien")

        Return oPrint
    End Function
    Function getQuerytattoan() As String
        Dim kq As String = ""
        For Each r As DataRow In conn.GetDatatable("select stt_rec_tt,ma_ct_tt from tdttno where stt_rec ='" & Voucher.Stt_rec & "'").Rows
            kq = kq & Chr(13) & "EXEC Tatoanno '" & r("stt_rec_tt") & "','" & r("ma_ct_tt") & "'"
        Next
        Return kq
    End Function
 
End Module
