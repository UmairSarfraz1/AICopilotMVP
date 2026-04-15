using AICopilot.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICopilot.Application.DTOS
{
    public class OrderDetailByCustomerIDResponse
    {
        public int ProductID { get; set; }
        public int CustomerID { get; set; }
        public int SalesOrderDetailID { get; set; }
        public int OrderQty { get; set; }
        public string Name { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}
