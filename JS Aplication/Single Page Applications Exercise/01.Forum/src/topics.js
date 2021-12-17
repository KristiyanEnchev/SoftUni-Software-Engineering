import { getComentsByPostId, getPostById } from "./requests.js";
import { e } from "./dom.js";
import { createComment } from "./create.js";

let id;
let main;
let section;

export async function setUpTopics(mainTarget, sectionTarget) {
    main = mainTarget;
    section = sectionTarget;

    const form = sectionTarget.querySelector('form').addEventListener('submit', createComment);
}

export async function showTopic(event) {
    main.querySelectorAll('section').forEach(section => section.remove());
    main.appendChild(section);
    id = event.target.parentElement.id;

    const [topic, comments] = await Promise.all([
        getPostById(id),
        getComentsByPostId(id)
    ]);
    sessionStorage.setItem('topicId', id);
    let titleField = section.querySelector('#title');
    let span = section.querySelector('#userName-span');
    let coment = section.querySelector('.comment');
    titleField.textContent = topic.title;
    span.textContent = topic.user;
    coment.querySelectorAll('div').forEach(div => div.remove());
    coment.appendChild(createTopicSection(topic, comments));
}

export function createTopicSection(topic, comments) {
    let element =

        e('div', { className: 'header' },
            e('img', { src: "./static/profile.png", alt: 'avatar' }),
            e('p', {}, e('span', {}, `${topic.user}`), ' post on ', e('time', {}, `${topic.dateTime}`)),
            e('p', { className: 'post-content' }, `${topic.text}`));

    if (comments != null) {

        Object.values(comments).forEach(coment => {
            let app = createComent(coment);
            element.appendChild(app);
        });
    }

    return element;
}

export function createComent(coment) {
    let app =
        e('div', { id: 'user-comment' },
            e('div', { className: 'topic-name-wrapper' },
                e('div', { className: 'topic-name' },
                    e('p', {}, e('strong', {}, `${coment.username}`), ' post on ',
                        e('time', {}, `${coment.dateTime}`)),
                    e('div', { className: 'post-content' }, e('p', {}, `${coment.coment}`)))));
    return app;
}

// export function createComent(comments) {
//     // let app = e('div', { id: 'user-comment' });
//     // console.log(comments);
//     if (comments != null) {

//         Object.values(comments).forEach(coment => {
//             let app =
//                 e('div', { id: 'user-comment' },
//                     e('div', { className: 'topic-name-wrapper' },
//                         e('div', { className: 'topic-name' },
//                             e('p', {}, e('strong', {}, `${coment.username}`), ' post on ',
//                                 e('time', {}, `${coment.dateTime}`)),
//                             e('div', { className: 'post-content' }, e('p', {}, `${coment.coment}`))));
//             app.appendChild(some);
//         });
//     }

//     return app;
// }