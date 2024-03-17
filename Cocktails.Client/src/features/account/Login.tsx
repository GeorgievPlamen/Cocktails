import {
  Box,
  Card,
  CardContent,
  Container,
  CssBaseline,
  TextField,
  Typography,
} from "@mui/material";
import Navbar from "../../app/layout/Navbar";
import { useAppDispatch } from "../../app/store/configureStore";
import { Link, useNavigate } from "react-router-dom";
import { FieldValues, useForm } from "react-hook-form";
import { LoadingButton } from "@mui/lab";
import { setUsername, signInUser } from "./accountSlice";
import { toast } from "react-toastify";

export default function Login() {
  const nav = useNavigate();
  const dispatch = useAppDispatch();
  const {
    handleSubmit,
    register,
    formState: { isSubmitting, errors, isValid },
  } = useForm({
    mode: "onTouched",
  });

  async function submitForm(data: FieldValues) {
    try {
      const actionResult = await dispatch(signInUser(data));

      if (signInUser.fulfilled.match(actionResult)) {
        toast.success("Login Successfull");
        if (localStorage["user"]) {
          const user = JSON.parse(localStorage["user"]);
          dispatch(setUsername(user["username"]));
        }
        nav("/");
      } else {
        toast.error("Login Failed");
      }
    } catch (error) {
      console.log(error);
    }
  }

  return (
    <Box
      display={"flex"}
      margin={"80px auto"}
      flexDirection={"column"}
      alignItems={"center"}
      justifyContent={"center"}
    >
      <Navbar />
      <Card
        sx={{
          minWidth: 275,
          maxWidth: 360,
        }}
      >
        <CardContent>
          <Box
            sx={{
              marginTop: 8,
              display: "flex",
              flexDirection: "column",
              alignItems: "center",
            }}
          >
            <Typography component="h1" variant="h5">
              {"Log in"}
            </Typography>
            <Box
              component="form"
              onSubmit={handleSubmit(submitForm)}
              noValidate
              sx={{ mt: 1 }}
            >
              <TextField
                margin="normal"
                fullWidth
                label={"Email"}
                autoFocus
                {...register("email", {
                  required: "Email is required",
                })}
                error={!!errors.username}
                helperText={errors.username?.message as string}
              />
              <TextField
                margin="normal"
                fullWidth
                label={"Password"}
                type="password"
                {...register("password", {
                  required: "Password is required",
                })}
                error={!!errors.password}
                helperText={errors.password?.message as string}
              />
              <LoadingButton
                loading={isSubmitting}
                disabled={!isValid}
                color="secondary"
                type="submit"
                fullWidth
                variant="contained"
                sx={{ mt: 3, mb: 2 }}
              >
                {"Log in"}
              </LoadingButton>
              <Link to="/register" style={{ textDecoration: "none" }}>
                <Typography textAlign={"end"} color={"textPrimary"}>
                  {"Don't have an account? Sign Up"}
                </Typography>
              </Link>
            </Box>
          </Box>
        </CardContent>
      </Card>
      <Container component="main" maxWidth="xs">
        <CssBaseline />
      </Container>
    </Box>
  );
}
