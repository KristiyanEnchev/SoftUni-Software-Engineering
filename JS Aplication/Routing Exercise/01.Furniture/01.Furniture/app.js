import page from "../node_modules/page/page.mjs";
import renderer from "./renderPasser/renderer.js";
import { logout } from "./requests/requestBuffer.js";
import { createView } from "./views/create.js";
import { dashboard } from "./views/dashboard.js";
import { detailsView } from "./views/details.js";
import { editView } from "./views/edit.js";
import { loginView } from "./views/login.js";
import { myFurnitureView } from "./views/my-furniture.js";
import { navigation } from "./views/navigarion.js";
import { registerView } from "./views/registration.js";

const navigationContainer = document.getElementById('navigation');
const viewContainer = document.getElementById('viewContainer');
renderer.init(viewContainer, navigationContainer);

page('/', '/dashboard');
page('/index.html', '/dashboard');

page(renderer.bindContext);
page(navigation);

page('/dashboard', dashboard);
page('/register', registerView);
page('/login', loginView);
page('/create', createView);
page('/my-furniture', myFurnitureView);
page('/logout', async (context) => { await logout(sessionStorage.getItem('authToken')); context.page.redirect('/login'); });
page('/details/:id', detailsView);
page('/edit/:id', editView);

page.start();