
Partial Class Admin_MasterPage
    Inherits System.Web.UI.MasterPage
    Public Email As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Email = Request.QueryString("Email")
    End Sub

    Protected Sub BtnLogout_Click(sender As Object, e As EventArgs) Handles BtnLogout.Click
        Response.Redirect("Default.aspx")
    End Sub
End Class

