using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolbox.Infrastructure.Entities;
using Toolbox.Infrastructure;

namespace Toolbox.Core.Services
{
    public class ResponseService
    {
        ToolboxDbContext dbContext;
        public ResponseService(ToolboxDbContext AppDbContext)
        {
            dbContext = AppDbContext; 
        }
        public void create(Response response)
        {
            dbContext.Responses.Add(response);
        }
        public void update(Response response)
        {
            dbContext.Responses.Update(response);
        }
        public void delete(int id)
        {
            dbContext.Responses.Where(x => x.Id.Equals(id)).ExecuteDelete();
        }
        public Response read(int id)
        {
            return dbContext.Responses.FirstOrDefault(x => x.Id == id);
        }
    }
}
