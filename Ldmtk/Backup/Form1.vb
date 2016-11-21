Imports Clsql
Imports ClsControl2
Imports ClsLookup
Public Class Frmmain
    Dim frmin As New tk
    Dim strdkloc As String
    Dim tk_me_old As String
    'Dim dk As New dkloc
    Dim isloaded As Boolean = False
    Public WithEvents list As ClsList.List1
    

    Private Sub dmload(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        Me.KeyPreview = True
        If ClsControl2.PropertyOfForm.CheckRegister = False Then
            Me.Close()
        End If
        lbluser.Text = Reg.GetValue("ID")
        list = New ClsList.List1(listid, grid, frmin)
        conn = list.conn

        
       
        PropertyOfForm.SetImage4Control("user.bmp", lbluser)
        PropertyOfForm.SetLable(list.oLable, Me)
        Me.Icon = frmin.Icon
        dkloc.Icon = frmin.Icon
        thong_tin_chung.ContextMenuStrip = list.Contextmenu
        'sercurity
        PropertyOfForm.Sercurity(thong_tin_chung)
        frmin.btnhuy.CausesValidation = False
        list.AddToolStripMain(ToolStripmain)
        'list.AddToolStripFind(ToolStripfind)

        list.AddMenuItem(mnfile)
        list.AddContextMenu()

        setupload()
        loadlist()
        
        If Reg.GetValue("Language") = "Vi" Then
            txtten_loai_cl_co2.Hide()
            txtten_loai_cl_no2.Hide()
        End If
        isloaded = True
    End Sub
    Private Sub thoat(ByVal sender As Object, ByVal e As System.EventArgs)
        list = Nothing
        Me.Close()
    End Sub
    
    Private Sub list_BeforeSave(ByVal e As System.Data.DataRow)
        e("loai_tk") = conn.GetValue("select case when  exists(select tk from dmtk where tk_me ='" & e("tk") & "') then 1 else 0 end")
        If e("tk_me") = "" Then
            e("bac_tk") = 1
        Else
            Dim bac_tk_me As Integer = conn.GetValue("select bac_tk from dmtk where tk ='" & e("tk_me") & "'")
            e("bac_tk") = bac_tk_me + 1
            For Each r As DataRow In list.datatable.Select("tk ='" & e("tk_me") & "'")
                r("loai_tk") = 1
            Next
            conn.Execute("update dmtk set loai_tk = 1 where tk ='" & e("tk_me") & "'")
        End If
        e("ten_loai_cl_co") = frmin.cbbloai_cl_co.Text
        e("ten_loai_cl_no") = frmin.cbbloai_cl_no.Text
        e("ten_loai_cl_co2") = frmin.cbbloai_cl_co.Text
        e("ten_loai_cl_no2") = frmin.cbbloai_cl_no.Text

    End Sub

    Private Sub list_AfterDeleteItem(ByVal e As DataRow)
        If conn.GetValue("  if exists(select tk from dmtk where tk_me ='" & e("tk_me") & "') select  1 else  select 0 ") = 1 Then
            For Each r As DataRow In list.datatable.Select("tk ='" & e("tk_me") & "'")
                r("loai_tk") = 1
            Next
        Else
            For Each r As DataRow In list.datatable.Select("tk ='" & e("tk_me") & "'")
                r("loai_tk") = 0
            Next
        End If
        conn.Execute("update dmtk set loai_tk =  case when  exists(select tk from dmtk where tk_me ='" & e("tk_me") & "') then 1 else 0 end where tk ='" & e("tk_me") & "'")
    End Sub
    Private Sub list_BeforeDeteleItem(ByVal e As DataRow)
        If e("loai_tk") = 1 Then
            MsgBox(list.oLable("018").ToString.Replace("%n", e("tk")), MsgBoxStyle.Exclamation, Me.Text)
            list.deleteYN = False
        End If
    End Sub
   
    Private Sub BeforeAddItem()

    End Sub


    Private Sub list_AfterEditItem(ByVal e As Object)
       
        If tk_me_old <> e("tk_me") Then
            If conn.GetValue(" if exists(select tk from dmtk where tk_me ='" & tk_me_old & "')  select 1 else select 0 ") = 1 Then
                For Each r As DataRow In list.datatable.Select("tk ='" & tk_me_old & "'")
                    r("loai_tk") = 1
                Next
            Else
                For Each r As DataRow In list.datatable.Select("tk ='" & tk_me_old & "'")
                    r("loai_tk") = 0
                Next
            End If
            conn.Execute("update dmtk set loai_tk =  case when  exists(select tk from dmtk where tk_me ='" & tk_me_old & "') then 1 else 0 end  where tk ='" & tk_me_old & "'")

        End If
        
    End Sub
    Private Sub list_AfterFind(ByVal e As String)
        ' loadData(e)
    End Sub
   
    Sub setupload()
        ma_nt_ht = Clsql.Others.Options("a_dtht", conn)
        If Clsql.Reg.GetValue("Language") = "Vi" Then
            AddItems.AddItemCbb(conn, "select ma_pp,ten_pp from dmpp where loai_pp =1", frmin.cbbloai_cl_no, "ten_pp", "ma_pp")
        Else
            AddItems.AddItemCbb(conn, "select ma_pp,ten_pp2 from dmpp where loai_pp =1", frmin.cbbloai_cl_no, "ten_pp2", "ma_pp")
        End If

        If Clsql.Reg.GetValue("Language") = "Vi" Then
            AddItems.AddItemCbb(conn, "select ma_pp,ten_pp from dmpp where loai_pp =1", frmin.cbbloai_cl_co, "ten_pp", "ma_pp")
        Else
            AddItems.AddItemCbb(conn, "select ma_pp,ten_pp2 from dmpp where loai_pp =1", frmin.cbbloai_cl_co, "ten_pp2", "ma_pp")
        End If
        'lookup
        Dim oNt As New ClsLookup.AutoCompleteLookup(conn, "dmnt", frmin.txtma_nt, "ma_nt", True)
        oNt.SetValue("ten_nt", frmin.ten_nt)
        oTK = New ClsLookup.AutoCompleteLookup(conn, "rdmtk", frmin.txttk_me, "tk", False)
        If Reg.GetValue("Language") = "Vi" Then
            oTK.SetValue("ten_tk", frmin.ten_tk_me)
        Else
            oTK.SetValue("ten_tk2", frmin.ten_tk_me)
        End If
    End Sub

   

    Private Sub list_BeforeEditItem() Handles list.BeforeEditItem
        frmin.cbbloai_cl_co.Enabled = Not (ma_nt_ht.Trim.ToUpper = txtma_nt.Text.Trim.ToUpper)
        frmin.cbbloai_cl_no.Enabled = Not (ma_nt_ht.Trim.ToUpper = txtma_nt.Text.Trim.ToUpper)

        tk_me_old = list.BindingSource.Current("tk_me")

    End Sub


#Region "tesst"
    Delegate Sub mydelegate()
    Sub loadlist()
       
       

        
        Me.ContextMenuStrip = list.Contextmenu

        ' Clsql.Others.GetArgu(1):ListID
        ' Clsql.Others.GetArgu(2):code
        If Clsql.Others.GetArgu(2) <> "" Then


            For Each r As DataGridViewRow In grid.Rows
                If r.Cells("tk").Value.ToString.ToUpper.Trim = Clsql.Others.GetArgu(2).Trim.ToUpper Then
                    grid.CurrentCell = r.Cells("tk")
                    Exit For
                End If
            Next
        End If


        'bind data cho view
        PropertyOfForm.BindData(list.BindingSource, thong_tin_chung)



        'add button detail
        ' Dim dd As New clsViDe.DropDownButtonDetail(list.conn, ToolStripfind, "ldkh", Me.grd)



        AddHandler frmin.btnLuu.Click, AddressOf list.Save
        AddHandler frmin.btnhuy.Click, AddressOf list.Cancel

        AddHandler list.BeforeDeleteItem, AddressOf list_BeforeDeteleItem
        '   AddHandler list.AfterAddItem, AddressOf list_AfterAddItem
        AddHandler list.AfterDeleteItem, AddressOf list_AfterDeleteItem
        AddHandler list.AfterEditItem, AddressOf list_AfterEditItem
        ' AddHandler list.AfterFind, AddressOf list_AfterFind
        AddHandler list.BeforeAddItem, AddressOf BeforeAddItem

        AddHandler list.BeforeSave, AddressOf list_BeforeSave

        list.datatable.DefaultView.Sort = "tk"
    End Sub
#End Region

   
    Private Sub list_SaveClick() Handles list.SaveClick
        'kiem tra xem da chon phuong thuc tinh ty gia ghi so chua
        If frmin.cbbloai_cl_co.Enabled = True Then
            If frmin.cbbloai_cl_co.SelectedValue = 0 AndAlso frmin.cbbloai_cl_no.SelectedValue = 0 Then
                list.ContinueSave = False
                MsgBox(list.oLable("101"), MsgBoxStyle.Critical, Me.Text)
                Return
            End If
        End If
        ''
    End Sub
End Class
