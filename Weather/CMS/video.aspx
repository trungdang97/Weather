<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CMS/CMS.Master" CodeBehind="video.aspx.cs" Inherits="Weather.CMS.video" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        td {
            vertical-align: middle !important;
        }

        table td, th {
            border: 1px solid grey;
        }

        .required {
            color: red;
        }
    </style>
    <section class="content-header">
        <h1>Quản lý video</h1>
        <input id="UserId" type="text" value="<% Response.Write(HttpContext.Current.Session["User_Id"]); %>" hidden />
    </section>

    <!-- Main content -->
    <section class="content container-fluid">
        <div style="margin-top: 30px;">
            <div class="row" style="margin: 0">
                <%--<input id="daterangepicker" type="text" class="text-center" name="datefilter" value="" style="padding: 0px 10px" placeholder="Chọn khoảng ngày" />--%>
                <%--<input type="text" id="FilterText" class="input" placeholder="Tìm kiếm" style="padding-left: 10px" />--%>
                <button type="button" class="btn btn-primary pull-right" data-toggle="modal" data-target="#exampleModal">
                    <i class="fa fa-plus"></i>&ensp;Thêm mới
                </button>
            </div>
            <%--<div class="row" style="margin: 0">
                <input type="text" id="FilterText"placeholder="Tìm kiếm" style="padding-left: 10px;width: 300px" />
            </div>--%>
            <table class="table table-striped table-hover " style="margin-top: 30px;">
                <thead style="background-color: deepskyblue">
                    <tr>
                        <th scope="col" class="text-center" width="20%">Tên video</th>
                        <th scope="col" class="text-center">Ngày tạo</th>
                        <th scope="col" class="text-center">Đường dẫn vật lý</th>
                        <th scope="col" class="text-center">Thao tác</th>
                    </tr>
                </thead>
                <tbody id="table-body">
                </tbody>
            </table>
        </div>
    </section>

    <!-- Modal -->
    <div class="modal fade bd-example-modal-lg" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h2 class="modal-title" id="exampleModalLabel" style="display: inline-block">Thêm mới video</h2>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close" style="display: inline-block; color: crimson; font-size: 50px">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="introduction">Tiêu đề video<span class="required">(*)</span>:</label>
                        <input type="text" class="form-control" id="Name" name="Name" placeholder="Nhập tiêu đề video..." />
                    </div>
                    <div class="form-group">
                        <label for="body">Tên file<span class="required">(*)</span>:</label>
                        <input type="text" disabled class="form-control" id="FileName" name="FileName" placeholder="Tên file video..." />
                    </div>
                    <div class="form-group">
                        <label for="body">File<span class="required">(*)</span>:</label>
                        <input type="file" class="form-control" id="File" name="File" accept="video/*" />
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" id="BtnReset" class="btn btn-danger">Hủy</button>
                    <%--<button type="button" class="btn btn-secondary" data-dismiss="modal">Tạm đóng</button>--%>
                    <button type="button" onclick="" id="BtnSave" class="btn btn-primary">Lưu</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal -->
    <div class="modal fade bd-example-modal-lg" id="exampleModal1" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h2 class="modal-title" id="exampleModalLabel1" style="display: inline-block">Sửa tiêu đề video</h2>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close" style="display: inline-block; color: crimson; font-size: 50px">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="introduction">Tiêu đề video<span class="required">(*)</span>:</label>
                        <input type="text" class="form-control" id="Name1" name="Name" placeholder="Nhập tiêu đề video..." />
                    </div>                    
                </div>
                <div class="modal-footer">
                    <button type="button" id="BtnReset1" class="btn btn-danger">Hủy</button>
                    <%--<button type="button" class="btn btn-secondary" data-dismiss="modal">Tạm đóng</button>--%>
                    <button type="button" onclick="Update()" id="BtnSave1" class="btn btn-primary">Lưu</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Xác nhận xóa video</h4>
                </div>
                <div class="modal-body">
                    <p>Bạn có chắc muốn xóa video này?</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Hủy</button>
                    <button type="button" class="btn btn-danger" onclick="Delete()" data-dismiss="modal">Xóa</button>
                </div>
            </div>
        </div>
    </div>

    <script src="video.js">
    </script>
</asp:Content>
