import { useState } from "react";
import { useNavigate } from "react-router-dom";
import {LoginRepository} from "./login-repository";
import {LocalStorage} from "./../../utils/local-storage";
import {
  Container,
  CssBaseline,
  Box,
  Typography,
  TextField,
  Button
} from "@mui/material";

export default function Login() {
  const [username, setUsername] = useState("");
  const navigate = useNavigate();

  const handleSubmit = async (event) => {
    event.preventDefault();

    try {
      const result =await  LoginRepository.getUserByUsername(username);
      console.log(result);
      LocalStorage.saveState("Token", result.token);
      navigate("/inbox");
    } catch (error) {
      console.error("Login error: ", error);
    }
  };

  const handleUsernameChange = (event) => {
    setUsername(event.target.value);
  };

  return (
    <Container component="main" maxWidth="xs">
      <CssBaseline />
      <Box
        sx={{
          marginTop: 8,
          display: "flex",
          flexDirection: "column",
          alignItems: "center"
        }}
      >
        <Typography component="h1" variant="h5">
          Login
        </Typography>
        <Box component="form" onSubmit={handleSubmit} noValidate sx={{ mt: 1 }}>
          <TextField
            margin="normal"
            required
            fullWidth
            id="username"
            label="UserName"
            name="username"
            autoComplete="UserName"
            autoFocus
            value={username}
            onChange={handleUsernameChange}
          />
          <Button
            type="submit"
            fullWidth
            variant="contained"
            sx={{ mt: 3, mb: 2 }}
          >
            Login
          </Button>
        </Box>
      </Box>
    </Container>
  );
}
