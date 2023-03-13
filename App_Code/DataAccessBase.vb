'This is the base class for creating connection to database.
'All classes accessing database must inherit this class and call the constructor
'@author: Kalu Nsi Idika
'@date: 20-01-2009
Imports Microsoft.VisualBasic
Imports System.Configuration

Public Class DataAccessBase
    Public ConStr As String = String.Empty
    'Declare Transaction log flag
    Public LogTxnFlag As String = String.Empty
    'Declare Error log flag
    Public LogErrorFlag As String = String.Empty
    'Declare Current Academic Session Name
    Public SessionName As String = String.Empty
    'Declare the Academic Session for which admission is being applied
    Public PostUMESessionName As String = String.Empty
    ''' <summary>
    ''' Retrieves connection string from web config
    ''' </summary>
    ''' <remarks>Returns the credentials for accessing data store.</remarks>
    Sub New()
        'Retrieve the connection string from the web config file.
        ConStr = ConfigurationManager.ConnectionStrings("ResultManagerConnectionString").ConnectionString
        'Retrieve the Transaction log flag from the web config file.
        LogTxnFlag = ConfigurationManager.AppSettings("LogTxnFlag")
        'Retrieve the Error log flag from the web config file.
        LogErrorFlag = ConfigurationManager.AppSettings("LogErrorFlag")
        'Retrieve the Current Academic Session Year from the web config file.
        SessionName = ConfigurationManager.AppSettings("SessionName")

        'Retrieve the Academic Session for which admission is being applied
        PostUMESessionName = ConfigurationManager.AppSettings("PostUMESessionName")
    End Sub
End Class
