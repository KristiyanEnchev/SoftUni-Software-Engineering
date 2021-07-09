function solve(description, criteria) {
    let tickets = [];

    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    for (let i = 0; i < description.length; i++) {
        let [destination, price, status] = description[i].split('|');
        price = Number(price);
        let ticket = new Ticket(destination, price, status);
        tickets.push(ticket);
    }

    tickets.sort((a, b) => {

        if (typeof criteria === 'number') {
            return a[criteria] - b[criteria]
        } else if (typeof criteria === 'string') {
            if (criteria === 'destination') {
                return a.destination.localeCompare(b.destination);
            } else if (criteria === 'status') {
                return a.status.localeCompare(b.status);
            }
        }
    });

    return tickets;
}

console.log(solve(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'destination'
));

console.log(solve(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'status'
));
