<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Admin_Default" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">

    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="Quickpair">
    <meta name="author" content="Quickpair">

    <meta http-equiv="x-pjax-version" content="v173">

    <link rel="stylesheet" href="styles/9281c719.vendor.css" />
    <link rel="stylesheet" href="styles/3fc417cd.main.css" />

    <link href="//maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css" rel="stylesheet">

    <!-- Le HTML5 shim, for IE6-8 support of HTML5 elements -->
    <!--[if lt IE 9]>
      <script src="//cdnjs.cloudflare.com/ajax/libs/html5shiv/3.7/html5shiv.min.js"></script>
    <![endif]-->

    <link href="../css/Table/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/DropzoneJs_scripts/dropzone.css" rel="stylesheet" />

    <link rel="shortcut icon" href="images/HomeLogo/favico.png" type="image/ico" />

</head>

<body class="animated fadeIn">
    <form id="Form1" runat="server">
        <div class="content content-full">
            <div class="container">
                <div class="signin-wrapper">
                    <div class="tab-content">
                        <div class="row tab-pane fade in active" id="signin">
                            <div class="col-md-offset-1 col-md-6 hidden-sm hidden-xs">
                                <div id="carousel-example" class="carousel slide" data-ride="carousel">
                                    <ol class="carousel-indicators">
                                        <li data-target="#carousel-example" data-slide-to="0" class="active"></li>
                                        <li data-target="#carousel-example" data-slide-to="1"></li>
                                        <li data-target="#carousel-example" data-slide-to="2"></li>
                                        <li data-target="#carousel-example" data-slide-to="3"></li>
                                        <li data-target="#carousel-example" data-slide-to="4"></li>
                                    </ol>
                                    <div class="carousel-inner">
                                        <div class="item active">
                                            <img src="images/dummy/04.jpg" alt="Slide image">
                                        </div>
                                        <div class="item">
                                            <img src="images/dummy/02.jpg" alt="Slide image">
                                        </div>
                                        <div class="item">
                                            <img src="images/dummy/03.jpg" alt="Slide image">
                                        </div>
                                        <div class="item">
                                            <img src="images/dummy/01.jpg" alt="Slide image">
                                        </div>
                                        <div class="item">
                                            <img src="images/dummy/05.jpg" alt="Slide image">
                                        </div>
                                    </div>
                                    <a class="left carousel-control" href="#carousel-example" data-slide="prev">
                                        <span class="glyphicon glyphicon-chevron-left"></span>
                                    </a>
                                    <a class="right carousel-control" href="#carousel-example" data-slide="next">
                                        <span class="glyphicon glyphicon-chevron-right"></span>
                                    </a>
                                </div>
                            </div>
                            <!--/cols-->

                            <div class="col-md-offset-1 col-md-4 col-sm-offset-2 col-sm-8">
                                <div class="signin">
                                    <div class="signin-brand">
                                        <a href="#">
                                            <img class="lazy" src="images/HomeLogo/HomeLogo.png" alt="Logo">
                                        </a>
                                    </div>

                                    <div>
                                        <div style="color: #45ae52; font-size: 15px; display: none; text-align: center;" id="spinner">
                                            <img src="images/loader7.gif" />
                                            ..........Please wait, <strong>processing</strong> .......
                                           <img src="images/loading.gif" />
                                        </div>
                                        <div class="alert alert-success" id="successMsg" style="display: none;">
                                            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                                        </div>
                                        <div class="alert alert-danger" id="failMsg" style="display: none;">
                                            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&t&times;</button>
                                        </div>
                                        <div class="form-group">
                                            <div class="input-group input-group-in">
                                                <span class="input-group-addon text-muted"><i class="fa fa-user"></i></span>
                                                <asp:TextBox ID="txtUsername" runat="server" class="form-control" placeholder="Enter Your Username" autocomplete="off"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <div class="input-group input-group-in">
                                                <span class="input-group-addon text-muted"><i class="fa fa-lock"></i></span>
                                                <asp:TextBox ID="txtPassword" runat="server" class="form-control" TextMode="Password" placeholder="Enter Your Password" autocomplete="off"></asp:TextBox>
                                            </div>
                                            <!--/input-group-->
                                        </div>
                                        <!--/form-group-->

                                        <div class="form-group form-actions">
                                            <input type="button" value="Sign In" id="BtnSignIn" class="hidden-sm btn btn-primary" />
                                            <input type="button" value="Sign In" id="BtnSignIn2" class="visible-sm btn btn-lg btn-block btn-primary" />
                                        </div>
                                        <!--/form-group-->

                                        <p>
                                            <small>
                                                <a href="#modalRecover" data-toggle="modal">Forgot your password?</a>
                                            </small>
                                        </p>
                                        <%--<p class="hidden-sm">
                                            <a href="#" rel="tooltip" title="Signin with Twitter account" class="btn btn-sm btn-info"><span class="fa fa-twitter"></span></a>
                                            <a href="#" rel="tooltip" title="Signin with Google account" class="btn btn-sm btn-danger"><span class="fa fa-google-plus"></span></a>
                                            <a href="#" rel="tooltip" title="Signin with Github account" class="btn btn-sm btn-cloud"><span class="fa fa-github"></span></a>
                                        </p>--%>

                                      <%--  <p class="margin-top"><small>Don't have a account? <a href="CreateAccount.aspx"><strong>Create an Account</strong></a></small></p>--%>
                                    </div>
                                </div>


                                <!-- modalRecover -->
                                <div class="modal fade" id="modalRecover" tabindex="-1" role="dialog" aria-labelledby="modalRecoverLabel" aria-hidden="true">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                <h4 class="modal-title" id="modalRecoverLabel">Reset Password</h4>
                                            </div>
                                            <div class="modal-body">
                                                <div style="color: #45ae52; font-size: 15px; display: none; text-align: center;" id="spinner1">
                                                    <img src="images/loader7.gif" />
                                                    Please wait, <strong>system is checking your account</strong>
                                                    <img src="images/loading.gif" />
                                                </div>
                                                <div class="alert alert-success" id="successMsg1" style="display: none;">
                                                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                                                </div>
                                                <div class="alert alert-danger" id="failMsg1" style="display: none;">
                                                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                                                </div>
                                                <div class="form-group">
                                                    <div class="input-group input-group-in">
                                                        <span class="input-group-addon text-muted"><i class="fa fa-envelope"></i></span>
                                                        <input type="email" class="form-control" name="emailUp" id="email" required="" autocomplete="off">
                                                    </div>
                                                </div>
                                                <p class="text-muted"><small>Enter your email and we will send your password to you.</small></p>
                                            </div>

                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                <input type="button" value="Send reset link" id="BtnReset" class="btn btn-primary" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="signin-footer">
                        <ul class="list-inline pull-right">
                            <li><a href="../Default.aspx">Student's Login</a></li>
                        </ul>
                        <ul class="list-inline">
                             <li>&copy;<%=Today.Year%> Powered By CK-HardByte Nig. LTD.</li>
                            <li><a href="#">Terms of Use</a></li>
                        </ul>
                    </div>

                </div>
                <!--/signin-wapper-->

            </div>
            <!--/container-->
        </div>
        <!--/content-->
        <!-- javascript
    ================================================== -->
        <script src="scripts/39914ff3.vendor-main.js"></script>
        <script src="scripts/756399db.vendor-usefull.js"></script>
        <script src="scripts/e7058f60.vendor-form.js"></script>
        <script src="scripts/fc9d433c.vendor-editor.js"></script>

        <script src="../js/jquery-1.8.2.js"></script>
        <script src="../css/latestJs_1.11/jquery.min.js"></script>
        <script src="../css/DropzoneJs_scripts/dropzone.js"></script>


        <!--[if lte IE 8]>
    <script src="scripts/eae815b5.excanvas.js"></script>
    <![endif]-->
        <script src="scripts/2ce1156c.vendor-graph.js"></script>
        <script src="scripts/37a77790.vendor-table.js"></script>
        <script src="scripts/1581b2aa.vendor-maps.js"></script>
        <script src="scripts/5f4fd25b.vendor-util.js"></script>


        <script>

            //Login Secondary
            $(function () {


                $('#BtnSignIn').click(function () {
                    //Calling SignIn Function
                    SignIn();
                })

                $(document).keypress(function (e) {
                    if (e.which == 13) {
                        //Calling SignIn Function
                        SignIn();
                    }
                });

                $('#BtnReset').click(function () {

                    if (email == '') {
                        $('#successMsg1').show().html('Please contact the admin');
                        return false;
                    }


                })


                function SignIn() {
                    //Sign in argument

                    var Email = $("[id*=txtUsername]").val();
                    var Password = $("[id*=txtPassword]").val();

                    if (Email == '') {
                        $('#failMsg').show().html('Please Enter Username to Continue');
                        $('#successMsg').hide()
                        return false;
                    }

                    if (Password == '') {
                        $('#failMsg').show().html('Please Enter Password to Continue');
                        $('#successMsg').hide()
                        return false;
                    }

                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "Default.aspx/Login",
                        data: "{'Email':'" + Email + "','Password':'" + Password + "'}",
                        dataType: "json",
                        success: function (data) {

                            var obj = data.d;

                            if (obj != '') {

                                var retSplit = obj.split("/")
                                var retSuccess = retSplit[0]
                                var retUrl = retSplit[1]


                                if (retSuccess == 'success') {
                                    window.location.replace('Dashboard.aspx?Email=' + retUrl)
                                } else {
                                    $('#failMsg').show().html(retSuccess);
                                    $('#successMsg').hide()
                                    return false;
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
                            $('#failMsg').show().html('User was NOT successfully created.');
                        }
                    }); //Ajax Ends
                }
            });


            var cbpAnimatedHeader = (function () {
                var docElem = document.documentElement,
                        header = document.querySelector('.navbar-default'),
                        didScroll = false,
                        changeHeaderOn = 200;
                function init() {
                    window.addEventListener('scroll', function (event) {
                        if (!didScroll) {
                            didScroll = true;
                            setTimeout(scrollPage, 250);
                        }
                    }, false);
                }
                function scrollPage() {
                    var sy = scrollY();
                    if (sy >= changeHeaderOn) {
                        $(header).addClass('navbar-scroll')
                    }
                    else {
                        $(header).removeClass('navbar-scroll')
                    }
                    didScroll = false;
                }
                function scrollY() {
                    return window.pageYOffset || docElem.scrollTop;
                }
                init();

            })();

            // Activate WOW.js plugin for animation on scrol
            new WOW().init();

        </script>



        <script src="../js/Table/jquery.dataTables.min.js"></script>
        <script src="../js/Table/dataTables.bootstrap.min.js"></script>
        <script src="../js/Table/dataTables.buttons.min.js"></script>
        <script src="../js/Table/buttons.bootstrap.min.js"></script>
        <script src="../js/Table/jszip.min.js"></script>
        <script src="../js/Table/pdfmake.min.js"></script>
        <script src="../js/Table/vfs_fonts.js"></script>
        <script src="../js/Table/buttons.html5.min.js"></script>
        <script src="../js/Table/buttons.colVis.min.js"></script>
        <!-- required stilearn template js -->
        <script src="scripts/5917523f.main.js"></script>
        <!-- This scripts will be reload after pjax or if popstate event is active (use with class .re-execute) -->
        <script src="scripts/89c3d6c9.initializer.js"></script>
    </form>
</body>
</html>
