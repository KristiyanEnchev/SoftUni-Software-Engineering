function solve(num,...arguments) {

    let normalArr = arguments;

    normalArr.forEach(argument => console.log(num = applyOperation(num, argument)));
    
    function applyOperation(num, op) {
        switch (op) {
            case 'chop': { num /= 2; break; }
            case 'dice': { num = Math.sqrt(num); break; }
            case 'spice': { num++; break; }
            case 'bake': { num *= 3; break; }
            case 'fillet': { num = num * 0.80; break; }
        }
        return num;
    }
}

solve('32', 'chop', 'chop', 'chop', 'chop', 'chop');
solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet');
