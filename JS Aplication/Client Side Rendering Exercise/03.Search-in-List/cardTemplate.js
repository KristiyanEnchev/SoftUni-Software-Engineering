import { html } from "./../node_modules/lit-html/lit-html.js";

const townsCardTemplate = (town) => html`
<li>${town}</li>`;

export const ulTemplate = (towns) => html`
<ul>
    ${towns.map(townsCardTemplate)}
</ul>`;