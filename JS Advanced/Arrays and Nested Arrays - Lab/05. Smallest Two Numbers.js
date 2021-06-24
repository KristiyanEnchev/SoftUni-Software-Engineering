function solve(input) {
    let result = input.sort((x, y) => x - y).slice(0, 2).join(' ');
    return result;
}

console.log(solve([30, 15, 50, 5]));