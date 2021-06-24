function solve(input){ 
    
    let sortedArray = input.sort((x, y) => x - y).slice(input.length / 2, input.length);

    return sortedArray;
}

console.log(solve([3, 19, 14, 7, 2, 19, 6]));
console.log(solve([4, 7, 2, 5]));
