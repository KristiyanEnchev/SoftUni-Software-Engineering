function solve() {

    let movieInputContainer = document.getElementById('container');
    let movieNameInput = movieInputContainer.children[0];
    let projectionHallInput = movieInputContainer.children[1];
    let ticketPriceInput = movieInputContainer.children[2];
    let buttonOnScreen = movieInputContainer.getElementsByTagName('button')[0];
    let movieSection = document.querySelector('#movies ul');
    let sectionArchive = document.querySelector('#archive ul');
    let buttonClearArchive = sectionArchive.parentNode.querySelector('button');

    buttonOnScreen.addEventListener('click', addMovieToScreen);
    buttonClearArchive.addEventListener('click', clearEntireArchive);

    function addMovieToScreen(e) {
        e.preventDefault();
        let moviesListElement = document.createElement('li');

        let listMovieName = document.createElement('span');
        let listHall = document.createElement('strong');

        let listDivElement = document.createElement('div');

        let divTicketPriceElement = document.createElement('strong');
        let divInputTickets = document.createElement('input');
        let divButtonArchive = document.createElement('button');

        if (inputValidator.call(movieInputContainer)) {

            listMovieName.textContent = movieNameInput.value;
            listHall.textContent = `Hall: ${projectionHallInput.value}`;
            divTicketPriceElement.textContent = Number(ticketPriceInput.value).toFixed(2);
            divInputTickets.placeholder = 'Tickets Sold';
            divButtonArchive.textContent = 'Archive';
            listDivElement.appendChild(divTicketPriceElement);
            listDivElement.appendChild(divInputTickets);
            listDivElement.appendChild(divButtonArchive);
            moviesListElement.appendChild(listMovieName);
            moviesListElement.appendChild(listHall);
            moviesListElement.appendChild(listDivElement);
            movieSection.appendChild(moviesListElement);

            divButtonArchive.addEventListener('click', archiveMovie);

            movieNameInput.value = '';
            projectionHallInput.value = '';
            ticketPriceInput.value = '';
        }

        function archiveMovie(e) {
            let btn = e.target;
            let listMovieElement = btn.parentNode.parentNode;
            let listMovieDivElement = btn.parentNode;
            let listInputValue = listMovieDivElement
                .querySelector('input[placeholder="Tickets Sold"]').value;
            let ticketPriceElement = listMovieDivElement.querySelector('strong');

            if (inputValidator.call(listMovieDivElement)) {
                let newArchiveListElement = document.createElement('li');

                let archiveMovieName = document.createElement('span');
                archiveMovieName.textContent = listMovieElement.querySelector('span').textContent;
                let archiveTotalAmount = document.createElement('strong');
                archiveTotalAmount.textContent = `Total amount: ${(Number(listInputValue) * Number(ticketPriceElement.textContent)).toFixed(2)}`;
                let archiveDeleteButton = document.createElement('button');
                archiveDeleteButton.textContent = 'Delete';
                archiveDeleteButton.addEventListener('click', deleteMovieFromArchive);

                newArchiveListElement.appendChild(archiveMovieName);
                newArchiveListElement.appendChild(archiveTotalAmount);
                newArchiveListElement.appendChild(archiveDeleteButton);

                movieSection.removeChild(listMovieElement);
                sectionArchive.appendChild(newArchiveListElement);
            }

            function deleteMovieFromArchive(e) {
                let archiveElement = e.target.parentNode;
                sectionArchive.removeChild(archiveElement);
            }
        }
    }

    function clearEntireArchive(e) {
        e.preventDefault();
        let archives = Array.from(sectionArchive.children);
        archives.forEach(e => {
            sectionArchive.removeChild(e);
        })
    }


    function inputValidator() {
        let inputElements = Array.from(this.children)
            .filter(e => e.nodeName === 'INPUT');
        if (inputElements.find(e => e.value === '')) {
            return false;
        } else if (inputElements.length === 3 && isNaN(inputElements[2].value)) {
            return false;
        } else if (inputElements.length === 1 && isNaN(inputElements[0].value)) {
            console.log(false);
            return false;
        }
        return true;
    }
}