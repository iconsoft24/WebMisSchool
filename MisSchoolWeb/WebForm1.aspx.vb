Imports System.Data
Imports System.Data.SqlClient


Public Class WebForm1
    Inherits System.Web.UI.Page

    Dim m As New clsMisClassName


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim m As New clsMisClassName
        m.ClassNo = "10111012"
        m.IsYear2 = True
        Label1.Text = m.ClassNo & "  room = " & m.Room
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim M1 As New MgData(modConn.pstrConn)

        Dim strsql As String = "Select Top 10 Fname From Tabain.dbo.tblStudent "
        Dim DT As DataTable = M1.GetDataTable(strsql)
        GV1.DataSource = DT
        GV1.DataBind()

    End Sub
End Class