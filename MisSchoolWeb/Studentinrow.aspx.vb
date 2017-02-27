Imports System.Data
Imports System.Data.SqlClient



Public Class Studentinrow
    Inherits _PageMainSec

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            showdata()
        End If

    End Sub

    Private Sub showdata()

        Dim dtClassTeacherCon As DataTable = CType(Session("dtteacher"), DataTable)

        Dim strWhere As String

        'For Each dr As DataRow In dtClassTeacherCon.Rows
        '    strWhere = "r.LavelNo+r.DepartNo+r.RoundNo+r.[Year]+r.Room = '" & dr!classNo & "'"
        'Next

        Dim strsql As String = "Select R.no_room,n.StdNo ,p.PrefixNameFull+s.FName+'  '+s.Lname as stdname " &
                                    " From Tabain.Dbo.tblStudent S " &
                                    " INNER JOIN Tabain.Dbo.tblStudentNumber N ON S.StdNoRef = N.StdNoRef " &
                                    " INNER JOIN Tabain.Dbo.tblStudentRoom R On N.StdNo = R.StdNo " &
                                    " LEFT JOIN BaseData.Dbo.tblPrefix P ON S.PrefixNo = P.PrefixNo " &
                                    " INNER JOIN Tabain.Dbo.tblStdStatus T ON R.StatusNo = T.StatusNo  " &
                                    " where r.LavelNo+r.DepartNo+r.RoundNo+r.[Year]+r.Room IN (" & CType(Session("iTeacherCounsel"), clsFindTeacherCounsel).SqlWhereClassNo & ")"


        Dim Da As New SqlDataAdapter(strsql, Resources.rsMain.strConn)
        Dim DT As New DataTable
        Da.Fill(DT)
        stdRowGV.DataSource = DT
        stdRowGV.DataBind()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim strSql As String = "", sqlConn As New SqlConnection(modConn.pstrConn)
        Dim data As String = ""

        DeleteData()

        For Each row As GridViewRow In stdRowGV.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim chkcb As CheckBox = TryCast(row.Cells(0).FindControl("cbrow"), CheckBox)
                If chkcb.Checked = False Then
                    Dim stdno As String = row.Cells(2).Text
                    data = Convert.ToString(stdno)
                    strSql = "INSERT INTO GovernMent.dbo.tblInputStudentNotInRow(DateInput, StdNo) VALUES ('" & dateinput.Text & "','" & stdno & "')"
                    sqlConn.Open()
                    Dim sqlCmd As New SqlCommand(strSql, sqlConn)
                    sqlCmd.ExecuteNonQuery()
                    sqlConn.Close()
                End If
            End If
        Next

        lblmsg.Text = data
        lbldateinput.Text = dateinput.Text
        '
    End Sub

    Private Sub DeleteData()
        Dim strSql As String = "", sqlConn As New SqlConnection(pstrConn)

        Dim iUser As clsUserInfo = CType(Session("iuser"), clsUserInfo)

        strSql = " DELETE from  GovernMent.dbo.tblInputStudentNotInRow " &
                  " where DateInput ='" & dateinput.Text & "' and " &
                  " StdNo in (select StdNo from tabain.dbo.tblstudentroom  " &
                  " where LavelNo+DepartNo+RoundNo+[Year]+Room  in " &
                  " (Select LavelNo+DepartNo+RoundNo+[Year]+Room From GovernMent.Dbo.tblTeacherCounsel " &
                  " Where TeacherNo = '" & iUser.TeacherNo & "' AND sTerm= '" & iUser.TermTabain & "' AND sYear = '" & iUser.YearTabain & "')) "

        Try
            sqlConn.Open()
            Dim sqlCmd As New SqlCommand(strSql, sqlConn)
            sqlCmd.ExecuteNonQuery()
            sqlConn.Close()
        Catch ex As Exception

        End Try


    End Sub

End Class