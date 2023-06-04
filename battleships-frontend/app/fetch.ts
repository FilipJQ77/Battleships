export const API_BASE_URL = "https://localhost:44346";

export const fetchRoute = async (route: string) => {
  const url = `${API_BASE_URL}/${route}`;
  const response = await fetch(url);
  return response.json();
};
