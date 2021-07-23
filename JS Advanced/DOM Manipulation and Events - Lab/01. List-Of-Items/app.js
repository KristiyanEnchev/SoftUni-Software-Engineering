function addItem() {
    let insertField = document.querySelector('#newItemText');
    let text = insertField.value;
    let outputField = document.querySelector('#items');
    let element = document.createElement('li');
    element.textContent = text;
    outputField.appendChild(element);
    
}