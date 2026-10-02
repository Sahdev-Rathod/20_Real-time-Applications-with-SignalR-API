using Day20SignalRChat.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Day20SignalRChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatRepository _chatRepository;

        public ChatController(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            var messages =
                await _chatRepository.GetMessages();

            return Ok(messages);
        }

        
    }
}