Imports System.Data
Imports System.Data.SqlClient

Public Class TeacherTrain
    Inherits System.Web.UI.Page

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

    Private Sub TeacherTrainGV_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles TeacherTrainGV.RowUpdating

    End Sub

    Protected Sub TeacherTrainGV_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MyBaseGV.SelectedIndexChanged

    End Sub

    Protected Sub TeacherTrainGV_SelectedIndexChanged1(sender As Object, e As EventArgs) Handles MyBaseGV.SelectedIndexChanged

    End Sub



    'Private Sub TeacherTrainGV_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles TeacherTrainGV.PageIndexChanging
    '    TeacherTrainGV.PageIndex = e.NewPageIndex
    '    showData()
    'End Sub


End Class

