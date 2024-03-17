import axios, { AxiosError, AxiosResponse } from "axios";
import { toast } from "react-toastify";

axios.defaults.baseURL = "http://localhost:5000/api/";

const responseBody = (response: AxiosResponse) => response.data;

// axios.interceptors.request.use(config => {
//     const token = store.getState().account.user?.token;
//     if (token) config.headers.Authorization = `Bearer ${token}`;
//     return config;
// })

axios.interceptors.response.use( async response => {
    return response;
}, (error: AxiosError) => {
    const {data, status} = error.response as AxiosResponse;
    switch (status) {
        case 400:
            if(data.errors) {
                const modelStateErrors: string[] = [];
                for (const key in data.errors) {
                    modelStateErrors.push(data.errors[key])
                }
                throw modelStateErrors.flat();
            }
            toast.error(data.title);
            break;
        case 401:
            toast.error(data.title);
            break;
        case 500:
            toast.error(data.title);
            break;
    }
    return Promise.reject(error.response);
})

const requests = {
    get: (url: string, params?: URLSearchParams) => axios.get(url, {params}).then(responseBody),
    post: (url: string, body: object) => axios.post(url, body).then(responseBody),
    delete: (url: string) => axios.delete(url).then(responseBody),
    postForm: (url: string, data: FormData) => axios.post(url, data, {
        headers: {"Content-type": "multipart/form-data"}
    }).then(responseBody),
    putForm: (url: string, data: FormData) => axios.put(url, data, {
        headers: {"Content-type": "multipart/form-data"}
    }).then(responseBody)
}

const Cocktail = {
    listBy: (alcoholType: number) => requests.get(`Cocktail?alcoholType=${alcoholType}`),
    details: (id: number) => requests.get(`Cocktail/id?id=${id}`)
}

const Account = {
    login: (values: object) => requests.post("Account/login", values),
    register: (values: object) => requests.post("Account/register", values)
}

const Favorites = {
    get: (userId: string) => requests.get(`FavoriteCocktails?userId=${userId}`),
    add: (values: object) => requests.post("FavoriteCocktails", values),
    delete: (id: number) => requests.delete(`FavoriteCocktails/id?id=${id}`)
}

const agent = {
    Cocktail,
    Account,
    Favorites
}

export default agent;