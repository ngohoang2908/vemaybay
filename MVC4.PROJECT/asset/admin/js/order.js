$(document).ready(function () {
    $('#fromdate').datepicker();
    $('#todate').datepicker();
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
        var conf = confirm("Bạn có thực sự muốn xóa những bản ghi này?");
        if (conf == true) {
            var checkbox = $(this).parents('.widget-box').find('tr td input:checkbox');
            var bool = false;
            checkbox.each(function () {
                if (this.checked) {
                    bool = true;
                    $.ajax(
                      {
                          type: "POST",
                          url: '/Order/DeleteMutileItem',
                          beforeSend: function () {
                              $("#rendersearch").html("<div id='dvloading' style=' text-align: center; padding: 20px 0px;'><img src='/Content/themes/website/images/ajax-loader.gif' /></div>");
                          },
                          async: false,
                          dataType: "json",
                          data: { item: $(this).val() }
                      })

                .fail(function () {
                    alert("cố lỗi xảy ra!!");
                })
                }
            });
            if (!bool) {
                $.gritter.add({
                    title: 'Chú ý.',
                    text: 'Bạn phải chọn ít nhất 1 bản ghi đi xóa.',
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
    $(".btndelte").click( function () {
        var id = $(this).attr('data');
        $(".deleleoneitem").attr('data', id);
        showalert("Bạn có thực sự muốn xóa bản ghi này?", "Cảnh báo", true);
    });
    $(".deleleoneitem").click( function () {
        var id = $(this).attr('data');
        $.ajax(
            {
                type: "POST",
                url: '/Order/DeleteMutileItem',
                data: { item: id }
            })
            .done(function() {
                $('#myAlert').modal('hide');
                $("#trow_" + id).fadeTo("fast", 0, function() {
                    $(this).slideUp("fast", function() { $(this).remove(); });
                });
            })
            .fail(function() {
                alert("cố lỗi xảy ra!!");
            });
    });
   

});