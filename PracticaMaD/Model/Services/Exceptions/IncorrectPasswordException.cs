using System;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.Exceptions
{
    /// <summary>
    /// Public <c>ModelException</c> which captures the error
    /// with the passwords of the users.
    /// </summary>
    [Serializable]
    public class IncorrectPasswordException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="IncorrectPasswordException"/> class.
        /// </summary>
        /// <param name="clientLogin"><c>clientLogin</c> that causes the error.</param>
        public IncorrectPasswordException(String clientLogin)
            : base("Incorrect password exception => clientLogin = " + clientLogin)
        {
            this.ClientLogin = clientLogin;
        }

        /// <summary>
        /// Stores the User login name of the exception
        /// </summary>
        /// <value>The name of the login.</value>
        public String ClientLogin { get; private set; }
    }
}