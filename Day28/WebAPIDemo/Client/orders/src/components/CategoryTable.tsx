import { useEffect, useState } from "react"
import { CategoryDTO } from "../models/categoryDTO"
import apiConnector from "../api/apiConnector";
import { Button, Container } from "semantic-ui-react";
import CategoryTableItem from "./CategoryTableItem";
import { NavLink } from "react-router-dom";

export default function CategoryTable() {
    const [categories, setCategories] = useState<CategoryDTO[] | undefined>([]);

    useEffect(() => {
        const fetchData = async () => {
            const fetchedCategories = await apiConnector.getCategories();
            setCategories(fetchedCategories);
        }

        fetchData();
    }, []);
    return (
        <>
            <Container className="container-style">
                <table className="ui inverted table">
                    <thead style={{textAlign: 'center'}}>
                        <tr>
                            <th>Category Id</th>
                            <th>Category Name</th>
                            <th>Category Description</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        {categories?.length !== 0 && (
                            categories?.map((category,index) => (
                                <CategoryTableItem key={index} category ={category}/>
                            ))
                        )}
                    </tbody>
                </table>
                <Button as={NavLink} to="createCategory" floated="right" type="button" content="Create Category" positive/>
            </Container>
        </>
    )
}