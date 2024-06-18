import { Button } from "semantic-ui-react";
import { CategoryDTO } from "../models/categoryDTO"
import apiConnector from "../api/apiConnector";
import { NavLink } from "react-router-dom";

interface Props {
    category: CategoryDTO;
}
export default function CategoryTableItem({category}: Props) {
    return (
        <>
        <tr className="center aligned">
            <td data-label="CategoryId">{category.categoryId}</td>
            <td data-label="CategoryName">{category.categoryName}</td>
            <td data-label="Description">{category.description}</td>
            <td data-label="Action">
                <Button as={NavLink} to={`editCategory/${category.categoryId}`} color="yellow" type="submit">
                    Edit
                </Button>
                <Button type="button" negative onClick={async () => {
                    await apiConnector.deleteCategory(category.categoryId!);
                    window.location.reload();
                }}>
                    Delete
                </Button>
            </td>
        </tr>
        </>
    )
}