Imports System.Data
Imports System.Web.Services
Imports System.Web.Script.Services
Imports System.Collections.Generic
Imports System.Data.SqlClient
Partial Class User_Dashboard
    Inherits System.Web.UI.Page
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function FindAlleBookDetails(max As Integer, min As Integer) As ArrayList
        Dim success As String = ""

        Dim GetSectionArray As ArrayList = New ArrayList

        Dim userData As DataSet = New DataSet
        Dim userDal As DigitalLibraryDAL = New DigitalLibraryDAL

        userData = userDal.FindAlleBookDetails(max, min)

        If userData.Tables(0).Rows.Count > 0 Then
            For Each row As DataRow In userData.Tables(0).Rows
                GetSectionArray.Add(New eBookDetalisDataArray(row(0), row(1), row(2), row(3), row(4), row(5)))
            Next
        Else
            GetSectionArray.Add(New eBookDetalisDataArray("0", "0", "", "", "", ""))
        End If


        Return GetSectionArray
    End Function
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function FindAlleBookDetailsBySearch(max As Integer, min As Integer, searchValue As String) As ArrayList
        Dim success As String = ""

        Dim GetSectionArray As ArrayList = New ArrayList

        Dim userData As DataSet = New DataSet
        Dim userDal As DigitalLibraryDAL = New DigitalLibraryDAL
        searchValue = searchValue.Trim

        userData = userDal.FindAlleBookDetailsBySearch(max, min, searchValue)

        If userData.Tables(0).Rows.Count > 0 Then
            For Each row As DataRow In userData.Tables(0).Rows
                GetSectionArray.Add(New eBookDetalisDataArray(row(0), row(1), row(2), row(3), row(4), row(5)))
            Next
        Else
            GetSectionArray.Add(New eBookDetalisDataArray("0", "0", "", "", "", ""))
        End If


        Return GetSectionArray
    End Function
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function FindAlleBookDetailsBySort(max As Integer, min As Integer, courseID As Integer) As ArrayList
        Dim success As String = ""

        Dim GetSectionArray As ArrayList = New ArrayList

        Dim userData As DataSet = New DataSet
        Dim userDal As DigitalLibraryDAL = New DigitalLibraryDAL

        userData = userDal.FindAlleBookDetailsBySort(max, min, courseID)

        If userData.Tables(0).Rows.Count > 0 Then
            For Each row As DataRow In userData.Tables(0).Rows
                GetSectionArray.Add(New eBookDetalisDataArray(row(0), row(1), row(2), row(3), row(4), row(5)))
            Next
        Else
            GetSectionArray.Add(New eBookDetalisDataArray("0", "0", "", "", "", ""))
        End If


        Return GetSectionArray
    End Function
    <WebMethod()> _
    Public Shared Function FindAlleBook() As ArrayList
        Dim success As String = ""

        Dim GetSectionArray As ArrayList = New ArrayList

        Dim userData As DataSet = New DataSet
        Dim userDal As DigitalLibraryDAL = New DigitalLibraryDAL

        userData = userDal.FindAlleBook()

        If userData.Tables(0).Rows.Count > 0 Then
            For Each row As DataRow In userData.Tables(0).Rows
                GetSectionArray.Add(New eBookDataArray(row(0), row(1), row(2), row(3), row(4), row(5), row(6), row(7), row(8), row(9), row(10), row(11), row(12), row(13), row(14), row(15), row(16)))
            Next
        Else
            GetSectionArray.Add(New eBookDataArray("0", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""))
        End If


        Return GetSectionArray
    End Function
    <WebMethod()> _
    Public Shared Function GetPosition() As List(Of ListItem)
        Dim customers As New List(Of ListItem)()

        Dim query As String = "select CourseAreaID,CourseArea from CourseArea"
        Dim constr As String = ConfigurationManager.ConnectionStrings("ResultManagerConnectionString").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand(query)

                cmd.CommandType = CommandType.Text
                cmd.Connection = con
                con.Open()
                Using sdr As SqlDataReader = cmd.ExecuteReader()
                    While sdr.Read()
                        customers.Add(New ListItem() With { _
                          .Value = sdr("CourseAreaID").ToString(), _
                          .Text = sdr("CourseArea").ToString() _
                        })
                    End While
                End Using
                con.Close()

            End Using
        End Using

        Return customers
    End Function

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Dim a As New ArrayList

        'a = FindAlleBookDetailsBySearch(4, 1, "Basic")

        'Dim userData As DataSet = New DataSet
        'Dim userDal As DigitalLibraryDAL = New DigitalLibraryDAL

        'userData = userDal.FindAlleBookDetailsBySearch(4, 1, "Tec")

        'txtSearch.Text = a.Item(2).ToString()
    End Sub
End Class
