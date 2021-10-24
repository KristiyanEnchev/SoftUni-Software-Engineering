let firstName1 = document.querySelector('input[name=firstName]');
let lastName1 = document.querySelector('input[name=lastName]');
let facNum = document.querySelector('input[name=facultyNumber]');
let grade1 = document.querySelector('input[name=grade]');
let body = document.querySelector("#results > tbody");

async function getinIcialData() {

    const url = 'http://localhost:3030/jsonstore/collections/students';
    let response = await fetch(url);
    let data = await response.json();

    if (response.ok) {
        Object.values(data).forEach(line => {
            body.appendChild(createElemnt(line.firstName, line.lastName, line.facultyNumber, line.grade));
        });
    };
};

getinIcialData();

let form = document.getElementById('form');
form.addEventListener('submit', processData);
async function processData(event) {
    event.preventDefault();
    // let infoParagraph1 = document.getElementById('info').textContent = '';
    //проверяваме дали полетата в формата са попълнени за да не пращаме празни заявки -- нее упоменато какво става ако едно поле нее попълнено
    if (firstName1.value == '' || lastName1.value == '' ||
        facNum.value == '' || grade1.value == '') {
        alert('All fields must be filed up');
        return
    }
    // по условие проверяваме дали оценката е Numbeр
    // по условие проверяваме дали факултетният номер е от числа или не 
    if (isNaN(grade1.value)) {
        return alert("Grade must be a number");

    } else if (isNaN(Number(facNum.value))) {
        return alert('Faculty Number should be digits only');
    }

    let student = {
        firstName: firstName1.value,
        lastName: lastName1.value,
        facultyNumber: facNum.value,
        grade: Number(grade1.value)
    };

    let url = 'http://localhost:3030/jsonstore/collections/students';
    let response = await fetch(url, {
        method: 'post',
        headers: { 'Content-type': 'aplication/json' },
        body: JSON.stringify(student)
    });

    if (!response.ok) {
        let error = await response.json();
        return alert(error.message);
    }
    let data = await response.json();

    //за тази задача е ок, но в реално приложение ще се наложи да се проверява в базата за сходно ентри преди да се 
    // направи пост заявка и да се изманипулира в ДОМ -а 
    body.appendChild(createElemnt(data.firstName, data.lastName, data.facultyNumber, data.grade));
    // let infoParagraph = document.getElementById('info').textContent = 'Student have been Submited';
    form.reset();
}

//Създаваме си таблизата
function createElemnt(first, last, fac, grade) {
    let tr = document.createElement('tr', id = 'trItem');
    let thFirst = document.createElement('th');
    let thLast = document.createElement('th');
    let thFac = document.createElement('th');
    let thGrade = document.createElement('th');

    thFirst.textContent = first;
    thLast.textContent = last;
    thFac.textContent = fac;
    thGrade.textContent = grade;
    tr.appendChild(thFirst);
    tr.appendChild(thLast);
    tr.appendChild(thFac);
    tr.appendChild(thGrade);

    return tr;
}