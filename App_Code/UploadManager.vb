'This class manages file upload and download.
'@author: Kalu Nsi Idika
'@date: 20-11-2008
Imports System
Imports System.Web
Imports System.Diagnostics
Imports System.IO
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class UploadManager    
    Inherits DataAccessBase
    Sub New()
        MyBase.New()
    End Sub
    ''' <summary>
    ''' Uploads Result Sheet to web server with WebControls.FileUpload control.
    ''' </summary>
    ''' <param name="file"></param>
    ''' <param name="message"></param>
    ''' <param name="CourseCode"></param>
    ''' <param name="Semester"></param>
    ''' <param name="SessionName"></param>
    ''' <returns></returns>
    ''' <remarks>Boolean</remarks>
    Public Shared Function UploadResultSheet(ByRef file As System.Web.UI.WebControls.FileUpload, ByRef message As String, ByVal CourseCode As String, ByVal Semester As String, ByVal SessionName As String, ByVal Level As String) As Boolean

        'Check if FileUpload control has file to upload.
        If Not file.HasFile Then
            message = "No file was selected for upload."
            Return False
        End If

        Dim sessionid As String

        ' Get the current HTTPContext and the session ID
        Dim context As HttpContext = HttpContext.Current
        sessionid = context.Session.SessionID
        'Get the file extension
        Dim fileExtension As String = System.IO.Path.GetExtension(file.FileName).ToLower()
        Dim allowedExtension As String = ".xls"

        'For counter = 0 To allowedExtensions.Length - 1 Step 1
        If fileExtension = allowedExtension Then

            Try
                'Specify the directory to save file to.
                Dim path As String = context.Server.MapPath("~/UploadedExcelSheets/")
                'Generate unique file name for the file in FileUpload control
                Dim filename As String = sessionid & "_" & CourseCode.Trim & "_" & Semester.Trim & "_" & Level & "_" & SessionName.Trim.Substring(0, 4) & fileExtension
                Dim fullpath As String = path & filename
                'Save file
                file.PostedFile.SaveAs(fullpath)
                message = "~/UploadedExcelSheets/" + filename
                Return True
            Catch ex As Exception
                'If occurs, log it and return false
                AppException.LogError(ex.Message)
                message = "Result could not be uploaded at the moment."
                Return False
            End Try
        Else
            message = "Invalid Document format! Only Result Sheets in MS Excel format are allowed"
            Return False
        End If


    End Function

    ''' <summary>
    ''' Uploads documemt to web server with WebControls.FileUpload control.
    ''' </summary>
    ''' <param name="file"></param>
    ''' <param name="message"></param>
    ''' <returns></returns>
    ''' <remarks>Boolean</remarks>
    Public Shared Function UploadFile(ByRef file As System.Web.UI.WebControls.FileUpload, ByRef message As String, ByVal RegNo As String, ByVal CredentialType As String) As Boolean
        'Check if FileUpload control has file to upload.
        If Not file.HasFile Then
            message = "No file was selected for upload."
            Return False
        End If

        Dim MaxSize As Integer = file.PostedFile.ContentLength
        If MaxSize > "20971" Then
            message = "The file size cannot exceed 20 KB. The width and the height must be between 100px to 120px. Use Microsoft Office Picture Manager to edit it."
            Return False
        End If

        Dim sessionid As String

        ' Get the current HTTPContext and the session ID
        Dim context As HttpContext = HttpContext.Current
        sessionid = context.Session.SessionID
        'Get the file extension
        Dim fileExtension As String = System.IO.Path.GetExtension(file.FileName).ToLower()
        Dim allowedExtensions As String() = {".jpeg", ".jpg", ".doc", ".pdf", ".txt", ".png"}
        Dim counter As Integer

        For counter = 0 To allowedExtensions.Length - 1 Step 1
            If fileExtension = allowedExtensions(counter) Then
                'Check the file type.
                If fileExtension = ".jpg" Or fileExtension = ".jpeg" Then
                    Dim myImage As System.Drawing.Bitmap
                    'Try
                    'Specify the directory to save file to.
                    Dim path As String = context.Server.MapPath("~/UploadedDocuments/")
                    'Generate unique file name for the file in FileUpload control
                    Dim filename As String = sessionid & "_" & RegNo.Substring(5) & "_" & CredentialType & ".jpg"
                    Dim fullpath As String = path & filename
                    'Save file
                    file.PostedFile.SaveAs(fullpath)

                    myImage = New System.Drawing.Bitmap(fullpath)
                    'Check image size after saving and report accordingly.
                    If myImage.Width > 0 Then
                        message = "~/UploadedDocuments/" + filename
                        Return True
                    Else
                        message = "Invalid image size! "
                        Return False
                    End If

                    'Catch ex As Exception
                    '    'If error occurs, log it and return false
                    '    AppException.LogError(ex.Message)
                    '    message = "Image could not be uploaded at the moment."
                    '    Return False
                    'Finally
                    '    'Clean up.
                    '    'myImage.Dispose()
                    'End Try
                    Exit For
                Else
                    Try
                        'Specify the directory to save file to.
                        Dim path As String = context.Server.MapPath("~/UploadedDocuments/")
                        'Generate unique file name for the file in FileUpload control
                        Dim filename As String = sessionid & "_" & RegNo.Substring(5) & "_" & CredentialType & fileExtension
                        Dim fullpath As String = path & filename
                        'Save file
                        file.PostedFile.SaveAs(fullpath)
                        message = "~/UploadedDocuments/" + filename
                        Return True
                    Catch ex As Exception
                        'If occurs, log it and return false
                        AppException.LogError(ex.Message)
                        message = "File could not be uploaded at the moment."
                        Return False
                    End Try
                End If
            End If
        Next

        message = "Invalid Document format! Only documents with Extension: '.jpeg', '.jpg', '.doc', '.pdf', '.txt' are allowed"
        Return False
    End Function

    '''' <summary>
    '''' Uploads documemt to web server with HtmlControls.HtmlInputFile.
    '''' </summary>
    '''' <param name="file"></param>
    '''' <param name="message"></param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Shared Function UploadFile(ByRef file As System.Web.UI.HtmlControls.HtmlInputFile, ByRef message As String, ByVal RegNo As String, ByVal CredentialType As String) As Boolean
    '    'Check if FileUpload control has file to upload.
    '    If file.PostedFile.ContentLength = 0 Then
    '        message = "No file was selected for upload."
    '        Return False
    '    End If

    '    Dim sessionid As String

    '    ' Get the current HTTPContext
    '    Dim context As HttpContext = HttpContext.Current
    '    sessionid = context.Session.SessionID
    '    'Get the file extension
    '    Dim fileExtension As String = System.IO.Path.GetExtension(file.PostedFile.FileName).ToLower()
    '    Dim allowedExtensions As String() = {".jpeg", ".jpg", ".doc", ".pdf", ".txt"}
    '    Dim counter As Integer

    '    For counter = 0 To allowedExtensions.Length - 1 Step 1
    '        If fileExtension = allowedExtensions(counter) Then
    '            'Check the file type.
    '            If fileExtension = ".jpg" Or fileExtension = ".jpeg" Then
    '                Dim myImage As System.Drawing.Bitmap
    '                Try
    '                    'Specify the directory to save file to.
    '                    Dim path As String = context.Server.MapPath("~/UploadedDocuments/")
    '                    'Generate unique file name for the file in FileUpload control
    '                    Dim filename As String = sessionid & "_" & RegNo.Substring(5) & "_" & CredentialType & ".jpg"
    '                    Dim fullpath As String = path & filename
    '                    'Save file
    '                    file.PostedFile.SaveAs(fullpath)

    '                    myImage = New System.Drawing.Bitmap(fullpath)
    '                    'Check image size after saving and report accordingly.
    '                    If myImage.Width > 0 Then

    '                        message = "~/UploadedDocuments/" + filename
    '                        Return True
    '                    Else
    '                        message = "Invalid image format!"
    '                        Return False
    '                    End If

    '                Catch ex As Exception
    '                    'If occurs, log it and return false
    '                    AppException.LogError(ex.Message)
    '                    message = "Image could not be uploaded at the moment."
    '                    Return False
    '                Finally
    '                    'Do clean up
    '                    myImage.Dispose()
    '                End Try
    '                Exit For
    '            Else
    '                Try
    '                    'Specify the directory to save file to.
    '                    Dim path As String = context.Server.MapPath("~/UploadedDocuments/")
    '                    'Generate unique file name for the file in FileUpload control
    '                    Dim filename As String = sessionid & "_" & RegNo.Substring(5) & "_" & CredentialType & fileExtension
    '                    Dim fullpath As String = path & filename
    '                    'Save file
    '                    file.PostedFile.SaveAs(fullpath)
    '                    message = "~/UploadedDocuments/" + filename
    '                Catch ex As Exception
    '                    'If occurs, log it and return false
    '                    AppException.LogError(ex.Message)
    '                    message = "File could not be uploaded at the moment."
    '                    Return False
    '                End Try
    '                Exit For
    '            End If
    '        End If
    '    Next

    '    message = "Invalid image format! "
    '    Return False

    'End Function

    Public Shared Function getImage(ByVal strpath As String) As Byte()
        Try
            If Len(strpath) <> 0 Then
                Dim fil As FileStream = New FileStream(strpath, FileMode.Open, FileAccess.ReadWrite)
                Dim filBty(fil.Length) As Byte
                fil.Read(filBty, 0, fil.Length)
                fil.Close()
                fil = Nothing
                Return filBty
            Else
                Return GetDefaultImage()
            End If
        Catch ex As Exception
            AppException.LogError(ex.Message)
            Return GetDefaultImage()
        End Try

    End Function
    Public Shared Function GetDefaultImage() As Byte()
        Dim StringForByte() As Byte
        Dim Encoder As New System.Text.ASCIIEncoding
        StringForByte = Encoder.GetBytes("KALU")
        Return StringForByte
    End Function
    Public Sub CreateTest(ByVal filename As String)
        Dim params() As SqlParameter = {New SqlParameter("@filename", filename)}
        Dim sql As String = "Insert into TestUpLoad (fileName) values (@filename)"
        SqlHelper.ExecuteNonQuery(ConStr, Data.CommandType.Text, sql, params)
    End Sub
    ''' <summary>
    ''' Uploads Result Sheet to web server with WebControls.FileUpload control.
    ''' </summary>
    ''' <param name="file"></param>
    ''' <param name="message"></param>
    ''' <param name="CourseCode"></param>
    ''' <param name="Semester"></param>
    ''' <param name="SessionName"></param>
    ''' <returns></returns>
    ''' <remarks>Boolean</remarks>
    Public Shared Function UploadResultSheet1(ByRef file As System.Web.UI.WebControls.FileUpload, ByRef message As String, ByVal CourseCode As String, ByVal Semester As String, ByVal ContinousAssesment As String, ByVal SessionName As String) As Boolean

        'Check if FileUpload control has file to upload.
        If Not file.HasFile Then
            message = "No file was selected for upload."
            Return False
        End If

        Dim sessionid As String

        ' Get the current HTTPContext and the session ID
        Dim context As HttpContext = HttpContext.Current
        sessionid = context.Session.SessionID
        'Get the file extension
        Dim fileExtension As String = System.IO.Path.GetExtension(file.FileName).ToLower()
        Dim allowedExtension As String = ".xls"

        'For counter = 0 To allowedExtensions.Length - 1 Step 1
        If fileExtension = allowedExtension Then

            Try
                'Specify the directory to save file to.
                Dim path As String = context.Server.MapPath("~/UploadedExcelSheets/")
                'Generate unique file name for the file in FileUpload control
                Dim filename As String = sessionid & "_" & CourseCode.Trim & "_" & Semester.Trim & "_" & ContinousAssesment.Trim & "_" & SessionName.Trim.Substring(0, 4) & fileExtension
                Dim fullpath As String = path & filename
                'Save file
                file.PostedFile.SaveAs(fullpath)
                message = "~/UploadedExcelSheets/" + filename
                Return True
            Catch ex As Exception
                'If occurs, log it and return false
                AppException.LogError(ex.Message)
                message = "Result could not be uploaded at the moment."
                Return False
            End Try
        Else
            message = "Invalid Document format! Only Result Sheets in MS Excel format are allowed"
            Return False
        End If


    End Function
    ''' <summary>
    ''' Uploads eBook to web server with WebControls.FileUpload control.
    ''' </summary>
    ''' <param name="file"></param>
    ''' <param name="message"></param>
    ''' <returns>Boolean</returns>
    Public Shared Function UploadeBook(ByRef file As System.Web.UI.WebControls.FileUpload, ByRef message As String) As Boolean

        'Check if FileUpload control has file to upload.
        If Not file.HasFile Then
            message = "No file was selected for upload."
            Return False
        End If

        Dim sessionid As String

        ' Get the current HTTPContext and the session ID
        Dim context As HttpContext = HttpContext.Current
        sessionid = context.Session.SessionID

        'Get the file extension
        Dim fileExtension As String = System.IO.Path.GetExtension(file.FileName).ToLower()
        Dim notAllowedExtension As String = ".jpeg"

        'Check if the file to be uploaded could be malicious
        If fileExtension <> ".pdf" Then
            message = "Invalid Document format! The file must be in PDF Format"
            Return False
        End If

        Try
            'Specify the directory to save file to.
            Dim path As String = context.Server.MapPath("~/eBooks/")
            'Generate unique file name for the file in FileUpload control
            Dim filename As String = sessionid & "_" & file.FileName
            Dim fullpath As String = path & filename
            'Save file
            file.PostedFile.SaveAs(fullpath)
            message = "~/eBooks/" + filename
            Return True
        Catch ex As Exception
            'If occurs, log it and return false
            AppException.LogError(ex.Message)
            message = "eBook could not be uploaded at the moment."
            Return False
        End Try
        'End If
    End Function
    ''' <summary>
    ''' Uploads eBook to web server with WebControls.FileUpload control.
    ''' </summary>
    ''' <param name="file"></param>
    ''' <param name="message"></param>
    ''' <returns>Boolean</returns>
    Public Shared Function UploadeBookPicture(ByRef file As System.Web.UI.WebControls.FileUpload, ByRef message As String) As Boolean

        'Check if FileUpload control has file to upload.
        If Not file.HasFile Then
            message = "No file was selected for upload."
            Return False
        End If

        Dim sessionid As String

        ' Get the current HTTPContext and the session ID
        Dim context As HttpContext = HttpContext.Current
        sessionid = context.Session.SessionID
        'Get the file extension
        Dim fileExtension As String = System.IO.Path.GetExtension(file.FileName).ToLower()
        'Dim notAllowedExtension As String = ".jpeg"

        'Check if the file to be uploaded could be malicious
        If fileExtension <> ".jpg" Then
            If fileExtension <> ".jpeg" Then
                message = "Invalid Document format! The file must be in JPG or JPEG Format"
                Return False
            End If
        End If

        Try
            'Specify the directory to save file to.
            Dim path As String = context.Server.MapPath("~/eBookPicture/")
            'Generate unique file name for the file in FileUpload control
            Dim filename As String = sessionid & "_" & file.FileName
            Dim fullpath As String = path & filename
            'Save file
            file.PostedFile.SaveAs(fullpath)
            message = "~/eBookPicture/" + filename
            Return True
        Catch ex As Exception
            'If occurs, log it and return false
            AppException.LogError(ex.Message)
            message = "eBook could not be uploaded at the moment."
            Return False
        End Try
        'End If
    End Function
    Public Shared Function UploadSheetResult(ByRef file As System.Web.UI.WebControls.FileUpload, ByRef message As String, ByRef fileExt As String, ByRef RetPathName As String, ByVal Session As String, ByVal Semester As String, ByVal CourseCode As String, ByVal DeptID As String) As Boolean

        'Check if FileUpload control has file to upload.
        If Not file.HasFile Then
            message = "No file was selected for upload."
            Return False
        End If
        'Dim fullPath As String
        'fullPath = My.Computer.FileSystem.CombinePath("C:\", file.PostedFile.FileName)
        'RetPathName = Path.GetDirectoryName(file.PostedFile.FileName)

        'Dim MaxSize As Integer = FU.PostedFile.ContentLength
        'If MaxSize > "2097152" Then
        '    lblUpload.Text = "The file size cannot exceed 2 MB"
        '    btnSave.Focus()
        '    GoTo 99
        'End If

        Dim sessionid As String

        ' Get the current HTTPContext and the session ID
        Dim context As HttpContext = HttpContext.Current
        sessionid = context.Session.SessionID
        'Get the file extension
        Dim fileExtension As String = System.IO.Path.GetExtension(file.FileName).ToLower()
        Dim allowedExtension As String = ".xls"

        fileExt = System.IO.Path.GetExtension(file.FileName).ToLower()
        Dim allowedSecondExtension As String = ".xlsx"

        'For counter = 0 To allowedExtensions.Length - 1 Step 1
        If fileExtension = allowedExtension Or fileExtension = allowedSecondExtension Then

            'Try
            'Specify the directory to save file to.
            Dim path As String = context.Server.MapPath("~/UploadedExcelSheets/")
            'Generate unique file name for the file in FileUpload control
            Dim filename As String = sessionid & "_" & Semester.Trim & "_" & CourseCode.Trim & "_" & DeptID.Trim & "_" & fileExtension
            Dim fullpath As String = path & filename
            'Save file
            file.PostedFile.SaveAs(fullpath)
            message = "~/UploadedExcelSheets/" + filename
            RetPathName = HttpContext.Current.Server.MapPath("~/UploadedExcelSheets/" & filename)
            Return True
            'Catch ex As Exception
            '    'If occurs, log it and return false
            '    AppException.LogError(ex.Message)
            '    message = "Result could not be uploaded at the moment."
            '    Return False
            'End Try
        Else
            message = "Invalid Document format! Only Result Sheets in MS Excel format are allowed"
            Return False
        End If


    End Function
    Public Shared Function UploadSheetAdmissionList(ByRef file As System.Web.UI.WebControls.FileUpload, ByRef message As String, ByRef fileExt As String, ByRef RetPathName As String) As Boolean

        'Check if FileUpload control has file to upload.
        If Not file.HasFile Then
            message = "No file was selected for upload."
            Return False
        End If

        Dim sessionid As String

        ' Get the current HTTPContext and the session ID
        Dim context As HttpContext = HttpContext.Current
        sessionid = context.Session.SessionID
        'Get the file extension
        Dim fileExtension As String = System.IO.Path.GetExtension(file.FileName).ToLower()
        fileExt = System.IO.Path.GetExtension(file.FileName).ToLower()
        Dim allowedExtensionxls As String = ".xls"
        Dim allowedExtensionxlsx As String = ".xlsx"

        'For counter = 0 To allowedExtensions.Length - 1 Step 1
        If fileExtension = allowedExtensionxls Or fileExtension = allowedExtensionxlsx Then

            'Try
            'Specify the directory to save file to.
            Dim Rand As New Random
            Dim NextRand As String = Rand.Next()

            Dim path As String = context.Server.MapPath("~/UploadAdmissionList/")
            'Generate unique file name for the file in FileUpload control
            Dim filename As String = sessionid & "_" & NextRand & "_" & "_AdmissionListOrStudent_" & file.FileName & fileExtension
            Dim fullpath As String = path & filename
            'Save file
            file.PostedFile.SaveAs(fullpath)
            message = "~/UploadAdmissionList/" + filename
            RetPathName = HttpContext.Current.Server.MapPath("~/UploadAdmissionList/" & filename)
            Return True
            'Catch ex As Exception
            '    'If occurs, log it and return false
            '    AppException.LogError(ex.Message)
            '    message = "Result could not be uploaded at the moment."
            '    Return False
            'End Try
        Else
            message = "Invalid Document format! Only Result Sheets in Microsoft Excel 97-2003 Workbook format are allowed"
            Return False
        End If


    End Function
    Public Shared Function UploadStudentProfileNotepad(ByRef file As System.Web.UI.WebControls.FileUpload, ByRef message As String, ByRef Retfullpath As String) As Boolean

        'Check if FileUpload control has file to upload.
        If Not file.HasFile Then
            message = "No file was selected for upload."
            Return False
        End If

        Dim sessionid As String

        ' Get the current HTTPContext and the session ID
        Dim context As HttpContext = HttpContext.Current
        sessionid = context.Session.SessionID
        'Get the file extension
        Dim fileExtension As String = System.IO.Path.GetExtension(file.FileName).ToLower()
        Dim allowedExtension As String = ".txt"

        'For counter = 0 To allowedExtensions.Length - 1 Step 1
        If fileExtension = allowedExtension Then

            'Try
            'Specify the directory to save file to.
            Dim path As String = context.Server.MapPath("~/Notepad/")
            'Generate unique file name for the file in FileUpload control
            Dim filename As String = sessionid & fileExtension
            Dim fullpath As String = path & filename
            Retfullpath = path & filename
            'Save file
            file.PostedFile.SaveAs(fullpath)
            message = "~/Notepad/" + filename
            Return True
            'Catch ex As Exception
            '    'If occurs, log it and return false
            '    AppException.LogError(ex.Message)
            '    message = "Result could not be uploaded at the moment."
            '    Return False
            'End Try
        Else
            message = "Invalid Document format! Only Result Sheets in MS Excel format are allowed"
            Return False
        End If


    End Function
End Class