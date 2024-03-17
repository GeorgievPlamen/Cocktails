/* eslint-disable @typescript-eslint/no-explicit-any */
import { createAsyncThunk, createSlice} from "@reduxjs/toolkit";
import { User } from "../../app/models/user";
import agent from "../../app/api/agent";
import { FieldValues } from "react-hook-form";
import { router } from "../../app/router/routes";


export interface AccountState {
    user: User | null;
}

const initialState: AccountState = {
    user: null
}

export const signInUser = createAsyncThunk<User, FieldValues>(
    "account/singInUser",
    async (data, thunkAPI) => {
        try {
            const user = await agent.Account.login(data);
            localStorage.setItem("user", JSON.stringify(user));
            return user;
        } catch (error: any) {
            return  thunkAPI.rejectWithValue({error: error.data})
        }
    }
)

export const accountSlice = createSlice({
    name: "account",
    initialState,
    reducers: {
        logOut: (state) => {
            state.user = null;
            localStorage.removeItem("user");
            router.navigate("/");
        },
        setUser: (state, action) => {
            state.user = action.payload;
        }
    }
})

export const {logOut,setUser} = accountSlice.actions;