import { showHome } from "./home.js";
import { userNavigationStateChecker } from "./app.js";
import { handleRegisterRequest } from "./requeststHandler.js";

let main;
let section;

export function setupRegister(mainTarget, sectionTarget) {
    main = mainTarget;
    section = sectionTarget;
    const form = sectionTarget.querySelector('form').addEventListener('submit', processData);
}

export function showRegister() {
    main.querySelectorAll('section').forEach(section => section.remove());
    main.appendChild(section);
}

async function processData(event) {
    event.preventDefault();
    let formData = new FormData(event.target);
    let email = formData.get('email');
    let password = formData.get('password');
    let rePass = formData.get('password');

    if (email == '' || password == '' || rePass == '') {
        event.target.reset();
        return alert("All fields must be filed up");
    } else if (password != rePass) {
        event.target.reset();
        return alert("Password doesn\'t match");
    }

    const body = JSON.stringify({
        email: email,
        password: password,
        repeatPassword: rePass
    });

    try {
        const data = await handleRegisterRequest(body, event.target)
        setupSession(data);
        userNavigationStateChecker();
        event.target.reset();
        showHome();
    }
    catch (error) {
        console.error(error.message);
    }
}

export function setupSession(data) {
    sessionStorage.setItem('authToken', data.accessToken);
    sessionStorage.setItem('userId', data._id);
    sessionStorage.setItem('email', data.email);
}