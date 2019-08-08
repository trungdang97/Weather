<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="hoi-dap-ve-kttv.aspx.cs" Inherits="Weather.hoi_dap" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <% if (HttpContext.Current.Session["User_Id"] != null)
        { %>
    <script src="/CMS/bower_components/ckeditor/ckeditor.js"></script>
    <input type="text" id="PostId" value="<% Response.Write(Context.Session["PostId"]); %>" hidden />
    <div class="container" style="padding-top: 10px;">
        <div class="row">
            <div id="Post" class="col-md-8">
                <span style="display: block"><small id="CreatedOnDate" style="font-weight: bold"></small></span>
                <div class="row">
                    <h3 id="PostTitle" style="font-weight: bold"></h3>
                </div>
                <div class="row" id="PostBody">
                </div>
                <div class="row">
                    <div class="pull-right" style="/*padding-right: 50px; */" id="PostCredit">
                    </div>
                </div>

                <div class="row" style="border: 1px solid black; padding: 15px 0px; margin-top: 20px;">
                    <div class="form-group">
                        <div class="col-md-12">
                            <label>Bình luận/trả lời</label>
                            <textarea id="CommentBody" class="form-control" style="min-width:100%; margin-bottom: 5px" placeholder="Viết trả lời / bình luận của bạn"></textarea>
                            <button class="pull-right btn btn-primary" type="button" id="BtnComment">Gửi</button>
                        </div>
                    </div>

                </div>
                <div id="PostComment" style="margin-top: 20px;">
                </div>
            </div>

            <div id="MainList" class="col-md-8">

                <div id="buttons">
                    <button type="button" class="btn btn-primary" id="CreateQuestion" data-toggle="modal" data-target="#QuestionModalItem"><i class="fa fa-plus"></i>&ensp;Đặt câu hỏi</button>
                </div>

                <div id="ListQuestions" style="padding-top: 20px">
                    <label>Danh sách câu hỏi</label>
                    <div id="InnerList">
                    </div>
                    <div class="col-md-1"></div>
                    <div class="col-md-4"></div>
                    <br />
                    <div class="col-md-7">
                        <div class="pull-right">
                            <div id="pagination" style="padding: 10px">
                                <span>Trang &ensp;<input id="PageNumber" class="text-center" style="width: 50px" type="number" min="1" value="1" /><%--&ensp;trên tổng số <span id="TotalPage"></span>--%></span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <%-- Panel --%>
            <div class="col-md-4">
                <div class="row">
                    <%--<div class="col-md-12" style="border: 1px solid grey; margin: 30px 0px; padding: 10px 10px; background: rgb(241, 241, 241)">
                        <b style="font-size: 17px">Chuyên mục</b><br />
                        <div id="LstCM" style="padding-top: 5px; background: rgb(241, 241, 241)">                            
                        </div>
                    </div>--%>
                    <%--<div class="col-md-12" style="border: 1px solid grey; margin: 10px 0px; padding: 10px 10px; background: rgb(241, 241, 241)">
                        <b style="font-size: 17px">Các câu hỏi gần đây</b><br />
                        <div id="LstRecentNews" style="background: rgb(241, 241, 241)">--%>
                    <%--<div style="padding: 10px 0px; ">
                            <div class="col-md-5" style="display: inline-block;height: 50px; padding-left: 0">
                                <img width="100%" src="data:image/jpeg;base64,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"/>
                            </div>
                            <div class="col-md-7 pull-right" style="display: inline-block">
                                <div><a href="#">Ngày 2/8 bão Wipha đổ bộ Quảng Ninh, Hải Phòng gió giật cấp 11</a></div>
                                <div style="padding-top: 5px;color:grey">31/07/2019</div>
                            </div>
                        </div>--%>
                    <%--</div>--%>
                </div>
            </div>
        </div>
    </div>

    <div id="QuestionModalItem" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Đặt câu hỏi</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Câu hỏi<span class="required" style="color: red">(*)</span>:</label>
                        <input id="Title" class="form-control" type="text" />
                    </div>
                    <div class="form-group">
                        <label>Nội dung/tình huống<span class="required" style="color: red">(*)</span>:</label>
                        <textarea id="Body"></textarea>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" id="BtnClose" class="btn btn-danger" data-dismiss="modal">Đóng</button>
                    <button type="button" id="BtnSave" class="btn btn-primary">Lưu</button>
                </div>
            </div>

        </div>
    </div>

    <script src="hoi-dap-ve-kttv.js"></script>
    <% } %>
    <% else
        { %>
    <div style="padding-top: 50px;">Bạn cần đăng nhập để sử dụng chức năng này</div>
    <% } %>
</asp:Content>
