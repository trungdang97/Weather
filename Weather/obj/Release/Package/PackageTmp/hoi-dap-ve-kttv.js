CKEDITOR.replace('Body');

var PostId = "";
var Post = {};
$(document).ready(function () {
    PostId = $("#PostId").val();
    ToggleVisible();
});


$("#BtnSave").click(function () {
    CheckInfo();
});
$("#BtnComment").click(function () {
    CreateComment();
});


var ToggleVisible = function () {
    if (PostId == null || PostId == undefined || PostId == "") {
        //cho list
        $("#MainList").show();
        $("#Post").hide();
        GetPost();
    }
    else {
        // cho single
        $("#MainList").hide();
        $("#Post").show();
        GetPostById();
    }
}

var CheckInfo = function () {
    var postData = {};
    postData.Title = $("#Title").val();
    postData.Body = CKEDITOR.instances['Body'].getData();
    postData.UserId = $("#UserId").val();

    if (postData.Title == null || postData.Title == undefined || postData.Title == "") {
        alert("Bạn không được để trống các trường bắt buộc!");
        return;
    }
    if (postData.Body == null || postData.Body == undefined || postData.Body == "") {
        alert("Bạn không được để trống các trường bắt buộc!");
        return;
    }

    CreatePost(postData);
};

var CreatePost = function (postData) {
    $.ajax({
        url: "/api/v1/post/create",
        method: "POST",
        dataType: "json",
        data: postData,
        success: function (response) {
            alert("Tạo câu hỏi thành công");
            $("#Title").val("");
            $("#UserId").val("");
            $("#QuestionModalItem").modal('hide');
            GetPost();
        },
        error: function (response) {
            alert("Xảy ra lỗi khi tạo câu hỏi!");
        }
    });
};

var GetPost = function () {
    var filter = {};
    filter.FilterText = "";
    filter.PageSize = 10;
    filter.PageNumber = 1;

    $.ajax({
        url: "/api/v1/post/filter?Filter=" + JSON.stringify(filter),
        method: "GET",
        dataType: "json",
        success: function (response) {
            //console.log(response);
            $("#InnerList").html("");
            for (var i = 0; i < response.length; i++) {
                $("#InnerList").append("<div class='col-md-12' style='border-top: 1px solid lightgrey;border-bottom: 1px solid lightgrey;padding: 10px 0px'>"
                    + "<div class='col-md-12'><a href='/hoi-dap-ve-kttv?cauhoi=" + response[i].PostId + "'>" + response[i].Title + "</a></div>"
                    + "<div class='col-md-12'><div class='pull-right'>Bởi <b>" + response[i].User.ShortName + "</b> lúc <b>" + FormatDateTime(response[i].CreatedOnDate) + "</b></div></div>"
                    + "</div>");
            }
        },
        error: function (response) {
            alert("Xảy ra lỗi khi lấy câu hỏi!");
        }
    });
}

var GetPostById = function () {
    $.ajax({
        url: "/api/v1/post?PostId=" + $("#PostId").val(),
        method: "GET",
        dataType: "json",
        success: function (response) {
            console.log(response);
            Post = response;
            //for (var i = 0; i < response.length; i++) {
            //    $("#InnerList").append("<div class='col-md-12' style='border-top: 1px solid lightgrey;border-bottom: 1px solid lightgrey;padding: 10px 0px'>"
            //        + "<div class='col-md-12'><a href='/hoi-dap-ve-kttv?cauhoi=" + response[i].PostId + "'>" + response[i].Title + "</a></div>"
            //        + "<div class='col-md-12'><div class='pull-right'>Bởi <b>" + response[i].User.ShortName + "</b> lúc <b>" + FormatDateTime(response[i].CreatedOnDate) + "</b></div></div>"
            //        + "</div>");
            //}
            $("#PostTitle").html(response.Title);
            $("#PostBody").html(response.Body);
            $("#PostCredit").html("<b>" + response.User.ShortName + " (" + FormatDateTime(response.CreatedOnDate) + ")</b>");
        },
        error: function (response) {
            alert("Xảy ra lỗi khi lấy câu hỏi!");
        }
    });
    GetComment();
};

var CreateComment = function () {
    var postData = {};
    postData.ThreadId = PostId;
    postData.Type = "POST";
    postData.Title = "Re: " + Post.Title;
    postData.Body = $("#CommentBody").val();
    postData.UserId = $("#UserId").val();
    postData.UserName = " ";
    postData.Email = " ";

    $.ajax({
        url: "/api/v1/comment/create",
        method: "POST",
        dataType: "json",
        data: postData,
        success: function (response) {
            //console.log("COMMENTS", response);
            $("#CommentBody").val("");
            GetComment();
        },
        error: function (response) {
            alert("Xảy ra lỗi khi gửi bình luận!");
        }
    });
};

var GetComment = function () {
    $.ajax({
        url: "/api/v1/comment/post?PostId=" + $("#PostId").val(),
        method: "GET",
        dataType: "json",
        success: function (response) {
            $("#PostComment").html("");
            //console.log("COMMENTS",response);
            for (var i = 0; i < response.length; i++) {
                $("#PostComment").append("<div class='col-md-12' style='padding-top: 10px;padding-left: 10px;padding-right: 10px;border-top: 1px solid lightgrey'>"
                    + "<b>" + response[i].UserName + "</b> đã viết <b>(" + FormatDateTime(response[i].CreatedOnDate) + ")</b>:"
                    + "<br/>"
                    + "<p style='padding: 5px 20px;'>"+ response[i].Body +"</p>"
                    + "</div>");
            }
        },
        error: function (response) {
            alert("Xảy ra lỗi khi lấy trả lời và bình luận!");
        }
    });
}