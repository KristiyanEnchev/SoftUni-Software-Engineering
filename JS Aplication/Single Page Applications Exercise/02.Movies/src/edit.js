import { editMovieRequestHandler, getMovieById } from "./requeststHandler.js";
import { showDetails } from "./details.js";

let main;
let section;
let id;

let title;
let description;
let url;

export function setupEdit(mainTarget, sectionTarget) {
    main = mainTarget;
    section = sectionTarget;
    const form = sectionTarget.querySelector('form').addEventListener('submit', processData);
}

export async function showEdit(event) {
    id = event.target.parentElement.parentElement.parentElement.id
    let movie = await getMovieById(id);
    let titleField = section.querySelector('form #title');
    let descriptionField = section.querySelector('form #text');
    let image = section.querySelector('form #image');

    titleField.value = (title = movie.title);
    descriptionField.value = (description = movie.description);
    image.value = (url = movie.img);

    main.querySelectorAll('section').forEach(section => section.remove());
    main.appendChild(section);
}

async function processData(event) {
    event.preventDefault();
    const formData = new FormData(event.target);

    let editTitle = formData.get('title');
    let editDescription = formData.get('description').split('\n').map(l => l.trim()).filter(l => l != '');
    let editUrlImg = formData.get('imageUrl');

    if (title == editTitle && editDescription[0] == description[0] && editUrlImg == url) {
        return alert("No edit hase been made");
    }

    const token = sessionStorage.getItem('authToken');
    if (token == null) {
        return alert('You\'re not logged in!');
    }
    const body = JSON.stringify({
        title: editTitle,
        description: editDescription,
        img: editUrlImg
    });

    try {
        let data = await editMovieRequestHandler(body, token, event.target, id);
        await showDetails(id);

    } catch (err) {
        alert(err.message);
        event.target.reset();
        console.error(err.message);
    }
}