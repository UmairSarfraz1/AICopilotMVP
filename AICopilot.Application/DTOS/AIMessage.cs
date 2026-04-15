using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICopilot.Application.DTOS
{
    public class AIMessage
    {
        public string Role { get; set; } = default!;
        public string Content { get; set; } = default!;
    }
}
