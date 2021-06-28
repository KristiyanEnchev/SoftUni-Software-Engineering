function solve(input) {
    let result = input.sort((x, y) => x.localeCompare(y));

    for(let i = 0; i < result.length; i++){
        console.log((`${i+1}.${result[i]}`));
    }

}

solve(["John", "Bob", "Christina", "Ema"]);
