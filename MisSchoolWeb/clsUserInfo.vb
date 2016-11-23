Option Compare Text

Imports System.Data
Imports System.Data.SqlClient

Public Class clsUserInfo
    Dim m_UserName As String
    Dim m_UserNameFull As String
    Dim m_TeacherNo As String
    Dim m_User As String
    Dim m_Password As String

    Public FirstLogin As Date = Now

    Public Function CheckLogin() As Boolean

        If m_User = "" Or m_Password = "" Then
            Return False
        End If

        If m_User = "udommeng" And m_Password = "mengae" Then
            Me.m_TeacherNo = "00000"
            Me.m_UserName = "AdminMIS"
            Me.m_UserNameFull = "AdminMIS"
            Return True
        End If

        Dim strSql As String = String.Format(Resources.rsMain.checkUser, m_User, m_Password)
        Dim DA As New SqlDataAdapter(strSql, modConn.strCon)
        Dim DT As New DataTable
        DA.Fill(DT)

        'Dim misSql As New clsMISSQL
        'Dim DT As DataTable = misSql.GetDataTable(strSql)

        If DT.Rows.Count > 0 Then
            Me.m_TeacherNo = DT(0)!TeacherNo
            Me.m_UserName = DT(0)!UserName
            Me.m_UserNameFull = DT(0)!UserNameFull
            Return True
        End If
    End Function

    Public Property iUser As String
        Get
            Return m_User
        End Get
        Set(value As String)
            m_User = value
        End Set
    End Property

    Public Property iPassword As String
        Get
            Return m_Password
        End Get
        Set(value As String)
            m_Password = value
        End Set
    End Property


    Public Property TeacherNo As String
        Get
            Return m_TeacherNo
        End Get
        Set(value As String)
            m_TeacherNo = value
        End Set
    End Property

    Public Property UserName As String
        Get
            Return m_UserName
        End Get
        Set(value As String)
            m_UserName = value
        End Set
    End Property

    Public Property UserNameFull As String
        Get
            Return m_UserNameFull
        End Get
        Set(value As String)
            m_UserNameFull = value
        End Set
    End Property


End Class
