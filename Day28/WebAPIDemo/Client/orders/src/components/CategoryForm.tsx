import { ChangeEvent, useEffect, useState } from "react";
import { NavLink, useNavigate, useParams } from "react-router-dom";
import { CategoryDTO } from "../models/categoryDTO";
import apiConnector from "../api/apiConnector";
import { Button, Form, Segment } from "semantic-ui-react";

export default function CategoryForm() {
    const { id } = useParams<{ id: string }>();
    const navigate = useNavigate();
    
    const [category, setCategory] = useState<CategoryDTO>({
        categoryId: undefined,
        categoryName: '',
        description: ''
    });

    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        if (id) {
            const categoryId = parseInt(id, 10); // Convert the id to a number
            if (!isNaN(categoryId)) {
                apiConnector.getCategoryById(categoryId)
                    .then(category => {
                        if (category) {
                            setCategory(category);
                        } else {
                            setError('Category not found.');
                        }
                        setLoading(false);
                    })
                    .catch(error => {
                        setError('Error fetching category.');
                        setLoading(false);
                    });
            } else {
                setError('Invalid category ID.');
                setLoading(false);
            }
        } else {
            setLoading(false);
        }
    }, [id]);

    function handleSubmit() {
        if (!category.categoryId) {
            apiConnector.createCategory(category)
                .then(() => navigate('/'))
                .catch(() => setError('Error creating category.'));
        } else {
            apiConnector.editCategory(category)
                .then(() => navigate('/'))
                .catch(() => setError('Error editing category.'));
        }
    }

    function handleInputChange(event: ChangeEvent<HTMLInputElement>) {
        const { name, value } = event.target;
        setCategory({ ...category, [name]: value });
    }

    if (loading) return <div>Loading...</div>;
    if (error) return <div>{error}</div>;

    return (
        <Segment clearing inverted>
            <Form onSubmit={handleSubmit} autoComplete='off' className='ui inverted form'>
                <Form.Input placeholder="Category Name" name='categoryName' value={category.categoryName} onChange={handleInputChange} />
                <Form.Input placeholder="Description" name='description' value={category.description} onChange={handleInputChange} />
                <Button floated="right" positive type="submit" content="Submit" />
                <Button as={NavLink} to='/' floated="right" type="button" content="Cancel" />
            </Form>
        </Segment>
    );
}
