import { html } from "../node_modules/lit-html/lit-html.js";

export const navigationTemplate = (loged, ctx) => html`
<h1><a href="/">Furniture Store</a></h1>
<nav>
    <a id="catalogLink" href="/dashboard" class=${ctx.pathname == '/dashboard' ? 'active' : undefined}>Dashboard</a>
    ${loged 
        ? 
        html`<div id="user">
        <a id="createLink" href="/create" class=${ctx.pathname == '/create' ? 'active' : undefined}>Create Furniture</a>
        <a id="profileLink" href="/my-furniture" class=${ctx.pathname == '/my-furniture' ? 'active' : undefined}>My Publications</a>
        <a id="logoutBtn" href="/logout">Logout</a>
    </div>`
        :
        html`<div id="guest">
        <a id="loginLink" href="/login" class=${ctx.pathname == '/login' ? 'active' : undefined}>Login</a>
        <a id="registerLink" href="/register" class=${ctx.pathname == '/register' ? 'active' : undefined}>Register</a>
    </div>`}
</nav>`;