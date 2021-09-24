import { setupHome } from "./home.js";
import { setupRegister } from "./register.js";
import { setupLogin } from "./login.js";
import { setupDashboard } from "./dashboard.js";
import { setupCreate } from "./create.js";
import { logout, settings } from "./api.js";
import { setupDetails } from "./details.js";

const main = document.querySelector('main');
const navigation = document.querySelector('#navigation');

const views = {};
const links = {};

const navigationLinks = {
    goTo,
    setNavigation,
}

async function goTo(name, ...params) {
    main.innerHTML = '';

    const view = views[name];
    const section = await view(...params);
    main.appendChild(section);
}

function registerView(name, section, setup, linkId) {
    views[name] = setup(section, navigationLinks);

    if (linkId) {
        links[linkId] = name;
    }
}

function setNavigation() {
    if (sessionStorage.getItem('token')) {
        navigation.querySelector('#logoutLink').style.display = 'inline-block';
        navigation.querySelector('#createLink').style.display = 'inline-block';
        navigation.querySelector('#loginLink').style.display = 'none';
        navigation.querySelector('#registerLink').style.display = 'none';
    } else {
        navigation.querySelector('#logoutLink').style.display = 'none';
        navigation.querySelector('#createLink').style.display = 'none';
        navigation.querySelector('#loginLink').style.display = 'inline-block';
        navigation.querySelector('#registerLink').style.display = 'inline-block';
    }
}

registerView('home', document.getElementById('home'), setupHome, 'homeLink');
registerView('register', document.getElementById('register'), setupRegister, 'registerLink');
registerView('login', document.getElementById('login'), setupLogin, 'loginLink');
registerView('dashboard', document.getElementById('dashboard-holder'), setupDashboard, 'dashboardLink');
registerView('create', document.getElementById('create'), setupCreate, 'createLink');
registerView('details', document.getElementById('details'), setupDetails);


navigation.addEventListener('click', async (ev) => {
    ev.preventDefault();

    const name = links[ev.target.id];
    if (name) {
        goTo(name);
    }

});

document.querySelector('#logoutLink').addEventListener('click', async (ev) => {
    ev.preventDefault();
    
    settings.host = 'http://localhost:3030';
    await logout();
    setNavigation();
    goTo('home');
});

setNavigation();
goTo('home');