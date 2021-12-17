const url = 'http://localhost:3030/jsonstore/collections/myboard/posts';

export async function getPosts() {

    const response = await fetch(url);
    if (!response.ok) {
        let error = await response.json();
        throw new Error(error.message);
    };

    const data = await response.json();
    return data;
};

export async function getPostById(id) {
    const response = await fetch("http://localhost:3030/jsonstore/collections/myboard/posts/" + id);
    if (!response.ok) {
        let error = await response.json();
        throw new Error(error.message);
    };

    const data = await response.json();
    return data;
}

export async function createTopicRequest(body) {

    let response = await fetch(url, {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body
    });

    if (!response.ok) {
        let error = await response.json();
        throw new Error(error.message);
    }

    let topic = await response.json();

    return topic;
}

export async function createComentRequest(body) {

    let response = await fetch('http://localhost:3030/jsonstore/collections/myboard/comments', {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body
    });

    if (!response.ok) {
        let error = await response.json();
        throw new Error(error.message);
    }

    let topic = await response.json();

    return topic;
}

export async function getComentsByPostId(id) {
    const response = await fetch(`http://localhost:3030/jsonstore/collections/myboard/comments?where=postId%3D${id}`);
    if (!response.ok) {
        let error = await response.json();
        throw new Error(error.message);
    };

    const data = await response.json();
    return data;
}