function solve(arr) {
    let catalogue = {};

    for (let i = 0; i < arr.length; i++) {
        let [productName, price] = arr[i].split(' : ');
        price = Number(price);
        let inicial = productName[0].toUpperCase();

        if (catalogue[inicial] === undefined) {
            catalogue[inicial] = {};
        }

        catalogue[inicial][productName] = price;
    }

    let result = [];
    let inicialSort = Object.keys(catalogue).sort((a, b) => a.localeCompare(b));

    for (const key of inicialSort) {
        let products = Object.entries(catalogue[key]).sort((a, b) => a[0].localeCompare(b[0]));

        result.push(key);
        let productString = products
        .map(x => `  ${x[0]}: ${x[1]}`)
        .join('\n');

        result.push(productString)
    }

    return result.join('\n');
}

console.log(solve(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']
));
