async function lockedProfile() {

    let url = 'http://localhost:3030/jsonstore/advanced/profiles';

    let response = await fetch(url);
    let data = await response.json();

    let main = document.getElementById('main');
    main.innerHTML = '';

    Object.values(data).forEach((user, i) => {

        i = i + 1;

        let profile =
            e('div', { class: 'profile' }, '',
                e('img', { src: './iconProfile2.png', class: 'userIcon' }),
                e('label', {}, 'Lock'),
                e('input', { type: 'radio', name: `user${i}Locked`, value: 'lock', checked: '' }),
                e('label', {}, 'Unlock'),
                e('input', { type: 'radio', name: `user${i}Locked`, value: 'unlock' }),
                e('br'),
                e('hr'),
                e('label', {}, `Username`),
                e('input', { type: 'text', name: `user${i}Username`, value: `${user.username}`, disabled: ``, randomly: `` }),
                e('div', { id: `user${i}HiddenFields` }, '',
                    e('hr'),
                    e('label', {}, 'Email:'),
                    e('input', { type: 'email', name: `user${i}Email`, value: `${user.email}`, disabled: '', randomly: '' }),
                    e('label', {}, 'Age'),
                    e('input', { type: 'email', name: `user${i}Age`, value: `${user.age}`, disabled: '', randomly: '' })),
                e('button', {}, 'Show more'));

        main.appendChild(profile);

        document.querySelector(`#user${i}HiddenFields`).style.display = 'none';
    });

    main.addEventListener('click', (event) => {

        if (event.target.tagName == 'BUTTON' && event.target.parentElement.querySelectorAll("input")[1].checked) {
            const toShowDiv = event.target.parentElement.querySelector("div")

            toShowDiv.style.display = event.target.innerHTML === "Show more" ? "block" : "none"
            event.target.innerHTML = event.target.innerHTML === "Show more" ? "Hide it" : "Show more"
        } else {
            return
        }
    });

    function e(type, attribute, text, ...params) {
    
        const element = document.createElement(type);
    
        if (attribute != {} && attribute != undefined) {
    
            Object.entries(attribute).forEach(([name, value]) => {
                element.setAttribute(`${name}`, `${value}`);
            });
        }
        if (text != undefined && text != '') {
    
            element.innerHTML = text;
        };
        if (params != undefined && params.length != 0) {
    
            params.forEach(e => {
                element.appendChild(e);
            });
        };
    
        return element;
    }
}