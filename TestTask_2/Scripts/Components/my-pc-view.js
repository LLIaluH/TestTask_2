class PCView extends HTMLElement {
    constructor() {
        super();
        this.dataObj = null;
        this.activeId = null;
    }

    showPC(id) {
        this.activeId = id;
        this.render();
    }

    hide() {
        this.activeId = null;
        this.innerHTML = '';
    }

    render() {
        let errors = '';
        let data = JSON.parse(this.getAttribute('data'));
        this.dataObj = data || null;

        if (this.activeId == null || this.dataObj == null) {
            return;
        }
        let keys = Object.keys(data[0]);
        this.keys = keys;
        let currentPc = null;
        for (var i = 0; i < this.dataObj.length; i++) {
            if (this.dataObj[i][this.keys[0]] == this.activeId) {
                currentPc = this.dataObj[i];
                break;
            }
        }
        if (currentPc == null) {
            errors += 'Нет такого PC!';
        }
        let html = '';
        html += '<div class="backModalScreen">';
        html += '<div class="centerPC">';
        for (var k = 0; k < this.keys.length; k++) {
            html += '<div class="form-group">';
            html += '<label class="myLabel" for="' + keys[k] + '">' + keys[k] + '</label><input readonly class="form-control" id="' + keys[k] + '" value="' + currentPc[keys[k]] + '"></input>';
            html += '</div>';
        }
        html += '<button class="closeBtn" onclick="hide(' + this.id + ')">Закрыть</button>';
        html += '</div>';
        html += '</div>';

        if (errors.length > 0) {
            alert(errors);
        } else {
            this.innerHTML = html;
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
customElements.define("my-pc-view", PCView);
