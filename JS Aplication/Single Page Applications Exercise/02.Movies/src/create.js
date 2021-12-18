import { createMovieRequestHandler } from "./requeststHandler.js";
import { showDetails } from "./details.js";

let main;
let section;

export function setupCreate(mainTarget, sectionTarget) {
    main = mainTarget;
    section = sectionTarget;
    const form = sectionTarget.querySelector('form').addEventListener('submit', processData);
}

export function showCreate() {
    main.querySelectorAll('section').forEach(section => section.remove());
    main.appendChild(section);
}

async function processData(event) {
    event.preventDefault();
    const formData = new FormData(event.target);
    const token = sessionStorage.getItem('authToken');

    if (formData.get('title') == '' || formData.get('description') == '' || formData.get('imageUrl') == '') {
        event.target.reset();
        return alert('All fields must be filed up');
    }

    const body = JSON.stringify({
        title: formData.get('title'),
        description: formData.get('description').split('\n').map(l => l.trim()).filter(l => l != ''),
        img: formData.get('imageUrl'),
    });

    if (token == null) {
        return alert('You\'re not logged in!');
    }

    try {
        let data = await createMovieRequestHandler(body, token, event.target);
        await showDetails(data._id);

    } catch (err) {
        alert(err.message);
        event.target.reset();
        console.error(err.message);
    }
}