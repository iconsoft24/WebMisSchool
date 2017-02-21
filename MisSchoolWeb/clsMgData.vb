Imports System.Data
Imports System.Data.SqlClient

'//-- วิธีการใช้งาน Get --
'//-- Dim M1 AS NEW MGData(strConn)
'//-- Dim DT as DataTable = M1.GetDataTable("Select * From Tabain.Dbo.tblStudent")

'//-- วิธีการใช้งาน Execu
'//-- Dim M1 As New MgData(strConn)
'//-- Dim strSql as string = "Delete From tblStudent"
'//-- dim Y as integer = M1.Execute(strSql)

Public Class MgData
    Dim strCon As String
    Dim m_ErrorMessage As String
    Dim m_ShowError As Boolean = True
    Dim ProjectName As String = "MisSchool"
    Dim m_AutoClose As Boolean = True
    Dim m_Identity As Integer = 0
    Dim DA As SqlDataAdapter
    Dim Cn As SqlConnection

    Public Sub New()

    End Sub

    Public Sub New(ByVal xCon As String)
        strCon = xCon
    End Sub

    Public ReadOnly Property Identity() As Integer
        Get
            Return m_Identity
        End Get
    End Property

    Public Property AutoClose As Boolean

        Get
            Return m_AutoClose
        End Get
        Set(value As Boolean)
            m_AutoClose = value
        End Set
    End Property

    Public ReadOnly Property ErrorMessage() As String
        Get
            Return m_ErrorMessage
        End Get
    End Property

    Public Property ShowError() As Boolean
        Get
            Return m_ShowError
        End Get
        Set(value As Boolean)
            m_ShowError = value
        End Set
    End Property

    Public Property ConnectionString() As String
        Get
            Return strCon
        End Get
        Set(value As String)
            strCon = value
        End Set
    End Property

    Public Function GetDataTable(strSql As String) As DataTable
        Try
            DA = New SqlDataAdapter(strSql, strCon)
            Dim DT As New DataTable
            DA.Fill(DT)
            Return DT
        Catch ex As Exception
            m_ErrorMessage = ex.Message
            If m_ShowError Then
                MsgBox(ex.Message, 48, ProjectName)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetDataTable(strSql As String, istrConn As String) As DataTable
        Try
            DA = New SqlDataAdapter(strSql, istrConn)
            Dim DT As New DataTable
            DA.Fill(DT)
            Return DT
        Catch ex As Exception
            m_ErrorMessage = ex.Message
            If m_ShowError Then
                MsgBox(ex.Message, 48, ProjectName)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetDataSet(strSql As String) As DataSet
        Try
            DA = New SqlDataAdapter(strSql, strCon)
            Dim DS As New DataSet
            DA.Fill(DS)
            Return DS
        Catch ex As Exception
            m_ErrorMessage = ex.Message
            If m_ShowError Then
                MsgBox(ex.Message, 48, ProjectName)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetdataScalar(ByVal strSql As String) As String
        Dim Result As String = ""
        Try
            Dim con As SqlConnection = New SqlConnection(strCon)
            con.Open()
            Dim cmd As SqlCommand = New SqlCommand(strSql, con)
            Result = cmd.ExecuteScalar
            con.Close()
            Return Result
        Catch ex As Exception
            m_ErrorMessage = ex.Message
            If m_ShowError Then
                MsgBox(ex.Message, 48, ProjectName)
            End If
            Return Result
        End Try
    End Function

    Public Sub ConnectionClose()
        If m_AutoClose Then
            Me.ConnectionRealClose()
        End If
    End Sub

    Public Sub ConnectionRealClose()
        If Not Cn Is Nothing Then
            If Cn.State = ConnectionState.Open Then
                Cn.Close()
            End If
            Cn.Dispose() '//- ขอทำลาย Object --
            Cn = Nothing
        End If
    End Sub

    Protected Overrides Sub Finalize()
        Me.ConnectionRealClose()
        MyBase.Finalize()
    End Sub

    Public Sub ConnectionOpen()
        If Cn Is Nothing Then
            Cn = New SqlConnection(strCon)
        End If
        If Cn.State = ConnectionState.Closed Then
            Try
                Cn.Open()
            Catch ex As Exception
                Cn = Nothing
                m_ErrorMessage = ex.Message
                If m_ShowError = True Then
                    MsgBox(ex.Message, 48, ProjectName)
                End If
            End Try
        End If
    End Sub

    Public Function Execute(strsql As String) As Integer
        Dim cmd As New SqlCommand(strsql)
        Return Me.Execute(cmd)
    End Function

    Public Function Execute(ByVal cmd As SqlCommand) As Integer
        Me.ConnectionOpen()
        cmd.Connection = Cn
        Dim Y As Integer
        Try
            m_Identity = 0
            Y = cmd.ExecuteNonQuery
            If Mid(cmd.CommandText, 1, 6) = "Insert" Then
                Dim cmd2 As New SqlCommand("select @@identity", Cn)
                m_Identity = cmd2.ExecuteScalar
            End If
        Catch ex As Exception
            m_ErrorMessage = ex.Message
            If m_ShowError = True Then
                MsgBox(ex.Message, 48, ProjectName)
            End If
            Y = -1
        End Try
        Me.ConnectionClose()
        Return Y
    End Function

    Public Function CommandCreate(ByVal strsql As String, Optional ByVal ParamType As String = "") As SqlCommand
        Dim cmd As New SqlCommand(strsql)
        If ParamType <> "" Then
            Dim i As Integer
            For i = 1 To Len(ParamType)
                Dim X As String = Mid(ParamType, i, 1)
                Dim P1 As New SqlParameter
                P1.ParameterName = "@P" & i
                Select Case X
                    Case "N"   'Text
                        P1.SqlDbType = SqlDbType.NVarChar
                    Case "T"   'Text
                        P1.SqlDbType = SqlDbType.VarChar
                    Case "I"   'Integer
                        P1.SqlDbType = SqlDbType.Int
                    Case "D"    'Date
                        P1.SqlDbType = SqlDbType.DateTime
                    Case "S"    'Single,Double
                        P1.SqlDbType = SqlDbType.Decimal
                    Case "M"   'Memo
                        P1.SqlDbType = SqlDbType.Text
                    Case "P"    'Image, OLEObject
                        P1.SqlDbType = SqlDbType.Binary
                    Case "B"    'Boolean
                        P1.SqlDbType = SqlDbType.Bit
                End Select
                cmd.Parameters.Add(P1)
            Next

        End If
        Return cmd
    End Function


End Class
