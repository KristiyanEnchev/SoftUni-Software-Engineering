function solve(argument) {
let map = {
    'Monday':1,
    'Tuesday':2,
    'Wednesday':3,
    'Thursday':4,
    'Friday':5,
    'Saturday':6,
    'Sunday':7,
}

return map[argument] ? map[argument] : 'error';

}

console.log(solve('Monday'));
console.log(solve('Tuesday'));
console.log(solve('Wednesday'));
console.log(solve('Thursday'));
console.log(solve('Friday'));
console.log(solve('Saturday'));
console.log(solve('Sunday'));
console.log(solve('Invalid'));