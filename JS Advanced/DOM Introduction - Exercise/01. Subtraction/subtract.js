function subtract() {
    let num1 = document.getElementById('firstNumber').value;
    let num2 = document.getElementById('secondNumber').value;

    function substract(num1, num2) {
        let sum = Number(num1) - Number(num2);
        return sum;
    }

    let result = document.getElementById('result').textContent = substract(num1, num2);
    console.log(result);
}