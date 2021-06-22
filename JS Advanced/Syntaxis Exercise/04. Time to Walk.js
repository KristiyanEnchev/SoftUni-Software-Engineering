function solve(steps, foot, personSpeed){ 
// find meters 
let distance = steps * foot;

// find -  meters / s 
let kmHToMS = 3.6
let speed = personSpeed / kmHToMS;

//find break
let breakTimeInSeconds = Math.floor(distance / 500) * 60;

let time = (distance / speed) + breakTimeInSeconds;

let hours = Math.floor(time/ 3600);
let minutes = Math.floor(time/ 60);
let seconds = Math.round(time- hours * 3600 - minutes * 60);

return `${hours < 10 ? 0 + '' + hours : hours}:${minutes < 10 ? 0 + '' + minutes : minutes}:${seconds < 10 ? 0 + '' + seconds : seconds}`;

}


console.log(solve(4000, 0.60, 5));
console.log(solve(2564, 0.70, 5.5));