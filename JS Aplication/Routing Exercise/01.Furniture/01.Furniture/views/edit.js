import { editFurniture, getFurnitureById } from "../requests/requestBuffer.js";
import { editTemplate } from "../templates/editTemplate.js";
import { validateInput } from "../validator/validatorFields.js";

export async function editView(ctx) {
    let id = ctx.params.id;
    let itemToEdit = await getFurnitureById(id);
    let templateResult = editTemplate(itemToEdit, submitHandler);
    ctx.renderView(templateResult);

    async function submitHandler(e) {
        e.preventDefault();
        let formData = new FormData(e.target);
        let make = formData.get('make');
        let model = formData.get('model');
        let year = Number(formData.get('year'));
        let description = formData.get('description');
        let price = Number(formData.get('price'));
        let img = formData.get('img');
        let material = formData.get('material');

        let data = {
            make,
            model,
            year,
            description,
            price,
            img,
            material
        }

        let isValid = validateInput(e.target, data);
        if (isValid) {

            let result = await editFurniture(JSON.stringify(data), sessionStorage.getItem('authToken'), id);
            ctx.page.redirect('/my-furniture');
        }
    }
}