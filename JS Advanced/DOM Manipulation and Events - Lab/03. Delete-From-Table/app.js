function deleteByEmail() {
    let inputBox = document.querySelector('input');
    let rows = Array.from(document.querySelectorAll('tbody tr'));

    for (let i = 0; i < rows.length; i++) {
        if (rows[i].children[1].textContent == inputBox.value) {
            rows[i].parentNode.removeChild(rows[i]);

            document.getElementById('result').textContent = 'Deleted';
            break;
        }else{
            document.getElementById('result').textContent = 'Not found.';
        }
    }

    inputBox.value = '';
}