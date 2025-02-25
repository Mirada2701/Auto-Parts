import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { ICategoryItem } from "../pages/Category/types";
import { APP_ENV } from "../env";



export const apiCategories = createApi({
    reducerPath: "apiCategories",
    baseQuery: fetchBaseQuery({
        baseUrl: `${APP_ENV.REMOTE_BASE_URL}api`,
    }),
    tagTypes: ["Categories"],
    endpoints: (builder) => ({
        getCategories: builder.query<ICategoryItem[], void>({
            query: () => "Category/all",
            providesTags: ["Categories"],
        }),
        getCategory: builder.query<ICategoryItem, number>({
            query: (id) => `Category/${id}/`,
            providesTags: (_result, _error, id) => [{ type: "Categories", id }],
        }),
    }),
});

export const {
    // Categories
    useGetCategoriesQuery,
    useGetCategoryQuery
} = apiCategories;