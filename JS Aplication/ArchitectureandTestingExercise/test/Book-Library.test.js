const { chromium } = require('playwright-chromium');
const { expect } = require('chai');

const endpoint = 'http://localhost:3030/jsonstore/collections/books';
const url = `http://localhost:5502/Book-Library`;

function json(data) {
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

describe('E2E tests book-library', function () {
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

        // block intensive resources and external calls (page routes take precedence)
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

    it('load index', async () => {
        await page.goto('http://localhost:5502/Book-Library');

        const content = await page.content();
        expect(content).to.contains('FORM');
        expect(content).to.contains('TITLE');
        expect(content).to.contains('AUTHOR');
        expect(content).to.contains('Action');
    });

    it('load books', async () => {
        await page.goto(url);

        await page.click('#loadBooks');
        expect('tbody').to.not.be.empty;
    });

    it('add book', async () => {
        await page.goto(url);

        const mock = {
            title: 'title',
            author: 'author'
        };
        page.route(endpoint, route => route.fulfill(json(mock)));

        await page.fill('#createForm > [name="title"]', 'title')
        await page.fill('#createForm > [name="author"]', 'author')

        const [response] = await Promise.all([
            page.waitForResponse(endpoint),
            page.click('#submitBtn')
        ]);

        const postData = JSON.parse(response.request().postData());
        expect(postData.author).to.eql('author');
        expect(postData.title).to.eql('title');
    });

    it('add book with empty input should trigger alert', async () => {

        page.on('dialog', async dialog => {
            console.log(dialog.message());
            expect(dialog.message()).to.eql('All fields are required!');
            await dialog.dismiss();
        });
        await page.goto(url);
        await page.click("#submitBtn")
    });

    it('edit book', async () => {

        await page.goto(url);
        await page.click('#loadBooks');
        await page.click('.editBtn');
        let t = await page.waitForSelector('#editForm>h3');
        const title = await t.textContent('h3');
        expect(title).to.equal('Edit FORM');
    });

    // it('Should send messages to the server', async () => {
    //     await page.goto(url);
    //     await page.click('#loadBooks');
    //     await page.click('.editBtn');

    //     const mock = {
    //         title: 'title',
    //         author: 'author'
    //     };
    //     page.route(endpoint, route => route.fulfill(json(mock)));

    //     await page.fill('#editForm > [name="title"]', 'title')
    //     await page.fill('#editForm > [name="author"]', 'author')

    //     const [response] = await Promise.all([
    //         page.waitForResponse(endpoint),
    //         page.click('#saveBtn')
    //     ]);

    //     const postData = JSON.parse(response.request().postData());
    //     expect(postData.author).to.eql(mock.author);
    //     expect(postData.title).to.eql(mock.title);
    // });

    it('delete book', async () => {
        await page.goto(url);

        await page.click('#loadBooks');
        await page.click('.deleteBtn');
    });
})