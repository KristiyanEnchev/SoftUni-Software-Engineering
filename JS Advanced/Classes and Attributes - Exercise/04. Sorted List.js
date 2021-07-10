class List {
    constructor() {
        this.data = [];
        this.size = this.data.length;
    }

    add(element) {
        if (isNaN(element)) {
            throw new Error('Input must be a number');
        }

        this.data.push(element);
        this.data.sort((a, b) => a - b);
        this.size++;
        return this;
    }
    remove(index) {
        if (index < 0 || index >= this.size) {
            throw new Error('Index out of range exception');
        }

        this.data.splice(index, 1);
        this.size--;
        this.data.sort((a, b) => a - b);
        return this;

    }
    get(index) {
        if (index < 0 || index > this.size) {
            throw new Error('Index out of range exception');
        }else{
            return this.data[index];
        }
    }
}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));
