function encodeAndDecodeMessagesTEST() {
    const textAreas = document.querySelectorAll('textarea');
    const buttons = document.querySelectorAll('button');


    buttons[0].addEventListener('click', function (e) {
        const message = textAreas[0].value.split('').map((char) => String.fromCharCode(char.charCodeAt(0) + 1)).join('');
        textAreas[0].value = '';
        textAreas[1].value = message;
    });

    buttons[1].addEventListener('click', function (e) {
        const message = textAreas[1].value.split('').map((char) => String.fromCharCode(char.charCodeAt(0) - 1)).join('');
        textAreas[1].value = message;
    })
}