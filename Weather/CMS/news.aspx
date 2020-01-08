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
                            <label for="category">Thời gian viết:</label>
                            <input type="text" class="form-control" id="singledatetimepicker" />
                        </div>
                        <div class="form-group">
                            <label for="thumbnail">Sử dụng hình ảnh đại diện tin bài:&ensp;</label><input type="checkbox" id="checkImg" />
                            <input type="file" id="imgFile" style="border: 1px solid black" />
                            <img id="previewImgFile" style="display: none" width="100px" />
                        </div>
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
                                //CKEDITOR.replace('body');
                            </script>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" id="BtnReset" class="btn btn-danger">Hủy</button>
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Tạm đóng</button>
                        <%--<asp:Button runat="server" OnClick="SaveBtn_click"/>--%>
                        <button type="button" onclick="" id="BtnSave" class="btn btn-primary">Lưu</button>
                        <%--<button type="button" class="btn btn-primary">Chờ duyệt</button>--%>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade bd-example-modal-lg" id="exampleModal2" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h2 class="modal-title" id="exampleModalLabel2" style="display: inline-block">Sửa tin bài</h2>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close" style="display: inline-block; color: crimson; font-size: 50px">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="category">Thời gian viết:</label>
                            <input type="text" class="form-control" id="singledatetimepicker2" />
                        </div>
                        <div class="form-group">
                            <label for="thumbnail">Sử dụng hình ảnh đại diện tin bài:&ensp;</label><input type="checkbox" id="checkImg2" />
                            <input type="file" id="imgFile2" style="border: 1px solid black" />
                            <img id="previewImgFile2" style="display: none; margin-top: 10px" width="300px" />
                        </div>
                        <div class="form-group">
                            <label for="category">Loại tin bài<span class="required">(*)</span>:</label>
                            <asp:DropDownList ID="ListCategory2" runat="server" Height="25px" Width="200px" name="category">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="name">Tên tin bài<span class="required">(*)</span>:</label>
                            <input type="text" class="form-control" id="name2" name="name" placeholder="Tên tin bài" />
                        </div>
                        <div class="form-group">
                            <label for="location">Địa điểm:</label>
                            <input type="text" class="form-control" id="location2" name="location" placeholder="Nơi viết" />
                        </div>
                        <div class="form-group">
                            <label for="introduction">Trích tin hiển thị<span class="required">(*)</span>:</label>
                            <textarea class="form-control" id="introduction2" name="introduction" placeholder="Trích tin hiển thị..."></textarea>
                        </div>
                        <div class="form-group">
                            <label for="body">Nội dung<span class="required">(*)</span>:</label>
                            <textarea name="body" id="body2" rows="10" cols="80">
                                
                            </textarea>
                            <script>
                                // Replace the <textarea id="editor1"> with a CKEditor
                                // instance, using default configuration.
                                //CKEDITOR.replace('body2');
                            </script>
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
                <input id="daterangepicker" type="text" class="text-center" name="datefilter" value="" style="padding: 0px 10px" placeholder="Chọn khoảng ngày" />

                <asp:DropDownList ID="OuterListCategory" runat="server" Height="31px" Width="200px">
                    <asp:ListItem Text="-- Chọn loại tin --" Value=""></asp:ListItem>
                </asp:DropDownList>
                <input type="text" id="FilterText" class="input" placeholder="Tìm kiếm" style="padding-left: 10px; height: 31px" />
                <button type="button" class="btn btn-primary pull-right" data-toggle="modal" data-target="#exampleModal">
                    <i class="fa fa-plus"></i>&ensp;Thêm mới tin bài
                </button>
            </div>
            <table class="table table-striped table-hover " style="margin-top: 30px;">
                <thead style="background-color: deepskyblue">
                    <tr>
                        <th scope="col" class="text-center">
                            <%--<input type="checkbox" class="multiSelect" />--%></th>
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
    <script>
        $('#singledatetimepicker').daterangepicker({
            "singleDatePicker": true,
            "timePicker": true,
            "locale": {
                "direction": "ltr",
                "format": "DD/MM/YYYY HH:mm",
                "separator": " - ",
                "applyLabel": "Áp dụng",
                "cancelLabel": "Hủy",
                "customRangeLabel": "Custom",
                "daysOfWeek": [
                    "CN",
                    "T2",
                    "T3",
                    "T4",
                    "T5",
                    "T6",
                    "T7"
                ],
                "monthNames": [
                    "Tháng 1",
                    "Tháng 2",
                    "Tháng 3",
                    "Tháng 4",
                    "Tháng 5",
                    "Tháng 6",
                    "Tháng 7",
                    "Tháng 8",
                    "Tháng 9",
                    "Tháng 10",
                    "Tháng 11",
                    "Tháng 12"
                ],
                "firstDay": 1
            },
            "startDate": new Date(),
        }, function (start, end, label) {

        });
        $('#singledatetimepicker2').daterangepicker({
            "singleDatePicker": true,
            "timePicker": true,
            "locale": {
                "direction": "ltr",
                "format": "DD/MM/YYYY HH:mm",
                "separator": " - ",
                "applyLabel": "Áp dụng",
                "cancelLabel": "Hủy",
                "customRangeLabel": "Custom",
                "daysOfWeek": [
                    "CN",
                    "T2",
                    "T3",
                    "T4",
                    "T5",
                    "T6",
                    "T7"
                ],
                "monthNames": [
                    "Tháng 1",
                    "Tháng 2",
                    "Tháng 3",
                    "Tháng 4",
                    "Tháng 5",
                    "Tháng 6",
                    "Tháng 7",
                    "Tháng 8",
                    "Tháng 9",
                    "Tháng 10",
                    "Tháng 11",
                    "Tháng 12"
                ],
                "firstDay": 1
            },
            "startDate": new Date(),
        }, function (start, end, label) {

        });
    </script>
</asp:Content>
