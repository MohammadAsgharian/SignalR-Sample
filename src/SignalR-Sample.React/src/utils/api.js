import axios from "axios";
import { LocalStorage } from "./local-storage";

const API_URL = "https://localhost:44379";
const token = LocalStorage.loadState("token");
const api = 
  axios.create({
    baseURL: API_URL,
    headers: {'Authorization': `Bearer ${token}`}
  });

export default api;
