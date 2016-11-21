Imports ClsLookup

Module Genaral


    Public conn As Clsql.SQL = Clsql.SQL.newInstance
    Public f_tien As String
    Public f_tien_nt As String
    Public f_so_luong As String

    Public dtht As String

    Function getQuerytattoan(stt_rec) As String
        Dim kq As String = ""
        For Each r As DataRow In conn.GetDatatable("select stt_rec_tt,ma_ct_tt from vtdttco where stt_rec ='" & stt_rec & "'").Rows
            kq = kq & Chr(13) & "EXEC Tatoanco '" & r("stt_rec_tt") & "','" & r("ma_ct_tt") & "'"
        Next
        Return kq
    End Function
    Sub BeforeShowInvoide(ByVal dv As DataView)
        For Each r As DataRow In dv.Table.Select("tien_nt<>0")
            r("sel") = True
        Next
    End Sub
End Module
