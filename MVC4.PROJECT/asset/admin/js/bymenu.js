var menu = {
    init: function () {
        menu.rendertreetable();
    },
    rendertreetable: function () {
        var strhtml = "<div style='text-align: center; padding: 20px 0px;'><img src='/Content/themes/images/ajax-loader.gif' /></div>";
        $('#grid').html(strhtml);
        var tr_template = "";
        tr_template = "<tr data-tt-id='{{ID}}' {{Parent}}> ";
        tr_template += "  <td><span class='{{Class}}'>{{Title}}</span></td>";//cột tiêu đề
        //tr_template += "  <td>{{MetaTitle}}</td>";//cột metatitle
        tr_template += "  <td><center><input type='text' data='{{ID}}' style='width: 30px; height: 14px;margin-bottom:2px' value='{{Order}}' /></center></td>";//status
        tr_template += "  <td> <center>";
        tr_template += "     <a  data='{{ID}}' class='btn btnview btn-danger btndelte'> Xóa khỏi menu </a></center>";
        tr_template += "  </td>";
        tr_template += "  </tr>";
        //alert(tr_template);

        $.getJSON('/Api/CategoriesApi/jtreetablebymenu?select=', { menucode: '@ViewBag.menucode', lang: '@Session["language"].ToString()' }).done(function (data) {
            var html = "";
            $.each(data, function (i, item) {
                var id = item.ID;
                var title = item.Title;
                //var metatitle = item.MetaTitle != null ? item.MetaTitle : "";
                var haschild = item.HasChild;
                var parent = item.Parent;
                var order = item.SortOrder;
                //alert(IsActive);
                var temp = tr_template.replace("{{ID}}", id).replace("{{ID}}", id).replace("{{ID}}", id).replace("{{ID}}", id).replace("{{Title}}", title).replace("{{Order}}", order);
                if (parent != null) {
                    temp = temp.replace("{{Parent}}", "data-tt-parent-id='" + parent + "'");
                } else {
                    temp = temp.replace("{{Parent}}", "");
                }
                if (haschild) {
                    temp = temp.replace("{{Class}}", "folder");
                } else {
                    temp = temp.replace("{{Class}}", "file");
                }
                html += temp;

            });
            var table = "";
            table += "<table id=\"treetable\">";
            table += "    <thead><tr>";
            table += "         <th>Tiêu đề</th>";
            //table += "         <th>MetaTitle</th>";
            table += "         <th style='width:90px; text-align:center;'><a href='javascript:void(0)' class='btn btn-mini btn-info' id='btnupdateorder'>Sắp xếp</a></th>";
            table += "         <th style='width:110px;'></th>";
            //table += "         <th><center><input type='checkbox' id='selectall' /></center></th>";
            table += "    </tr></thead>";
            table += "    <tbody>" + html + "</tbody>";
            table += "</table>";
            alert(table);
            $('#grid').html(table);
            $("#treetable").treetable({ expandable: true });
            $("#treetable tbody tr").mousedown(function () {
                $("tr.selected").removeClass("selected");
                $(this).addClass("selected");
            });
            jQuery('#treetable').treetable('expandAll');
        });
    }
}
menu.init();
