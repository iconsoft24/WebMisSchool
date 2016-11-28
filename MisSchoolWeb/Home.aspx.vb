Imports System.Data
Imports System.Data.SqlClient

Public Class Home
    Inherits _PageMainSec

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim iUserinfo As clsUserInfo = CType(Session("iuser"), clsUserInfo)

        ''lblShow.Text = "<H1> ยินดีต้อนรับ " & iUserinfo.TeacherNo.ToString & " " & iUserinfo.UserName.ToString & " " & iUserinfo.UserNameFull.ToString & "</H1>"

        'Dim M1 As MISMain = Me.Master
        'Dim lbl As Label = M1.FindControl("lblUserName")
        'Dim img As Image = M1.FindControl("picTeacher")
        'lbl.Text = "ยินดีต้อนรับ " & iUserinfo.TeacherNo.ToString & " " & iUserinfo.UserName.ToString
        ''//-- แสดงรูป --ฺ
        'Dim strFile As String = iUserinfo.TeacherNo & ".JPG"
        'img.ImageUrl = "/picteacher/" & strFile

        Dim strSql As String = "SELECT  A.HisNo,TermYear,TimeIN,c.DintComeType " &
                                " From Personal.dbo.tblHisMain AS A " &
                                " LEFT JOIN Personal.dbo.tblHisDetail AS B ON a.HisNo=b.HisNo " &
                                " LEFT JOIN Personal.dbo.tblDintComeType AS C ON b.DintComeTypeNo = c.DintComeTypeNo " &
                                " WHERE CONVERT(varchar(10),A.DateHis,102) = '2016.09.27' AND B.TeacherNo = 'T45003' "
        Dim M1 As New MgData(modConn.strCon)
        Dim DT As DataTable = M1.GetDataTable(strSql)

        If DT.Rows.Count > 0 Then
            GV1.DataSource = DT
            GV1.DataBind()
        End If

    End Sub


End Class