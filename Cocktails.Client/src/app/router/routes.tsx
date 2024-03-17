import { createBrowserRouter } from "react-router-dom";
import App from "../layout/App";
import Login from "../../features/account/Login";
import Register from "../../features/account/Register";
import Cocktails from "../../features/cocktails/Cocktails";
import DetailedCocktail from "../../features/cocktails/DetailedCocktail";

export const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    children: [
      { path: "", element: <App /> },
      { path: "login", element: <Login /> },
      { path: "register", element: <Register /> },
      { path: "cocktails", element: <Cocktails /> },
      { path: "details", element: <DetailedCocktail /> },
      { path: "*", element: <App /> },
    ],
  },
]);
