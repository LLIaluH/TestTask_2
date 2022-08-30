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

//показываем PC
function ShowDetails(b) {
    let id = b.id;
    $('#pcView')[0].showPC(id);
}

function hide(id) {
    //var a = id;
    $('#pcView')[0].hide();

}

function changeFilter(idMyTable, f) {
    StartSpiner('screen');
    setTimeout(() => StopSpiner('screen'), 1000);

    //сам ничего не понял, первым параметром сую id таблицы на странице, а приходит объект моего тэга...
    //ну и ладно, так даже удобнее
    let filterloc = f.value;
    idMyTable.filter = filterloc;
    //idMyTable.filterF();//почему это не работает, я так и не разобрался, пока захардкодил
    $('#userTable')[0].filterF();
}