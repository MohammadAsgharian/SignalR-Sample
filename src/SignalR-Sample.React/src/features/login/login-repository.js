
import { HttpClient } from "../../utils/http-client";

const API_LOGIN_URL = "api/login";

export class LoginRepository  {
   static   getUserByUsername = async (username)=> {
    try {
      const params = { username };
      const result = await HttpClient.get(`${API_LOGIN_URL}`, params);
      return result;
    } catch (error) {
      console.error(error);
      throw error;
    }
  }

  
}
