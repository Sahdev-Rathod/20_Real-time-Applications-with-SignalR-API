using Day20SignalRChat.DAL.Entities;
using Day20SignalRChat.Repository.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Day20SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatRepository _chatRepository;

        public ChatHub(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public async Task SendMessage(
            string userName,
            string message)
        {
            var chatMessage = new ChatMessage
            {
                UserName = userName,
                Message = message,
                SentAt = DateTime.UtcNow
            };

            var savedMessage =
                await _chatRepository.SaveMessage(chatMessage);

            await Clients.All.SendAsync(
                "ReceiveMessage",
                savedMessage);
        }
    }
}