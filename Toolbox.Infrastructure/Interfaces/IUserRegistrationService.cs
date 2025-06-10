using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toolbox.Core.Interfaces
{
    public interface IUserRegistrationService
    {
        bool Register(string username, string password, out string errorMessage);
    }
}
