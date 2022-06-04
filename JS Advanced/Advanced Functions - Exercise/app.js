// .than  --- решение 
// --------------------------
function attachEvents() {

    const url = 'http://localhost:3030/jsonstore/messenger';
    const textArea = document.getElementById('messages');

    fetch(url)
        .then(r => r.json())
        .then(data => {

            Object.values(data).forEach((line) => textArea.textContent += `${line.author}: ${line.content} \n`)
        })

    const name = document.getElementById('author');
    const message = document.getElementById('content');
    const sendButton = document.getElementById('submit');
    const refreshButton = document.getElementById('refresh');

    sendButton.addEventListener('click', sendMessage);
    refreshButton.addEventListener('click', expandMessages);

    function sendMessage() {
        if (name.value == '' || message.value == '') {
            return
        }
        const senders = {
            method: "POST",
            senders: { 'Content-type': 'application/json' },
            body: JSON.stringify({
                author: name.value,
                content: message.value
            })
        }
        let mainUrl = `http://localhost:3030/jsonstore/messenger`;
        fetch(`${mainUrl}`, senders);

        name.value = ''
        message.value = ''
    }

    function expandMessages() {
        textArea.textContent = '';
        fetch(`http://localhost:3030/jsonstore/messenger`)
            .then(res => res.json())
            .then(data => {
                Object.values(data).forEach(({ author, content }) => {
                    textArea.textContent += `${author}: ${content}\n`;
                });
            });
    }
}

attachEvents();
