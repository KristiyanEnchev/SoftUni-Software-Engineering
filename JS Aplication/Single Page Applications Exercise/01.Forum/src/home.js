import { getPosts } from "./requests.js";
import { e } from "./dom.js";
import { showTopic } from "./topics.js";

let main;
let section;
let container;

export async function setUpHome(mainTarget, sectionTarget) {
    main = mainTarget;
    section = sectionTarget;
    container = section.querySelector('.topic-container');
}

export async function showHome() {
    main.querySelectorAll('section').forEach(section => section.remove());
    main.appendChild(section);
    const topics = await getPosts();
    const cards = [];
    Object.values(topics).forEach(topic => {
        cards.push(createTopicPreview(topic))
    });
    const fragment = document.createDocumentFragment();
    cards.forEach(card => fragment.appendChild(card));

    container.querySelectorAll('div').forEach(div => div.remove());
    container.appendChild(fragment);
}

export function createTopicPreview(topic) {
    const result =
        e('div', { className: 'topic-name-wrapper' },
            e('div', { className: 'topic-name' },
                e('a', { id: topic._id, className: 'normal', href: "#", onclick: showTopic },
                    e('h2', {}, `${topic.title}`)),
                e('div', { className: 'columns' },
                    e('div', {},
                        e('p', {}, 'Date: ',
                            e('time', { time: topic.dateTime }, `${topic.dateTime}`)),
                        e('div', { className: 'nick-name' },
                            e("p", {}, "Username: ",
                                e("span", { user: topic.user }, `${topic.user}`)))))));

    return result;
}