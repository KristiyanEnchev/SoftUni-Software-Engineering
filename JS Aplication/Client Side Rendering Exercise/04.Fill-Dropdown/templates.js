import { html } from "./../node_modules/lit-html/lit-html.js";

const optionCreate = (item) => html`<option value='${item._id}'>${item.text}</option>`;

export const optionTemplate = (data) => html`
<select id='menu'>
    ${data.map(optionCreate)}
</select>`;
