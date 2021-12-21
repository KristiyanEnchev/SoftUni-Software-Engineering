let allSections = document.querySelectorAll('section');

allSections.forEach(section => {
    if (section.id != 'years') {
        section.style.display = 'none';
    }
});

let year = '';
let mounth = '';
let mounths = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sept", "Oct", "Nov", "Dec"];

allSections.forEach(section => {
    section.addEventListener('click', (event) => {
        let targett = event.target;


        if (section.id == 'years') {

            if (targett.className == 'day' || targett.className == 'date') {
                year = targett.innerText;
                document.getElementById(`year-${year}`).style.display = 'block';
                section.style.display = 'none';
            }

        } else if (section.id == `year-${year}`) {

            if (targett.className == 'day' || targett.className == 'date') {
                mounth = targett.innerText;
                document.getElementById(`month-${year}-${mounths.indexOf(mounth) + 1}`).style.display = 'block';
                section.style.display = 'none';
            } else if (targett.tagName == 'CAPTION') {
                document.getElementById('years').style.display = 'block';
                section.style.display = 'none';
            }

        } else if (section.id == `month-${year}-${mounths.indexOf(mounth) + 1}`) {

            if (targett.tagName == 'CAPTION') {
                document.getElementById(`year-${year}`).style.display = 'block'
                section.style.display = 'none';
                console.log('CAPTION')
            }
        }
    });
});

//селектираме секциите като имаме секции по : 
// години 
// месеци 
// дни 
// обхождаме секциите и показваме само тази с годините
// закачаме на всички секции евентлистенери и ако има клик показваме дадената секция кадето е възникнал кликът (event.target)
// съответно скриваме всички останали