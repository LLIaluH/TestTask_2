class PCView extends HTMLElement {
    constructor() {
        super();
        this.dataObj = JSON.parse(this.getAttribute('data'));

    }

    Arr = [];
    render() {
        let html;
        if (data != null) {
            Arr.push(data);
            for (var i = 0; i < data.length; i++) {
                html += '<div class="backModalScreen">' + data[i] + '</div>';
            }
        } else {
            html = 'Ошибка';
        }
        this.innerHTML = html;
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
