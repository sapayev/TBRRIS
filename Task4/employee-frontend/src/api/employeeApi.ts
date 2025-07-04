import axios from 'axios';

const BASE_URL = 'http://localhost:5152/api';

export const getEmployees = (params: any) => axios.get(`${BASE_URL}/Employees`, { params });
export const getEmployeeById = (id: number) => axios.get(`${BASE_URL}/Employees/${id}`);
export const createEmployee = (data: any) => axios.post(`${BASE_URL}/Employees`, data);
export const updateEmployee = (id: number, data: any) => axios.put(`${BASE_URL}/Employees/${id}`, data);
export const deleteEmployee = (id: number) => axios.delete(`${BASE_URL}/Employees/${id}`);
