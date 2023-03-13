Imports Microsoft.VisualBasic
''' <summary>
''' author: Kalu Nsi Idika
''' for SocketWorks Ltd
''' 04-08-2008
''' data access object for Users Entity
''' </summary>
''' <remarks></remarks>
''' 

<Serializable()> Public Class UsersData

    Private _UserName As String
    Private _UsersID As Integer
    Private _FirstName As String
    Private _Surname As String
    Private _Password As String
    Private _Phone As String
    Private _Email As String
    Private _CretedUserId As Integer
    Private _CreateDate As String
    Private _Address As String
    Private _SaltKey As String
    Private _NewPassword As String
    Private _NewSaltKey As String
    Private _PhotoURL As String
    Public Sub New()

    End Sub

    Public Property SaltKey() As String
        Get
            Return _SaltKey
        End Get
        Set(ByVal value As String)
            _SaltKey = value
        End Set
    End Property
    Public Property UsersID() As Integer
        Get
            Return _UsersID
        End Get
        Set(ByVal value As Integer)
            _UsersID = value
        End Set
    End Property

    Public Property UserName() As String
        Get
            Return _UserName
        End Get
        Set(ByVal value As String)
            _UserName = value
        End Set
    End Property

    Public Property FirstName() As String
        Get
            Return _FirstName
        End Get
        Set(ByVal value As String)
            _FirstName = value
        End Set
    End Property

    Public Property Surname() As String
        Get
            Return _Surname
        End Get
        Set(ByVal value As String)
            _Surname = value
        End Set
    End Property


    Public Property Password() As String
        Get
            Return _Password
        End Get
        Set(ByVal value As String)
            _Password = value
        End Set
    End Property

    Public Property Phone() As String
        Get
            Return _Phone
        End Get
        Set(ByVal value As String)
            _Phone = value
        End Set
    End Property

    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            _Email = value
        End Set
    End Property


    Public Property CretedUserId() As Integer
        Get
            Return _CretedUserId
        End Get
        Set(ByVal value As Integer)
            _CretedUserId = value
        End Set
    End Property


    Public Property CreateDate() As String
        Get
            Return _CreateDate
        End Get
        Set(ByVal value As String)
            _CreateDate = value
        End Set
    End Property

    Public Property Address() As String
        Get
            Return _Address
        End Get
        Set(ByVal value As String)
            _Address = value
        End Set
    End Property
    Public Property NewPassword() As String
        Get
            Return _NewPassword
        End Get
        Set(ByVal value As String)
            _NewPassword = value
        End Set
    End Property
    Public Property NewSaltKey() As String
        Get
            Return _NewSaltKey
        End Get
        Set(ByVal value As String)
            _NewSaltKey = value
        End Set
    End Property
    Public Property PhotoURL() As String
        Get
            Return _PhotoURL
        End Get
        Set(ByVal value As String)
            _PhotoURL = value
        End Set
    End Property
End Class
