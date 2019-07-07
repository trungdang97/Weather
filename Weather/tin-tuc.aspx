<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="tin-tuc.aspx.cs" Inherits="Weather.tin_tuc" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        
    </style>
    <input id="newsid" value="<% Response.Write(HttpContext.Current.Session["newsid"]); %>"" hidden/>
    <div class="container">
        <span style="display:block"><small id="CreatedOnDate" style="font-weight:bold"></small></span>
        <div class="row">
            <h3 id="Name" style="font-weight:bold"></h3>
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
    <script src="tin-tuc.js"></script>
</asp:Content>
