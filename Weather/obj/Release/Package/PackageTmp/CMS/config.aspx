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
            <li><a data-toggle="tab" href="#loai-api">Loại API</a></li>
            <%--<li><a data-toggle="tab" href="#menu2">Menu 2</a></li>--%>
        </ul>
        <div class="tab-content">
            <div id="the-loai-tin" class="tab-pane fade in active">
                <h3>Thể loại tin</h3>
                <div class="container-fluid" id="the-loai-tin-container"></div>
            </div>
            <div id="loai-api" class="tab-pane fade">
                <h3>Loại API</h3>
                <div class="container-fluid" id="loai-api-container"></div>
            </div>
            <%--<div id="menu2" class="tab-pane fade">
                <h3>Menu 2</h3>
                <p>Some content in menu 2.</p>
            </div>--%>
        </div>
    </section>

    <script src="config.js"></script>
</asp:Content>
