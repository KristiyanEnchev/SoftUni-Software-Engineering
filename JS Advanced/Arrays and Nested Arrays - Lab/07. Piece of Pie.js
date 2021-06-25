function solve(arr, startFrom, endAt){ 
    
let startIndex = arr.indexOf(startFrom);
let endIndex = arr.indexOf(endAt);

let result = arr.slice(startIndex, endIndex + 1);

return result;

}

console.log(solve(['Pumpkin Pie',
'Key Lime Pie',
'Cherry Pie',
'Lemon Meringue Pie',
'Sugar Cream Pie'],
'Key Lime Pie',
'Lemon Meringue Pie'
));
