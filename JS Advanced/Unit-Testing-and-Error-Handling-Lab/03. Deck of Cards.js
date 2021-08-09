function printDeckOfCards(cards) {
    let arr = []

    function createCard(f, s) {
        let faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
        let suits = new Map();
        suits.set('S', '\u2660');
        suits.set('H', '\u2665');
        suits.set('D', '\u2666');
        suits.set('C', '\u2663');


        if (!faces.includes(f) || !suits.has(s)) {
            console.log(`Invalid card: ${f + s}`)
        }
        let face = faces.filter(face => face === f)[0];
        let suit = suits.get(s);

        return {
            face, suit, toString: () => {
                return face + suit
            }
        };

    }
    cards.forEach(currCard => {
        let f = currCard.substring(0, currCard.length - 1);
        let s = currCard.substring(currCard.length - 1);
        let card = createCard(f, s);
        arr.push(card)
    })

    console.log(arr.join(' '))
}

printDeckOfCards(['AS', '10D', 'KH', '2C']);
printDeckOfCards(['5S', '3D', 'QD', '1C']);