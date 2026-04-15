using AICopilot.Application.DTOs;
using AICopilot.Application.DTOS;

namespace AICopilot.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task<GetOrderStatusResponse> GetOrderStatus(int orderID);
        Task<string> CheckOrderExist(int orderID);
        Task<CustomerDetailByOrderIdResponse> GetCustomerDetailByOrderId(int orderID);
        Task<IEnumerable<OrderDetailByCustomerIDResponse>> GetOrderDetailByCustomerID(int customerID);
    }
}
