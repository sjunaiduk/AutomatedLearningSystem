import axios from "axios";

export const client = axios.create({
  baseURL: import.meta.env.VITE_API_BASE,
  withCredentials: true,
});

export class BaseClient<TResponse> {
  endpoint: string;
  constructor(endpoint: string) {
    this.endpoint = endpoint;
  }
  GetAll = async () => {
    var res = await client.get<TResponse[]>(this.endpoint);
    return res.data;
  };

  Get = async (id: string) => {
    var res = await client.get<TResponse>(`${this.endpoint}/${id}`);
    return res.data;
  };

  Update = async <TUpdateRequest>(id: string, request: TUpdateRequest) => {
    var res = await client.put(`${this.endpoint}/${id}`, request);
    return res.data;
  };

  Post = async <TPostRequest>(request: TPostRequest) => {
    var res = await client.post(`${this.endpoint}`, request);
    return res.data;
  };

  Delete = async (id: string) => {
    var res = await client.delete(`${this.endpoint}/${id}`);
    return res.data;
  };
}
