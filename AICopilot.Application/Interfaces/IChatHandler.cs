using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICopilot.Application.Interfaces
{
    public interface IChatHandler 
    {
        Task<string> HandleAsync(string userMessage);
    }
}
