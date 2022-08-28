function StartSpiner(Parent) {
    StopSpiner(Parent);
    var spiner = $("#" + Parent).append('<div class="loader"></div>')
    return spiner;
}

function StopSpiner(Parent) {
    var DIVS = $('#' + Parent).find("DIV");
    for (var i = 0; i < DIVS.length; i++) {
        if (DIVS[i].className == "loader") {
            DIVS[i].remove();
        }
    }
}

function ShowDetails(b) {
    var id = b.id;
    document.location.href = '/Home/Index/' + id;
    //показываем PC
}