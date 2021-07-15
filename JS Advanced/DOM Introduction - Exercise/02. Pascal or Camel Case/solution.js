function solve() {
  let data = document.getElementById('text').value.split(' ');
  let state = document.getElementById(`naming-convention`).value;
  let diplayResult = document.getElementById('result');

  let result = '';

  for (let i = 0; i < data.length; i++) {
    let lowerData = data[i].toLowerCase()

    if (state === 'Camel Case') {
      if (i != 0) {
        result += lowerData[0].toUpperCase() + lowerData.slice(1);
      } else {
        result += lowerData;
      }
    } else if (state === 'Pascal Case') {
      result += lowerData[0].toUpperCase() + lowerData.slice(1);
    } else {
      result = 'Error!'
    }
  };

  return diplayResult.textContent = result;
}