function solve() {
  let input = document.getElementById('input').value;
  let output = document.getElementById('output');
  let sentancesArray = input.split(".").filter(function (currentElement) {
    return currentElement.length > 0 && currentElement !== '\n';
  });

  for (let i = 0; i < sentancesArray.length; i += 3) {
    let arr = [];
    for (let y = 0; y < 3; y++) {
      if (sentancesArray[i + y]) {
        arr.push(sentancesArray[i + y]);
      }
    }

    let paragraph = arr.join('. ') + '.';
    output.appendChild(document.createElement('p')).textContent = paragraph;
  }
}