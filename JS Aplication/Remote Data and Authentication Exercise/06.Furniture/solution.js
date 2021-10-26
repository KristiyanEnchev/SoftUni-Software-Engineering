const url = 'http://localhost:3030/data/furniture';

function solve() {

  async function handleRequests(url, options) {
    try {
      let response = await fetch(url, options);
      if (!response.ok) {
        const error = await response.json();
        alert(error.message);
        throw new Error(error.message);
      }
      let data = await response.json();
      return data;

    } catch (error) {
      alert(error.message);
    }
  }

  window.addEventListener('load', async () => {
    const response = await handleRequests(url);
    return response;
  });


  function create(type, content, attributes, appendElements) {
    const el = document.createElement(type);

    if (content) {
      el.textContent = content;
    }

    if (attributes) {
      Object.entries(attributes).forEach(([key, value]) => el.setAttribute(key, value));
    }

    if (appendElements) {
      appendElements.forEach(element => {
        el.appendChild(element);
      });
    }
    return el;
  }

  async function renderTabel() {
    const data = await handleRequests(url);
    const tbody = document.querySelector('tbody');
    tbody.querySelectorAll('tr').forEach(tr => tr.remove());

    data.forEach(el => {
      console.log(el);
      const img = create('img', undefined, { src: el.img });
      const imgTd = create('td', undefined, undefined, [img]);

      const nameP = create('p', el.name);
      const nameTd = create('td', undefined, undefined, [nameP]);

      const priceP = create('p', el.price);
      const priceTd = create('td', undefined, undefined, [priceP]);

      const factorP = create('p', el.factor);
      const factorTd = create('td', undefined, undefined, [factorP]);

      const input = create('input', undefined, { type: 'checkbox', disabled: true });
      const inputTd = create('td', undefined, undefined, [input]);

      const tr = create('tr', undefined, undefined, [imgTd, nameTd, priceTd, factorTd, inputTd]);
      tbody.appendChild(tr);
    });
  }
  renderTabel();
}

solve();