const createCalculator = require('../07. Add-Subtract');
const { assert, expect } = require('chai');

describe('Testing all functionalitys', () => {
    describe('Testing Add function', () => {

        it('Should increae value with the given number when add comand is iniciated', () => {
            let calculator = createCalculator();
            let expected = 10;
            calculator.add(10);
            assert.strictEqual(expected, calculator.get());
        });

        it('Should pass if a number as string is provided', () => {
            let calculator = createCalculator();
            let expected = 10;
            calculator.add('10');
            assert.strictEqual(expected, calculator.get());
        });

        it('Should fail if a nonNumber string is provided', () => {
            let calculator = createCalculator();
            let expected = undefined;
            assert.equal(expected, calculator.add('pesho'));
        });
    });

    describe('Testing get function', () => {

        it('Should return 0 if its the first operation', () => {
            let expected = 0;
            let calculator = createCalculator();

            assert.strictEqual(expected, calculator.get());
        });
    });

    describe('Testing subtract function', () => {

        it('Should increae value with the given number when add comand is iniciated', () => {
            let calculator = createCalculator();
            let expected = -10;
            calculator.subtract(10);
            assert.strictEqual(expected, calculator.get());

        });

        it('Should pass if a number as string is provided', () => {
            let calculator = createCalculator();
            let expected = -10;
            calculator.subtract('10');
            assert.strictEqual(expected, calculator.get());
        });

        it('Should fail if a nonNumber string is provided', () => {
            let calculator = createCalculator();
            let expected = undefined;
            assert.equal(expected, calculator.subtract('pesho'));
        });
    });
});