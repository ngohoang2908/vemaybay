

$(document).ready(function () {
   
    
    $("a.IsEnable").click(function () {
        var id = $(this).attr('title');
        var bool = $(this).attr('data-boo');
        $.ajax(
                {
                    type: "POST",
                    url: '/admin/reviews/UpdateIsEnable',
                    data: { id: id, isactive: bool }
                })

            .done(function () {
                window.location.reload();
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
                            url: '/Admin/reviews/DeleteMutileItem',
                            beforeSend: function () {
                                $("#rendersearch").html("<div id='dvloading' style=' text-align: center; padding: 20px 0px;'><img src='/Content/themes/admin/images/ajax-loader.gif' /></div>");
                            },
                            async: false,
                            dataType: "json",
                            data: { item: $(this).val() }
                        }).done(function () {
                            $.gritter.add({
                                title: 'Thông báo thành công.',
                                text: 'Cập nhật thành công.',
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
        $('#myAlert').modal('show');
        //showalert("Bạn có thực sự muốn xóa bản ghi này?", "Cảnh báo", true);
    });

    $(".deleleoneitem").click(function () {
        var _id = $(this).attr('data');
        $.ajax(
            {
                type: "POST",
                url: '/Admin/reviews/DeleteMutileItem',
                data: { item: _id }
            })
            .done(function () {
                $('#myAlert').modal('hide');
                window.location.reload();
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