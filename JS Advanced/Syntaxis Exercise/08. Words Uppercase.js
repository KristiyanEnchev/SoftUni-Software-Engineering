function solve(text) {

    
    let formatedWords = [];
    let words = text.split(/\W+/g);
    
    for (const word of words) {
        if (word !== '') {
            
            formatedWords.push(word.toUpperCase());
        }
    }

    console.log(formatedWords.join(", "));
}

solve('Hi, how are you?');
solve('hello');