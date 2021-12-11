import { getMyFurniture } from "../requests/requestBuffer.js";
import { myfurnitureTemplate } from "../templates/my-furnitureTemplate.js";

export async function myFurnitureView(ctx) {
    let furniture = await getMyFurniture();
    let templateResult = myfurnitureTemplate(furniture);
    ctx.renderView(templateResult);
}