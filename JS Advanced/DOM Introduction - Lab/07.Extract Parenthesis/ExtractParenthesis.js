function extract(content) {
    let text = document.getElementById(content).textContent;

    let regex = /\((.+?)\)/gm;
    let maches = text.match(regex);

    return maches.join('; ');
}