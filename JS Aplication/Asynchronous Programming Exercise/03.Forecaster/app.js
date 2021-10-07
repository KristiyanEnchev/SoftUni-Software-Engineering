async function attachEvents() {

    let locationInput = document.getElementById('location');
    let submitBtn = document.getElementById('submit');

    submitBtn.addEventListener('click', showData);

    async function showData(event) {
        event.preventDefault();
        let url = `http://localhost:3030/jsonstore/forecaster/locations`;
        let response = await fetch(url);
        let data = await response.json();

        let locationCode;

        data.forEach(element => {
            if (element.name == locationInput.value) {
                locationCode = element.code;
            }
        });

        locationInput.value = '';
        let currentConditionURL = `http://localhost:3030/jsonstore/forecaster/today/${locationCode}`
        let threeDayForecastURL = `http://localhost:3030/jsonstore/forecaster/upcoming/${locationCode}`

        try {

            let todayResponce = await fetch(currentConditionURL);
            let todayData = await todayResponce.json();

            let threeDaysResponce = await fetch(threeDayForecastURL);
            let threeDaysData = await threeDaysResponce.json();

            // today wether display 
            let weatherSymbols = {
                'Sunny': '&#x2600',
                'Partly sunny': '&#x26C5;',
                'Overcast': '&#x2601;',
                'Rain': '&#x2614;',
                'Degrees': '&#176;',
            }

            // get the type to operate int the obj with symbols
            let weatherType = `${todayData['forecast'].condition}`;

            // create main elements
            let forecastDivToday = document.createElement('div');
            forecastDivToday.classList.add('forecasts');
            let spanSymbol = document.createElement('span');
            spanSymbol.classList = 'condition symbol';
            spanSymbol.innerHTML = weatherSymbols[weatherType];
            let conditionSpan = document.createElement('span');
            conditionSpan.classList.add('condition');

            // make 3 condition spans 
            let locationSpan = document.createElement('span');
            locationSpan.classList.add('forecast-data');
            locationSpan.textContent = todayData['name']

            let maxMinTempSpan = document.createElement('span');
            maxMinTempSpan.classList.add('forecast-data');

            maxMinTempSpan.innerHTML = `${todayData['forecast'].low}${weatherSymbols['Degrees']}/${todayData['forecast'].high}${weatherSymbols['Degrees']}`;

            let weatherTypeSpan = document.createElement('span');
            weatherTypeSpan.classList.add('forecast-data');
            weatherTypeSpan.textContent = weatherType;

            //append the 3 condition spans to the main 
            conditionSpan.appendChild(locationSpan);
            conditionSpan.appendChild(maxMinTempSpan);
            conditionSpan.appendChild(weatherTypeSpan);

            // select current section
            let currentSection = document.getElementById('current');

            //append all spans to DOM 
            currentSection.appendChild(forecastDivToday);
            forecastDivToday.appendChild(spanSymbol);
            currentSection.appendChild(conditionSpan);

            // display block 
            let forcastField = document.getElementById('forecast');
            forcastField.style.display = 'block';

            // Next threeDays display

            //create upcoming day elements
            let forecastInfoDiv = document.createElement('div');
            forecastInfoDiv.classList.add('forecasts-info');


            //create first day elements
            let upcomingSpanOne = document.createElement('span');
            upcomingSpanOne.classList.add('upcoming');

            let symbolSpanFirstDay = document.createElement('span');
            symbolSpanFirstDay.classList.add('symbol');
            symbolSpanFirstDay.innerHTML = weatherSymbols[`${threeDaysData['forecast'][0].condition}`];

            let degreeSpanFirstDay = document.createElement('span');
            degreeSpanFirstDay.classList.add('forecast-data');
            degreeSpanFirstDay.innerHTML = `${threeDaysData['forecast'][0].low}${weatherSymbols['Degrees']}/${threeDaysData['forecast'][0].high}${weatherSymbols['Degrees']}`;

            let weatherTypeFirstDay = document.createElement('span');
            weatherTypeFirstDay.classList.add('forecast-data');
            weatherTypeFirstDay.textContent = `${threeDaysData['forecast'][0].condition}`;

            // append to main span
            upcomingSpanOne.appendChild(symbolSpanFirstDay);
            upcomingSpanOne.appendChild(degreeSpanFirstDay);
            upcomingSpanOne.appendChild(weatherTypeFirstDay);

            //create second day elements
            let upcomingSpanTwo = document.createElement('span');
            upcomingSpanTwo.classList.add('upcoming');

            let symbolSpanSecondDay = document.createElement('span');
            symbolSpanSecondDay.classList.add('symbol');
            symbolSpanSecondDay.innerHTML = weatherSymbols[`${threeDaysData['forecast'][1].condition}`];

            let degreeSpanSecondDay = document.createElement('span');
            degreeSpanSecondDay.classList.add('forecast-data');
            degreeSpanSecondDay.innerHTML = `${threeDaysData['forecast'][1].low}${weatherSymbols['Degrees']}/${threeDaysData['forecast'][1].high}${weatherSymbols['Degrees']}`;

            let weatherTypeSecondDay = document.createElement('span');
            weatherTypeSecondDay.classList.add('forecast-data');
            weatherTypeSecondDay.textContent = `${threeDaysData['forecast'][1].condition}`;

            // append to main span
            upcomingSpanTwo.appendChild(symbolSpanSecondDay);
            upcomingSpanTwo.appendChild(degreeSpanSecondDay);
            upcomingSpanTwo.appendChild(weatherTypeSecondDay);

            //create thurd day elements
            let upcomingSpanThree = document.createElement('span');
            upcomingSpanThree.classList.add('upcoming');

            let symbolSpanThurdDay = document.createElement('span');
            symbolSpanThurdDay.classList.add('symbol');
            symbolSpanThurdDay.innerHTML = weatherSymbols[`${threeDaysData['forecast'][2].condition}`];

            let degreeSpanThurdDay = document.createElement('span');
            degreeSpanThurdDay.classList.add('forecast-data');
            degreeSpanThurdDay.innerHTML = `${threeDaysData['forecast'][2].low}${weatherSymbols['Degrees']}/${threeDaysData['forecast'][2].high}${weatherSymbols['Degrees']}`;

            let weatherTypeThurdDay = document.createElement('span');
            weatherTypeThurdDay.classList.add('forecast-data');
            weatherTypeThurdDay.textContent = `${threeDaysData['forecast'][2].condition}`;

            // append to main span
            upcomingSpanThree.appendChild(symbolSpanThurdDay);
            upcomingSpanThree.appendChild(degreeSpanThurdDay);
            upcomingSpanThree.appendChild(weatherTypeThurdDay);

            //select upcoming section 
            let upcommingSection = document.getElementById('upcoming');

            //append all spans to forecast-info div
            forecastInfoDiv.appendChild(upcomingSpanOne);
            forecastInfoDiv.appendChild(upcomingSpanTwo);
            forecastInfoDiv.appendChild(upcomingSpanThree);

            // appen all elements to DOM
            upcommingSection.appendChild(forecastInfoDiv);

        } catch (error) {
            let forecastDiv = document.querySelector('#forecast');

            forecastDiv.textContent = 'Error';
            forecastDiv.style.display = 'block';
        }
    }
}

attachEvents();