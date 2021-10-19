import { html } from "./../node_modules/lit-html/lit-html.js";

let template = (data) => html`
<tr>
    <td>${data.firstName + " " + data.lastName}</td>
    <td>${data.email}</td>
    <td>${data.course}</td>
</tr>`;

export let tableTeplate = (data) => html`
    ${data.map(template)}`;
