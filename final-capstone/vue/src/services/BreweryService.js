import axios from 'axios';

export default {

  getAllBreweries() {
    return axios.get('/breweries')
  },

  getBreweryById(breweryId) {
      return axios.get(`/breweries/${breweryId}`)
  },

  addBrewery(brewery) {
      return axios.post('/breweries', brewery)
  },

  updateBrewery(brewery) {
      return axios.put(`/breweries/${brewery.breweryId}`, brewery)
  }, 

  deleteBrewery(breweryId) {
      return axios.delete(`/breweries/${breweryId}`)
  }
}