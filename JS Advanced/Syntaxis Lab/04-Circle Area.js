function calculateArea(num) {

    let resutl;
    let argumentType = typeof (num);
    let MathPi = Math.PI;

    if (argumentType === `number`) {

        resutl = Math.pow(num, 2) * MathPi;
        resutl = resutl.toFixed(2);

    }
    else {

        resutl = `We can not calculate the circle area, because we receive a ${argumentType}.`;
        
    }

    console.log(resutl)
}

calculateArea(5);