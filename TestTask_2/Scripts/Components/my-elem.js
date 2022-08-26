class MyTest extends HTMLElement {

    constructor() {
        super();

        this.text = {
            "when-close": "Развернуть",
            "when-open": "Свернуть",
        }

        this.innerHTML = `
      <button type="button">${this.text["when-close"]}</button>
      <section style="display: none;">${this.innerHTML}</section>
    `;

        this.querySelector("button").addEventListener("click", () => {
            const opened = (this.getAttribute("opened") !== null);

            if (opened) {
                this.removeAttribute("opened");
            } else {
                this.setAttribute("opened", "");
            }
        });
    }

    //Arr = [];
    //render() { // (1)
    //    let data = JSON.parse(this.getAttribute('data'));
    //    Arr.push(data);
    //    //var html = <table>;
    //    for (var i = 0; i < data.length; i++) {
    //        html += '<div>' + data.Id + '</div> <div>' + data.Cpu + '</div>';
    //    }
    //    this.innerHTML = html;
    //}

    //connectedCallback() {
    //    if (!this.rendered) {
    //        this.render();
    //        this.rendered = true;
    //    }
    //}
}
customElements.define("my-elem", MyTest);
