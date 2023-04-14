import api from "./api";
import { GenerateUrl } from "./generator-url";

const responseBody = (response) => response.data;

export const HttpClient = {
  get: async (url , parameter) => {
    if (Object.keys(parameter).length !== 0) {
      if (parameter) {
        const URLWithParams = GenerateUrl(url, parameter);
        url = URLWithParams;
      }
    }
    return await api.get(url).then(responseBody);
  },
  post: async (url , parameter, body) => {
    if (Object.keys(parameter).length !== 0) {
      if (parameter) {
        url =  GenerateUrl(url, parameter);
      }
    }
    await api.post(url, body).then(responseBody)
        
    return responseBody;
  },

};