﻿Imports ClsLookup

Module Genaral
    Public Voucherid As String = "PKT"
    Public Voucher As ClsSV31.Voucher20
    Public conn As Clsql.SQL
    Public f_tien As String
    Public f_tien_nt As String
    Public f_so_luong As String
    Public oPrint As ClsSV31.Print20
    Public ma_nt_ht As String
    Public formtask As New ClsSV31.frmTask
    Public fPrintDialog As New frmPrint

End Module
