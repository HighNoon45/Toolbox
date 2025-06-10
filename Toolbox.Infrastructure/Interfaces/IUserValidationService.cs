using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toolbox.Core.Interfaces
{
    public interface IUserValidationService
    {
        /// <summary>
        /// Prüft, ob der Benutzername den definierten Richtlinien entspricht.
        /// </summary>
        /// <param name="username">Der eingegebene Benutzername</param>
        /// <param name="errorMessage">Die Fehlermeldung, falls ungültig</param>
        /// <returns>true, wenn gültig; andernfalls false</returns>
        bool IsUsernameValid(string username, out string? errorMessage);
    }
}
