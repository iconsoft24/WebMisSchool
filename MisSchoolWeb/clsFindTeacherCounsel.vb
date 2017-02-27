Option Compare Text

Imports System.Data
Imports System.Data.SqlClient

Public Class clsFindTeacherCounsel

    Private _ClassNo As DataTable

    Public SqlWhereClassNo As String


    Public ReadOnly Property TeacherCounselClass As DataTable
        Get
            Return _ClassNo
        End Get

    End Property

    Sub New(TeacherNO As String, Term As String, year As String)
        FindTeacherCounsel(TeacherNO, Term, year)
    End Sub

    Private Sub FindTeacherCounsel(TeacherNO As String, Term As String, year As String)
        Dim Strsql As String
        Dim strIN As String = ""

        Strsql = "SELECT tc.TeacherNo, tth.Fname  ,tth.Lname," &
                  " tc.LavelNo + tc
                  .DepartNo + tc.RoundNo + tc.[Year] + tc.Room AS ClassNo," &
                  " l.LavelName + ' ' + tc.[Year]  + '/' + tc.Room + ' ' + d.DepartName + ' ' + r.RoundName AS ClassName" &
                  " From Government.dbo.tblTeacherCounSel  TC" &
                  " Left  Join Personal.dbo.tblTeacherHis AS tth ON tth.TeacherNo = tc.TeacherNo" &
                  " Left Join BaseData.dbo.tblLavel AS L ON tc.LavelNo = l.LavelNo " &
                  " Left Join BaseData.dbo.tblDepart AS D ON tc.DepartNo = d.DepartNo " &
                  " Left Join BaseData.dbo.tblRound AS R ON tc.RoundNo = r.RoundNo" &
                  " WHERE sTerm = '" & Term & "'  AND sYear = '" & year & "'  AND TC.TeacherNo = '" & TeacherNO & "'"
        Dim M1 As New MgData
        Dim dt As DataTable = M1.GetDataTable(Strsql, modConn.pstrConn)
        If dt.Rows.Count > 0 Then
            _ClassNo = dt

            For Each dr As DataRow In dt.Rows
                If strIN = "" Then
                    strIN = "'" & dr!ClassNo & "'"
                Else
                    strIN = strIN & ",'" & dr!ClassNo & "'"
                End If
            Next
            If strIN <> "" Then
                SqlWhereClassNo = strIN
            End If
        End If
    End Sub
End Class
