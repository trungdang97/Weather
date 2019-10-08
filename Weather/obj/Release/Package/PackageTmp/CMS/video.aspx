<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CMS/CMS.Master" CodeBehind="video.aspx.cs" Inherits="Weather.CMS.video" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        td {
            vertical-align: middle !important;
        }

        table td,th{
            border:1px solid grey;
        }
    </style>
    <section class="content-header">
        <h1>Quản lý video</h1>
        <input id="UserId" type="text" value="<% Response.Write(HttpContext.Current.Session["User_Id"]); %>" hidden />
    </section>

    <!-- Main content -->
    <section class="content container-fluid">
        <div style="margin-top: 30px;">
            <%--<div class="row" style="margin: 0">
                <input type="text" id="FilterText"placeholder="Tìm kiếm" style="padding-left: 10px;width: 300px" />
            </div>--%>
            <table class="table table-striped table-hover " style="margin-top: 30px;">
                <thead style="background-color: deepskyblue">
                    <tr>                        
                        <th scope="col" class="text-center" width="20%">Tên video</th>
                        <th scope="col" class="text-center">Ngày tạo</th>
                        <th scope="col" class="text-center">Đường dẫn vật lý</th>
                        <%--<th scope="col" class="text-center">Thao tác</th>--%>
                    </tr>
                </thead>
                <tbody id="table-body">
                </tbody>
            </table>
        </div>
    </section>
    <script src="video.js">
    </script>
</asp:Content>
