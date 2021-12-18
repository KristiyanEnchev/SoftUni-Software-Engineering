import { e } from "./dom.js";
import { showEdit } from "./edit.js";
import { showHome } from "./home.js";
import { getLikesByMovieId, getMovieById, getOwnLikesByMovieId, likeMovieRequest, deleteRequest } from "./requeststHandler.js";

function createMovieCard(movie, likes, ownLike) {
    let element =
        e('div', { className: "container", id: movie._id },
            e('div', { className: "row bg-light text-dark" },
                e('h1', {}, `Movie title: ${movie.title}`),
                e('div', { className: "col-md-8" },
                    e('img', { className: "img-thumbnail", src: `${movie.img}`, alt: "Movie" })),
                e('div', { className: "col-md-4 text-center" },
                    e('h3', { className: "my-3" }, `Movie Description`),
                    e('p', {}, `${movie.description}`),
                )
            )
        );

    let app = element.querySelector('.col-md-4.text-center');
    let userId = sessionStorage.getItem('userId');
    let token = sessionStorage.getItem("authToken");

    if (userId != null) {
        if (userId == movie._ownerId) {
            app.appendChild(e('a', { className: "btn btn-danger", href: "#", onClick: deleteMovie }, "Delete"));
            app.appendChild(e('a', { className: "btn btn-warning", href: "#", onClick: showEdit }, "Edit"));
        } else if (ownLike.length == 0) {
            app.appendChild(e('a', { className: "btn btn-primary", href: "#", onClick: likeMovie }, "Like"));
        }
    }
    const likesSpan = e('span', { className: "enrolled-span" }, likes + '  like' + (likes == 1 ? '' : 's'));
    app.appendChild(likesSpan);

    async function likeMovie(event) {
        let body = JSON.stringify({ movieId: movie._id });
        let res = await likeMovieRequest(body, token);
        event.target.remove();
        likes++;
        likesSpan.textContent = likes + '  like' + (likes == 1 ? '' : 's');
    }

    async function deleteMovie(event) {
        let res = await deleteRequest(movie._id, token);
        event.target.parentElement.parentElement.parentElement.remove();
        showHome();
    }

    return element;
}

let main;
let section;

export function setupDetails(mainTarget, sectionTarget) {
    main = mainTarget;
    section = sectionTarget;
}

export async function showDetails(id) {
    section.querySelectorAll('div').forEach(div => div.remove());
    main.querySelectorAll('section').forEach(section => section.remove());
    main.appendChild(section);

    const [movie, likes, ownLike] = await Promise.all([
        getMovieById(id),
        getLikesByMovieId(id),
        getOwnLikesByMovieId(id)
    ]);
    const card = createMovieCard(movie, likes, ownLike);
    section.appendChild(card);
}