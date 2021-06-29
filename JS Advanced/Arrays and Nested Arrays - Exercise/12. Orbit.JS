function solve(input) {
    let [cols, rows, rowsOne, colsOne] = input;
    let field = [];
    while (field.length < rows) {
        let r = [];
        while (r.length < cols) {
            r.push(0);
        } field.push(r);
    }
    for (let row in field) {
        row = Number(row);
        for (let col in field[row]) {
            col = Number(col);
            field[row][col] = Math.max(Math.abs(row - rowsOne), Math.abs(col - colsOne)) + 1;
        }
    }
    return field.map((el) => el.join(" ")).join("\n");
}

console.log(solve([4, 4, 0, 0]));