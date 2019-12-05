<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="CMS.Master" CodeBehind="config.aspx.cs" Inherits="Weather.CMS.config" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
        <h1>Quản trị danh mục cấu hình</h1>
        <%--<input id="UserId" type="text" value="<% Response.Write(HttpContext.Current.Session["User_Id"]); %>" hidden />--%>
    </section>

    <!-- Main content -->
    <section class="content container-fluid">
        <ul class="nav nav-tabs">
            <li class="active"><a data-toggle="tab" href="#the-loai-tin">Thể loại tin</a></li>
            <li><a data-toggle="tab" href="#loai-api">Loại API (đang xây dựng)</a></li>
            <%--<li><a data-toggle="tab" href="#menu2">Menu 2</a></li>--%>
        </ul>
        <div class="tab-content">
            <div id="the-loai-tin" class="tab-pane fade in active">
                <div class="row">
                    <div class="col-md-6" style="margin: 0;">
                        <h3>Thể loại tin</h3>
                    </div>
                    <div class="col-md-6" style="padding-top: 20px">
                        <button type="button" id="NewsCategoryCreate" class="btn btn-primary pull-right" data-toggle="modal" data-target="#NewsCategoryModal">
                            <i class="fa fa-plus"></i>&ensp;Thêm mới
                        </button>
                    </div>
                </div>
                <div class="container-fluid" id="the-loai-tin-container">
                    <table class="table table-striped table-hover " style="margin-top: 30px;">
                        <thead style="background-color: deepskyblue">
                            <tr>
                                <th scope="col" class="text-center">
                                    <input type="checkbox" id="NewsCategorySelectAll" class="multiSelect" /></th>
                                <th scope="col" class="text-center" width="20%">Tên thể loại</th>
                                <th scope="col" class="text-center">Loại tin</th>
                                <th scope="col" class="text-center">Thứ tự hiển thị trang chủ</th>
                                <th scope="col" class="text-center">Đường dẫn</th>
                                <th scope="col" class="text-center">Thao tác</th>
                            </tr>
                        </thead>
                        <tbody id="newscatergory-table-body">
                        </tbody>
                    </table>
                    <div class="row">
                <div class="col-md-12">
                    <div class="pull-right">
                        <div id="NewsCategory_pagination" class="text-center">
                            <%--<span>Trang &ensp;<input id="PageNumber" class="text-center" style="width: 50px" type="number" min="1" value="1" /></span>--%>
                            <button type="button" id="NewsCategory_PreviousPage" style="display: inline-block">&lt;</button>
                            <div id="NewsCategory_Pages" style="display: inline-block">
                            </div>
                            <button type="button" id="NewsCategory_NextPage" style="display: inline-block">&gt;</button>
                        </div>
                        <br />
                        Đến trang
                <input id="NewsCategory_PageNumber" style="width: 50px; text-align: center;" value="1" type="number" min="1" />
                        trên tổng số <span id="NewsCategory_TotalPage"></span>
                    </div>
                </div>
            </div>
                </div>
            </div>
            <div id="loai-api" class="tab-pane fade hidden">
                <div class="row">
                    <div class="col-md-6" style="margin: 0;">
                        <h3>Loại API</h3>
                    </div>
                    <div class="col-md-6" style="padding-top: 20px">
                        <button type="button" class="btn btn-primary pull-right" data-toggle="modal" data-target="#APITypeModal">
                            <i class="fa fa-plus"></i>&ensp;Thêm mới
                        </button>
                    </div>
                </div>
                <div class="container-fluid" id="loai-api-container">
                    <table class="table table-striped table-hover " style="margin-top: 30px;">
                        <thead style="background-color: deepskyblue">
                            <tr>
                                <th scope="col" class="text-center">
                                    <input type="checkbox" class="multiSelect" /></th>
                                <th scope="col" class="text-center" width="20%">Tên loại API</th>
                                <th scope="col" class="text-center">Thứ tự</th>
                                <th scope="col" class="text-center">Thao tác</th>
                            </tr>
                        </thead>
                        <tbody id="apicatergory-table-body">
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
            </div>
            <%--<div id="menu2" class="tab-pane fade">
                <h3>Menu 2</h3>
                <p>Some content in menu 2.</p>
            </div>--%>
        </div>
    </section>

    <%-- NewsCategory modal --%>
    <div class="modal fade bd-example-modal-lg" id="NewsCategoryModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h2 class="modal-title" id="exampleModalLabel" style="display: inline-block">Thêm loại tin</h2>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close" style="display: inline-block; color: crimson; font-size: 50px">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="category">Tên loại tin<span class="required">(*)</span>:</label>
                        <input type="text" class="form-control" id="NewsCategory_Name" placeholder="Tên loại tin"/>
                    </div>
                    <div class="form-group">
                        <label for="category">Loại tin<span class="required">(*)</span>:</label>
                        <select id="NewsCategory_Type">
                            <option value="TT">Tin tức</option>
                            <option value="CM">Chuyên mục</option>
                        </select>
                    </div>
                    <div class="form-group" id="NewsCategory_Order_Group">
                        <label for="name">Thứ tự:</label>
                        <input type="number" class="form-control" id="NewsCategory_Order" min="0" name="name" value="" />
                    </div>
                    <div class="form-group">
                        <label for="category">Đường dẫn<span class="required">(*)</span>:</label>
                        <input type="text" class="form-control" id="NewsCategory_Description" placeholder="Đường dẫn"/>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" id="NewsCategory_BtnReset" class="btn btn-danger">Hủy</button>
                    <button type="button" onclick="" id="NewsCategory_BtnSave" class="btn btn-primary">Lưu</button>
                </div>
            </div>
        </div>
    </div>

    <%-- APIType modal --%>
    <div class="modal fade bd-example-modal-lg" id="APITypeModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h2 class="modal-title" id="exampleModalLabel2" style="display: inline-block">Thêm loại tin</h2>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close" style="display: inline-block; color: crimson; font-size: 50px">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="category">Tên loại tin<span class="required">(*)</span>:</label>
                        <input type="text" class="form-control" id="APIType_Name" />
                    </div>
                    <%--<div class="form-group">
                        <label for="category">Loại tin<span class="required">(*)</span>:</label>
                        <select id="NewsType_Description">
                            <option value="TT">Thời tiết</option>
                            <option value="CM">Chuyên mục</option>
                        </select>
                    </div>--%>
                    <div class="form-group">
                        <label for="name">Thứ tự:</label>
                        <input type="text" class="form-control" id="APIType_Order" name="name" placeholder="Thứ tự hiển thị" />
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" id="APIType_BtnReset" class="btn btn-danger">Hủy</button>
                    <button type="button" onclick="" id="APIType_BtnSave" class="btn btn-primary">Lưu</button>
                </div>
            </div>
        </div>
    </div>

    <script src="config.js"></script>
</asp:Content>
