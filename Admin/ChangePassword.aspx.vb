Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Imports System
Imports System.Web
Imports System.IO
Partial Class Admin_ChangePassword
    Inherits System.Web.UI.Page
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function Resetpass(ByVal email As String, ByVal password As String) As String
        Dim success As String = ""
        Dim Dal As DigitalLibraryDAL = New DigitalLibraryDAL
        Dim Data As DigitalLibraryData = New DigitalLibraryData

        Dim Decrypt As EncryptionUtil = New EncryptionUtil
        Dim Emails = Decrypt.Decrypt(HttpUtility.UrlDecode(email))

        Dim Datas As DigitalLibraryData = New DigitalLibraryData
        Dim Dals As DigitalLibraryDAL = New DigitalLibraryDAL

        'Datas = Dals.FindUserByEmail_Dataset(Emails)

        'Dim IEncrypt As EncryptionUtil = New EncryptionUtil
        '' Encrypt password and generate Salt Key for the password decryption
        'Dim PassSaltKey() As String = IEncrypt.EncryptData(password)
        ''Assign the encrypted password to the password property 
        'Data.LoginPassword = PassSaltKey(0)
        ''Assign the decryption salt key to saltkey property
        'Data.SaltKey = PassSaltKey(1)
        'Data.QuickPairUsersID = Datas.QuickPairUsersID
        'Dim fetch As Integer = Dal.UpdatePassword(Data)

        'If fetch = 1 Then
        '    success = "Success"
        'Else
        '    success = "Fail"
        'End If

        Return success
    End Function
End Class
