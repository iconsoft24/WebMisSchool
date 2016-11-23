Imports System.Data
Imports System.Data.SqlClient

Public Class WebShowStudent
    Inherits System.Web.UI.Page

    Dim cClassNo As New clsMisClassName

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strClassNo As String

        strClassNo = Request.QueryString("ClassNo")

        If strClassNo = "" Then
            strClassNo = "101111"
        End If

        cClassNo.ClassNo = strClassNo

        If Not Page.IsPostBack Then

            Me.BindData(strClassNo)

        End If

    End Sub

    Sub modEditCommand(sender As Object, e As GridViewEditEventArgs)
        GV1.EditIndex = e.NewEditIndex
        GV1.ShowFooter = False
        BindData(cClassNo.ClassNo)
        GV1.Rows(e.NewEditIndex).FindControl("txtEditFname").Focus()

    End Sub

    Sub modCancelCommand(sender As Object, e As GridViewCancelEditEventArgs)
        With GV1
            .EditIndex = -1
            .ShowFooter = True
            Me.BindData(cClassNo.ClassNo)
        End With
    End Sub

    Sub modDeleteCommand(sender As Object, e As GridViewDeleteEventArgs)



        With GV1
            Dim strStdNo As String = .DataKeys.Item(e.RowIndex).Value

            Dim strconn As String = modConn.strCon

            Dim cn As New SqlConnection(strconn)
            Dim strSql As String = Resources.rsMain.StudentDel


            Dim cmd As New SqlCommand(strSQL, cn)

            cmd.Parameters.AddWithValue("@p1", strStdNo)

            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            .EditIndex = -1

            Call BindData(cClassNo.ClassNo)
        End With

    End Sub

    Sub modUpdateCommand(s As Object, e As GridViewUpdateEventArgs)

        '*** CustomerID ***'
        With GV1

            Dim strStdNo As String = .DataKeys.Item(e.RowIndex).Value
            Dim txtStdNo As Label = CType(.Rows(e.RowIndex).FindControl("lblStdNo"), Label)
            '*** Email ***'
            Dim txtFName As TextBox = CType(.Rows(e.RowIndex).FindControl("txtEditName"), TextBox)
            '*** Name ***'
            Dim txtLname As TextBox = CType(.Rows(e.RowIndex).FindControl("txtEditLname"), TextBox)
            '*** CountryCode ***'


            Dim strSQL As String = "UPDATE _Tabain.Dbo.tblStudent " &
            " SET FName = '" & txtFName.Text & "' " &
            " ,LName = '" & txtLname.Text & "' " &
            " WHERE StdNoRef = '" & strStdNo & "'"

            Dim Cn As New SqlConnection(modConn.strCon)
            Dim cmd = New SqlCommand(strSQL, Cn)

            Cn.Open()
            cmd.ExecuteNonQuery()

            .EditIndex = -1
            .ShowFooter = True
        End With
        Me.BindData(cClassNo.ClassNo)
    End Sub

    Sub BindData(strClassNo As String)

        ''strSQL = "Select StdNo from _Tabain.dbo.tblStudentRoom Where StdNo In 
        '            (Select StdNo From _Tabain.Dbo.tblstudentRoom 
        '             Where lavelNo+departNo+roundno+year+room = '" & strClassNo & "')"

        Dim strSQL As String = String.Format(Resources.rsMain.Student, strClassNo).ToString
        Dim DA As New SqlDataAdapter(strSQL, modConn.strCon)
        Dim DT As New DataTable
        DA.Fill(DT)

        '*** BindData to GridView ***'
        Try
            GV1.DataSource = DT
            GV1.DataBind()
            lblShow.Text = "Pass"
        Catch ex As Exception
            lblShow.Text = Err.Description
        End Try



        cClassNo.ClassNo = strClassNo
        lblClassName.Text = "รายชื่อ นักเรียน ระดับชั้น " & cClassNo.LavelName & " " & cClassNo.YearRoom

    End Sub

    'Private Sub ShowData(ClassNo As String)

    '    Dim strSql As String = String.Format(Resources.rsMain.Student, ClassNo).ToString
    '    Dim strConn As String = modConn.strCon

    '    Dim DA As New SqlDataAdapter(strSql, strConn)
    '    Dim DT As New DataTable
    '    DA.Fill(DT)

    '    GV1.DataSource = DT
    '    GV1.DataBind()

    '    Dim cClassNo = New clsClassRoom
    '    cClassNo.ClassNo = strClassNo
    '    lblClassName.Text = "รายชื่อ นักเรียน ระดับชั้น " & cClassNo.LavelName & " " & cClassNo.YearRoom
    'End Sub


    'Protected Sub cmdShow_Click(sender As Object, e As EventArgs) Handles cmdShow.Click
    '    Dim data As String = ""
    '    For Each row As GridViewRow In GV1.Rows
    '        If row.RowType = DataControlRowType.DataRow Then
    '            Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("Chk"), CheckBox)
    '            If chkRow.Checked Then
    '                Dim storid As String = row.Cells(1).Text
    '                Dim storname As String = row.Cells(2).Text
    '                Dim state As String = row.Cells(3).Text
    '                data = (Convert.ToString((Convert.ToString((data & storid) + " ,  ") & storname) + " , ") & state) + "<br>"
    '            End If
    '        End If
    '    Next
    '    lblShow.Text = data
    'End Sub



End Class