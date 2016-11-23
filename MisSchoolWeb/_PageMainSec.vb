Public Class _PageMainSec

    Inherits _PageMain

    Private Sub VBPageSec_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("iuser") Is Nothing Then
            Response.Redirect("index.aspx")
        End If
    End Sub
End Class
