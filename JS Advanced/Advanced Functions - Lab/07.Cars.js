function solve(input) {

    let myObj = {}

    let obj = {
        create: (hisName, inherits, parentName) =>
            (myObj[hisName] = inherits ? Object.create(myObj[parentName]) : {}),

        set: (hisName, key, value) => (myObj[hisName][key] = value),

        print: hisName => {
            let myArr = []
            for (let i in myObj[hisName]) {
                myArr.push(`${i}:${myObj[hisName][i]}`)
            }
            console.log(myArr.join(', '));
        },
    }
    input.forEach(i => {
        let [a, hisName, key, value] = i.split(' ');
        obj[a](hisName, key, value);
    });
}

solve(['create c1',
'create c2 inherit c1',
'set c1 color red',
'set c2 model new',
'print c1',
'print c2']
);