using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICopilot.Application.DTOS
{
    public class AIResponse
    {
        public bool IsToolCall { get; set; }
        public string? Content { get; set; }
        public IEnumerable<ToolCallResponse?> Tools { get; set; }
    }

    public class ToolCallResponse {
        public string? ToolName { get; set; }
        public string? ToolArguments { get; set; }
        public string ToolCallId { get; set; }
    }

}
