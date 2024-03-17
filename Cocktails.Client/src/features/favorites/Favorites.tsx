import { List, Paper } from "@mui/material";
import { useAppSelector } from "../../app/store/configureStore";
import FavoriteItem from "../../app/components/FavoriteItem";

export default function Favorites() {
  const favorites = useAppSelector((state) => state.favorites.favoritesByUser);

  return (
    <>
      {favorites.length > 0 ? (
        <>
          <Paper sx={{ width: "80%", bgcolor: "#eee", borderRadius: "20px" }}>
            <List
              dense
              sx={{
                display: "flex",
                flexFlow: "column",
                gap: "5px",
                minWidth: "400px",
              }}
            >
              {favorites.map((f) => (
                <FavoriteItem key={f.id} favorite={f} />
              ))}
            </List>
          </Paper>
        </>
      ) : (
        <></>
      )}
    </>
  );
}
