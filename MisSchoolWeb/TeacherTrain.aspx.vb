Imports System.Data
Imports System.Data.SqlClient

Public Class TeacherTrain
    Inherits _PageMainSec

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            showData()

        End If
    End Sub

    Private Sub showData()
        Dim strSql As String = "select tt.term+'/'+tt.year as termyear,tt.Course ,tt.AddressCourse ,
                                    tt.DateCourse,tt.TotalTimeCourse 
                                     from personal.dbo.tblTeacherTrain tt
                                     where TeacherNo= '" & Session("iuser").teacherno & "'"

        Dim Da As New SqlDataAdapter(strSql, Resources.rsMain.strConn)
        Dim DT As New DataTable
        Da.Fill(DT)
        TeacherTrainGV.DataSource = DT
        TeacherTrainGV.DataBind()

    End Sub


End Class

