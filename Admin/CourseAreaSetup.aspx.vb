Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Imports System
Imports System.Web
Imports System.IO

Partial Class Admin_CourseAreaSetup
    Inherits System.Web.UI.Page

    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function GetAllCourseArea() As ArrayList
        Dim GetSectionArray As ArrayList = New ArrayList

        Dim userData As DataSet = New DataSet
        Dim userDal As DigitalLibraryDAL = New DigitalLibraryDAL
        userData = userDal.FindAllCourseArea()

        If userData.Tables(0).Rows.Count > 0 Then
            For Each row As DataRow In userData.Tables(0).Rows
                GetSectionArray.Add(New FetchCourseArea(row(0), row(1)))
            Next
        Else
            GetSectionArray.Add(New FetchCourseArea(0, ""))
        End If
        Return GetSectionArray
    End Function
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function CreateCourseArea(ByVal CourseArea As String) As String
        Dim success As String = ""
        Dim Dal As DigitalLibraryDAL = New DigitalLibraryDAL
        Dim Data As DigitalLibraryData = New DigitalLibraryData


        Dim fetch As Integer = Dal.CreateCourseArea(CourseArea)

        If fetch = 1 Then
            success = "success"
        Else
            success = "fail"
        End If

        Return success
    End Function

    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function GetAllCourseAreaByID(ByVal CourseAreaID As Integer) As ArrayList
        Dim GetSectionArray As ArrayList = New ArrayList

        Dim userData As DataSet = New DataSet
        Dim userDal As DigitalLibraryDAL = New DigitalLibraryDAL
        userData = userDal.GetAllCourseAreaByID(CourseAreaID)

        If userData.Tables(0).Rows.Count > 0 Then
            For Each row As DataRow In userData.Tables(0).Rows
                GetSectionArray.Add(New FetchCourseArea(row(0), row(1)))
            Next
        Else
            GetSectionArray.Add(New FetchCourseArea(0, ""))
        End If
        Return GetSectionArray
    End Function
End Class

Public Class FetchCourseArea
    Public CourseAreaID As Integer
    Public CourseArea As String
    Public Sub New(ByVal CourseAreaID As Integer, ByVal CourseArea As String)

        Me.CourseAreaID = CourseAreaID
        Me.CourseArea = CourseArea
    End Sub
End Class