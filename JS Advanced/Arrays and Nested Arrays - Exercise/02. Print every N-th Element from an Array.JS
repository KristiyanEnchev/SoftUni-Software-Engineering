function solve(arr, num) {
    let result = arr.filter((x, i) => i % num === 0);
    
    return result;
}

console.log(solve(['5',
    '20',
    '31',
    '4',
    '20'],
    2
));
