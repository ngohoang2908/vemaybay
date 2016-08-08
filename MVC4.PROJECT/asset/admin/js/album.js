//update tiêu đề bài viết
function updateVal(currentEle, value, idpro) {
    $(currentEle).html('<input class="thVal" type="text" value="' + value.trim() + '" />');
    $(".thVal").focus();
    $(".thVal").keyup(function (event) {
        if (event.keyCode == 13) {
            $.ajax(
                {
                    type: "POST",
                    url: '/Admin/Album/UpdateTitle',
                    data: { id: idpro, title: $(".thVal").val().trim() }
                })
                .done(function () {
                    $(currentEle).html($(".thVal").val().trim());
                    $.gritter.add({
                        title: 'Thông báo thành công.',
                        text: 'Bạn đã cập nhật tiêu đề album ảnh thành công.',
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

    $(".thVal").focusout(function () {
        $.ajax(
                 {
                     type: "POST",
                     url: '/Admin/Album/UpdateTitle',
                     data: { id: idpro, title: $(".thVal").val().trim() }
                 })

             .done(function () {
                 $(currentEle).html($(".thVal").val().trim());
                 $.gritter.add({
                     title: 'Thông báo thành công.',
                     text: 'Bạn đã cập nhật tiêu đề album ảnh thành công.',
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
             })
    });
}



$(document).ready(function () {
    //alert("OK");
    //hiển thị form upload ảnh
    $("#dialog").dialog({
        autoOpen: false,
        show: "fade",
        hide: "fade",
        modal: true,
        height: '500',
        width: '700',
        resizable: true,
        title: 'Quản lý ảnh album'
    });
    $('.imgproduct').click(function () {
        var proid = $(this).attr("data-id");
        $("#dialog #myIframe").attr("src", "/admin/albumimages/Index?id=" + proid);
        $('#dialog').dialog('open');
        return false;
    });


    //update isactive
    $("span.active").click(function () {
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
                    url: '/Admin/Album/UpdateIsActive',
                    data: { id: id, isactive: bool }
                })

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
        var cof = confirm("Bạn có thực sự muốn xóa những bản ghi đã chọn ?");
        if (cof == true) {
            var checkbox = $(this).parents('.box').find('tr td input:checkbox');
            var bool = false;
            checkbox.each(function () {
                if (this.checked) {
                    bool = true;
                    $.ajax(
                        {
                            type: "POST",
                            url: '/Admin/Album/Delete',
                            beforeSend: function () {
                                $("#rendersearch").html("<div id='dvloading' style=' text-align: center; padding: 20px 0px;'><img src='/Content/themes/website/images/ajax-loader.gif' /></div>");
                            },
                            async: false,
                            dataType: "json",
                            data: { id: $(this).val() }
                        })
                        .fail(function () {
                            alert("cố lỗi xảy ra!!");
                        });
                }
            });
            if (!bool)
                alert("Bạn vui lòng chọn một bản ghi để xóa!");
            else
                window.location.reload();
        }

    });
    //xóa một bản ghi
    $(".btndelte").click(function () {
        var id = $(this).attr('data');
        $(".deleleoneitem").attr('data', id);
        $('#myAlert').modal('show');
        //showalert("Bạn có thực sự muốn xóa bản ghi này?", "Cảnh báo", true);
    });
    $(".deleleoneitem").click(function () {
        var id = $(this).attr('data');
        $.ajax(
            {
                type: "POST",
                url: '/Album/Delete',
                data: { id: id }
            })
            .done(function () {
                $('#myAlert').modal('hide');
                $("#trow_" + _id).fadeTo("fast", 0, function () {
                    $(this).slideUp("fast", function () { $(this).remove(); });
                });
            })
            .fail(function () {
                alert("cố lỗi xảy ra!!");
            });
    });

    $(document).on('focusout', '.txtorder', function () {
        if (event.which == 13) {
            alert("nxh");
        } else {
            var value = $(this).val();
            var _id = $(this).attr('data-id');
            $.ajax({
                url: '/Admin/album/UpdateOrder',
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

});
