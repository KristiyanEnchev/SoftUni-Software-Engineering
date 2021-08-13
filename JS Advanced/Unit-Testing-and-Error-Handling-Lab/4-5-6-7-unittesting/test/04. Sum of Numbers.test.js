const sum = require('../04. Sum of Numbers');
const {assert, expect} = require('chai');

it('Should add positive numbers', () => {
    let input = [1, 2, 3, 4, 5];
    let expectedResult = 15;

    let actualResult = sum(input);

    assert.strictEqual(expectedResult, actualResult);
});

it('Should return false when adding positive numbers', () => {
    let input = [10, 20 ,30];
    let expected = 15;

    let actualResult = sum(input);

    assert.notEqual(actualResult, expected);
});

it('should pass when adding negative numbers', () => {
    let input = [-1, -2, -3];
    let expected = -6;

    let actualResult = sum(input);

    assert.equal(actualResult, expected);
});