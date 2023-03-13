Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Imports System
Imports System.Web
Imports System.IO
Partial Class Home_Default
    Inherits System.Web.UI.Page
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function Login(ByVal LoginID As String) As String
        Dim success As String = ""

        If LoginID = "123456" Then
            success = "success"
            Return success
        Else
            success = "fail"
            Return success
            Exit Function
        End If

        Return success
    End Function
End Class
