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
    public class OrderProductRepository : BaseRepository, IOrderProductRepository
    {
        public OrderProductRepository(ConfigOptions config) : base(config)
        {
        }

        /// <summary>
        /// Cập nhật thông tin
        /// </summary>
        /// <param name="_object"></param>
        /// <returns></returns>
        public bool CreateOrUpdate(OrderProduct _object)
        {
            try
            {
                using (IDbCommand cmd = _db.CreateCommand())
                {
                    cmd.CommandText = "sp_OrderProduct_InsertOrUpdate";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@FK_OrderId", _object.FK_OrderId));
                    cmd.Parameters.Add(new SqlParameter("@FK_ProductId", _object.FK_ProductId));
                    cmd.Parameters.Add(new SqlParameter("@Quantity", _object.Quantity));
                    cmd.Parameters.Add(new SqlParameter("@Price", _object.Price));
                    cmd.Parameters.Add(new SqlParameter("@Discount", _object.Discount));
                    cmd.Parameters.Add(new SqlParameter("@Payments", _object.Payments));
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("OrderProductRepository", ex);
                return false;
            }
        }

        public bool Delete(OrderProduct _object)
        {
            try
            {
                using (IDbCommand cmd = _db.CreateCommand())
                {
                    cmd.CommandText = "sp_OrderProduct_Delete";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@FK_OrderId", _object.FK_OrderId));
                    cmd.Parameters.Add(new SqlParameter("@FK_ProductId", _object.FK_ProductId));
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("OrderProductRepository", ex);
                return false;
            }
        }

        public List<OrderProduct> GetAll()
        {
            return new List<OrderProduct>();
        }

        public OrderProduct GetById(string Id)
        {
            return new OrderProduct();
        }

        public List<OrderProduct> GetOrderProductByOrderId(string OrderId)
        {
            List<OrderProduct> lst = new List<OrderProduct>();

            try
            {
                string command = string.Format("SELECT [FK_OrderId],[FK_ProductId],[Quantity],[Price],[Discount],[Payments] FROM [OrderProduct] WHERE FK_OrderId='{0}'", OrderId);
                using (IDataReader dataReader = _db.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        OrderProduct item = new OrderProduct();
                        item.FK_OrderId = dataReader["FK_OrderId"].AsString();
                        item.FK_ProductId = dataReader["FK_ProductId"].AsString();
                        item.Quantity = dataReader["Quantity"].AsInt(0);
                        item.Price = dataReader["Price"].AsInt(0);
                        item.Discount = dataReader["Discount"].AsInt(0);
                        item.Payments = dataReader["Payments"].AsInt(0);
                        lst.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("OrderProductRepository", ex);
            }
            return lst;
        }
    }
}