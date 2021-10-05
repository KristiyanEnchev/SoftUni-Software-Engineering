function getInfo() {

    const userInputBussId = document.getElementById('stopId').value;
    const url = `http://localhost:3030/jsonstore/bus/businfo/${userInputBussId}`;

    const busStopName = document.getElementById('stopName');
    const ulElement = document.getElementById('buses');

    fetch(url)
        .then(res => res.json())
        .then(data => {
            busStopName.textContent = data.name;
            ulElement.innerHTML = '';
            Object.entries(data.buses).forEach(element => {
                let liElement = document.createElement('li');
                liElement.textContent = `Bus ${element[0]} arrives in ${element[1]} minutes`;

                ulElement.appendChild(liElement);
            });
        })
        .catch(error => {
            busStopName.textContent = "Error";
            ulElement.innerHTML = '';
        });
}