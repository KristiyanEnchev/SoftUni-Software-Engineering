function balloons() {
    class Balloon {
        constructor(color, gasWeight) {
            this.color = color;
            this.gasWeight = gasWeight;
        }
    }


    class PartyBalloon extends Balloon {
        constructor(color, gasWeight, ribbonColor, ribbonLength) {
            super(color, gasWeight);
            this._ribbon = {
                color: ribbonColor,
                length: ribbonLength
            }
        }

        get ribbon() {
            return this._ribbon;
        }
    }

    class BirthdayBalloon extends PartyBalloon {
        constructor(color, gasWeight, ribbonColor, ribbonLength, text) {
            super(color, gasWeight, ribbonColor, ribbonLength);
            this._text = text;
        }

        get text() {
            return this._text;
        }
    }

    return {
        Balloon,
        PartyBalloon,
        BirthdayBalloon
    }
}


const balloon = balloons();
const party = new balloon.PartyBalloon('red', 10, 'yellow', 100);
console.log(party.color);

const birthday = new balloon.BirthdayBalloon('red', 10, 'yellow', 100, "TEST");

console.log(birthday.ribbon);
console.log(birthday.text);