using AICopilot.Application.DTOS;
using AICopilot.Application.Interfaces;
using Microsoft.Extensions.Options;
using OpenAI;
using OpenAI.Chat;
using System.ClientModel;

namespace AICopilot.Infrastructure.OpenAI
{
    public class OpenAIService : IOpenAiService
    {
        private readonly ChatClient _client;
        private readonly JsonSetting _jsonSetting;

        public OpenAIService(IOptions<JsonSetting> options)
        {
            _jsonSetting = options.Value;
            var endpoint = new Uri(_jsonSetting.OpenAiEndpoint);
            var apiKey = _jsonSetting.OpenAiKey ?? "";

            //var aiOption = new OpenAIClientOptions { Endpoint = endpoint };
            var client = new OpenAIClient(new ApiKeyCredential(apiKey));

            _client = client.GetChatClient("gpt-4o-mini");
        }

        public async Task<AIResponse> SendAsync(
            List<AIMessage> messages,
            List<AIToolDefination> tools,
            bool IsToolCall = false)
        {
            var response = new AIResponse { IsToolCall = false};
            var chatMessages = new List<ChatMessage>();

            foreach (var m in messages)
            {
                chatMessages.Add(m.Role switch
                {
                    "system" => new SystemChatMessage(m.Content),
                    "user" => new UserChatMessage(m.Content),
                    "assistant" => new AssistantChatMessage(m.Content),
                    "tool" => new ToolChatMessage(m.Content),
                    _ => throw new InvalidOperationException("Unsupported role")
                });
            }
            var options = new ChatCompletionOptions();

            if (IsToolCall)
            {
                var toolDefinitions = tools
                   .Select(t => ChatTool.CreateFunctionTool(
                       functionName: t.Name,
                       functionDescription: t.Description,
                       functionParameters: BinaryData.FromObjectAsJson(t.Parameters)))
                   .ToList();

                foreach (var tool in toolDefinitions)
                    options.Tools.Add(tool);
            }

            var aiResponse = await _client.CompleteChatAsync(
                chatMessages,
                options);

            var result = aiResponse.Value;

            if (result.ToolCalls.Count > 0)
            {
                var toolCall = result.ToolCalls.Select(t => new ToolCallResponse
                {
                    ToolArguments = Convert.ToString(t.FunctionArguments),
                    ToolName = t.FunctionName,
                    ToolCallId = t.Id
                });

                response.Tools = toolCall;
                response.IsToolCall = true;
                return response;
            }

            response.Content = result.Content[0].Text;

            return response;
        }
    }
}
