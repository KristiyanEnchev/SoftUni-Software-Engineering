function solve(speed, residence) {

    let currSpeed = Number(speed);
    let massage = '';
    let limits = {
        motorway: 130,
        interstate: 90,
        city: 50,
        residential: 20
    }

    if (currSpeed <= limits[residence]) {
        return `Driving ${currSpeed} km/h in a ${limits[residence]} zone`
    } else if (currSpeed > limits[residence] && currSpeed <= limits[residence] + 20) {
        massage = `speeding`;
    } else if (currSpeed > limits[residence] && currSpeed <= limits[residence] + 40) {
        massage = 'excessive speeding';
    } else {
        massage = 'reckless driving';
    }

    console.log(`The speed is ${currSpeed - limits[residence]} km/h faster than the allowed speed of ${limits[residence]} - ${massage}`);
}

console.log(solve(40, 'city'));
console.log(solve(21, 'residential'));
console.log(solve(120, 'interstate'));
