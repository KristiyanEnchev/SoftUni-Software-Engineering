function calculator() {

    return {
        init(num1, num2, result) {
            this.selector1 = document.querySelector(num1);
            this.selector2 = document.querySelector(num2);
            this.output = document.querySelector(result);
        },
        add() {
            this.output.value = Number(this.selector1.value)
                + Number(this.selector2.value);
        },
        subtract() {
            this.output.value = Number(this.selector1.value)
            - Number(this.selector2.value);
        }
    }
}

const calculate = calculator();
calculate.init('#num1', '#num2', '#result');