<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="CMS.Master" CodeBehind="admin.aspx.cs" Inherits="Weather.CMS.admin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        table td{
            vertical-align: middle !important;
        }
    </style>

    <section class="content-header">
        <h1>Quản trị người dùng</h1>
        <input id="UserId" type="text" value="<% Response.Write(HttpContext.Current.Session["User_Id"]); %>" hidden />
    </section>

    <!-- Main content -->
    <section class="content container-fluid">
        <!-- Modal -->
        <div class="modal fade bd-example-modal-lg" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h2 class="modal-title" id="exampleModalLabel" style="display: inline-block">Thêm mới người dùng</h2>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close" style="display: inline-block; color: crimson; font-size: 50px">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="roles">Phân quyền người dùng<span class="required" style="color: red">(*)</span>:</label>
                            <asp:DropDownList ID="ListRoles" runat="server" Height="25px" Width="200px" name="category">
                                <asp:ListItem Text="-- Chọn quyền --" Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="name">Tên tài khoản<span class="required" style="color: red">(*)</span>:</label>
                            <input type="text" class="form-control" id="username" name="username" placeholder="Tên tài khoản" />
                        </div>
                        <div class="form-group">
                            <label for="name">Tên người dùng<span class="required" style="color: red">(*)</span>:</label>
                            <input type="text" class="form-control" id="fullname" name="username" placeholder="Họ và tên" />
                        </div>
                        <div class="form-group">
                            <label for="name">Tên viết tắt / Bút danh<span class="required" style="color: red">(*)</span>:</label>
                            <input type="text" class="form-control" id="shortname" name="username" placeholder="Tên viết tắt / Bút danh" />
                        </div>
                        <div class="form-group">
                            <label for="name">SDT<span class="required" style="color: red">(*)</span>:</label>
                            <input type="text" class="form-control" id="phone" name="username" placeholder="Số điện thoại" />
                        </div>
                        <div class="form-group">
                            <label for="location">Mật khẩu<span class="required" style="color: red">(*)</span>:</label>
                            <input type="text" class="form-control" id="password" name="password" placeholder="Mật khẩu" />
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" id="BtnReset" class="btn btn-danger">Hủy</button>
                        <%--<asp:Button runat="server" OnClick="SaveBtn_click"/>--%>
                        <button type="button" onclick="" id="BtnSave" class="btn btn-primary">Lưu</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade bd-example-modal-lg" id="exampleModal2" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h2 class="modal-title" id="exampleModalLabel2" style="display: inline-block">Cập nhật người dùng</h2>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close" style="display: inline-block; color: crimson; font-size: 50px">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="roles">Phân quyền người dùng<span class="required" style="color: red">(*)</span>:</label>
                            <asp:DropDownList ID="ListRoles2" runat="server" Height="25px" Width="200px" name="category">
                                <asp:ListItem Text="-- Chọn quyền --" Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="name">Tên tài khoản<span class="required" style="color: red">(*)</span>:</label>
                            <input type="text" class="form-control" id="username2" name="username" placeholder="Tên tài khoản" disabled="disabled"/>
                        </div>
                        <div class="form-group">
                            <label for="name">Tên người dùng<span class="required" style="color: red">(*)</span>:</label>
                            <input type="text" class="form-control" id="fullname2" name="username" placeholder="Họ và tên" disabled="disabled"/>
                        </div>
                        <div class="form-group">
                            <label for="name">Tên viết tắt / Bút danh<span class="required" style="color: red">(*)</span>:</label>
                            <input type="text" class="form-control" id="shortname2" name="username" placeholder="Tên viết tắt / Bút danh" disabled="disabled"/>
                        </div>
                        <div class="form-group">
                            <label for="name">SDT<span class="required" style="color: red">(*)</span>:</label>
                            <input type="text" class="form-control" id="phone2" name="username" placeholder="Số điện thoại" disabled="disabled"/>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" id="BtnReset2" class="btn btn-danger">Hủy</button>
                        <%--<asp:Button runat="server" OnClick="SaveBtn_click"/>--%>
                        <button type="button" onclick="" id="BtnSave2" class="btn btn-primary">Lưu</button>
                    </div>
                </div>
            </div>
        </div>
        <div style="margin-top: 30px;">
            <div class="row" style="margin: 0">
                <input type="text" id="FilterText" class="input" placeholder="Tìm kiếm" style="padding-left: 10px; width: 320px" />
                <asp:DropDownList ID="ListRolesOutter" runat="server" Height="33px" Width="200px" name="role">
                    <asp:ListItem Text="-- Chọn phân quyền --" Value=""></asp:ListItem>
                </asp:DropDownList>
                <button type="button" class="btn btn-primary pull-right" data-toggle="modal" data-target="#exampleModal">
                    <i class="fa fa-plus"></i>&ensp;Thêm mới người dùng
                </button>
            </div>
            <table class="table table-striped table-hover " style="margin-top: 30px;">
                <thead style="background-color: deepskyblue">
                    <tr>
                        <th scope="col" class="text-center">
                            <input type="checkbox" class="multiSelect" /></th>
                        <th scope="col" class="text-center" width="20%">Tên người dùng</th>
                        <th scope="col" class="text-center">Tên đầy đủ</th>
                        <th scope="col" class="text-center">Email</th>
                        <th scope="col" class="text-center">SDT</th>
                        <th scope="col" class="text-center">Bút danh</th>
                        <th scope="col" class="text-center">Phân quyền</th>
                        <th scope="col" class="text-center">Thao tác</th>
                    </tr>
                </thead>
                <tbody id="table-body">
                </tbody>
            </table>
            <div class="row">
                <div class="col-md-12">
                    <div class="pull-right">
                        <div id="pagination" class="text-center">
                            <%--<span>Trang &ensp;<input id="PageNumber" class="text-center" style="width: 50px" type="number" min="1" value="1" /></span>--%>
                            <button type="button" id="PreviousPage" style="display: inline-block">&lt;</button>
                            <div id="Pages" style="display: inline-block">
                            </div>
                            <button type="button" id="NextPage" style="display: inline-block">&gt;</button>
                        </div>
                        <br />
                        Đến trang
                <input id="PageNumber" style="width: 50px; text-align: center;" value="1" type="number" min="1" />
                        trên tổng số <span id="TotalPage"></span>
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="myModal1" role="dialog">
            <div class="modal-dialog modal-sm">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Xác nhận mở khóa người dùng</h4>
                    </div>
                    <div class="modal-body">
                        <p>Bạn có chắc muốn mở khóa người dùng này?</p>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Hủy</button>
                        <button type="button" class="btn btn-success" onclick="ToggleLock()" data-dismiss="modal">Mở khóa</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="myModal2" role="dialog">
            <div class="modal-dialog modal-sm">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Xác nhận khóa người dùng</h4>
                    </div>
                    <div class="modal-body">
                        <p>Bạn có chắc muốn khóa người dùng này?</p>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Hủy</button>
                        <button type="button" class="btn btn-danger" onclick="ToggleLock()" data-dismiss="modal">Khóa</button>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <script src="admin.js"></script>
</asp:Content>
