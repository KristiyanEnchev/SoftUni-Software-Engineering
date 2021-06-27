function solve(arr, rotations){ 
    let last = '';
    for (let i = 0; i <= rotations - 1; i++) {
         last = arr.pop()
         arr.unshift(last);
    }

    return arr.join(" ");
}

console.log(solve(['1', 
'2', 
'3', 
'4'], 
2
));