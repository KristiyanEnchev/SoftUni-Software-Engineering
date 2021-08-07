const { assert, expect } = require('chai');
const isOddOrEven = require('../02. Even Or Odd');

describe('Cheking the functionalyty of a function', () => {
    it('should return undefined if the passed value is not a string type', () => {
        let value = 1;
        let expected = undefined;

        assert.strictEqual(expected, isOddOrEven(value));
    });

    it('Should return even as a string if the lenght of the value is even number', () => {
        let str = 'Hellou';
        let expected = 'even';

        assert.strictEqual(expected, isOddOrEven(str));
    });

    it('Should return odd as a string if the lenght of the value is odd number', () => {
        let str = 'Hello';
        let expected = 'odd';

        assert.strictEqual(expected, isOddOrEven(str));
    });
});