document.querySelector('form').addEventListener('submit', processData);

async function processData(event) {
    event.preventDefault();

    let formData = new FormData(event.target);

    let name = formData.get('name');
    let img = formData.get('img');
    let ingredients = formData
        .get('ingredients')
        .split('\n')
        .map(x => x.trim())
        .filter(x => x != '');
    let steps = formData
        .get('steps')
        .split('\n')
        .map(x => x.trim())
        .filter(x => x != '');

    let token = sessionStorage.getItem('authToken');

    //if the session of the token hase expired should return to index.html
    if (token == null) {
        return window.location.pathname = 'index.html';
    }

    let response = await fetch('http://localhost:3030/data/recipes', {
        method: 'post',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': token
            },
        body: JSON.stringify({ name, img, ingredients, steps })
    });

    if (!response.ok) {
        let error = await response.json();
        return alert(error.message);
    }

    window.location.pathname = 'index.html';
}
