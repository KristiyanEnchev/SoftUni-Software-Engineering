function colorize() {
    let allRows = document.querySelectorAll('table tr')

    for (let i = 1; i < allRows.length; i+=2) {
        allRows[i].style.backgroundColor = 'teal';
    }
}