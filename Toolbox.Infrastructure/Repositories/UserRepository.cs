using System.Linq;
using Toolbox.Infrastructure.Entities;
using Toolbox.Infrastructure;

namespace Toolbox.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public bool ExistsByUsername(string username)
        {
            using var db = new ToolboxDbContext();
            return db.Users.Any(u => u.Username == username);
        }

        public void Create(User user)
        {
            using var db = new ToolboxDbContext();
            db.Users.Add(user);
            db.SaveChanges();
        }

        public User? GetByUsername(string username)
        {
            using var db = new ToolboxDbContext();
            return db.Users.FirstOrDefault(u => u.Username == username);
        }

        public List<User> GetAll()
        {
            using var db = new ToolboxDbContext();
            return db.Users.ToList();
        }

        public void DeleteById(int id)
        {
            using var db = new ToolboxDbContext();
            var user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }

        public void Update(User user)
        {
            using var db = new ToolboxDbContext();
            db.Users.Update(user);
            db.SaveChanges();
        }
    }
}
