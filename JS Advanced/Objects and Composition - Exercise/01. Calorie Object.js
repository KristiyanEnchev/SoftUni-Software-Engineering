function solve(input) {
    let obj = {};

    for (let i = 0; i < input.length; i += 2) {
        let name = input[i];
        obj[name] = Number(input[i + 1]);
    }

    return obj;

}

console.log(solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']));
console.log(solve(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']));
