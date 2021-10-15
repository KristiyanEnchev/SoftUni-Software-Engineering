import { render } from "./../node_modules/lit-html/lit-html.js";
import { createTownsCard } from "./townsTemplate.js";

let main = document.getElementById('root');

let loadBtn = document.getElementById('btnLoadTowns').addEventListener('click', updateList);

function updateList(event) {
    event.preventDefault();
    const input = document.getElementById('towns').value;

    let data = input.split(', ').map(x => x.trim());

    render(createTownsCard(data), main);
}