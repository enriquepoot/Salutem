using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quimank.Utilities.DataAccess;
using Salutem.Entities;
using Salutem.DataAccess.Interfaces;
using System.Data.SqlClient;

namespace Salutem.DataAccess.Repositories
{
    public class AccessRepository : BaseRepository<Access>, IAccessRepository
    {
        public override Access ConvertFrom(System.Data.IDataReader rd)
        {
            var entity = new Access();
            entity.UserIdentifier = rd.GetString(rd.GetOrdinal("UserIdentifier"));
            entity.PasswordHash = rd.GetString(rd.GetOrdinal("PasswordHash"));
            entity.PasswordSalt = rd.GetString(rd.GetOrdinal("PasswordSalt"));
            entity.PersonID = rd.GetGuid(rd.GetOrdinal("PersonID"));
            return entity;
        }

        public override Dictionary<string, object> ConvertFrom(Access entity)
        {
            var col = new Dictionary<string, object>();
            col.Add("UserIdentifier", entity.UserIdentifier);
            col.Add("PasswordHash", entity.PasswordHash);
            col.Add("PasswordSalt", entity.PasswordSalt);
            col.Add("PersonID", entity.PersonID);
            return col;
        }

        public Access GetByUserAndPassword(string userIdentifier, string passwordHash = null)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = typeof(Access).Name + "GetByUserAndPassword";
                command.Parameters.AddWithValue("UserIdentifier", userIdentifier);
                if(!string.IsNullOrEmpty(passwordHash))
                    command.Parameters.AddWithValue("PasswordHash", passwordHash);
                var rd = command.ExecuteReader();
                while (rd.Read())
                {
                    var entity = ConvertFrom(rd);
                    return AddBaseDataFrom(entity, rd);
                }
                return default(Access);
            }
        }
    }
}
