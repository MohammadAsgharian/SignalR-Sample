import axios from "axios";
import { LocalStorage } from "./local-storage";

const API_URL = "https://localhost:44379";
const api = 
  axios.create({
    baseURL: API_URL,
  });

export default api;
