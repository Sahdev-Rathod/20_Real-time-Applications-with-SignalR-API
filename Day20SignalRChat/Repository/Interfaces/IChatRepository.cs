using Day20SignalRChat.DAL.Entities;

namespace Day20SignalRChat.Repository.Interfaces
{
    public interface IChatRepository
    {
        Task<ChatMessage> SaveMessage(ChatMessage message);
        Task<List<ChatMessage>> GetMessages();
    }
}