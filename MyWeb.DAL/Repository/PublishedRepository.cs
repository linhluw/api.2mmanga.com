using Dapper;
using Microsoft.Data.SqlClient;
using MyWeb.COM.Helper;
using MyWeb.DAL.Data;
using MyWeb.DAL.Interface;
using MyWeb.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace MyWeb.DAL.Repository
{
    public class PublishedRepository : BaseRepository, IPublishedRepository
    {
        public PublishedRepository(ConfigOptions config) : base(config)
        {
        }

        /// <summary>
        /// Cập nhật thông tin
        /// </summary>
        /// <param name="_object"></param>
        /// <returns></returns>
        public bool CreateOrUpdate(Published _object)
        {
            try
            {
                using (IDbCommand cmd = _db.CreateCommand())
                {
                    cmd.CommandText = "sp_Published_InsertOrUpdate";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PK_PublishedId", _object.PK_PublishedId));
                    cmd.Parameters.Add(new SqlParameter("@Name", _object.Name));
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("PublishedRepository", ex);
                return false;
            }
        }

        /// <summary>
        /// Xóa
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Delete(Published _object)
        {
            try
            {
                using (IDbCommand cmd = _db.CreateCommand())
                {
                    cmd.CommandText = "sp_Published_Delete";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PK_PublishedId", _object.PK_PublishedId));
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("PublishedRepository", ex);
                return false;
            }
        }

        /// <summary>
        /// Lấy tất
        /// </summary>
        /// <returns></returns>
        public List<Published> GetAll()
        {
            List<Published> lst = new List<Published>();

            try
            {
                string command = "SELECT [PK_PublishedId],[Name] FROM [Published]";
                using (IDataReader dataReader = _db.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        Published item = new Published();
                        item.PK_PublishedId = dataReader["PK_PublishedId"].AsString();
                        item.Name = dataReader["Name"].AsString();
                        lst.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("PublishedRepository", ex);
            }
            return lst;
        }

        /// <summary>
        /// Lấy theo Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Published GetById(string Id)
        {
            Published item = new Published();

            try
            {
                string command = string.Format("SELECT [PK_PublishedId],[Name] FROM [Published] WHERE PK_PublishedId='{0}'", Id);
                using (IDataReader dataReader = _db.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        item.PK_PublishedId = dataReader["PK_PublishedId"].AsString();
                        item.Name = dataReader["Name"].AsString();
                    }
                }
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("PublishedRepository", ex);
            }
            return string.IsNullOrEmpty(item.PK_PublishedId) ? null : item;
        }
    }
}