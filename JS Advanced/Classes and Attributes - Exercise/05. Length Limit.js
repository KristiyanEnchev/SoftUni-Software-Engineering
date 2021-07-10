class Stringer {
    constructor(innerString, innerLength) {
        this.innerString = innerString;
        this.innerLength = innerLength;
    }

    increase(length) {

        length = Number(length);

        return this.innerLength += length;
    }

    decrease(length) {

        length = Number(length);

        if (this.innerLength - length <= 0) {

            return this.innerLength = 0;
        }

        return this.innerLength = this.innerLength - length;
    }

    toString() {
        let str = this.innerString.substring(0, this.innerLength);

        return this.innerString.substring(0, this.innerLength) + '...';
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4);
console.log(test.toString()); // Test

