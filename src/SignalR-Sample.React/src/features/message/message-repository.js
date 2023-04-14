
import { HttpClient } from "../../utils/http-client";

const API_LOGIN_URL = "api/message";

export class MessageRepository  {
   static  createMessage = async (personId, messageContent)=> {
    try {
      const body = 
        { 
            personId : personId, 
            body:messageContent  
        };
      const result = await HttpClient.post(`${API_LOGIN_URL}`, {},body);
      return result;
    } catch (error) {
      console.error(error);
      throw error;
    }
  }

  
}
