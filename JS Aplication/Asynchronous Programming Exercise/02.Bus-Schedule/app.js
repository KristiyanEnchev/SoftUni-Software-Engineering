function solve() {
    let departBtn = document.getElementById('depart');
    let arriveBtn = document.getElementById('arrive');

    let infoBar = document.querySelector('.info');

    let stopDepot = {
        next: 'depot'
    };

    async function depart() {
        let url = `http://localhost:3030/jsonstore/bus/schedule/${stopDepot.next}`;
        let response = await fetch(url);
        let data = await response.json();
        stopDepot = data;

        infoBar.textContent = `Next stop ${stopDepot.name}`;

        departBtn.disabled = true;
        arriveBtn.disabled = false;
    }

    function arrive() {

        infoBar.textContent = `Arriving at ${stopDepot.name}`;

        departBtn.disabled = false;
        arriveBtn.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();