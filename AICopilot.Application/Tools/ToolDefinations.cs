using AICopilot.Application.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICopilot.Application.Tools
{
    public static class ToolDefinations
    {
        public static List<AIToolDefination> GetAll()
        {
            return new List<AIToolDefination> {
                GetOrderStatus(),
                CheckOrderExist(),
                GetCustomerDetailByOrderId(),
                GetOrderDetailByCustomerID()
            };
        }
        private static AIToolDefination GetOrderStatus()
        {
            return new AIToolDefination(
                name: "GetOrderStatus",
                description: "Get order status by order ID",
                parameters: new ToolParameterSchema
                {
                    Properties = new Dictionary<string, ToolProperty>
                    {
                        ["orderId"] = new ToolProperty
                        {
                            Type = "integer",
                            Description = "Sales order ID"
                        }
                    },
                    Required = new List<string> { "orderId" }
                }
            );
        }

        private static AIToolDefination CheckOrderExist()
        {
            return new AIToolDefination(
                name: "CheckOrderExist",
                description: "Check order exist by order ID",
                parameters: new ToolParameterSchema
                {
                    Properties = new Dictionary<string, ToolProperty>
                    {
                        ["orderId"] = new ToolProperty
                        {
                            Type = "integer",
                            Description = "Sales order ID"
                        }
                    },
                    Required = new List<string> { "orderId" }
                }
            );
        }

        private static AIToolDefination GetCustomerDetailByOrderId()
        {
            return new AIToolDefination(
                name: "GetCustomerDetailByOrderId",
                description: "Get Customer Detail by order ID if anyone asked about the detail of customer who placed the order or want information of customer against the order id. )",
                parameters: new ToolParameterSchema
                {
                    Properties = new Dictionary<string, ToolProperty>
                    {
                        ["orderId"] = new ToolProperty
                        {
                            Type = "integer",
                            Description = "Sales order ID"
                        }
                    },
                    Required = new List<string> { "orderId" }
                }
            );
        }

        private static AIToolDefination GetOrderDetailByCustomerID()
        {
            return new AIToolDefination(
                name: "GetOrderDetailByCustomerID",
                description: "Get Order Detail by customer ID if anyone asked about the detail of orders like how much order user placed, what're the current statuses of all the orders placed by customer, detail of order that user asked etc. )",
                parameters: new ToolParameterSchema
                {
                    Properties = new Dictionary<string, ToolProperty>
                    {
                        ["customerId"] = new ToolProperty
                        {
                            Type = "integer",
                            Description = "Customer ID"
                        }
                    },
                    Required = new List<string> { "customerId" }
                }
            );
        }
    }
}
