import Vue from 'vue'
import Router from 'vue-router'
import Home from '../views/Home.vue'
import Login from '../views/Login.vue'
import Logout from '../views/Logout.vue'
import Profile from '../views/Profile.vue'
import Register from '../views/Register.vue'
import Breweries from '../views/Breweries.vue'
import Brewery from '../views/Brewery.vue'
import Beer from '../views/Beer.vue'
import NotFound from '../views/NotFound.vue'
import store from '../store/index'
import Beers from '../views/Beers.vue'
import Reviews from '../views/Reviews.vue'


Vue.use(Router)

/**
 * The Vue Router is used to "direct" the browser to render a specific view component
 * inside of App.vue depending on the URL.
 *
 * It also is used to detect whether or not a route requires the user to have first authenticated.
 * If the user has not yet authenticated (and needs to) they are redirected to /login
 * If they have (or don't need to) they're allowed to go about their way.
 */

const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/login",
      name: "login",
      component: Login,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/profile",
      name: "profile",
      component: Profile,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/logout",
      name: "logout",
      component: Logout,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/register",
      name: "register",
      component: Register,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/breweries",
      name: "breweries",
      component: Breweries,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/breweries/:breweryId",
      name: "brewery",
      component: Brewery,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: '/beers', 
      component: Beers,
      name: 'beers'
    },
    {
      path: '/reviews', 
      component: Reviews,
      name: 'reviews'
    },
    {
      path: '/beers/:beerId', 
      component: Beer,
      name: 'beer'
    },
    { 
      path: '/:catchAll(.*)', 
      component: NotFound,
      name: 'NotFound'
    },

  ]
})

router.beforeEach((to, from, next) => {
  // Determine if the route requires Authentication
  const requiresAuth = to.matched.some(x => x.meta.requiresAuth);

  // If it does and they are not logged in, send the user to "/login"
  if (requiresAuth && store.state.token === '') {
    next("/login");
  } else {
    // Else let them go to their next destination
    next();
  }
});

export default router;
