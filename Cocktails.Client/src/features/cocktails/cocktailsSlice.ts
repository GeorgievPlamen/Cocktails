import { createSlice } from "@reduxjs/toolkit";
import { Cocktail } from "../../app/models/cocktail";
import { CocktailDetails } from "../../app/models/cocktailDetails";


export interface Cocktails {
    cocktailsByType: Cocktail[];
    detailedCocktail: CocktailDetails | null;
}

const initialState: Cocktails = {
    cocktailsByType: [],
    detailedCocktail: null
}

export const cocktailsSlice = createSlice({
    name: "game",
    initialState,
    reducers: {
 
        addCocktails: (state, action) => {
            state.cocktailsByType = action.payload;
        },
        addDetailedCocktail: (state, action) => {
            state.detailedCocktail = action.payload;
        }
    }
})

export const {addCocktails,addDetailedCocktail} = cocktailsSlice.actions;
