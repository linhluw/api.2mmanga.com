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
    public class CartRepository : BaseRepository, ICartRepository
    {
        public CartRepository(ConfigOptions config) : base(config)
        {
        }

        /// <summary>
        /// Cập nhật thông tin
        /// </summary>
        /// <param name="_object"></param>
        /// <returns></returns>
        public bool CreateOrUpdate(Cart _object)
        {
            try
            {
                using (IDbCommand cmd = _db.CreateCommand())
                {
                    cmd.CommandText = "sp_Cart_InsertOrUpdate";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@FK_ProductId", _object.FK_ProductId));
                    cmd.Parameters.Add(new SqlParameter("@Quantity", _object.Quantity));
                    cmd.Parameters.Add(new SqlParameter("@FK_UserId", _object.FK_UserId));
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("CartRepository", ex);
                return false;
            }
        }

        public bool Delete(string Id)
        {
            return true;
        }


        /// <summary>
        /// Xóa
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteCart(string ProductId, string UserId)
        {
            try
            {
                using (IDbCommand cmd = _db.CreateCommand())
                {
                    cmd.CommandText = "sp_Cart_Delete";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@FK_ProductId", ProductId));
                    cmd.Parameters.Add(new SqlParameter("@FK_UserId", UserId));
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("CartRepository", ex);
                return false;
            }
        }

        public List<Cart> GetAll()
        {
            return new List<Cart>();
        }

        public Cart GetById(string Id)
        {
            return new Cart();
        }

        public List<Cart> GetCartByUserId(string UserId)
        {
            List<Cart> lst = new List<Cart>();

            try
            {
                string command = string.Format("SELECT [FK_ProductId],[Quantity],[FK_UserId] FROM [Cart] WHERE FK_UserId='{0}'", UserId);
                using (IDataReader dataReader = _db.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        Cart item = new Cart();
                        item.FK_ProductId = dataReader["FK_ProductId"].AsString();
                        item.Quantity = dataReader["Quantity"].AsInt(0);
                        item.FK_UserId = dataReader["FK_UserId"].AsString();
                        lst.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("CartRepository", ex);
            }
            return lst;
        }
    }
}