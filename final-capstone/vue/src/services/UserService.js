import axios from 'axios';

export default {

  getAllUsers() {
    return axios.get('/users')
  },

  getUserById(userId) {
      return axios.get(`/users/${userId}`)
  },

  addUser(user) {
      return axios.post('/users', user)
  },

  updateUser(user) {
      return axios.put(`/users/${user.userId}`, user)
  }, 

  deleteUser(userId) {
      return axios.delete(`/users/${userId}`)
  }
}