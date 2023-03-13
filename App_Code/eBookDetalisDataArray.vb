Imports Microsoft.VisualBasic

Public Class eBookDetalisDataArray
    Public Property eBookDetailsID As Integer
    Public Property CourseAreaID As Integer
    Public Property BookTitle As String
    Public Property BookAuthor As String
    Public Property CoverPageUrl As String
    Public Property eBookUrl As String

    Public Sub New()
    End Sub
    Public Sub New(ByVal eBookDetailsID As Integer, ByVal CourseAreaID As Integer, ByVal BookTitle As String, ByVal BookAuthor As String, ByVal CoverPageUrl As String, _
                    ByVal eBookUrl As String)

        Me.eBookDetailsID = eBookDetailsID
        Me.CourseAreaID = CourseAreaID
        Me.BookTitle = BookTitle
        Me.BookAuthor = BookAuthor
        Me.CoverPageUrl = CoverPageUrl
        Me.eBookUrl = eBookUrl

    End Sub
End Class
