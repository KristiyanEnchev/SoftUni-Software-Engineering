const { assert, expect } = require('chai');
const rgbToHexColor = require('../06. RGB to Hex');

describe('Test all functionality', () => {
    describe('Testing the first argument', () => {

        it('Should return undefined if the first argument is not a number', () => {
            let expected = undefined;
            let actual = rgbToHexColor('blue', 2, 3);

            assert.strictEqual(expected, actual);
        });

        it('Should return undefined if the first argument is less than zero', () => {
            let expected = undefined;
            let actual = rgbToHexColor(-1, 2, 3);

            assert.strictEqual(expected, actual);
        });

        it('Should pass if the first argument is zero', () => {
            let expected = '#000203';
            let actual = rgbToHexColor(0, 2, 3);

            assert.strictEqual(expected, actual);
        });

        it('Should return undefined if the first argument is more than 255', () => {
            let expected = undefined;
            let actual = rgbToHexColor(256, 2, 3);

            assert.strictEqual(expected, actual);
        });

        it('Should pass if the first argument is 255', () => {
            let expected = '#FF0203';
            let actual = rgbToHexColor(255, 2, 3);

            assert.strictEqual(expected, actual);
        });
    });

    describe('Testing the second argument', () => {

        it('Should return undefined if the second argument is not a number', () => {
            let expected = undefined;
            let actual = rgbToHexColor(2, 'two', 3);

            assert.strictEqual(expected, actual);
        });

        it('Should return undefined if the second argument is less than zero', () => {
            let expected = undefined;
            let actual = rgbToHexColor(2, -1, 3);

            assert.strictEqual(expected, actual);
        });

        it('Should pass if the second argument is zero', () => {
            let expected = '#020003';
            let actual = rgbToHexColor(2, 0, 3);

            assert.strictEqual(expected, actual);
        });

        it('Should return undefined if the second argument is more than 255', () => {
            let expected = undefined;
            let actual = rgbToHexColor(2, 256, 3);

            assert.strictEqual(expected, actual);
        });

        it('Should pass if the second argument is 255', () => {
            let expected = '#02FF03';
            let actual = rgbToHexColor(2, 255, 3);

            assert.strictEqual(expected, actual);
        });
    });

    describe('Testing the thurd argument', () => {

        it('Should return undefined if the thurd argument is not a number', () => {
            let expected = undefined;
            let actual = rgbToHexColor(2, 3, 'three');

            assert.strictEqual(expected, actual);
        });

        it('Should return undefined if the thurd argument is less than zero', () => {
            let expected = undefined;
            let actual = rgbToHexColor(2, 3, -1);

            assert.strictEqual(expected, actual);
        });

        it('Should pass if the thurd argument is zero', () => {
            let expected = '#020200';
            let actual = rgbToHexColor(2, 2, 0);

            assert.strictEqual(expected, actual);
        });

        it('Should return undefined if the thurd argument is more than 255', () => {
            let expected = undefined;
            let actual = rgbToHexColor(2, 3, 300);

            assert.strictEqual(expected, actual);
        });

        it('Should pass if the thurd argument is 255', () => {
            let expected = '#0203FF';
            let actual = rgbToHexColor(2, 3, 255);

            assert.strictEqual(expected, actual);
        });
    });
});