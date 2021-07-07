function solution(contextNum){ 

    let num = contextNum;

    function addFunction(outNumber){
        num = contextNum;
        num += outNumber;
        return num;
    }

    return addFunction;
}



let add5 = solution(5);
console.log(add5(2));
console.log(add5(3));
