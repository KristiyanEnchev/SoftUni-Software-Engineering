function solve(arr) {
    let operand = [];
    let wasWrong = false;
    for (let i = 0; i < arr.length; i++) {
        if (typeof arr[i] === 'number') {
            operand.push(arr[i]);
        } else {
            let operator = arr[i];
            if (operand.length < 2) {
                console.log(("Error: not enough operands!"));
                wasWrong = true;
                break;;
            }
            let operand2 = operand.pop();
            let operand1 = operand.pop();
            let result = applyOperation(operand1, operand2, operator);

            operand.push(result);
        }
    }

    if (operand.length > 1 && wasWrong === false) {
        console.log("Error: too many operands!");
    } else if(wasWrong === false){
        console.log(operand[0]);
    }

    function applyOperation(operand, operand2, operator) {
        const aritmeticalOperation = {
            '+': () => operand + operand2,
            '-': () => operand - operand2,
            '*': () => operand * operand2,
            '/': () => operand / operand2,
        }

        return aritmeticalOperation[operator]();
    }
}

solve([3,
    4,
    '+']
   );
