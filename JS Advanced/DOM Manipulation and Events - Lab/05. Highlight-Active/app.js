function focused() {
    let elements = Array.from(document.querySelectorAll('input'));

    for (const element of elements) {
        
        element.addEventListener('focus', focused);
        element.addEventListener('blur', blured);
    };

    function focused(ev) {
        ev.target.parentNode.classList.add('focused')
    }

    function blured(ev) {
        ev.target.parentNode.classList.remove('focused')
    }
}