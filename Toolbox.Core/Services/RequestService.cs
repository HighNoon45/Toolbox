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
    public class RequestService
    {
        ToolboxDbContext dbContext;
        public RequestService(ToolboxDbContext AppDbContext)
        {
            dbContext = AppDbContext;
        }
        public void create(Request request)
        {
            dbContext.Requests.Add(request);
        }
        public void update(Request request)
        {
            dbContext.Requests.Update(request);
        }
        public void delete(int id)
        {
            dbContext.Requests.Where(x => x.Id.Equals(id)).ExecuteDelete();
        }
        public Request read(int id)
        {
            return dbContext.Requests.FirstOrDefault(x => x.Id == id);
        }
    }
}
