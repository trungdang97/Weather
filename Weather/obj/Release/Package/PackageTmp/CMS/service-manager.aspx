<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="CMS.Master" CodeBehind="service-manager.aspx.cs" Inherits="Weather.CMS.service_manager" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        table td {
            vertical-align: middle !important;
        }
    </style>

    <section class="content-header">
        <h1>Quản lý dịch vụ / đăng ký dịch vụ</h1>
        <input id="UserId" type="text" value="<% Response.Write(HttpContext.Current.Session["User_Id"]); %>" hidden />
    </section>

    <!-- Main content -->
    <section class="content container-fluid">
        <div class="row" style="margin: 0">
            <div class="col-md-6">
            </div>
            <div class="col-md-6">
                <button id="RegisterService" type="button" class="btn btn-primary pull-right" data-toggle="modal" data-target="#exampleModal"><i class="fa fa-plus"></i>&ensp;Đăng ký dịch vụ</button>
                <%--<button id="RegisterService" type="button" class="btn btn-primary pull-right"><i class="fa fa-plus"></i>&ensp;Đăng ký dịch vụ</button>--%>
            </div>
        </div>


        <div class="row" style="margin: 0">
            <h4>Danh sách các dịch vụ đang sử dụng</h4>
            <table class="table table-striped table-hover " style="margin-top: 30px;">
                <thead style="background-color: deepskyblue">
                    <tr>
                        <th class="text-center">Tên dịch vụ</th>
                        <th class="text-center">Thời hạn</th>
                        <th class="text-center">Trạng thái</th>
                        <th class="text-center">Thao tác</th>
                    </tr>
                </thead>
                <tbody id="UsingService">
                </tbody>
            </table>
        </div>

        <%-- 10 giao dịch gần nhất --%>
        <div class="row" style="margin: 0">
            <h4>Danh sách 10 giao dịch gần nhất</h4>
            <table class="table table-striped table-hover " style="margin-top: 30px;">
                <thead style="background-color: deepskyblue">
                    <tr>
                        <th class="text-center">Mã giao dịch</th>
                        <th class="text-center">Thời gian phát sinh</th>
                        <th class="text-center">Số tiền thanh toán</th>
                        <%--<th class="text-center">Thao tác</th>--%>
                    </tr>
                </thead>
                <tbody id="Transaction">
                </tbody>
            </table>
        </div>

        <%-- Modal --%>
        <div class="modal fade bd-example-modal-lg" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h2 class="modal-title" id="exampleModalLabel" style="display: inline-block">Đăng ký sử dụng dịch vụ</h2>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close" style="display: inline-block; color: crimson; font-size: 50px">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="roles">Chọn loại dịch vụ<span class="required" style="color: red">(*)</span>:</label>
                            <asp:DropDownList ID="ListAPIType" runat="server" Height="25px" Width="200px" name="category">
                                <asp:ListItem Text="-- Chọn loại dịch vụ --" Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <%-- Danh sách chưa đăng ký --%>
                        <div>
                            <table class="table table-striped table-hover " style="margin-top: 30px;">
                                <thead style="background-color: deepskyblue">
                                    <tr>
                                        <th class="text-center">
                                            <input type="checkbox" class="multiSelect" /></th>
                                        <th class="text-center">Loại dịch vụ</th>
                                        <th class="text-center">Tên dịch vụ</th>
                                        <th class="text-center">Thời hạn (tháng)</th>
                                        <th class="text-center">Giá tiền</th>
                                    </tr>
                                </thead>
                                <tbody id="ServiceList">
                                </tbody>
                            </table>
                        </div>
                        <%-- Danh sách đã chọn --%>
                        <div>
                            <table class="table table-striped table-hover " style="margin-top: 30px;">
                                <thead style="background-color: deepskyblue">
                                    <tr>
                                        <th class="text-center">
                                            <input type="checkbox" class="multiSelect" /></th>
                                        <th class="text-center">Loại dịch vụ</th>
                                        <th class="text-center">Tên dịch vụ</th>
                                        <th class="text-center">Thời hạn (tháng)</th>
                                        <th class="text-center">Giá tiền</th>
                                    </tr>
                                </thead>
                                <tbody id="SelectedServiceList">
                                </tbody>
                                <tbody>
                                    <tr style="border-top: 1px solid black">
                                        <th colspan="4" class="text-center">Tổng cộng</th>
                                        <th class="text-center"><span id="TotalPrice">0</span>&ensp;<span>VND</span></th>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" id="BtnRegisterReset" class="btn btn-danger">Hủy</button>
                        <%--<asp:Button runat="server" OnClick="SaveBtn_click"/>--%>
                        <button type="button" onclick="" id="BtnRegister" class="btn btn-primary">Đăng ký</button>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <script src="service-manager.js"></script>
</asp:Content>
