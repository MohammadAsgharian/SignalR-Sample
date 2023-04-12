import axios from "axios";
const API_URL = process.env.REACT_APP_BASE_API_URL;
const api = setupInterceptorsTo(
  axios.create({
    baseURL: API_URL,
  })
);

export default api;
