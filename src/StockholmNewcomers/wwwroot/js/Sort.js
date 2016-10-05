$('#checkbox').click(function () {
    $.post("/home/GetResultByCategory", {})
})


function hasClass(element, cls) {
    return (' ' + element.className + ' ').indexOf(' ' + cls + ' ') > -1;
}

function hideFunction(item) {

}

function filter(element) {
    var lista = document.getElementById('orgList');
    var organisations = lista.getElementsByClassName('js-company');

    if (element === "Language") {
        hideOrShow(organisations, 3)
    }

    if (element === "Community") {
        hideOrShow(organisations, 2);
    }
    if (element === "Info&Support") {
        hideOrShow(organisations, 4);
    }
    if (element === "All") {
        hideOrShow(organisations, 4);
        for (i = 0; i < organisations.length; i++) {
            $(organisations[i]).show();
        }
    }

    function hideOrShow(organisations, catNum) {
        for (i = 0; i < organisations.length; i++) {
            if (!hasClass(organisations[i], catNum)) {
                //item.className += temi.className ? ' hidden' : 'hidden';
                //$(organisations[i]).addClass("hidden");
                $(organisations[i]).hide();
            }
            else {
                $(organisations[i]).show();
                //item.classList.remove("hidden");
            }
        }

    }
}

function changeColor(id) {
    var btn = document.getElementById(id);
    if (btn.style.backgroundColor === "#f9b234") {
        btn.style.backgroundColor = "#e40b7c";
    } else {
        btn.style.backgroundColor = "#f9b234";
    }
}

function btnColor(btn) {
    if (btn.style.backgroundColor === "#f9b234") {
        btn.style.backgroundColor = "#e40b7c";
    document.getElementById(id).style.backgroundColor = "#A9A9A9";
    } else {
        btn.style.backgroundColor = "#f9b234";
    }c
}







//if (element == "Language") {
//    for (i = 0; i < organisations.length; i++) {
//        if (!hasClass(organisations[i], 2)) {
//            //item.className += temi.className ? ' hidden' : 'hidden';
//            //$(organisations[i]).addClass("hidden");
//            $(organisations[i]).hide();
//        }
//        else {
//            $(organisations[i]).show();
//            //item.classList.remove("hidden");
//        }
//    }

//}
/*
for (i = 0; i <organisations.length; i++) {
    if (element === "Language") {
        if(organisations[i].getElementsByName('category').innerHTML === 2)
            alert('Hello')
        //if (document.getElementsByName('category').innerHTML === 3 || document.getElementsByName('category').innerHTML === 2) {
        //    lista.className += "hidden";
        //    lista.className.style.visibility = 'hidden';
        //    item.className += "hidden";
        //    lista[0].style.visibility = 'hidden';
        //    organisations[0].style.visibility = 'hidden';
        //}
    }
    if (element === 'Community') {
        if (document.getElementsByName('category')[0].innerHTML === 3 || document.getElementsByName('category')[0].innerHTML === 4)
            organisations.className += "hidden";
    }
    if (element === 'Info&Support') {
        if (document.getElementsByName('category')[0].innerHTML === 2 || document.getElementsByName('category')[0].innerHTML === 4)
            organisations.className += "hidden";
    }
}*/
//if (element === 'Community') {
//    companies.sort(function (a, b) { return a.getElementsByClassName('language')[0].innerHTML.compareTo(b.language); });
//}
//if (element === 'Info&Support') {
//    companies.sort(function (a, b) { return a.getElementsByClassName('language')[0].innerHTML.compareTo(b.language); });
//}
//// GÖR SAMMA FÖR ALLA OCH SEN KAN VI 

//if(element === 'Language')

//for (item in companies) {
//    lista.appendChild(item);
//    //}


//function checkIfRightFilter(element) {
//    if (element === 'Language' && document.getElementsByName('category')[0].innerHTML === 3)
//        return;
//    else 
//        getElementbyClassName('langygage')


//    else if (element === 'Info&Support' && document.getElementsByName('category')[0].innerHTML === 4)
//        return;
//    else if (element === 'Community' && document.getElementsByName('category')[0].innerHTML === 2)
//        return;
//}