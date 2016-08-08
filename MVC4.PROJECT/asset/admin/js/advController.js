$(document).ready(function() {
    $(document).on('change', '#selectpos', function () {
        //$("#selectpos").change(function () {
        //$("#frmid").submit();
        var id = $(this).val();
        var url = "/admin/adv/search";
        $.get(url, { position: id }, function (data) {
            var strhtml = "";
            $.each(data, function (i, adv) {
                strhtml += "<div class='col-sm-4 col-md-2'>";
                strhtml += "<div class='form-group box-adv'>";
                strhtml += "<a class='thumbnail lightbox_trigger' href='" + adv.images + "'>";
                strhtml += "<img src='" + adv.images + "' alt='" + adv.name + "'>";
                strhtml += "</a>";
                strhtml += "<div class='actions'>";
                strhtml += "<a title='Sửa' href='/admin/adv/edit/" + adv.id + "'  class='btn btn-mini btn-primary'><i class='fa fa-pencil icon-white'></i></a>";
                strhtml += "<a title='Xóa' data='" + adv.id + "' class='btn btn-mini btn-danger btndelte'><i class='fa fa-trash icon-white'></i></a>";
                strhtml += "</div>";
                strhtml += "</div>";
                strhtml += "</div>";
            });
            $('.box-body .row').html(strhtml);
        }).done(function () {
            $.gritter.add({
                title: 'Thông báo thành công.',
                text: 'Cập nhật thành công.',
                sticky: false,
                class_name: 'my_class_gritter_success'
            });
        }).fail(function () {
            $.gritter.add({
                title: 'Thông báo lỗi.',
                text: 'Có lỗi xảy ra.',
                sticky: false,
                class_name: 'my_class_gritter_error'
            });
        });

    });

    //xóa một bản ghi
    $(document).on('click', '.btndelte', function () {
        //$(".btndelte").click(function () {
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
                url: '/Adv/Delete',
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