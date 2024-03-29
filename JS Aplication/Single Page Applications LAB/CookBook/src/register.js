async function processData(event) {
    event.preventDefault();

    let formData = new FormData(event.currentTarget);

    let email = formData.get('email');
    let password = formData.get('password');
    let rePass = formData.get('rePass');

    if (email == '' || password == '') {
        form.reset();
        return alert('Email and Password must be filed up');
    } else if (rePass != password) {
        form.reset();
        return alert('Password doesn\'t match');
    }

    let url = 'http://localhost:3030';

    const response = await fetch(`${url}/users/register`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ email, password })
    });

    if (!response.ok) {
        let error = await response.json();
        return alert(error.message);
    }

    let data = await response.json();
    sessionStorage.setItem('userToken', data.accessToken);

    onSeccess();
}

let main;
let section;
let onSeccess;

export function setupRegister(targetMain, targetSection, onSeccessTarget) {
    main = targetMain;
    section = targetSection;
    onSeccess = onSeccessTarget;

    section.querySelector('form').addEventListener('submit', processData);
}

export async function showRegister() {
    main.innerHTML = '';
    main.appendChild(section);
}