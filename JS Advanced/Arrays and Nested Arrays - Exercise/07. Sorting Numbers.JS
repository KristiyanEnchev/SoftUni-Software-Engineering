function solve(input) {
    let newArr = input.slice(input);
    let assending = newArr.sort((x, y) => x - y);
    let desending = input.sort((x, y) => y - x);
    let result = [];

    for (let i = 0; i < input.length; i++) {
        if (result.length < input.length) {
            result.push(assending[i]);
        }
        if (result.length < input.length) {
            result.push(desending[i]);
        }
    }

    return result;
}

console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18]));
