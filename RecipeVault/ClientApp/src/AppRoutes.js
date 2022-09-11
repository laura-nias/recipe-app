import { AddRecipe } from "./components/AddRecipe";
import { Home } from "./components/Home";

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/addrecipe',
        element: <AddRecipe />
    }
];

export default AppRoutes;
