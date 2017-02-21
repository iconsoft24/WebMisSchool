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

        'Dim strSql As String = " Select Case SR.no_room,n.StdNo ,p.PrefixNameFull+s.FName+'  '+s.Lname as stdname from Tabain.dbo.tblStudentRoom sr
        '                            INNER Join Tabain.Dbo.tblStudentNumber N ON n.StdNo = sr.StdNo
        '                            inner Join Tabain.Dbo.tblStudent S  on s.StdNoRef =s.StdNoRef 
        '                            Left Join BaseData.Dbo.tblPrefix P ON S.PrefixNo = P.PrefixNo  
        '                            where SR.LavelNo + SR.DepartNo + SR.RoundNo + SR.[Year] + SR.Room  in 
        '                            (Select LavelNo+DepartNo+RoundNo+[Year]+Room From GovernMent.Dbo.tblTeacherCounsel
        '                            Where TeacherNo = '" & Session("iuser").teacherno & "' AND sTerm = '2' AND sYear = '2559')
        '                            ORDER BY SR.No_Room,SR.StdNo"


        Dim strsql As String = "Select R.no_room,n.StdNo ,p.PrefixNameFull+s.FName+'  '+s.Lname as stdname
                                    From Tabain.Dbo.tblStudent S  
                                    INNER JOIN Tabain.Dbo.tblStudentNumber N ON S.StdNoRef = N.StdNoRef  
                                    INNER JOIN Tabain.Dbo.tblStudentRoom R On N.StdNo = R.StdNo  
                                    LEFT JOIN BaseData.Dbo.tblPrefix P ON S.PrefixNo = P.PrefixNo  
                                    INNER JOIN Tabain.Dbo.tblStdStatus T ON R.StatusNo = T.StatusNo  
                                     where r.LavelNo+r.DepartNo+r.RoundNo+r.[Year]+r.Room  in 
                                    (Select LavelNo+DepartNo+RoundNo+[Year]+Room From GovernMent.Dbo.tblTeacherCounsel
                                    Where TeacherNo = '" & Session("iuser").teacherno & "' AND sTerm = '2' AND sYear = '2559')
                                    order by R.No_Room,R.StdNo"




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