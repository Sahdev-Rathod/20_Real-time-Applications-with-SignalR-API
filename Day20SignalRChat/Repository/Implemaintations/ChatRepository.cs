using Day20SignalRChat.DAL.Entities;
using Day20SignalRChat.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Day20SignalRChat.Repository
{
    public class ChatRepository : IChatRepository
    {
        private readonly SingleDbContext _context;

        public ChatRepository(SingleDbContext context)
        {
            _context = context;
        }

        public async Task<ChatMessage> SaveMessage(
            ChatMessage message)
        {
            _context.ChatMessages.Add(message);

            await _context.SaveChangesAsync();

            return message;
        }

        public async Task<List<ChatMessage>> GetMessages()
        {
            return await _context.ChatMessages
                .OrderBy(x => x.SentAt)
                .ToListAsync();
        }
    }
}