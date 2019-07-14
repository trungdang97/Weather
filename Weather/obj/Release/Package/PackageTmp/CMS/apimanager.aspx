<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="CMS.Master" CodeBehind="apimanager.aspx.cs" Inherits="Weather.CMS.apimanager" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
        <h1>Quản trị API</h1>
        <input id="UserId" type="text" value="<% Response.Write(HttpContext.Current.Session["User_Id"]); %>" hidden />
    </section>

    <!-- Main content -->
    <section class="content container-fluid">
        <!-- Modal -->
        <div class="modal fade bd-example-modal-lg" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h2 class="modal-title" id="exampleModalLabel" style="display: inline-block">Thêm mới API</h2>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close" style="display: inline-block; color: crimson; font-size: 50px">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label>Loại API<span class="required" style="color: red">(*)</span>:</label>
                            <asp:DropDownList ID="ListAPIType" runat="server" Height="25px" Width="200px">
                                <asp:ListItem Text="-- Chọn loại danh mục --" Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="name">Mã API<span class="required" style="color: red">(*)</span>:</label>
                            <input type="text" class="form-control" id="APICode" placeholder="Mã API" />
                        </div>
                        <div class="form-group">
                            <label for="name">Tên API<span class="required" style="color: red">(*)</span>:</label>
                            <input type="text" class="form-control" id="Name" placeholder="Tên API" />
                        </div>
                        <div class="form-group">
                            <label for="name">Giá tiền (VND)<span class="required" style="color: red">(*)</span>:</label>
                            <input type="number" class="form-control" id="Price" placeholder="Giá tiền (VND)" />
                        </div>
                        <div class="form-group">
                            <label for="location">Thời hạn (tháng)<span class="required" style="color: red">(*)</span>:</label>
                            <input type="number" class="form-control" id="Duration" placeholder="Thời hạn (tháng)" />
                        </div>
                        <div class="form-group">
                            <label for="location">Code cho API<span class="required" style="color: red">(*)</span>:</label>
                            <%--<input type="text" class="form-control" id="Body" placeholder="Code cho API" />--%>
                            <textarea id="Body" rows="10" cols="80">
                            </textarea>
                        </div>
                        <div class="form-group">
                            <label for="location">Hướng dẫn sử dụng<span class="required" style="color: red">(*)</span>:</label>
                            <%--<input type="text" class="form-control" id="Documentation" placeholder="Hướng dẫn sử dụng" />--%>
                            <textarea id="Documentation" rows="10" cols="80">
                            </textarea>
                        </div>
                        <div class="form-group">
                            <label for="location">Link dự phòng cho hướng dẫn sử dụng<span class="required" style="color: red">(*)</span>:</label>
                            <input type="text" class="form-control" id="DocumentationLink" placeholder="URL" />
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
                <input type="text" id="FilterText" class="input" placeholder="Tìm kiếm" style="padding-left: 10px; width: 320px" />
                <asp:DropDownList ID="ListAPITypeOutter" runat="server" Height="25px" Width="200px" name="role">
                    <asp:ListItem Text="-- Chọn loại danh mục --" Value=""></asp:ListItem>
                </asp:DropDownList>
                <button type="button" class="btn btn-primary pull-right" data-toggle="modal" data-target="#exampleModal">
                    <i class="fa fa-plus"></i>&ensp;Thêm mới API
                </button>
            </div>
            <table class="table table-striped table-hover " style="margin-top: 30px;">
                <thead style="background-color: deepskyblue">
                    <tr>
                        <th scope="col" class="text-center">
                            <input type="checkbox" class="multiSelect" /></th>
                        <th scope="col" class="text-center">Loại API</th>
                        <th scope="col" class="text-center" width="20%">Mã API</th>
                        <th scope="col" class="text-center">Tên API</th>
                        <th scope="col" class="text-center">Giá tiền (VND)</th>
                        <th scope="col" class="text-center">Thời hạn</th>
                        <th scope="col" class="text-center">Thao tác</th>
                    </tr>
                </thead>
                <tbody id="table-body">
                </tbody>
            </table>
        </div>

        <div class="modal fade" id="myModal1" role="dialog">
            <div class="modal-dialog modal-sm">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Xác nhận mở khóa API</h4>
                    </div>
                    <div class="modal-body">
                        <p>Bạn có chắc muốn mở khóa API này?</p>
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
                        <h4 class="modal-title">Xác nhận khóa API</h4>
                    </div>
                    <div class="modal-body">
                        <p>Bạn có chắc muốn khóa API này?</p>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Hủy</button>
                        <button type="button" class="btn btn-danger" onclick="ToggleLock()" data-dismiss="modal">Khóa</button>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <script src="apimanager.js"></script>
</asp:Content>
