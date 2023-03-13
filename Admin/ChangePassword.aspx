<%@ Page Language="VB" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="false" CodeFile="ChangePassword.aspx.vb" Inherits="Admin_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content">

        <!-- content-control -->
        <div class="content-control">
            <!--control-nav-->
        </div>

        <div class="content-body">
            <div class="row">

                <div class="col-md-12" data-toggle="sortable-widget">
                    <!-- ALERT AND CALLOUT  -->
                    <div id="panel-alco" class="panel panel-default sortable-widget-item">
                        <div class="panel-heading">
                            <div class="panel-actions">

                                <button data-expand="#panel-alco" title="expand" class="btn-panel">
                                    <i class="fa fa-expand"></i>
                                </button>
                                <button data-collapse="#panel-alco" title="collapse" class="btn-panel">
                                    <i class="fa fa-caret-down"></i>
                                </button>
                                <button data-close="#panel-alco" title="close" class="btn-panel">
                                    <i class="fa fa-times"></i>
                                </button>
                            </div>
                            <!-- /panel-actions -->
                            <h3 class="panel-title sortable-widget-handle">Change Password</h3>
                        </div>
                        <!-- /panel-heading -->

                        <!-- /panel-body -->
                        <div class="panel-body bordered-bottom">

                            <div class="alert alert-success" id="successmsg" style="display: none;">
                                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                            </div>
                            <div class="alert alert-danger" id="failmsg" style="display: none;">
                                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                            </div>
                            <div style="color: #F25926; font-size: 15px; display: none; text-align: center;" id="spinner">
                                <img src="images/loader7.gif" />
                                ..........Please wait, <strong>processing</strong> .......
                                           <img src="images/loading.gif" />
                            </div>

                            <br />

                            <div class="form-group">
                                <label class="control-label text-inverse col-sm-2" >New Password: </label>
                                <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="control-label text-inverse col-sm-2" >Confirm Password: </label>
                                <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                           <div class="form-group">
                                <input type="button" value="Change Password" id="btnChangePassword" class="btn btn-primary" />
                            </div>
                        </div>
                        <!-- /panel-body -->
                    </div>
                    <!-- /panel-alco -->
                </div>
                <!--/cols -->

            </div>
        </div>
    </div>


    <script src="scripts/39914ff3.vendor-main.js"></script>
    <script src="js/Table/jquery.dataTables.min.js"></script>
    <script src="js/Table/dataTables.bootstrap.min.js"></script>
    <script src="js/Table/dataTables.buttons.min.js"></script>
    <script src="js/Table/buttons.bootstrap.min.js"></script>
    <script src="js/Table/jszip.min.js"></script>
    <script src="js/Table/pdfmake.min.js"></script>
    <script src="js/Table/vfs_fonts.js"></script>
    <script src="js/Table/buttons.html5.min.js"></script>
    <script src="js/Table/buttons.colVis.min.js"></script>

    <script type="text/javascript" class="init">

        $(document).ready(function () {
            var table = $('#example').DataTable({
                lengthChange: true,
                buttons: ['copy', 'excel', 'pdf', 'colvis']
            });

            table.buttons().container()
                .appendTo('#example_wrapper .col-sm-6:eq(0)');

        });
    </script>


    <script>

        $(function () {
            $('#BtnSave').click(function () {
                email = '<%= Request.QueryString("Email")%>';
                var password = $("[id*=txtNewPassword]").val();
                var cpassword = $("[id*=txtConfirmPassword]").val();

                if (password == '') {
                    $('#failMsg').show().html('Please Enter Password to continue');
                    return false;
                }

                if (cpassword != password) {
                    $('#failMsg').show().html('Password do not match');
                    return false;
                }

                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "ChangePassword.aspx/Resetpass",
                    data: "{'email':'" + email + "','password':'" + password + "'}",
                    dataType: "json",
                    success: function (data) {

                        var returnMsg = data.d

                        if (returnMsg != '') {

                            if (returnMsg == 'Success') {
                                window.location.replace('Dashboard.aspx?Email=' + email + '&npr=reset')
                            }

                        }

                    },
                    beforeSend: function () {
                        // Code to display spinner
                        $('#spinner').show();
                    },
                    complete: function () {
                        // Code to hide spinner.
                        $('#spinner').hide();
                    },
                    error: function (result) {
                        alert('Error Occured, please try again.');
                    }
                });//ajax ends

            })
       });
    </script>

</asp:Content>




