import { deleteRequest, getFurnitureById } from "../requests/requestBuffer.js";
import { detailsTemplate } from "../templates/detailsTemplate.js";

export async function detailsView(ctx) {
    let id = ctx.params.id;
    let item = await getFurnitureById(id);
    let templateResult = detailsTemplate(item, deleteFunc);
    ctx.renderView(templateResult);

    async function deleteFunc(e) {
        e.preventDefault();
        const confirmation = confirm('Are you sure you want to delete this item?');
        if (confirmation) {
            await deleteRequest(id, sessionStorage.getItem('authToken'))
            ctx.page.redirect('/dashboard');
        }
    }
}

