using Toolbox.Infrastructure.Entities;

namespace Toolbox.Core.Interfaces
{
    public interface IUserRepository
    {
        bool ExistsByUsername(string username);
        void Create(User user);
        User? GetByUsername(string username);
        List<User> GetAll();
        void DeleteById(int id);
        void Update(User user);
    }
}
