export async function getItems() {
    const response = await fetch('http://localhost:3030/jsonstore/advanced/table')

    if (!response.ok) {
        const error = await response.json();
        alert(error.message);
        throw new Error(error.message);
    }

    const data = response.json();

    return data;
}

export async function postInDropdownItems(body) {
    const response = await fetch('http://localhost:3030/jsonstore/advanced/dropdown', {
        method: 'post',
        headers: { 'Content-type': 'Application/json' },
        body
    })

    if (!response.ok) {
        const error = await response.json();
        alert(error.message);
        throw new Error(error.message);
    }

    const data = await response.json();

    return data;
}