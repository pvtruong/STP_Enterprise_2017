Module Main
    Public conn As Clsql.SQL = New Clsql.SQL
    Public dv As DataView
    Public listid As String = Clsql.Others.GetArgu(1)

    Public oTK As ClsLookup.AutoCompleteLookup
    Public ma_nt_ht As String
End Module
