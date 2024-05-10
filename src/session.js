import { useCookies } from "vue3-cookies";
import { reactive } from 'vue'

export const isUserLogged = () => {
  const cookie = useCookies().cookies.get("X-User");
  return cookie ? true : false;
};

export const getUserLogged = () => {
  const cookie = useCookies().cookies.get("X-User");
  return cookie;
};

export const refreshStore = () => {
    store.userLogged = isUserLogged();
}

export const store = reactive({
    userLogged: false
})