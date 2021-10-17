import { render } from "./../node_modules/lit-html/lit-html.js";
import { towns } from "./towns.js";
import { ulTemplate } from "./cardTemplate.js";

const container = document.getElementById('towns');
render(ulTemplate(towns), container);
const serchBtn = document.getElementById('sercheBtn').addEventListener('click', search);

function search(event) {
   let serchBox = document.getElementById('searchText');
   const townsElements = container.querySelectorAll('li');
   const resultCountField = document.getElementById('result');
   let counter = 0;
   if (serchBox.value == '') {
      return alert('No serch Data hase been passed on');
   } else {
      townsElements.forEach(li => {
         li.classList = 'disabled';
         if (li.textContent.toLowerCase().includes(serchBox.value.toLowerCase())) {
            li.classList = 'active';
            counter++;
         }
      });
   }
   resultCountField.textContent = `${counter} matches found`;
   serchBox.value = '';
}
