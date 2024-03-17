import { createSlice } from "@reduxjs/toolkit";
import { Favorite } from "../../app/models/favorite";


export interface Favorites {
    favoritesByUser: Favorite[];
}

const initialState: Favorites = {
    favoritesByUser: [],
}

export const favoritesSlice = createSlice({
    name: "game",
    initialState,
    reducers: {
        addFavorites: (state, action) => {
            state.favoritesByUser = action.payload;
        },
        removeFromFavorites: (state, action) => {
            state.favoritesByUser = 
                state.favoritesByUser.filter(
                f => f.id !== action.payload.id);
        }
    }
})

export const {addFavorites} = favoritesSlice.actions;
