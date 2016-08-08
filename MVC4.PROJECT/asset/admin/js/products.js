$(document).ready(function () {

    //hiển thị form upload ảnh
    $("#dialog").dialog({
        autoOpen: false,
        show: "fade",
        hide: "fade",
        modal: true,
        height: '500',
        width: '700',
        resizable: true,
        title: 'Quản lý ảnh sản phẩm',
        close: function () {
            window.location.reload();
        }
    });
    $('.imgproduct').click(function () {
        var proid = $(this).attr("data-id");
        $("#dialog #myIframe").attr("src", "/admin/ProductImages/Index?id=" + proid);
        $('#dialog').dialog('open');
        return false;
    });

    //checked all
    $("#title-checkbox").change(function () {
        var checkedStatus = this.checked;
        var checkbox = $(this).parents('.box').find('tr td input:checkbox');

        checkbox.each(function () {
            this.checked = checkedStatus;
            if (this.checked) {
                checkbox.attr("selected", "checked");
                checkbox.parent('span').addClass('checked');
            }
            else {
                checkbox.attr("selected", "");
                checkbox.parent('span').removeClass('checked');
            }
        });
    });
    //update isactive
    $("span.active").click(function () {
        var id = $(this).attr('data-title');
        var bool = $(this).attr('data-boo');
        if (bool == 'True') {
            $(this).removeClass("label-success");
            $(this).addClass("label-danger");

            $(this).removeAttr("data-original-title");
            $(this).attr("data-original-title", "Không hiển thi");

            $(this).removeAttr('data-boo');
            $(this).attr("data-boo", "False");

            $(this).html("X");
        }
        else {
            $(this).removeClass("label-danger");
            $(this).addClass("label-success");

            $(this).removeAttr("data-original-title");
            $(this).attr("data-original-title", "Hiển thị");

            $(this).removeAttr('data-boo');
            $(this).attr("data-boo", "True");

            $(this).html("V");
        }
        //var id = $(this).attr('title');
        //var bool = $(this).attr('data-boo');
        $.ajax(
        {
            type: "POST",
            url: '/Admin/Products/UpdateIsActive',
            data: { id: id, isactive: bool }
        });
    });


    //update ispromotion
    $("span.ispromotion").click(function () {
        var id = $(this).attr('data-title');
        var bool = $(this).attr('data-boo');
        if (bool == 'True') {
            $(this).removeClass("label-success");
            $(this).addClass("label-danger");

            $(this).removeAttr('data-boo');
            $(this).attr("data-boo", "False");

            $(this).html("X");
        }
        else {
            $(this).removeClass("label-danger");
            $(this).addClass("label-success");

            $(this).removeAttr('data-boo');
            $(this).attr("data-boo", "True");

            $(this).html("V");
        }

        $.ajax(
                {
                    type: "POST",
                    url: '/Admin/Products/UpdateIsPromotion',
                    data: { id: id, ispromotion: bool }
                })
    });
    //update isnews
    $("span.isnews").click(function () {
        var id = $(this).attr('data-title');
        var bool = $(this).attr('data-boo');
        if (bool == 'True') {
            $(this).removeClass("label-success");
            $(this).addClass("label-danger");

            $(this).removeAttr('data-boo');
            $(this).attr("data-boo", "False");

            $(this).html("X");
        }
        else {
            $(this).removeClass("label-danger");
            $(this).addClass("label-success");

            $(this).removeAttr('data-boo');
            $(this).attr("data-boo", "True");

            $(this).html("V");
        }

        $.ajax(
        {
            type: "POST",
            url: '/Admin/Products/UpdateIsNews',
            data: { id: id, isnews: bool }
        });
    });

    //update ishot
    $("span.ishot").click(function () {
        var id = $(this).attr('data-title');
        var bool = $(this).attr('data-boo');
        if (bool == 'True') {
            $(this).removeClass("label-success");
            $(this).addClass("label-danger");

            $(this).removeAttr('data-boo');
            $(this).attr("data-boo", "False");

            $(this).html("X");
        }
        else {
            $(this).removeClass("label-danger");
            $(this).addClass("label-success");

            $(this).removeAttr('data-boo');
            $(this).attr("data-boo", "True");

            $(this).html("V");
        }

        $.ajax(
                {
                    type: "POST",
                    url: '/Admin/Products/UpdateIsHot',
                    data: { id: id, ishot: bool }
                })
    });

    //update isfeatured
    $("span.isfeatured").click(function () {
        var id = $(this).attr('data-title');
        var bool = $(this).attr('data-boo');
        if (bool == 'True') {
            $(this).removeClass("label-success");
            $(this).addClass("label-danger");

            $(this).removeAttr('data-boo');
            $(this).attr("data-boo", "False");

            $(this).html("X");
        }
        else {
            $(this).removeClass("label-danger");
            $(this).addClass("label-success");

            $(this).removeAttr('data-boo');
            $(this).attr("data-boo", "True");

            $(this).html("V");
        }

        $.ajax(
                {
                    type: "POST",
                    url: '/Admin/Products/UpdateIsFeatured',
                    data: { id: id, isfeatured: bool }
                })
    });



    //xóa nhiều bản ghi cùng một nút
    $(".delete").click(function () {
        var conf = confirm("Bạn có thực sự muốn xóa những bản ghi này?");
        if (conf == true) {
            var checkbox = $(this).parents('.box').find('tr td input:checkbox');
            var bool = false;
            checkbox.each(function () {
                if (this.checked) {
                    bool = true;
                    $.ajax(
                      {
                          type: "POST",
                          url: '/Admin/Products/DeleteMutileItem',
                          async: false,
                          beforeSend: function () {
                              $("#rendersearch").html("<div id='dvloading' style=' text-align: center; padding: 20px 0px;'><img src='/Content/themes/images/ajax-loader.gif' /></div>");
                          },
                          dataType: "json",
                          data: { item: $(this).val() }
                      })
                .fail(function () {
                    $.gritter.add({
                        title: 'Thông báo lỗi.',
                        text: 'Có lỗi xảy ra trong quá trình cập nhật.',
                        sticky: false,
                        class_name: 'my_class_gritter_error'
                    });
                })
                }
            });

            if (!bool) {
                $.gritter.add({
                    title: 'Chú ý.',
                    text: 'Bạn phải chọn ít nhất 1 bản ghi để xóa.',
                    sticky: false,
                    class_name: 'my_class_gritter_alert'
                });
            }
            else {
                window.location.reload();
            }
        }

    });
   

    //update order
    $('.txtorder').focusout(function (event) {
        if (event.which == 13) {
            alert("af");
        }
        else {
            var value = $(this).val();
            var _id = $(this).attr('data-id');
            $.ajax(
                {
                    type: "POST",
                    url: '/Admin/Products/UpdateOrder',
                    data: { id: _id, order: value }
                })
                .done(function () {
                    $.gritter.add({
                        title: 'Thông báo thành công.',
                        text: 'Bạn đã cập nhật thứ tự thành công.',
                        sticky: false,
                        class_name: 'my_class_gritter_success'
                    });
                })
                .fail(function () {
                    $.gritter.add({
                        title: 'Thông báo lỗi.',
                        text: 'Có lỗi xảy ra trong quá trình cập nhật.',
                        sticky: false,
                        class_name: 'my_class_gritter_error'
                    });
                });
        }
    });


    
});