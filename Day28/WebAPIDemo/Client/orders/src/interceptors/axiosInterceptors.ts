import axios, { AxiosResponse } from "axios";

let isInterceptorSetup = false;

export const setupErrorHandlingInterceptor = () => {
    if (!isInterceptorSetup) {
        axios.interceptors.response.use(
            (response: AxiosResponse) => response,
            (error) => {
                if (error.response) {
                    const statusCode = error.response.statusCode;

                    switch (statusCode) {
                        case 400:
                            console.log('Maap');
                            break;
                        case 401:
                            console.log('Unauthorized');
                            break;
                        case 403:
                            console.log('Forbidden');
                            break;
                        case 404:
                            console.log('Not found');
                            break;
                        default:
                            console.log('Generic error');
                    }
                }
                return Promise.reject(error);
            }
        )
        isInterceptorSetup = true;
    }
}