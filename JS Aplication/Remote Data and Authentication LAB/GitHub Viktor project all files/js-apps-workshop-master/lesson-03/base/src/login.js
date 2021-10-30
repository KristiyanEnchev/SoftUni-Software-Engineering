document.querySelector('form').addEventListener('submit', processData);

async function processData(event) {
    event.preventDefault();

    let formData = new FormData(event.currentTarget);

    let email = formData.get('email');
    let password = formData.get('password');

    if (email == '' || password == '') {
        let form = document.querySelector('form');
        form.reset();
        return alert('Both username or password need to be filed');
    }

    try {
        let url = 'http://localhost:3030';
        const response = await fetch(url + '/users/login', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ email, password })
        });
        
        let data = await response.json();
        
        if (!response.ok) {
            let error = await response.json();
            return alert(error.message);
        } else {
            sessionStorage.setItem('authToken', data.accessToken);
            window.location.pathname = 'index.html';
        }
    } catch (error) {
        let form = document.querySelector('form');
        form.reset();
        return alert('User don\'t exist');
    }
}