import { showDetails } from "./details.js";
import { e } from "./dom.js";
import { getMovies } from "./requeststHandler.js";

let main;
let section;
let container;

export function setupHome(mainTarget, sectionTarget) {
    main = mainTarget;
    section = sectionTarget;
    container = section.querySelector('.card-deck.d-flex.justify-content-center');

    container.addEventListener('click', (event) => {
        if (event.target.classList.contains('movieDetails')) {
            showDetails(event.target.id);
        };
    });
};

export async function showHome() {
    main.querySelectorAll('section').forEach(section => section.remove());
    main.appendChild(section);
    const movies = await getMovies();
    const cards = movies.map(createMoviesCardsPreview);
    const fragment = document.createDocumentFragment();
    cards.forEach(card => fragment.appendChild(card));

    container.querySelectorAll('div').forEach(div => div.remove());
    container.appendChild(fragment);
};

function createMoviesCardsPreview(movie) {
    let element =
        e('div', { className: "card mb-4" },
            e('img', { className: "card-img-top", src: `${movie.img}`, alt: "Card image cap", width: "400" }),
            e('div', { className: "card-body" },
                e('h4', { className: "card-title" }, `${movie.title}`)),
            e('div', { className: "card-footer" },
                e('button', { id: `${movie._id}`, type: "button", className: "btn btn-info movieDetails" }, "Details")
            ));

    return element;
};