function solve(arr) {
    let newArr = [];
    let num = 1;
    for (let i = 0; i < arr.length; i++) {
        if (arr[i] == 'add') {
            newArr.push(num);
            num++;
        } else if (arr[i] == 'remove') {
            num++;
            newArr.pop();
        }
    }
    if (newArr.length > 0) {
        newArr.forEach(element => {
            console.log(element);
        });
    }else{
        console.log('Empty');
    }
}

solve(['add', 'add', 'add', 'add']);
solve(['add', 'add', 'remove', 'add', 'add']);