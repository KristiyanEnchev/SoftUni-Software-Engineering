function solve(matrix) {

    let rowSum = [];
    let colSum = [];

    for (let i = 0; i < matrix.length; i++) {
        let row = matrix[i];
        let sum = row.reduce((acc, val) => (acc + val), 0);
        rowSum.push(sum);
    }

    for (let i = 0; i < matrix.length; i++) {
        let newRow = [];

        for (let j = 0; j < matrix.length; j++) {
            let index = matrix.length - 1 - j;
            newRow.push(matrix[index][i]);
        }
        let sum = newRow.reduce((acc, val) => (acc + val), 0);
        colSum.push(sum);
    }
    return rowSum.concat(colSum).every((el, i, arr) => el === arr[0]);
}


console.log(solve([[4, 5, 6],
[6, 5, 4],
[5, 5, 5]]
));

console.log(solve([[11, 32, 45],
[21, 0, 1],
[21, 1, 1]]
));