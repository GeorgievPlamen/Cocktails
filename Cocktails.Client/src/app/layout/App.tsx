import { CssBaseline } from "@mui/material";
import { Outlet } from "react-router-dom";
import { ToastContainer } from "react-toastify";
import Navbar from "./Navbar";

function App() {
  return (
    <>
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
    </>
  );
}

export default App;
