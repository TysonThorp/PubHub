import axios from 'axios';

export default {

  getAllBeers() {
    return axios.get('/beers')
  },

  getBeerById(beerID) {
    return axios.get('/beers/${beerID}')
  },

  addBeer(beer) {
      return axios.post('/beers', beer)
  },

  deleteBeer(beerID) {
      return axios.delete('/beers/${beerID}')
  }

}