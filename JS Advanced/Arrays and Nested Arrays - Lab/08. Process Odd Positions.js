function solve(input){ 
// let result = input.filter(x => x % 2 != 0).map(x => x * 2).reverse();
let result = [];

for (let i = 0; i < input.length; i++) {
   if (i % 2 !== 0) {
       result.push(input[i])
   }
}

result = result.map(x => x * 2).reverse();

return result;
}

console.log(solve([10, 15, 20, 25]));
console.log(solve([3,0,10,4,7,3]));
