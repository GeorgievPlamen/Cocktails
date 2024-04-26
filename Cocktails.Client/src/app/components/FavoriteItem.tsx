import { LoadingButton } from "@mui/lab";
import { ListItem, Avatar, Typography, Box } from "@mui/material";
import agent from "../api/agent";
import { useAppDispatch, useAppSelector } from "../store/configureStore";
import { addDetailedCocktail } from "../../features/cocktails/cocktailsSlice";
import { useNavigate } from "react-router-dom";
import { Favorite } from "../models/favorite";
import { addFavorites } from "../../features/favorites/favoritesSlice";

interface Props {
  favorite: Favorite;
}

export default function FavoriteItem({ favorite }: Props) {
  const nav = useNavigate();
  const dispatch = useAppDispatch();
  const user = useAppSelector((state) => state.account.user);

  async function submit(data: number) {
    try {
      console.log("submiting");
      const cocktailDetails = await agent.Cocktail.details(data);
      dispatch(addDetailedCocktail(cocktailDetails));
      nav("/details");
    } catch (error) {
      console.log(error);
    }
  }

  async function del(id: number) {
    try {
      await agent.Favorites.delete(id);
      const favorites = await agent.Favorites.get(user!.id);
      dispatch(addFavorites(favorites));
    } catch (error) {
      console.log(error);
    }
  }
  return (
    <ListItem
      key={favorite.id}
      sx={{ display: "flex", justifyContent: "space-between" }}
    >
      <Avatar
        sx={{ height: "60px", width: "60px" }}
        alt={`Picutre of a nice ${favorite.name} cocktail`}
        src={favorite.imageURL}
      ></Avatar>
      <Typography fontWeight={"bold"} variant="h5">
        {favorite.name}
      </Typography>
      <Box>
        <LoadingButton onClick={() => del(favorite.id!)}>Delete</LoadingButton>
        <LoadingButton onClick={() => submit(favorite.cocktailId!)}>
          Details
        </LoadingButton>
      </Box>
    </ListItem>
  );
}
