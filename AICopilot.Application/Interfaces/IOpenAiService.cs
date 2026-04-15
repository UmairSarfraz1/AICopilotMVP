using AICopilot.Application.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICopilot.Application.Interfaces
{
    public interface IOpenAiService
    {
        Task<AIResponse> SendAsync(List<AIMessage> messages, List<AIToolDefination> tools,bool isToolCall = false);
    }
}
