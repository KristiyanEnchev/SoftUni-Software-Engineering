function solve() {

    function fighter(name) {
        let heroState = {
            name,
            health: 100,
            stamina: 100
        };

        fightFunc(heroState);
        return heroState;
    }

    function fightFunc(heroState) {
        heroState.fight = () => {
            heroState.stamina--;
            console.log(`${heroState.name} slashes at the foe!`);
        }
    }

    function mage(name) {
        let heroState = {
            name,
            health: 100,
            mana: 100
        };

        castFunc(heroState);
        return heroState;
    }

    function castFunc(heroState) {
        heroState.cast = (spell) => {
            heroState.mana--;
            console.log(`${heroState.name} cast ${spell}`);
        }
    }

    return {fighter, mage}
}

let create = solve();
const scorcher2 = create.fighter("Scorcher 2");
scorcher2.fight();
let act = scorcher2.stamina;
let exp = 99;
// let create = solve();
// const scorcher = create.mage("Scorcher");
// scorcher.cast("fireball")
// scorcher.cast("thunder")
// scorcher.cast("light")

// const scorcher2 = create.fighter("Scorcher 2");
// scorcher2.fight()

// console.log(scorcher2.stamina);
// console.log(scorcher.mana);

