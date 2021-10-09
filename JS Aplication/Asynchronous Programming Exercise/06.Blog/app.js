let viewPostsBtn = document.getElementById('btnViewPost');

function attachEvents() {

    let loadPostsBtn = document.getElementById('btnLoadPosts');

    loadPostsBtn.addEventListener('click', () => {
        getPostsData();
    });

    viewPostsBtn.addEventListener('click', () => {
        returnSelectedPostInfo();
    });

    viewPostsBtn.disabled = true;
}

attachEvents();

function e(type, attribute) {

    let element = document.createElement(type);

    if (attribute != {} && attribute != undefined) {

        Object.entries(attribute).forEach(([value, title]) => {
            element.textContent = title;
            element.setAttribute(`${value}`, `${title}`);
        });
    }

    return element;
}

async function getPostsData() {
    let postsSection = document.getElementById('posts');
    postsSection.innerHTML = '';

    let url = 'http://localhost:3030/jsonstore/blog/posts';
    let response = await fetch(url);
    let data = await response.json();
    Object.values(data).forEach(element => {

        let id = element.id;
        let title = element.title;
        let optionElement = e('option', { value: id, title: title });
        postsSection.appendChild(optionElement);
    });

    viewPostsBtn.disabled = false;
}

async function getComentsByPostId(postId) {

    let ulElement = document.getElementById('post-comments');
    ulElement.innerHTML = '';

    let resUrl = `http://localhost:3030/jsonstore/blog/posts/${postId}`;
    let url = 'http://localhost:3030/jsonstore/blog/comments';

    let [postresponse, response] = await Promise.all([
        fetch(resUrl),
        fetch(url)
    ]);

    let postData = await postresponse.json();
    document.getElementById('post-title').textContent = postData.title;
    document.getElementById('post-body').textContent = postData.body;

    let data = await response.json();
    let comentsArr = Object.values(data).filter(coment => coment.postId == postId);

    comentsArr.forEach(coment => {

        let comment = coment.text;
        let liElement = e('li', { value: postId, title: comment });
        ulElement.appendChild(liElement);
    });
}

function returnSelectedPostInfo() {
    let postId = document.getElementById('posts').value;
    getComentsByPostId(postId);
}