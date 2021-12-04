import { render } from "../node_modules/lit-html/lit-html.js";

let main;
let nav;

function init(viewContainer, navigationContainer) {
    main = viewContainer;
    nav = navigationContainer;
}

function renderView(template) {
    render(template, main);
}

function renderNavigation(template) {
    render(template, nav);
}

function bindContext(ctx, next) {
    ctx.renderView = renderView;
    ctx.renderNavigation = renderNavigation;
    next();
}

export default {
    init,
    bindContext,
    renderView,
    renderNavigation
}