function solve(arr) {
let herosArr = [];

for (let i = 0; i < arr.length; i++) {
let[heroName, heroLevel, items] = arr[i].split(' / ');
heroLevel = Number(heroLevel);
items = items !== undefined ? items.split(', ') : [];

herosArr.push({name: heroName, level: heroLevel, items: items});
}
return JSON.stringify(herosArr);
}

console.log(solve(['Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']
));
