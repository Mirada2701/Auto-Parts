import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { APP_ENV } from "../env";
import { IProducerItem } from "../pages/Producer/types";

export const apiProducers = createApi({
    reducerPath: "apiProducers",
    baseQuery: fetchBaseQuery({
        baseUrl: `${APP_ENV.REMOTE_BASE_URL}api`,
    }),
    tagTypes: ["Producers"],
    endpoints: (builder) => ({
        getProducers: builder.query<IProducerItem[], void>({
            query: () => "Producers/all",
            providesTags: ["Producers"],
        }),
        getProducer: builder.query<IProducerItem, number>({
            query: (id) => `Producers/${id}/`,
            providesTags: (_result, _error, id) => [{ type: "Producers", id }],
        }),
    }),
});

export const {
    // Categories
    useGetProducersQuery,
    useGetProducerQuery
} = apiProducers;