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

        'Dim strSql As String = "select tt.term+'/'+tt.year as termyear,tt.Course ,tt.AddressCourse ,
        '                            tt.DateCourse,tt.TotalTimeCourse 
        '                             from personal.dbo.tblTeacherTrain tt
        '                             where TeacherNo= '" & Session("iuser").teacherno & "'"

        Dim strsql As String = "Select R.no_room,n.StdNo ,p.PrefixNameFull+s.FName+'  '+s.Lname as stdname
                                From Tabain.Dbo.tblStudent S  
                                INNER JOIN Tabain.Dbo.tblStudentNumber N ON S.StdNoRef = N.StdNoRef  
                                INNER JOIN Tabain.Dbo.tblStudentRoom R On N.StdNo = R.StdNo  
                                LEFT JOIN BaseData.Dbo.tblPrefix P ON S.PrefixNo = P.PrefixNo  
                                INNER JOIN Tabain.Dbo.tblStdStatus T ON R.StatusNo = T.StatusNo  
                                Where R.LavelNo = '1' 
                                And R.DepartNo = '01' And R.RoundNo = '1' And R.Year = '1' 
                                And Room = '1' ORDER BY R.No_Room,R.StdNo"

        Dim Da As New SqlDataAdapter(strsql, Resources.rsMain.strConn)
        Dim DT As New DataTable
        Da.Fill(DT)
        stdRowGV.DataSource = DT
        stdRowGV.DataBind()
    End Sub

    Private Sub stdRowGV_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles stdRowGV.RowCommand

    End Sub
End Class