﻿
$(document).ready(function () {


    //xóa nhiều bản ghi cùng một nút
    $(".delete").click(function () {
        var checkbox = $('.box').find('tr td input:checkbox');
        //if (checkbox.attr("selected", "")) {
        //    alert("Bạn chưa chọn bản ghi nào");
        //}
        var conf = confirm("Bạn có thực sự muốn xóa những bản ghi này !");
        if (conf == true) {
            var checkbox = $(this).parents('.box').find('tr td input:checkbox');
            var bool = false;
            checkbox.each(function () {
                if (this.checked) {
                    bool = true;
                    $.ajax(
                        {
                            type: "POST",
                            url: '/Categories/Delete',
                            beforeSend: function () {
                                $("#rendersearch").html("<div id='dvloading' style=' text-align: center; padding: 20px 0px;'><img src='/Content/themes/admin/images/ajax-loader.gif' /></div>");
                            },
                            async: false,
                            dataType: "json",
                            data: { id: $(this).val() }
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
            if (!bool) {
                $.gritter.add({
                    title: 'Chú ý.',
                    text: 'Bạn vui lòng chọn một bản ghi để xóa!',
                    sticky: false,
                    class_name: 'my_class_gritter_alert'
                });
            }
            else {
                window.location.reload();
            }
        }

    });
   
    //xóa một bản ghi
    $(".btndelte").click(function () {
        var id = $(this).attr('data');
        $(".deleleoneitem").attr('data', id);
        //showalert("Bạn có thực sự muốn xóa bản ghi này?", "Cảnh báo", true);
    });

    $(".deleleoneitem").click(function () {
        var _id = $(this).attr('data');
        $.ajax(
            {
                type: "POST",
                url: '/Categories/DeleteOneItem',
                data: { item: _id }
            })
            .done(function () {
                hidealert();
                $("#trow_" + _id).fadeTo("fast", 0, function () {
                    $(this).slideUp("fast", function () { $(this).remove(); });
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
    });
    //đóng alert
    $('.close').click(function () {
        hidealert();
    });
    $('.closealert').click(function () {
        hidealert();
    });
});