import {
  Box,
  Card,
  CardContent,
  Container,
  CssBaseline,
  TextField,
  Typography,
} from "@mui/material";
import { Link, useNavigate } from "react-router-dom";
import { useForm } from "react-hook-form";
import { LoadingButton } from "@mui/lab";
import agent from "../../app/api/agent";
import { toast } from "react-toastify";
import Navbar from "../../app/layout/Navbar";

export default function Register() {
  const nav = useNavigate();
  const {
    handleSubmit,
    register,
    setError,
    formState: { isSubmitting, errors, isValid },
  } = useForm({
    mode: "onTouched",
  });

  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  function handleApiErrors(errors: any) {
    if (errors) {
      errors.forEach((error: string) => {
        if (error.includes("Password")) {
          setError("password", { message: error });
        } else if (error.includes("Email")) {
          setError("email", { message: error });
        } else if (error.includes("Username")) {
          setError("username", { message: error });
        }
      });
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
              {"Register"}
            </Typography>
            <Box
              component="form"
              onSubmit={handleSubmit((data) =>
                agent.Account.register(data)
                  .then(() => {
                    toast.success("Registration successful");
                    nav("/login");
                  })
                  .catch((error) => {
                    handleApiErrors(error);
                    toast.error(error);
                  })
              )}
              noValidate
              sx={{ mt: 1 }}
            >
              <TextField
                margin="normal"
                fullWidth
                label={"Name"}
                autoFocus
                {...register("name", {
                  required: "Name is required",
                })}
                error={!!errors.username}
                helperText={errors.username?.message as string}
              />
              <TextField
                margin="normal"
                fullWidth
                label={"Email"}
                {...register("email", {
                  required: "Email is required",
                })}
                error={!!errors.email}
                helperText={errors.email?.message as string}
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
                {"Register"}
              </LoadingButton>
              <Link to="/login" style={{ textDecoration: "none" }}>
                <Typography textAlign={"end"} color={"textPrimary"}>
                  {"Already have an account? Log In"}
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
