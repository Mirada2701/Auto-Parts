import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { APP_ENV } from "../env";
import { IProviderItem } from "../pages/Provider/types";

export const apiProviders = createApi({
    reducerPath: "apiProviders",
    baseQuery: fetchBaseQuery({
        baseUrl: `${APP_ENV.REMOTE_BASE_URL}api`,
    }),
    tagTypes: ["Providers"],
    endpoints: (builder) => ({
        getProviders: builder.query<IProviderItem[], void>({
            query: () => "Providers/all",
            providesTags: ["Providers"],
        }),
        getProvider: builder.query<IProviderItem, number>({
            query: (id) => `Providers/${id}/`,
            providesTags: (_result, _error, id) => [{ type: "Providers", id }],
        }),
    }),
});

export const {
    // Categories
    useGetProvidersQuery,
    useGetProviderQuery
} = apiProviders;