import { render } from "./../node_modules/lit-html/lit-html.js";
import { indexPage, formTemplate, tableTemp } from './templates.js'
import { getBook, loadBooks, deleteBook, updateBook, createBook } from './requestsHandler.js'
import { checkValidInput, clearInputs, getId } from './helper.js'

const body = document.querySelector('body')
render(indexPage(), body)

const clearInput = () => clearInputs(
    document.querySelector('input[name="title"]'),
    document.querySelector('input[name="author"]')
)


document.addEventListener('click', e => {
    if (e.target.tagName === 'BUTTON') {
        const id = e.target.id ? e.target.id : e.target.className

        const actions = {
            'loadBooks': async () => {
                const booksData = Object.entries(await loadBooks())

                render(indexPage(booksData), body)
            },
            'editBookBtn': async () => {
                const bookResponse = await getBook(getId(e))

                render(
                    formTemplate('editForm', 'Save', getId(e),),
                    document.getElementById('formDiv')
                )

                document.querySelector('input[name="title"]').value = bookResponse.title
                document.querySelector('input[name="author"]').value = bookResponse.author
            },
            'deleteBookBtn': async () => {
                await deleteBook(getId(e))
                const bookData = await loadBooks()

                render(tableTemp(Object.entries(bookData)), document.querySelector('table'))
            },
        }

        actions[id]()
    }
})

document.addEventListener('submit', e => {
    e.preventDefault()
    const className = e.target.className
    const formData = new FormData(e.target)
    const data = Object.fromEntries([...formData.entries()])

    const actions = {
        editForm: async () => {
            await updateBook(e.target.id, data)

            render(indexPage(Object.entries(await loadBooks())), body)
            render(
                formTemplate('createForm', 'Submit'),
                document.getElementById('formDiv')
            )
            clearInput()
        },
        createForm: async () => {
            await createBook(data)
            clearInput()
            render(indexPage(Object.entries(await loadBooks())), body)
        }
    }

    if (checkValidInput(Object.values(data))) {
        actions[className]()
    }
})