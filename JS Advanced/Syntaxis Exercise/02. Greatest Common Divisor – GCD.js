function solve(arg1, arg2) {
    let highest = arg1 % arg2;
    while (highest != 0) {
        arg1 = arg2;
        arg2 = highest;
        highest = arg1 % arg2;
    }

    console.log(arg2);

}

solve(15, 5);
solve(2154, 458);