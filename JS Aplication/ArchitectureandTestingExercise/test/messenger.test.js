const { chromium } = require('playwright-chromium');
const { expect } = require('chai');

const endpoint = 'http://localhost:3030/jsonstore/messenger';
const url = 'http://localhost:5502/Messenger';

function jsonT(data) {
    return {
        status: 200,
        headers: {
            'Access-Control-Allow-Origin': '*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    };
}
let browser;
let context;
let page;

describe('E2E tests messanger', function () {
    this.timeout(6000);

    before(async () => {
        // browser = await chromium.launch({ headless: false, slowMo: 500 });
        browser = await chromium.launch();
    });

    after(async () => {
        await browser.close();
    });

    beforeEach(async () => {
        context = await browser.newContext();
        await context.route('**/*.{png,jpg,jpeg}', route => route.abort());
        await context.route(url => {
            return url.hostname != 'localhost';
        }, route => route.abort());

        page = await context.newPage();
    });

    afterEach(async () => {
        await page.close();
        await context.close();
    });

    it('Should load messages from server', async () => {
        await page.goto(url);
        const mock = {
            author: 'kiko',
            content: 'AlaBala',
        };
        page.route('http://localhost:3030/jsonstore/messenger', route => route.fulfill(jsonT(mock)));
        const [response] = await Promise.all([
            page.waitForResponse('http://localhost:3030/jsonstore/messenger'),
            page.click('#refresh')
        ]);
        let result = await response.json();
        expect(result).to.eql(mock);
    })

    it('Should send messages to the server', async () => {
        await page.goto(url);

        const endpoint = 'http://localhost:3030/jsonstore/messenger';
        const mock = {
            author: 'kiko',
            content: 'AlaBala',
        };
        page.route(endpoint, route => route.fulfill(jsonT(mock)));
        await page.fill('#author', 'kiko');
        await page.fill('#content', 'AlaBala');

        const [response] = await Promise.all([
            page.waitForResponse(endpoint),
            page.click('#submit')
        ]);

        const postData = JSON.parse(response.request().postData());
        expect(postData.author).to.equal(mock.author);
        expect(postData.content).to.equal(mock.content);
    });

    it('should clear inputs', async () => {
        const mock = {
            author: 'kiko',
            content: 'AlaBala',
        };
        let requestData = undefined;
        let expected = {
            author: 'gosho',
            content: 'gosho message'
        };
        await page.route('**/jsonstore/messenger', (route, request) => {
            if (request.method().toLowerCase() === 'post') {
                requestData = request.postData();
                route.fulfill(jsonT(mock))
            }
        });

        await page.goto(url);

        await page.fill('#author', expected.author);
        await page.fill('#content', expected.content);

        const [response] = await Promise.all([
            page.waitForResponse('**/jsonstore/messenger'),
            page.click('#submit')
        ]);

        let authorValue = await page.$eval('#author', a => a.value);
        let contentValue = await page.$eval('#content', a => a.value);

        expect(authorValue).to.equal('');
        expect(contentValue).to.equal('');
    });
})