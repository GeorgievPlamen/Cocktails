import { LoadingButton } from "@mui/lab";
import { ListItem, Avatar, Typography } from "@mui/material";
import { Cocktail } from "../models/cocktail";
import agent from "../api/agent";
import { useAppDispatch } from "../store/configureStore";
import { addDetailedCocktail } from "../../features/cocktails/cocktailsSlice";
import { useNavigate } from "react-router-dom";

interface Props {
  cocktail: Cocktail;
}

export default function CocktailItem({ cocktail }: Props) {
  const nav = useNavigate();
  const dispatch = useAppDispatch();
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
  return (
    <ListItem
      key={cocktail.id}
      sx={{ display: "flex", justifyContent: "space-between" }}
    >
      <Avatar
        sx={{ height: "60px", width: "60px" }}
        alt={`Picutre of a nice ${cocktail.name} cocktail`}
        src={cocktail.imageURL}
      ></Avatar>
      <Typography fontWeight={"bold"} variant="h5">
        {cocktail.name}
      </Typography>
      <LoadingButton onClick={() => submit(cocktail.id)}>Details</LoadingButton>
    </ListItem>
  );
}
