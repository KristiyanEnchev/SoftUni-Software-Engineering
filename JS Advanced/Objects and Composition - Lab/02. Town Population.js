function solve(arr) {

    let result = {};

    arr.forEach(element => {
        let [name, population] = element.split(' <-> ');
        population = Number(population);

        if (result[name]) {

            result[name] += population;

        } else {

            result[name] = population;
        }
    });
    Object.entries(result).forEach(entry => {
        console.log(`${entry[0]} : ${entry[1]}`);
    })  
}

solve(['Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000']
);
solve(['Istanbul <-> 100000',
    'Honk Kong <-> 2100004',
    'Jerusalem <-> 2352344',
    'Mexico City <-> 23401925',
    'Istanbul <-> 1000']
);