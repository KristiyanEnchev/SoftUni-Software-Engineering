import { setupCatalog, showCatalogue } from './catalogue.js';
import { setupLogin, showLogin } from './login.js';
import { setupRegister, showRegister } from './register.js';
import { setupCreate, showCreate } from './create.js';

main();

function main() {

    navigationControl();

    const main = document.querySelector('main');
    const catalogueSection = document.getElementById('catalog');
    const loginSection = document.getElementById('login');
    const registerSection = document.getElementById('register');
    const createSection = document.getElementById('create');

    const links = {
        'catalogLink': showCatalogue,
        'loginLink': showLogin,
        'registerLink': showRegister,
        'createLink': showCreate
    };

    setupCatalog(main, catalogueSection);
    setupLogin(main, loginSection, () => { navigationControl(); showCatalogue(); });
    setupRegister(main, registerSection, () => { navigationControl(); showCatalogue(); });
    setupCreate(main, createSection, () =>  showCatalogue());

    setNavigation();
    showCatalogue();

    function setNavigation() {
        document.querySelector('nav').addEventListener('click', (event) => {
            if (event.target.tagName == 'a') {
                const view = links[event.target.id];
                if (typeof (view) == 'function') {
                    event.preventDefault();
                    view();
                }
            }
        });
    }

    function navigationControl() {
        if (sessionStorage.getItem("authToken") == null) {
            document.querySelector('#guest').style.display = 'inline-block';
            document.querySelector('#user').style.display = 'none';
        } else {
            document.querySelector('#user').style.display = 'inline-block';
            document.querySelector('#guest').style.display = 'none';
            document.getElementById('logoutBtn').addEventListener('click', logout);
        }
    }

    async function logout() {
        let response = await fetch('http://localhost:3030/users/logout', {
            method: 'POST',
            headers: {
                'X-Authorization': sessionStorage.getItem('authToken')
            },
        });

        if (response.status == 200) {
            sessionStorage.removeItem('authToken');
            window.location.pathname = 'index.html';
        } else {
            console.error(await response.json());
        }
    }
}

// window.addEventListener('load', async () => {

//     if (sessionStorage.getItem("authToken") == null) {
//         document.querySelector('#guest').style.display = 'inline-block';
//     } else {
//         document.querySelector('#user').style.display = 'inline-block';
//         document.getElementById('logoutBtn').addEventListener('click', logout);
//     }

//     const main = document.querySelector('main');

//     const recipes = await getRecipes();
//     const cards = recipes.map(createRecipePreview);

//     main.innerHTML = '';
//     cards.forEach(c => main.appendChild(c));
// });

