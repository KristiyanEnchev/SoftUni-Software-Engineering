function solve() {

    let result = [];
    let count = {};

    [...arguments].forEach(arg => {
        let type = typeof arg;
        result.push({ type, value: arg });

        if (!count[type]) {
            count[type] = 0;
        }

        count[type] ++;
    });

    result.forEach(element => {
        console.log(`${element.type}: ${element.value}`);
    });

    let sortedObj = Object.entries(count).sort((a, b) => b[1] - a[1]);

    sortedObj.forEach(element => {
        console.log(`${element[0]} = ${element[1]}`);
    });
}

solve('cat', 42, function () { console.log('Hello world!'); });
