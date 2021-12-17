import { setupHome, showHome } from "./home.js";
import { setupDetails, showDetails } from "./details.js";
import { setupLogin, showLogin } from "./login.js";
import { setupRegister, showRegister } from "./register.js";
import { setupCreate, showCreate } from "./create.js";
import { setupEdit, showEdit } from "./edit.js";

const main = document.querySelector('main');

const paths = {
    'home': showHome,
    'login': showLogin,
    'register': showRegister,
    'createMovieBtn': showCreate
}

setupSection('home-page', setupHome);
setupSection('edit-movie', setupEdit);
setupSection('add-movie', setupCreate);
setupSection('movie-example', setupDetails);
setupSection('form-login', setupLogin);
setupSection('form-sign-up', setupRegister);

setupNavigation();
showHome();

function setupSection(sectionId, setup) {
    const section = document.getElementById(sectionId);
    setup(main, section);
}

function setupNavigation() {

    userNavigationStateChecker();

    document.querySelector('nav').addEventListener('click', (event) => {
        if (event.target.tagName == 'A') {
            const view = paths[event.target.id];
            if (typeof (view) == 'function') {
                event.preventDefault();
                view();
            }
        }
    });
    document.getElementById('createMovieBtn').addEventListener('click', (event) => {
        event.preventDefault();
        showCreate();
    });

    document.getElementById('logOut').addEventListener('click', logOunt);
    function logOunt() {
        sessionStorage.clear();
        userNavigationStateChecker();
        showHome();
    }
}

export function userNavigationStateChecker() {
    let email = sessionStorage.getItem('email');
    if (email != null) {
        document.getElementById('welcome-msg').textContent = `Welcome, ${email}`;
        [...document.querySelectorAll('nav .user')].forEach(line => line.style.display = 'block');
        [...document.querySelectorAll('nav .guest')].forEach(line => line.style.display = 'none');
    } else {
        [...document.querySelectorAll('nav .user')].forEach(line => line.style.display = 'none');
        [...document.querySelectorAll('nav .guest')].forEach(line => line.style.display = 'block');
    }
}