function solve(arr, str) {

    if (str === 'asc') {
       return arr.sort((x, y) => x - y);
    } else if (str === 'desc') {
       return arr.sort((x, y) => y - x);
    }
}

console.log(solve([14, 7, 17, 6, 8], 'asc'));
