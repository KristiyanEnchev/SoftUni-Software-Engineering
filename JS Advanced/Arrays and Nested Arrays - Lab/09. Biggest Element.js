function solve(matrix) {

    let biggestNumber = matrix[0][0];
    
    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            
            let num = matrix[row][col]
            
            if (matrix[row][col] > biggestNumber) {
                biggestNumber = matrix[row][col];
            }
        }
    }

    return biggestNumber;
}


console.log(solve([[20, 50, 10], [8, 33, 145]]));
