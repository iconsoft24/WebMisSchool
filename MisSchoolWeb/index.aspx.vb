Option Compare Text

Public Class index
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request.QueryString("Result") IsNot Nothing Then
            Label1.CssClass = "Show"
            Label1.Text = "ชื่อผุ้ใช้งานไม่ถูกต้อง กรุณาตรวจสอบ"
        End If

    End Sub

    Protected Sub cmdLogin_Click(sender As Object, e As EventArgs) Handles cmdLogin.Click

        Dim iUser As New clsUserInfo

        Dim IP As String = Request.ServerVariables("Remote_Addr")
        Dim url As String = Request.ServerVariables("URL")

        iUser.iUser = txtusername.Text
        iUser.iPassword = txtPassword.Text
        iUser.IP = IP

        If iUser.CheckLogin Then

            Session("iUser") = iUser

            Dim M1 As New clsFindTeacherCounsel(iUser.TeacherNo, iUser.TermTabain, iUser.YearTabain)

            Dim dt As DataTable = M1.TeacherCounselClass

            Session("dtTeacher") = dt
            Session("iTeacherCounsel") = M1



            Response.Redirect("Home.aspx")
        Else
            Session("iUser") = Nothing
            Response.Redirect("Index.aspx?Result=Err")
        End If
    End Sub

End Class