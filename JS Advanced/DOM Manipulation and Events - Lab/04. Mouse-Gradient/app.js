function attachGradientEvents() {
    let box = document.getElementById('gradient');
    let result = document.getElementById('result');
    box.addEventListener('mousemove', moving);


    function moving(event) {
        let offsetX = event.offsetX;
        let percent =  Math.floor(offsetX / event.target.clientWidth * 100);

        return result.textContent = percent + '%';
    }
}