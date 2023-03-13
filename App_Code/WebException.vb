Imports System
Imports System.Web
Imports System.Diagnostics
Imports System.Web.Mail
Imports System.Configuration

Public Class WebException

End Class


' Default exception to be thrown by the website, it will automatically
' log the contents of  the exception to LogError.txt file
' ---
Public Class AppException
    Inherits System.Exception
    ' Constructors
    '- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

    Public Sub New()

        LogError("An unexpected error occurred.")
    End Sub


    Public Sub New(ByVal message As String)
        LogError(message)
    End Sub

    ' Shared Methods
    '- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

    Public Shared Sub LogError(ByVal message As String)

        ' Get the current HTTPContext
        Dim context As HttpContext = HttpContext.Current

        ' Get location of ErrorLogFile from Web.config file
        Dim filePath As String = context.Server.MapPath( _
          CStr(ConfigurationManager.AppSettings( _
             "ErrorLogFile")))

        ' Calculate GMT offset
        Dim gmtOffset As Integer = _
          DateTime.Compare(DateTime.Now, DateTime.UtcNow)

        Dim gmtPrefix As String
        If gmtOffset > 0 Then
            gmtPrefix = "+"
        Else
            gmtPrefix = ""
        End If

        ' Create DateTime string
        Dim errorDateTime As String = _
          DateTime.Now.Year.ToString & "." & _
          DateTime.Now.Month.ToString & "." & _
          DateTime.Now.Day.ToString & " @ " & _
          DateTime.Now.Hour.ToString & ":" & _
          DateTime.Now.Minute.ToString & ":" & _
          DateTime.Now.Second.ToString & _
          " (GMT " & gmtPrefix & gmtOffset.ToString & ")"
        ' Write message to error file
        Try
            Dim sw As New System.IO.StreamWriter(filePath, True)
            sw.WriteLine("## " & errorDateTime & " ## " & message & " ##")
        Catch ex As Exception
            ex.ToString() 'Leave this error for God to handle
        End Try

    End Sub

End Class


