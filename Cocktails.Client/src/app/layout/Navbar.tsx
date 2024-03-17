import { Box, Select, MenuItem, Typography } from "@mui/material";
import { useForm } from "react-hook-form";
import { toast } from "react-toastify";
import agent from "../api/agent";
import { useAppDispatch, useAppSelector } from "../store/configureStore";
import { addCocktails } from "../../features/cocktails/cocktailsSlice";
import { LoadingButton } from "@mui/lab";
import { useNavigate } from "react-router-dom";
import { logOut } from "../../features/account/accountSlice";
import { addFavorites } from "../../features/favorites/favoritesSlice";

export default function Navbar() {
  const dispatch = useAppDispatch();
  const user = useAppSelector((state) => state.account.user);
  const nav = useNavigate();
  const { handleSubmit, register } = useForm({
    mode: "onTouched",
  });

  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  async function submitForm(formData: any) {
    try {
      const cocktails = await agent.Cocktail.listBy(formData.alcohol);
      dispatch(addCocktails(cocktails));
      nav("/cocktails");
    } catch (error) {
      toast.error("Couldn't fetch cocktails.");
      console.error("Error:", error);
    }
  }

  async function getFavorites() {
    try {
      const favorites = await agent.Favorites.get(user!.id);
      dispatch(addFavorites(favorites));
      nav("/favorites");
    } catch (error) {
      toast.error("Couldn't get favorites");
      console.log(error);
    }
  }

  return (
    <Box sx={{ display: "flex" }}>
      <Box>
        <Box
          component={"form"}
          onSubmit={handleSubmit(submitForm)}
          sx={{ minWidth: 240 }}
        >
          <Select
            sx={{ minWidth: "150px", margin: "20px" }}
            label="alcohol"
            defaultValue={0}
            {...register("alcohol")}
          >
            <MenuItem value={0}>Rum</MenuItem>
            <MenuItem value={1}>Gin</MenuItem>
            <MenuItem value={2}>Scotch</MenuItem>
            <MenuItem value={3}>Brandy</MenuItem>
            <MenuItem value={4}>Vodka</MenuItem>
            <MenuItem value={5}>Champagne</MenuItem>
            <MenuItem value={6}>Tequila</MenuItem>
          </Select>
          <LoadingButton type="submit" variant={"contained"}>
            Submit
          </LoadingButton>
        </Box>
      </Box>
      <Box sx={{ display: "flex", margin: "20px", gap: "20px" }}>
        <Box sx={{ margin: "auto" }}>
          {user ? (
            <Typography fontWeight={"bold"}>{user?.name}'s</Typography>
          ) : (
            <></>
          )}
        </Box>
        <LoadingButton
          onClick={() => getFavorites()}
          sx={{ margin: "auto" }}
          variant={"contained"}
        >
          Favorites
        </LoadingButton>
        {user ? (
          <LoadingButton
            onClick={() => dispatch(logOut())}
            sx={{ margin: "auto" }}
            variant={"contained"}
          >
            Logout
          </LoadingButton>
        ) : (
          <LoadingButton
            onClick={() => nav("/login")}
            sx={{ margin: "auto" }}
            variant={"contained"}
          >
            Login
          </LoadingButton>
        )}
      </Box>
    </Box>
  );
}
