function solve(input) {
let title = serializeRow(input[0])
let rows = input
.slice(1)
.map(row => serializeRow(row).reduce((acc, el, i) => {
    acc[title[i]] = el;
    return acc;
},{}));

return JSON.stringify(rows);


    function serializeRow(str) {
        return str
        .split(/\s*\|\s*/gim)
        .filter(x => x!== '')
        .map(x => isNaN(Number(x))? x : Number(Number(x).toFixed(2)));
    }
}

console.log(solve(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']
    // ['| Town | Latitude | Longitude |',
    // '| Veliko Turnovo | 43.0757 | 25.6172 |',
    //     '| Monatevideo | 34.50 | 56.11 |']
));
