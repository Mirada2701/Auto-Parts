import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { APP_ENV } from "../env";
import { ISparePart, ISparePartPostRequest, ISparePartPutRequest } from "../pages/SparePart/types";

export const apiParts = createApi({
    reducerPath: "apiParts",
    baseQuery: fetchBaseQuery({
        baseUrl: `${APP_ENV.REMOTE_BASE_URL}api`,
    }),
    tagTypes: ["SpareParts"],
    endpoints: (builder) => ({
        getSpareParts: builder.query<ISparePart[], void>({
            query: () => "Parts/all",
            providesTags: ["SpareParts"],
        }),
        getSparePart: builder.query<ISparePart, number>({
            query: (id) => `Parts/${id}/`,
            providesTags: (_result, _error, id) => [{ type: "SpareParts", id }],
        }),
        createSparePart: builder.mutation<ISparePart, ISparePartPostRequest>({
            query: (body) => ({
                url: "Parts/",
                method: "POST",
                body,
            }),
            invalidatesTags: ["SpareParts"],
        }),
        updateSparePart: builder.mutation<void, ISparePartPutRequest>
        ({
            query: (updatedPart) => ({
                url: `Parts`,
                method: "PUT",
                body: updatedPart,
            }),
            invalidatesTags: ["SpareParts"],
        }),
        deleteSparePart: builder.mutation<{ success: boolean }, number>({
            query: (id) => ({
                url: `Parts/${id}/`,
                method: "DELETE",
            }),
            invalidatesTags: ["SpareParts"],
        }),
    }),
});

// ======================= ЕКСПОРТ ХУКІВ =========================

export const {
    // SpareParts
    useGetSparePartsQuery,
    useGetSparePartQuery,
    useCreateSparePartMutation,
    useUpdateSparePartMutation,
    useDeleteSparePartMutation
} = apiParts;