function create(words) {

   let output = document.getElementById('content');

   for (let i = 0; i < words.length; i++) {

      let div = document.createElement('div');
      let p = document.createElement('p');
      p.textContent = words[i];
      p.style.display = 'none';
      div.appendChild(p);
      output.appendChild(div);
   }

   output.addEventListener('click', addEvent);

   function addEvent(event) {

      if (event.target.matches('#content div')) {
         let innerP = event.target.children[0];
         innerP.style.display = 'block';
      }
   }
}