function listProcessor(params) {
    let commands = {
        add: str => result.push(str),
        remove: n => result = result.filter(x => x != n),
        print: () => console.log(result.join(','))
    }

    let result = [];

    for (const line of params) {
        let [cmd, arg] = line.split(' ');
        commands[cmd](arg);
    }
}

listProcessor(['add hello', 'add again', 'remove hello', 'add again', 'print']);


listProcessor(['add pesho', 'add george', 'add peter', 'remove peter', 'print']);