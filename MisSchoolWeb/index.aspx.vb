Option Compare Text

Public Class index
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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
            Response.Redirect("NotLogin.aspx")
        End If
    End Sub
End Class