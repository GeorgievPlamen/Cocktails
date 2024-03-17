import { createSlice } from "@reduxjs/toolkit";
import { Cocktail } from "../../app/models/cocktail";
import { CocktailDetails } from "../../app/models/cocktailDetails";


export interface Cocktails {
    loading: boolean;
    cocktailsByType: Cocktail[];
    detailedCocktail: CocktailDetails | null;
}

const initialState: Cocktails = {
    loading: false,
    cocktailsByType: [],
    detailedCocktail: null
}

export const cocktailsSlice = createSlice({
    name: "game",
    initialState,
    reducers: {
        toggleLoading: (state, action) => {
            state.loading = action.payload;
        },
        addCocktails: (state, action) => {
            state.cocktailsByType = action.payload;
        },
        addDetailedCocktail: (state, action) => {
            state.detailedCocktail = action.payload;
        }
    }
})

export const {toggleLoading,addCocktails,addDetailedCocktail} = cocktailsSlice.actions;
