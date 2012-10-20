using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quimank.Utilities.Entities;

namespace Salutem.Entities
{
    public class Person :  EntityBase
    {
        #region properties
        private string _name;
        /// <summary>
        /// Person's first name
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _lastName;
        /// <summary>
        /// Person's last name
        /// </summary>
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        #endregion
    }
}
