Imports System.Data
Imports System.Data.SqlClient


Public Class TeacherTraining
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim strSql As String = "select tt.term,tt.year,tt.Course ,tt.AddressCourse ,
                                    tt.DateCourse,tt.TotalTimeCourse 
                                     from personal.dbo.tblTeacherTrain tt
                                     where TeacherNo= '" & Session("iuser").teacherno & "'"

            Dim Da As New SqlDataAdapter(strSql, Resources.rsMain.strConn)
            Dim DT As New DataTable
            Da.Fill(DT)
            Da.Dispose()
            DT.Dispose()
        End If
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim strsql As String = "Insert into  personal.dbo.tblTeacherTrain  
                                ([TeacherNo],[Term],[Year],[Course],[AddressCourse],[DateCourse],[TotalTimeCourse],[EditTeacherNo]) VALUES 
                                ('" & Session("iuser").teacherno & "', '" & DTerm.Text & "', '" & DYear.Text & "',
                                '" & txtCourse.Text & "','" & txtAddressCourse.Text & "', '" & txtDateCourse.Text & "',
                                '" & txtTotalTimeCourse.Text & "','" & Session("iuser").teacherno & "')"



        Dim sqlConn As New SqlConnection(Resources.rsMain.strConn)
        sqlConn.Open()
        Dim sqlCmd As New SqlCommand(strsql, sqlConn)
        sqlCmd.ExecuteNonQuery()
        sqlConn.Close()

        lblModalTitle.Text = "แจ้งให้ทราบ"
        lblModalBody.Text = "ทำการบันทึกข้อมูลแล้ว"
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", True)
        cmd01.OnClientClick = "window.location = '/TeacherTrain.aspx'"
        cmd01.Text = "ตกลง"

        upModal.Update()
    End Sub
End Class