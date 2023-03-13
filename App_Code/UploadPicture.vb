Imports System.IO
Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Drawing
Public Class UploadPicture

    ''' <summary>
    ''' Uploads documemt to web server with HtmlControls.HtmlInputFile.
    ''' </summary>
    ''' <param name="file"></param>
    ''' <param name="message"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function UploadFileImage(ByRef file As System.Web.UI.WebControls.FileUpload, ByRef message As String, ByVal RegNo As String, ByVal CredentialType As String) As Boolean
        'Check if FileUpload control has file to upload.
        If file.PostedFile.ContentLength = 0 Then
            message = "No file was selected for upload."
            Return False
        End If

        Dim sessionid As String

        ' Get the current HTTPContext
        Dim context As HttpContext = HttpContext.Current
        sessionid = context.Session.SessionID
        'Get the file extension
        Dim fileExtension As String = System.IO.Path.GetExtension(file.PostedFile.FileName).ToLower()
        Dim allowedExtensions As String() = {".jpeg", ".jpg", ".doc", ".pdf", ".txt"}




        Dim counter As Integer

        For counter = 0 To allowedExtensions.Length - 1 Step 1
            If fileExtension = allowedExtensions(counter) Then
                'Check the file type.
                If fileExtension = ".jpg" Or fileExtension = ".jpeg" Then
                    Dim myImage As System.Drawing.Bitmap

                    Try
                        'Specify the directory to save file to.

                        'Dim path2 As String = context.Server.MapPath("")

                        Dim path As String = context.Server.MapPath("~/UploadedPhotos/")
                        'Generate unique file name for the file in FileUpload control
                        Dim filename As String = sessionid & "_" & RegNo.Substring(5) & "_" & CredentialType & ".jpg"
                        Dim fullpath As String = path & filename
                        'Save file
                        file.PostedFile.SaveAs(fullpath)

                        'Changing the picture size
                        'following code resizes picture to fit

                        Dim fileDirectory As String = path & sessionid & "_" & RegNo.Substring(5) & "_" & CredentialType & ".jpg"

                        Dim bm As New Bitmap(fileDirectory)
                        Dim x As Int32 = 110 'variable for new width size
                        Dim y As Int32 = 110 'variable for new height size

                        Dim width As Integer = x 'Val(x) 'image width. 

                        Dim height As Integer = y 'Val(y) 'image height

                        Dim thumb As New Bitmap(width, height)

                        Dim g As Graphics = Graphics.FromImage(thumb)

                        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic

                        g.DrawImage(bm, New Rectangle(0, 0, width, height), New Rectangle(0, 0, bm.Width, _
                bm.Height), GraphicsUnit.Pixel)

                        g.Dispose()


                        'image path. better to make this dynamic. I am hardcoding a path just for example sake
                        'thumb.Save("C:\inetpub\wwwroot\Uwauna\UploadedDocuments\newimage.bmp", _
                        'System.Drawing.Imaging.ImageFormat.Jpeg) 'can use any image format 

                        thumb.Save(fullpath & ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
                        bm.Dispose()

                        thumb.Dispose()

                        myImage = New System.Drawing.Bitmap(fullpath)
                        'Check image size after saving and report accordingly.
                        If myImage.Width > 0 Then

                            ' message = "~/UploadedDocuments/" + filename & ".jpg"
                            message = "~/UploadedPhotos/" + filename & ".jpg"
                            Return True
                        Else
                            message = "Invalid image format!"
                            Return False
                        End If

                    Catch ex As Exception
                        'If occurs, log it and return false
                        AppException.LogError(ex.Message)
                        message = "Image could not be uploaded at the moment."
                        Return False
                    Finally
                        'Do clean up
                        'myImage.Dispose()
                    End Try
                    Exit For
                Else
                    Try
                        'Specify the directory to save file to.
                        Dim path As String = context.Server.MapPath("~/UploadedPhotos/")
                        'Generate unique file name for the file in FileUpload control
                        Dim filename As String = sessionid & "_" & RegNo.Substring(5) & "_" & CredentialType & fileExtension
                        Dim fullpath As String = path & filename
                        'Save file
                        file.PostedFile.SaveAs(fullpath)
                        message = "~/UploadedPhotos/" + filename
                    Catch ex As Exception
                        'If occurs, log it and return false
                        AppException.LogError(ex.Message)
                        message = "File could not be uploaded at the moment."
                        Return False
                    End Try
                    Exit For
                End If
            End If
        Next

        message = "Invalid image format! "
        Return False
    End Function
    ''' <summary>
    ''' Uploads documemt to web server with HtmlControls.HtmlInputFile.
    ''' </summary>
    ''' <param name="file"></param>
    ''' <param name="message"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function UploadFileCredential(ByRef file As System.Web.UI.WebControls.FileUpload, ByRef message As String, ByVal RegNo As String, ByVal CredentialType As String) As Boolean
        'Check if FileUpload control has file to upload.
        If file.PostedFile.ContentLength = 0 Then
            message = "No file was selected for upload."
            Return False
        End If

        Dim sessionid As String

        ' Get the current HTTPContext
        Dim context As HttpContext = HttpContext.Current
        sessionid = context.Session.SessionID
        'Get the file extension
        Dim fileExtension As String = System.IO.Path.GetExtension(file.PostedFile.FileName).ToLower()
        Dim allowedExtensions As String() = {".jpeg", ".jpg", ".doc", ".pdf", ".txt"}




        Dim counter As Integer

        For counter = 0 To allowedExtensions.Length - 1 Step 1
            If fileExtension = allowedExtensions(counter) Then
                'Check the file type.
                If fileExtension = ".jpg" Or fileExtension = ".jpeg" Then
                    Dim myImage As System.Drawing.Bitmap

                    Try
                        'Specify the directory to save file to.

                        'Dim path2 As String = context.Server.MapPath("")

                        Dim path As String = context.Server.MapPath("~/UploadedDocuments/")
                        'Generate unique file name for the file in FileUpload control
                        Dim filename As String = sessionid & "_" & RegNo.Substring(5) & "_" & CredentialType & ".jpg"
                        Dim fullpath As String = path & filename
                        'Save file
                        file.PostedFile.SaveAs(fullpath)

                        'Changing the picture size
                        'following code resizes picture to fit

                        Dim fileDirectory As String = path & sessionid & "_" & RegNo.Substring(5) & "_" & CredentialType & ".jpg"

                        Dim bm As New Bitmap(fileDirectory)
                        Dim x As Int32 = 800 'variable for new width size
                        Dim y As Int32 = 600 'variable for new height size

                        Dim width As Integer = x 'Val(x) 'image width. 

                        Dim height As Integer = y 'Val(y) 'image height

                        Dim thumb As New Bitmap(width, height)

                        Dim g As Graphics = Graphics.FromImage(thumb)

                        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic

                        g.DrawImage(bm, New Rectangle(0, 0, width, height), New Rectangle(0, 0, bm.Width, _
                bm.Height), GraphicsUnit.Pixel)

                        g.Dispose()


                        'image path. better to make this dynamic. I am hardcoding a path just for example sake
                        'thumb.Save("C:\inetpub\wwwroot\Uwauna\UploadedDocuments\newimage.bmp", _
                        'System.Drawing.Imaging.ImageFormat.Jpeg) 'can use any image format 

                        thumb.Save(fullpath & ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
                        bm.Dispose()

                        thumb.Dispose()

                        myImage = New System.Drawing.Bitmap(fullpath)
                        'Check image size after saving and report accordingly.
                        If myImage.Width > 0 Then

                            ' message = "~/UploadedDocuments/" + filename & ".jpg"
                            message = "~/UploadedDocuments/" + filename & ".jpg"
                            Return True
                        Else
                            message = "Invalid image format!"
                            Return False
                        End If

                    Catch ex As Exception
                        'If occurs, log it and return false
                        AppException.LogError(ex.Message)
                        message = "Image could not be uploaded at the moment."
                        Return False
                    Finally
                        'Do clean up
                        'myImage.Dispose()
                    End Try
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
                    Catch ex As Exception
                        'If occurs, log it and return false
                        AppException.LogError(ex.Message)
                        message = "File could not be uploaded at the moment."
                        Return False
                    End Try
                    Exit For
                End If
            End If
        Next

        message = "Invalid image format! "
        Return False

    End Function
        ''' <summary>
    ''' Uploads documemt to web server with HtmlControls.HtmlInputFile.
    ''' </summary>
    ''' <param name="file"></param>
    ''' <param name="message"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function UploadFileImage1(ByRef file As System.Web.UI.WebControls.FileUpload, ByRef message As String, ByRef message1 As String, ByVal RegNo As String, ByVal CredentialType As String) As Boolean
        'Check if FileUpload control has file to upload.
        If file.PostedFile.ContentLength = 0 Then
            message = "No file was selected for upload."
            Return False
        End If

        Dim FileFullName As String = file.FileName.ToLower
        message1 = FileFullName

        Dim sessionid As String

        ' Get the current HTTPContext
        Dim context As HttpContext = HttpContext.Current
        sessionid = context.Session.SessionID
        'Get the file extension
        Dim fileExtension As String = System.IO.Path.GetExtension(file.PostedFile.FileName).ToLower()
        Dim allowedExtensions As String() = {".jpeg", ".jpg", ".doc", ".pdf", ".txt"}




        Dim counter As Integer

        For counter = 0 To allowedExtensions.Length - 1 Step 1
            If fileExtension = allowedExtensions(counter) Then
                'Check the file type.
                If fileExtension = ".jpg" Or fileExtension = ".jpeg" Then
                    Dim myImage As System.Drawing.Bitmap

                    'Try
                    'Specify the directory to save file to.

                    'Dim path2 As String = context.Server.MapPath("")

                    Dim path As String = context.Server.MapPath("~/UploadedPhotos/")
                    'Generate unique file name for the file in FileUpload control
                    Dim filename As String = sessionid & "_" & RegNo.Substring(5) & "_" & CredentialType & ".jpg"
                    Dim fullpath As String = path & filename
                    'Save file
                    file.PostedFile.SaveAs(fullpath)

                    'Changing the picture size
                    'following code resizes picture to fit

                    Dim fileDirectory As String = path & sessionid & "_" & RegNo.Substring(5) & "_" & CredentialType & ".jpg"

                    Dim bm As New Bitmap(fileDirectory)
                    Dim x As Int32 = 110 'variable for new width size
                    Dim y As Int32 = 110 'variable for new height size

                    Dim width As Integer = x 'Val(x) 'image width. 

                    Dim height As Integer = y 'Val(y) 'image height

                    Dim thumb As New Bitmap(width, height)

                    Dim g As Graphics = Graphics.FromImage(thumb)

                    g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic

                    g.DrawImage(bm, New Rectangle(0, 0, width, height), New Rectangle(0, 0, bm.Width, _
            bm.Height), GraphicsUnit.Pixel)

                    g.Dispose()


                    'image path. better to make this dynamic. I am hardcoding a path just for example sake
                    'thumb.Save("C:\inetpub\wwwroot\Uwauna\UploadedDocuments\newimage.bmp", _
                    'System.Drawing.Imaging.ImageFormat.Jpeg) 'can use any image format 

                    thumb.Save(fullpath & ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
                    bm.Dispose()

                    thumb.Dispose()

                    myImage = New System.Drawing.Bitmap(fullpath)
                    'Check image size after saving and report accordingly.
                    If myImage.Width > 0 Then

                        ' message = "~/UploadedDocuments/" + filename & ".jpg"
                        message = "~/UploadedPhotos/" + filename & ".jpg"
                        Return True
                    Else
                        message = "Invalid image format!"
                        Return False
                    End If

                    'Catch ex As Exception
                    '    'If occurs, log it and return false
                    '    AppException.LogError(ex.Message)
                    '    message = "Image could not be uploaded at the moment."
                    '    Return False
                    'Finally
                    '    'Do clean up
                    '    'myImage.Dispose()
                    'End Try
                    Exit For
                Else
                    'Try
                    'Specify the directory to save file to.
                    Dim path As String = context.Server.MapPath("~/UploadedPhotos/")
                    'Generate unique file name for the file in FileUpload control
                    Dim filename As String = sessionid & "_" & RegNo.Substring(5) & "_" & CredentialType & fileExtension
                    Dim fullpath As String = path & filename
                    'Save file
                    file.PostedFile.SaveAs(fullpath)
                    message = "~/UploadedPhotos/" + filename
                    'Catch ex As Exception
                    '    'If occurs, log it and return false
                    '    AppException.LogError(ex.Message)
                    '    message = "File could not be uploaded at the moment."
                    '    Return False
                    'End Try
                    Exit For
                End If
            End If
        Next

        message = "Invalid image format! "
        Return False
    End Function
    ''' <summary>
    ''' Uploads documemt to web server with HtmlControls.HtmlInputFile.
    ''' </summary>
    ''' <param name="file"></param>
    ''' <param name="message"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function UploadFileCredential1(ByRef file As System.Web.UI.WebControls.FileUpload, ByRef message As String, ByRef message1 As String, ByVal RegNo As String, ByVal CredentialType As String) As Boolean
        'Check if FileUpload control has file to upload.
        If file.PostedFile.ContentLength = 0 Then
            message = "No file was selected for upload."
            Return False
        End If

        Dim FileFullName As String = file.FileName.ToLower
        message1 = FileFullName


        Dim sessionid As String

        ' Get the current HTTPContext
        Dim context As HttpContext = HttpContext.Current
        sessionid = context.Session.SessionID
        'Get the file extension
        Dim fileExtension As String = System.IO.Path.GetExtension(file.PostedFile.FileName).ToLower()
        Dim allowedExtensions As String() = {".jpeg", ".jpg", ".doc", ".pdf", ".txt"}




        Dim counter As Integer

        For counter = 0 To allowedExtensions.Length - 1 Step 1
            If fileExtension = allowedExtensions(counter) Then
                'Check the file type.
                If fileExtension = ".jpg" Or fileExtension = ".jpeg" Then
                    Dim myImage As System.Drawing.Bitmap

                    Try
                        'Specify the directory to save file to.

                        'Dim path2 As String = context.Server.MapPath("")

                        Dim path As String = context.Server.MapPath("~/UploadedDocuments/")
                        'Generate unique file name for the file in FileUpload control
                        Dim filename As String = sessionid & "_" & RegNo.Substring(5) & "_" & CredentialType & ".jpg"
                        Dim fullpath As String = path & filename
                        'Save file
                        file.PostedFile.SaveAs(fullpath)

                        'Changing the picture size
                        'following code resizes picture to fit

                        Dim fileDirectory As String = path & sessionid & "_" & RegNo.Substring(5) & "_" & CredentialType & ".jpg"

                        Dim bm As New Bitmap(fileDirectory)
                        Dim x As Int32 = 800 'variable for new width size
                        Dim y As Int32 = 600 'variable for new height size

                        Dim width As Integer = x 'Val(x) 'image width. 

                        Dim height As Integer = y 'Val(y) 'image height

                        Dim thumb As New Bitmap(width, height)

                        Dim g As Graphics = Graphics.FromImage(thumb)

                        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic

                        g.DrawImage(bm, New Rectangle(0, 0, width, height), New Rectangle(0, 0, bm.Width, _
                bm.Height), GraphicsUnit.Pixel)

                        g.Dispose()


                        'image path. better to make this dynamic. I am hardcoding a path just for example sake
                        'thumb.Save("C:\inetpub\wwwroot\Uwauna\UploadedDocuments\newimage.bmp", _
                        'System.Drawing.Imaging.ImageFormat.Jpeg) 'can use any image format 

                        thumb.Save(fullpath & ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
                        bm.Dispose()

                        thumb.Dispose()

                        myImage = New System.Drawing.Bitmap(fullpath)
                        'Check image size after saving and report accordingly.
                        If myImage.Width > 0 Then

                            ' message = "~/UploadedDocuments/" + filename & ".jpg"
                            message = "~/UploadedDocuments/" + filename & ".jpg"
                            Return True
                        Else
                            message = "Invalid image format!"
                            Return False
                        End If

                    Catch ex As Exception
                        'If occurs, log it and return false
                        AppException.LogError(ex.Message)
                        message = "Image could not be uploaded at the moment."
                        Return False
                    Finally
                        'Do clean up
                        'myImage.Dispose()
                    End Try
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
                    Catch ex As Exception
                        'If occurs, log it and return false
                        AppException.LogError(ex.Message)
                        message = "File could not be uploaded at the moment."
                        Return False
                    End Try
                    Exit For
                End If
            End If
        Next

        message = "Invalid image format! "
        Return False

    End Function
    Public Shared Function GetImageHeight(ByRef file As String) As Integer
        Using image As System.Drawing.Image = System.Drawing.Image.FromFile(file)
            Return image.Height
        End Using
    End Function
    Public Shared Function GetImageWidth(ByRef file As String) As Integer
        Using image As System.Drawing.Image = System.Drawing.Image.FromFile(file)
            Return image.Width
        End Using
    End Function
    ''' <summary>
    ''' Uploads documemt to web server with HtmlControls.HtmlInputFile.
    ''' </summary>
    ''' <param name="file"></param>
    ''' <param name="message"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function UploadFileImage5(ByRef file As System.Web.UI.WebControls.FileUpload, ByRef message As String, ByRef message1 As String) As Boolean

        'Dim FileFullName As String = file.FileName
        'Dim FileFullName As String = file.FileContent
        'message1 = FileFullName
        ''Dim image As System.Drawing.Image = System.Drawing.Image.FromStream(System.Net.HttpWebRequest.Create(FileFullName).GetResponse().GetResponseStream())
        'message = image.Height

        'Using image As System.Drawing.Image = System.Drawing.Image.FromFile(FileFullName)
        '    message = image.Height
        'End Using

        'Using image As System.Drawing.Image = System.Drawing.Image.FromFile(FileFullName)
        '    message1 = image.Width
        'End Using

        'Dim fs As FileStream = New FileStream("C:\inetpub\wwwroot\HeritagePolyPortal\UploadedDocuments\1nk1g4ezqv42yofznhecflyt_34661_2001234661.jpg", FileMode.Open, FileAccess.Read, FileShare.Read)
        'Dim image1 As System.Drawing.Image = System.Drawing.Image.FromStream(fs)
        'Dim fileLength As Int32 = Convert.ToInt32(fs.Length)
        'Dim fileWidth As Integer = image1.Width
        'Dim fileHeight As Integer = image1.Height

        'message = CType(fileWidth, String)
        'message1 = CType(fileHeight, String)

        'Dim bmp As Bitmap = New Bitmap("C:\inetpub\wwwroot\HeritagePolyPortal\UploadedDocuments\fmbgccu0oivalji3oj3mcs55_34661_SSCE1.jpg")
        'Dim fileWidth As Integer = bmp.Height
        'Dim fileHeight As Integer = bmp.Width

        ''Dim fileWidth As Integer = image1.Width
        ''Dim fileHeight As Integer = image1.Height

        'message = CType(fileWidth, String)
        'message1 = CType(fileHeight, String)

        Return False
    End Function
End Class
