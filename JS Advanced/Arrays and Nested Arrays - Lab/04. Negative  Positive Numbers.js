function solve(input){ 
let result =[];

for (const num of input) {

    if (num < 0) {
        result.unshift(num);
    }else{
        result.push(num);
    }
    
}

    result.forEach(element => {
        console.log(element);
    });

}

solve([7, -2, 8, 9]);
solve([3, -2, 0, -1]);
