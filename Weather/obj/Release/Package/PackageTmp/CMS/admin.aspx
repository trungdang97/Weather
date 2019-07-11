<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="CMS.Master" CodeBehind="admin.aspx.cs" Inherits="Weather.CMS.admin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
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
                            <label for="roles">Phân quyền người dùng<span class="required" style="color:red">(*)</span>:</label>
                            <asp:DropDownList ID="ListRoles" runat="server" Height="25px" Width="200px" name="category">
                                <asp:ListItem Text="-- Chọn quyền --" Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="name">Tên tài khoản<span class="required" style="color:red">(*)</span>:</label>
                            <input type="text" class="form-control" id="username" name="username" placeholder="Tên tài khoản" />
                        </div>
                        <div class="form-group">
                            <label for="name">Tên người dùng<span class="required" style="color:red">(*)</span>:</label>
                            <input type="text" class="form-control" id="fullname" name="username" placeholder="Họ và tên" />
                        </div>
                        <div class="form-group">
                            <label for="name">Tên viết tắt / Bút danh<span class="required" style="color:red">(*)</span>:</label>
                            <input type="text" class="form-control" id="shortname" name="username" placeholder="Tên viết tắt / Bút danh" />
                        </div>
                        <div class="form-group">
                            <label for="location">Mật khẩu<span class="required" style="color:red">(*)</span>:</label>
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
        <div style="margin-top: 30px;">
            <div class="row" style="margin: 0">                
                <%--<input type="text" id="FilterText" class="input" placeholder="Tìm kiếm" style="padding-left: 10px" />--%>
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
                        <th scope="col" class="text-center">Bút danh</th>
                        <th scope="col" class="text-center">Phân quyền</th>
                        <th scope="col" class="text-center">Thao tác</th>
                    </tr>
                </thead>
                <tbody id="table-body">
                </tbody>
            </table>
        </div>

        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog modal-sm">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Xác nhận xóa tin bài</h4>
                    </div>
                    <div class="modal-body">
                        <p>Bạn có chắc muốn xóa tin bài này?</p>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Hủy</button>
                        <button type="button" class="btn btn-danger" onclick="Delete()" data-dismiss="modal">Xóa</button>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <script src="admin.js"></script>
</asp:Content>
