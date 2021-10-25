let url = 'http://localhost:3030/jsonstore/collections/books';

const loadBtn = document.getElementById('loadBooks');
loadBtn.addEventListener('click', loadAllBooks);

let booksTableBody = document.querySelector('#books-table tbody');
booksTableBody.querySelectorAll('tr').forEach(tr => tr.remove());

let form = document.getElementById('form');
form.addEventListener('submit', submitData);

let editForm = document.getElementById('editForm');
let id;

async function handleRequests(url, options) {
    let response = await fetch(url, options);
    if (!response.ok) {
        const error = await response.json();
        alert(error.message);
        throw new Error(error.message);
    }
    let data = await response.json();
    return data;
}

async function loadAllBooks(event) {
    let books = await handleRequests(url);
    booksTableBody.querySelectorAll('tr').forEach(tr => tr.remove());
    if (editForm.style.display == 'block') {
        editForm.reset();
        form.style.display = 'block';
        editForm.style.display = 'none';
    }
    createBooksInDom(books);
}

async function editBook(event) {
    form.style.display = 'none';
    editForm.style.display = 'block';
    id = event.target.parentElement.dataset.id;
    let author = event.target.parentElement.dataset.author;
    let title = event.target.parentElement.dataset.title;
    editForm.querySelector('#title-Field').value = title;
    editForm.querySelector('#author-Field').value = author;
    editForm.addEventListener('submit', newBookUpdate);
}

function newBookUpdate(event) {
    event.preventDefault();
    let bookToEdit = booksTableBody.querySelector(`[data-id="${id}"]`);
    let title = bookToEdit.dataset.title;
    let author = bookToEdit.dataset.author;
    let formData = new FormData(event.target);

    if (formData.get('author') == author && formData.get('title') == title) {
        alert('No updata has been made');
        editForm.reset();
        return;
    }
    if (formData.get('author') == '' || formData.get('title') == '') {
        editForm.querySelector('#title-Field').value = title;
        editForm.querySelector('#author-Field').value = author;
        alert('No Edit has been made');
        return;
    }

    let book = {
        author: formData.get('author'),
        title: formData.get('title')
    }

    updateBook(id, book);
    form.style.display = 'block';
    editForm.style.display = 'none';
}

async function updateBook(id, book) {
    let response = await handleRequests(url + '/' + id, {
        method: 'put',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(book)
    });

    loadAllBooks();
}

async function submitData(event) {
    event.preventDefault();
    let formData = new FormData(event.target);
    let book = {
        author: formData.get('author'),
        title: formData.get('title')
    }

    if (formData.get('authot') == '' || formData.get('title') == '') {
        alert('Both fields must be filed up');
        return;
    }
    let response = handleRequests(url, {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(book)
    });

    form.reset();
}

async function deleteBook(event) {

    id = event.target.parentElement.dataset.id;
    let response = await handleRequests(url + '/' + id, {
        method: 'Delete'
    });
    event.target.parentElement.remove();
}

function createBooksInDom(data) {
    Object.entries(data).forEach(book => {
        let tr = createTheElement(book[1].title, book[1].author, book[0]);
        booksTableBody.appendChild(tr);
    });
}

function createDeleteButton() {
    const deleteBtn = document.createElement('button');
    deleteBtn.textContent = 'Delete';
    deleteBtn.addEventListener('click', deleteBook);

    return deleteBtn;
}

function createEditButton() {
    const editBtn = document.createElement('button');
    editBtn.textContent = 'Edit';
    editBtn.addEventListener('click', editBook);

    return editBtn;
}

function createTheElement(bookTitle, bookAuthor, id) {
    let tr = document.createElement('tr');
    let title = document.createElement('td');
    let author = document.createElement('td');

    title.textContent = bookTitle;
    author.textContent = bookAuthor;
    tr.appendChild(title);
    tr.appendChild(author);
    tr.dataset.id = id;
    tr.dataset.author = bookAuthor;
    tr.dataset.title = bookTitle;
    tr.appendChild(createEditButton());
    tr.appendChild(createDeleteButton());

    return tr;
}