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

        'Dim strSql As String = "SELECT  A.HisNo,TermYear,TimeIN,c.DintComeType " &
        '                        " From Personal.dbo.tblHisMain AS A " &
        '                        " LEFT JOIN Personal.dbo.tblHisDetail AS B ON a.HisNo=b.HisNo " &
        '                        " LEFT JOIN Personal.dbo.tblDintComeType AS C ON b.DintComeTypeNo = c.DintComeTypeNo " &
        '                        " WHERE CONVERT(varchar(10),A.DateHis,102) = '2016.09.27' AND B.TeacherNo = 'T45003' "
        'Dim M1 As New MgData(modConn.strCon)
        'Dim DT As DataTable = M1.GetDataTable(strSql)

        'If DT.Rows.Count > 0 Then
        '    GV1.DataSource = DT
        '    GV1.DataBind()
        'End If

        If Not Page.IsPostBack Then
            Dim strSql As String = "select pf.PrefixNameFull,th.FName,th.Lname,th.NickName,th.idno,th.dateofBirth
                                    from personal.dbo.tblteacherhis  th
                                    inner join Basedata.dbo.tblPrefix pf on th.PrefixNo=pf.PrefixNo 
                                    where th.teacherNo='" & Session("iuser").teacherno & "'"
            'Session("iuser").teacherno

            Dim Da As New SqlDataAdapter(strSql, Resources.rsMain.strConn)
            Dim DT As New DataTable
            Da.Fill(DT)
            If DT.Rows.Count > 0 Then
                Dim Dr As DataRow = DT.Rows(0)

                txtTeacherPrefix.Text = Dr!PrefixNameFull & ""
                txtTeacherName.Text = Dr!Fname & ""
                txtTeacherLName.Text = Dr!Lname & ""
                txtTeacherNickname.Text = Dr!nickname & ""
                txtIDNo.Text = Dr!IDNo & ""
                txtDateBirth.Text = Dr!DateofBirth & ""
            End If

            Da.Dispose()
            DT.Dispose()
        End If
    End Sub

    Protected Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim strSql As String = "UPDATE personal.dbo.tblteacherhis SET 
                        Fname = '" & txtTeacherName.Text & "',
                        Lname = '" & txtTeacherLName.Text & "',
                        Nickname = '" & txtTeacherNickname.Text & "',
                        idno = '" & txtIDNo.Text & "',
                        dateofBirth = '" & txtDateBirth.Text & "'
                        where teacherno='" & Session("iuser").teacherno & "'"

        Dim sqlConn As New SqlConnection(Resources.rsMain.strConn)
        sqlConn.Open()
        Dim sqlCmd As New SqlCommand(strSql, sqlConn)
        sqlCmd.ExecuteNonQuery()
        sqlConn.Close()

        lblModalTitle.Text = "แจ้งให้ทราบ"
        lblModalBody.Text = "ทำการบันทึกข้อมูลแล้ว"
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", True)
        cmd01.OnClientClick = "window.location = '/Home.aspx'"
        cmd01.Text = "ตกลง"

        cmd02.Visible = False
        cmd03.Visible = False
        upModal.Update()

    End Sub
End Class