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
    public class NewsRepository : BaseRepository, INewsRepository
    {
        public NewsRepository(ConfigOptions config) : base(config)
        {
        }

        /// <summary>
        /// Cập nhật thông tin
        /// </summary>
        /// <param name="_object"></param>
        /// <returns></returns>
        public bool CreateOrUpdate(News _object)
        {
            try
            {
                using (IDbCommand cmd = _db.CreateCommand())
                {
                    cmd.CommandText = "sp_News_InsertOrUpdate";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PK_NewsId", _object.PK_NewsId));
                    cmd.Parameters.Add(new SqlParameter("@Name", _object.Name));
                    cmd.Parameters.Add(new SqlParameter("@TagName", _object.TagName));
                    cmd.Parameters.Add(new SqlParameter("@SignName", _object.SignName));
                    cmd.Parameters.Add(new SqlParameter("@FK_GroupNewsId", _object.FK_GroupNewsId));
                    cmd.Parameters.Add(new SqlParameter("@ShortDetail", _object.ShortDetail));
                    cmd.Parameters.Add(new SqlParameter("@Detail", _object.Detail));
                    cmd.Parameters.Add(new SqlParameter("@Images", _object.Images));
                    cmd.Parameters.Add(new SqlParameter("@TagIDs", _object.TagIDs));
                    cmd.Parameters.Add(new SqlParameter("@CreatedPush", _object.CreatedPush));
                    cmd.Parameters.Add(new SqlParameter("@CreatedDate", _object.CreatedDate));
                    cmd.Parameters.Add(new SqlParameter("@CreatedByUser", _object.CreatedByUser));
                    cmd.Parameters.Add(new SqlParameter("@UpdatedDate", _object.UpdatedDate));
                    cmd.Parameters.Add(new SqlParameter("@UpdatedByUser", _object.UpdatedByUser));
                    cmd.Parameters.Add(new SqlParameter("@IsPublish", _object.IsPublish));
                    cmd.Parameters.Add(new SqlParameter("@IsActive", _object.IsActive));
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("NewsRepository", ex);
                return false;
            }
        }

        /// <summary>
        /// Xóa
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Delete(News _object)
        {
            try
            {
                using (IDbCommand cmd = _db.CreateCommand())
                {
                    cmd.CommandText = "sp_News_Delete";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PK_NewsId", _object.PK_NewsId));
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("NewsRepository", ex);
                return false;
            }
        }

        /// <summary>
        /// Lấy tất
        /// </summary>
        /// <returns></returns>
        public List<News> GetAll()
        {
            List<News> lst = new List<News>();

            try
            {
                string command = "SELECT [PK_NewsId],[Name],[TagName],[SignName],[FK_GroupNewsId],[ShortDetail],[Detail],[Images],[TagIDs],[CreatedPush],[IsPublish],[IsActive] FROM [News]";
                using (IDataReader dataReader = _db.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        News item = new News();
                        item.PK_NewsId = dataReader["PK_NewsId"].AsString();
                        item.Name = dataReader["Name"].AsString();
                        item.TagName = dataReader["TagName"].AsString();
                        item.SignName = dataReader["SignName"].AsString();
                        item.FK_GroupNewsId = dataReader["FK_GroupNewsId"].AsString();
                        item.ShortDetail = dataReader["ShortDetail"].AsString();
                        item.Detail = dataReader["Detail"].AsString();
                        item.Images = dataReader["Images"].AsString();
                        item.TagIDs = dataReader["TagIDs"].AsString();
                        item.CreatedPush = dataReader["CreatedPush"].AsDateTime();
                        item.IsPublish = dataReader["IsPublish"].AsBool(false);
                        item.IsActive = dataReader["IsActive"].AsBool(false);
                        lst.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("NewsRepository", ex);
            }
            return lst;
        }

        /// <summary>
        /// Lấy theo Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public News GetById(string Id)
        {
            News item = new News();

            try
            {
                string command = string.Format("SELECT [PK_NewsId],[Name],[TagName],[SignName],[FK_GroupNewsId],[ShortDetail],[Detail],[Images],[TagIDs],[CreatedPush],[IsPublish],[IsActive] FROM [News] WHERE PK_NewsId='{0}'", Id);
                using (IDataReader dataReader = _db.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        item.PK_NewsId = dataReader["PK_NewsId"].AsString();
                        item.Name = dataReader["Name"].AsString();
                        item.TagName = dataReader["TagName"].AsString();
                        item.SignName = dataReader["SignName"].AsString();
                        item.FK_GroupNewsId = dataReader["FK_GroupNewsId"].AsString();
                        item.ShortDetail = dataReader["ShortDetail"].AsString();
                        item.Detail = dataReader["Detail"].AsString();
                        item.Images = dataReader["Images"].AsString();
                        item.TagIDs = dataReader["TagIDs"].AsString();
                        item.CreatedPush = dataReader["CreatedPush"].AsDateTime();
                        item.IsPublish = dataReader["IsPublish"].AsBool(false);
                        item.IsActive = dataReader["IsActive"].AsBool(false);
                    }
                }
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("NewsRepository", ex);
            }
            return string.IsNullOrEmpty(item.PK_NewsId) ? null : item;
        }
    }
}