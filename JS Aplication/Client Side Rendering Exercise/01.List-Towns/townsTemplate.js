import { html } from "./../node_modules/lit-html/lit-html.js";

export const createTownsCard = (data) => html`
<ul>
    ${data.map(t => html`<li>${t}</li>`)}
</ul>`;
