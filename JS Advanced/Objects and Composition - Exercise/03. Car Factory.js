function solve(obj) {

    function createEngine(hp) {
        let engine = {};

        if (hp <= 90) {
            engine.power = 90;
            engine.volume = 1800;
        } else if (hp <= 120) {
            engine.power = 120;
            engine.volume = 2400;
        } else if (hp <= 200) {
            engine.power = 200;
            engine.volume = 3500;
        }
        return engine;
    }

    function createCarriage(color, type) {
        let carriage = { type, color };
        return carriage;
    }

    function createWheels(size) {

        let wheels = [];
        for (let i = 0; i < 4; i++) {
            if (size % 2 == 0) {
                wheels[i] = size - 1;
            } else {
                wheels[i] = size;
            }
        }
        return wheels;
        // return new Array(4).fill(wheels);
    }

    return {
        model: obj.model,
        engine: createEngine(obj.power),
        carriage: createCarriage(obj.color, obj.carriage),
        wheels: createWheels(obj.wheelsize)
    }
}

console.log(solve({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}
));

console.log(solve({
    model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17
}

));
