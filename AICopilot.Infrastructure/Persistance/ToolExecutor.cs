using AICopilot.Application.DTOS;
using AICopilot.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AICopilot.Application.Tools
{
    public class ToolExecutor : IToolExecuter
    {
        private readonly IOrderRepository _orderRepository;

        public ToolExecutor(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<object?> ExecuteAsync(
        string toolName,
        string argumentsJson)
        {
            switch (toolName)
            {
                case "GetOrderStatus":
                    var orderArgs = JsonSerializer
                        .Deserialize<GetOrderStatusArg>(argumentsJson);
                    return await _orderRepository.GetOrderStatus(orderArgs!.OrderId);
                case "CheckOrderExist":
                    var orderExistArgs = JsonSerializer
                        .Deserialize<GetOrderStatusArg>(argumentsJson);
                    return await _orderRepository.CheckOrderExist(orderExistArgs!.OrderId);
                case "GetCustomerDetailByOrderId":
                    var customerDetailArgs = JsonSerializer
                        .Deserialize<GetOrderStatusArg>(argumentsJson);
                    return await _orderRepository.GetCustomerDetailByOrderId(customerDetailArgs!.OrderId);
                case "GetOrderDetailByCustomerID":
                    var orderDetailArgs = JsonSerializer
                        .Deserialize<GetCustomerIdArg>(argumentsJson);
                    return await _orderRepository.GetOrderDetailByCustomerID(orderDetailArgs!.CustomerId);

                default:
                    throw new InvalidOperationException("Unknown tool");
            }
        }

    }
}
