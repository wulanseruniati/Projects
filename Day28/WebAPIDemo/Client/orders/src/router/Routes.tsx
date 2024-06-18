import { RouteObject, createBrowserRouter } from "react-router-dom";
import App from "../App";
import CategoryForm from "../components/CategoryForm";
import CategoryTable from "../components/CategoryTable";

export const routes: RouteObject[] = [
    {
        path: '/',
        element: <App/>,
        children: [
            {path: 'createCategory', element: <CategoryForm key='create' />},
            { path: 'editCategory/:id', element: <CategoryForm key='edit' /> },
            {path: '*', element: <CategoryTable /> }
        ]
    }
]

export const router = createBrowserRouter(routes);