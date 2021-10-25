function attachEvents() {
    const url = 'http://localhost:3030/data/catches';
    const token = sessionStorage.getItem('authToken');
    //Чистим токена при logOut 
    document.getElementById('logged').addEventListener('click', sessionStorage.clear());
    // закача ме се за Load бутона
    document.getElementById('load').addEventListener('click', (event) => {
        event.preventDefault();
        getCatches(url, token);
    });
    //Логика за показване и сриване на бутоните по страницата в зависимист дали сме логнати или не 
    if (!token) {
        document.getElementById('guest').style.display = 'inline-block';
        document.getElementById('logged').style.display = 'none';
        document.querySelector("#addForm > button").disabled = true;
    } else {
        document.getElementById('guest').style.display = 'none';
        document.getElementById('logged').style.display = 'inline-block';
        document.querySelector("#addForm > button").disabled = false;
        // закача ме се за add бутона 
        document.querySelector("#addForm button").addEventListener('click', (e) => {
            e.preventDefault();
            const current = e.target.parentNode;
            postCatch(url, current, token);
        })
        // Закачаме се за всеки бутон в Catches и проверяваме ако сме на бутон и посел на кои бутон сме и правим логика за бутона
        document.querySelectorAll('#catches').forEach((btn) => btn.addEventListener('click', (e) => {
            e.preventDefault();
            if (e.target.nodeName == "BUTTON") {
                const current = e.target.parentNode;
                if (e.target.className === 'update') {
                    updateCatch(url, current, token);
                }
                if (e.target.className === 'delete') {
                    deleteCatch(url, current, token);
                }
            }
        }));
    }
}
attachEvents();

// Логика за load бутона
async function getCatches(url, tokenBtn) {
    let catches = document.getElementById('catches');
    //за намаляване на ненужни заявки при евентуален спам на бутона -- проверка дали има NodeList 
    // но трбват още корекции при този случай за update и delete
    // if (catches.querySelectorAll('div').length != 0) {
    //     return alert('Already displayed');
    // }
    const response = await fetch(url);
    const data = await response.json();
    // трием всичко преди да го направим на ново и изпишем за да не се дублира на всеки клик на бутона 
    // !!!!!! не ползваме innerHTML !!!!! :D :) 
    catches.querySelectorAll('div').forEach(div => div.remove());

    for (const key in data) {
        const token = data[key];
        const catchDiv = e('div', 'catch');
        catchDiv.id = token._id;
        const labelAngler = e('label', 'Angler');
        const inputAngler = e('input', 'text', 'angler', token.angler);
        const labelWeigth = e('label', 'Weight');
        const inputWeigth = e('input', 'text', 'weight', token.weight);
        const labelSpecies = e('label', 'Species');
        const inputSpecies = e('input', 'text', 'species', token.species);
        const labelLocation = e('label', 'Location');
        const inputLocation = e('input', 'text', 'location', token.location);
        const labelBait = e('label', 'Bait');
        const inputBait = e('input', 'text', 'bait', token.bait);
        const labelCaptureTime = e('label', 'Capture Time');
        const inputCaptureTime = e('input', 'text', 'captureTime', token.captureTime);
        const updateBtn = e('button', 'update', 'Update', tokenBtn);
        const deleteBtn = e('button', 'delete', 'Delete', tokenBtn);

        catchDiv.append(
            labelAngler, inputAngler, e('hr'),
            labelWeigth, inputWeigth, e('hr'),
            labelSpecies, inputSpecies, e('hr'),
            labelLocation, inputLocation, e('hr'),
            labelBait, inputBait, e('hr'),
            labelCaptureTime, inputCaptureTime, e('hr'),
            updateBtn, deleteBtn);
        catches.appendChild(catchDiv);
    }
}
// Логика за добавяне на улов
async function postCatch(url, current, token) {

    const angler = current.children[2].value;
    const weight = current.children[4].value;
    const species = current.children[6].value;
    const location = current.children[8].value;
    const bait = current.children[10].value;
    const captureTime = current.children[12].value;
    //проверяваме дали полетата са пълни за да не пращаме напразно заявки 
    checkIfAllInputsAreFiled(angler, weight, species, location, bait, captureTime);

    await post(url, { angler, weight, species, location, bait, captureTime });

    for (let i = 2; i <= 12; i += 2) {
        current.children[i].value = '';
    }

    async function post(url, data) {
        await fetch(url, {
            method: 'post',
            headers: { 'Content-type': 'application/json', 
            'X-Authorization': token },
            body: JSON.stringify(data),
        });
        getCatches(url, token);
    }
}

//Логика за update бутона 
async function updateCatch(url, current, token) {
    // селектираме по индекса и вземаме полето върху бланката ---- не е най инуативнуто решение но работи за случая 
    const angler = current.children[1].value;
    const weight = current.children[4].value;
    const species = current.children[7].value;
    const location = current.children[10].value;
    const bait = current.children[13].value;
    const captureTime = current.children[16].value;
    //проверяваме дали полетата са пълни за да не пращаме напразно заявки 
    checkIfAllInputsAreFiled(angler, weight, species, location, bait, captureTime);

    await update(url, current, { angler, weight, species, location, bait, captureTime });

    async function update(url, current, data) {
        const response = await fetch(url + current.id, {
            method: 'put',
            headers: { 'Content-type': 'application/json',
             'X-Authorization': token },
            body: JSON.stringify(data),
        });

        if (!response.ok) {
            const error = await response.json();
            return alert(error.message + '\n' + 'You are not authorized');
        }
        getCatches(url, token);
    }
}
//Логика за delete бутона -- simple, но трябва да проверим дали имаме права да извършим деиствието и ако не хвърлямв грешка
async function deleteCatch(url, current, token) {
    const response = await fetch(url + current.id, {
        method: 'delete',
        headers: { 'X-Authorization': token },
    });

    if (!response.ok) {
        const error = await response.json();
        return alert(error.message + '\n' + 'You are not authorized');
    }
    getCatches(url, token);
}
//Функция за справяне с елементите на DOM -а 
function e(type, attribute1, attribute2, attribute3) {
    const element = document.createElement(type);
    if (type == 'div') {
        element.className = attribute1;
    } if (type == 'label') {
        element.textContent = attribute1;
    } if (type == 'input') {
        element.type = attribute1;
        element.className = attribute2;
        element.setAttribute('value', attribute3);
    } if (type == 'button') {
        element.className = attribute1;
        element.textContent = attribute2;
        if (attribute3 == null) {
            element.disabled = true;
        }
    }
    return element;
}
// функция за проверка, че полетата са попълнени 
function checkIfAllInputsAreFiled(angler, weight, species, location, bait, captureTime) {
    if (angler == '' || weight == '' || species == '' || location == '' || bait == '' || captureTime == '') {
        if (angler == '') {
            alert('Write Angler');
        } else if (weight == '') {
            alert('Write Weight');
        } else if (species == '') {
            alert('Write Species');
        } else if (location == '') {
            alert('Write Location');
        } else if (bait == '') {
            alert('Write Bait');
        } else if (captureTime == '') {
            alert('Write Capture Time');
        } else {
            alert('Empty input');
        }
    }
}