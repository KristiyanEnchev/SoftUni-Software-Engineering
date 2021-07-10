class Company {
    constructor() {
        this.departments = [];
    }

    addEmployee(username, Salary, Position, Department) {

        if (!username || !Position || !Department || !Salary || Salary <= 0) {
            throw new Error("Invalid input!");
        }

        let newEmploy = {
            username: username,
            Salary: Number(Salary),
            Position: Position
        }

        if (!this.departments[Department]) {
            this.departments[Department] = [];
        }

        this.departments[Department].push(newEmploy);

        return `New employee is hired. Name: ${username}. Position: ${Position}`;
    }

    bestDepartment() {

        let bestAvarageName = '';
        let bestAvgSalary = 0;
        for (const [key, value] of Object.entries(this.departments)) {
            let sum = 0;

            for (const salary of value) {
                sum += salary.Salary;
            }
            sum = sum / value.length;

            if (sum > bestAvgSalary) {
                bestAvgSalary = sum;
                bestAvarageName = key;
            }
        }

        let finalMassage = `Best Department is: ${bestAvarageName}\nAverage salary: ${bestAvgSalary.toFixed(2)}\n`;

        this.departments.forEach(element => {
            let en = element;
            element[bestAvarageName].sort((a, b) => b.Salary - a.Salary && a.username.localeCompare(b.username));
        });

        let secondPart = '';

        this.departments[bestAvarageName].forEach(element => {
            secondPart += `${element.username} ${element.Salary} ${element.Position}\n`;
        });

        // Object.values(this.departments[bestAvarageName]
        //     .sort((a, b) => b.Salary - a.Salary
        //         || a.username.localeCompare(b.username)).forEach(element => {
        //             let rstMassage = `${element.username} ${element.Salary} ${element.Position}\n`;
        //             return rstMassage;
        //         }));
        let final = finalMassage + secondPart;
        return final.trim();
    }
}

let c = new Company();
// c.addEmployee("Stanimir", 2000, "engineer", "Construction");
// c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
// c.addEmployee("Slavi", 500, "dyer", "Construction");
// c.addEmployee("Stan", 2000, "architect", "Construction");
// c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
// c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
// c.addEmployee("Gosho", 1350, "HR", "Human resources");

c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");

console.log(c.bestDepartment());