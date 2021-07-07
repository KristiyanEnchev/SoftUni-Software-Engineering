function solve(area, vol, input) {
    let cordinatesAsArr = JSON.parse(input);
    let result = [];

    for (const cordinate of cordinatesAsArr) {
        result.push({
            area: area.call(cordinate),
            volume: vol.call(cordinate)
        });
    }

    return result;
}


function area() {
    return Math.abs(this.x * this.y);
};
function vol() {
    return Math.abs(this.x * this.y * this.z);
};


solve(area, vol, '[{"x":"1","y":"2","z":"10"},{"x":"7","y":"7","z":"10"},{"x":"5","y":"2","z":"10"}]');
