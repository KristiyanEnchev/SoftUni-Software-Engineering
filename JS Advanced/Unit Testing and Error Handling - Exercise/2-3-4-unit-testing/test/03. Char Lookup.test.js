const { assert, expect } = require('chai');
const lookupChar = require('../03. Char Lookup');

describe('Cheking the functionality of a function', () => {

    it('Shoulr return undefined if the first argument is not a string', () => {
        let arg1 = 123;
        let arg2 = 1234;
        let arg3 = {};
        let arg4 = NaN;
        let arg5 = 1.23;


        let expected = undefined;

        assert.strictEqual(expected, lookupChar(arg1, arg2));
        assert.strictEqual(expected, lookupChar(arg1, arg3));
        assert.strictEqual(expected, lookupChar(arg1, arg4));
        assert.strictEqual(expected, lookupChar(arg1, arg5));
    });


    it('Shoulr return undefined if the second argument is not a number', () => {
        let arg1 = '123';
        let arg2 = '1234';

        let expected = undefined;

        assert.strictEqual(expected, lookupChar(arg1, arg2));
    });

    it('Shoulr return undefined if the second argument is floating point number', () => {
        let arg1 = '123';
        let arg2 = 2.2;

        let expected = undefined;

        assert.strictEqual(expected, lookupChar(arg1, arg2));
    });

    it('Shoulr return massege if the index is smaller or equal to the length of the string', () => {
        let arg1 = '123';
        let arg2 = 4;
        let arg3 = arg1.length;

        let expected = "Incorrect index";

        assert.strictEqual(expected, lookupChar(arg1, arg2));
        assert.strictEqual(expected, lookupChar(arg1, arg3));
    });

    it('Shoulr pass if the second argument(index) is smaller than the lenght of the firs argument(string)', () => {
        let arg1 = '123';
        let arg2 = 2;
        let arg3 = arg1.length;

        let expected = '3';

        assert.strictEqual(expected, lookupChar(arg1, arg2));
        assert.strictEqual(expected, lookupChar(arg1, arg3 -1));
    });

    it('Shoulr return massege if the index is smaller than zero', () => {
        let arg1 = '123';
        let arg2 = -1;

        let expected = "Incorrect index";

        assert.strictEqual(expected, lookupChar(arg1, arg2));
    });

    it('Shoulr return single charecter', () => {
        let arg1 = '123';
        let arg2 = 0;

        let expected = "1";

        assert.strictEqual(expected, lookupChar(arg1, arg2));
    });
});