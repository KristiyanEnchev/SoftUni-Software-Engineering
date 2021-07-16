function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   const rows = document.querySelectorAll('tbody tr');

   function onClick() {
      const input = document.querySelector('#searchField').value.toLowerCase();

      rows.forEach(el => {
         el.style.fontWeight = 'normal';
         el.style.textDecoration = 'none';
      });

      for (let row of rows) {
         if (row.textContent.toLowerCase().includes(input)) {
            row.setAttribute('class', 'select');
         } else {
            row.removeAttribute('class');
         }
      }

   }
}