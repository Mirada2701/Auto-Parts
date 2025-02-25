import { configureStore } from '@reduxjs/toolkit';
import { apiParts } from '../services/apiParts.ts';
import { apiCategories } from '../services/apiCategory.ts';
import { apiProducers } from '../services/apiProducers.ts';
import { apiProviders } from '../services/apiProviders.ts';

export const store = configureStore({
    reducer: {
        [apiParts.reducerPath]: apiParts.reducer,
        [apiCategories.reducerPath]: apiCategories.reducer,
        [apiProducers.reducerPath]: apiProducers.reducer,
        [apiProviders.reducerPath]: apiProviders.reducer,
    },
    middleware: (getDefaultMiddleware) =>
        getDefaultMiddleware().concat(apiParts.middleware, apiCategories.middleware, apiProducers.middleware, apiProviders.middleware),
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;