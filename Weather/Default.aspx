<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Weather._Default" %>

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
        <iframe class="col-md-8" style="border: 1px solid lightgrey; padding: 0px; border-radius: 2px; width: 74%" src="index.html">
            <p>Your browser does not support iframes.</p>
        </iframe>
        <%--</div>--%>
        <div id="citiesWeather" class="col-md-3 pull-right" style="border: 1px solid lightgrey; box-shadow: 2px 2px; padding: 0; border-radius: 2px">
            <div class="row">
                <div class="text-uppercase" style="font-weight: bold; color: dodgerblue; font-size: 20px; display: block; padding: 5px 20px;">Cảnh báo thiên tai</div>
                <div style="font-weight: bold; font-size: 20px; display: block; background-color: #ebe9e1; padding: 5px 10px;">
                    <table>
                        <tr>
                            <td style="padding-right: 5px;">
                                <img src="http://chittagongit.com/download/52198" width="50px" />
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
                        <tr>
                            <td style="padding-right: 5px;">
                                <img src="https://cdn4.iconfinder.com/data/icons/iconsland-weather/PNG/256x256/Sunny.png" width="50px" />
                            </td>
                            <td>
                                <span class="text-uppercase" style="font-size: 14px">Hà Nội</span>
                                <span class="pull-right" style="color: #dec402; font-size: 14px; padding-top: 5px">30-32&#176;C</span>
                                <br />
                                <span style="font-size: 12px; color: grey">Nắng mạnh</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-right: 5px;">
                                <img src="https://cdn4.iconfinder.com/data/icons/iconsland-weather/PNG/256x256/Sunny.png" width="50px" />
                            </td>
                            <td>
                                <span class="text-uppercase" style="font-size: 14px">Hải Phòng</span>
                                <span class="pull-right" style="color: #dec402; font-size: 14px; padding-top: 5px">28-30&#176;C</span>
                                <br />
                                <span style="font-size: 12px; color: grey">Nắng mạnh</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-right: 5px;">
                                <img src="https://cdn4.iconfinder.com/data/icons/weather-132/100/blue_cloud-512.png" width="50px" />
                            </td>
                            <td>
                                <span class="text-uppercase" style="font-size: 14px">Nha Trang</span>
                                <span class="pull-right" style="color: #dec402; font-size: 14px; padding-top: 5px">29-30&#176;C</span>
                                <br />
                                <span style="font-size: 12px; color: grey">Nhiều mây</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-right: 5px;">
                                <img src="https://cdn4.iconfinder.com/data/icons/iconsland-weather/PNG/256x256/Sunny.png" width="50px" />
                            </td>
                            <td>
                                <span class="text-uppercase" style="font-size: 14px">Nghệ An</span>
                                <span class="pull-right" style="color: #dec402; font-size: 14px; padding-top: 5px">30-32&#176;C</span>
                                <br />
                                <span style="font-size: 12px; color: grey">Nắng mạnh</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-right: 5px;">
                                <img src="https://cdn0.iconfinder.com/data/icons/clouds-and-precipitation-filled/64/Clouds_and_Precipitation_EXP_11_Cloud_with_rain_rainy_shower_weather_forecast-512.png" width="50px" />
                            </td>
                            <td>
                                <span class="text-uppercase" style="font-size: 14px">Gia Lai</span>
                                <span class="pull-right" style="color: #dec402; font-size: 14px; padding-top: 5px">28-31&#176;C</span>
                                <br />
                                <span style="font-size: 12px; color: grey">Mưa rào và giông</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-right: 5px;">
                                <img src="https://cdn4.iconfinder.com/data/icons/iconsland-weather/PNG/256x256/Sunny.png" width="50px" />
                            </td>
                            <td>
                                <span class="text-uppercase" style="font-size: 14px">Sơn La</span>
                                <span class="pull-right" style="color: #dec402; font-size: 14px; padding-top: 5px">30-32&#176;C</span>
                                <br />
                                <span style="font-size: 12px; color: grey">Nắng mạnh</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-right: 5px;">
                                <img src="https://cdn2.iconfinder.com/data/icons/crystalproject/crystal_project_256x256/apps/kweather.png" width="50px" />
                            </td>
                            <td>
                                <span class="text-uppercase" style="font-size: 14px">TP. Hồ Chí Minh</span>
                                <span class="pull-right" style="color: #dec402; font-size: 14px; padding-top: 5px">30-32&#176;C</span>
                                <br />
                                <span style="font-size: 12px; color: grey">Trưa chiều giảm mây, trời nắng</span>
                            </td>
                        </tr>
                    </table>
                    <%-- Pagination --%>
                    <div>
                    </div>
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
                    <div class="tab-content">
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
        $("iframe").height($("#citiesWeather").height());
    </script>
    <script src="Default.js"></script>
</asp:Content>
