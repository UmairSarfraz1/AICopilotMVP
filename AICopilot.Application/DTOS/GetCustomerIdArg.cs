using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AICopilot.Application.DTOS
{
    public class GetCustomerIdArg
    {
        [JsonPropertyName("customerId")]
        public int CustomerId { get; set; }
    }
}
