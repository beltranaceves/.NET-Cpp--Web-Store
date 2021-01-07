using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Es.Udc.DotNet.PracticaMad.Model.Services.ClientService;
using Es.Udc.DotNet.PracticaMad.Model.Services.ProductService;
using Es.Udc.DotNet.PracticaMad.Web.HTTP.View.ApplicationObjects;
using Es.Udc.DotNet.PracticaMad.Web.HTTP.Util;
using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMad.Model.Services.CreditCardService;
using Es.Udc.DotNet.PracticaMad.Model.Services.CategoryService;
using Es.Udc.DotNet.PracticaMad.Model.Services.ProductCommentService;
using Es.Udc.DotNet.PracticaMad.Model;
using Es.Udc.DotNet.PracticaMad.Model.Services.ClientOrderService;
using Es.Udc.DotNet.PracticaMad.Model.Services.TagService;
using Es.Udc.DotNet.PracticaMad.Model.Objetos;
using Es.Udc.DotNet.PracticaMad.Model.Services.ShoppingCartService;

namespace Es.Udc.DotNet.PracticaMad.Web.HTTP.Session
{
    ///<summary>
    ///
    /// A facade utility class to transparently manage session objects and
    /// cookies. The following objects are mantained in the session:
    /// <list>
    ///  <item>* The client's data, stored in the ClientSession object under the key
    ///    <c>CIENT_SESSION_ATTRIBUTE</c>. This attribute is only present
    ///    for authenticated clients, and is only of interest to the view. The
    ///    ClientSession object stores the firstName and the clientId</item>
    ///
    ///  <item>* The client's language and the client's country, stored in the
    ///     Locale object under the key <c>LOCALE_SESSION_ATTRIBUTE</c>. This
    ///     attribute is only present for authenticated clients, and is only of
    ///     interest to the view.</item>
    ///</list>
    ///
    /// For clients that select "remember my password" in the login wizard, the
    /// following cookies are used (managed in the CookiesManager object):
    /// <list>
    ///   <item>* <c>CLIENT_LOGIN_COOKIE</c>: to store the client Login.</item>
    ///   <item>* <c>ENCRYPTED_PASSWORD_COOKIE</c>: to store the
    ///              encrypted password.</item>
    ///   <item>* <c>.ASPXAUTH</c>: Authentication Cookie.</item>
    /// </list>
    /// In order to make transparent the management of session objects and cookies
    /// to the implementation of controller actions, this class provides a number
    /// of methods equivalent to some of the ones provided by
    /// <c>ClientService</c>, which manage session objects and cookies,
    /// and call upon the corresponding <c>ClientService's</c> method.
    /// These methods are as follows:
    /// <list>
    ///   <item>* <c>Login</c>.</item>
    ///   <item>* <c>RegisterClient</c>.</item>
    ///   <item>* <c>FindClientDetails</c>.</item>
    ///   <item>* <c>UpdateClientDetails</c>.</item>
    ///   <item>* <c>ChangePassword</c>.</item>
    /// </list>
    ///
    /// It is important to remember that when needing to do some of the above
    /// actions from the controller, the corresponding method of this class
    /// (one of the previous list) must be called, and <b>not</b> the one in
    /// <c>ClientService</c>. The rest of methods of <c>ClientService</c> must be
    /// called directly.
    ///
    /// For example, in a personalizable portal,<c>ClientService</c> could include:
    ///
    ///   <c>findServicePreferences</c>, <c>updateServicePreferences</c>,
    ///   <c>findLayout</c>, <c>updateLayout</c>, etc.
    ///
    /// In a electronic commerce shop <c>UserFacadeDelegate</c> could include:
    ///
    ///   <c>getShoppingCart</c>, <c>addToShoppingCart</c>,
    ///   <c>removeFromShoppingCart</c>, <c>makeOrder</c>,
    ///   <c>findPendingOrders</c>, etc.
    ///
    /// When needing to invoke directly a method of <c>ClientSession</c>, the
    /// property <c>SessionManager.ClientService</c> must be invoked in order
    /// to get the personal delegate (each client has his/her own delegate).
    ///
    /// Same as <c>ClientService</c>, there exist some logical
    /// restrictions with regard to the order of method calling. In particular,
    /// <c>updateClientDetails</c> and <c>changePassword</c>
    /// can not be called if <c>login</c> or <c>registerClient</c>
    /// have not been previously called. After the client calls one of these two
    ///  methods, the client is said to be authenticated.
    /// </summary>
    public class SessionManager
    {
        public static ShoppingCart shoppingCart;

        public static readonly String LOCALE_SESSION_ATTRIBUTE = "locale";

        public static readonly String CLIENT_SESSION_ATTRIBUTE =
               "ClientSession";

        public static readonly String CREDITCARD_SESSION_ATTRIBUTE =
             "CreditCardSession";

        public static readonly String PRODUCT_SESSION_ATTRIBUTE =
               "ProductSession";

        private static IClientService clientService;

        public IClientService ClientService
        {
            set { clientService = value; }
        }

        private static ICreditCardService creditCardService;

        public ICreditCardService CreditCardService
        {
            set { creditCardService = value; }
        }

        private static IProductService productService;

        public IProductService ProductService
        {
            set { productService = value; }
        }

        private static IShoppingCartService shoppingCartService;
        public IShoppingCartService ShoppingCartService
        {
            set { shoppingCartService = value; }
        }

        private static IClientOrderService clientOrderService;

        public IClientOrderService ClientOrderService
        {
            set { clientOrderService = value; }
        }

        private static IProductCommentService productCommentService;

        public IProductCommentService ProductCommentService
        {
            set { productCommentService = value; }
        }

        private static ITagService tagService;

        public ITagService TagService
        {
            set { tagService = value; }
        }

        private static ICategoryService categoryService;

        public ICategoryService CategoryService
        {
            set { categoryService = value; }
        }

        static SessionManager()
        {
            IIoCManager iocManager =
                (IIoCManager)HttpContext.Current.Application["managerIoC"];

            clientService = iocManager.Resolve<IClientService>();
            creditCardService = iocManager.Resolve<ICreditCardService>();

            productService = iocManager.Resolve<IProductService>();

            clientOrderService = iocManager.Resolve<IClientOrderService>();

            shoppingCartService = iocManager.Resolve<IShoppingCartService>();


            productCommentService = iocManager.Resolve<IProductCommentService>();
            categoryService = iocManager.Resolve<ICategoryService>();
            tagService = iocManager.Resolve<ITagService>();
            shoppingCart = new ShoppingCart();
        }

        #region Client methods

        /// <summary>
        /// Registers a new client.
        /// </summary>
        /// <param name="clientLogin"> Name of the login. </param>
        /// <param name="clientPassword"> The clear password. </param>
        /// <param name="clientDetails"> The client profile details. </param>
        /// <exception cref="DuplicateInstanceException"/>
        public static void RegisterClient(HttpContext context,
            String clientLogin, String clientPassword,
                ClientDetails clientDetails)
        {
            /* Register client. */
            long clientId = clientService.RegisterClient(clientLogin, clientPassword,
                clientDetails);

            /* Insert necessary objects in the session. */
            ClientSession clientSession = new ClientSession();
            clientSession.ClientId = clientId;
            clientSession.FirstName = clientDetails.FirstName;

            Locale locale = new Locale(clientDetails.ClientLanguage,
                clientDetails.Country);

            UpdateSessionForAuthenticatedClient(context, clientSession, locale);

            FormsAuthentication.SetAuthCookie(clientLogin, false);
        }

        /// <summary>
        /// Login method. Authenticates a client in the current context.
        /// </summary>
        /// <param name="context">Http Context includes request, response, etc.</param>
        /// <param name="clientLogin">Client login name</param>
        /// <param name="clearPassword">Password in clear text</param>
        /// <param name="rememberMyPassword">Remember password to the next logins</param>
        /// <exception cref="IncorrectPasswordException"/>
        /// <exception cref="InstanceNotFoundException"/>
        public static void Login(HttpContext context, String clientLogin,
           String clearPassword, Boolean rememberMyPassword)
        {
            /* Try to login, and if successful, update session with the necessary
             * objects for an authenticated client. */
            LoginResult loginResult = DoLogin(context, clientLogin,
                clearPassword, false, rememberMyPassword);

            /* Add cookies if requested. */
            if (rememberMyPassword)
            {
                CookiesManager.LeaveCookies(context, clientLogin,
                    loginResult.EncryptedPassword);
            }
        }

        /// <summary>
        /// Tries to log in with the corresponding method of
        /// <c>ClientService</c>, and if successful, inserts in the
        /// session the necessary objects for an authenticated client.
        /// </summary>
        /// <param name="context">Http Context includes request, response, etc.</param>
        /// <param name="clientLogin">Client Login name</param>
        /// <param name="password">Client Password</param>
        /// <param name="passwordIsEncrypted">Password is either encrypted or
        /// in clear text</param>
        /// <param name="rememberMyPassword">Remember password to the next
        /// logins</param>
        /// <exception cref="IncorrectPasswordException"/>
        /// <exception cref="InstanceNotFoundException"/>
        private static LoginResult DoLogin(HttpContext context,
             String clientLogin, String password, Boolean passwordIsEncrypted,
             Boolean rememberMyPassword)
        {
            LoginResult loginResult =
                clientService.Login(clientLogin, password,
                    passwordIsEncrypted);

            /* Insert necessary objects in the session. */

            ClientSession clientSession = new ClientSession();
            clientSession.ClientId = loginResult.ClientId;
            clientSession.FirstName = loginResult.ClientName;

            Locale locale =
                new Locale(loginResult.ClientLanguage, loginResult.Country);

            UpdateSessionForAuthenticatedClient(context, clientSession, locale);

            return loginResult;
        }

        /// <summary>
        /// Updates the session values for an previously authenticated client
        /// </summary>
        /// <param name="context">Http Context includes request, response, etc.</param>
        /// <param name="clientSession">The client data stored in session.</param>
        /// <param name="locale">The locale info.</param>
        private static void UpdateSessionForAuthenticatedClient(
            HttpContext context, ClientSession clientSession, Locale locale)
        {
            /* Insert objects in session. */
            context.Session.Add(CLIENT_SESSION_ATTRIBUTE, clientSession);
            context.Session.Add(LOCALE_SESSION_ATTRIBUTE, locale);
        }

        /// <summary>
        /// Determine if a client is authenticated
        /// </summary>
        /// <param name="context">Http Context includes request, response, etc.</param>
        /// <returns>
        /// 	<c>true</c> if is client authenticated
        ///     <c>false</c> otherwise
        /// </returns>
        public static Boolean IsClientAuthenticated(HttpContext context)
        {
            if (context.Session == null)
                return false;

            return (context.Session[CLIENT_SESSION_ATTRIBUTE] != null);
        }

        public static Locale GetLocale(HttpContext context)
        {
            Locale locale =
                (Locale)context.Session[LOCALE_SESSION_ATTRIBUTE];

            return locale;
        }

        /// <summary>
        /// Updates the client  details.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="clientDetails">The client details.</param>
        public static void UpdateClientDetails(HttpContext context,
            ClientDetails clientDetails)
        {
            /* Update client's details. */

            ClientSession clientSession =
                (ClientSession)context.Session[CLIENT_SESSION_ATTRIBUTE];

            clientService.UpdateClientDetails(clientSession.ClientId,
                clientDetails);

            /* Update client's session objects. */

            Locale locale = new Locale(clientDetails.ClientLanguage,
                clientDetails.Country);

            clientSession.FirstName = clientDetails.FirstName;

            UpdateSessionForAuthenticatedClient(context, clientSession, locale);
        }

        /// <summary>
        /// Finds the client details with the id stored in the session.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>The client details</returns>
        public static ClientDetails FindClientDetails(HttpContext context)
        {
            ClientSession clientSession =
                (ClientSession)context.Session[CLIENT_SESSION_ATTRIBUTE];

            ClientDetails clientDetails =
                clientService.FindClientDetails(clientSession.ClientId);

            return clientDetails;
        }

        /// <summary>
        /// Gets the client info stored in the session.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public static ClientSession GetClientSession(HttpContext context)
        {
            if (IsClientAuthenticated(context))
                return (ClientSession)context.Session[CLIENT_SESSION_ATTRIBUTE];
            else
                return null;
        }

        /// <summary>
        /// Changes the client's password
        /// </summary>
        /// <param name="context">Http Context includes request, response, etc.</param>
        /// <param name="oldClearPassword">The old password in clear text</param>
        /// <param name="newClearPassword">The new password in clear text</param>
        /// <exception cref="IncorrectPasswordException"/>
        public static void ChangePassword(HttpContext context,
               String oldClearPassword, String newClearPassword)
        {
            ClientSession clientSession =
                (ClientSession)context.Session[CLIENT_SESSION_ATTRIBUTE];

            clientService.ChangePassword(clientSession.ClientId,
                oldClearPassword, newClearPassword);

            /* Remove cookies. */
            CookiesManager.RemoveCookies(context);
        }

        /// <summary>
        /// Destroys the session, and removes the cookies if the client had
        /// selected "remember my password".
        /// </summary>
        /// <param name="context">Http Context includes request, response, etc.</param>
        public static void Logout(HttpContext context)
        {
            /* Remove cookies. */
            CookiesManager.RemoveCookies(context);

            /* Invalidate session. */
            context.Session.Abandon();

            /* Invalidate Authentication Ticket */
            FormsAuthentication.SignOut();
        }

        /// <sumary>
        /// Guarantees that the session will have the necessary objects if the
        /// client has been authenticated or had selected "remember my password"
        /// in the past.
        /// </sumary>
        /// <param name="context">Http Context includes request, response, etc.</param>
        public static void TouchSession(HttpContext context)
        {
            /* Check if "ClientSession" object is in the session. */
            ClientSession clientSession = null;

            if (context.Session != null)
            {
                clientSession =
                    (ClientSession)context.Session[CLIENT_SESSION_ATTRIBUTE];

                // If ClientSession object is in the session, nothing should be doing.
                if (clientSession != null)
                {
                    return;
                }
            }

            /*
             * The client had not been authenticated or his/her session has
             * expired. We need to check if the client has selected "remember my
             * password" in the last login (login name and password will come
             * as cookies). If so, we reconstruct client's session objects.
             */
            UpdateSessionFromCookies(context);
        }

        /// <summary>
        /// Tries to login (inserting necessary objects in the session) by using
        /// cookies (if present).
        /// </summary>
        /// <param name="context">Http Context includes request, response, etc.</param>
        private static void UpdateSessionFromCookies(HttpContext context)
        {
            HttpRequest request = context.Request;
            if (request.Cookies == null)
            {
                return;
            }

            /*
             * Check if the login name and the encrypted password come as
             * cookies.
             */
            String clientLogin = CookiesManager.GetClientLogin(context);
            String encryptedPassword = CookiesManager.GetEncryptedPassword(context);

            if ((clientLogin == null) || (encryptedPassword == null))
            {
                return;
            }

            /* If clientLogin and encryptedPassword have valid values (the client selected "remember
             * my password" option) try to login, and if successful, update session with the
             * necessary objects for an authenticated client.
             */
            try
            {
                DoLogin(context, clientLogin, encryptedPassword, true, true);

                /* Authentication Ticket. */
                FormsAuthentication.SetAuthCookie(clientLogin, true);
            }
            catch (Exception)
            { // Incorrect clientLogin or encryptedPassword
                return;
            }
        }

        public static List<CreditCardDetails> GetAllCards(HttpContext context)
        {
            ClientSession cSession =
                     (ClientSession)context.Session[CLIENT_SESSION_ATTRIBUTE];

            List<CreditCardDetails> cards = creditCardService.GetClientCards(cSession.ClientId);
            return cards;
        }

        public static void AddCard(HttpContext context,
            CreditCardDetails card)
        {
            ClientSession clientSession =
                (ClientSession)context.Session[CLIENT_SESSION_ATTRIBUTE];

            creditCardService.AddCard(clientSession.ClientId, card);
        }

        internal static void ChangeDefaultCard(HttpContext context, long cardId)
        {
            ClientSession clientSession =
                            (ClientSession)context.Session[CLIENT_SESSION_ATTRIBUTE];

            creditCardService.SelectDefaultCard(clientSession.ClientId, cardId);
        }

        internal static void DeleteShoppingCart()
        {
            for (int i = 0; i<SessionManager.shoppingCart.shoppingCartLines.Count; i++)
            {
              
                 shoppingCartService.RemoveFromCart(SessionManager.shoppingCart.shoppingCartLines.ElementAt(i), SessionManager.shoppingCart);
            }

        }

        internal static void DeleteShoppingCartOneRow(long productid)
        {

            for (int i = 0; i<SessionManager.shoppingCart.shoppingCartLines.Count; i++)
            {
                if (SessionManager.shoppingCart.shoppingCartLines.ElementAt(i).productId == productid)

                    shoppingCartService.RemoveFromCart(SessionManager.shoppingCart.shoppingCartLines.ElementAt(i), SessionManager.shoppingCart);
            }

        }


        #endregion Client methods

        #region Product Methods

        /// <summary>
        /// Finds the product details.
        /// </summary>
        /// <param name="context"> The product id. </param>
        /// <returns> The product details </returns>
        /// <exception cref="InstanceNotFoundException"/>
        public static ProductDetails FindProductDetails(long productId)
        {
            ProductDetails product = productService.FindProductDetails(productId);
            return product;
        }

        /// <summary>
        /// Update the product details.
        /// </summary>
        /// <param name="productId"> The product id. </param>
        /// <param name="prodDetails"> The product details. </param>
        /// <returns> The product details </returns>
        /// <exception cref="InstanceNotFoundException"/>
        public static ProductDetails UpdateProductDetails(long productId, ProductDetails prodDetails)
        {
            ProductDetails product = productService.UpdateProduct(productId, prodDetails);
            return product;
        }

        public static ProductDetails UpdateBooksDetails(long productId, BooksDetails prodDetails)
        {
            ProductDetails product = productService.UpdateBooks(productId, prodDetails);
            return product;
        }

        public static ProductDetails UpdateFilmsDetails(long productId, FilmsDetails prodDetails)
        {
            ProductDetails product = productService.UpdateFilms(productId, prodDetails);
            return product;
        }

        public static ProductDetails UpdateMusicDetails(long productId, MusicDetails prodDetails)
        {
            ProductDetails product = productService.UpdateMusic(productId, prodDetails);
            return product;
        }

        #endregion Product Methods

        #region ProductComment Methods

        /// <summary>
        /// Add Comment.
        /// </summary>
        /// <param name="context"> The product and client id. </param>
        /// <param name="comment"> The text of the comment. </param>
        /// <exception cref="InstanceNotFoundException"/>
        public static ProductComment AddProductComment(HttpContext context, long prodId, string comment, List<Tag> tags)
        {
            ClientSession clientSession =
                   (ClientSession)context.Session[CLIENT_SESSION_ATTRIBUTE];

            ProductComment prodComment = productCommentService.AddProductComment(prodId, comment, clientSession.ClientId);

            return prodComment;
        }

        /// <summary>
        /// Find a Comment.
        /// </summary>
        /// <param name="context"> The client id. </param>
        /// <param name="prodId"> The product Id. </param>
        /// <exception cref="InstanceNotFoundException"/>
        public static ProductCommentDetails FindProductComment(HttpContext context, long prodId)
        {
            ClientSession clientSession =
                   (ClientSession)context.Session[CLIENT_SESSION_ATTRIBUTE];

            ProductCommentDetails prodComment = productCommentService.FindProductDetailsByProdIdAndClientID(prodId, clientSession.ClientId);

            return prodComment;
        }

        /// <summary>
        /// Edit a Comment.
        /// </summary>

        /// <param name="prodDetails"> The comment  id. </param>
        /// <exception cref="InstanceNotFoundException"/>
        public static ProductCommentDetails EditProductComment(ProductCommentDetails prodDetails)
        {
            ProductCommentDetails prodComment = productCommentService.EditProductComment(prodDetails.CommentId, prodDetails);

            return prodComment;
        }

        /// <summary>
        /// Add Tags to a Comment.
        /// </summary>
        /// <param name="commentId"> The comment id. </param>
        /// <param name="tags"> The tags to addd. </param>
        public static void TagProductComment(long commentId, List<Tag> tags)
        {
            productCommentService.TagProductComment(commentId, tags);
        }

        /// <summary>
        /// See if a client comment the product
        /// </summary>
        /// <param name="productId"> The product Id. </param>
        /// <returns> True-> exist a comment, False-> Doesnt exist the comment</returns>

        public static bool ExistCommentFromClient(HttpContext context, long productId)
        {
            ClientSession clientSession =
                   (ClientSession)context.Session[CLIENT_SESSION_ATTRIBUTE];
            return productCommentService.ExistCommentFromClient(productId, clientSession.ClientId);
        }

        #endregion ProductComment Methods

        #region Tag Methods

        /// <summary>
        /// Get All Tags
        /// </summary>
        public static List<Tag> GetTags()
        {
            List<Tag> tags = tagService.GetAllTags();
            return tags;
        }

        /// <summary>
        /// Find Tag By Name
        /// </summary>
        /// <param name="tagName"> The name of the tag. </param>
        public static Tag FindTagByName(string tagName)
        {
            Tag tag = tagService.FindTagByName(tagName);
            return tag;
        }

        /// <summary>
        /// Create Tag
        /// </summary>
        /// <param name="tagName"> The name of the tag. </param>
        /// <exception cref="DuplicateInstanceException"/>
        public static Tag CreateTag(string tagName)
        {
            Tag tag = tagService.Create(tagName);
            return tag;
        }

        #endregion Tag Methods

        #region Category Methods

        /// <summary>
        /// Get Categories
        /// </summary>
        public static List<string> GetCategories()
        {
            List<string> cats = categoryService.GetCategoryNames();
            return cats;
        }

        /// <summary>
        /// Get Categories
        /// </summary>
        /// <param name="catName">The category Name</param>
        public static long GetCategoryId(string catName)
        {
            long id = categoryService.GetCategoryId(catName);
            return id;
        }

        #endregion Category Methods
    }
}