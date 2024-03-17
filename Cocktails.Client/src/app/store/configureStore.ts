import { configureStore } from "@reduxjs/toolkit";
import { TypedUseSelectorHook, useDispatch, useSelector } from "react-redux";
import { accountSlice } from "../../features/account/accountSlice";
import { cocktailsSlice } from "../../features/cocktails/cocktailsSlice";
import { favoritesSlice } from "../../features/favorites/favoritesSlice";

export const store = configureStore({
    reducer: {
        cocktails: cocktailsSlice.reducer,
        account: accountSlice.reducer,
        favorites: favoritesSlice.reducer
    }
})

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;

export const useAppDispatch = () => useDispatch<AppDispatch>();
export const useAppSelector: TypedUseSelectorHook<RootState> = useSelector;