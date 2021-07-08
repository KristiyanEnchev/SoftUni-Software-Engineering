function solution() {
    let str = '';

    function append(strToAppend) {
        str += strToAppend;
    }

    function removeStart(n) {
        str = str.slice(n)
    }

    function removeEnd(n) {
        str = str.slice(0, -n);
    }

    function print() {
        console.log(str);
    }

    return {
        append,
        removeStart,
        removeEnd,
        print
    };
}


let firstZeroTest = solution();

firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();