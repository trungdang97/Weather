<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="tin-tuc.aspx.cs" Inherits="Weather.tin_tuc" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        
    </style>
    <input id="newsid" value="<% Response.Write(HttpContext.Current.Session["NewsId"]); %>" hidden />
    <input id="newsCategory" value="<% Response.Write(HttpContext.Current.Session["NewsCategory"]); %>" hidden />
    <div class="container">
        <div id="News">
            <span style="display: block"><small id="CreatedOnDate" style="font-weight: bold"></small></span>
            <div class="row">
                <h3 id="Name" style="font-weight: bold"></h3>
            </div>
            <div class="row" id="Introduction">
            </div>
            <div class="row" id="Body">
            </div>
            <div class="row">
                <div class="pull-right" style="padding-right: 50px;" id="Credit">
                </div>
            </div>
        </div>
        <div id="ListNews">
            <div id="InnerList" class="col-md-7"></div>
            <div class="col-md-1"></div>
            <div class="col-md-4"></div>
            <br />
            <div class="col-md-7">
                <div class="pull-right">
                    <div id="pagination">
                        <span>Trang &ensp;<input id="PageNumber" class="text-center" style="width: 50px" type="number" min="1" value="1" /><%--&ensp;trên tổng số <span id="TotalPage"></span>--%></span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="/tin-tuc.js"></script>
</asp:Content>
