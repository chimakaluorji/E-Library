Imports System.Data
Imports System.Web.Services
Imports System.Web.Script.Services
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.IO

Partial Class Admin_Dashboard
    Inherits System.Web.UI.Page
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function UploadeBooks(ByVal CourseAreaID As Integer, ByVal BookTitle1 As String, ByVal BookAuthor1 As String, ByVal CoverPageUrl1 As String, _
                                       ByVal eBookUrl1 As String) As String
        Dim success As String = ""
        Dim Dal As DigitalLibraryDAL = New DigitalLibraryDAL
        Dim Data As DigitalLibraryData = New DigitalLibraryData


        Dim fetch As Integer = Dal.UploadeBooks_New(CourseAreaID, BookTitle1, BookAuthor1, CoverPageUrl1, eBookUrl1)

        If fetch = 1 Then
            success = "success"
        Else
            success = "fail"
        End If

        Return success
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
End Class
