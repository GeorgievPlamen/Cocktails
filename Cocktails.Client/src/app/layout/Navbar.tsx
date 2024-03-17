import { Box, Select, MenuItem } from "@mui/material";
import { useForm } from "react-hook-form";
import { toast } from "react-toastify";
import agent from "../api/agent";
import { useAppDispatch } from "../store/configureStore";
import { addCocktails } from "../../features/cocktails/cocktailsSlice";
import { LoadingButton } from "@mui/lab";
import { useNavigate } from "react-router-dom";

export default function Navbar() {
  const dispatch = useAppDispatch();
  const nav = useNavigate();
  const { handleSubmit, register } = useForm({
    mode: "onTouched",
  });

  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  async function submitForm(formData: any) {
    try {
      const cocktails = await agent.Cocktail.listBy(formData.alcohol);
      console.log(cocktails);
      dispatch(addCocktails(cocktails));
      nav("/cocktails");
    } catch (error) {
      toast.error("Couldn't fetch cocktails.");
      console.error("Error:", error);
    }
  }

  return (
    <>
      <Box
        component={"form"}
        onSubmit={handleSubmit(submitForm)}
        sx={{ minWidth: 120 }}
      >
        <Select label="alcohol" defaultValue={0} {...register("alcohol")}>
          <MenuItem value={0}>Rum</MenuItem>
          <MenuItem value={1}>Gin</MenuItem>
          <MenuItem value={2}>Scotch</MenuItem>
          <MenuItem value={3}>Brandy</MenuItem>
          <MenuItem value={4}>Vodka</MenuItem>
          <MenuItem value={5}>Champagne</MenuItem>
          <MenuItem value={6}>Tequila</MenuItem>
        </Select>
        <LoadingButton type="submit">Submit</LoadingButton>
      </Box>
      <h2>Favorites</h2>
    </>
  );
}
