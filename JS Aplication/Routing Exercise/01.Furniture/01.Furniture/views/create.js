import { create } from "../requests/requestBuffer.js";
import { createTemplate } from "../templates/createTemplate.js";
import { validateInput } from "../validator/validatorFields.js";


export async function createView(ctx) {
    let templateResult = createTemplate(submitHandler);
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

            let result = await create(JSON.stringify(data), sessionStorage.getItem('authToken'));
            ctx.page.redirect('/dashboard');
        }
    }
}

