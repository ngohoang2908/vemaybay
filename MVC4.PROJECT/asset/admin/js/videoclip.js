

$(document).ready(function () {
    $(document).on('focusout', '.txtorder', function () {
        if (event.which == 13) {
            alert("nxh");
        } else {
            var value = $(this).val();
            var _id = $(this).attr('data-id');
            $.ajax({
                url: '/Admin/Videoclip/UpdateOrder',
                type: 'POST',
                dataType: 'json',
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
    $("#dialog").dialog({
        autoOpen: false,
        show: "fade",
        hide: "fade",
        modal: true,
        height: '400',
        width: '600',
        resizable: true,
        title: 'Xem video clips'
    });
    $(".btndialog").click(function() {
        var _id = $(this).attr("data");
        $("#dialog #myIframe").attr("src", "/admin/videoclip/Showvideo?id=" + _id);
        $('#dialog').dialog('open');
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
                            url: '/Admin/Videoclip/Delete',
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

    //update isactive
    $("span.active").click(function () {
        var id = $(this).attr('data-title');
        var bool = $(this).attr('data-boo');
        if (bool == 'True') {
            $(this).removeClass("label-success");
            $(this).addClass("label-danger");

            $(this).removeAttr('data-boo');
            $(this).attr("data-boo", "Flase");

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
            url: '/Admin/Videoclip/UpdateIsActive',
            data: { id: id, isactive: bool }
        }).done(function() {
            $.gritter.add({
                title: 'Thông báo thành công.',
                text: 'Bạn đã cập nhật thứ tự thành công.',
                sticky: false,
                class_name: 'my_class_gritter_success'
            });
        });
    });
    //xóa một bản ghi
    $(".btndelte").click(function () {
        var id = $(this).attr('data');
        $(".deleleoneitem").attr('data', id);
        $('#myAlert').modal('show');
        //showalert("Bạn có thực sự muốn xóa bản ghi này?", "Cảnh báo", true);
    });

    $(".deleleoneitem").click(function () {
        var _id = $(this).attr('data');
        $.ajax(
            {
                type: "POST",
                url: '/Videoclip/Delete',
                data: { id: _id }
            })
            .done(function () {
                $('#myAlert').modal('hide');
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

   
});