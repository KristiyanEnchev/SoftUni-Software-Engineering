async function solution() {

    let url = 'http://localhost:3030/jsonstore/advanced/articles/list';
    let response = await fetch(url);
    let data = await response.json();
    // console.log(data);

    manageData(data);
}

solution();

async function manageData(data) {

    const mainElement = document.getElementById('main');

    for (const element in data) {

        // console.log(element);
        let el = data[element];
        let elementId = el._id;
        let elementTitle = el.title;
        let contentUrl = `http://localhost:3030/jsonstore/advanced/articles/details/${elementId}`;

        let elementResponse = await fetch(contentUrl);
        let elementData = await elementResponse.json();
        // console.log(elementData);
        let content = elementData.content;

        let mainDiv = e('div', '', 'accordion');
        let headDiv = e('div', '', 'head');
        let titleSpan = e('span', elementTitle);
        let button = e('button', 'More', 'button', elementId);
        let extraTextDiv = e('div', '', 'extra');

        extraTextDiv.style.display = 'none'

        let textParagraph = e('p', content);

        headDiv.appendChild(titleSpan);
        headDiv.appendChild(button);
        extraTextDiv.appendChild(textParagraph);
        mainDiv.appendChild(headDiv);
        mainDiv.appendChild(extraTextDiv);

        mainElement.appendChild(mainDiv);
    };

    let buttons = document.querySelectorAll('button');
    // console.log(buttons);

    buttons.forEach(buton => {

        buton.addEventListener('click', showExtra);

        function showExtra(event) {

            // let extraSection = event.currentTarget.parentElement.parentElement[1];
            let extraSection = event.currentTarget.parentElement.parentElement.children[1];
            
            if (extraSection.style.display == 'none') {

                extraSection.style.display = 'block';
                buton.textContent = 'Less';

            }else if (extraSection.style.display == 'block') {

                extraSection.style.display = 'none';
                buton.textContent = 'More';
            }
        }
    });
}

//     <!-- <div class="accordion">
//     <div class="head">
//         <span>Scalable Vector Graphics</span>
//         <button class="button" id="ee9823ab-c3e8-4a14-b998-8c22ec246bd3">More</button>
//     </div>
//     <div class="extra">
//         <p>Scalable Vector Graphics .....</p>
//     </div>
// </div> -->

function e(type, text, style, id) {

    let element = document.createElement(type);

    if (text) {
        element.textContent = text;
    }
    if (style) {
        element.classList.add(style);
    }
    if (id) {
        element.id = id;
    }

    return element;
}



// Правим заявка към сървара за да си достъпим датата по "title"
// ще направим функция която да обработва данните за всяко заглавия в data - та, да прави съответните DOM елементи 
// за всяко заглавие вземаме неговоро id и title 
// правим заявка към сървара за да си вземам текста за съответното id 
// създаваме елементите за DOM - а , с помоща на създаващата функция
// правим нов елемент(параграф) чрез функцията за създаване на елементи и закачаме съдържанието като текст
// апендваме всеки елемент към съответният parent по дървото докато не закачим всичко за main секцията

// закачаме eventListener за бутоните на всеки елемент 
// при клик на ботон правим показваме или скриваме info - то (togle button logic) и сменяме текста на бутона