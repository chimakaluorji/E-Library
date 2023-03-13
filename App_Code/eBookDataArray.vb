Imports Microsoft.VisualBasic

Public Class eBookDataArray

    Public Property CourseAreaID As Integer
    Public Property BookTitle1 As String
    Public Property BookAuthor1 As String
    Public Property BookTitle2 As String
    Public Property BookAuthor2 As String
    Public Property BookTitle3 As String
    Public Property BookAuthor3 As String
    Public Property BookTitle4 As String
    Public Property BookAuthor4 As String
    Public Property CoverPageUrl1 As String
    Public Property CoverPageUrl2 As String
    Public Property CoverPageUrl3 As String
    Public Property CoverPageUrl4 As String
    Public Property eBookUrl1 As String
    Public Property eBookUrl2 As String
    Public Property eBookUrl3 As String
    Public Property eBookUrl4 As String
    Public Sub New()
    End Sub
    Public Sub New(ByVal CourseAreaID As Integer, ByVal BookTitle1 As String, ByVal BookAuthor1 As String, ByVal BookTitle2 As String, _
                    ByVal BookAuthor2 As String, ByVal BookTitle3 As String, ByVal BookAuthor3 As String, ByVal BookTitle4 As String, _
                    ByVal BookAuthor4 As String, ByVal CoverPageUrl1 As String, ByVal CoverPageUrl2 As String, ByVal CoverPageUrl3 As String,
                    ByVal CoverPageUrl4 As String, ByVal eBookUrl1 As String, ByVal eBookUrl2 As String, ByVal eBookUrl3 As String, ByVal eBookUrl4 As String)

        Me.CourseAreaID = CourseAreaID
        Me.BookTitle1 = BookTitle1
        Me.BookAuthor1 = BookAuthor1
        Me.BookTitle2 = BookTitle2
        Me.BookAuthor2 = BookAuthor2
        Me.BookTitle3 = BookTitle3
        Me.BookAuthor3 = BookAuthor3
        Me.BookTitle4 = BookTitle4
        Me.BookAuthor4 = BookAuthor4
        Me.CoverPageUrl1 = CoverPageUrl1
        Me.CoverPageUrl2 = CoverPageUrl2
        Me.CoverPageUrl3 = CoverPageUrl3
        Me.CoverPageUrl4 = CoverPageUrl4
        Me.eBookUrl1 = eBookUrl1
        Me.eBookUrl2 = eBookUrl2
        Me.eBookUrl3 = eBookUrl3
        Me.eBookUrl4 = eBookUrl4

    End Sub
End Class
