class MyTable extends HTMLElement {
    constructor() {
        super();
        this.countShow = 10;
        this.countClicksMore = 1;
        this.filter = '';
        this.fiteredData = null;
        this.fiteredFocus = false;
    }

    filterF() {
        if (this.filter == '') {
            this.fiteredData = null;
            this.render();
            return;
        }
        this.fiteredFocus = true;
        this.fiteredData = new Array();
        var re = new RegExp('.?' + this.filter.toUpperCase() + '.?');
        for (var i = 0; i < this.dataObj.length; i++) {
            for (var k = 0; k < this.keys.length; k++) {
                if (String(this.dataObj[i][this.keys[k]]).toUpperCase().match(re)) {
                    //захардкодил по названиям столбцов, но в идеале просто исключить регулярным выражением по md5 
                    if (this.keys[k] == 'Id' || this.keys[k] == 'ПК') {
                        continue;
                    }
                    this.fiteredData.push(this.dataObj[i]);
                    break;
                }                
            }
        }
        this.render();
    }

    render() {
        let html = '';
        let data = JSON.parse(this.getAttribute('data')) || null;
        if (data != null && data.length > 0) {
            html += '<input id="filter' + this.id + '" class="filter" onfocus="this.selectionStart = this.selectionEnd = this.value.length;" placeholder="Поле фильтрации" oninput="changeFilter(' + this.id + ', this)" value="' + this.filter + '"></input>';
            let keys = Object.keys(data[0]);
            this.keys = keys;
            this.dataObj = data;

            if (this.filter == '') {
                this.fiteredData = this.dataObj;
            }

            //сколько строк отображать
            if (this.fiteredData.length < 10 * this.countClicksMore) {
                this.countShow = this.fiteredData.length;
            } else {
                this.countShow = 10 * this.countClicksMore;
            }

            html += '<table class="table">';
            for (var k = 1; k < keys.length; k++) {
                html += '<th>' + keys[k] + '</th>';
            }

            for (var i = 0; i < this.countShow; i++) {
                html += '<tr>';

                for (var k = 1; k < keys.length; k++) {
                    if (keys[k] == 'ПК') {
                        var pcid = this.fiteredData[i][keys[k]];
                        html += '<td style="text-align:center;"><button id="' + pcid +'" class="floating-button" onclick="ShowDetails(this)" type="submit">Подробнее</button></td>';
                        continue;
                    }
                    html += '<td>' + this.fiteredData[i][keys[k]] + '</td>';
                }
                html += '</tr>';
            }
            html += '</table>';
            //если выведенных меньше чем есть на самом деле, то необходимо отобразить кнопку ленивой загрузки
            if (this.fiteredData.length > 10 * this.countClicksMore) {
                html += '<div id="loadMore" class="loadMore"><a>Показать ещё...</a></div>';
            }
        } else {
            html = '<div class="NoData">Нет данных</div>';
        }

        this.innerHTML = html;

        if (data != null && data.length > 0) {
            if (this.fiteredFocus) {
                document.getElementById('filter' + this.id).focus();
            }
            try {
                this.querySelector("#loadMore").addEventListener("click", () => {
                    if (this.fiteredData.length < 10 * this.countClicksMore) {
                        return;
                    }
                    this.countClicksMore++;
                    this.render();
                });
            } catch (e) {

            }
        }
    }

    connectedCallback() {
        if (!this.rendered) {
            this.render();
            this.rendered = true;
        }
    }

    static get observedAttributes() { 
        return ['data', 'filter'];
    }

    attributeChangedCallback(name, oldValue, newValue) {
        this.filterF();
        this.render();
    }
}
customElements.define("my-table", MyTable);
