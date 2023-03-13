<%@ WebHandler Language="VB" Class="adminFileUploader" %>

Imports System
Imports System.Web
Imports System.IO

Public Class adminFileUploader : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        context.Response.ContentType = "text/plain"
        Try
            Dim dirFullPath As String = HttpContext.Current.Server.MapPath("../CoverPage/")
            Dim files As String()
            Dim numFiles As Integer
            files = System.IO.Directory.GetFiles(dirFullPath)
            numFiles = files.Length
            numFiles = numFiles + 1
            Dim str_image As String = ""
            Dim pathToSave_100 As String = ""

            For Each s As String In context.Request.Files
                Dim file As HttpPostedFile = context.Request.Files(s)
                Dim fileName As String = file.FileName
                Dim fileExtension As String = file.ContentType

                'If Not String.IsNullOrEmpty(fileName) Then
                '    fileExtension = Path.GetExtension(fileName)
                '    str_image = Convert.ToString("COVER_PAGE_" + numFiles.ToString()) & fileExtension
                '    pathToSave_100 = HttpContext.Current.Server.MapPath("../CoverPage/") & str_image
                '    file.SaveAs(pathToSave_100)
                'End If
                
                If Not String.IsNullOrEmpty(fileName) Then
                    fileExtension = Path.GetExtension(fileName)
                    str_image = "COVER_PAGE_" + numFiles.ToString() + fileExtension
                    Dim pathToSave As String = HttpContext.Current.Server.MapPath("../CoverPage/") + str_image
                    Dim bmpPostedImage As New System.Drawing.Bitmap(file.InputStream)

                    'ResizeMyImage method call
                    'Dim objImage As System.Drawing.Image = ResizeMyImage(bmpPostedImage, 220)
                    'objImage.Save(pathToSave, System.Drawing.Imaging.ImageFormat.Jpeg)
                    
                    Dim objImage As System.Drawing.Bitmap = ResizeImage(bmpPostedImage, 220, 250)
                    objImage.Save(pathToSave, System.Drawing.Imaging.ImageFormat.Jpeg)
                End If
            Next
            '  database record update logic here  ()

            context.Response.Write("../CoverPage/" & str_image)

        Catch ac As Exception
        End Try
    End Sub

    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property
    
    Public Shared Function ResizeMyImage(image As System.Drawing.Image, maxHeight As Integer) As System.Drawing.Image
        Dim ratio As Double = CDbl(maxHeight) / image.Height
        Dim newWidth As Integer = CInt(image.Width * ratio)
        Dim newHeight As Integer = CInt(image.Height * ratio)
        Dim newImage As Drawing.Bitmap = New Drawing.Bitmap(newWidth, newHeight)
        Using g = Drawing.Graphics.FromImage(newImage)
            g.DrawImage(image, 0, 0, newWidth, newHeight)
        End Using
        Return newImage
    End Function
    
    Public Shared Function ResizeImage(bmSource As Drawing.Bitmap, TargetWidth As Int32, TargetHeight As Int32) As Drawing.Bitmap
        Dim bmDest As New Drawing.Bitmap(TargetWidth, TargetHeight, Drawing.Imaging.PixelFormat.Format32bppArgb)

        Dim nSourceAspectRatio = bmSource.Width / bmSource.Height
        Dim nDestAspectRatio = bmDest.Width / bmDest.Height

        Dim NewX = 0
        Dim NewY = 0
        Dim NewWidth = bmDest.Width
        Dim NewHeight = bmDest.Height

        If nDestAspectRatio = nSourceAspectRatio Then
            'same ratio
        ElseIf nDestAspectRatio > nSourceAspectRatio Then
            'Source is taller
            NewWidth = Convert.ToInt32(Math.Floor(nSourceAspectRatio * NewHeight))
            NewX = Convert.ToInt32(Math.Floor((bmDest.Width - NewWidth) / 2))
        Else
            'Source is wider
            NewHeight = Convert.ToInt32(Math.Floor((1 / nSourceAspectRatio) * NewWidth))
            NewY = Convert.ToInt32(Math.Floor((bmDest.Height - NewHeight) / 2))
        End If

        Using grDest = Drawing.Graphics.FromImage(bmDest)
            With grDest
                .CompositingQuality = Drawing.Drawing2D.CompositingQuality.HighQuality
                .InterpolationMode = Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
                .PixelOffsetMode = Drawing.Drawing2D.PixelOffsetMode.HighQuality
                .SmoothingMode = Drawing.Drawing2D.SmoothingMode.AntiAlias
                .CompositingMode = Drawing.Drawing2D.CompositingMode.SourceOver

                .DrawImage(bmSource, NewX, NewY, NewWidth, NewHeight)
            End With
        End Using

        Return bmDest
    End Function
End Class