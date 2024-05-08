import { useCookies } from "vue3-cookies";

export const isUserLogged = () => {
  const cookie = useCookies().cookies.get("X-User");
  return cookie ? true : false;
};

export const getUserLogged = () => {
  const cookie = useCookies().cookies.get("X-User");
  return cookie;
};
