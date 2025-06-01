using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolbox.Infrastructure;
using Toolbox.Infrastructure.Entities;

namespace Toolbox.Core.Services
{
    public class ChatService
    {
        ToolboxDbContext dbContext;
        public ChatService(ToolboxDbContext AppDbContext)
        {
            dbContext = AppDbContext;
        }
        public void create(Chat chat)
        {
            dbContext.Chats.Add(chat);
        }
        public void update(Chat chat)
        {
            dbContext.Chats.Update(chat);
        }
        public void delete(int id)
        {
            dbContext.Chats.Where(x => x.Id.Equals(id)).ExecuteDelete();
        }
        public Chat read(int id)
        {
            return dbContext.Chats.FirstOrDefault(x => x.Id == id);
        }
    }
}
