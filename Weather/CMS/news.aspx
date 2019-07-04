<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="CMS.Master" CodeBehind="news.aspx.cs" Inherits="Weather.CMS.NewsForm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .required {
            color: red;
        }

        td {
            vertical-align: middle !important;
        }
    </style>
    <section class="content-header">
        <h1>Quản lý tin bài cá nhân</h1>
        <input id="UserId" type="text" value="<% Response.Write(HttpContext.Current.Session["User_Id"]); %>" hidden />
    </section>

    <!-- Main content -->
    <section class="content container-fluid">

        <!-- Modal -->
        <div class="modal fade bd-example-modal-lg" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h2 class="modal-title" id="exampleModalLabel" style="display: inline-block">Thêm mới tin bài</h2>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close" style="display: inline-block; color: crimson; font-size: 50px">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="category">Loại tin bài<span class="required">(*)</span>:</label>
                            <asp:DropDownList ID="ListCategory" runat="server" Height="25px" Width="200px" name="category">
                                <asp:ListItem Text="-- Chọn loại tin --" Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="name">Tên tin bài<span class="required">(*)</span>:</label>
                            <input type="text" class="form-control" id="name" name="name" placeholder="Tên tin bài" />
                        </div>
                        <div class="form-group">
                            <label for="location">Địa điểm:</label>
                            <input type="text" class="form-control" id="location" name="location" placeholder="Nơi viết" />
                        </div>
                        <div class="form-group">
                            <label for="introduction">Trích tin hiển thị<span class="required">(*)</span>:</label>
                            <textarea class="form-control" id="introduction" name="introduction" placeholder="Trích tin hiển thị..."></textarea>
                        </div>
                        <div class="form-group">
                            <label for="body">Nội dung<span class="required">(*)</span>:</label>
                            <textarea name="body" id="body" rows="10" cols="80">
                                
                            </textarea>
                            <script>
                            // Replace the <textarea id="editor1"> with a CKEditor
                            // instance, using default configuration.
                            CKEDITOR.replace('body');
                            </script>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" id="BtnReset" class="btn btn-danger">Hủy</button>
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Tạm đóng</button>
                        <%--<asp:Button runat="server" OnClick="SaveBtn_click"/>--%>
                        <button type="button" onclick="" id="BtnSave" class="btn btn-secondary">Lưu</button>
                        <button type="button" class="btn btn-primary">Chờ duyệt</button>
                    </div>
                </div>
            </div>
        </div>
        <div style="margin-top: 30px;">
            <div class="row" style="margin: 0">
                <input id="daterangepicker" type="text" class="text-center" name="datefilter" value="" style="padding: 0px 10px" placeholder="Chọn khoảng ngày" />

                <asp:DropDownList ID="OuterListCategory" runat="server" Height="25px" Width="200px">
                    <asp:ListItem Text="-- Chọn loại tin --" Value=""></asp:ListItem>
                </asp:DropDownList>
                <input type="text" id="FilterText" class="input" placeholder="Tìm kiếm" style="padding-left: 10px" />
                <button type="button" class="btn btn-primary pull-right" data-toggle="modal" data-target="#exampleModal">
                    <i class="fa fa-plus"></i>&ensp;Thêm mới tin bài
                </button>
            </div>
            <table class="table table-striped table-hover " style="margin-top: 30px;">
                <thead style="background-color: deepskyblue">
                    <tr>
                        <th scope="col" class="text-center">
                            <input type="checkbox" class="multiSelect" /></th>
                        <th scope="col" class="text-center" width="20%">Tên tin bài</th>
                        <th scope="col" class="text-center">Loại tin</th>
                        <th scope="col" class="text-center">Nơi viết</th>
                        <th scope="col" class="text-center">Ngày tạo</th>
                        <th scope="col" class="text-center">Người viết</th>
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

        <script src="news.js"></script>
    </section>
</asp:Content>
