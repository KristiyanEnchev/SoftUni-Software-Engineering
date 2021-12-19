import { showHome } from "./home.js";
import { userNavigationStateChecker } from "./app.js";
import { handleLoginRequest } from "./requeststHandler.js";
import { setupSession } from "./register.js";

let main;
let section;

export function setupLogin(mainTarget, sectionTarget) {
    main = mainTarget;
    section = sectionTarget;
    const form = sectionTarget.querySelector('form').addEventListener('submit', processData);
};

export function showLogin() {
    main.querySelectorAll('section').forEach(section => section.remove());
    main.appendChild(section);
};

async function processData(event) {
    event.preventDefault();
    let formData = new FormData(event.target);
    let email = formData.get('email');
    let password = formData.get('password');

    if (email == '' || password == '') {
        return alert("All fields must be filed up");
    };

    const body = JSON.stringify({
        email: email,
        password: password,
    });

    try {
        const data = await handleLoginRequest(body, event.target)
        setupSession(data);
        userNavigationStateChecker();
        event.target.reset();
        showHome();
    }
    catch (error) {
        console.error(error.message);
    }
};