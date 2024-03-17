import { Box, Paper, Typography } from "@mui/material";
import { useAppSelector } from "../../app/store/configureStore";
import { LoadingButton } from "@mui/lab";
import agent from "../../app/api/agent";
import { Favorite } from "../../app/models/favorite";
import { toast } from "react-toastify";

export default function DetailedCocktail() {
  const cocktailWithDetails = useAppSelector(
    (state) => state.cocktails.detailedCocktail
  );
  const user = useAppSelector((state) => state.account.user);

  const favorite: Favorite = {
    id: cocktailWithDetails?.id,
    userId: user?.id,
    name: cocktailWithDetails?.name,
    imageURL: cocktailWithDetails?.imageURL,
    dateCreated: undefined,
  };

  async function addToFavorites(data: Favorite) {
    try {
      await agent.Favorites.add(data);
    } catch (error) {
      toast.error("Couldn't add to favorites");
      console.log(error);
    }
  }

  return (
    <>
      {cocktailWithDetails ? (
        <Paper
          sx={{
            display: "flex",
            flexFlow: "column",
            width: "80%",
            bgcolor: "#eee",
            borderRadius: "20px",
          }}
        >
          <Typography textAlign={"center"} fontWeight={"bold"} variant="h4">
            {cocktailWithDetails?.name}
          </Typography>
          <LoadingButton
            onClick={() => addToFavorites(favorite)}
            sx={{ maxWidth: "180px", alignSelf: "center" }}
            variant="outlined"
          >
            Add to favorites
          </LoadingButton>
          <Box sx={{ display: "flex" }}>
            <Box>
              <img
                src={cocktailWithDetails?.imageURL}
                alt={cocktailWithDetails?.name}
                style={{
                  borderRadius: "20px",
                  width: "250px",
                  height: "250px",
                  margin: "10px",
                }}
              />
            </Box>
            <Box
              sx={{
                display: "flex",
                flexFlow: "column",
                width: "100%",
                justifyContent: "center",
                alignItems: "center",
              }}
            >
              <Typography>Type: {cocktailWithDetails?.alcoholic}</Typography>
              <Typography gutterBottom>
                Glass: {cocktailWithDetails?.glass}
              </Typography>
              <Box sx={{ display: "flex" }}>
                <Box>
                  {cocktailWithDetails?.ingredients.map((i) => (
                    <Typography>{i}</Typography>
                  ))}
                </Box>
                <Box sx={{ marginLeft: "20px" }}>
                  {cocktailWithDetails?.measurements.map((i) => (
                    <Typography>{i}</Typography>
                  ))}
                </Box>
              </Box>
            </Box>
          </Box>
          <Typography margin={"10px"} textAlign={"center"}>
            {cocktailWithDetails?.instructions}
          </Typography>
        </Paper>
      ) : (
        <></>
      )}
    </>
  );
}
