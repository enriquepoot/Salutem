using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Salutem.Entities;
using Quimank.Utilities.DataAccess;

namespace Salutem.DataAccess.Repositories
{
    public class PersonRepository : BaseRepository<Person>
    {
        public PersonRepository(string connectionString)
            : base(connectionString)
        {
        }

        public override Person ConvertFrom(System.Data.IDataReader rd)
        {
            var entity = new Person();
            entity.Name = rd.GetString(rd.GetOrdinal("Name"));
            entity.LastName = rd.GetString(rd.GetOrdinal("LastName"));
            return entity;
        }

        public override Dictionary<string, object> ConvertFrom(Person entity)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("Name", entity.Name);
            dict.Add("LastName", entity.LastName);
            return dict;
        }
    }
}
