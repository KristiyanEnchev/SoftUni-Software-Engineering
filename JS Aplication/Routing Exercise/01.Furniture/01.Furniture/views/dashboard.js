import { getFurniture } from "../requests/requestBuffer.js";
import { dashboardTemplate } from "../templates/dashboardTemplate.js";

export async function dashboard(ctx) {
    let furniture = await getFurniture();
    let templateResult = dashboardTemplate(furniture);
    ctx.renderView(templateResult);
}