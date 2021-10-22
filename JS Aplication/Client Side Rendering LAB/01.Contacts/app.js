import { render } from "./node_modules/lit-html/lit-html.js";
import { contacts } from "./contacts.js";
import { cardTemplate } from "./cardTemplate.js";

const container = document.getElementById('contacts');
container.addEventListener('click', onClick);
const result = contacts.map(cardTemplate);

render(result, container);

function onClick(event) {
    if (event.target.classList.contains('detailsBtn')) {
        const element = event.target.parentElement;
        const currentState = element.querySelector('.details').style.display;
        if (currentState == 'block') {
            element.querySelector('.details').style.display = 'none';
        } else {
            element.querySelector('.details').style.display = 'block';
        }
    }
}