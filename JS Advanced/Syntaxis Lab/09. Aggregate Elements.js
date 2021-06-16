function solve(arr) {

    sum = (arr) => arr.reduce((x, y) => x + +y)

    inverseSum = (arr) => arr.reduce((x, y) => x + (1 / y), 0)

    concat = (arr) => arr.reduce((x, y) => x + '' + y)

    let result = Array.of(sum(arr), inverseSum(arr), concat(arr)).join('\n')

    return result;
}

console.log(solve([2, 4, 8, 16]))