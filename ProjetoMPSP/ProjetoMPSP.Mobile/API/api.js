import { create } from 'apisauce';

const api = create({
  baseURL: 'http://localhost:56840/',
});

api.addResponseTransform(response =>{
  console.log(response)
  if(!response.ok) throw response;
})

export default api;