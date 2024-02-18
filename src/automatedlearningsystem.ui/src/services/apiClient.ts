import axios from "axios";

export const client = axios.create({
  baseURL: import.meta.env.VITE_API_BASE,
  withCredentials: true,
});

export class BaseClient<TResponse> {
  GetAll = async (endpoint: string) => {
    var res = await client.get<TResponse[]>(endpoint);
    return res.data;
  };

  Get = async (endpoint: string) => {
    var res = await client.get<TResponse>(endpoint);
    return res.data;
  };
}
