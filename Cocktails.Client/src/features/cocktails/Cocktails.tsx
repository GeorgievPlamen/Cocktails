import { List, Paper, Button, Box } from "@mui/material";
import { useState } from "react";
import CocktailItem from "../../app/components/CocktailItem";
import { useAppSelector } from "../../app/store/configureStore";

export default function Cocktails() {
  const cocktails = useAppSelector((state) => state.cocktails.cocktailsByType);
  const itemsPerPage = 10;
  const [currentPage, setCurrentPage] = useState(1);

  const startIndex = (currentPage - 1) * itemsPerPage;
  const endIndex = currentPage * itemsPerPage;

  const currentCocktails = cocktails.slice(startIndex, endIndex);

  const nextPage = () => {
    setCurrentPage((prevPage) => prevPage + 1);
  };

  const prevPage = () => {
    setCurrentPage((prevPage) => prevPage - 1);
  };

  return (
    <>
      {cocktails.length < 1 ? (
        <></>
      ) : (
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
            {currentCocktails.map((c) => (
              <CocktailItem key={c.id} cocktail={c} />
            ))}
          </List>
          <Box>
            <Button disabled={currentPage === 1} onClick={prevPage}>
              Previous Page
            </Button>
            <Button disabled={endIndex >= cocktails.length} onClick={nextPage}>
              Next Page
            </Button>
          </Box>
        </Paper>
      )}
    </>
  );
}
