<%@ Page Language="VB" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="false" CodeFile="CourseAreaSetup.aspx.vb" Inherits="Admin_CourseAreaSetup" %>

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
                            <h3 class="panel-title sortable-widget-handle">Course Area</h3>
                        </div>
                        <!-- /panel-heading -->

                        <!-- /panel-body -->
                        <div class="panel-body bordered-bottom">

                            <div class="form-group">
                                <a href="#modalShowMails" class="btn btn-info" data-toggle="modal" data-target="#modalShowMails">Add Course Area</a>
                            </div>
                            <div class="form-group">
                                <div id="table"></div>
                            </div>

                            <div class="alert alert-success" id="successmsg5" style="display: none;">
                                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                            </div>
                            <div class="alert alert-danger" id="failmsg5" style="display: none;">
                                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                            </div>
                            <div style="color: #F25926; font-size: 15px; display: none; text-align: center;" id="spinner5">
                                <img src="images/loader7.gif" />
                                ..........Please wait, <strong>processing</strong> .......
                                           <img src="images/loading.gif" />
                            </div>


                            <%--<div class="form-group">
                                <input type="button" value="Send Message" id="btnSendMsg" class="btn btn-primary" />
                                <input type="button" value="Close" id="btnClose" class="btn btn-default" />
                            </div>--%>
                            <br />
                        </div>
                        <!-- /panel-body -->
                    </div>
                    <!-- /panel-alco -->
                </div>
                <!--/cols -->

            </div>
        </div>
    </div>



    <div class="modal fade bs-example-modal-lg" id="modalShowMails" tabindex="-1" role="dialog" aria-labelledby="modalBasicLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="H2">ADD COURSE AREA</h4>
                </div>
                <div class="modal-body">
                    <div style="color: #36a924; font-size: 15px; display: none; text-align: center;" id="spinner1">
                        <img src="images/loader7.gif" />
                        ..........Please wait, <strong>processing</strong> .......
                                           <img src="images/loading.gif" />
                    </div>
                    <div class="alert alert-success" id="successMsg1" style="display: none;">
                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                    </div>
                    <div class="alert alert-danger" id="failMsg1" style="display: none;">
                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                    </div>
                     <div class="form-group">
                                <label class="control-label text-inverse col-sm-2" >Course Area: </label>
                                <asp:TextBox ID="txtCourseArea" runat="server" CssClass="form-control"></asp:TextBox>
                     </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    <input type="button" value="Save" id="btnSave" class="btn btn-primary" />
                </div>

                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->

        </div>
    </div>

     <div class="modal fade bs-example-modal-lg" id="modalEditDelete" tabindex="-1" role="dialog" aria-labelledby="modalBasicLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="H1">EDIT AND DELETE COURSE AREA</h4>
                </div>
                <div class="modal-body">
                    <div style="color: #36a924; font-size: 15px; display: none; text-align: center;" id="spinner2">
                        <img src="images/loader7.gif" />
                        ..........Please wait, <strong>processing</strong> .......
                                           <img src="images/loading.gif" />
                    </div>
                    <div class="alert alert-success" id="successMsg2" style="display: none;">
                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                    </div>
                    <div class="alert alert-danger" id="failMsg2" style="display: none;">
                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                    </div>
                     <div class="form-group">
                                <label class="control-label text-inverse col-sm-2" >Course Area: </label>
                                <asp:TextBox ID="txtCourseAreaEdit" runat="server" CssClass="form-control"></asp:TextBox>
                     </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    <input type="button" value="Edit" id="btnEdit" class="btn btn-primary" />
                    <input type="button" value="Delete" id="btnDelete" class="btn btn-danger" />
                </div>

                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->

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

        //load all complains by pairuserid

        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "CourseAreaSetup.aspx/GetAllCourseArea",
            data: "{}",
            dataType: "json",
            success: function (data) {


                $('#table').empty();

                var table = '<table id="Subject" class="table table-striped table-bordered" cellspacing="0" width="100%">';

                table += '<thead>';
                table += '<tr>';
                table += '<th>Course Area</th>';
                table += '<th></th>';
                table += '</tr>';
                table += '</thead>';

                table += '<tfoot>';
                table += '<tr>';
                table += '<th>Course Area</th>';
                table += '<th></th>';
                table += '</tr>';
                table += '</tfoot>';

                table += '<tbody>';

                for (var i = 0; i < data.d.length; i++) {
                    table += '<tr>';
                    table += '<td>' + data.d[i].CourseArea + '</td>';
                    table += '<td><a href="#modalEditDelete" class="btn btn-info edit" data-toggle="modal" data-target="#modalEditDelete" id="' + data.d[i].CourseAreaID + '">Edit Or Delete Course Area</a></td>';
                    table += '</tr>';
                }

                table += '</tbody>';

                table += '</table>';

                $('#table').append(table);



                //$(document).ready(function () {
                var table = $('#Subject').DataTable({
                    lengthChange: true,
                    buttons: ['copy', 'excel', 'pdf', 'colvis']
                });

                table.buttons().container()
                    .appendTo('#example_wrapper .col-sm-6:eq(0)');

                //});//Table End



                //GETTING PRIMARY ID
                $('.edit').click(function () {

                    essay_id = $(this).attr('id');

                    FetchID(essay_id);
                });// PRIMARY ID Ends


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
                $('#failMsg').show().html('Error occured');
                $('#successMsg').hide();
            }
        });// Ajax End



        function FetchID(essay_id) {

            //Getting session that need to be updated
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "CourseAreaSetup.aspx/GetAllCourseAreaByID",
                data: "{'CourseAreaID':'" + essay_id + "'}",
                dataType: "json",
                success: function (data) {
                    var obj = data.d;

                    if (obj != '') {
                        $("[id$='txtCourseAreaEdit']").val(data.d[0].CourseArea);
                    }
                },

                error: function (result) {
                    $('#failMsg1').show().html('Error occured');
                    $('#successMsg1').hide();
                }
            }); //Ajax Ends
        };// Function Ends





        $(function () {

            $('#btnSave').click(function () {
                //alert(essay_id);
                var CourseArea = $("[id*=txtCourseArea]").val();

                if (CourseArea == '') {
                    $('#failMsg1').show().html('Please Enter Course Area to Continue');
                    $('#successMsg1').hide();
                    return false;
                }

                var FailMsg = 'Something went wrong, please try again later';

                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "CourseAreaSetup.aspx/CreateCourseArea",
                    data: "{'CourseArea':'" + CourseArea + "'}",
                    dataType: "json",
                    success: function (data) {

                        var obj = data.d;

                        if (obj != '') {

                            if (obj == 'success') {
                                $('#successMsg1').show().html('The Course Area was successfully saved.');
                                $('#failMsg1').hide()

                                //Closing pop up modal
                                location.reload();
                            }
                        }

                    },
                    beforeSend: function () {
                        // Code to display spinner
                        $('#spinner1').show();
                    },
                    complete: function () {
                        // Code to hide spinner.
                        $('#spinner1').hide();
                    },
                    error: function (result) {
                        $('#failMsg1').show().html(FailMsg);
                    }
                }); //Ajax Ends


                function close_modal() {
                    $('#modalComplain').modal('hide');
                };
            })


            $('#BtnLogout').click(function () {

                var Email = '<%= Request.QueryString("Email")%>';
                var returnMsgFail = 'Something went wrong, try again';
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "ComplaintBox.aspx/Logout",
                    data: "{'Email':'" + Email + "'}",
                    dataType: "json",
                    success: function (data) {

                        var obj = data.d;

                        if (obj != '') {

                            if (obj == 'Success') {
                                window.location.replace("Default.aspx?npl=Logout")
                            } else {
                                $('#failMsg1').show().html(returnMsgFail);
                            }
                        }

                    },
                    error: function (result) {
                        $('#failMsg').show().html(returnMsgFail);
                    }
                }); //Ajax Ends
            })
        });

    </script>

</asp:Content>




