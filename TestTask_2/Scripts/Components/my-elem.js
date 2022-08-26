class MyTest extends HTMLElement {
    constructor() {
        super();
        //this.renderMe = function () {
        //    render();
        //}
    }

    Arr = [];
    render() {
        let html;
        let data = JSON.parse(this.getAttribute('data'));
        if (data != null) {
            Arr.push(data);
            for (var i = 0; i < data.length; i++) {
                html += '<div>' + data.Id + '</div> <div>' + data.Cpu + '</div>';
            }
        } else {
            html = 'Нет данных';
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
customElements.define("my-elem", MyTest);
