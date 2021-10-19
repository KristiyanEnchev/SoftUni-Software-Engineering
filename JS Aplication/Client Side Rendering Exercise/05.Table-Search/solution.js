import { render } from "./../node_modules/lit-html/lit-html.js";
import { tableTeplate } from "./templates.js";
import { getItems } from "./requestsHendler.js";

let body = document.querySelector('tbody');
async function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);
   // on click of the serchField remove previouse serches // 
   document.getElementById('searchField').addEventListener('click', () => {
      let tds = body.querySelectorAll('tr').forEach(td => td.classList = "disabled");
   });

   let data = await getItems();
   let list = Object.values(data);
   render(tableTeplate(list), body);

   function onClick() {
      let serchBox = document.getElementById('searchField');
      const row = body.querySelectorAll('tr');
      if (serchBox.value == '') {
         return alert('No serch Data hase been passed on');
      } else {
         row.forEach(td => {
            td.classList = 'disabled';
            if (td.textContent.toLowerCase().includes(serchBox.value.toLowerCase())) {
               td.classList = 'select';
            }
         });
      }
      serchBox.value = '';
   }
}

solve();