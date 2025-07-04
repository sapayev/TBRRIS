import axios from 'axios';

const BASE_URL = 'http://localhost:5152/api';

export const getPositions = () => axios.get(`${BASE_URL}/Positions`);
