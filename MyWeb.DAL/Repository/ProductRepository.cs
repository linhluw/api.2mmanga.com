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
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(ConfigOptions config) : base(config)
        {
        }

        /// <summary>
        /// Cập nhật thông tin
        /// </summary>
        /// <param name="_object"></param>
        /// <returns></returns>
        public bool CreateOrUpdate(Product _object)
        {
            try
            {
                using (IDbCommand cmd = _db.CreateCommand())
                {
                    cmd.CommandText = "sp_Product_InsertOrUpdate";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PK_ProductId", _object.PK_ProductId));
                    cmd.Parameters.Add(new SqlParameter("@Name", _object.Name));
                    cmd.Parameters.Add(new SqlParameter("@TagName", _object.TagName));
                    cmd.Parameters.Add(new SqlParameter("@SignName", _object.SignName));
                    cmd.Parameters.Add(new SqlParameter("@Images", _object.Images));
                    cmd.Parameters.Add(new SqlParameter("@Quantity", _object.Quantity));
                    cmd.Parameters.Add(new SqlParameter("@Price", _object.Price));
                    cmd.Parameters.Add(new SqlParameter("@Discount", _object.Discount));
                    cmd.Parameters.Add(new SqlParameter("@Weight", _object.Weight));
                    cmd.Parameters.Add(new SqlParameter("@Details", _object.Details));
                    cmd.Parameters.Add(new SqlParameter("@BarCode", _object.BarCode));
                    cmd.Parameters.Add(new SqlParameter("@SapoCode", _object.SapoCode));
                    cmd.Parameters.Add(new SqlParameter("@FK_PublishedId", _object.FK_PublishedId));
                    cmd.Parameters.Add(new SqlParameter("@FK_CategoryId", _object.FK_CategoryId));
                    cmd.Parameters.Add(new SqlParameter("@ReleaseDate", _object.ReleaseDate));
                    cmd.Parameters.Add(new SqlParameter("@CreatedDate", _object.CreatedDate));
                    cmd.Parameters.Add(new SqlParameter("@IsSoldAll", _object.IsSoldAll));
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("ProductRepository", ex);
                return false;
            }
        }

        /// <summary>
        /// Xóa
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Delete(Product _object)
        {
            try
            {
                using (IDbCommand cmd = _db.CreateCommand())
                {
                    cmd.CommandText = "sp_Product_Delete";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PK_ProductId", _object.PK_ProductId));
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("ProductRepository", ex);
                return false;
            }
        }

        /// <summary>
        /// Lấy tất
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAll()
        {
            List<Product> lst = new List<Product>();

            try
            {
                string command = "SELECT [PK_ProductId],[Name],[TagName],[SignName],[Images],[Quantity],[Price],[Discount],[Weight],[Details],[BarCode],[SapoCode],[FK_PublishedId],[FK_CategoryId],[ReleaseDate],[IsSoldAll] FROM [Product]";
                using (IDataReader dataReader = _db.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        Product item = new Product();
                        item.PK_ProductId = dataReader["PK_ProductId"].AsString();
                        item.Name = dataReader["Name"].AsString();
                        item.TagName = dataReader["TagName"].AsString();
                        item.SignName = dataReader["SignName"].AsString();
                        item.Images = dataReader["Images"].AsString();
                        item.Quantity = dataReader["Quantity"].AsInt(0);
                        item.Price = dataReader["Price"].AsInt(0);
                        item.Discount = dataReader["Discount"].AsInt(0);
                        item.Weight = dataReader["Weight"].AsInt(0);
                        item.Details = dataReader["Details"].AsString();
                        item.BarCode = dataReader["BarCode"].AsString();
                        item.SapoCode = dataReader["SapoCode"].AsString();
                        item.FK_PublishedId = dataReader["FK_PublishedId"].AsString();
                        item.FK_CategoryId = dataReader["FK_CategoryId"].AsString();
                        item.ReleaseDate = dataReader["ReleaseDate"].AsDateTime();
                        item.IsSoldAll = dataReader["IsSoldAll"].AsBool(false);
                        lst.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("ProductRepository", ex);
            }
            return lst;
        }

        /// <summary>
        /// Lấy theo Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Product GetById(string Id)
        {
            Product item = new Product();

            try
            {
                string command = string.Format("SELECT [PK_ProductId],[Name],[TagName],[SignName],[Images],[Quantity],[Price],[Discount],[Weight],[Details],[BarCode],[SapoCode],[FK_PublishedId],[FK_CategoryId],[ReleaseDate],[IsSoldAll] FROM [Product] WHERE PK_ProductId='{0}'", Id);
                using (IDataReader dataReader = _db.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        item.PK_ProductId = dataReader["PK_ProductId"].AsString();
                        item.Name = dataReader["Name"].AsString();
                        item.TagName = dataReader["TagName"].AsString();
                        item.SignName = dataReader["SignName"].AsString();
                        item.Images = dataReader["Images"].AsString();
                        item.Quantity = dataReader["Quantity"].AsInt(0);
                        item.Price = dataReader["Price"].AsInt(0);
                        item.Discount = dataReader["Discount"].AsInt(0);
                        item.Weight = dataReader["Weight"].AsInt(0);
                        item.Details = dataReader["Details"].AsString();
                        item.BarCode = dataReader["BarCode"].AsString();
                        item.SapoCode = dataReader["SapoCode"].AsString();
                        item.FK_PublishedId = dataReader["FK_PublishedId"].AsString();
                        item.FK_CategoryId = dataReader["FK_CategoryId"].AsString();
                        item.ReleaseDate = dataReader["ReleaseDate"].AsDateTime();
                        item.IsSoldAll = dataReader["IsSoldAll"].AsBool(false);
                    }
                }
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("ProductRepository", ex);
            }
            return string.IsNullOrEmpty(item.PK_ProductId) ? null : item;
        }
    }
}