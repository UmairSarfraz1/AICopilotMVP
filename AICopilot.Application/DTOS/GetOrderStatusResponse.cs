using AICopilot.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICopilot.Application.DTOS
{
    public class GetOrderStatusResponse
    {
        public int SalesOrderID { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
