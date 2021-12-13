import { setUpHome, showHome } from "./home.js"
import { setUpTopics } from "./topics.js"
import {createTopic} from "./create.js";

const main = document.querySelector('#display-main');
const views = {
    'home': showHome,
};

setupSection('home-section', setUpHome);
setupSection('theme-section', setUpTopics);

setUpNavigation();
showHome();

function setupSection(sectionId, setup) {
    const section = document.getElementById(sectionId);
    setup(main, section);
}

let form = document.querySelector('form');
form.addEventListener('submit', createTopic);

function setUpNavigation() {

    document.querySelector('nav').addEventListener('click', (event) => {
        event.preventDefault();
        if (event.target.tagName == 'A') {
            const view = views[event.target.id];
            if (typeof (view) == 'function') {
                view();
            }
        }
    });
}