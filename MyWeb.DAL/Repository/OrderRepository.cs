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
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(ConfigOptions config) : base(config)
        {
        }

        /// <summary>
        /// Cập nhật thông tin
        /// </summary>
        /// <param name="_object"></param>
        /// <returns></returns>
        public bool CreateOrUpdate(Order _object)
        {
            try
            {
                using (IDbCommand cmd = _db.CreateCommand())
                {
                    cmd.CommandText = "sp_Order_InsertOrUpdate";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PK_OrderId", _object.PK_OrderId));
                    cmd.Parameters.Add(new SqlParameter("@FK_UserId", _object.FK_UserId));
                    cmd.Parameters.Add(new SqlParameter("@Phone", _object.Phone));
                    cmd.Parameters.Add(new SqlParameter("@Address", _object.Address));
                    cmd.Parameters.Add(new SqlParameter("@TotalPrice", _object.TotalPrice));
                    cmd.Parameters.Add(new SqlParameter("@Status", _object.Status));
                    cmd.Parameters.Add(new SqlParameter("@IsCancel", _object.IsCancel));
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("OrderRepository", ex);
                return false;
            }
        }

        /// <summary>
        /// Xóa
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Delete(Order _object)
        {
            try
            {
                using (IDbCommand cmd = _db.CreateCommand())
                {
                    cmd.CommandText = "sp_Order_Delete";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PK_OrderId", _object.PK_OrderId));
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("OrderRepository", ex);
                return false;
            }
        }

        /// <summary>
        /// Lấy tất
        /// </summary>
        /// <returns></returns>
        public List<Order> GetAll()
        {
            List<Order> lst = new List<Order>();

            try
            {
                string command = "SELECT [PK_OrderId],[FK_UserId],[Phone],[Address],[TotalPrice],[Status],[IsCancel] FROM [Order]";
                using (IDataReader dataReader = _db.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        Order item = new Order();
                        item.PK_OrderId = dataReader["PK_OrderId"].AsString();
                        item.FK_UserId = dataReader["FK_UserId"].AsString();
                        item.Phone = dataReader["Phone"].AsString();
                        item.Address = dataReader["Address"].AsString();
                        item.TotalPrice = dataReader["TotalPrice"].AsInt(0);
                        item.Status = dataReader["Status"].AsInt(0);
                        item.IsCancel = dataReader["IsCancel"].AsBool(false);
                        lst.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("OrderRepository", ex);
            }
            return lst;
        }

        /// <summary>
        /// Lấy theo Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Order GetById(string Id)
        {
            Order item = new Order();

            try
            {
                string command = string.Format("SELECT [PK_OrderId],[FK_UserId],[Phone],[Address],[TotalPrice],[Status],[IsCancel] FROM [Order] WHERE PK_OrderId='{0}'", Id);
                using (IDataReader dataReader = _db.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        item.PK_OrderId = dataReader["PK_OrderId"].AsString();
                        item.FK_UserId = dataReader["FK_UserId"].AsString();
                        item.Phone = dataReader["Phone"].AsString();
                        item.Address = dataReader["Address"].AsString();
                        item.TotalPrice = dataReader["TotalPrice"].AsInt(0);
                        item.Status = dataReader["Status"].AsInt(0);
                        item.IsCancel = dataReader["IsCancel"].AsBool(false);
                    }
                }
            }
            catch (Exception ex)
            {
                FileHelper.WriteLog("OrderRepository", ex);
            }
            return string.IsNullOrEmpty(item.PK_OrderId) ? null : item;
        }
    }
}