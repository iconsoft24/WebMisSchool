Public Class _PageMain
    Inherits System.Web.UI.Page

    Public SchoolCode As String

    Private Sub VBPage_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim url As String = Request.ServerVariables("URL")
            Dim IP As String = Request.ServerVariables("Remote_Addr")
        End If
    End Sub

    '//-- ให้เขียน Code ที่่นี่เพราะเกิดก่อน PreInit --
    Private Sub VBPage_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        Me.MasterPageFile = "~/MISMain.Master"
    End Sub
End Class
