<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Dashboard.aspx.vb" Inherits="User_Dashboard" %>

<!DOCTYPE html>
<html lang="en">


<!-- Mirrored from wintechserver.com/mojo/styleshop/html/category.html by HTTrack Website Copier/3.x [XR&CO'2014], Mon, 01 Jun 2015 07:42:50 GMT -->
<head>
    <meta charset="utf-8">
    <title>Air Force Comprehensive Secodary School | e-Library</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">

    <!-- Fonts -->
    <link href='http://fonts.googleapis.com/css?family=Droid+Serif' rel='stylesheet' type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Ubuntu' rel='stylesheet' type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400italic,400,800,700,300' rel='stylesheet' type='text/css'>

    <!-- styles -->
    <link href="css/bootstrap.css" rel="stylesheet">
    <link href="css/bootstrap-responsive.css" rel="stylesheet">
    <link href="css/docs.css" rel="stylesheet">
    <link href="js/google-code-prettify/prettify.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">
    <link href="css/Pagination.css" rel="stylesheet" />
    <!-- Slider -->
    <link rel="stylesheet" href="css/default.html" type="text/css" media="screen" />
    <link rel="stylesheet" href="css/nivo-slider.css" type="text/css" media="screen" />

    <!-- Icon -->
    <link href="font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="css/font-awesome.min.css" />
    <!--[if lt IE 9]>
      <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->

    <!-- fav and touch icons -->
    <link rel="shortcut icon" href="images/HomeLogo/favico.png" type="image/ico" />
</head>
<body>
    <form id="form1" runat="server">
        <!-- Header Start -->
        <header>
            <!-- Sticky Navbar Start -->
            <div id="main-nav" class="navbar navbar-fixed-top">
                <div class="container">
                    <button type="button" class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <ul class="nav">
                        <li><a href="#"><i class="icon-envelope"></i>afcs@gmail.com</a></li>
                        <li><a href="#"><i class="icon-phone-sign"></i>0802 737 4466</a></li>
                    </ul>
                </div>
            </div>
            <!--Sticky Navbar End -->

            <div class="header-white">
                <div class="container">
                    <div class="row">
                        <div class="span4">
                            <a href="#" class="logo">
                                <img title="eLibrary" alt="eLibrary" src="images/logo.png"></a>
                        </div>
                        <div class="span8">
                            <div class="row">
                                <div class="pull-right logintext">
                                    WELCOME YOU, YOU CAN <a href="Default.aspx">CLICK HERE TO LOGOUT </a>
                                </div>
                            </div>
                            <%-- <form class="form-search marginnull topsearch pull-right">--%>
                            <div class="span6 pull-right">
                                <%--<button value="Search" class="btn btn-success pull-right search" type="submit">Search</button>--%>
                                <%--<asp:Button ID="btnSearch" runat="server" Text="Search" class="btn btn-success pull-right search" />--%>
                                <input type="button" value="Search" id="btnSearch" class="btn btn-success pull-right search" />
                                <%--<input type="text" class="span5 search-query search-icon-top pull-right" value="Search here..." onfocus="if (this.value=='Search here...') this.value='';" onblur="if (this.value=='') this.value='Search here...';">--%>
                                <asp:TextBox ID="txtSearch" runat="server" class="span5 search-query search-icon-top pull-right" placeholder="Search With Book Title"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <!-- Navigation Start -->
                    <div id="categorymenu">
                        <div class="container">
                            <nav class="subnav">
                            </nav>
                        </div>
                    </div>
                    <!-- Navigation Ends -->
                </div>
            </div>
        </header>
        <!-- Header Ends -->
        <!--Content starts-->
        <div id="maincontainer">

            <div class="container">
                <asp:Label ID="lblError" runat="server" Text="" Font-Size="15px" Font-Bold="true"></asp:Label>
                <div class="row">
                    <div class="span12">
                        <section id="latest">
                            <div class="row">
                                <div class="span12">
                                    <div class="sorting well">
                                        <div class="form-inline pull-left">
                                            Sort By Course:
                         
                                            <asp:DropDownList ID="ddlCourseArea" runat="server" CssClass="form-control"></asp:DropDownList>

                                            <%--<asp:Button ID="BtnSearchBook" runat="server" Text="Sort" class="btn btn-success" />--%>
                                            <input type="button" value="Sort" id="btnSort" class="btn btn-success" />
                                        </div>

                                        <div class="btn-group pull-right">
                                            <button id="btngrid" class="btn btn-success"><i class="icon-th icon-white"></i></button>
                                        </div>

                                    </div>
                                    <section id="thumbnails">
                                        <div style="color: #F25926; font-size: 15px; display: none; text-align: center;" id="spinner">
                                            <img src="images/loading.gif" />
                                            ...Please wait, <strong>the System is Working</strong> ...
                                            <img src="images/loader7.gif" />
                                        </div>
                                        <asp:Panel ID="PnlGrid" runat="server" Width="100%">
                                            <ul class="thumbnails grid" style="display: block;">
                                                  <div id="Request"></div>
                                                <div id="Pagination"></div>
                                                 
                                            </ul>
                                          
                                        </asp:Panel>
                                    </section>
                                </div>
                            </div>

                        </section>
                    </div>
                </div>
            </div>
        </div>
        <!-- Footer Starts-->
        <footer>
            <section class="copyrightbottom">
                <div class="container">
                    <div class="row">
                        <div class="span6">Air Force Comprehensive Secodary School.</div>
                        <div class="span6 textright">Designed by CK HardByte Nig. LTD.</div>
                    </div>
                </div>
            </section>
            <a id="gotop" href="#">Back to top</a>
        </footer>
        <!-- /maincontainer -->

        <!-- javascript
    ================================================== -->
        <!-- Placed at the end of the document so the pages load faster -->
        <script src="js/jquery.js"></script>
        <script src="js/google-code-prettify/prettify.js"></script>
        <script src="js/bootstrap-transition.js"></script>
        <script src="js/bootstrap-alert.js"></script>
        <script src="js/bootstrap-modal.js"></script>
        <script src="js/bootstrap-dropdown.js"></script>
        <script src="js/bootstrap-scrollspy.js"></script>
        <script src="js/bootstrap-tab.js"></script>
        <script src="js/bootstrap-tooltip.js"></script>
        <script src="js/bootstrap-popover.js"></script>
        <script src="js/bootstrap-button.js"></script>
        <script src="js/bootstrap-collapse.js"></script>
        <script src="js/bootstrap-carousel.js"></script>
        <script src="js/bootstrap-typeahead.js"></script>
        <script src="js/bootstrap-affix.js"></script>
        <script src="js/application.js"></script>
        <script src="js/respond.min.js"></script>
        <script src="js/cloud-zoom.1.0.2.js"></script>
        <script type="text/javascript" src="js/jquery.nivo.slider.js"></script>
        <script defer src="js/custom.js"></script>
        <script type="text/javascript">
            $(window).load(function () {
                $('#slider').nivoSlider();
            });
        </script>


        <script src="scripts/39914ff3.vendor-main.js"></script>

        <script>

            $(function () {

                //Declaring Variable
                var maxNum = 12;
                var minNum = 1;
                var Value = 0;

                //Calling the loadPage function
                loadPage(maxNum, minNum);

                //Pagination
                var Pagination = '<ul class="pagination">';
                Pagination += '<li class="inline"><a class="linka active" href="#1">1</a></li>';
                Pagination += '<li class="inline"><a class="linka" href="#2">2</a></li>';
                Pagination += '<li class="inline"><a class="linka" href="#3">3</a></li>';
                Pagination += '<li class="inline"><a class="linka" href="#4">4</a></li>';
                Pagination += '<li class="inline"><a class="linka" href="#5">5</a></li>';
                Pagination += '<li class="inline"><a class="linka" href="#6">6</a></li>';
                Pagination += '<li class="inline"><a class="linka" href="#7">7</a></li>';
                Pagination += '<li class="inline"><a class="linka" href="#8">8</a></li>';
                Pagination += '<li class="inline"><a class="linka" href="#9">9</a></li>';
                Pagination += '<li class="inline"><a class="linka" href="#10">10</a></li>';
                Pagination += '<li class="inline"><a class="linka" href="#11">11</a></li>';
                Pagination += '<li class="inline"><a class="linka" href="#12">12</a></li>';
                Pagination += '<li class="inline"><a class="linka" href="#13">13</a></li>';
                Pagination += '<li class="inline"><a class="linka" href="#14">14</a></li>';
                Pagination += '<li class="inline"><a class="linka" href="#15">15</a></li>';
                Pagination += '</ul>';

                $('#Pagination').append(Pagination);

                //Click Paging Link
                $(".linka").click(function () {
                    //Declaring Variables for pagination
                    var strValue = $(this).attr("href");
                    var splitValue = strValue.split("#")

                    Value = splitValue[1]

                    var xmaxNum = 0
                    var xminNum = 0

                    var xmaxSubNum = 0

                    xmaxSubNum = 12 * Value
                    xmaxNum = xmaxSubNum - 1
                    xminNum = xmaxSubNum - 12

                    if (xminNum == 0) {
                        xmaxNum = 12
                    }
                    

                    //Calling the loadPage function
                    loadPage(xmaxNum, xminNum);

                    //Automatically showning active class
                    $(".linka").removeClass("active");
                    $(this).addClass("linka active");

                });

                //Click Paging Link
                $(".linkNext").click(function () {
                    $(".linkNext").removeClass("active");
                    $(this).addClass("linka active");
                });


                //Searching for page
                $("#btnSearch").click(function () {
                    //Clearing Request
                    $('#Request').html("");
                    $('#Pagination').html("");

                    var Search = $("[id*=txtSearch]").val();

                    loadSearchPage(maxNum, minNum, Search)
                });


                //Sorting Page By Course ID
                $("#btnSort").click(function () {
                    //Clearing Request
                    $('#Request').html("");
                    $('#Pagination').html("");
                    var CourseID = $("[id*=ddlCourseArea]").find("option:selected").val();

                    loadSortPage(maxNum, minNum, CourseID)
                });


                //Loading the page
                function loadPage(max, min) {
                    //Clearing Request
                    $('#Request').html("");

                    //Find All Request to Donate
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "Dashboard.aspx/FindAlleBookDetails",
                        data: "{'max':'" + max + "','min':'" + min + "'}",
                        dataType: "json",
                        success: function (data) {


                            var checkValue;
                            checkValue = data.d[0].CourseAreaID

                            if (checkValue != 0) {

                                for (var i = 0; i < data.d.length; i++) {
                                    //Request

                                    var Request = '<li class="span3">';
                                    Request += '<div class="prdocutname" style="font-size:15px; font-weight:500">' + data.d[i].BookTitle + '</div>';
                                    Request += '<div class="thumbnail">';
                                    Request += '<a href="ReadeBook.aspx?e=' + data.d[i].eBookUrl + '" target="_blank"><span><span>';
                                    Request += '<img class="mydiv" src="' + data.d[i].CoverPageUrl + '" /> </a></span></span>';
                                    Request += '<div class="caption">';
                                    Request += '<div class="price pull-left">';
                                    Request += '<span class="newprice">' + data.d[i].BookAuthor + '</span>';
                                    Request += '</div>';
                                    Request += '<a href="ReadeBook.aspx?e=' + data.d[i].eBookUrl + '" class="btn pull-right" target="_blank">Read Book</a>';
                                    Request += '<div class="clearfix"></div>';
                                    Request += '</div>';
                                    Request += '</div>';
                                    Request += '</li>';

                                    $('#Request').append(Request);


                                }//End For


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
                            alert('Cannot load eBook at the moment.');
                        }
                    }); //Ajax Ends
                }



                //Loading the page via search
                function loadSearchPage(max, min, searchValue) {
                    //Clearing Request
                    //$('#Request').html("");

                    //Find All Request to Donate
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "Dashboard.aspx/FindAlleBookDetailsBySearch",
                        data: "{'max':'" + max + "','min':'" + min + "','searchValue':'" + searchValue + "'}",
                        dataType: "json",
                        success: function (data) {


                            var checkValue;
                            checkValue = data.d[0].CourseAreaID

                            if (checkValue != 0) {

                                for (var i = 0; i < data.d.length; i++) {
                                    //Request

                                    var Request = '<li class="span3">';
                                    Request += '<div class="prdocutname" style="font-size:15px; font-weight:500">' + data.d[i].BookTitle + '</div>';
                                    Request += '<div class="thumbnail">';
                                    Request += '<a href="ReadeBook.aspx?e=' + data.d[i].eBookUrl + '" target="_blank"><span><span>';
                                    Request += '<img class="mydiv" src="' + data.d[i].CoverPageUrl + '" /> </a></span></span>';
                                    Request += '<div class="caption">';
                                    Request += '<div class="price pull-left">';
                                    Request += '<span class="newprice">' + data.d[i].BookAuthor + '</span>';
                                    Request += '</div>';
                                    Request += '<a href="ReadeBook.aspx?e=' + data.d[i].eBookUrl + '" class="btn pull-right" target="_blank">Read Book</a>';
                                    Request += '<div class="clearfix"></div>';
                                    Request += '</div>';
                                    Request += '</div>';
                                    Request += '</li>';

                                    $('#Request').append(Request);


                                }//End For


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
                            alert('Cannot load eBook at the moment.');
                        }
                    }); //Ajax Ends
                }


                //Loading the page via Sort
                function loadSortPage(max, min, courseID) {

                    //Find All Request to Donate
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "Dashboard.aspx/FindAlleBookDetailsBySort",
                        data: "{'max':'" + max + "','min':'" + min + "','courseID':'" + courseID + "'}",
                        dataType: "json",
                        success: function (data) {


                            var checkValue;
                            checkValue = data.d[0].CourseAreaID

                            if (checkValue != 0) {

                                for (var i = 0; i < data.d.length; i++) {
                                    //Request

                                    var Request = '<li class="span3">';
                                    Request += '<div class="prdocutname" style="font-size:15px; font-weight:500">' + data.d[i].BookTitle + '</div>';
                                    Request += '<div class="thumbnail">';
                                    Request += '<a href="ReadeBook.aspx?e=' + data.d[i].eBookUrl + '" target="_blank"><span><span>';
                                    Request += '<img class="mydiv" src="' + data.d[i].CoverPageUrl + '" /> </a></span></span>';
                                    Request += '<div class="caption">';
                                    Request += '<div class="price pull-left">';
                                    Request += '<span class="newprice">' + data.d[i].BookAuthor + '</span>';
                                    Request += '</div>';
                                    Request += '<a href="ReadeBook.aspx?e=' + data.d[i].eBookUrl + '" class="btn pull-right" target="_blank">Read Book</a>';
                                    Request += '<div class="clearfix"></div>';
                                    Request += '</div>';
                                    Request += '</div>';
                                    Request += '</li>';

                                    $('#Request').append(Request);


                                }//End For


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
                            alert('Cannot load eBook at the moment.');
                        }
                    }); //Ajax Ends
                }




                //Loading Courses
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
                        $('#spinner').show();
                    },
                    complete: function () {
                        // Code to hide spinner.
                        $('#spinner').hide();
                    },
                    error: function (result) {
                        alert('Error Occured.');
                    }
                });

            });


        </script>
</body>
</form> 
<!-- Mirrored from wintechserver.com/mojo/styleshop/html/category.html by HTTrack Website Copier/3.x [XR&CO'2014], Mon, 01 Jun 2015 07:42:50 GMT -->
</html>
