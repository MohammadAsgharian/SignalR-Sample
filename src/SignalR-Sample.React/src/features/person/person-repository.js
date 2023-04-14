import { HttpClient } from "../../utils/http-client";

const API_PERSONS_URL = "api/Person";

export class PersonRepository {
  static  getAllPersons = async() => {
      const result = await HttpClient.get(`${API_PERSONS_URL}`,{});
      console.log(result);
      return result;
   
  }
}
