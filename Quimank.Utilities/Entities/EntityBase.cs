using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quimank.Utilities.Entities
{
    public class EntityBase
    {
        #region properties
        private Guid _id;
        /// <summary>
        /// Entity Identifier
        /// </summary>
        public Guid ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private DateTime _crDt;
        /// <summary>
        /// Entity creation date
        /// </summary>
        public DateTime CrDt
        {
            get { return _crDt; }
            set { _crDt = value; }
        }

        private DateTime _mdDt;
        /// <summary>
        /// Entity last modification date
        /// </summary>
        public DateTime MdDt
        {
            get { return _mdDt; }
            set { _mdDt = value; }
        }

        private bool _deleted;
        /// <summary>
        /// Specify if the entity is marked as deleted in the database
        /// </summary>
        public bool Deleted
        {
            get { return _deleted; }
            set { _deleted = value; }
        }
        #endregion
    }
}
