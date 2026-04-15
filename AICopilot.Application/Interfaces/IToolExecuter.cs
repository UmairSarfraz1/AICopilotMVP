using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICopilot.Application.Interfaces
{
    public interface IToolExecuter
    {
        Task<object?> ExecuteAsync(string toolName, string argumentsJson);
    }
}
