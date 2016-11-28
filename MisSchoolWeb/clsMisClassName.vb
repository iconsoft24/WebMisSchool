Imports System.Data
Imports System.Data.SqlClient

Public Class clsMisClassName
    Dim m_ClassNo As String
    Dim m_IsYear2 As Boolean = False   '//-- ตัวกำหนดที่บอกว่า ชั้นปี เป็น 2 หลัก เช่น ปี 10

    Public Property IsYear2 As Boolean
        Get
            Return m_IsYear2
        End Get
        Set(value As Boolean)
            m_IsYear2 = value
        End Set

    End Property

    Public Property ClassNo As String
        Get
            Return m_ClassNo
        End Get
        Set(value As String)
            m_ClassNo = value
        End Set

    End Property

    Public Function LavelNo() As String
        LavelNo = Mid(m_ClassNo, 1, 1)
    End Function

    Public Function DepartNo() As String
        DepartNo = Mid(m_ClassNo, 2, 2)
    End Function

    Public Function RoundNo() As String
        RoundNo = Mid(m_ClassNo, 4, 1)
    End Function

    Public Function Year() As String
        If m_IsYear2 = False Then
            Year = Mid(m_ClassNo, 5, 1)
        Else
            Year = Mid(m_ClassNo, 5, 2)
        End If
    End Function

    Public Function Room() As String
        If m_IsYear2 = False Then
            Room = Mid(m_ClassNo, 6, 3)
        Else
            Room = Mid(m_ClassNo, 7, 3)
        End If
    End Function

    Public Function LavelName(Optional iFull As Boolean = False) As String
        Dim strSql As String = String.Format(Resources.rsMain.tblLavel, Me.LavelNo)
        Dim strLavelName As String
        Dim strConn As String = modConn.strCon

        Dim MisSql As New MgData(strConn)
        Dim DT As DataTable = MisSql.GetDataTable(strSql)

        strLavelName = ""
        If DT.Rows.Count > 0 Then
            If iFull Then
                strLavelName = DT(0)!LavelNameFull
            Else
                strLavelName = DT(0)!LavelName
            End If
        End If

        Return strLavelName
    End Function

    Public Function DepartName() As String
        Dim strSql As String = String.Format(Resources.rsMain.tblDepart, Me.DepartNo)
        Dim strDepartName As String
        Dim strConn As String = modConn.strCon

        Dim MisSql As New MgData(strConn)
        Dim DT As DataTable = MisSql.GetDataTable(strSql)

        strDepartName = ""
        If DT.Rows.Count > 0 Then
            strDepartName = DT(0)!DepartNameFull
        End If

        Return strDepartName
    End Function

    Public Function RoundName() As String
        Dim strSql As String = String.Format(Resources.rsMain.tblDepart, Me.DepartNo)
        Dim strRoundName As String
        Dim strConn As String = modConn.strCon

        Dim MisSql As New MgData(strConn)
        Dim DT As DataTable = MisSql.GetDataTable(strSql)

        strRoundName = ""
        If DT.Rows.Count > 0 Then
            strRoundName = DT(0)!RoundName
        End If

        Return strRoundName
    End Function

    Public Function YearRoom() As String
        Return Me.Year & "/" & Me.Room
    End Function
End Class
