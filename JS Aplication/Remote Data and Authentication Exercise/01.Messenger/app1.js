    // async await  --- решение 
// --------------------------
async function attachEvents() {

    const url = 'http://localhost:3030/jsonstore/messenger';
    let textArea = document.getElementById("messages");

    let response = await fetch(url);
    let data = await response.json();
    Object.values(data).forEach((line) => textArea.textContent += `${line.author}: ${line.content} \n`);

    let author = document.getElementById('author');
    let message = document.getElementById('content');
    let submitBtn = document.getElementById('submit');
    let refreshBtn = document.getElementById('refresh');

    submitBtn.addEventListener('click', submitData);
    async function submitData(e) {

        if (author.value == '' || message.value == '') {
            return
        }

        let response = await fetch(url, {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ author: author.value, content: message.value })
        });

        if (!response.ok) {
            let error = await response.json();
            return alert(error.message);
        }

        author.value = '';
        message.value = '';
    };

    refreshBtn.addEventListener('click', refreshData);
    async function refreshData(e) {

        textArea.textContent = '';

        let response = await fetch(url);
        let data = await response.json();

        Object.values(data).forEach(line => {
            textArea.textContent += `${line.author}: ${line.content} \n`
        });
    };
}

attachEvents();