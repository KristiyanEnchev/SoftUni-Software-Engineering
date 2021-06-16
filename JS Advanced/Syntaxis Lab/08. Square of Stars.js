function solve(size = 5) {
    function drawRow(size) {
        let row = '';
        for (let i = 0; i < size; i++) {
            row += '*' + ' ';
        }
        return row + '\n'
    }

    let rectangle = '';
    for (let i = 0; i < size; i++) {
        rectangle += drawRow(size);
    }

    return rectangle;

}

console.log(solve(1));
console.log(solve(7));
console.log(solve(3));
console.log(solve());