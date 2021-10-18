import { render } from "./../node_modules/lit-html/lit-html.js";
import { optionTemplate } from "./templates.js";
import { getDropdownItems, postInDropdownItems } from "./requestsHendler.js";

const main = document.querySelector('div');
processData();
async function processData() {
    let dropdownData = await getDropdownItems();
    let list = Object.values(dropdownData);
    renderer(list);
}

function renderer(list) {
    const dropdown = optionTemplate(list)
    render(dropdown, main);
}

const addBtn = document.getElementById('btn').addEventListener('click', addItem);
let imputData = document.getElementById('itemText');

async function addItem(event) {
    event.preventDefault();
    let body = {
        text: imputData.value
    }

    let data = await postInDropdownItems(JSON.stringify(body));
    imputData.value = '';
    processData();
}