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
        iUser.iUser = txtusername.Text
        iUser.iPassword = txtPassword.Text

        If iUser.CheckLogin Then
            Session("iUser") = iUser
            Response.Redirect("Home.aspx")
        Else
            Session("iUser") = Nothing
            Response.Redirect("Index.aspx?Result=Err")
        End If
    End Sub

End Class