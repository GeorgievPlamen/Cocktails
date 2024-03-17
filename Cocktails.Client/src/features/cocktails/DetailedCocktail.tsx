import { Box, Typography } from "@mui/material";
import { useAppSelector } from "../../app/store/configureStore";

export default function DetailedCocktail() {
  const cocktailWithDetails = useAppSelector(
    (state) => state.cocktails.detailedCocktail
  );
  return (
    <Box>
      <h2>details</h2>
      <Typography>{cocktailWithDetails?.name}</Typography>
      <Typography>{cocktailWithDetails?.id}</Typography>
      <Typography>{cocktailWithDetails?.alcoholic}</Typography>
      <Typography>{cocktailWithDetails?.glass}</Typography>
      <Typography>{cocktailWithDetails?.imageURL}</Typography>
      <Typography>{cocktailWithDetails?.instructions}</Typography>
      <Typography>{cocktailWithDetails?.ingredients}</Typography>
      <Typography>{cocktailWithDetails?.measurements}</Typography>
    </Box>
  );
}
