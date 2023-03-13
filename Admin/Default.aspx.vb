Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Imports System
Imports System.Web
Imports System.IO
Partial Class Admin_Default
    Inherits System.Web.UI.Page
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function Login(ByVal Email As String, ByVal Password As String) As String
        Dim success As String = ""
        Dim IEncrypt As EncryptionUtil = New EncryptionUtil
        Dim userData As UsersData = New UsersData
        Dim userDal As UsersDAL = New UsersDAL

        userData = userDal.FindUserByUserName(Email)

        If userData Is Nothing Then
            success = "User Does not Exist"
            Return success
            Exit Function
        End If

        If userData.UserName <> Email.Trim Then
            success = "Wrong Username"
            Return success
            Exit Function
        Else
            'Decrypt users password with the password key and check if it matches with the supplied password.
            'Dim DecrptedPass As String = IEncrypt.DecryptData(userData.Password, userData.SaltKey)

            If userData.Password = Password Then
                'Encrypting the url
                Dim Encrypt As EncryptionUtil = New EncryptionUtil
                Email = HttpUtility.UrlEncode(Encrypt.Encrypt(userData.Email))

                success = "success/" & Email
                Return success
            Else
                success = "Wrong Password"
                Return success
                Exit Function
            End If
        End If

        Return success
    End Function
End Class
