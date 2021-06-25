function solve(matrix) {

    let primeryDiagonalSum = 0;
    let secondaryDiagonalSum = 0;

    for (let row = 0; row < matrix.length; row++) {

        primeryDiagonalSum += matrix[row][row]
        secondaryDiagonalSum += matrix[row][matrix.length - row - 1];
    }

    let arr = primeryDiagonalSum + ' ' + secondaryDiagonalSum;
    return arr;

}

console.log(solve([[20, 40], [10, 60]]));
