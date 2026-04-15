using AICopilot.Application.DTOs;
using AICopilot.Application.DTOS;
using AICopilot.Application.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace AICopilot.Infrastructure.Persistance
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string _connectionString;
        private readonly IDbConnection _dbConnection;
        public OrderRepository(IOptions<JsonSetting> options)
        {
            _connectionString = options.Value.ConnectionString;
            _dbConnection = new SqlConnection(_connectionString);
        }
        public async Task<GetOrderStatusResponse> GetOrderStatus(int orderID)
        {
            var sql = @"select SOH.Status,SO.SalesOrderID,SOH.OrderDate from SalesLT.SalesOrderHeader SOH
                        JOIN SalesLT.SalesOrderHeader SO on SO.SalesOrderID = SOH.SalesOrderID
                        where SO.SalesOrderID = @orderID";
            var result = await _dbConnection.QueryFirstOrDefaultAsync<OrderStatusDto>(sql, new { orderID });
            var response = new GetOrderStatusResponse { OrderDate = result.OrderDate , SalesOrderID = result.SalesOrderID ,Status = result.Status.ToString() };
            
            return response;
        }

        public async Task<string> CheckOrderExist(int orderID)
        {
            var sql = @"select SalesOrderID  from SalesLT.SalesOrderHeader 
                        where SalesOrderID = @orderID";
            var response = await _dbConnection.QueryFirstOrDefaultAsync<OrderExistDto>(sql, new { orderID });
            
            return response is not null ? $"Order Exist with order number {orderID}" : $"Order doesn't exist with order number {orderID}";
        }

        public async Task<CustomerDetailByOrderIdResponse> GetCustomerDetailByOrderId(int orderID)
        {
            var sql = @"select c.FirstName,c.LastName,C.CustomerID,C.EmailAddress,C.CompanyName  from SalesLT.SalesOrderHeader s JOIN 
                        SalesLT.Customer C on C.CustomerID = s.CustomerID
                        where SalesOrderID = @orderID";
            var response = await _dbConnection.QueryFirstOrDefaultAsync<CustomerDetailByOrderIdResponse>(sql, new { orderID });

            return response;
        }
        public async Task<IEnumerable<OrderDetailByCustomerIDResponse>> GetOrderDetailByCustomerID(int customerID)
        {
            var sql = @"select sd.SalesOrderDetailID,sd.OrderQty,sd.ProductID,p.Name,s.CustomerID,s.Status,s.OrderDate,s.DueDate from SalesLT.SalesOrderHeader s
                        join SalesLT.SalesOrderDetail sd on sd.SalesOrderID = s.SalesOrderID
                        join SalesLT.Product p on p.ProductID = sd.ProductID
                        where s.CustomerID = @customerID";
            var response = await _dbConnection.QueryAsync<OrderDetailByCustomerIDResponse>(sql, new { customerID });

            return response;
        }
    }
}
