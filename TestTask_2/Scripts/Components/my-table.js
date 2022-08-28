class MyTable extends HTMLElement {
    constructor() {
        super();
        this.countShow = 10;
        this.countClicksMore = 1;
        this.addClicks = function () {
            this.countClicksMore++;
            render();
        }
    }

    render() {
        let html = '';
        let data = JSON.parse(this.getAttribute('data'));
        if (data != null && data.length > 0) {
            let keys = Object.keys(data[0])
            this.dataObj = data;
            //сколько строк отображать
            if (this.dataObj.length < 10 * this.countClicksMore) {
                this.countShow = this.dataObj.length;
            } else {
                this.countShow = 10 * this.countClicksMore;
            }

            html += '<table class="table">';
            for (var k = 0; k < keys.length; k++) {
                if (keys[k] == 'Id') {
                    continue;
                }
                html += '<th>' + keys[k] + '</th>';
            }

            for (var i = 0; i < this.countShow; i++) {
                html += '<tr>';

                for (var k = 0; k < keys.length; k++) {
                    if (keys[k] == 'Id') {
                        continue;
                    }
                    else if (keys[k] == 'PCId') {
                        var pcid = this.dataObj[i][keys[k]];
                        html += '<td><button id="' + pcid +'" class="floating-button" onclick="ShowDetails(this)" type="submit">Подробнее</button></td>';
                        continue;
                    }
                    html += '<td>' + this.dataObj[i][keys[k]] + '</td>';
                }
                html += '</tr>';
            }
            html += '</table>';
            //если выведенных меньше чем есть на самом деле, то необходимо отобразить кнопку ленивой загрузки
            if (this.dataObj.length > 10 * this.countClicksMore) {
                html += '<div id="loadMore" class="loadMore"><a>Показать ещё...</a></div>';
            }
        } else {
            html = '<div class="NoData">Нет данных</div>';
        }
        this.innerHTML = html;
        //$('#loadMore').click = this.addClicks;
        if (data != null && data.length > 0) {
            this.querySelector("a").addEventListener("click", () => {
                if (this.dataObj.length < 10 * this.countClicksMore) {
                    return;
                }
                this.countClicksMore++;
                this.render();
            });
        }
    }

    connectedCallback() {
        if (!this.rendered) {
            this.render();
            this.rendered = true;
        }
    }

    static get observedAttributes() { 
        return ['data'];
    }

    attributeChangedCallback(name, oldValue, newValue) { 
        this.render();
    }
}
customElements.define("my-table", MyTable);
