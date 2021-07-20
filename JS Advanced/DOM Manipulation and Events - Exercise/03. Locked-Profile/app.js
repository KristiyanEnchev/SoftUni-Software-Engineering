function lockedProfile() {
    // let profiles = document.querySelectorAll('#main .profile');
    let buttons = document.querySelectorAll('#main .profile button');

    for (let i = 0; i < buttons.length; i++) {
        buttons[i].addEventListener('click', () => {

            let name = `user${i + 1}Locked`;
            let radioButton = document.querySelector(`input[name="${name}"]:checked`);

            if (radioButton.value === 'unlock') {

                let hiddenfield = document.getElementById(`user${i + 1}HiddenFields`);
                hiddenfield.style.display = hiddenfield.style.display === 'block' ? 'none' : 'block';

                buttons[i].textContent = buttons[i].textContent === 'Show more' ? 'Hide it' : 'Show more';
            }
        });
    }
}