function validate() {
    let input = document.getElementById('email');
    input.addEventListener('change', change);

    function change(ev) {

        let pattern = /^[a-z]+@[a-z]+\.[a-z]+$/gi
        const email = ev.target.value;
        if (pattern.test(email)) {
            ev.target.className = '';
        } else {
            ev.target.className = 'error';
        }

    }
}