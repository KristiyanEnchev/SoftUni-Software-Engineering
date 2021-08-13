const { assert, expect } = require('chai');
const isSymmetric = require('../05. Check for Symmetry');

describe('Testing array symmetry', () => {

    it('Should return false if non array value is passed', () => {

        let expected = false;

        assert.strictEqual(expected, isSymmetric(2));
        assert.strictEqual(expected, isSymmetric({}));
        assert.strictEqual(expected, isSymmetric('2'));
    });

    it('Should pass when a symmetric array is provaded', () => {
        let arr = [1, 2, 3, 2, 1];
        let expected = true;

        assert.strictEqual(expected, isSymmetric(arr));
    });

    it('Should fail when a nonsymmetric array is provaded', () => {
        let arr = [1, 2, 3, 3, 1];
        let expected = false;

        assert.strictEqual(expected, isSymmetric(arr));
    });

    it('Shoud fail if the values are not from the same type', () => {
        let arr = [1,'1'];
        let expected = false;

        assert.strictEqual(expected, isSymmetric(arr));
    });

});