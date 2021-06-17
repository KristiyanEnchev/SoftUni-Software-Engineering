function solve(arr1,arr2,operator){
let result;
switch(operator){
case'+': result = arr1 + arr2; break;
case'-': result = arr1 - arr2; break;
case'*': result = arr1 * arr2; break;
case'/': result =arr1 / arr2; break;
case'%': result =arr1 % arr2; break;
case'**': result =arr1 ** arr2; break;
}

console.log(result);
}

solve(5, 6, '+');