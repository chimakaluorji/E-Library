<%@ Page Language="VB" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="false" CodeFile="Dashboard.aspx.vb" Inherits="Admin_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!--=== Content Medium Part ===-->
    <style>
        #progressbar {
            background-color: black;
            background-repeat: repeat-x;
            border-radius: 13px; /* (height of inner div) / 2 + padding */
            padding: 3px;
        }

            #progressbar > div {
                background-color: #2CD5B6;
                width: 0%; /* Adjust with JavaScript */
                height: 20px;
                border-radius: 10px;
            }

        input[type="file"] {
            display: none;
        }

        .custom-file-upload {
            border: 1px solid #2CD5B6;
            display: inline-block;
            padding: 6px 12px;
            cursor: pointer;
        }
    </style>

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
                            <h3 class="panel-title sortable-widget-handle">Upload eBooks</h3>
                        </div>
                        <!-- /panel-heading -->

                        <!-- /panel-body -->
                        <div class="panel-body bordered-bottom">
                            <div style="color: #F25926; font-size: 15px; display: none; text-align: center;" id="spinnerPosition">
                                <img src="images/loader7.gif" />
                                ..........Please wait, <strong>processing</strong> .......
                                           <img src="images/loading.gif" />
                            </div>

                            <div class="form-group">
                                <label class="control-label text-inverse">Course/Subject Area: </label>
                                <asp:DropDownList ID="ddlCourseArea" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>

                            <div class="form-group">
                                <b style="font-size: 30px;">Book Details</b>
                            </div>

                            <div class="form-group">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label text-inverse col-sm-4">Book Title: </label>
                                        <asp:TextBox ID="txtBookTitle1" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <label class="control-label text-inverse col-sm-4">Cover Page: </label>
                                        <div class="col-lg-10">
                                            <div id="dZUploadCoverPage1" class="dropzone">
                                                <div class="dz-default dz-message">
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label text-inverse col-sm-4">Book Author: </label>
                                        <asp:TextBox ID="txtBookAuthor1" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <label class="control-label text-inverse col-sm-4">eBook: </label>
                                        <div class="col-lg-10">
                                            <div id="dZUploadeBook1" class="dropzone">
                                                <div class="dz-default dz-message">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
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

                            <div class="form-group">
                                <b style="font-size: 30px;">&nbsp;</b>
                            </div>

                            <div class="form-group">
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <input type="button" value="Upload Book" id="btnUploadBooks" class="btn btn-primary" />
                            </div>

                             <div class="form-group">
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                 <input type="button" value="Reload" id="btnReload" class="btn btn-primary" style="display: none;"/>
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
    
    <script src="latestJs_1.11/jquery.min.js"></script>
    <script src="DropzoneJs_scripts/dropzone.js"></script>


    <script>

        ////Upload Files

        var CoverPageUrl1 = '';
        var eBookUrl1 = '';

        Dropzone.autoDiscover = false;

        //Upload Cover Page
        $("#dZUploadCoverPage1").dropzone({
            url: "CoverPageFileUploader.ashx",
            addRemoveLinks: true,
            success: function (file, response) {
                CoverPageUrl1 = response;
                file.previewElement.classList.add("dz-success");
                console.log("Successfully uploaded :" + CoverPageUrl1);

            },
            error: function (file, response) {
                file.previewElement.classList.add("dz-error");
            }
        });

        //Upload eBook
        $("#dZUploadeBook1").dropzone({
            url: "eBookFileUploader.ashx",
            addRemoveLinks: true,
            success: function (file, response) {
                eBookUrl1 = response;
                file.previewElement.classList.add("dz-success");
                console.log("Successfully uploaded :" + eBookUrl1);
            },
            error: function (file, response) {
                file.previewElement.classList.add("dz-error");
            }
        });

        $('#btnUploadBooks').click(function () {


            var CourseAreaID = $("[id$=ddlCourseArea]").find("option:selected").val();

            if (CourseAreaID == 0) {
                $('#failmsg5').show().html("Please Select Course/Subject Area to Continue");
                return
            }


            var BookTitle1 = $("[id*=txtBookTitle1]").val();
            var BookAuthor1 = $("[id*=txtBookAuthor1]").val();

            //Checking if excel file was selected for upload

            if (BookTitle1 == '') {
                $('#failmsg5').show().html("Please enter the Book Title to Continue");
                return
            }
            if (BookAuthor1 == '') {
                $('#failmsg5').show().html("Please enter the Book Author to Continue");
                return
            }

            //if (BookTitle1 == '') {
            //    BookTitle1 = 'NO BOOK'
            //}
            //if (BookAuthor1 == '') {
            //    BookAuthor1 = 'NO BOOK'
            //}


            //Checking if excel file was selected for upload
            if (CoverPageUrl1 == '') {
                $('#failmsg5').show().html("Please Select Cover Page to Continue");
                return
            }

            if (eBookUrl1 == '') {
                $('#failmsg5').show().html("Please Select eBook to Continue");
                return
            }

            //if (CoverPageUrl1 == '') {
            //    CoverPageUrl1 = '../CoverPage/NoBook.jpg'
            //}

            //if (eBookUrl1 == '') {
            //    eBookUrl1 = '~/eBook/NoBook.jpg'
            //}

            $('#failmsg5').hide()
            var FailMsg = 'Something went wrong, please try again later';


            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Dashboard.aspx/UploadeBooks",
                data: "{'CourseAreaID':'" + CourseAreaID + "','BookTitle1':'" + BookTitle1 + "','BookAuthor1':'" + BookAuthor1
                        + "','CoverPageUrl1':'" + CoverPageUrl1 + "','eBookUrl1':'" + eBookUrl1 + "'}",
                dataType: "json",
                success: function (data) {

                    var obj = data.d;

                    if (obj == 'success') {
                        $('#failmsg5').hide();
                        $('#btnReload').show();
                        $('#successmsg5').show().html('The book was successfully uploaded. Click on Reload Button to upload another book');
                    }

                },
                beforeSend: function () {
                    // Code to display spinner
                    $('#spinner5').show();
                },
                complete: function () {
                    // Code to hide spinner.
                    $('#spinner5').hide();
                },
                error: function (result) {
                    $('#failmsg5').show().html(FailMsg);
                }
            }); //Ajax Ends


        })

        //Reload the page
        $('#btnReload').click(function () {
            $('#btnReload').hide();
            location.reload();
        })

        //Loading the dropdownlist
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "Dashboard.aspx/GetPosition",
            data: "{}",
            dataType: "json",
            success: function (data) {

                var ddlPosition = $("[id*=ddlCourseArea]");
                ddlPosition.empty().append('<option selected="selected" value="0">--Please select--</option>');
                $.each(data.d, function () {
                    ddlPosition.append($("<option></option>").val(this['Value']).html(this['Text']));
                });

            },
            beforeSend: function () {
                // Code to display spinner
                $('#spinnerPosition').show();
            },
            complete: function () {
                // Code to hide spinner.
                $('#spinnerPosition').hide();
            },
            error: function (result) {
                alert('Error Occured.');
            }
        });
    </script>
</asp:Content>
