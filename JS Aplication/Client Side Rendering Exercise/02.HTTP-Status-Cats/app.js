import { render } from "./../node_modules/lit-html/lit-html.js";
import { ulTemplate } from "./catCardTemplate.js";
import { cats } from "./catSeeder.js";

const main = document.getElementById('allCats');
main.addEventListener('click', toggleInfo);
const result = ulTemplate(cats);

render(result, main);

function toggleInfo(event) {
    if (event.target.classList.contains('showBtn')) {
        const element = event.target.parentElement;
        const currentState = element.querySelector('.status').style.display;
        if (currentState == 'block') {
            element.querySelector('.status').style.display = 'none';
            element.querySelector('.showBtn').textContent = "Show status code";
        } else {
            element.querySelector('.status').style.display = 'block';
            element.querySelector('.showBtn').textContent = "Hide status code";
        }
    }
}