describe('StringBuilder', () => {
    describe('constructor', () => {

        it('Should initialize with empty when passed undefined', () => {
            let sb = new StringBuilder();
            expect(sb.toString()).to.equal('');
        });

        it('Should throw when called with a non-string', () => {
            expect(() => new StringBuilder(25)).to.throw(TypeError, 'Argument must be a string');
            expect(() => new StringBuilder(null)).to.throw(TypeError, 'Argument must be a string');
        });

        it('Should initialize with correct value passed a valid string', () => {
            let expected = 'hello';
            let sb = new StringBuilder(expected);
            expect(sb.toString()).to.equal(expected);
        });
    });

    describe('append', () => {
        it('Should throw when called with a non-string', () => {
            let sb = new StringBuilder();
            let invalidString = 1.23;
            expect(() => sb.append(invalidString)).to.throw(TypeError, 'Argument must be a string');
            expect(() => sb.append(true)).to.throw(TypeError, 'Argument must be a string');
        });

        it('Should append string at the end when passed a valid string', () => {
            let initial = 'test';
            let validString = 'wow';
            let validString2 = 'haha';
            let expected = 'testwow';
            let expected2 = 'testwowhaha';
            
            let sb = new StringBuilder(initial);

            sb.append(validString);
            expect(sb.toString()).to.equal(expected);

            sb.append(validString2);
            expect(sb.toString()).to.equal(expected2);
        });

        it('Should correctly append only the passed string chars', () => {
            let initial = 'test';
            let validString = 'wow';
            let validString2 = '123';
            
            let expected = 'testwow';
            let expected2 = 'testwow123';
            let expected3 = 'testwow23';
            
            let sb = new StringBuilder(initial);

            sb.append(validString);
            expect(sb.toString()).to.equal(expected);

            sb.append(validString2);
            expect(sb.toString()).to.equal(expected2);

            sb.remove(7,1);
            expect(sb.toString()).to.equal(expected3);
        });
    });

    describe('prepend', () => {
        it('Should throw when called with a non-string', () => {
            let sb = new StringBuilder();
            let invalidString = undefined;
            expect(() => sb.prepend(invalidString)).to.throw(TypeError, 'Argument must be a string');
            expect(() => sb.prepend(true)).to.throw(TypeError, 'Argument must be a string');
        });

        it('Should prepend string to the beginning when passed a valid string', () => {
            let initial = 'car';
            let sb = new StringBuilder(initial);
            let validString = 'fast ';
            let validString2 = 'very ';
            let expected = 'fast car';
            let expected2 = 'very fast car';

            sb.prepend(validString);
            expect(sb.toString()).to.equal(expected);

            sb.prepend(validString2);
            expect(sb.toString()).to.equal(expected2);
        });

        it('Should correctly prepend only the passed string chars', () => {
            let initial = 'car';
            let sb = new StringBuilder(initial);
            let validString = 'fast ';
            let validString2 = 'very ';

            let expected = 'fast car';
            let expected2 = 'very fast car';
            let expected3 = 'very fat car';
            sb.prepend(validString);
            expect(sb.toString()).to.equal(expected);

            sb.prepend(validString2);
            expect(sb.toString()).to.equal(expected2);

            sb.remove(7, 1);
            expect(sb.toString()).to.equal(expected3);
        });
    });

    describe('insertAt', () => {
        it('Should throw when called with a non-string', () => {
            let sb = new StringBuilder();
            let invalidString = undefined;
            expect(() => sb.insertAt(invalidString, 0)).to.throw(TypeError, 'Argument must be a string');
            expect(() => sb.insertAt(22, 0)).to.throw(TypeError, 'Argument must be a string');
        });

        it('Should insert chars at target index when passed a valid string', () => {
            let initial = 'car';
            let sb = new StringBuilder(initial);
            let validString = 'very ';
            let validString2 = 'fast ';

            let expected = 'very car';
            let expected2 = 'very fast car';

            sb.insertAt(validString, 0);
            expect(sb.toString()).to.equal(expected);

            sb.insertAt(validString2, 5);
            expect(sb.toString()).to.equal(expected2);
        });

        it('Should correctly insert only chars', () => {
            let initial = ' faast';
            let sb = new StringBuilder(initial);
            let validString = 'car';
            let validString2 = 'is ';

            let expected = 'car faast';
            let expected2 = 'car is faast';
            let expected3 = 'car is fat';

            sb.insertAt(validString, 0);
            expect(sb.toString()).to.equal(expected);

            sb.insertAt(validString2, 4);
            expect(sb.toString()).to.equal(expected2);

            sb.remove(9,2);
            expect(sb.toString()).to.equal(expected3);
        });
    });

    describe('remove', () => {
        it('Should remove the specified length at target index', () => {
            let initial = 'cars are fast';
            let sb = new StringBuilder(initial);

            let expected = 'c are fast';
            let expected3 = 'c are fat';

            sb.remove(1, 3);
            expect(sb.toString()).to.equal(expected);

            sb.remove(8, 1);
            expect(sb.toString()).to.equal(expected3);
        });
    });

    describe('toString', () => {
        it('Should return correct string representation', () => {
            let initial = 'testing';
            let sb = new StringBuilder(initial);
            expect(sb.toString()).to.equal(initial);
        });

        it('Should return empty string when string builder is empty', () => {
            let sb = new StringBuilder();
            expect(sb.toString()).to.equal('');
            let sb2 = new StringBuilder('test');
            sb2.remove(0,4);
            expect(sb2.toString()).to.equal('');
        });
    });
});