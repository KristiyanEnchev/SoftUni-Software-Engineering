class Company {
    static Employee = class Employee {
        constructor(username, salary, position) {
            this.username = username;
            this.salary = salary;
            this.position = position;
        }

        get username() {
            return this._username;
        }

        set username(value) {
            this._verifyParam(value);
            this._username = value;
        }

        get salary() {
            return this._salary;
        }

        set salary(value) {
            this._verifyParam(value);
            if (value < 0) {
                throw new Error('Invalid input!');
            }
            this._salary = Number(value);
        }

        get position() {
            return this._position;
        }

        set position(value) {
            this._verifyParam(value);
            this._position = value;
        }

        _verifyParam(value) {
            if (value === undefined || value === null || value === '') {
                throw new Error('Invalid input!');
            }
        }

        compareTo(other) {
            let result = other.salary - this.salary;
            return result === 0 ? this.username.localeCompare(other.username) : result;
        }

        toString() {
            return `${this.username} ${this.salary} ${this.position}`;
        }
    }

    constructor() {
        this.departments = new Map();
    }

    _getAverageSalary(department) {
        let currentDepartment = this.departments.get(department);
        return currentDepartment.reduce((acc, w) => acc + w.salary, 0) / currentDepartment.length;
    }

    addEmployee(username, salary, position, department) {
        if (department === undefined || department === null || department === '') {
            throw new Error('Invalid input!');
        }

        if (!this.departments.has(department)) {
            this.departments.set(department, []);
        }

        let employee = new Company.Employee(username, salary, position);
        this.departments.get(department).push(employee);
        return `New employee is hired. Name: ${username}. Position: ${position}`;
    }

    bestDepartment() {
        let sortedDepartments = [...this.departments.keys()]
            .sort((aDepartmentName, bDepartmentName) => {
                let aAverageSalary = this._getAverageSalary(aDepartmentName);
                let bAverageSalary = this._getAverageSalary(bDepartmentName);
                return bAverageSalary - aAverageSalary;
            });

        let bestDepartmentName = sortedDepartments[0];
        let bestDepartment = this.departments.get(bestDepartmentName);
        bestDepartment.sort((wA, wB) => wA.compareTo(wB));

        let bestDepartmentString =
            `Best Department is: ${bestDepartmentName}\nAverage salary: ${this._getAverageSalary(bestDepartmentName).toFixed(2)}`;
        let workersString = bestDepartment.map(x => x.toString()).join('\n');
        return `${bestDepartmentString}\n${workersString}`;
    }
}
