class Contact {
    constructor(firstName, lastName, phone, email) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.phone = phone;
        this.email = email;
        this._online = false;
    }

    render(id) {
        const target = document.getElementById(id);
        const hiddenDiv = el('div', null, 'info');
        const hiddenDivSpan1 = el('span', `&phone; ${this.phone}`);
        const hiddenDivSpan2 = el('span', `&#9993; ${this.email}`);
        hiddenDiv.appendChild(hiddenDivSpan1);
        hiddenDiv.appendChild(hiddenDivSpan2);
        hiddenDiv.style.display = 'none';

        const visibleDiv = el('div', `${this.firstName} ${this.lastName}`, 'title');
        const visibleDivButton = el('button', "&#8505");
        visibleDiv.appendChild(visibleDivButton);

        if (this.online) {
            visibleDiv.classList.add("online");
        }


        const card = el('article');
        card.appendChild(visibleDiv);
        card.appendChild(hiddenDiv);

        card.addEventListener('click', (e) => {
            if (e.target.tagName === 'BUTTON') {
                if (e.target.parentElement.nextSibling.style.display == 'none') {
                    e.target.parentElement.nextSibling.style.display = "block";
                } else {
                    e.target.parentElement.nextSibling.style.display = "none";
                }
            }
        });


        function el(type, content, addClass) {
            let result = document.createElement(type);
            if (typeof content == 'string') {
                result.innerText = content;
            }

            if (addClass) {
                result.classList.add(addClass);
            }

            return result;
        }

        target.appendChild(card);
    }

    set online(state) {
        this._online = state;

        if (document.querySelectorAll("article > div.title").length != 0) {
            if (this._online) {
                Array.from(document.querySelectorAll("article > div.title"))
                    .filter((el) => el.innerText.includes(this.firstName))[0]
                    .classList.add("online");
            } else {
                Array.from(document.querySelectorAll("article > div.title"))
                    .filter((el) => el.innerText.includes(this.firstName))[0]
                    .classList.remove("online");
            }
        }
    }

    get online() {
        return this._online;
    }
}


let contacts = [
    new Contact("Ivan", "Ivanov", "0888 123 456", "i.ivanov@gmail.com"),
    new Contact("Maria", "Petrova", "0899 987 654", "mar4eto@abv.bg"),
    new Contact("Jordan", "Kirov", "0988 456 789", "jordk@gmail.com")
];
contacts.forEach(c => c.render('main'));
setTimeout(() => contacts[1].online = true, 1000);