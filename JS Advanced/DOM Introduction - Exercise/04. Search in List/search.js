function search() {
   let serchedItem = document.getElementById('searchText').value;
   let buttonTab = document.getElementById('result');
   // let data = Array.from(document.getElementById('towns'));
   let data = document.getElementById('towns');
   let dataAsArray = Array.from(data.querySelectorAll('li'));

   let serchesCount = 0;

   dataAsArray.forEach(el => {
      el.style.fontWeight = 'normal'
      el.style.textDecoration = 'none'
   });

   for (const item of dataAsArray) {
      if (item.textContent.toLowerCase().includes(serchedItem.toLowerCase())) {
         item.style.fontWeight = 'bold';
         item.style.textDecoration = 'underline';
         serchesCount++
      }
   }

   buttonTab.textContent = `${serchesCount} matches found`;
}
