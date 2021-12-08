import axios from 'axios';

export default {

  getAllBeers() {
    return axios.get('/beers')
  },

  getBeerById(beerId) {
    return axios.get(`/beers/${beerId}`)
  },

  addBeer(beer) {
      return axios.post('/beers', beer)
  },

  deleteBeer(beerId) {
      return axios.delete(`/beers/${beerId}`)
  }

}