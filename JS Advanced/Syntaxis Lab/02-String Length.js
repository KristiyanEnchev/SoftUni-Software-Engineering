function solve(arr1, arr2, arr3){
    let arr1Length = arr1.length;
    let arr2Length = arr2.length;
    let arr3Length = arr3.length;

    let sumLength = arr1Length + arr2Length + arr3Length;
    let avgLength = Math.floor(sumLength/3)

    console.log(sumLength);
    console.log(avgLength);
}

solve('chocolate', 'ice cream', 'cake');
