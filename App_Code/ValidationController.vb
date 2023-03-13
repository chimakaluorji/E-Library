Imports System.Data.SqlClient
Imports System.Configuration
Imports Microsoft.ApplicationBlocks.Data
Imports System
Imports System.Data
Imports System.Diagnostics
Imports Microsoft.VisualBasic
Imports System.Web
Imports System.IO
Imports System.Drawing
'Imports Neurotec.Biometrics.VFMatcher
Public Class ValidationController

    Private cn As SqlConnection
    Private today As String
    'Dim BIO_UseBiometricSDK As String = String.Empty
    Public Sub New()
        Dim cnString As String = System.Configuration.ConfigurationManager.AppSettings("ConnectionString")
        cn = New SqlConnection(cnString)
        today = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")

    End Sub


    Public Shared Function ValidateTextFieldAlphaNumeric(ByVal MinNo As Integer, ByVal MaxNo As Integer, ByVal Str As String) As Boolean
        If Len(Str) < MinNo Then
            Return False
        End If
        If Len(Str) > MaxNo Then
            Return False
        End If
        Return True

    End Function

    Public Shared Function ValidateTextFieldAlphaOnly(ByVal MinNo As Integer, ByVal MaxNo As Integer, ByVal Str As String) As Boolean

        Dim target As String = "0123456789"
        Dim anyOf As Char() = target.ToCharArray()

        If Len(Str) < MinNo Then
            Return False
        End If
        If Len(Str) > MaxNo Then
            Return False
        End If
        If Str.IndexOfAny(anyOf) > -1 Then
            Return False
        End If
        Return True

    End Function

    Public Shared Function ValidateTextFieldNumericOnly(ByVal MinNo As Integer, ByVal MaxNo As Integer, ByVal Str As String) As Boolean
        If Len(Str) < MinNo Then
            Return False
        End If
        If Len(Str) > MaxNo Then
            Return False
        End If
        If Not IsNumeric(Str) Then
            Return False
        End If
        Return True

    End Function

    Public Shared Function ValidateEmailFx(ByVal strEmail As String) As Boolean
        Dim strTmp As String, n As Long, sEXT As String
        Dim EMsg As String
        EMsg = "" 'reset on open for good form 
        Dim ValidateEmail As Boolean
        ValidateEmail = True 'Assume true on init 

        sEXT = strEmail
        Do While InStr(1, sEXT, ".") <> 0
            sEXT = Right(sEXT, Len(sEXT) - InStr(1, sEXT, "."))
        Loop

        If strEmail = "" Then
            ValidateEmail = False
            'EMsg = EMsg & "<BR>You did not enter an email address!"
        ElseIf InStr(1, strEmail, "@") = 0 Then
            ValidateEmail = False
            'EMsg = EMsg & "<BR>Your email address does not contain an @ sign."
        ElseIf InStr(1, strEmail, "@") = 1 Then
            ValidateEmail = False
            'EMsg = EMsg & "<BR>Your @ sign can not be the first character in your email address!"
        ElseIf InStr(1, strEmail, "@") = Len(strEmail) Then
            ValidateEmail = False
            EMsg = EMsg & "<BR>Your @sign can not be the last character in your email address!"
        ElseIf Len(strEmail) < 6 Then
            '1@j.co
            ValidateEmail = False
            'EMsg = EMsg & "<BR>Your email address is shorter than 6 characters which is impossible."
        End If
        strTmp = strEmail
        Do While InStr(1, strTmp, "@") <> 0
            n = 1
            strTmp = Right(strTmp, Len(strTmp) - InStr(1, strTmp, "@"))
        Loop
        If n > 1 Then
            ValidateEmail = False 'found more than one @ sign 
            'EMsg = EMsg & "<BR>You have more than 1 @ sign in your email address"
        End If
        Return ValidateEmail
    End Function

    Public Shared Function ValidateDate(ByVal DateStr As String, ByVal maxServiceYears As Integer, ByVal MaxAge As Integer, ByVal MinAge As Integer) As Boolean
        'Find The Date Difference between today and Supplied Date abd the parametres supplied
        Try
            '12/09/2005
            'A / B / C
            If Len(DateStr) < 10 Then
                Return False
            End If
            Dim _tempDate() As String = DateStr.Split("/")
            Dim _DayPart As String = _tempDate(0)
            Dim _Monthpart As String = _tempDate(1)
            Dim _yearPart As String = _tempDate(2)
            'Construct a New Date From the parts
            Dim _NewdateStr As String = _yearPart & "/" & _Monthpart & "/" & _DayPart
            Dim _today As Date = System.DateTime.Now
            Dim _AtodayStr As Date = CDate(System.DateTime.Now.ToString("yyyy/MM/dd"))

            'Dim _yearFactor As String
            'If CInt(_tempDate(2)) > 10 Then
            '    _yearFactor = "19" & _tempDate(2)
            'Else
            '    _yearFactor = "20" & _tempDate(2)
            'End If
            DateStr = _tempDate(2) & "/" & _tempDate(1) & "/" & _tempDate(0)
            Dim _DateStr As Date = CDate(DateStr)
            Dim _TheDateStr As Date = CDate(_DateStr.ToString("yyyy/MM/dd"))
            Dim _DateDiff As Integer = DateDiff(DateInterval.Year, _DateStr, _today)

            'Check if the Date is a future date
            If _DateDiff < 1 And _AtodayStr < _TheDateStr Then
                Return False
            End If
            If _DateDiff < MinAge And MinAge <> 0 Then
                Return False
            End If

            If _DateDiff > MaxAge And MaxAge <> 0 Then
                Return False
            End If

            If _DateDiff > maxServiceYears And maxServiceYears <> 0 Then
                Return False
            End If

            If _DateDiff > maxServiceYears And maxServiceYears <> 0 Then
                Return False
            End If

            Return True
        Catch ex As Exception
            Print(ex.Message)

            Return False
        End Try

    End Function

    Public Shared Function ValidateTwoEqualFields(ByVal minNo As Integer, ByVal MaxNo As Integer, ByVal field1 As String, ByVal field2 As String) As Boolean
        Try
            If Len(field1) < minNo Or Len(field2) < minNo Then
                Return False
            End If
            If Len(field1) > MaxNo Or Len(field2) > MaxNo Then
                Return False
            End If

            If field1 <> field2 Then
                Return False

            ElseIf field1.ToString = field2.ToString Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            'AppControls.LogError(ex.Message, ex.StackTrace)

            Return False
        End Try



    End Function

    Public Shared Function ValidateSumOfTwoNumbers(ByVal Number1 As Double, ByVal Number2 As Double, ByVal TotalSupplied As Double) As Boolean
        Try
            Dim n As Double
            n = Number1 + Number2
            If n = TotalSupplied Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            'AppControls.LogError(ex.Message, ex.StackTrace)

            Return False
        End Try

    End Function
    'Public Shared Function ValidateImages(ByVal imgData() As Byte, ByVal grayScale As Boolean, ByVal imageType As String) As ImageValidationControlValues
    '    Dim Status As Boolean = False
    '    Dim DefaultByt As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes("0")

    '    'Dim ResponseObjCol As WcTableObjects.ImageValidationControlValues_ResponseCollection = New WcTableObjects.ImageValidationControlValues_ResponseCollection
    '    Dim ResponseObj As ImageValidationControlValues = New ImageValidationControlValues
    '    'Dim verResolution As Integer
    '    'Dim horResolution As Integer
    '    Dim MaxPassportWidth As Integer = CType(System.Configuration.ConfigurationManager.AppSettings("MaxPassportWidth"), Integer)
    '    Dim MinPassportWidth As Integer = CType(System.Configuration.ConfigurationManager.AppSettings("MinPassportWidth"), Integer)

    '    Dim MaxPassportHeight As Integer = CType(System.Configuration.ConfigurationManager.AppSettings("MaxPassportHeight"), Integer)
    '    Dim MinPassportHeight As Integer = CType(System.Configuration.ConfigurationManager.AppSettings("MinPassportHeight"), Integer)

    '    Dim MaxSignatureWidth As Integer = CType(System.Configuration.ConfigurationManager.AppSettings("MaxSignatureWidth"), Integer)
    '    Dim MinSignatureWidth As Integer = CType(System.Configuration.ConfigurationManager.AppSettings("MinSignatureWidth"), Integer)

    '    Dim MaxSignatureHeight As Integer = CType(System.Configuration.ConfigurationManager.AppSettings("MaxSignatureHeight"), Integer)
    '    Dim MinSignatureHeight As Integer = CType(System.Configuration.ConfigurationManager.AppSettings("MinSignatureHeight"), Integer)

    '    Dim MaxFingerPrintWidth As Integer = CType(System.Configuration.ConfigurationManager.AppSettings("MaxFingerPrintWidth"), Integer)
    '    Dim MinFingerPrintWidth As Integer = CType(System.Configuration.ConfigurationManager.AppSettings("MinFingerPrintWidth"), Integer)


    '    Dim MaxFingerPrintHeight As Integer = CType(System.Configuration.ConfigurationManager.AppSettings("MaxFingerPrintHeight"), Integer)
    '    Dim MinFingerPrintHeight As Integer = CType(System.Configuration.ConfigurationManager.AppSettings("MinFingerPrintHeight"), Integer)

    '    Dim FingerPrintResolution As Integer = CType(System.Configuration.ConfigurationManager.AppSettings("FingerPrintResolution"), Integer)

    '    Dim BIO_MinMinutiae As Integer = CType(System.Configuration.ConfigurationManager.AppSettings("BIO_MinMinutiae"), Integer)
    '    Dim BIO_MinQuality As Integer = CType(System.Configuration.ConfigurationManager.AppSettings("BIO_MinQuality"), Integer)

    '    Dim ImgInfoStat As ImageInfo_Biometrics = New ImageInfo_Biometrics
    '    Dim BIO_UseBiometricSDK As String = System.Configuration.ConfigurationManager.AppSettings("BIO_UseBiometricSDK")

    '    'Dim ImgInfoStat As WeCanBioLib.ImageInfo_Biometrics = New WeCanBioLib.ImageInfo_Biometrics
    '    ' Dim ss As New WeCanBioLib.ImageInfo_Biometrics
    '    Try

    '        ImgInfoStat.Load(imgData, imageType)
    '        'TEST FOR GRAYSCALE FIRST.
    '        If grayScale = True Then
    '            If ImgInfoStat.PixelFormat.ToString <> "Format8bppIndexed" Then   'Format8bppIndexed
    '                ResponseObj.Status = False
    '                ResponseObj.Comment = "Invalid PixelFormat"
    '                Return ResponseObj
    '                'Return Status = False
    '            End If
    '        End If

    '        'Test For Height
    '        Select Case imageType
    '            Case "Passport"
    '                If MaxPassportWidth < ImgInfoStat.Width Or MinPassportWidth > ImgInfoStat.Width Then
    '                    ResponseObj.Status = False
    '                    ResponseObj.Comment = "Invalid Passport"
    '                    Return ResponseObj
    '                    'Return False
    '                End If

    '                If MaxPassportHeight < ImgInfoStat.Height Or MinPassportHeight > ImgInfoStat.Height Then
    '                    ResponseObj.Status = False
    '                    ResponseObj.Comment = "Invalid Passport"
    '                    Return ResponseObj
    '                    'Return False
    '                End If

    '            Case "Signature"
    '                If MaxSignatureWidth < ImgInfoStat.Width Or MinSignatureWidth > ImgInfoStat.Width Then
    '                    ResponseObj.Status = False
    '                    ResponseObj.Comment = "Invalid Signature"
    '                    Return ResponseObj
    '                    'Return False
    '                End If

    '                If MaxSignatureHeight < ImgInfoStat.Height Or MinSignatureHeight > ImgInfoStat.Height Then
    '                    ResponseObj.Status = False
    '                    ResponseObj.Comment = "Invalid Signature"
    '                    Return ResponseObj
    '                    'Return False
    '                End If
    '            Case "FingerPrint"
    '                If MaxFingerPrintWidth < ImgInfoStat.Width Or MinFingerPrintWidth > ImgInfoStat.Width Then
    '                    ResponseObj.Status = False
    '                    ResponseObj.Comment = "Invalid FingerPrint Width"
    '                    Return ResponseObj
    '                    'Return False
    '                End If

    '                If MaxFingerPrintHeight < ImgInfoStat.Height Or MinFingerPrintHeight > ImgInfoStat.Height Then
    '                    ResponseObj.Status = False
    '                    ResponseObj.Comment = "Invalid FingerPrint Height"
    '                    Return ResponseObj
    '                    'Return False
    '                End If
    '                'Do Resolution
    '                If FingerPrintResolution <> ImgInfoStat.VerticalResolution Or FingerPrintResolution <> ImgInfoStat.HorizontalResolution Then
    '                    ResponseObj.Status = False
    '                    ResponseObj.Comment = "Invalid FingerPrint Resolution"
    '                    Return ResponseObj
    '                    'Return False
    '                End If

    '                If BIO_UseBiometricSDK = "YES" Then
    '                    If BIO_MinMinutiae > ImgInfoStat.NoOfMinutiae Or BIO_MinQuality > ImgInfoStat.QualityOfImagesInPercent Then
    '                        ResponseObj.Status = False
    '                        ResponseObj.Comment = "Invalid FingerPrint Properties"
    '                        Return ResponseObj
    '                        'Return False
    '                    End If
    '                Else
    '                    'THEN PUT A DEFAULT Stuff
    '                    'ImgInfoStat.TemplateByt = DefaultByt
    '                End If

    '            Case Else
    '                ResponseObj.Status = False
    '                ResponseObj.Comment = "Invalid Data"
    '                Return ResponseObj
    '                'Return False
    '        End Select
    '        ResponseObj.Status = True
    '        ResponseObj.Comment = "Data Ok"
    '        If BIO_UseBiometricSDK = "YES" Then
    '            ResponseObj.Template = ImgInfoStat.TemplateByt
    '            ResponseObj.Valid = 1
    '        Else
    '            ResponseObj.Valid = 0
    '            ResponseObj.Template = DefaultByt ' Put a Default values
    '        End If

    '        Return ResponseObj
    '        'Return True ' This means all is well.
    '    Catch ex As Exception
    '        AppControls.LogError(ex.Message, ex.StackTrace)
    '        'Something went wrong
    '        ResponseObj.Status = False
    '        ResponseObj.Comment = "Invalid Data"
    '        ResponseObj.Valid = 0
    '        ResponseObj.Template = DefaultByt
    '        Return ResponseObj
    '    Finally
    '        ImgInfoStat.Dispose() ' Destroy Object
    '    End Try


    'End Function

    'Public Shared Function IS_FingerPrint_Unique(ByVal cand As Candidate_Application) As String
    '    Dim cnString As String = System.Configuration.ConfigurationManager.AppSettings("ConnectionString")

    '    Dim VFMatcher_ As Neurotec.Biometrics.VFMatcher
    '    Dim BIO_UseBiometricSDK As String = System.Configuration.ConfigurationManager.AppSettings("BIO_UseBiometricSDK")
    '    If BIO_UseBiometricSDK <> "YES" Then
    '        Return "0"
    '        Exit Function
    '    End If
    '    Dim _ret As String = "0" ' Default this to be good
    '    Dim Ds As DataSet = Nothing
    '    Dim dv As DataView = Nothing
    '    Dim i As Integer


    '    'Get the records from the Database to compare with
    '    Try
    '        Dim params() As SqlParameter = {New SqlParameter("@FingerCode", cand.FingerCode), _
    '                                        New SqlParameter("@ExamTypeID", cand.ExamTypeID), _
    '                                        New SqlParameter("@ExamTypeCode", cand.ExamTypeCode), _
    '                                        New SqlParameter("@ExamYear", cand.ExamYear), _
    '                                        New SqlParameter("@GenderID", cand.GenderID)} 'TemplateByt

    '        Ds = SqlHelper.ExecuteDataset(cnString, CommandType.StoredProcedure, "Get_ApplicantsDataByExamTypeAndExamYearAndFingerCode", params)

    '    Catch ex As Exception 'custom exceptionHandler
    '        AppControls.LogError(ex.Message, ex.StackTrace)
    '        Return "990"
    '    End Try

    '    'Initialise the Matcher Object
    '    VFMatcher_ = New Neurotec.Biometrics.VFMatcher()
    '    Try

    '        VFMatcher_.MatchingThreshold = 36 'TO DO
    '        Dim Score As Integer = 0
    '        'Identify is used for 1:N mathing
    '        VFMatcher_.IdentifyStart(cand.FingerTemplate)

    '        Dim _template As Byte()
    '        Dim _member_Id As Integer


    '        If Not Ds Is Nothing Then
    '            dv = New DataView(Ds.Tables(0))
    '            For i = 0 To dv.Count - 1
    '                _template = dv.Item(i).Item("FingerTemplate")
    '                _member_Id = dv.Item(i).Item("ID")
    '                Try
    '                    Score = VFMatcher_.IdentifyNext(_template)
    '                    If Score > 0 Then
    '                        'VFMatcher_.IdentifyEnd() ' Just end anytime you find something matching
    '                        Return _member_Id
    '                    End If
    '                Catch ex As Exception
    '                    'iF IT GETS HERE  - There is an error in the database template
    '                    AppControls.LogError(ex.Message & "DB Record ID: [" & _member_Id.ToString & "]", ex.StackTrace)
    '                End Try

    '            Next

    '            Return _ret
    '        End If

    '    Catch ex As Exception
    '        AppControls.LogError(ex.Message, ex.StackTrace)

    '    Finally
    '        VFMatcher_.IdentifyEnd()
    '    End Try
    '    Return _ret


    'End Function

    'Public Shared Function IS_A_PAIR_OF_FingerPrint_Unique(ByVal cand_Data As Candidate_BiometricData) As String
    '    Dim ret As String = "99"
    '    Dim cand As Candidate_Application = New Candidate_Application
    '    'Check for Left Thumb First
    '    With cand
    '        .ExamTypeCode = cand_Data.ExamTypeCode
    '        .ExamTypeID = cand_Data.ExamTypeID
    '        .ExamYear = cand_Data.ExamYear
    '        .GenderID = cand_Data.GenderID
    '        .FingerTemplate = cand_Data.LeftFingerTemplate
    '        .FingerCode = 1
    '    End With
    '    ret = IS_FingerPrint_Unique(cand)
    '    If ret = "0" Then ' Go ahead and compare for Right template
    '        'Check for the RIGHT thumb 
    '        cand.FingerTemplate = cand_Data.RightFingerTemplate
    '        cand.FingerCode = 6
    '        ret = IS_FingerPrint_Unique(cand)
    '    End If
    '    Return ret
    'End Function

End Class
