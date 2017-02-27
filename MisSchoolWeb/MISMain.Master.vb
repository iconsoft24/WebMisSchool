Public Class MISMain
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Dim iUserinfo As clsUserInfo = CType(Session("iuser"), clsUserInfo)
            Dim iterm As clsUserInfo = CType(Session("TermTabain"), clsUserInfo)
            Dim iyear As clsUserInfo = CType(Session("YearTabain"), clsUserInfo)

            lblUserName.Text = "ยินดีต้อนรับ " & iUserinfo.TeacherNo.ToString & " " & iUserinfo.UserName.ToString
            lblTimeIN.Text = "วันที่ " & Now.ToString("dd MMMM yyyy")
            lblIP.Text = "IP : " & iUserinfo.IP
            lblTermYear.Text = "ปีการศึกษา " & iUserinfo.TermYearTabain
            '//-- แสดงรูป --ฺ
            Dim strFile As String = iUserinfo.TeacherNo & ".JPG"
            picTeacher.ImageUrl = "/picteacher/" & strFile




        End If
    End Sub

    Private Sub MISMain_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Session("iUser") = Nothing
        Session.Abandon()
    End Sub

End Class