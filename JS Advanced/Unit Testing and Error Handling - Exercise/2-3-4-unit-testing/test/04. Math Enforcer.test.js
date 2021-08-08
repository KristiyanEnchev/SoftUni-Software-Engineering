const { assert, expect } = require('chai');
const mathEnforcer = require('../04. Math Enforcer');

describe('Cheking the functionality of an object', () => {

    describe('Cheking the addFive methood in the Object', () => {
        it('Should return undefined if the argument passed is not a number', () => {
            let arg = '123';
            let expected = undefined;
            assert.strictEqual(expected, mathEnforcer.addFive(arg));
        });

        it('Should pass if the agrument passed is floating point number', () => {
            let arg = 2.2;
            let expected = 7.2;
            assert.strictEqual(expected, mathEnforcer.addFive(arg));
        });

        it('Should pass if the agrument passed is negative number', () => {
            let arg = -5;
            let expected = 0;
            assert.strictEqual(expected, mathEnforcer.addFive(arg));
        });

        it('Should add exactly 5', () => {
            let arg = 5;
            let expected = 10;
            assert.strictEqual(expected, mathEnforcer.addFive(arg));
        });
    });

    describe('Cheking the subtractTen methood in the Object', () => {
        it('Should return undefined if the argument passed is not a number', () => {
            let arg = '123';
            let expected = undefined;
            assert.strictEqual(expected, mathEnforcer.subtractTen(arg));
        });

        it('Should pass if the agrument passed is floating point number', () => {
            let arg = 2.2;
            let expected = -7.8;
            assert.strictEqual(expected, mathEnforcer.subtractTen(arg));
        });

        it('Should pass if the agrument passed is negative number', () => {
            let arg = -5;
            let expected = -15;
            assert.strictEqual(expected, mathEnforcer.subtractTen(arg));
        });

        it('Should subtract exactly 10', () => {
            let arg = 10;
            let expected = 0;
            assert.strictEqual(expected, mathEnforcer.subtractTen(arg));
        });
    });

    describe('Cheking the sum methood in the Object', () => {
        it('Should return undefined if the argument one is not a number', () => {
            let arg1 = '123';
            let arg2 = 5;
            let expected = undefined;
            assert.strictEqual(expected, mathEnforcer.sum(arg1, arg2));
        });

        it('Should return undefined if the argument two is not a number', () => {
            let arg1 = 3;
            let arg2 = '123';
            let expected = undefined;
            assert.strictEqual(expected, mathEnforcer.sum(arg1, arg2));
        });

        it('Should return undefined if both arguments are not a number', () => {
            let arg1 = '123';
            let arg2 = '123';
            let expected = undefined;
            assert.strictEqual(expected, mathEnforcer.sum(arg1, arg2));
        });

        it('Should return the sum of both arguments', () => {
            let arg1 = 2;
            let arg2 = 3;
            let expected = 5;
            assert.strictEqual(expected, mathEnforcer.sum(arg1, arg2));
        });

        it('Should return the sum of both arguments even if there is negative inputs', () => {
            let arg1 = -2;
            let arg2 = 3;
            let expected = 1;
            assert.strictEqual(expected, mathEnforcer.sum(arg1, arg2));
        });

        it('Should return the sum of both arguments even if there isfloating point inputs', () => {
            let arg1 = 2.2;
            let arg2 = 3;
            let expected = 5.2;
            assert.strictEqual(expected, mathEnforcer.sum(arg1, arg2));
        });

        it('Should return the sum of both arguments even if there isfloating point inputs', () => {
            let arg1 = 2.2;
            let arg2 = 3.2;
            let expected = 5.4;
            assert.strictEqual(expected, mathEnforcer.sum(arg1, arg2));
        });

        it('Should return undefined if invalid number of params is passed', () => {
            let arg1 = 2;
            let arg2 = 3;
            let expected = undefined;
            assert.strictEqual(expected,mathEnforcer.sum(arg1,'Dimitrichko',arg2))
        });

        it('Should return undefined if no params are passed', () => {
            let expected = undefined;
            assert.strictEqual(expected,mathEnforcer.sum())
        });
    });
});