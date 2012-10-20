using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quimank.Utilities.DataAccess;
using Quimank.Utilities.Entities;
using System.Data.SqlClient;
using System.Data;

namespace Quimank.Utilities.DataAccess
{
    public abstract class BaseRepository<T> : IRepositoryBase<T>
        where T : EntityBase
    {
        protected readonly string _connectionString;
        
        public BaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public abstract T ConvertFrom(IDataReader rd);
        public abstract Dictionary<string, object> ConvertFrom(T entity);

        public T AddBaseDataFrom(T entity, IDataReader rd)
        {
            entity.ID = rd.GetGuid(rd.GetOrdinal("ID"));
            entity.CrDt = rd.GetDateTime(rd.GetOrdinal("CrDt"));
            entity.MdDt = rd.GetDateTime(rd.GetOrdinal("MdDt"));
            entity.Deleted = rd.GetBoolean(rd.GetOrdinal("Deleted"));
            return entity;
        }

        public IEnumerable<T> GetAllWithDeleted()
        {
            using(SqlConnection conn = new SqlConnection(this._connectionString))
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = typeof(T).Name+"GetAll";
                command.Parameters.AddWithValue("WithDeleted", true);
                var rd = command.ExecuteReader();
                while(rd.Read())
                {
                    var entity = ConvertFrom(rd);
                    yield return AddBaseDataFrom(entity, rd);
                }
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = typeof(T).Name + "GetAll";
                var rd = command.ExecuteReader();
                while (rd.Read())
                {
                    var entity = ConvertFrom(rd);
                    yield return AddBaseDataFrom(entity, rd);
                }
            }
        }

        public T GetById(Guid id)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = typeof(T).Name + "GetById";
                command.Parameters.AddWithValue("Id", id);
                var rd = command.ExecuteReader();
                while (rd.Read())
                {
                    var entity = ConvertFrom(rd);
                    return AddBaseDataFrom(entity, rd);
                }
                return default(T);
            }
        }

        private void GeneralUpdate(T obj)
        {
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = typeof(T).Name + "Update";
                command.Parameters.AddWithValue("Id", obj.ID);
                //Add values
                var prm = ConvertFrom(obj);
                foreach (var item in prm)
                {
                    command.Parameters.AddWithValue(item.Key, item.Value);
                }
                var identity = command.ExecuteScalar();
                obj.ID = Guid.Parse(identity.ToString());
            }
        }

        public void Add(T obj)
        {
            obj.ID = Guid.Empty;
            GeneralUpdate(obj);
        }

        public void Update(T obj)
        {
            if (obj.ID == Guid.Empty)
                throw new Exception("ID cannot be empty");
            GeneralUpdate(obj);
        }

        public void Delete(T obj)
        {
            if (obj.ID == Guid.Empty)
                throw new Exception("ID cannot be empty");
            using (SqlConnection conn = new SqlConnection(this._connectionString))
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = typeof(T).Name + "Update";
                command.Parameters.AddWithValue("Id", obj.ID);
                //Add values
                var prm = ConvertFrom(obj);
                foreach (var item in prm)
                {
                    command.Parameters.AddWithValue(item.Key, item.Value);
                }
                command.Parameters.AddWithValue("Deleted", true);
                command.ExecuteNonQuery();
            }
        }
    }
}
