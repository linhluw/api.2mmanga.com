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
    public class GroupNewsRepository : BaseRepository, IGroupNewsRepository
    {
        public GroupNewsRepository(ConfigOptions config) : base(config)
        {
        }

        /// <summary>
        /// Cập nhật thông tin
        /// </summary>
        /// <param name="_object"></param>
        /// <returns></returns>
        public bool CreateOrUpdate(GroupNews _object)
        {
            try
            {
                using (IDbCommand cmd = _db.CreateCommand())
                {
                    cmd.CommandText = "sp_GroupNews_InsertOrUpdate";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PK_GroupNewsId", _object.PK_GroupNewsId));
                    cmd.Parameters.Add(new SqlParameter("@Name", _object.Name));
                    cmd.Parameters.Add(new SqlParameter("@TagName", _object.TagName));
                    cmd.Parameters.Add(new SqlParameter("@Description", _object.Description));
                    cmd.Parameters.Add(new SqlParameter("@Order", _object.Order));
                    cmd.Parameters.Add(new SqlParameter("@IsActive", _object.IsActive));
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("GroupNewsRepository", ex);
                return false;
            }
        }

        /// <summary>
        /// Xóa
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Delete(GroupNews _object)
        {
            try
            {
                using (IDbCommand cmd = _db.CreateCommand())
                {
                    cmd.CommandText = "sp_GroupNews_Delete";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PK_GroupNewsId", _object.PK_GroupNewsId));
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("GroupNewsRepository", ex);
                return false;
            }
        }

        /// <summary>
        /// Lấy tất
        /// </summary>
        /// <returns></returns>
        public List<GroupNews> GetAll()
        {
            List<GroupNews> lst = new List<GroupNews>();

            try
            {
                string command = "SELECT [PK_GroupNewsId],[Name],[TagName],[Description],[Order],[Active] FROM [GroupNews]";
                using (IDataReader dataReader = _db.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        GroupNews item = new GroupNews();
                        item.PK_GroupNewsId = dataReader["PK_GroupNewsId"].AsString();
                        item.Name = dataReader["Name"].AsString();
                        item.TagName = dataReader["TagName"].AsString();
                        item.Description = dataReader["Description"].AsString();
                        item.Order = dataReader["Order"].AsInt(0);
                        item.IsActive = dataReader["IsActive"].AsBool(false);
                        lst.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("GroupNewsRepository", ex);
            }
            return lst;
        }

        /// <summary>
        /// Lấy theo Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public GroupNews GetById(string Id)
        {
            GroupNews item = new GroupNews();

            try
            {
                string command = string.Format("SELECT [PK_GroupNewsId],[Name],[TagName],[Description],[Order],[Active] FROM [GroupNews] WHERE PK_GroupNewsId='{0}'", Id);
                using (IDataReader dataReader = _db.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        item.PK_GroupNewsId = dataReader["PK_GroupNewsId"].AsString();
                        item.Name = dataReader["Name"].AsString();
                        item.TagName = dataReader["TagName"].AsString();
                        item.Description = dataReader["Description"].AsString();
                        item.Order = dataReader["Order"].AsInt(0);
                        item.IsActive = dataReader["IsActive"].AsBool(false);
                    }
                }
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("GroupNewsRepository", ex);
            }
            return string.IsNullOrEmpty(item.PK_GroupNewsId) ? null : item;
        }
    }
}