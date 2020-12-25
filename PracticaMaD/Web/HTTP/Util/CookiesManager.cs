using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Es.Udc.DotNet.PracticaMad.Web.HTTP.Util
{
    public class CookiesManager
    {
        private const string CLIENT_LOGIN_COOKIE = "clientLogin";
        private const string ENCRYPTED_PASSWORD_COOKIE = "encryptedPassword";

        private const int REMEMBER_MY_PASSWORD_AGE = 30 * 24 * 3600;
        private const int COOKIES_TIME_TO_LIVE_REMOVE = 0;

        public static void LeaveCookies(HttpContext context, String clientLogin,
                String encryptedPassword)
        {
            int timeToLive = REMEMBER_MY_PASSWORD_AGE;

            /* Create the clientLogin cookie. */
            HttpCookie clientLoginCookie =
                new HttpCookie(CLIENT_LOGIN_COOKIE, clientLogin);

            /* Create the encryptedPassword cookie. */
            HttpCookie encryptedPasswordCookie =
                new HttpCookie(ENCRYPTED_PASSWORD_COOKIE, encryptedPassword);

            /* Create the authentication ticket cookie. */
            HttpCookie authTicket =
                FormsAuthentication.GetAuthCookie(clientLogin, true);

            /* Set maximum age to cookies. */
            clientLoginCookie.Expires = DateTime.Now.AddSeconds(timeToLive);
            encryptedPasswordCookie.Expires = DateTime.Now.AddSeconds(timeToLive);
            authTicket.Expires = DateTime.Now.AddSeconds(timeToLive);

            /* Add cookies to response. */
            context.Response.Cookies.Add(clientLoginCookie);
            context.Response.Cookies.Add(encryptedPasswordCookie);
        }

        public static void RemoveCookies(HttpContext context)
        {
            int timeToLive = COOKIES_TIME_TO_LIVE_REMOVE;

            /* Create the clientLogin cookie. */
            HttpCookie clientLoginCookie =
                new HttpCookie(CLIENT_LOGIN_COOKIE, "");

            /* Create the encryptedPassword cookie. */
            HttpCookie encryptedPasswordCookie =
                new HttpCookie(ENCRYPTED_PASSWORD_COOKIE, "");

            /* Set maximum age to cookies. */
            clientLoginCookie.Expires = DateTime.Now.AddSeconds(timeToLive);
            encryptedPasswordCookie.Expires = DateTime.Now.AddSeconds(timeToLive);

            /* Add cookies to response. */
            context.Response.Cookies.Add(clientLoginCookie);
            context.Response.Cookies.Add(encryptedPasswordCookie);
        }

        public static String GetClientLogin(HttpContext context)
        {
            HttpCookie clientLoginCookie =
                context.Request.Cookies.Get(CLIENT_LOGIN_COOKIE);

            if (clientLoginCookie != null)
                return clientLoginCookie.Value;
            else
                return null;
        }

        public static String GetEncryptedPassword(HttpContext context)
        {
            HttpCookie encryptedPasswordCookie =
                context.Request.Cookies.Get(ENCRYPTED_PASSWORD_COOKIE);

            if (encryptedPasswordCookie != null)
                return encryptedPasswordCookie.Value;
            else
                return null;
        }
    }
}