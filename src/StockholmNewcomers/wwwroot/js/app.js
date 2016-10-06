
//$("#menu").click(function () {
//    $("#menu").removeClass('none')
//});

//$('li').click(function () {
//    $(this).removeClass('none');
//    $(this).siblings().addClass('none');
//});

$(document).foundation();

function openPreview() {
    document.getElementById("namePreview").innerHTML = document.getElementById("nameform").value;
    document.getElementById("summaryPreview").innerHTML = document.getElementById("sumform").value;
    document.getElementById("descriptionPreview").innerHTML = document.getElementById("descriptionform").value;
    document.getElementById("websitePreview").innerHTML = document.getElementById("websiteform").value;
    document.getElementById("facebookPreview").innerHTML = document.getElementById("facebookform").value;
    document.getElementById("emailPreview").innerHTML = document.getElementById("emailform").value;
}


$('li').click(function () {
    $(this).removeClass('none');
    $(this).siblings().addClass('none');
});


(function () {
    var materialForm;
    materialForm = function () {
        return $('.material-field').focus(function () {
            return $(this).closest('.form-group-material').addClass('focused has-value');
        }).focusout(function () {
            return $(this).closest('.form-group-material').removeClass('focused');
        }).blur(function () {
            if (!this.value) {
                $(this).closest('.form-group-material').removeClass('has-value');
            }
            return $(this).closest('.form-group-material').removeClass('focused');
        });
    };
    $(function () {
        return materialForm();
    });
}.call(this));