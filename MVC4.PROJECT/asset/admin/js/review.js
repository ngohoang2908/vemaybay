$(document).ready(function () {

    $('.btnshowanswer').click(function () {
        var proid = $(this).attr("data-id");
        var question = $(this).parent().parent().find("a.containquestion").attr("title");
        var answer = $(this).parent().parent().find("p.containanswer").attr("data-answer");
        $("#renderquestion").html(question);
        $("#contenteditor").html(answer);


        return false;
    });

    //update isenable
    $("a.IsEnable").click(function () {
        var id = $(this).attr('title');
        var bool = $(this).attr('data-boo');
        $.ajax(
                {
                    type: "POST",
                    url: '/Reviews/UpdateIsEnable',
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

    //xóa một bản ghi
    $(".btndelte").click(function () {
        var id = $(this).attr('data');
        $(".deleleoneitem").attr('data', id);
        //showalert("Bạn có thực sự muốn xóa bản ghi này?", "Cảnh báo", true);
    });
    $(".deleleoneitem").click(function () {
        var id = $(this).attr('data');
        $.ajax(
                  {
                      type: "POST",
                      url: '/Reviews/DeleteMutileItem',
                      data: { item: id }
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
            })
    });
   


});