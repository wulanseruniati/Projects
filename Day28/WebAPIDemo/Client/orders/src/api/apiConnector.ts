import axios, { AxiosResponse } from "axios";
import { CategoryDTO } from "../models/categoryDTO.ts";
import { API_BASE_URL } from "../config.ts";

const apiConnector = {
    getCategories: async (): Promise<CategoryDTO[]> => {
        try {
            const response: AxiosResponse<{ categoryDTOs: CategoryDTO[] }> =
                await axios.get(`${API_BASE_URL}/Category`);
            const categories = response.data.categoryDTOs.map(category => ({
                ...category
            }));
            return categories;
        } catch (error) {
            console.error('Error fetching categories', error);
            return []; // Return an empty array in case of error
        }
    },

    createCategory: async (category: CategoryDTO): Promise<void> => {
        try {
            await axios.post<number>(`${API_BASE_URL}/Category`, category);
        } catch (error) {
            console.log(error);
            throw(error);
        }
    },

    editCategory: async (category: CategoryDTO): Promise<void> => {
        try {
            await axios.put<number>(`${API_BASE_URL}/Category/${category.categoryId}`, category);
        } catch (error) {
            console.log(error);
            throw(error);
        }
    },

    deleteCategory: async (categoryId: number): Promise<void> => {
        try {
            await axios.delete<number>(`${API_BASE_URL}/Category/${categoryId}`);
        } catch (error) {
            console.log(error);
            throw(error);
        }
    },

    getCategoryById: async (categoryId: number): Promise<CategoryDTO | undefined> => {
        try {
            const response: AxiosResponse<CategoryDTO> = await axios.get(`${API_BASE_URL}/Category/${categoryId}`);
            return response.data; // Assuming the API returns the category object directly
        } catch (error) {
            console.log(error);
            throw(error);
        }
    }
}

export default apiConnector;
