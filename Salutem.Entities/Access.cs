using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Salutem.Entities
{
    public class Access
    {
        #region properties
        private string _userIdentifier;
        /// <summary>
        /// User's email used as identifier
        /// </summary>
        public string UserIdentifier
        {
            get { return _userIdentifier; }
            set { _userIdentifier = value; }
        }

        private string _passwordHash;
        /// <summary>
        /// User's Password Hash
        /// </summary>
        public string PasswordHash
        {
            get { return _passwordHash; }
            set { _passwordHash = value; }
        }

        private string _passwordSalt;
        /// <summary>
        /// User's Password Salt
        /// </summary>
        public string PasswordSalt
        {
            get { return _passwordSalt; }
            set { _passwordSalt = value; }
        }

        private Guid _personID;
        /// <summary>
        /// Identifier of the person whose this acces user belongs
        /// </summary>
        public Guid PersonID
        {
            get { return _personID; }
            set { _personID = value; }
        }
        #endregion
    }
}
