function toggle() {
    let element = document.getElementsByClassName('button')[0];
    let text = document.getElementById('extra');

    text.style.display = text.style.display == 'none' || text.style.display == '' ? 'block' : 'none';

    element.textContent = element.textContent == 'More' ? 'Less' : 'More';

}