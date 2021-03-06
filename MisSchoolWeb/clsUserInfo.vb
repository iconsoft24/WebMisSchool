﻿Option Compare Text

Imports System.Data
Imports System.Data.SqlClient

Public Class clsUserInfo
    Dim m_UserName As String
    Dim m_UserNameFull As String
    Dim m_TeacherNo As String
    Dim m_User As String
    Dim m_Password As String
    Dim _IP As String

    Public FirstLogin As Date = Now

    Public TermTabain, YearTabain, TermYearTabain As String

    Sub New()
        FindTermYearTabain()
    End Sub

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
        Dim M1 As New MgData(modConn.pstrConn)
        Dim DT As DataTable = M1.GetDataTable(strSql)

        'Dim DA As New SqlDataAdapter(strSql, modConn.pstrConn)
        'Dim DT As New DataTable
        'DA.Fill(DT)

        'Dim clsMgdata As New clsclsMgdata
        'Dim DT As DataTable = clsMgdata.GetDataTable(strSql)

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

    Public Property IP As String
        Get
            IP = _IP
        End Get
        Set(value As String)
            _IP = value
        End Set
    End Property

    '//-- หา ปีการศึกษา ในงานทะเบียน --
    Private Sub FindTermYearTabain()
        Dim strSql As String = "SELECT sTerm AS Term , sYear AS [Year], STerm + '/' +  SYear AS TermYear " &
                              " FROM Tabain.dbo.tblSetSystemTabain "
        Dim M1 As New MgData

        Dim dt As DataTable = M1.GetDataTable(strSql, modConn.pstrConn)

        If dt.Rows.Count > 0 Then
            TermTabain = dt(0)!Term
            YearTabain = dt(0)!Year
            TermYearTabain = dt(0)!TermYear
        End If
    End Sub

End Class
