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
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(ConfigOptions config) : base(config)
        {
        }

        /// <summary>
        /// Cập nhật thông tin
        /// </summary>
        /// <param name="_object"></param>
        /// <returns></returns>
        public bool CreateOrUpdate(User _object)
        {
            try
            {
                using (IDbCommand cmd = _db.CreateCommand())
                {
                    cmd.CommandText = "sp_User_Insert";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PK_UserId", _object.PK_UserId));
                    cmd.Parameters.Add(new SqlParameter("@Name", _object.Name));
                    cmd.Parameters.Add(new SqlParameter("@Password", _object.Password));
                    cmd.Parameters.Add(new SqlParameter("@Phone", _object.Phone));
                    cmd.Parameters.Add(new SqlParameter("@Address", _object.Address));
                    cmd.Parameters.Add(new SqlParameter("@CreatedDate", _object.CreatedDate));
                    cmd.Parameters.Add(new SqlParameter("@Active", _object.Active));
                    cmd.Parameters.Add(new SqlParameter("@PermissionId", _object.PermissionId));
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("UserRepository", ex);
                return false;
            }
        }

        /// <summary>
        /// Xóa
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Delete(string Id)
        {
            try
            {
                using (IDbCommand cmd = _db.CreateCommand())
                {
                    cmd.CommandText = "sp_User_Delete";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PK_UserId", Id));
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("UserRepository", ex);
                return false;
            }
        }

        /// <summary>
        /// Lấy tất
        /// </summary>
        /// <returns></returns>
        public List<User> GetAll()
        {
            List<User> lst = new List<User>();

            try
            {
                string command = "SELECT [PK_UserId],[Name],[UserName],[Phone],[Address],[Active],[PermissionId] FROM [User]";
                using (IDataReader dataReader = _db.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        User item = new User();
                        item.PK_UserId = dataReader["PK_UserId"].AsString();
                        item.Name = dataReader["Name"].AsString();
                        item.UserName = dataReader["UserName"].AsString();
                        item.Phone = dataReader["Phone"].AsString();
                        item.Address = dataReader["Address"].AsString();
                        item.Active =dataReader["Active"].AsBool(false);
                        item.PermissionId = dataReader["PermissionId"].AsInt(0);
                        lst.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("UserRepository", ex);
            }
            return lst;
        }

        /// <summary>
        /// Lấy theo Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public User GetById(string Id)
        {
            User item = new User();

            try
            {
                string command = string.Format("SELECT [PK_UserId],[Name],[UserName],[Phone],[Address],[Active],[PermissionId] FROM [User] WHERE PK_UserId='{0}'", Id);
                using (IDataReader dataReader = _db.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        item.PK_UserId = dataReader["PK_UserId"].AsString();
                        item.Name = dataReader["Name"].AsString();
                        item.UserName = dataReader["UserName"].AsString();
                        item.Phone = dataReader["Phone"].AsString();
                        item.Address = dataReader["Address"].AsString();
                        item.Active = dataReader["Active"].AsBool(false);
                        item.PermissionId = dataReader["PermissionId"].AsInt(0);
                    }
                }
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("UserRepository", ex);
            }
            return string.IsNullOrEmpty(item.PK_UserId) ? null : item;
        }
    }
}