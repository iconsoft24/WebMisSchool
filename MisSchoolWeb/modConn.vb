Module modConn
    Public Function pstrConn() As String
        Return ConfigurationManager.ConnectionStrings("MisSchool").ToString
        'Return Resources.rsMain.strConn
    End Function
End Module
