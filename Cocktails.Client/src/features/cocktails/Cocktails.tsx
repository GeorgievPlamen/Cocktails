import { List } from "@mui/material";
import CocktailItem from "../../app/components/CocktailItem";
import { useAppSelector } from "../../app/store/configureStore";

export default function Cocktails() {
  const cocktails = useAppSelector((state) => state.cocktails.cocktailsByType);

  return (
    <List
      dense
      sx={{
        display: "flex",
        flexFlow: "column",
        gap: "5px",
        width: "50%",
        minWidth: "400px",
        bgcolor: "grey",
      }}
    >
      {cocktails.map((c) => (
        <CocktailItem key={c.id} cocktail={c} />
      ))}
    </List>
  );
}
