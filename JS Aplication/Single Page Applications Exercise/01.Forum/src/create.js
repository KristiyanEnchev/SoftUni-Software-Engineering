import { newTopicFildsCheck, comentFieldCheck } from "./fieldCheker.js";
import { showHome } from "./home.js";
import { createComent } from "./topics.js";
import { createTopicRequest, createComentRequest } from "./requests.js";

export async function createTopic(event) {
    event.preventDefault();
    let formData = new FormData(event.target);

    let title = formData.get('topicName');
    let user = formData.get('username');
    let text = formData.get('postText');

    let today = new Date();
    let date = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();
    let time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
    let dateTime = date + ' ' + time;

    if (document.activeElement.textContent == 'Post') {

        if (newTopicFildsCheck(title, user, text) == false) {
            // event.target.reset();
            return;
        };

        let body = JSON.stringify(
            { title: title, user: user, text: text, dateTime: dateTime }
        );

        let topic = await createTopicRequest(body);
        alert('Post succesfully posted');
        showHome();
        event.target.reset();

    } else if (document.activeElement.textContent == 'Cancel') {
        event.target.reset();
        return alert('Post canceled');
    }
};

export async function createComment(event) {
    event.preventDefault();
    let formData = new FormData(event.target)
    let id = sessionStorage.getItem('topicId');
    
    let today = new Date();
    let date = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();
    let time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
    let dateTime = date + ' ' + time;

    if (comentFieldCheck(formData.get('postText'), formData.get('username')) == false) {
        return;
    }
    let body = JSON.stringify({
        coment: formData.get('postText'),
        username: formData.get('username'),
        dateTime: dateTime,
        topicId: id
    })

    let theComent = await createComentRequest(body);
    let coment = document.querySelector('.header');
    coment.appendChild(createComent(theComent));

    alert('Comment succesfully posted');
    event.target.reset();
}