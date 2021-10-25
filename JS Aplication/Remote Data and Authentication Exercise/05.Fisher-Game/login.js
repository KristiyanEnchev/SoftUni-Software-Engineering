//Логика в зависомост дали имаме налична сесия да излиза само register или login , но в последствие има конфликт с логиката ми в app
// след logOut трия tokena но вече имам регистрация но нямам налична сесия 
// window.addEventListener('load', () => {

//     if (sessionStorage.getItem("authToken") == null) {
//         document.getElementById('registerForm').style.display = 'inline-block';
//     } else {
//         document.getElementById('loginForm').style.display = 'inline-block';
//     }
// });

function atachEvents() {
    let loginForm = document.getElementById('loginForm');
    let registerForm = document.getElementById('registerForm');
    loginForm.addEventListener('submit', handleLogin);
    registerForm.addEventListener('submit', handleRegister);
}
atachEvents();

async function handleRegister(event) {
    event.preventDefault();
    const formData = new FormData(event.target);

    let data = {
        email: formData.get('email'),
        password: formData.get('password'),
        rePass: formData.get('rePass')
    }
    onRegister(data);
}

async function onRegister(data) {

    if (data.email == '' || data.password == '' || data.rePass == '') {
        registerForm.reset();
        return alert('All fields must be filed up');
    }
    if (data.password != data.rePass) {
        registerForm.reset();
        return alert('Passwords don\'t match');
    }

    const body = {
        email: data.email,
        password: data.password,
    };

    try {

        const response = await fetch('http://localhost:3030/users/register', {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(body)
        });

        if (!response.ok) {
            const error = await response.json();
            registerForm.reset();
            return alert(error.message)
        }

        const data = await response.json();
        sessionStorage.setItem('authToken', data.accessToken);
        window.location.href = window.location.pathname = 'index.html';
        // window.location.pathname = 'index.html';

    } catch (err) {
        console.error(err.message);
    }
}

async function handleLogin(event) {
    event.preventDefault();
    const formData = new FormData(event.target);

    let data = {
        email: formData.get('email'),
        password: formData.get('password'),
    }
    onLogin(data);
}

async function onLogin(data) {
    if (data.email == '' || data.password == '') {
        loginForm.reset();
        return alert('Email and password must be filed up');
    }

    const body = {
        email: data.email,
        password: data.password,
    };

    try {
        const response = await fetch('http://localhost:3030/users/login', {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(body)
        });

        if (!response.ok) {
            const error = await response.json();
            loginForm.reset();
            return alert(error.message)
        }

        const data = await response.json();
        sessionStorage.setItem('authToken', data.accessToken);
        window.location.href = window.location.pathname = 'index.html';
        // window.location.pathname = 'index.html';

    } catch (err) {
        console.error(err.message);
    }
}