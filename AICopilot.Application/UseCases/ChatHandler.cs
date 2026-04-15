using AICopilot.Application.DTOS;
using AICopilot.Application.Interfaces;
using AICopilot.Application.Tools;
using System.Net.Mail;
using System.Text;
using System.Text.Json;

namespace AICopilot.Application.UseCases
{
    public class ChatHandler : IChatHandler
    {
        private readonly IOpenAiService _openAIService;
        private readonly IToolExecuter _toolExecutor;

        public ChatHandler(IOpenAiService openAIService, IToolExecuter toolExecutor)
        {
            _openAIService = openAIService;
            _toolExecutor = toolExecutor;
        }

        public async Task<string> HandleAsync(string userMessage)
        {
            var messages = new List<AIMessage>
            {
            new() { Role = "system", Content =
                "You are an AI assistant for a business operations system.Always use the available tools when the user asks about orders, products, sales, customers, analytics, or operational data. Never guess or invent business data.Do not mention tools, internal systems, databases, or how you retrieve information. Speak naturally and confidently, as if you directly know the information.If data is returned from a tool, summarize it clearly and conversationally. Use plain language. Avoid technical terms unless the user specifically asks for them.If the information is unavailable or the tool returns no results, politely explain that no matching data was found.Never expose internal implementation details." },
            new() { Role = "user", Content = userMessage }
            };

            var tools = ToolDefinations.GetAll();

            var response = await _openAIService.SendAsync(messages, tools, true);

            if (response.IsToolCall)
            {
                StringBuilder dbResponse = new StringBuilder();

                foreach (var tool in response.Tools)
                {
                    var result = await _toolExecutor.ExecuteAsync(
                    tool.ToolName!,
                    tool.ToolArguments!);
                    dbResponse.Append(JsonSerializer.Serialize(result));
                }


                messages.Add(new AIMessage
                {
                    Role = "assistant",
                    Content = dbResponse.ToString()
                });


                var finalResponse = await _openAIService.SendAsync(messages, tools);

                return finalResponse.Content!;
            }

            return response.Content!;
        }

    }
}
