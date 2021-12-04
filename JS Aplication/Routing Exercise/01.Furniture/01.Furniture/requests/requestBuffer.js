import * as api from "./requester.js";

const host = 'http://localhost:3030'
api.setHost.host = host;

export const login = api.login;
export const register = api.register;

export async function getFurniture() {
    return await api.get(host + '/data/catalog');
}

export async function getMyFurniture() {
    const userId = sessionStorage.getItem('userId');
    return await api.get(host + `/data/catalog?where=_ownerId%3D%22${userId}%22`);
}

export async function getFurnitureById(id) {
    const response = await fetch(host + '/data/catalog/' + id);
    if (!response.ok) {
        let error = await response.json();
        throw new Error(error.message);
    }
    const data = await response.json();

    return data;
}

export async function create(body, token) {
    const response = await fetch(host + '/data/catalog', {
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
        throw new Error(error.message);
    }
    const data = await response.json();
    return data;
}

export async function deleteRequest(id, token) {

    const response = await fetch(host + '/data/catalog/' + id, {
        method: 'Delete',
        headers: { "X-Authorization": token }
    });

    if (!response.ok) {
        const error = await response.json();
        alert(error.message);
        throw new Error(error.message);
    }

    let data = await response.json();
    return data;
}

export async function editFurniture(body, token, id) {

    const response = await fetch(host + '/data/catalog/' + id, {
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
        throw new Error(error.message);
    }
    const data = await response.json();
    return data;
}

export async function logout(token) {

    const response = await fetch(host + '/users/logout', {
        method: 'get',
        headers: { "X-Authorization": token }
    });

    if (!response.ok) {
        const error = await response.json();
        alert(error.message);
        throw new Error(error.message);
    }
    sessionStorage.clear();
}