<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Weather.Login.LoginForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập</title>
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.min.js"></script>
    <link href="CSS/Index.css" rel="stylesheet" />
</head>
<body>
    <div class="container-fluid" style="height: 100%">
        <div class="row justify-content-center">
            <div class="col-md-5"></div>
            <div class="col-md-2" style="height: 100%;">
                <div class="login-panel">
                    <div class="text-center" style="padding-bottom: 30px">
                        <img src="../Content/Icons/kttv_logo.jpg" width="100px" />
                    </div>
                    <form id="form1" runat="server">
                        <div class="form-group">
                            <% if (HttpContext.Current.Session["warning"] != null)
                                {
                                    Response.Write("<span class='text text-danger'>" + HttpContext.Current.Session["warning"] + "</span>");
                                } %>
                            <label for="username">Tên tài khoản</label>
                            <input type="text" class="form-control" id="username" name="username" placeholder="Tài khoản" />
                        </div>
                        <div class="form-group">
                            <label for="pwd">Mật khẩu:</label>
                            <input type="password" class="form-control" id="pwd" name="password" placeholder="Mật khẩu" />
                        </div>

                        <%--<div class="form-group form-check">
                            <label class="form-check-label">
                                <input class="form-check-input" type="checkbox" />
                                Remember me
                            </label>
                        </div>--%>
                        <div class="text-center">
                            <asp:Button ID="LoginBtn" Text="Đăng nhập" runat="server" CssClass="btn btn-primary" OnClick="LoginBtn_click" />
                        </div>
                        <br />
                        <div class="text-center">
                            <a href="register.aspx">Đăng ký</a>
                        </div>
                    </form>

                </div>
            </div>
            <div class="col-md-5"></div>
        </div>
    </div>
    <script>
        var viewport = $(window).height();
        var login = $(".login-panel").height();
        var percent = (viewport - login) / viewport / 2 * 100 + "%";
        $(".login-panel").css("top", "35%");

    </script>
</body>
</html>
