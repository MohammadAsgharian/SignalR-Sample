
import { HttClient } from "../../utils/http-client";

const API_LOGIN_URL = "api/login";

export class LoginRepository  {
  // #region Acitvity
  async list(username) {
    const parameter = {username };
    const result = await HttClient.get(
      API_LOGIN_URL,
      parameter
    );
    return result;
  }
}
