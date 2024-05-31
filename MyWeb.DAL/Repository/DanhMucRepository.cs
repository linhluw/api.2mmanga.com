using Dapper;
using Microsoft.Data.SqlClient;
using MyWeb.DAL.Data;
using MyWeb.DAL.Interface;
using MyWeb.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyWeb.DAL.Repository
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(ConfigOptions config) : base(config)
        {
        }

        public void Create(Category _object)
        {
            using (IDbCommand cmd = _db.CreateCommand())
            {
                cmd.CommandText = "sp_Category_Insert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Name", _object.Name));
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string Id)
        {
            using (IDbCommand cmd = _db.CreateCommand())
            {
                cmd.CommandText = "sp_Category_Delete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@PK_CategoryId", Id));
                cmd.ExecuteNonQuery();
            }
        }

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

            }
            return lst;
        }

        public Category GetById(string Id)
        {
            Category item = new Category();

            try
            {
                string command = string.Format("SELECT [PK_CategoryId],[Name] FROM [Category] WHERE Id='{0}'", Id);
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

            }
            return item ?? null;
        }

        public void Update(Category _object)
        {
            using (IDbCommand cmd = _db.CreateCommand())
            {
                cmd.CommandText = "sp_Category_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@PK_CategoryId", _object.PK_CategoryId));
                cmd.Parameters.Add(new SqlParameter("@Name", _object.Name));
                cmd.ExecuteNonQuery();
            }
        }
    }
}