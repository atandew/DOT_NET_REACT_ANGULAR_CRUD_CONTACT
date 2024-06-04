import axios from 'axios';

const _baseURL = "https://localhost:7251/api";

const axios_api = axios.create({
  baseURL: _baseURL,
});

export default axios_api;

