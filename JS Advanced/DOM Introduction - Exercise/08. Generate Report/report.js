function generateReport() {
    // let chechBoxRows = document.querySelectorAll('thead tr th input');
    let chechBoxRows = document.querySelectorAll('table>thead>tr>th>input');
    let dataRows = Array.from(document.querySelectorAll('tbody tr'));
    let output = document.getElementById('output');

    let result = [];

    for (let i = 0; i < dataRows.length; i++) {

        let obj = {};
        let personData = Array.from(dataRows[i].getElementsByTagName('td')).map(x => x.textContent);

        for (let j = 0; j < chechBoxRows.length; j++) {
            if (chechBoxRows[j].checked) {
                obj[chechBoxRows[j].name] = personData[j];
            }
        }

        result.push(obj);
    }

    output.textContent = JSON.stringify(result, null, 1);
}