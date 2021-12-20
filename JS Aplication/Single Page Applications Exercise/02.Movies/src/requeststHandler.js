const url = 'http://localhost:3030'

export async function getMovies() {
    const response = await fetch(url + '/data/movies');
    if (!response.ok) {
        let error = await response.json();
        throw new Error(error.message);
    }
    const data = await response.json();

    return data;
}

export async function getLikesByMovieId(id) {
    const response = await fetch(url + '/data/likes/' + `?where=movieId%3D%22${id}%22&distinct=_ownerId&count`);
    if (!response.ok) {
        let error = await response.json();
        throw new Error(error.message);
    }
    const data = await response.json();

    return data;
}

export async function getOwnLikesByMovieId(id) {
    const userId = sessionStorage.getItem('userId');
    const response = await fetch(url + `/data/likes?where=movieId%3D%22${id}%22%20and%20_ownerId%3D%22${userId}%22`);
    if (!response.ok) {
        let error = await response.json();
        throw new Error(error.message);
    }
    const data = await response.json();

    return data;
}

export async function getMovieById(id) {
    const response = await fetch(url + '/data/movies/' + id);
    if (!response.ok) {
        let error = await response.json();
        throw new Error(error.message);
    }
    const data = await response.json();

    return data;
}

export async function handleRegisterRequest(body, eventTarget) {

    const response = await fetch(url + '/users/register', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body
    });

    if (!response.ok) {
        const error = await response.json();
        alert(error.message);
        eventTarget.reset();
        throw new Error(error.message);
    }
    const data = await response.json();
    return data;
}

export async function handleLoginRequest(body, eventTarget) {

    const response = await fetch(url + '/users/login', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body
    });

    if (!response.ok) {
        const error = await response.json();
        alert(error.message);
        eventTarget.reset();
        throw new Error(error.message);
    }
    const data = await response.json();
    return data;
}

export async function createMovieRequestHandler(body, token, eventTarget) {

    const response = await fetch(url + '/data/movies', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': token
        },
        body
    });

    if (!response.ok) {
        const error = await response.json();
        alert(error.message);
        eventTarget.reset();
        throw new Error(error.message);
    }
    const data = await response.json();
    eventTarget.reset();
    return data;
}

export async function likeMovieRequest(body, token) {

    const response = await fetch(url + '/data/likes', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': token
        },
        body
    });

    if (!response.ok) {
        const error = await response.json();
        alert(error.message);
        eventTarget.reset();
        throw new Error(error.message);
    }

    return response;
}

export async function deleteRequest(id, token) {

    const response = await fetch(url + '/data/movies/' + id, {
        method: 'Delete',
        headers: { "X-Authorization": token }
    });

    if (!response.ok) {
        const error = await response.json();
        alert(error.message);
        eventTarget.reset();
        throw new Error(error.message);
    }

    let data = await response.json();
    return data;
}

export async function editMovieRequestHandler(body, token, eventTarget, id) {

    const response = await fetch(url + '/data/movies/' + id, {
        method: 'put',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': token
        },
        body
    });

    if (!response.ok) {
        const error = await response.json();
        alert(error.message);
        eventTarget.reset();
        throw new Error(error.message);
    }
    const data = await response.json();
    eventTarget.reset();
    return data;
}