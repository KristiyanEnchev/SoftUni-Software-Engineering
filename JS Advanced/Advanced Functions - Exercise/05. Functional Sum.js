function add(num) {
    let sum = 0;
    sum += num;

    function calculate(num2) {
        sum += num2
        return calculate;
    }

    calculate.toString = () => sum;
    return calculate;
}


console.log(add(1)(6)(-3).toString());