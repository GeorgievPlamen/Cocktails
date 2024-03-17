import { Box, CssBaseline } from "@mui/material";
import { Outlet } from "react-router-dom";
import { ToastContainer } from "react-toastify";
import "react-toastify/ReactToastify.css";
import Navbar from "./Navbar";
import { useAppDispatch } from "../store/configureStore";
import { useEffect } from "react";
import { setUser } from "../../features/account/accountSlice";
import agent from "../api/agent";
import { User } from "../models/user";
import { addFavorites } from "../../features/favorites/favoritesSlice";
function App() {
  const dispatch = useAppDispatch();
  const userString = localStorage.getItem("user");

  useEffect(() => {
    if (userString != null) {
      const user: User = JSON.parse(userString);
      dispatch(setUser(user));
      const favorites = agent.Favorites.get(user.id);
      dispatch(addFavorites(favorites));
    }
  }, [dispatch, userString]);
  return (
    <Box
      sx={{
        display: "flex",
        flexFlow: "column",
        alignItems: "center",
      }}
    >
      <ToastContainer
        limit={10}
        position="top-center"
        hideProgressBar
        theme="colored"
        autoClose={750}
      />
      <CssBaseline enableColorScheme />
      <Navbar />
      <>
        <Outlet />
      </>
    </Box>
  );
}

export default App;
