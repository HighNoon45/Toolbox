using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toolbox.Core.Interfaces
{
    public interface IPasswordHandler
    {
        string HashPassword(string password, string salt);
        string GenerateSalt(int length = 16);
    }
}
