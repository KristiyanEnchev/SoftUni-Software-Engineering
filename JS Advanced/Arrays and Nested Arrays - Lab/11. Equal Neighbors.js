
function solve(matrix) {

    let maches = 0;

    for (let row = 0; row < matrix.length; row++) {

        for (let col = 0; col < matrix[row].length; col++) {

            let num = matrix[row][col];

            if (row - 1 >= 0) {
                let up = matrix[row - 1][col]
                if (num == up) {
                    maches++;
                }
            }
            if (row + 1 <= matrix.length - 1) {
                let down = matrix[row + 1][col]
                if (num == down) {
                    maches++;
                }
            }
            if (col - 1 >= 0) {
                let left = matrix[row][col - 1]
                if (num == left) {
                    maches++;
                }
            }
            if (col + 1 <=  matrix[row].length - 1) {
                let right = matrix[row][col + 1]
                if (num == right) {
                    maches++;
                }
            }

        }
    }

    return maches / 2;
}

console.log(solve([['2', '3', '4', '7', '0'], ['4', '0', '5', '3', '4'], ['2', '3', '5', '4', '2'], ['9', '8', '7', '5', '4']]));
// console.log(solve([['test', 'yes', 'yo', 'ho'], ['well', 'done', 'yo', '6'], ['not', 'done', 'yet', '5']]));
// console.log(solve([['2', '2', '5', '7', '4'], ['4', '0', '5', '3', '4'], ['2', '5', '5', '4', '2']]));