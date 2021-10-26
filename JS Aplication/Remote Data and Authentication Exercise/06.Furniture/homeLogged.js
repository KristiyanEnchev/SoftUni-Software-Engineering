function checkUser() {
    const token = sessionStorage.getItem('authToken');

    if (!token) {
        window.location.href = window.location.pathname = 'login.html';
        return alert('Forbidden action! Please log in!');
    }
}

function attachEvents() {
    document.getElementById('logoutBtn').addEventListener('click', onLogout);
    document.querySelector('form').addEventListener('submit', onCreate);
    document.getElementById('buyBtn').addEventListener('click', onBuy);
    document.getElementById('ordersBtn').addEventListener('click', onAllOrders);
}

async function createTabel() {
    const tbody = document.querySelector('tbody');
    tbody.querySelectorAll('tr').forEach(tr => tr.remove());

    try {
        const data = await request('http://localhost:3030/data/furniture');

        data.forEach(el => {
            const hiddenInput = createHtmlElement('input', undefined, {
                'data-ownerId': el._ownerId,
                type: 'hidden',
                disabled: true
            });

            const elImg = createHtmlElement('img', undefined, {
                src: el.img
            });
            const imgTd = createHtmlElement('td', undefined, undefined, [elImg]);

            const nameP = createHtmlElement('p', el.name);
            const nameTd = createHtmlElement('td', undefined, undefined, [nameP]);

            const priceP = createHtmlElement('p', el.price);
            const priceTd = createHtmlElement('td', undefined, undefined, [priceP]);

            const factorP = createHtmlElement('p', el.factor);
            const factorTd = createHtmlElement('td', undefined, undefined, [factorP]);

            const input = createHtmlElement('input', undefined, {
                type: 'checkbox'
            });
            const inputTd = createHtmlElement('td', undefined, undefined, [input]);

            const tr = createHtmlElement('tr', undefined, {
                'data-id': el._id
            }, [hiddenInput, imgTd, nameTd, priceTd, factorTd, inputTd]);
            tbody.appendChild(tr);
        });
    } catch (error) {
        return alert(error.message);
    }
}

attachEvents();
checkUser();
createTabel();

async function onBuy() {
    const rows = [...document.querySelectorAll('tbody tr')];
    const token = sessionStorage.getItem('authToken');

    await Promise.all(rows.map(async (e) => {
        const input = e.querySelector('td input');
        if (input.checked) {
            const img = e.querySelector('img');
            const [itemName, price, factor] = e.querySelectorAll('p');
            const hiddenInput = e.querySelector('input[type=hidden]');
            const ownerId = hiddenInput.dataset.ownerid;
            const itemId = e.dataset.id;

            const data = await request('http://localhost:3030/data/orders', {
                method: 'post',
                headers: {
                    'Content-Type': 'aplication/json',
                    'X-Authorization': token
                },
                body: JSON.stringify({
                    img: img.src,
                    name: itemName.textContent,
                    price: price.textContent,
                    factor: factor.textContent,
                    ownerId,
                    itemId
                })
            });
        }
        input.checked = false;
    }));
    alert('You bought some product!');
}

async function onAllOrders(event) {
    const id = sessionStorage.getItem('userId');
    if (id == null) {
        alert('Your session hase expired, Plese login');
    }

    const names = [];
    let totalPrice = 0;

    const data = await request('http://localhost:3030/data/orders');
    data.filter(d => d._ownerId == id).map(d => {
        names.push(d.name);
        totalPrice += Number(d.price);
    });

    const furnitureSpan = createHtmlElement('span', names.join(', '));
    const furnitureP = createHtmlElement('p', 'Bought furniture: ', undefined, [furnitureSpan]);
    const totalPriceSpan = createHtmlElement('span', totalPrice + ' $');
    const totalPriceP = createHtmlElement('p', 'Total price: ', undefined, [totalPriceSpan]);

    const length = event.target.parentNode.children.length;
    [...event.target.parentNode.children].slice(0, length - 1).forEach(element => {
        element.remove();
    });

    event.target.parentNode.prepend(furnitureP, totalPriceP);
}

async function request(url, options) {
    const response = await fetch(url, options);

    if (response.ok == false) {
        const error = await response.json();
        throw new Error(error.message);
    }

    const data = await response.json();

    return data;
}

async function onCreate(event) {
    event.preventDefault();

    const formData = new FormData(event.target);
    const name = formData.get('name');
    const price = formData.get('price');
    const factor = formData.get('factor');
    const img = formData.get('img');

    if (!name || !price || !factor || !img) {
        return alert('All fields are required!');
    }

    checkUser();
    const token = sessionStorage.getItem('authToken');

    try {
        const data = await request('http://localhost:3030/data/furniture', {
            method: 'post',
            headers: {
                'Content-Type': 'aplication/json',
                'X-Authorization': token
            },
            body: JSON.stringify({
                name,
                price,
                factor,
                img
            })
        });
    } catch (error) {
        alert(error.message);
    }
    createTabel();
    event.target.reset();
}

async function onLogout() {
    const token = sessionStorage.getItem('authToken');
    checkUser();

    await fetch('http://localhost:3030/users/logout', {
        method: 'get',
        headers: {
            'X-Authorization': token
        }
    });

    sessionStorage.clear();
    window.location.href = window.location.pathname = 'home.html';
}

function createHtmlElement(type, content, attributes, elementsToAppend) {
    const el = document.createElement(type);

    if (content) {
        el.textContent = content;
    }

    if (attributes) {
        Object.entries(attributes).map(([key, value]) => {
            el.setAttribute(key, value);
        });
    }

    if (elementsToAppend) {
        elementsToAppend.forEach(appendElement => {
            el.appendChild(appendElement);
        });
    }

    return el;
}