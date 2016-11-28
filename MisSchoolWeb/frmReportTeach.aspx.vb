Public Class frmReportTeach
    Inherits _PageMainSec

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim iUserinfo As clsUserInfo = CType(Session("iuser"), clsUserInfo)

        'lblShow.Text = "<H1> ยินดีต้อนรับ " & iUserinfo.TeacherNo.ToString & " " & iUserinfo.UserName.ToString & " " & iUserinfo.UserNameFull.ToString & "</H1>"

        Dim M1 As MISMain = Me.Master
        Dim lbl As Label = M1.FindControl("lblUserName")
        Dim img As Image = M1.FindControl("picTeacher")
        lbl.Text = "ยินดีต้อนรับ " & iUserinfo.TeacherNo.ToString & " " & iUserinfo.UserName.ToString
        '//-- แสดงรูป --ฺ
        Dim strFile As String = iUserinfo.TeacherNo & ".JPG"
        img.ImageUrl = "/picteacher/" & strFile
    End Sub

End Class