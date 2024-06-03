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
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(ConfigOptions config) : base(config)
        {
        }

        /// <summary>
        /// Cập nhật thông tin
        /// </summary>
        /// <param name="_object"></param>
        /// <returns></returns>
        public bool CreateOrUpdate(Category _object)
        {
            try
            {
                using (IDbCommand cmd = _db.CreateCommand())
                {
                    cmd.CommandText = "sp_Category_InsertOrUpdate";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PK_CategoryId", _object.PK_CategoryId));
                    cmd.Parameters.Add(new SqlParameter("@Name", _object.Name));
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("CategoryRepository", ex);
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
                    cmd.CommandText = "sp_Category_Delete";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PK_CategoryId", Id));
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("CategoryRepository", ex);
                return false;
            }
        }

        /// <summary>
        /// Lấy tất
        /// </summary>
        /// <returns></returns>
        public List<Category> GetAll()
        {
            List<Category> lst = new List<Category>();

            try
            {
                string command = "SELECT [PK_CategoryId],[Name] FROM [Category]";
                using (IDataReader dataReader = _db.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        Category item = new Category();
                        item.PK_CategoryId = dataReader["PK_CategoryId"].AsString();
                        item.Name = dataReader["Name"].AsString();
                        lst.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("CategoryRepository", ex);
            }
            return lst;
        }

        /// <summary>
        /// Lấy theo Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Category GetById(string Id)
        {
            Category item = new Category();

            try
            {
                string command = string.Format("SELECT [PK_CategoryId],[Name] FROM [Category] WHERE PK_CategoryId='{0}'", Id);
                using (IDataReader dataReader = _db.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        item.PK_CategoryId = dataReader["PK_CategoryId"].AsString();
                        item.Name = dataReader["Name"].AsString();
                    }
                }
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("CategoryRepository", ex);
            }
            return string.IsNullOrEmpty(item.PK_CategoryId) ? null : item;
        }
    }
}