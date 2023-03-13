Imports System.Data
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Net
Partial Class User_ReadeBook
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Dim title As String = Request.QueryString("t")
        'Dim author As String = Request.QueryString("a")

        'lblTitle.Text = title
        'lblAuthor.Text = author

        Dim url As String = Request.QueryString("e")

        'eBookframe.Attributes.Add("src", url)

        Dim FileName As String = MapPath(url)

        Dim User As WebClient = New WebClient
        Dim FileBuffer As Byte() = User.DownloadData(FileName)

        If FileBuffer IsNot Nothing Then
            Response.ContentType = "application/pdf"
            Response.AddHeader("content-length", FileBuffer.Length.ToString())
            Response.BinaryWrite(FileBuffer)
        End If
    End Sub
End Class
