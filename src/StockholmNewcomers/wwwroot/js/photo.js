$("#uploadEditorImage").change(function () {
    var data = new FormData();
    var files = $("#uploadEditorImage").get(0).files;
    if (files.length > 0) {
        data.append("HelpSectionImages", files[0]);
    }
    $.ajax({
        url: resolveUrl("~/Admin/HelpSection/AddTextEditorImage/"),
        type: "POST",
        processData: false,
        contentType: false,
        data: data,
        success: function (response) {
            //code after success

        },
        error: function (er) {
            alert(er);
        }

    });
});