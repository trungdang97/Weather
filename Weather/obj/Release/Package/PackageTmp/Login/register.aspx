<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Weather.Login.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng ký tài khoản</title>
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
            <div class="col-md-2" style="height:100%;">
                <div class="login-panel">
                    <div class="text-center" style="padding-bottom: 30px">
                        <img src="../Content/Icons/kttv_logo.jpg" width="100px" />
                    </div>
                    <form id="form1">
                        <div class="form-group">
                            <label>Tên tài khoản<span class="required" style="color: red">(*)</span></label>
                            <input type="text" class="form-control" id="Username" placeholder="Tài khoản"/>
                            <div >

                            </div>
                        </div>
                        <div class="form-group">
                            <label>Số điện thoại<span class="required" style="color: red">(*)</span></label>
                            <input type="text" class="form-control" id="Phone" placeholder="Số điện thoại"/>
                            <div>

                            </div>
                        </div>
                        <div class="form-group">
                            <label>Tên đầy đủ<span class="required" style="color: red">(*)</span></label>
                            <input type="text" class="form-control" id="FullName" placeholder="Họ và tên"/>
                        </div>
                        <div class="form-group">
                            <label>Tên và đệm<span class="required" style="color: red">(*)</span></label>
                            <input type="text" class="form-control" id="ShortName" placeholder="Tên và đệm tên"/>
                        </div>
                        <div class="form-group">
                            <label>Mật khẩu<span class="required" style="color: red">(*)</span></label>
                            <input type="password" class="form-control" id="Password" placeholder="Mật khẩu" />
                        </div>
                        <div class="text-center">
                            <%--<asp:Button ID="LoginBtn" Text="Đăng nhập" runat="server" CssClass="btn btn-primary" OnClick="LoginBtn_click" />--%>
                            <button type="button" id="Register" class="btn btn-primary">Đăng ký</button>
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
        $(".login-panel").css("top", "20%");
        
    </script>
    <script src="JS/register.js"></script>
</body>
</html>