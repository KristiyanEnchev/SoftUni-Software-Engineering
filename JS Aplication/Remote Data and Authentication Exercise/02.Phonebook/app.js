async function attachEvents() {

    const url = 'http://localhost:3030/jsonstore/phonebook';
    let loadBtn = document.getElementById('btnLoad');
    let ulElement = document.getElementById('phonebook');

    loadBtn.addEventListener('click', loadBook);

    async function loadBook(event) {
        let response = await fetch(url);
        let data = await response.json();

        Object.values(data).forEach(phone => {
            let li = createPhoneRecord(phone);
            const deleteBtn = document.createElement('button');
            deleteBtn.textContent = 'Delete';
            deleteBtn.addEventListener('click', deleteEntrie);
            li.appendChild(deleteBtn);
            ulElement.appendChild(li);
        });

    }

    async function deleteEntrie(event) {

        let id = event.target.parentElement.id;
        let url = `http://localhost:3030/jsonstore/phonebook/${id}`;

        let response = await fetch(url, {
            method: 'delete'
        });

        event.target.parentElement.remove();
    }

    let person = document.getElementById('person');
    let phone = document.getElementById('phone');
    let createBtn = document.getElementById('btnCreate');

    createBtn.addEventListener('click', submitData);
    async function submitData(e) {

        if (person.value == '' || phone.value == '') {
            return
        }

        let response = await fetch(url, {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ person: person.value, phone: phone.value })
        });

        if (!response.ok) {
            let error = await response.json();
            return alert(error.message);
        }

        person.value = '';
        phone.value = '';
    };
}

function createPhoneRecord(phone) {
    const res = document.createElement('li');
    res.textContent = `${phone.person}: ${phone.phone}`;
    res.id = phone._id;
    return res
}

attachEvents();