using AICopilot.Application.DTOS;
using AICopilot.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AICopilot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatHandler _chatHandler;

        public ChatController(IChatHandler chatHandler)
        {
            _chatHandler = chatHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Chat([FromBody] ChatRequest request)
        {
            var response = await _chatHandler.HandleAsync(request.Message);
            return Ok(new { message = response });
        }

    }
}
