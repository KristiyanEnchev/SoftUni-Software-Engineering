import { navigationTemplate } from "../templates/navigationTemplate.js";

export async function navigation(ctx, next) {
    let isLogedIn = sessionStorage.getItem('authToken');
    let loged = false;
    if (isLogedIn != null) {
        loged = true;
    }
    let templateResult = navigationTemplate(loged, ctx);
    ctx.renderNavigation(templateResult);
    next();
}