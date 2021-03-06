﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Weather._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/Default/default.css" rel="stylesheet" />
    <style>
        /*p {
            text-overflow: ellipsis;
            display: block;
            width: 100%;
            overflow: hidden;
            white-space: nowrap;
            padding-right: 15px;
        }*/

        /*.card-body {
            display: -webkit-box;
            overflow: hidden;
            text-overflow: ellipsis;
            -webkit-line-clamp: 3;
            -webkit-box-orient: vertical;
        }*/
        .card-deck {
            display: grid;
            grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
            grid-gap: .5rem;
        }
    </style>
    <div class="row" style="padding: 20px 15px">
        <%--<div class="col-md-8" style="border: 1px solid lightgrey; padding: 0px; border-radius: 2px; width: 74%">--%>
        <iframe class="col-md-7" style="border: 1px solid lightgrey; padding: 0px; border-radius: 2px; width: 66%; height: 520px" src="index.html">
            <p>Your browser does not support iframes.</p>
        </iframe>
        <%--</div>--%>
        <div id="citiesWeather" class="col-md-4 pull-right" style="border: 1px solid lightgrey; box-shadow: 2px 2px; padding: 0; border-radius: 2px">
            <div class="row">
                <div class="text-uppercase" style="font-weight: bold; color: dodgerblue; font-size: 20px; display: block; padding: 5px 20px;">Cảnh báo thiên tai</div>
                <div style="font-weight: bold; font-size: 20px; display: block; background-color: #ebe9e1; padding: 5px 10px;">
                    <table>
                        <tr>
                            <td style="padding-right: 5px;">
                                <img src="/Content/Images/Icon/Icon/tornado.png" width="50px" />
                                <%--<img src="Content/Images/Icon/Icon/clound.png" width="50px" />--%>
                            </td>
                            <td>
                                <span class="text-uppercase" style="font-size: 14px">Tin bão trên biển đông</span>
                                <br />
                                <span style="font-size: 14px">(Cơn bão số 7)</span>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="row">
                <div class="text-uppercase" style="font-weight: bold; color: dodgerblue; font-size: 20px; display: block; padding: 5px 20px;">
                    Thời tiết hiện tại
                </div>
                <div style="font-weight: bold; font-size: 20px; display: block; background-color: #ebe9e1; padding: 5px 10px;">
                    <table style="width: 100%">
                        <tbody id="ForecastContent">
                            <tr>
                                <td style="height: 336px">
                                </td>
                            </tr>
                            <%--<tr>
                                <td style="padding-right: 5px;">
                                    <img src="https://cdn4.iconfinder.com/data/icons/iconsland-weather/PNG/256x256/Sunny.png" width="50px" />
                                </td>
                                <td>
                                    <span class="text-uppercase" style="font-size: 14px">Hà Nội</span>
                                    <span class="pull-right" style="color: #dec402; font-size: 14px; padding-top: 5px">30-32&#176;C</span>
                                    <br />
                                    <span style="font-size: 12px; color: grey">Nắng mạnh</span>
                                </td>
                            </tr>--%>
                        </tbody>
                        <tbody>
                            <tr>
                                <td>
                                    <a id="PreviousForecast" href="#"><i class="fa fa-arrow-left"></i></a>
                                </td>
                                <td class="text-center" style="padding-right:30px;">
                                    <b style="font-size: 14px;" id="ForecastPageNumber"></b>
                                    <b style="font-size: 14px;">/</b>
                                    <b style="font-size: 14px;" id="ForecastTotalPage"></b>
                                </td>
                                <td class="pull-right">
                                    <a id="NextForecast" href="#"><i class="fa fa-arrow-right"></i></a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <%-- Pagination --%>
                </div>
            </div>
        </div>
    </div>

    <div class="row" style="padding-top: 50px; align-items: center;">
        <div class="col-md-12" style="padding: 0">
            <div class="tabbable-panel">
                <div class="tabbable-line">
                    <ul class="nav nav-tabs" style="font-weight: bold">
                        <li>
                            <a href="#tab_default_1" data-toggle="tab">Tin nội bộ </a>
                        </li>
                        <li class="active">
                            <a href="#tab_default_2" data-toggle="tab">Tin thời tiết </a>
                        </li>
                        <li>
                            <a href="#tab_default_3" data-toggle="tab">Tin Xã hội </a>
                        </li>
                    </ul>
                    <div class="tab-content" style="">
                        <div class="tab-pane" id="tab_default_1">
                        </div>
                        <div class="tab-pane active" id="tab_default_2">
                        </div>
                        <div class="tab-pane" id="tab_default_3">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        
    </script>
    <script src="Default.js"></script>
</asp:Content>
