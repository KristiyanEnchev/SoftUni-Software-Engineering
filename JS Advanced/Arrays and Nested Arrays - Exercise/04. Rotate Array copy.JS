function solve(arr, rotations) {
    let realRotations = rotations % arr.length;
    // for (let i = 0; i <= realRotations - 1; i++) {
    //     last = arr.pop()
    //     arr.unshift(last);
    // }

    let elements = arr.splice(arr.length - realRotations, realRotations)
    arr.splice(0, 0, ...elements)

    return arr.join(" ");
}

console.log(solve(['1',
    '2',
    '3',
    '4'],
    2
));