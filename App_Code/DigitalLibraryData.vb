Imports Microsoft.VisualBasic

Public Class DigitalLibraryData
    Private _DigitalLibraryID As Integer
    Private _LibSubjID As Integer
    Private _LibSubjAreaID As Integer
    Private _MaterialTypeID As Integer
    Private _Title As String
    Private _eBookUrl As String
    Private _eBookPictureUrl As String
    Private _Keywords As String
    Private _CreatedByUID As Integer
    Private _LibSubjName As String
    Private _SubjectAreaName As String
    Private _MaterialType As String
    Private _Author As String
    Private _PriceTag As String
    Private _TodayDate As String
    Public Property DigitalLibraryID() As Integer
        Get
            Return _DigitalLibraryID
        End Get
        Set(ByVal value As Integer)
            _DigitalLibraryID = value
        End Set
    End Property
    Public Property LibSubjID() As Integer
        Get
            Return _LibSubjID
        End Get
        Set(ByVal value As Integer)
            _LibSubjID = value
        End Set
    End Property

    Public Property LibSubjAreaID() As Integer
        Get
            Return _LibSubjAreaID
        End Get
        Set(ByVal value As Integer)
            _LibSubjAreaID = value
        End Set
    End Property

    Public Property MaterialTypeID() As Integer
        Get
            Return _MaterialTypeID
        End Get
        Set(ByVal value As Integer)
            _MaterialTypeID = value
        End Set
    End Property

    Public Property Title() As String
        Get
            Return _Title
        End Get
        Set(ByVal value As String)
            _Title = value
        End Set
    End Property

    Public Property eBookUrl() As String
        Get
            Return _eBookUrl
        End Get
        Set(ByVal value As String)
            _eBookUrl = value
        End Set
    End Property
    Public Property eBookPictureUrl() As String
        Get
            Return _eBookPictureUrl
        End Get
        Set(ByVal value As String)
            _eBookPictureUrl = value
        End Set
    End Property
    Public Property Keywords() As String
        Get
            Return _Keywords
        End Get
        Set(ByVal value As String)
            _Keywords = value
        End Set
    End Property

    Public Property CreatedByUID() As Integer
        Get
            Return _CreatedByUID
        End Get
        Set(ByVal value As Integer)
            _CreatedByUID = value
        End Set
    End Property

    Public Property LibSubjName() As String
        Get
            Return _LibSubjName
        End Get
        Set(ByVal value As String)
            _LibSubjName = value
        End Set
    End Property

    Public Property SubjectAreaName() As String
        Get
            Return _SubjectAreaName
        End Get
        Set(ByVal value As String)
            _SubjectAreaName = value
        End Set
    End Property
    Public Property MaterialType() As String
        Get
            Return _MaterialType
        End Get
        Set(ByVal value As String)
            _MaterialType = value
        End Set
    End Property
    Public Property Author() As String
        Get
            Return _Author
        End Get
        Set(ByVal value As String)
            _Author = value
        End Set
    End Property
    Public Property PriceTag() As String
        Get
            Return _PriceTag
        End Get
        Set(ByVal value As String)
            _PriceTag = value
        End Set
    End Property
    Public Property TodayDate() As String
        Get
            Return _TodayDate
        End Get
        Set(ByVal value As String)
            _TodayDate = value
        End Set
    End Property
End Class
