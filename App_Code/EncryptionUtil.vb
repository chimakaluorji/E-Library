''''''''''''''''''''''''''''''''''''''''''''''''''
'' Author: Chima kalu-orji
'' Date: 18-09-2008
'' The Class is a utility that handles data encryption and decryption.
''''''''''''''''''''''''''''''''''''''''''''''''''
Imports Microsoft.VisualBasic
Imports Persephone.Security.Utilities.Cryptography
Imports System.Security.Cryptography
Imports System.IO
Public Class EncryptionUtil

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'This method encrypts data and generates a key for for decrypting it. 
    'It accepts the data to be encrypted as a parameter and returns a sring array containg the encrypted data and the key for decrypting it.
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Function EncryptData(ByVal DataToEncrypt As String) As String()
        Dim RetArr() As String = {"", ""}
        Dim IEncrypt As ICryptoHelper = CryptoFactory.Create(CryptographyAlgorithm.Rijndael)
        'Encrypt data and save the encrypted data into the first position of the array.
        RetArr(0) = IEncrypt.Encrypt(DataToEncrypt, StringEncodingType.Base64)
        'Generate the Key for decrypting the data and save it into the second position of the array.
        RetArr(1) = IEncrypt.Entropy  ' Note: This may be null if using the DPAPI
        Return RetArr
    End Function

    ''' <summary>
    '''This method decrypts Encrypted Data.
    '''It accepts EncryptedData and Key for decrypting it as parameters and      '''returns the decrypted data as string
    ''' </summary>
    ''' <param name="EncryptedData"></param>
    ''' <param name="Key"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DecryptData(ByVal EncryptedData As String, ByVal Key As String) As String
        ' decrypt the data using the Key string
        Dim IDecrypt As ICryptoHelper = CryptoFactory.Create(CryptographyAlgorithm.Rijndael, Key)
        Dim decryptedData As String = IDecrypt.Decrypt(EncryptedData, StringEncodingType.Base64)
        Return decryptedData

    End Function

    Public Function Encrypt(s As String) As String
        Dim rijnKey As Byte() = {&H1, &H2, &H3, &H4, &H5, &H6, &H7, &H8, &H9, &H10, &H11, &H12, &H13, &H14, &H15, &H16}
        Dim rijnIV As Byte() = {&H1, &H2, &H3, &H4, &H5, &H6, &H7, &H8, &H9, &H10, &H11, &H12, &H13, &H14, &H15, &H16}

        'Creates the default implementation, which is RijndaelManaged.
        Dim rijn As SymmetricAlgorithm = SymmetricAlgorithm.Create()
        Dim encrypted() As Byte
        Using msEncrypt As New MemoryStream()
            Dim csEncrypt As New CryptoStream(msEncrypt, rijn.CreateEncryptor(rijnKey, rijnIV), CryptoStreamMode.Write)
            Using swEncrypt As New StreamWriter(csEncrypt)
                'Write all data to the stream.
                swEncrypt.Write(s)
            End Using
            encrypted = msEncrypt.ToArray()
        End Using

        ' You cannot convert the byte to a string or you will get strange characters so base64 encode the string
        ' Replace any + that will lead to the error
        Return Convert.ToBase64String(encrypted).Replace("+", "BIN00101011BIN")
    End Function

    Public Function Decrypt(S As String) As String

        Dim rijnKey As Byte() = {&H1, &H2, &H3, &H4, &H5, &H6, &H7, &H8, &H9, &H10, &H11, &H12, &H13, &H14, &H15, &H16}
        Dim rijnIV As Byte() = {&H1, &H2, &H3, &H4, &H5, &H6, &H7, &H8, &H9, &H10, &H11, &H12, &H13, &H14, &H15, &H16}

        If S = "" Then
            Return S
        End If
        ' Turn the cipherText into a ByteArray from Base64
        Dim cipherText As Byte()
        Try
            ' Replace any + that will lead to the error
            cipherText = Convert.FromBase64String(S.Replace("BIN00101011BIN", "+"))
        Catch ex As Exception
            ' There is a problem with the string, perhaps it has bad base64 padding
            Return S
        End Try
        'Creates the default implementation, which is RijndaelManaged.
        Dim rijn As SymmetricAlgorithm = SymmetricAlgorithm.Create()
        Try
            ' Create the streams used for decryption.
            Using msDecrypt As New MemoryStream(cipherText)
                Using csDecrypt As New CryptoStream(msDecrypt, rijn.CreateDecryptor(rijnKey, rijnIV), CryptoStreamMode.Read)
                    Using srDecrypt As New StreamReader(csDecrypt)
                        ' Read the decrypted bytes from the decrypting stream and place them in a string.
                        S = srDecrypt.ReadToEnd()
                    End Using
                End Using
            End Using
        Catch E As CryptographicException
            Return S
        End Try
        Return S
    End Function
End Class
